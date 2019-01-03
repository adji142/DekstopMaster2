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

namespace ISA.Finance.Kasir.Budget
{
    public partial class frmBudgetMingguan : ISA.Controls.BaseForm
    {
        string Moderefresh = "";
        public frmBudgetMingguan()
        {
            InitializeComponent();
        }

        private void frmBudgetMingguan_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            rangePriode.Month = GlobalVar.DateTimeOfServer.Month;
            rangePriode.Year = GlobalVar.DateTimeOfServer.Year;
            GVDetail.AutoGenerateColumns = false;
            Moderefresh = "Load";
            //listDataBudget();
        }



        public void listDataBudget()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_BudgetMingguan_List]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalMulai", SqlDbType.DateTime, rangePriode.FirstDateOfMonth));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalSelesai", SqlDbType.DateTime, rangePriode.LastDateOfMonth));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                GVHeader.DataSource = dt;

                if (GVHeader.Rows.Count > 0)
                {
                    cmdAdd.Enabled = false;
                    cmdSave.Enabled = true;
                }
                else
                {
                    cmdAdd.Enabled = true;
                    cmdSave.Enabled = false;
                    GVDetail.DataSource = null;
                }

                if (rangePriode.LastDateOfMonth < GlobalVar.DateTimeOfServer)
                {
                    cmdEdit.Enabled = false;
                }
                else
                {
                    cmdEdit.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void listDataBudgetDetail()
        {
            if (GVHeader.Rows.Count > 0)
            {
                try
                {
                    Guid RowID = (Guid)Tools.isNull(this.GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value, Guid.Empty);
                    DataTable dt = new DataTable();
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_BudgetMingguanDetail_List]"));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, RowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    GVDetail.DataSource = dt;

                    if (GVDetail.Rows.Count > 0)
                    {
                        bool hasil = (bool)dt.Rows[0]["SynchFlag"];
                        if (hasil)
                        {
                            GVDetail.Columns["NominalRencana"].ReadOnly = true;
                            GVDetail.Columns["KeteranganD"].ReadOnly = true;
                            cmdEdit.Enabled = false;
                            cmdSave.Enabled = false;
                        }
                        else
                        {
                            GVDetail.Columns["NominalRencana"].ReadOnly = false;
                            GVDetail.Columns["KeteranganD"].ReadOnly = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                GVDetail.DataSource = null;
            }
        }

        private void Save()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int n = 0;
                using (Database db = new Database(GlobalVar.DBName))
                    foreach (DataGridViewRow row in GVDetail.Rows)
                    {
                        Guid _RowId = (Guid)row.Cells["RowIDD"].Value;
                        double _NominalAjuan = double.Parse(Tools.isNull(row.Cells["NominalRencana"].Value, "0").ToString());
                        string _Keterangan00 = Tools.isNull(row.Cells["KeteranganD"].Value, string.Empty).ToString();


                        //if (_NominalAjuan > 0)
                        //{
                        db.Commands.Add(db.CreateCommand("usp_BudgetMingguanDetail_Update"));
                        db.Commands[n].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowId));
                        db.Commands[n].Parameters.Add(new Parameter("@NominalRencana", SqlDbType.Money, _NominalAjuan));
                        db.Commands[n].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, _Keterangan00.ToUpper()));
                        db.Commands[n].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[n].ExecuteNonQuery();
                        n++;
                        //}
                    }
                BudgetInsert();
                MessageBox.Show("Berhasil Disimpan");
                listDataBudget();
                this.Cursor = Cursors.Default;
            }

            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void BudgetInsert()
        {
            DateTime _TanggalMulai = rangePriode.FirstDateOfMonth;
            DateTime _TanggalSelesai = rangePriode.LastDateOfMonth;
            string _UserInitial = SecurityManager.UserInitial;
            string _KodeGudang = GlobalVar.Gudang;

            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_BudgetMingguan_insertBudgetBulanan]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalMulai", SqlDbType.DateTime, _TanggalMulai));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalSelesai", SqlDbType.DateTime, _TanggalSelesai));
                    db.Commands[0].Parameters.Add(new Parameter("@UserInitial", SqlDbType.VarChar, _UserInitial));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            listDataBudget();
        }

        private void GVHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            //if (GVHeader.SelectedCells[0].OwningRow.Cells["MingguKe"].Value.ToString() != "" && GVHeader.Rows.Count > 0)
            //{
            //    if (MessageBox.Show("Simpan Data ? /n jika tidak save data akan hilang", "Download", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            //    {
            //        Save();
            //    }
            //}
            listDataBudgetDetail();
        }

        private void GVHeader_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            Kasir.Budget.frmBudgetMingguanUpdate ifrmChild = new Kasir.Budget.frmBudgetMingguanUpdate(this, rangePriode.FirstDateOfMonth, rangePriode.LastDateOfMonth);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            Kasir.Budget.frmBudgetMingguanUpdate ifrmChild = new Kasir.Budget.frmBudgetMingguanUpdate(this, rangePriode.FirstDateOfMonth, rangePriode.LastDateOfMonth);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }





    }
}
