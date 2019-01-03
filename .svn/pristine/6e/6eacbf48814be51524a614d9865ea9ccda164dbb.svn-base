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
    public partial class frmBudgetMingguanUpdate : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode FormMode;
        DateTime TglAwal, TglAkhir;
        DataTable listData;

        public frmBudgetMingguanUpdate()
        {
            InitializeComponent();
        }

        private void frmBudgetMingguanUpdate_Load(object sender, EventArgs e)
        {
            listDataBudget();
            int jml = listData.Rows.Count;
            if (jml == 0)
            {
                txtDate1A.DateValue = TglAwal;
                txtDate1B.DateValue = TglAwal.AddDays(6);
                txtDate2A.DateValue = TglAwal.AddDays(7);
                txtDate2B.DateValue = TglAwal.AddDays(13);
                txtDate3A.DateValue = TglAwal.AddDays(14);
                txtDate3B.DateValue = TglAwal.AddDays(20);
                txtDate4A.DateValue = TglAwal.AddDays(21);
                txtDate4B.DateValue = TglAwal.AddDays(27);
                txtDate5A.DateValue = TglAwal.AddDays(28);
                txtDate5B.DateValue = TglAwal.AddDays(28);
            }
            else
            {
                txtDate2B.Enabled = false;
                txtDate3B.Enabled = false;
                txtDate4B.Enabled = false;
                txtDate5B.Enabled = false;

                if (jml >= 1)
                {
                    txtDate1A.DateValue = (DateTime)listData.Rows[0]["TanggalMulai"];
                    txtDate1B.DateValue = (DateTime)listData.Rows[0]["TanggalSelesai"];
                }

                if (jml >= 2)
                {
                    txtDate2A.DateValue = (DateTime)listData.Rows[1]["TanggalMulai"];
                    txtDate2B.DateValue = (DateTime)listData.Rows[1]["TanggalSelesai"];
                    txtDate2B.Enabled = true;
                }

                if (jml >= 3)
                {
                    txtDate3A.DateValue = (DateTime)listData.Rows[2]["TanggalMulai"];
                    txtDate3B.DateValue = (DateTime)listData.Rows[2]["TanggalSelesai"];
                    txtDate3B.Enabled = true;
                }

                if (jml >= 4)
                {
                    txtDate4A.DateValue = (DateTime)listData.Rows[3]["TanggalMulai"];
                    txtDate4B.DateValue = (DateTime)listData.Rows[3]["TanggalSelesai"];
                    txtDate4B.Enabled = true;
                }

                if (jml >= 5)
                {
                    txtDate5A.DateValue = (DateTime)listData.Rows[4]["TanggalMulai"];
                    txtDate5B.DateValue = (DateTime)listData.Rows[4]["TanggalSelesai"];
                    txtDate5B.Enabled = true;
                }

                txtKeterangan.Text = Tools.isNull(listData.Rows[0]["Keterangan"], "").ToString();
            }
        }

        public frmBudgetMingguanUpdate(Form caller, DateTime tgl1, DateTime tgl2)
        {
            InitializeComponent();
            FormMode = enumFormMode.New;
            this.Caller = caller;
            TglAwal = tgl1;
            TglAkhir = tgl2;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                return;
            }

            int i = 0;
            BudgetInsert("1", (DateTime)txtDate1A.DateValue, (DateTime)txtDate1B.DateValue);


            if (txtDate2B.Enabled)
            {
                BudgetInsert("2", (DateTime)txtDate2A.DateValue, (DateTime)txtDate2B.DateValue);
                i = 2;
            }

            if (txtDate3B.Enabled)
            {
                BudgetInsert("3", (DateTime)txtDate3A.DateValue, (DateTime)txtDate3B.DateValue);
                i = 3;
            }

            if (txtDate4B.Enabled)
            {
                BudgetInsert("4", (DateTime)txtDate4A.DateValue, (DateTime)txtDate4B.DateValue);
                i = 4;
            }

            if (txtDate5B.Enabled)
            {
                BudgetInsert("5", (DateTime)txtDate5A.DateValue, (DateTime)txtDate5B.DateValue);
                i = 5;
            }

            deleteDataBudget(i);

            MessageBox.Show("Proses Selesai");
            if (this.Caller is frmBudgetMingguan)
            {
                frmBudgetMingguan frmCaller = (frmBudgetMingguan)this.Caller;
                frmCaller.listDataBudget();
                //frmCaller.FindRowHeader("StockRowID", _stockRowId.ToString());
            }

            this.Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDate1B_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtDate1B.DateValue >= TglAkhir)
                {
                    txtDate2B.Enabled = false;
                    txtDate3B.Enabled = false;
                    txtDate4B.Enabled = false;
                    txtDate5B.Enabled = false;
                }
                else
                {
                    txtDate2B.Enabled = true;
                    txtDate2A.DateValue = ((DateTime)txtDate1B.DateValue).AddDays(1);
                }
            }
            catch
            {
            }
        }

        private void txtDate2B_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtDate2B.DateValue >= TglAkhir)
                {
                    txtDate3B.Enabled = false;
                    txtDate4B.Enabled = false;
                    txtDate5B.Enabled = false;
                }
                else
                {
                    txtDate3B.Enabled = true;
                    txtDate3A.DateValue = ((DateTime)txtDate2B.DateValue).AddDays(1);
                }
            }
            catch
            {
            }
        }

        private void txtDate3B_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtDate3B.DateValue >= TglAkhir)
                {
                    txtDate4B.Enabled = false;
                    txtDate5B.Enabled = false;
                }
                else
                {
                    txtDate4B.Enabled = true;
                    txtDate4A.DateValue = ((DateTime)txtDate3B.DateValue).AddDays(1);
                }
            }
            catch
            {
            }
        }

        private bool validate()
        {
            bool hasil = false;
            if (txtDate1A.DateValue < TglAwal)
            {
                MessageBox.Show("Tgl Awal tidak boleh kurang dari " + TglAwal.ToString("dd-MM-yyyy"));
                txtDate1B.Focus();
                hasil = true;
            }
            if (txtDate1A.DateValue > txtDate1B.DateValue)
            {
                MessageBox.Show("Tgl Selesai harus >= Tanggal Awal");
                txtDate1B.Focus();
                hasil = true;
            }

            if (txtDate2B.Enabled && txtDate2A.DateValue > txtDate2B.DateValue)
            {
                MessageBox.Show("Tgl Selesai harus >= Tanggal Awal");
                txtDate2B.Focus();
                hasil = true;
            }

            if (txtDate2B.Enabled && txtDate2B.DateValue > TglAkhir)
            {
                MessageBox.Show("Tgl Selesai harus tidak boleh lebih dari " + TglAkhir.ToString("dd-MM-yyyy"));
                txtDate2B.Focus();
                hasil = true;
            }

            if (txtDate3B.Enabled && txtDate3A.DateValue > txtDate3B.DateValue)
            {
                MessageBox.Show("Tgl Selesai harus >= Tanggal Awal");
                txtDate3B.Focus();
                hasil = true;
            }

            if (txtDate3B.Enabled && txtDate3B.DateValue > TglAkhir)
            {
                MessageBox.Show("Tgl Selesai harus tidak boleh lebih dari " + TglAkhir.ToString("dd-MM-yyyy"));
                txtDate3B.Focus();
                hasil = true;
            }

            if (txtDate4B.Enabled && txtDate4A.DateValue > txtDate4B.DateValue)
            {
                MessageBox.Show("Tgl Selesai harus >= Tanggal Awal");
                txtDate4B.Focus();
                hasil = true;
            }

            if (txtDate4B.Enabled && txtDate4B.DateValue > TglAkhir)
            {
                MessageBox.Show("Tgl Selesai harus tidak boleh lebih dari " + TglAkhir.ToString("dd-MM-yyyy"));
                txtDate4B.Focus();
                hasil = true;
            }

            if (txtDate5B.Enabled && txtDate5A.DateValue > txtDate5B.DateValue)
            {
                MessageBox.Show("Tgl Selesai harus >= Tanggal Awal");
                txtDate5B.Focus();
                hasil = true;
            }

            if (txtDate5B.Enabled && txtDate5B.DateValue > TglAkhir)
            {
                MessageBox.Show("Tgl Selesai harus tidak boleh lebih dari " + TglAkhir.ToString("dd-MM-yyyy"));
                txtDate5B.Focus();
                hasil = true;
            }

            if (txtKeterangan.Text == "")
            {
                MessageBox.Show("Keterangan belum diisi");
                hasil = true;
                txtKeterangan.Focus();
            }

            return hasil;
        }

        public void BudgetInsert(string mingguke, DateTime tgl1, DateTime tgl2)
        {
            DateTime _TanggalMulai = tgl1;
            DateTime _TanggalSelesai = tgl2;
            string _mingguke = mingguke;
            string _UserInitial = SecurityManager.UserInitial;
            string _KodeGudang = GlobalVar.Gudang;

            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_BudgetMingguan_INSERT]"));
                    db.Commands[0].Parameters.Add(new Parameter("@mingguke", SqlDbType.VarChar, _mingguke));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalMulai", SqlDbType.DateTime, _TanggalMulai));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalSelesai", SqlDbType.DateTime, _TanggalSelesai));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, _KodeGudang));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void listDataBudget()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_BudgetMingguan_List]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalMulai", SqlDbType.DateTime, TglAwal));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalSelesai", SqlDbType.DateTime, TglAkhir));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                listData = dt;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void deleteDataBudget(int _mingguke)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_BudgetMingguan_Delete]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalMulai", SqlDbType.DateTime, TglAwal));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalSelesai", SqlDbType.DateTime, TglAkhir));
                    db.Commands[0].Parameters.Add(new Parameter("@MingguKe", SqlDbType.Int, _mingguke));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                listData = dt;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void txtDate4B_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtDate4B.DateValue >= TglAkhir)
                {
                    txtDate5B.Enabled = false;
                }
                else
                {
                    txtDate5B.Enabled = true;
                    txtDate5A.DateValue = ((DateTime)txtDate4B.DateValue).AddDays(1);
                }
            }
            catch
            {
            }
        }


    }
}
