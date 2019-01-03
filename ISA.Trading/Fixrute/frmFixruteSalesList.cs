using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Net;
using System.IO;

namespace ISA.Trading.Fixrute
{
    public partial class frmFixruteSalesList : ISA.Trading.BaseForm
    {
        public frmFixruteSalesList()
        {
            InitializeComponent();
        }

        private void frmFixruteSalesList_Load(object sender, EventArgs e)
        {
            //if (SecurityManager.UserName != "MANAGER")
            //    cmdUpload.Enabled = false;
            //else
            //    cmdUpload.Enabled = true;

            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime fromDate = Convert.ToDateTime(rangeDateBox1.FromDate) ;
            rangeDateBox1.ToDate = new DateTime(fromDate.Year, fromDate.Month, DateTime.DaysInMonth(fromDate.Year, fromDate.Month));
            RefreshFixrute();
        }

        private void RefreshFixrute()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_fixrutesales_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@TglFrom", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@TglTo", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                customGridView1.DataSource = dt;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshFixrute();
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            pnlUpload.Visible = true;
            pnlUpload.BringToFront();
        }

        private void bwSFMA_DoWork(object sender, DoWorkEventArgs e)
        {
            DataSet ds = new DataSet();

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_SFMA_Data"));
                db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.Date, monthYearBox1.FirstDateOfMonth));
                db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.Date, monthYearBox1.LastDateOfMonth));
                ds = db.Commands[0].ExecuteDataSet();
            }

            if (ds.Tables.Count > 0)
            {
                #region users
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    HttpWebRequest request;
                    Stream dataStream;
                    StreamReader reader;
                    string responseFromServer;
                    string token;

                    try
                    {
                        CookieContainer cc = new CookieContainer();

                        string UrlData = "http://salesforce.sas-autoparts.com/SendUser";

                        string sendData = "" +
                            "username=" + dr["SalesID"] +
                            "&name=" + dr["NamaSales"] +
                            "&email=" + dr["NamaSales"] + "@gmail.com" +
                            "&password=" + "$2y$10$qhHQwB1FCVdUPvhpgKCjnOKvMZ7R4gLmaekhFDSr4M1zJoaWbun4S" +
                            "&status=" + "true" +
                            "&api_token=" + "aAU7XGzxjaZxYMwSD5HfeKRBX0otzV42yc9JcJmiXxa22UY4CdxRIjZBddXc" +
                            "&remember_token=" + "" +
                            "&groups=" + "S" +
                            "&userid=" + dr["SalesID"] +
                            "&createdby=" + "Automatic" +
                            "&updatedby=" + "Automatic";
                        var sdata = Encoding.ASCII.GetBytes(sendData);

                        request = (HttpWebRequest)WebRequest.Create(UrlData + "?" + sendData);
                        request.CookieContainer = cc;

                        request.Method = "GET";
                        //request.ContentType = "application/x-www-form-urlencoded";
                        //request.ContentLength = sdata.Length;

                        //using (var stream = request.GetRequestStream())
                        //{
                        //    stream.Write(sdata, 0, sdata.Length);
                        //}

                        var responses = (HttpWebResponse)request.GetResponse();

                        string responseString = new StreamReader(responses.GetResponseStream()).ReadToEnd();
                        responses.Close();
                    }
                    catch (WebException ex)
                    {
                        WebResponse errResp = ex.Response;
                        string message = "";
                        if (errResp != null)
                        {
                            using (Stream respStream = errResp.GetResponseStream())
                            {
                                reader = new StreamReader(respStream);
                                message += reader.ReadToEnd();
                            }
                            //MessageBox.Show(message);

                            reader.Close();
                        }
                    }
                }
                #endregion

                #region updateuser
                for (int a = 0; a < 1; a++)
                {
                    HttpWebRequest request;
                    Stream dataStream;
                    StreamReader reader;
                    string responseFromServer;
                    string token;

                    try
                    {
                        CookieContainer cc = new CookieContainer();

                        string UrlData = "http://salesforce.sas-autoparts.com/SendUserUpdate";

                        request = (HttpWebRequest)WebRequest.Create(UrlData);
                        request.CookieContainer = cc;

                        request.Method = "GET";
                        //request.ContentType = "application/x-www-form-urlencoded";
                        //request.ContentLength = sdata.Length;

                        //using (var stream = request.GetRequestStream())
                        //{
                        //    stream.Write(sdata, 0, sdata.Length);
                        //}

                        var responses = (HttpWebResponse)request.GetResponse();

                        string responseString = new StreamReader(responses.GetResponseStream()).ReadToEnd();
                        responses.Close();
                    }
                    catch (WebException ex)
                    {
                        WebResponse errResp = ex.Response;
                        string message = "";
                        if (errResp != null)
                        {
                            using (Stream respStream = errResp.GetResponseStream())
                            {
                                reader = new StreamReader(respStream);
                                message += reader.ReadToEnd();
                            }
                            //MessageBox.Show(message);

                            reader.Close();
                        }
                    }
                }
                #endregion

                #region toko
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    HttpWebRequest request;
                    Stream dataStream;
                    StreamReader reader;
                    string responseFromServer;
                    string token;

                    try
                    {
                        CookieContainer cc = new CookieContainer();

                        string UrlData = "http://salesforce.sas-autoparts.com/SendToko";

                        string sendData = "" +
                            "tokoid=" + dr["TokoID"] +
                            "&kodetoko=" + dr["KodeToko"] +
                            "&namatoko=" + dr["NamaToko"] +
                            "&kota=" + dr["Kota"] +
                            "&daerah=" + dr["Daerah"] +
                            "&alamat=" + dr["Alamat"] +
                            "&wilid=" + dr["WilID"] +
                            "&hp=" + dr["HP"] +
                            "&telp=" + dr["Telp"] +
                            "&cabang=" + dr["Cabang"] +
                            "&username=" + dr["UserID"] +
                            "&isadate=" + dr["UpdatedAt"];
                        var sdata = Encoding.ASCII.GetBytes(sendData);

                        request = (HttpWebRequest)WebRequest.Create(UrlData + "?" + sendData);
                        request.CookieContainer = cc;

                        request.Method = "GET";
                        //request.ContentType = "application/x-www-form-urlencoded";
                        //request.ContentLength = sdata.Length;

                        //using (var stream = request.GetRequestStream())
                        //{
                        //    stream.Write(sdata, 0, sdata.Length);
                        //}

                        var responses = (HttpWebResponse)request.GetResponse();

                        string responseString = new StreamReader(responses.GetResponseStream()).ReadToEnd();
                        responses.Close();
                    }
                    catch (WebException ex)
                    {
                        WebResponse errResp = ex.Response;
                        string message = "";
                        if (errResp != null)
                        {
                            using (Stream respStream = errResp.GetResponseStream())
                            {
                                reader = new StreamReader(respStream);
                                message += reader.ReadToEnd();
                            }
                            //MessageBox.Show(message);

                            reader.Close();
                        }
                    }
                }
                #endregion

                #region rencanakunjungan
                foreach (DataRow dr in ds.Tables[2].Rows)
                {
                    HttpWebRequest request;
                    Stream dataStream;
                    StreamReader reader;
                    string responseFromServer;
                    string token;

                    try
                    {
                        CookieContainer cc = new CookieContainer();

                        string UrlData = "http://salesforce.sas-autoparts.com/SendRencanaKunjunganAuto";

                        string sendData = "" +
                            "tglinput=" + Convert.ToDateTime(dr["LastUpdatedTime"]).ToString("yyyy-MM-dd") +
                            "&tglrencana=" + Convert.ToDateTime(dr["TglKunjung"]).ToString("yyyy-MM-dd") +
                            "&username=" + dr["UserID"] +
                            "&kodetoko=" + dr["TokoID"] +
                            "&cabang=" + dr["CabangID"] +
                            "&keterangan=" + "" +
                            "&createdby=" + "Automatic" +
                            "&updatedby=" + "Automatic" +
                            "&rowid=" + dr["RowID"];
                        var sdata = Encoding.ASCII.GetBytes(sendData);

                        request = (HttpWebRequest)WebRequest.Create(UrlData + "?" + sendData);
                        request.CookieContainer = cc;

                        request.Method = "GET";
                        //request.ContentType = "application/x-www-form-urlencoded";
                        //request.ContentLength = sdata.Length;

                        //using (var stream = request.GetRequestStream())
                        //{
                        //    stream.Write(sdata, 0, sdata.Length);
                        //}

                        var responses = (HttpWebResponse)request.GetResponse();

                        string responseString = new StreamReader(responses.GetResponseStream()).ReadToEnd();
                        responses.Close();
                    }
                    catch (WebException ex)
                    {
                        WebResponse errResp = ex.Response;
                        string message = "";
                        if (errResp != null)
                        {
                            using (Stream respStream = errResp.GetResponseStream())
                            {
                                reader = new StreamReader(respStream);
                                message += reader.ReadToEnd();
                            }
                            //MessageBox.Show(message);

                            reader.Close();
                        }
                    }
                }
                #endregion

                #region deleterencanakunjungan
                foreach (DataRow dr in ds.Tables[3].Rows)
                {
                    HttpWebRequest request;
                    Stream dataStream;
                    StreamReader reader;
                    string responseFromServer;
                    string token;

                    try
                    {
                        CookieContainer cc = new CookieContainer();

                        string UrlData = "http://salesforce.sas-autoparts.com/DeleteRencanaKunjungan";

                        string sendData = "" +
                            "rowid=" + dr["RowID"] +
                            "&deletedby=" + "Automatic";
                        var sdata = Encoding.ASCII.GetBytes(sendData);

                        request = (HttpWebRequest)WebRequest.Create(UrlData + "?" + sendData);
                        request.CookieContainer = cc;

                        request.Method = "GET";
                        //request.ContentType = "application/x-www-form-urlencoded";
                        //request.ContentLength = sdata.Length;

                        //using (var stream = request.GetRequestStream())
                        //{
                        //    stream.Write(sdata, 0, sdata.Length);
                        //}

                        var responses = (HttpWebResponse)request.GetResponse();

                        string responseString = new StreamReader(responses.GetResponseStream()).ReadToEnd();
                        responses.Close();
                    }
                    catch (WebException ex)
                    {
                        WebResponse errResp = ex.Response;
                        string message = "";
                        if (errResp != null)
                        {
                            using (Stream respStream = errResp.GetResponseStream())
                            {
                                reader = new StreamReader(respStream);
                                message += reader.ReadToEnd();
                            }
                            //MessageBox.Show(message);

                            reader.Close();
                        }
                    }
                }
                #endregion
            }
        }

        private void bwSFMA_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Proses Upload Selesai");
            cmdYes.Enabled = true;
            pnlUpload.Visible = false;
            pnlUpload.SendToBack();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            pnlUpload.Visible = false;
            pnlUpload.SendToBack();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            int _period = Convert.ToInt32(GlobalVar.DateOfServer.ToString("yyyyMM"));
            int _period2 = Convert.ToInt32(monthYearBox1.FirstDateOfMonth.Date.ToString("yyyyMM"));

            if (_period2 < _period)
            {
                MessageBox.Show("Tidak bisa upload Data bulan lalu.");
                return;
            }

            cmdYes.Enabled = false;
            if (!bwSFMA.IsBusy)
            {
                bwSFMA.RunWorkerAsync();
            }
        }
    }
}
