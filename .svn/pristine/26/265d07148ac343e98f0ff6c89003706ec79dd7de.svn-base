using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
 

namespace ISA.Trading.Persediaan
    {
    public partial class frmRptStandarStok : ISA.Trading.BaseForm
        {

        DataSet dsS = new DataSet();
        DataTable dtS = new DataTable();

        bool LinkPBO;
        string _NoRQ;
        string docNoDO = "NOMOR_RQ_PB0";
        int iNomor;



        private void GetData()
        {
            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("[rsp_StandarStok_Get]"));
                db.Commands[0].Parameters.Add(new Parameter("@Tgl", SqlDbType.DateTime, dateTextBox1.DateValue));
                db.Commands[0].Parameters.Add(new Parameter("@KelompokBarang", SqlDbType.VarChar, cboKel.Text.Trim()));
                dtS = db.Commands[0].ExecuteDataTable();
            }
        }

        private int GetSaldo(string KodeBarang)
        {
            int val = 0;
       
             using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("[fsp_StokGudang_GetSaldo]"));
                db.Commands[0].Parameters.Add(new Parameter("@Tgl", SqlDbType.DateTime, dateTextBox1.DateValue));
                db.Commands[0].Parameters.Add(new Parameter("@kodeBarang", SqlDbType.VarChar, KodeBarang));
                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                val =Convert.ToInt32( db.Commands[0].ExecuteScalar());
            }
            return val;
        }

        private void DisplayReport(DataTable dt)
            {

            //construct parameter
            List<ReportParameter> rptParams=new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", dateTextBox1.DateValue.Value.ToString("dd-MMM-yyyy")));
            rptParams.Add(new ReportParameter("Kelompok", cboKel.Text));

            //call report viewer
            frmReportViewer ifrmReport=new frmReportViewer("Persediaan.rptStandarStok.rdlc", rptParams, dt, "dsOpname_Data");
            ifrmReport.Show();

            }

        private void ReloadCBO()
            {
            try
                {
                this.Cursor=Cursors.WaitCursor;
                using (Database db = new Database())
                    {
                    DataTable dt=new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_KelompokBarang_LIST"));
                    dt=db.Commands[0].ExecuteDataTable();
                    object[] a = {"",""};
                    dt.Rows.Add(a);

                    cboKel.ValueMember="kelompokBrgID";
                    cboKel.DisplayMember="kelompokBrgID";
                    cboKel.DataSource=dt;

                    cboKel.SelectedValue = "";
                    }
                }
            catch(Exception ex)
                {
                Error.LogError(ex);
                }
            finally
                {
                this.Cursor=Cursors.Default;
                }
            }

        public frmRptStandarStok()
            {
            InitializeComponent();
            }

        private void frmRptStandarStok_Load(object sender, EventArgs e)
            {
            dateTextBox1.DateValue=DateTime.Now;
            progressBar1.Visible = false;
            lblStok.Text = string.Empty;
            ReloadCBO();
            }

        private void cmdYes_Click(object sender, EventArgs e)
            {
            try
                {
                this.Cursor=Cursors.WaitCursor;
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                GetData();
                progressBar1.Maximum = dtS.Rows.Count;
                DataSet ds = new dsOpname();
                DataTable dt = ds.Tables[0];
                int val = 0;
                string ket=string.Empty;
                foreach (DataRow dr in dtS.Rows)
                {
                    lblStok.Text = dr["NamaStok"].ToString();
                    
                    DataRow drw = dt.NewRow();
                    drw["NamaStok"] = dr["NamaStok"];
                    drw["KodeBarang"] = dr["KodeBarang"];
                    drw["Satuan"] = dr["Satuan"];
                    drw["KodeBarang"] = dr["KodeBarang"];
                    drw["Rak"] = dr["Rak"];
                    drw["AVGJual"] = dr["AVGJual"];
                    drw["Maximum"] = dr["Maximum"];
                    drw["Minimum"] = dr["Minimum"];
                    val = GetSaldo(dr["KodeBarang"].ToString());
                    drw["QtyAkhir"] = val;

                    drw["Keterangan"] = (val > Convert.ToInt32(dr["Maximum"])) ? "KELEBIHAN" : (val < Convert.ToInt32(dr["Minimum"]) ? "KEKURANGAN" : "IDEAL");
                  
                    dt.Rows.Add(drw);
                    

                    progressBar1.Value = progressBar1.Value + 1; ;
                    Application.DoEvents();
                    this.Invalidate();
                }
                
                if (dt.Rows.Count==0)
                {
                    MessageBox.Show("No Data");
                    return;
                }
                DisplayReport(dt);


                }
            catch(Exception ex)
                {
                Error.LogError(ex);
                }
            finally
                {
                this.Cursor=Cursors.Default;
                }
            }

        private void cmdNo_Click(object sender, EventArgs e)
            {
            this.Close();
            }

       


        }
    }
