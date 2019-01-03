using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Pembelian
{
    public partial class frmAmbilDODariBOFilter2nd : ISA.Trading.BaseForm
    {
        public frmAmbilDODariBOFilter2nd()
        {
            InitializeComponent();
        }

        DateTime _tglRQ;
        string _noRQ;
        string _headerRec;
        Guid _doBeliID;
        int result;
        
        public frmAmbilDODariBOFilter2nd(Form caller, Guid doBeliID, string headerRec, DateTime tglRQ, string noRQ)
        {
            InitializeComponent();
            _doBeliID = doBeliID;
            _headerRec = headerRec;
            _tglRQ = tglRQ;
            _noRQ = noRQ;
            this.Caller = caller;
        }

        private void frmAmbilDODariBOFilter2nd_Load(object sender, EventArgs e)
        {
            this.Title = "Ambil Data dari BO";
            this.Text = "Pembelian";
            txtTglRQ.DateValue = _tglRQ;
            txtNoRQ.Text = _noRQ;
            txtTglDOFrom.DateValue = _tglRQ.AddDays(-30);
            txtTglDOTo.DateValue = _tglRQ.AddDays(-1);
        }
        

        private void cmdYES_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtResult = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_OrderPembelian_OrderOtomatis"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, txtTglDOFrom.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, txtTglDOTo.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@doBeliID", SqlDbType.UniqueIdentifier, _doBeliID));
                    db.Commands[0].Parameters.Add(new Parameter("@headerRec", SqlDbType.UniqueIdentifier, _headerRec));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.UniqueIdentifier, GlobalVar.Gudang));
                    db.Commands[0].Parameters.Add(new Parameter("@initialUser", SqlDbType.VarChar, SecurityManager.UserInitial));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    dtResult = db.Commands[0].ExecuteDataTable();
                }
                result = int.Parse(dtResult.Rows[0]["ResultCount"].ToString());
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }


            if (result == 0)
            {
                MessageBox.Show("Tidak ada data");
                return;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Order Pembelian dari " + result + " BO telah disimpan");
                this.Close();
            }
        }


        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void frmAmbilDODariBOFilter2nd_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                frmDOBeliBrowser formCaller = (frmDOBeliBrowser)this.Caller;
                formCaller.RefreshDataOrderPembelianDetail();
            }
        }

    }
}
