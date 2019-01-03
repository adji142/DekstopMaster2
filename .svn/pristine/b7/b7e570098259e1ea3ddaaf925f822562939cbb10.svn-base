using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
using System.IO;
using ISA.Trading.Class;
using System.IO.Compression;
using System.Data.SqlClient;



namespace ISA.Trading.Persediaan
{
    public partial class frmStandarStok : ISA.Trading.BaseForm
    {
        int prevGrid1Row = -1;

        #region "Function & Procedure"
        bool _Finish1;
        string _KodeBarang;
        int _AVGDay;
        private void RefreshHeader(string Like)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Stok_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaStok", SqlDbType.VarChar, Like));
                    dt = db.Commands[0].ExecuteDataTable();
                    dt.DefaultView.Sort = "NamaStok ASC";
                    dataGridHeader.DataSource = dt.DefaultView;
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

        private void RefreshHeader()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_Stok_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@bit", SqlDbType.Bit, 0));
                    dt = db.Commands[0].ExecuteDataTable();

                }
                dt.DefaultView.Sort = "NamaStok ASC";
                dataGridHeader.DataSource = dt.DefaultView;
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

        public void RefreshData1(string BarangID)
        {
            try
            {

                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_StandarStok_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, BarangID));

                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridDetail1.DataSource = dt;
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

        public void RefreshData2()
        {
            try
            {

                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_StandarStokHistory_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, _KodeBarang));

                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridDetail2.DataSource = dt;
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


        public void RefreshStokBuffer(string barangid)
        {
            try
            {

                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_StokBuffer_list"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangid", SqlDbType.VarChar, barangid));

                    dt = db.Commands[0].ExecuteDataTable();
                    dgvStokBuffer.DataSource = dt;
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
        #endregion


        public frmStandarStok()
        {
            InitializeComponent();
        }

        private void frmStandarStok_Load(object sender, EventArgs e)
        {
            dataGridHeader.AutoGenerateColumns = false;
            dataGridDetail1.AutoGenerateColumns = false;
            dataGridDetail2.AutoGenerateColumns = false;
            _KodeBarang = "";
            _AVGDay = 0;
            label1.Text = "";
            _Finish1 = false;
            RefreshHeader();
            _Finish1 = true;
        }

        private void dataGridHeader_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.F3:
                        //if (!SecurityManager.IsAuditor())
                        //{
                        //    Persediaan.frmStandarStokHitungStandar ifrmChild = new Persediaan.frmStandarStokHitungStandar(this, _KodeBarang, _AVGDay);
                        //    ifrmChild.MdiParent = Program.MainForm;
                        //    Program.MainForm.RegisterChild(ifrmChild);
                        //    ifrmChild.Show();
                        //}
                        break;
                    case Keys.F4:
                        if (!SecurityManager.IsAuditor())
                        {
                            Persediaan.frmStandarStokHitungAll ifrmChild = new Persediaan.frmStandarStokHitungAll(this, _KodeBarang);
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                        break;
                }
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshHeader(textBox1.Text.Trim());
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }


        }

        private void dataGridHeader_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_Finish1)
            {
                if (dataGridHeader.Rows[e.RowIndex].Cells["StatusPasif"].Value.ToString() == "True")
                {
                    dataGridHeader.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                }
                else
                {
                    dataGridHeader.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }

        }

        private void dataGridHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            if (_Finish1)
            {
                if (dataGridHeader.SelectedCells.Count > 0)
                {
                    label1.Text = dataGridHeader.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();
                    _KodeBarang = dataGridHeader.SelectedCells[0].OwningRow.Cells["KodeBarang"].Value.ToString();
                    _AVGDay = (int)dataGridHeader.SelectedCells[0].OwningRow.Cells["HariRataRata"].Value;
                    RefreshData1(_KodeBarang);
                    RefreshData2();
                    RefreshStokBuffer(_KodeBarang);

                }
            }
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            if (dataGridHeader.Rows.Count > 0)
            {
                Communicator.FrmStokbufferUpload ifrmChild = new Communicator.FrmStokbufferUpload();
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
