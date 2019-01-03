using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.VACCDO;


namespace ISA.Trading.VACCDO_Pos
{
    public partial class frmACCDOPosBrowseISA : ISA.Trading.BaseForm
    {
        string docNO = "NOMOR_ACC_DO";
        string initPerusahaan = GlobalVar.PerusahaanID;
        string host = Database.Host ;
        public frmACCDOPosBrowseISA()
        {
            InitializeComponent();
        }

        private void frmACCDOBrowseISA_Load(object sender, EventArgs e)
        {
            chBoFilter.Checked = true;
            chBoFilter.Text = "Tampilkan seluruhnya";
            rgbTglDO.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTglDO.ToDate = DateTime.Now;
        }

        private void chBoFilter_Click(object sender, EventArgs e)
        {
            if (chBoFilter.Checked == false)
            {
                chBoFilter.Text = "Tampilkan yang belum ACC saja.";
                RefreshDataBelum();
            }
            else
            {
                chBoFilter.Text = "Tampilkan seluruhnya";
                RefreshDataSeluruhnya();
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataSeluruhnya();
        }

        public void RefreshDataSeluruhnya()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    
                    db.Commands.Add(db.CreateCommand("usp_ACCDOPos_LIST")); //H cek table, 14032013
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglDO.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglDO.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();                    
                }
                dt.DefaultView.Sort = "TglDO, NoDo";
                dataGridView1.DataSource = dt;               
            }
            catch (Exception ex)
            {
                //Error.LogError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        public void RefreshRowDataDO(string _rowID)
        {
            Guid rowID = new Guid(_rowID);
            DataTable dtRefresh;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRefresh = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ACCDOPos_LIST_FILTER_ROWID"));//h cek 14032013
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }

                if (dtRefresh.Rows.Count > 0)
                {
                    dataGridView1.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID.ToString());
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

        public void RefreshDataBelum()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_ACCDOPos_LIST")); //h, cek 14032013
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglDO.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglDO.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@filter", SqlDbType.VarChar, ""));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                //Error.LogError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdApprove_Click(object sender, EventArgs e)
        {
            Guid doID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            DataTable dt = new DataTable();
            try
            {
                int nota_ = 0;

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_NotaPenjualan_CHEK]")); //H, cek 14032013
                    db.Commands[0].Parameters.Add(new Parameter("@doID", SqlDbType.UniqueIdentifier, doID));
                    nota_ = Convert.ToInt32(db.Commands[0].ExecuteScalar());
                    //dt = db.Commands[0].ExecuteDataTable();
                }

                if (nota_ > 0//dt.Rows.Count > 0 
                    && !SecurityManager.AskPasswordManager())
                {
                    MessageBox.Show("Anda tidak berwenang untuk ACC ulang");
                    return;
                }

                
               
                Guid headerID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                string kodeToko = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
                DateTime tglDo = (DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglDO"].Value;
                string NamaToko_ = dataGridView1.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString();
                string AlamatToko_ = dataGridView1.SelectedCells[0].OwningRow.Cells["AlamatKirim"].Value.ToString();
                string CatatanTOko_ = dataGridView1.SelectedCells[0].OwningRow.Cells["CatatanToko"].Value.ToString();
                string Grade_ = dataGridView1.SelectedCells[0].OwningRow.Cells["Grade"].Value.ToString();
                VACCDO.frmACCDOBrowseISA accdo = new VACCDO.frmACCDOBrowseISA();
                accdo.F12(kodeToko, NamaToko_, AlamatToko_, Grade_, CatatanTOko_);

                VACCDO_Pos.frmPlafonPosISA ifrmChild = new VACCDO_Pos.frmPlafonPosISA(this, headerID, kodeToko, tglDo);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                
                ifrmChild.Show();


                //RefreshRowDataDO(doID.ToString());
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                cmdApprove.PerformClick();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells["NoACC"].Value.ToString() == "")
            {

                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
            else
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
            }
        }
    }
}
