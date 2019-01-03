using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;

namespace ISA.Toko.Pembelian
{
    public partial class frmAmbilDODariBOFilter : ISA.Toko.BaseForm
    {
        DateTime _tglRQ;
        string _noRQ;
        Guid _doBeliID;
        int result;

        public frmAmbilDODariBOFilter(Form caller, Guid doBeliID, DateTime tglRQ, string noRQ)
        {
            InitializeComponent();
            _doBeliID = doBeliID;
            _tglRQ = tglRQ;
            _noRQ = noRQ;
            this.Caller = caller;
        }

        private void frmAmbilDODariBO_Load(object sender, EventArgs e)
        {
            this.Title = "Ambil Data dari BO";
            this.Text = "Pembelian";
            txtTglRQ.DateValue = _tglRQ;
            txtNoRQ.Text = _noRQ;
            txtTglDOFrom.DateValue = _tglRQ;
            txtTglDOTo.DateValue = _tglRQ;
        }

        private void cmdYES_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtResult = new DataTable();
                ds = new DataSet();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_OrderPembelian_InsertFromBO"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, txtTglDOFrom.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, txtTglDOTo.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@doBeliID", SqlDbType.UniqueIdentifier, _doBeliID));
                    db.Commands[0].Parameters.Add(new Parameter("@initialUser", SqlDbType.VarChar, SecurityManager.UserInitial));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    ds = db.Commands[0].ExecuteDataSet();
                    dtResult = ds.Tables[0].Copy();
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
                if (ds.Tables[1].Rows.Count>0)
                {
                    DisplayReport(ds.Tables[1]);
                    if (MessageBox.Show("Hapus record yang sudah pernah di Order ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("[usp_OrderPembelianDetail_DELETE]"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dr["RowID"]));
                                db.Commands[0].ExecuteNonQuery();
                            }
                        }
                    } 
                }
               
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Order Pembelian dari " + result + " BO telah disimpan");
                this.Close();
            }
        }

        private void txtTglDOFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            //cmdYES.PerformClick();
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void frmAmbilDODariBO_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                frmDOBeliBrowser formCaller = (frmDOBeliBrowser)this.Caller;
                formCaller.RefreshDataOrderPembelianDetail();
            }
        }

        private void DisplayReport(DataTable dt)
        {
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)txtTglDOFrom.DateValue).ToString("dd/MM/yyyy"), ((DateTime)txtTglDOTo.DateValue).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", dt.Rows[0]["norq"].ToString()));
            rptParams.Add(new ReportParameter("Tgl", ((DateTime)dt.Rows[0]["Tglrq"]).ToString("dd/MM/yyyy")));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Pembelian.rptBOCancel.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
            ifrmReport.Show();

        } 

    }
}
