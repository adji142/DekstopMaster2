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


namespace ISA.Trading.Master
{
    public partial class frmTargetSalesUpdate : ISA.Trading.BaseForm
    {
        
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        string _KodeSales, _NamaSales;
        DataTable dt;

        public frmTargetSalesUpdate()
        {
            InitializeComponent();
        }

        public frmTargetSalesUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmTargetSalesUpdate(Form caller, Guid rowID, string KodeSales_, string NamaSAles_)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID  =   rowID;
            _NamaSales = NamaSAles_;
            _KodeSales = KodeSales_;
            this.Caller = caller;
        }

        public frmTargetSalesUpdate(Form caller, string KodeSales_,string NamaSAles_)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _NamaSales = NamaSAles_;
            _KodeSales = KodeSales_;
            this.Caller = caller;
          
        }


        private void frmTargetSalesUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_HistoryTargetSales_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, null));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, null));
                        db.Commands[0].Parameters.Add(new Parameter("@SalesID", SqlDbType.VarChar, null));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                     }

                    //display data
                    txtKdSales.Text = _KodeSales;
                    txtNama.Text = _NamaSales;
                    dateTMT.DateValue = (DateTime)dt.Rows[0]["TglAktif"] ;
                    txtNama.Enabled = false;
                    txtKdSales.Enabled = false;
                    dateTMT.Enabled = false;
                    txtSkuR2.Text = Tools.isNull(dt.Rows[0]["SkuR2"], "").ToString();
                    txtSkuR4.Text = Tools.isNull(dt.Rows[0]["SkuR4"], "").ToString();
                    txtSkuLain.Text = Tools.isNull(dt.Rows[0]["SkuLain"], "").ToString();
                    txtNomFE2.Text = Tools.isNull(dt.Rows[0]["NomFE2"], "").ToString();
                    txtNomFE4.Text = Tools.isNull(dt.Rows[0]["NomFE4"], "").ToString();
                    txtNomFB2.Text = Tools.isNull(dt.Rows[0]["NomFB2"], "").ToString();
                    txtNomFB4.Text = Tools.isNull(dt.Rows[0]["NomFB4"], "").ToString();
                    txtNomFA.Text = Tools.isNull(dt.Rows[0]["NomFA"], "").ToString();
                    txtNomFLain.Text = Tools.isNull(dt.Rows[0]["NomFLain"], "").ToString();
                    txtOrdAktif.Text = Tools.isNull(dt.Rows[0]["OrderAktif"], "").ToString();
                    txtKunjHarian.Text = Tools.isNull(dt.Rows[0]["Kunjungan"], "").ToString();
                }
                else
                {
                    txtKdSales.Text = _KodeSales;
                    txtNama.Text = _NamaSales;
                    dateTMT.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); 
                    
                    txtNama.Enabled = false;
                    txtKdSales.Enabled = false;
                    dateTMT.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
          
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (PeriodeClosing.IsPJTClosed(dateTMT.DateValue.Value))
            {
                MessageBox.Show("Periode Tanggal Sudah Closing");
                return;
            }

            try
            {
                string cGudang = GlobalVar.Gudang;
                switch (formMode)
                
                {
                    case enumFormMode.New:

                        using (Database db = new Database())
                        {
                            _rowID = Guid.NewGuid();
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_HistoryTargetSales_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@SalesID", SqlDbType.VarChar, txtKdSales.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@TglAktif", SqlDbType.Date,  dateTMT.DateValue.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, cGudang));
                            db.Commands[0].Parameters.Add(new Parameter("@SKUR2", SqlDbType.Int, txtSkuR2.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@SKUR4", SqlDbType.Int, txtSkuR4.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@SKULain", SqlDbType.Int, txtSkuLain.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NomFE2", SqlDbType.Money, txtNomFE2.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NomFB2", SqlDbType.Money, txtNomFB2.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NomFE4", SqlDbType.Money, txtNomFE4.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NomFB4", SqlDbType.Money, txtNomFB4.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NomFA", SqlDbType.Money, txtNomFA.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NomFLain", SqlDbType.Money, txtNomFLain.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@OrderAktif", SqlDbType.Int, txtOrdAktif.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Kunjungan", SqlDbType.Int, txtKunjHarian.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.VarChar, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                                                     
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_HistoryTargetSales_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@SalesID", SqlDbType.VarChar, txtKdSales.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@TglAktif", SqlDbType.Date, dateTMT.DateValue.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, cGudang));
                            db.Commands[0].Parameters.Add(new Parameter("@SKUR2", SqlDbType.Int, txtSkuR2.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@SKUR4", SqlDbType.Int, txtSkuR4.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@SKULain", SqlDbType.Int, txtSkuLain.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NomFE2", SqlDbType.Money, txtNomFE2.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NomFB2", SqlDbType.Money, txtNomFB2.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NomFE4", SqlDbType.Money, txtNomFE4.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NomFB4", SqlDbType.Money, txtNomFB4.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NomFA", SqlDbType.Money, txtNomFA.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NomFLain", SqlDbType.Money, txtNomFLain.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@OrderAktif", SqlDbType.Int, txtOrdAktif.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Kunjungan", SqlDbType.Int, txtKunjHarian.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.VarChar, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                frmTargetSales frm = new frmTargetSales();
                frm = (frmTargetSales)Caller;
                frm.BindData();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTargetSalesUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmTargetSales)
                {
                    frmTargetSales frmCaller = (frmTargetSales)this.Caller;
                    frmCaller.RefreshBrowse1(_rowID.ToString());
                    frmCaller.FindBrowse1("colrowID", _rowID.ToString());
                }
            }
        }


                     
    }
}
