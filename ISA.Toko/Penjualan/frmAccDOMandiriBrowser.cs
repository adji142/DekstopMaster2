using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Common;
using ISA.DAL;

namespace ISA.Toko.Penjualan
{
    public partial class frmAccDOMandiriBrowser : ISA.Controls.BaseForm
    {
        public frmAccDOMandiriBrowser()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAccDOMandiriBrowser_Load(object sender, EventArgs e)
        {
            rdbTglDO.FromDate = GlobalVar.DateOfServer;
            rdbTglDO.ToDate = GlobalVar.DateOfServer;

            bool isAccDo = LookupInfoValue.CekAccDo(SecurityManager.UserID);
            cmdYes.Visible = isAccDo;

            cmdSearch_Click(sender, e);
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void rdbTglDO_KeyDown(object sender, KeyEventArgs e)
        {
            cmdSearch_Click(sender, new EventArgs());
        }

        private void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DataTable dt = new DataTable();

                using (Database db = new Database())
                {
                    //db.Commands.Add(db.CreateCommand("usp_PengajuanDO_LIST"));
                    db.Commands.Add(db.CreateCommand("usp_Pengajuan_OVD_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, (DateTime)rdbTglDO.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, (DateTime)rdbTglDO.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                dataGridDO.DataSource = dt;
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

        private void UpdateAcc(Guid rowId, int bagian)
        {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateACCPiutang"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowId));
                db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, bagian));
                db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, "ACC"));
                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                dt = db.Commands[0].ExecuteDataTable();
                db.Commands[0].ExecuteNonQuery();
            }
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (dataGridDO.SelectedCells.Count > 0)
            {
                Guid rowId = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells[RowID.Name].Value;
                bool isOverdueBe = dataGridDO.SelectedCells[0].OwningRow.Cells[IsOverdueBE.Name].Value.ToString() == "YA";
                bool isSalesBl = dataGridDO.SelectedCells[0].OwningRow.Cells[IsSalesBL.Name].Value.ToString() == "YA";
                string noDo = dataGridDO.SelectedCells[0].OwningRow.Cells[NoDo.Name].Value.ToString();

                DateTime TglDo = Convert.ToDateTime(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[TglDO.Name].Value, "").ToString());
                String KdSales = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[KodeSales.Name].Value, "").ToString();
                String KdToko = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[KodeToko.Name].Value, "").ToString();
                Double Plf = Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[plf_fb.Name].Value, 0).ToString());
                Double Ptg = Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[piutang.Name].Value, 0).ToString());
                Double Git = Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[GIT.Name].Value, 0).ToString());
                Double Gro = Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[Giro.Name].Value, 0).ToString());
                Double Grt = Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[GiroTolak.Name].Value, 0).ToString());
                Double JDo = Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[SumRpNet.Name].Value, 0).ToString());
                Double Ovd = Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[ovdBE.Name].Value, 0).ToString());
                Double Hro = Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[hrbe.Name].Value, 0).ToString());
                Double Ovs = Convert.ToDouble(Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[ovdsbl.Name].Value, 0).ToString());
                String NoAccPst = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[NoAccPusat.Name].Value, "").ToString();
                String NoAccPtg = Tools.isNull(dataGridDO.SelectedCells[0].OwningRow.Cells[NoAccPiutang.Name].Value, "").ToString();
                String _kdgud = GlobalVar.Gudang;

                DialogResult dlg = new DialogResult();
                if (isOverdueBe)
                {
                    dlg = MessageBox.Show("Acc Pengajuan Overdue DO " + noDo + "?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dlg == DialogResult.Yes)
                    {
                        //UpdateAcc(rowId, PinId.Bagian.OverdueFB);
                        UpdateHistAcc(rowId, PinId.Bagian.OverdueFB, NoAccPst, NoAccPtg, noDo, TglDo, KdSales, KdToko
                            , Plf, Ptg, Git, Gro, Grt, JDo, Ovd, Hro, Ovs);
                        cmdSearch_Click(sender, e);
                    }
                }

                //if (isSalesBl)
                //{
                //    dlg = MessageBox.Show("Acc Pengajuan Sales BL DO " + noDo + "?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                //    if (dlg == DialogResult.Yes)
                //    {
                //        bool isAcc = DialogResult == DialogResult.Yes;
                //        UpdateAcc(rowId, PinId.Bagian.SalesBL);
                //        cmdSearch_Click(sender, e);
                //    }
                //}
            }
        }


        private void UpdateHistAcc(Guid rowId, int bagian, String NoAccPst, String NoAccPtg, String noDO, DateTime TglDo
            , String KdSales, String KdToko, Double Plf, Double Ptg, Double Git, Double Gro, Double Grt, Double JDo
            , Double Ovd, Double Hro, Double Ovs)
        {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_updateHistACCPiutang"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowId));
                db.Commands[0].Parameters.Add(new Parameter("@bagian", SqlDbType.Int, bagian));
                db.Commands[0].Parameters.Add(new Parameter("@NoAccPst", SqlDbType.VarChar, NoAccPst));
                db.Commands[0].Parameters.Add(new Parameter("@NoAccPtg", SqlDbType.VarChar, NoAccPtg));
                db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, "ACC"));
                db.Commands[0].Parameters.Add(new Parameter("@NoDo", SqlDbType.VarChar, noDO));
                db.Commands[0].Parameters.Add(new Parameter("@tglDo", SqlDbType.DateTime, TglDo));
                db.Commands[0].Parameters.Add(new Parameter("@KdSales", SqlDbType.VarChar, KdSales));
                db.Commands[0].Parameters.Add(new Parameter("@KdToko", SqlDbType.VarChar, KdToko));
                db.Commands[0].Parameters.Add(new Parameter("@plafon", SqlDbType.Money, Plf));
                db.Commands[0].Parameters.Add(new Parameter("@piutang", SqlDbType.Money, Ptg));
                db.Commands[0].Parameters.Add(new Parameter("@git", SqlDbType.Money, Git));
                db.Commands[0].Parameters.Add(new Parameter("@giro", SqlDbType.Money, Gro));
                db.Commands[0].Parameters.Add(new Parameter("@girotolak", SqlDbType.Money, Grt));
                db.Commands[0].Parameters.Add(new Parameter("@sumrpnet", SqlDbType.Money, JDo));
                db.Commands[0].Parameters.Add(new Parameter("@ovdbe", SqlDbType.Money, Ovd));
                db.Commands[0].Parameters.Add(new Parameter("@hrbe", SqlDbType.Money, Hro));
                db.Commands[0].Parameters.Add(new Parameter("@ovdsbl", SqlDbType.Money, Ovs));
                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                dt = db.Commands[0].ExecuteDataTable();
                db.Commands[0].ExecuteNonQuery();
            }
        }
    }
}
