using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Toko.Master
{
    public partial class frmJasaHargaUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { NEW, UPDATE };
        enumFormMode formMode;
        Guid RowID, JasaRowID;
        string tampNama;
        DataTable dt;

        public frmJasaHargaUpdate(Form caller, Guid HeaderRowID)
        {
            InitializeComponent();
            JasaRowID = HeaderRowID;
            RowID = Guid.NewGuid();
            formMode = enumFormMode.NEW;
            RowID = Guid.NewGuid();
            this.Caller = caller;
            setNew();
        }

        public frmJasaHargaUpdate(Form caller, Guid HeaderRowID, Guid rowID)
        {
            InitializeComponent();
            JasaRowID = HeaderRowID;
            formMode = enumFormMode.UPDATE;
            RowID = rowID;
            this.Caller = caller;
            setUpdate();
        }

        private void setNew() 
        {
            txtdate.DateValue = GlobalVar.DateOfServer;
            txtHargaJual.Text = "0";
            txtKeterangan.Text = "";
        }

        private void setUpdate()
        {
            dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Open();
                db.Commands.Add(db.CreateCommand("[usp_BankKota_LIST]"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                dt = db.Commands[0].ExecuteDataTable();
                db.Close();
                db.Dispose();
            }
            if (dt.Rows.Count > 0)
            {
                txtdate.DateValue = (DateTime)dt.Rows[0]["Tanggal"];
                txtHargaJual.Text = dt.Rows[0]["HargaJual"].ToString();
                txtKeterangan.Text = dt.Rows[0]["Keterangan"].ToString();
            } 
        }

        private void frmJasaHargaUpdate_Load(object sender, EventArgs e)
        {
            
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty( txtdate.Text))
            {
                KotakPesan.Warning("Anda belum mengisi Tanggal","Cek Tanggal");
                txtdate.Focus();
                return;
            }

            if (txtdate.DateValue < GlobalVar.DateOfServer)
            {
                KotakPesan.Warning("Tanggal tidak boleh kurang dari datetime server", "Cek Tanggal");
                txtdate.Focus();
                return;
            } 
            if (txtHargaJual.GetDoubleValue <= 0)
            {
                KotakPesan.Warning("Harga Jual Harus Lebih besar dari 0", "Cek Harga Jual");
                txtHargaJual.Focus();
                return;
            }
            try
            {
               // using (Database db = new Database(GlobalVar.DBFinance))
                using (Database db = new Database())

                {
                    db.Open();
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_JasaHarga_Insert"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@JasaRowID", SqlDbType.UniqueIdentifier, JasaRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, txtdate.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@HargaJual", SqlDbType.Money, txtHargaJual.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                    dt = db.Commands[0].ExecuteDataTable();
                    db.Close();
                    db.Dispose();
                    if (dt.Rows.Count > 0)
                    {
                        KotakPesan.Warning(string.Format("Jasa Harga Tanggal {0:dd-MM-yyyy} sudah ada. Mohon gunakan Tombol Edit jika ingin merubah.", txtdate.DateValue), "Cek Tanggal");
                        txtdate.Focus();
                        return;
                    }
                }

                this.DialogResult = DialogResult.OK;
                frmJasaBrowse frmcaller = (frmJasaBrowse)this.Caller;
                frmcaller.RefreshData();
                this.Close();
                frmcaller.Show();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmJasaHargaUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmJasaBrowse)
                {
                    frmJasaBrowse frmCaller = (frmJasaBrowse)this.Caller;
                    frmCaller.RefreshDataDetail(JasaRowID);
                    frmCaller.FindRowDetail("DRowID",RowID.ToString());                
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void commonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
