using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using ISA.Toko.DataTemplates;

namespace ISA.Toko.Persediaan
{
    public partial class frmRecalculateStokGudang : ISA.Toko.BaseForm
    {
        DataTable _dt;
        string _gudang;
        public frmRecalculateStokGudang()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form Kalkulasi stok pergudang
        /// </summary>
        /// <param name="caller">Form Pemanggil</param>
        /// <param name="dt_">Datatable Stok</param>
        /// <param name="gudang_">Kode Gudang</param>
        public frmRecalculateStokGudang(Form caller,DataTable dt_, string gudang_)
        {
            _dt = dt_;
            _gudang = gudang_;
            this.Caller = caller;
            InitializeComponent();
        }

        private void frmRecalculateStokGudang_Load(object sender, EventArgs e)
        {
            if(_dt.Rows.Count>0)
            {
                _dt.DefaultView.Sort = "NamaStok ASC";
                customGridView1.DataSource = _dt;
                progressBar1.Value = 0;
                progressBar1.Maximum = _dt.Rows.Count;
                lblCount.Text = progressBar1.Value.ToString("#,##0") + " / " + progressBar1.Maximum.ToString("#,##0");
                RefreshBar();
            
            }
        }
          
        private void RefreshBar()
        {
            Application.DoEvents();
            this.Invalidate();
            lblCount.Text = progressBar1.Value.ToString("#,##0") + " / " + progressBar1.Maximum.ToString("#,##0");
        }

        private void Recalculate(DataTable dt_, string gudang_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                 using (Database db = new Database())
                {
                    int i = 0;
                    int v = 0;
                    progressBar1.Value = 0;
                    progressBar1.Maximum = dt_.Rows.Count;
                    foreach (DataRow row in dt_.Rows)
                    {

                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("psp_StokGudang_Recalculation"));
                        db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, gudang_));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, row["BarangID"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        v = db.Commands[0].ExecuteNonQuery();

                        //if (v > 0)
                        //{
                            //this.customGridView1.Rows[i].Cells[0].Style.ForeColor = Color.Green;
                            //this.customGridView1.Rows[i].Cells[1].Style.ForeColor = Color.Green;
                            i++;
                            progressBar1.Value = i;
                            
                            //customGridView1.Refresh();
                            RefreshBar();
                        //}
                    }
                  }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            if (customGridView1.RowCount > 0)
            {
                if (MessageBox.Show(string.Format(Messages.Question.AskCalculateGudang, _gudang), "Calculate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                try
                {
                    Recalculate(_dt, _gudang);
                    MessageBox.Show("Proses Telah Selesai");
                    CloseForm();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {

                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRecalculateStokGudang_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void CloseForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmStokGudang)
                {
                    frmStokGudang frmCaller = (frmStokGudang)this.Caller;
                    frmCaller.RefreshDetail(_gudang);
                    
                }
            }
        }

        private void customGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmRecalculateStokGudang_Resize(object sender, EventArgs e)
        {
            lblCount.Top = progressBar1.Top + progressBar1.Height + 10;
        }
    }
}
