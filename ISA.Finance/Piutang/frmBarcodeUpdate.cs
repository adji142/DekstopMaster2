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

namespace ISA.Finance.Piutang
{
    public partial class frmBarcodeUpdate : ISA.Finance.BaseForm
    {
        Guid NotaRowID;
        String NoNota;
        String TglNota;
        String NamaToko;
        String WilID;

        public frmBarcodeUpdate()
        {
            InitializeComponent();
        }

        public frmBarcodeUpdate(Form caller_, Guid RowID_)
        {
            this.Caller = caller_;
            NotaRowID = RowID_;
            InitializeComponent();
        }

        private void frmBarcodeUpdate_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_NotaBarcodeUpdate_list"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, NotaRowID));
                dt = db.Commands[0].ExecuteDataTable();
            }

            txtTglNota.Text = Tools.isNull(dt.Rows[0]["TglNota"], "").ToString();
            txtNoNota.Text = Tools.isNull(dt.Rows[0]["NoNota"], "").ToString();
            txtSalesman.Text = Tools.isNull(dt.Rows[0]["Salesman"], "").ToString();
            txtBarcode.Text = Tools.isNull(dt.Rows[0]["Barcode"], "").ToString();
            txtToko.Text = Tools.isNull(dt.Rows[0]["NamaToko"], "").ToString();
            txtAlamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
            txtIDWill.Text = Tools.isNull(dt.Rows[0]["WilID"], "").ToString();
            txtBarcode.Focus();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdsave_Click(object sender, EventArgs e)
        {
            try
            {
                string cBarcode = txtBarcode.Text.ToString().Trim();
                int Panjang = cBarcode.Length;

                if (Panjang != 12)
                {
                    MessageBox.Show("Panjang Barcode kurang atau lebi dari 12 character");
                    return;
                }

                DataTable dtcek = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_BarcodeNota_CekDouble")); //ngecek enek no barcode nek header ora
                    db.Commands[0].Parameters.Add(new Parameter("@Barcode", SqlDbType.VarChar, txtBarcode.Text.Substring(0,12)));
                    dtcek = db.Commands[0].ExecuteDataTable();
                }

                if (dtcek.Rows.Count == 0)
                {
                    
                    DataTable dt = new DataTable();
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("usp_Barcode_Insert"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, NotaRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@Barcode", SqlDbType.VarChar, txtBarcode.Text.Substring(0, 12)));
                        db.Commands[0].Parameters.Add(new Parameter("@Createdby", SqlDbType.VarChar, SecurityManager.UserName));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    MessageBox.Show("Save Berhasil", "Informasi");
                    Piutang.frmBarcodeNotaBrowse frm = new Piutang.frmBarcodeNotaBrowse();
                    frm = (frmBarcodeNotaBrowse)Caller;
                    frm.RefreshFind(NotaRowID);
                    //frm.RefreshRowDataReturJual(NotaRowID);

                    this.Close();
                }
                else
                {
                    NoNota = dtcek.Rows[0]["NoNota"].ToString();
                    TglNota = dtcek.Rows[0]["TglNota"].ToString();
                    NamaToko = dtcek.Rows[0]["NamaToko"].ToString();
                    WilID = dtcek.Rows[0]["WilID"].ToString();
                    MessageBox.Show("No Barcode masih dipakai di nota no " + NoNota +" , TglNota "+ TglNota +" , Toko " + NamaToko + " , WilID " + WilID, "Informasi" );
                    txtBarcode.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
