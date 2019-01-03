using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.Class;


namespace ISA.Toko.Master
{
    public partial class frmTargetSalesUpdate : ISA.Toko.BaseForm
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
            lookupSales1.SalesID = KodeSales_;
            lookupSales1.NamaSales = NamaSAles_;
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
                    dateTMT.DateValue = (DateTime)dt.Rows[0]["TglAktif"] ;
                    dateTMT.Enabled = true;
                    txtSkuR2.Text = Tools.isNull(dt.Rows[0]["SKU"], "").ToString();
                    txtOmsetNetto.Text = Tools.isNull(dt.Rows[0]["OmsetNetto"], "").ToString();
                    txtOrdAktif.Text = Tools.isNull(dt.Rows[0]["OrderAktif"], "").ToString();
                    lookupSales1.NamaSales = Tools.isNull(dt.Rows[0]["NamaSales"], "").ToString();
                    lookupSales1.SalesID = Tools.isNull(dt.Rows[0]["SalesID"], "").ToString();
                    lookupSales1.Enabled = false;
                    
                }
                else
                {
                    
                    dateTMT.DateValue = GlobalVar.DateOfServer; 
                    
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
                            db.Commands[0].Parameters.Add(new Parameter("@SalesID", SqlDbType.VarChar, lookupSales1.SalesID));
                            db.Commands[0].Parameters.Add(new Parameter("@TglAktif", SqlDbType.Date, dateTMT.DateValue.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@SKU", SqlDbType.Int, txtSkuR2.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@OmsetNetto", SqlDbType.Int, txtOmsetNetto.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@OrderAktif", SqlDbType.Int, txtOrdAktif.GetIntValue));
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
                            db.Commands[0].Parameters.Add(new Parameter("@SalesID", SqlDbType.VarChar, lookupSales1.SalesID));
                            db.Commands[0].Parameters.Add(new Parameter("@TglAktif", SqlDbType.Date, dateTMT.DateValue.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@SKU", SqlDbType.Int, txtSkuR2.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@OmsetNetto", SqlDbType.Int, txtOmsetNetto.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@OrderAktif", SqlDbType.Int, txtOrdAktif.GetIntValue));
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
