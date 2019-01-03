using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance.Kasir
{
    public partial class frmBudget : ISA.Controls.BaseForm
    {
        public frmBudget()
        {
            InitializeComponent();
        }

        private void frmBudget_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            monthYearBox1.Month = GlobalVar.DateOfServer.Month;
            monthYearBox1.Year = GlobalVar.DateOfServer.Year;
            RefreshBudget();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshBudget();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int n = 0;
                using (Database db = new Database(GlobalVar.DBName))
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        Guid _RowId = (Guid)row.Cells["RowId"].Value;
                        double _NominalAjuan = double.Parse(Tools.isNull(row.Cells["NominalAjuan"].Value, "0").ToString());
                        string _Keterangan00 = Tools.isNull(row.Cells["Keterangan00"].Value, string.Empty).ToString();


                        if (_NominalAjuan > 0)
                        {
                            db.Commands.Add(db.CreateCommand("usp_Budget_UPDATE"));
                            db.Commands[n].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowId));
                            db.Commands[n].Parameters.Add(new Parameter("@NominalAjuan", SqlDbType.Money, _NominalAjuan));
                            db.Commands[n].Parameters.Add(new Parameter("@Keterangan00", SqlDbType.VarChar, _Keterangan00.ToUpper()));
                            db.Commands[n].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[n].ExecuteNonQuery();
                            n++;
                        }
                    }
                RefreshBudget();
                this.Cursor = Cursors.Default;
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

        public void RefreshBudget()
        {
            DateTime _TanggalMulai = monthYearBox1.FirstDateOfMonth;
            DateTime _TanggalSelesai = monthYearBox1.LastDateOfMonth;
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Budget_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalMulai", SqlDbType.DateTime, _TanggalMulai));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalSelesai", SqlDbType.DateTime, _TanggalSelesai));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                    if (dt.Rows.Count == 0)
                    {
                        checkBox1.Checked = false;
                        if (MessageBox.Show("Budget Rencana Bulanan Periode " + monthYearBox1.MonthName + " " + monthYearBox1.Year.ToString() + " Tidak ada\nDownload dari Budget Mingguan ?", "Budget Rencana", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            BudgetInsert();
                        }
                    }
                    else
                    {
                        checkBox1.Checked = (bool)dataGridView1.SelectedCells[0].OwningRow.Cells["SyncFlag"].Value;
                        tbTotalAjuan.Text = dt.Compute("Sum(NominalAjuan)", string.Empty).ToString();
                        tbTotalACC.Text = dt.Compute("Sum(NominalACC)", string.Empty).ToString();
                        if (checkBox1.Checked == true)
                        {
                            //dataGridView1.Columns["NominalAjuan"].ReadOnly = true;
                            dataGridView1.Columns["Keterangan00"].ReadOnly = true;
                        }
                        else
                        {
                            //dataGridView1.Columns["NominalAjuan"].ReadOnly = false;
                            dataGridView1.Columns["Keterangan00"].ReadOnly = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void BudgetInsert()
        {
            DateTime _TanggalMulai = monthYearBox1.FirstDateOfMonth;
            DateTime _TanggalSelesai = monthYearBox1.LastDateOfMonth;
            string _UserInitial = SecurityManager.UserInitial;
            string _KodeGudang = GlobalVar.Gudang;

            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Budget_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalMulai", SqlDbType.DateTime, _TanggalMulai));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalSelesai", SqlDbType.DateTime, _TanggalSelesai));
                    db.Commands[0].Parameters.Add(new Parameter("@UserInitial", SqlDbType.VarChar, _UserInitial));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, _KodeGudang));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                    //checkBox1.Checked = false;
                    //dataGridView1.SelectedCells[0].OwningRow.Cells["NominalAjuan"].ReadOnly = false;
                    //dataGridView1.SelectedCells[0].OwningRow.Cells["Keterangan00"].ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

    }
}
