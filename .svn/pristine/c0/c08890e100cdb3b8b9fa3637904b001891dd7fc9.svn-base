using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlTypes;


namespace ISA.Trading.xpdc
{
    public partial class frmXpdcDetailAddNonTrading : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        Guid _rowIDdetail;
        string docNoPengiriman = "ATK";
        DataTable dt;
        DataTable dtNum;
        int lebar, iNomor;
        string depan, belakang;
        string panjang = string.Empty;

        public frmXpdcDetailAddNonTrading(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _rowID = rowID;
            this.Caller = caller;
        }
        //public frmXpdcDetailAddNonTrading(Form caller, Guid rowIDdetail)
        //{
        //    InitializeComponent();
        //    formMode = enumFormMode.Update;
        //    _rowIDdetail = rowIDdetail;
        //    this.Caller = caller;
        //}

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmXpdcDetailAddNonTrading_Load(object sender, EventArgs e)
        {
            Tanggal.DateValue = DateTime.Now;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (Tools.isNull(NamaBarang.Text, "").ToString() == "")
            {
                MessageBox.Show("Nama Barang masih Kosong.");
                NamaBarang.Focus();
                return;
            }
            if (lookupGudang1.GudangID == "")
            {
                MessageBox.Show("Gudang Tujuan masih kosong.");
                lookupGudang1.Focus();
                return;
            }
            if (lookupExpedisi1.NamaExpedisi == "")
            {
                MessageBox.Show("Nama Ekspedisi masih kosong.");
                lookupExpedisi1.Focus();
                return;
            }

            depan = "ATK";
            lebar = 4;
            int nomor = 0;
            string belakang = "";
            DataTable dtNum = Tools.GetGeneralNumerator(depan);
            if (dtNum.Rows.Count > 0)
            {
                belakang = Tools.isNull(dtNum.Rows[0]["Belakang"], "").ToString();
                if (Tools.isNull(dtNum.Rows[0]["Depan"], "").ToString() != depan)
                    nomor = 1;
                else
                {
                    nomor = int.Parse(Tools.isNull(dtNum.Rows[0]["Nomor"],"0").ToString());
                    nomor = nomor + 1;
                }
            }
            else
            {
                nomor = 1;
            }
            string _Nomor = Tools.FormatNumerator(nomor, lebar, depan, belakang);

            using (Database db = new Database())
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    db.Commands.Add(db.CreateCommand("usp_PengirimanXpdcDetail_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@NotaJualID", SqlDbType.UniqueIdentifier, Guid.Empty));
                    db.Commands[0].Parameters.Add(new Parameter("@TglSuratJalan", SqlDbType.DateTime, Tanggal.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@NoSuratJalan", SqlDbType.VarChar, _Nomor));
                    db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, "ATK"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, lookupGudang1.GudangID));
                    db.Commands[0].Parameters.Add(new Parameter("@Barcode", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@JumlahKoli", SqlDbType.Int, int.Parse(Tools.isNull(JmlKoli.Text,"0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@JumlahPcs", SqlDbType.Int, int.Parse(Tools.isNull(JmlPcs.Text,"0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@KeteranganKoli", SqlDbType.VarChar, Tools.isNull(KetKoli.Text, string.Empty).ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@NoKoli", SqlDbType.VarChar, Tools.isNull(NoKoli.Text,string.Empty).ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex) { Error.LogError(ex); }
                finally { Cursor.Current = Cursors.Default; }
            }
        }
    }
}
