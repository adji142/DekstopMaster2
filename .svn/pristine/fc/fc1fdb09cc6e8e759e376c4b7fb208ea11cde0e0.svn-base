using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;

namespace ISA.Toko.SIP
{
    public partial class frmRptSIP : ISA.Toko.BaseForm
    {
        string _KodeToko;
        Guid _RowID;
        string _NamaToko, _Alamat, _Telepon, _Kontak, _Plafon, _Status, _Bentrok;
        bool f9;
        DataSet ds = new DataSet();
        /// <summary>
        /// Procedure Init Form Report
        /// </summary>
        /// <param name="caller">Nama Form Pemanggil</param>
        /// <param name="KodeToko">KodeToko yang akan diCetak</param>
        /// <param name="RowID">RowID Kolitone</param>
        public frmRptSIP(Form caller, string KodeToko,Guid RowID, bool f)
        {
            this.Caller = caller;
            _RowID = RowID;
            _KodeToko = KodeToko;
            f9 = f;
            InitializeComponent();
        }

        public frmRptSIP()
        {
            InitializeComponent();
        }

        private void LoadData(string KodeToko)
        {
            try
            {
                DataTable dt = new DataTable();

                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("[usp_SIP_LIST]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier,_RowID));
                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count > 0)
                    {

                        _NamaToko = Tools.isNull(dt.Rows[0]["NamaToko"], "").ToString();
                        _Alamat = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                        _Telepon = Tools.isNull(dt.Rows[0]["Telp"], "").ToString();
                        _Kontak = Tools.isNull(dt.Rows[0]["PenanggungJawab"], "").ToString();
                        _Plafon = Tools.isNull(dt.Rows[0]["Plafon"], "").ToString();
                        _Status = Tools.isNull(dt.Rows[0]["Status"], "").ToString();
                        _Bentrok = Tools.isNull(dt.Rows[0]["Bentrok"], "").ToString();
                    }

                   
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void frmRptSIP_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = DateTime.Now;
            rangeDateBox1.ToDate = DateTime.Now;
            rangeDateBox1.Focus();
            LoadData(_KodeToko);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    //DataSet ds = new DataSet();
                    db.Commands.Add(db.CreateCommand("[rsp_SIP]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, _KodeToko));

                    ds = db.Commands[0].ExecuteDataSet();
                }


                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("No Data");
                        return;
                    }
                   
                   

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            double Nilai = Convert.ToDouble(Tools.isNull(dr["HrgJual"], "0").ToString());
                            dr["AntiNumeric1"] = Tools.GetAntiNumeric(Nilai.ToString("#,##0"), true);
                        }
                   
                        double Nilai4 = 0;
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            double Nilai1 = Convert.ToDouble(Tools.isNull(dr["Omzet"], "0").ToString());
                            double Nilai2 = Convert.ToDouble(Tools.isNull(dr["QtyRetur"], "0").ToString());
                            double Nilai3 = Convert.ToDouble(Tools.isNull(dr["JmlhNetto"], "0").ToString());
                            if (!f9)
                            {
                                dr["AntiNumeric1"] = Tools.GetAntiNumeric(Nilai1.ToString("#,##0"), true);
                                dr["AntiNumeric2"] = Tools.GetAntiNumeric(Nilai2.ToString("#,##0"), true);
                                dr["AntiNumeric3"] = Tools.GetAntiNumeric(Nilai3.ToString("#,##0"), true);
                            }
                            Nilai4 = Nilai4 + Nilai3;
                        }
                       
                           
                       
                   DisplayReport(ds, Nilai4);
                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void DisplayReport(DataSet ds,double nilai4)
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
           
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            List<ReportParameter> rptParams2 = new List<ReportParameter>();
            rptParams2.Add(new ReportParameter("UserID", SecurityManager.UserID));
            
            string AntiNumeric4 = "";
            AntiNumeric4 = Tools.GetAntiNumeric(nilai4.ToString("#,##0"), true);
            if(!f9)
                rptParams2.Add(new ReportParameter("AntiNumeric4", AntiNumeric4));
            else
            rptParams2.Add(new ReportParameter("AntiNumeric4", nilai4.ToString("#,##0")));
                
            string tes = _KodeToko;
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("NamaToko", _NamaToko));
            rptParams.Add(new ReportParameter("Alamat", _Alamat));
            rptParams.Add(new ReportParameter("Telepon", _Telepon));
            rptParams.Add(new ReportParameter("Kontak", _Kontak));
            if(!f9)
            rptParams.Add(new ReportParameter("Plafon", Tools.GetAntiNumeric(_Plafon.ToString(),true)));
            else 
            rptParams.Add(new ReportParameter("Plafon", _Plafon.ToString()));
            rptParams.Add(new ReportParameter("Status",_Status));
            rptParams.Add(new ReportParameter("Bentrok", _Bentrok));

            if(!f9)
            {
            // call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("SIP.rptSIP1.rdlc", rptParams, ds.Tables[0], "dsNotaPenjualan_Data");
            ifrmReport.Text = "Report Ke-1";
            ifrmReport.Show();

            frmReportViewer ifrmReport2 = new frmReportViewer("SIP.rptSIP2.rdlc", rptParams2, ds.Tables[1], "dsNotaPenjualan_Data");
            ifrmReport2.Text = "Report Ke-2";
            ifrmReport2.Show();
            }
            else{
             // call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("SIP.rptSIP11.rdlc", rptParams, ds.Tables[0], "dsNotaPenjualan_Data");
            ifrmReport.Text = "Report Ke-1";
            ifrmReport.Show();

            frmReportViewer ifrmReport2 = new frmReportViewer("SIP.rptSIP22.rdlc", rptParams2, ds.Tables[1], "dsNotaPenjualan_Data");
            ifrmReport2.Text = "Report Ke-2";
            ifrmReport2.Show();
            
            
            }


        }
    }
}
