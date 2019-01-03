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


namespace ISA.Toko.Communicator
{
    public partial class frmStatusTokoUpload11 : ISA.Toko.BaseForm
    {
        DataTable dt = new DataTable();

        public frmStatusTokoUpload11()
        {
            InitializeComponent();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (rangeDateBox1.FromDate != null && rangeDateBox1.ToDate != null)
            {
                RefreshData();
            }
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    Upload();
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi file: " + GlobalVar.DbfUpload + "stsTokoUp.dbf");
                    DisplayReport();                    
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
            else
            {
                MessageBox.Show(Messages.Error.NotFound);
            }
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_StatusToko_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;                    
                }
                dt.DefaultView.Sort = "NamaToko, KodeToko, TglAktif";
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

        private void Upload()
        {
            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("CabangID", "C1", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("Kodetoko", "kd_toko", Foxpro.enFoxproTypes.Varchar, 19));
            fields.Add(new Foxpro.DataStruct("TglAktif", "tmt", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Status", "sts", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Keterangan", "ket", Foxpro.enFoxproTypes.Char, 30));
            fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("KStatus", "ksts", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("Roda", "rd", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("WilID", "idwil", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("tglPasif", "tmtpasif", Foxpro.enFoxproTypes.DateTime, 8));
            Foxpro.WriteFile(GlobalVar.DbfUpload, "stsTokoUp", fields, dt, pbUpload);
        }

        private void frmStatusTokoUpload11_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayReport()
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            frmReportViewer ifrmReport = new frmReportViewer("Communicator.rptUploadStatusToko.rdlc", rptParams, dt, "dsStatusToko_Data");
            ifrmReport.Show();

        }
    }
}
