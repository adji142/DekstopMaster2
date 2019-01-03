using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.Class;

namespace ISA.Trading.Penjualan
{
    public partial class frmRencKunjSalesUpdate : ISA.Trading.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        DateTime _TglKunjung;
        string _KodeSales, _KodeToko;
        DataTable dt;

        public frmRencKunjSalesUpdate()
        {
            InitializeComponent();
        }


        public frmRencKunjSalesUpdate(Form caller, string KodeSales_, DateTime TglKunjung_)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _TglKunjung = TglKunjung_;
            _KodeSales = KodeSales_;
            this.Caller = caller;
          
        }

        private void frmRencKunjSalesUpdate_Load(object sender, EventArgs e)
        {
            txtIdWil.Enabled = false;
            txtAlamat.Enabled = false;
            txtDaerah.Enabled = false;
            txtKota.Enabled = false;

        }


        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                switch (formMode)
                {
                    case enumFormMode.New:

                        using (Database db = new Database())
                        {
                            _rowID = Guid.NewGuid();
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_KunjunganSales_INSERT")); //HR, create SP 19032013
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@DateKunj", SqlDbType.Date,_TglKunjung ));
                            db.Commands[0].Parameters.Add(new Parameter("@SalesID", SqlDbType.VarChar,_KodeSales ));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar,_KodeToko ));
                            db.Commands[0].Parameters.Add(new Parameter("@KetRealisasi", SqlDbType.VarChar,"" ));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_KunjunganSales_UPDATE")); //HR, created SP 19032013
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@DateKunj", SqlDbType.Date, _TglKunjung));
                            db.Commands[0].Parameters.Add(new Parameter("@SalesID", SqlDbType.VarChar, _KodeSales));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, _KodeToko));
                            db.Commands[0].Parameters.Add(new Parameter("@KetRealisasi", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                frmRencKunjSalesBrowser frm = new frmRencKunjSalesBrowser();
                frm = (frmRencKunjSalesBrowser)Caller;
                frm.Bindata();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void lookupToko1_SelectData(object sender, EventArgs e)
        {
            txtIdWil.Text = lookupToko1.WilID;
            txtAlamat.Text = lookupToko1.Alamat;
            txtKota.Text = lookupToko1.Kota;
            txtDaerah.Text = lookupToko1.Daerah;
            _KodeToko = lookupToko1.KodeToko;
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
