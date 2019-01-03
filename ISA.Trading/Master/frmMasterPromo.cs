using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Master
{
    public partial class frmMasterPromo : ISA.Trading.BaseForm
    {
        private void refreshPDB()
        {
            try
            {
                Guid rowID;
                if (this.dataGridPromoDetail.SelectedCells.Count > 0)
                    rowID = (Guid)dataGridPromoDetail.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                else
                    rowID = Guid.NewGuid();

                DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    rowID = (Guid)dataGridPromoDetail.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                    db.Commands.Add(db.CreateCommand("usp_PromoDetailBarang_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@PromoDetailRowID", SqlDbType.UniqueIdentifier, rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridPDB.DataSource = dt.DefaultView;

                    foreach (DataGridViewColumn col in dataGridPDB.Columns)
                    {
                        if (col.Name.Contains("RowID"))
                        {
                            col.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void refreshDDPromo()
        {
            try
            {
                Guid rowID;
                if (this.dataGridPromoDetail.SelectedCells.Count > 0)
                    rowID = (Guid)dataGridPromoDetail.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                else
                    rowID = Guid.NewGuid();

                DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    rowID = (Guid)dataGridPromoDetail.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                    db.Commands.Add(db.CreateCommand("usp_DDPromo_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@PromoDetailRowID", SqlDbType.UniqueIdentifier, rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridDDPromo.DataSource = dt.DefaultView;

                    foreach (DataGridViewColumn col in dataGridDDPromo.Columns)
                    {
                        if (col.Name.Contains("RowID"))
                        {
                            col.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void refreshCPromo()
        {
            try
            {
                Guid rowID;
                if (this.dataGridPromoDetail.SelectedCells.Count > 0)
                    rowID = (Guid)dataGridPromoDetail.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                else
                    rowID = Guid.NewGuid();

                DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    rowID = (Guid)dataGridPromoDetail.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                    db.Commands.Add(db.CreateCommand("usp_CPromo_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@PromoDetailRowID", SqlDbType.UniqueIdentifier, rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridCPromo.DataSource = dt.DefaultView;

                    foreach (DataGridViewColumn col in dataGridCPromo.Columns)
                    {
                        if (col.Name.Contains("RowID"))
                        {
                            col.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void refreshPromoDetail()
        {
            try
            {
                //Guid HeaderRowID;
                //if (this.dataGridPromo.SelectedCells.Count > 0)
                //    HeaderRowID = (Guid)dataGridPromo.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                //else
                //    rowID = Guid.NewGuid();

                Guid RowIDH = (Guid)Tools.isNull(dataGridPromo.SelectedCells[0].OwningRow.Cells["RowID"].Value, Guid.Empty);
                //Guid RowIDD = (Guid)Tools.isNull(dataGridPromoDetail.SelectedCells[0].OwningRow.Cells["RowIDPD"].Value, Guid.Empty);

                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Promo_Detail_LIST"));
                    //db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowIDD));
                    db.Commands[0].Parameters.Add(new Parameter("@PromoRowID", SqlDbType.UniqueIdentifier, RowIDH));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridPromoDetail.DataSource = dt.DefaultView;

                    foreach (DataGridViewColumn col in dataGridPromoDetail.Columns)
                    {
                        if (col.Name.Contains("RowID"))
                        {
                            col.Visible = false;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void refreshPromoHeader()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_Promo_Header_LIST"));
                    if (txtSearch.Text != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Ket", SqlDbType.VarChar, txtSearch.Text));
                    }
                    dt = db.Commands[0].ExecuteDataTable();
                    //dt.DefaultView.Sort = "keterangan";
                    dt.DefaultView.Sort = "tgl_sk";
                    dataGridPromo.DataSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        } 

        public frmMasterPromo()
        {
            InitializeComponent();
        }

        private void frmMasterPromo_Load(object sender, EventArgs e)
        {
            this.Title = "PROMO" ;
            dataGridPromoDetail.AutoGenerateColumns = true;
            dataGridCPromo.AutoGenerateColumns = true;
            dataGridDDPromo.AutoGenerateColumns = true;
            dataGridPDB.AutoGenerateColumns = true;
            tabControlPromo.TabPages["tabPagePromo"].Select();
            tabControlPromo.TabPages["tabPagePromo"].Focus();

            refreshPromoHeader();
            refreshPromoDetail();
            refreshCPromo();
            refreshDDPromo();
            refreshPDB();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            refreshPromoHeader();
            refreshPromoDetail();
            refreshCPromo();
            refreshDDPromo();
            refreshPDB();
        }

        private void dataGridPromo_SelectionRowChanged(object sender, EventArgs e)
        {
            refreshPromoDetail();
            refreshCPromo();
            refreshDDPromo();
            refreshPDB();
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            Master.frmPromoDownload ifrmChild = new Master.frmPromoDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridPromoDetail_SelectionRowChanged(object sender, EventArgs e)
        {
            refreshCPromo();
            refreshDDPromo();
            refreshPDB();
        }
    }
}
