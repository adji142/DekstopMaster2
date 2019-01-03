using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using Microsoft.Reporting.WinForms;

namespace ISA.Finance.GL
{
    public partial class frmRptBukuBesarPartner : ISA.Finance.BaseForm
    {
        public frmRptBukuBesarPartner()
        {
            InitializeComponent();
        }

        private void frmRptBukuBesarPartner_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            rangeDateBox1.ToDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
            lookupGudang1.GudangID = "";
        }

        

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;                
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_GL_BukuBesarPartner"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, lookupGudang1.GudangID));
                    db.Commands[0].Parameters.Add(new Parameter("@PartnerID", SqlDbType.VarChar, partnerComboBox1.PartnerID.Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@PartnerNo", SqlDbType.VarChar, partnerDetailComboBox1.PartnerDetailID.Trim()));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(Messages.Confirm.NoDataAvailable);
                    return;
                }
                ShowReport(dt);

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        private void ShowReport(DataTable dt)
        {
            //construct parameter
            //string periode;
            string PartnerID;
            string PartnerNo;
            string KodeGudang = string.Empty;

            PartnerID = partnerComboBox1.Text.Replace("-", ":");
            PartnerNo = partnerDetailComboBox1.Text.Replace("-", ":");

            if (string.IsNullOrEmpty(lookupGudang1.Text))
            {
                KodeGudang = "PT ALL";
            }
            else
            {
                KodeGudang = lookupGudang1.GudangID;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("PartnerID", PartnerID));
                rptParams.Add(new ReportParameter("PartnerNo", PartnerNo ));
                rptParams.Add(new ReportParameter("KodeGudang", KodeGudang));

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("GL.rptBukuBesarPartner.rdlc", rptParams, dt, "dsGL_Data");
                ifrmReport.Text = "Buku Besar";
                ifrmReport.Show();
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void partnerComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
                try
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_PartnerDetail_LIST]"));
                        db.Commands[0].Parameters.Add(new Parameter("@PartnerID", SqlDbType.VarChar, partnerComboBox1.PartnerID.Trim()));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    dt.DefaultView.Sort = "Display ASC";
                    partnerDetailComboBox1.DataSource = dt.DefaultView;

                    partnerDetailComboBox1.DisplayMember = "Display";
                    partnerDetailComboBox1.ValueMember = "PartnerNo";
                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }

            

            
        }
    }
}
