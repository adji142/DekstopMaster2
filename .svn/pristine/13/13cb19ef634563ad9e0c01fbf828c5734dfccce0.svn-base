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
    public partial class frmBarcodeTambahNota : ISA.Finance.BaseForm
    {
        Guid NotaRowID;
        String NoNota;
        String TglNota;
        String NamaToko;
        String WilID;

        public frmBarcodeTambahNota()
        {
            InitializeComponent();
        }

        public frmBarcodeTambahNota(Form caller_, Guid RowID_)
        {
            this.Caller = caller_;
            NotaRowID = RowID_;
            InitializeComponent();
        }

        private void frmBarcodeUpdate_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdsave_Click(object sender, EventArgs e)
        {
            try
            {

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
                        db.Commands.Add(db.CreateCommand("usp_Barcode_Insert_TAC"));
                        //db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, NotaRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@NoNota", SqlDbType.VarChar, txtNoNota.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@TglNota", SqlDbType.DateTime, dateTimePicker1.Value.Date));

                        db.Commands[0].Parameters.Add(new Parameter("@Barcode", SqlDbType.VarChar, txtBarcode.Text.Substring(0, 12)));
                        db.Commands[0].Parameters.Add(new Parameter("@Createdby", SqlDbType.VarChar, "TAC"));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, lookupToko1.KodeToko));
                        db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.VarChar, txtKPID.Text));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    MessageBox.Show("Save Berhasil", "Informasi");
                    //Piutang.frmBarcodeNotaBrowse frm = new Piutang.frmBarcodeNotaBrowse();
                    //frm = (frmBarcodeNotaBrowse)Caller;
                    ////frm.RefreshFind(NotaRowID);
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

        private void commandButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dtcekpiutang = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_BarcodeTambah_cekPiutang")); //ngecek piutang
                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, lookupToko1.KodeToko));
                db.Commands[0].Parameters.Add(new Parameter("@NoTransaksi", SqlDbType.VarChar, txtNoNota.Text));
                db.Commands[0].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.DateTime, dateTimePicker1.Value.Date));
                dtcekpiutang = db.Commands[0].ExecuteDataTable();
            }

            if (dtcekpiutang.Rows.Count <= 0)
            {
                MessageBox.Show("Tidak ada data piutang dengan toko, nomor nota dan tanggal nota tersebut");
                return;
            }

            txtKPID.Text = dtcekpiutang.Rows[0]["KPID"].ToString();
            txtrpsisa.Text = dtcekpiutang.Rows[0]["rpsisa"].ToString();
            cmdsave.Enabled = true;
            //txtIDWilPiutang.Text = dtcekpiutang.Rows[0][""].ToString();
        }

        private void lookupToko1_SelectData(object sender, EventArgs e)
        {
            txtAlamat.Text = lookupToko1.Alamat;
            txtIDWill.Text = lookupToko1.WilID;
        }

        
    }
}
