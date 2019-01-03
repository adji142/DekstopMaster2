using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using ISA.Toko.Class;
using Microsoft.Reporting.WinForms;


namespace ISA.Toko.Kasir
{
    public partial class frmPenerimaanTunai : ISA.Toko.BaseForm
    {
        public frmPenerimaanTunai()
        {
            InitializeComponent();
        }

        private void frmPenerimaanTunai_Load(object sender, EventArgs e)
        {
            rangeTanggal.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeTanggal.ToDate = DateTime.Now;
            RefreshData();
        }

        public void RefreshData()
        {
            if (rangeTanggal.FromDate.ToString() == "" || rangeTanggal.ToDate.ToString() == "")
            {
                MessageBox.Show("Range tanggal isi dengan benar");
                rangeTanggal.Focus();
                return;
            }


            try
            {
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanTunai_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeTanggal.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeTanggal.ToDate.Value));
                    dt = db.Commands[0].ExecuteDataTable();
                    customGridView1.DataSource = dt;
                }               

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSeacrh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            Kasir.frmPenerimaanTunaiUpdate ifrmChild = new Kasir.frmPenerimaanTunaiUpdate(this);
            ifrmChild.WindowState = FormWindowState.Normal;
            ifrmChild.ShowDialog();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {

            if (customGridView1.SelectedCells.Count == 0)
            {
                return;
            }

            string _Pin = customGridView1.SelectedCells[0].OwningRow.Cells["Pin"].Value.ToString();            

            if (_Pin != "")
            {
                MessageBox.Show("PIN Sudah Terisi", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Guid _RowID = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database(GlobalVar.DBFinance))
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_PenerimaanTunai_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID",SqlDbType.UniqueIdentifier, _RowID));
                        db.Commands[0].ExecuteNonQuery();
                    }

                    MessageBox.Show("Record Berhasil Dihapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.RefreshData();
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

        private void cmdIsiPin_Click(object sender, EventArgs e)
        {

            if (PeriodeClosing.IsKasirClosed(GlobalVar.DateOfServer))
            {
                MessageBox.Show("Sudah clossing kasir!");
                return;
            }
            
            Guid _RowID = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            string _Pin = customGridView1.SelectedCells[0].OwningRow.Cells["Pin"].Value.ToString();
            DateTime _tgltrm = Convert.ToDateTime(customGridView1.SelectedCells[0].OwningRow.Cells["TanggalTerima"].Value.ToString());

            //string _Collector = customGridView1.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();
            if (_Pin != "")
            {
                MessageBox.Show("PIN Sudah Terisi", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string PUBLICKEY = customGridView1.SelectedCells[0].OwningRow.Cells["PublicKey"].Value.ToString();
            //Kasir.frmPenerimaanTunaiPIN ifrmChild = new Kasir.frmPenerimaanTunaiPIN(this, _RowID, PUBLICKEY, _tgltrm);
            //ifrmChild.WindowState = FormWindowState.Normal;
            //ifrmChild.ShowDialog();
         
        }

        private void cmdMintaPin_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtt = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanTunai_MintaPIN"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeTanggal.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeTanggal.ToDate.Value));
                    dtt = db.Commands[0].ExecuteDataTable();
                }
                if (dtt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak Ada Data", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    DisplayReport(dtt);
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

        private void DisplayReport(DataTable dtt)
        {
            string _FromDate, _ToDate;
            //_FromDate = String.Format("{0}", rangeTanggal.FromDate.Value.ToString("dd-MMM-yyyy"));
            //_ToDate = String.Format("{0}", rangeTanggal.ToDate.Value.ToString("dd-MMM-yyyy"));

            _FromDate = DateTime.Now.ToString("dd-MMM-yyyy");
            _ToDate = DateTime.Now.ToString("dd-MMM-yyyy");
            
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("FromDate", _FromDate));
            rptParams.Add(new ReportParameter("ToDate", _ToDate));
            rptParams.Add(new ReportParameter("Gudang", GlobalVar.Gudang));
            rptParams.Add(new ReportParameter("Perusahaan", GlobalVar.PerusahaanName));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Kasir.rptPenerimaanTunaiMintaPIN.rdlc", rptParams, dtt, "dsPenerimaanTunai_Data");
            ifrmReport.Show();  
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rangeTanggal_Leave(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void FindRow(Guid _RowID)
        {
            customGridView1.FindRow("RowID", _RowID.ToString());
        }

        private void customGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }        
    }
}
