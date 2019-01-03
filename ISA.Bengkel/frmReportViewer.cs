﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using ISA.Trading.Class;


namespace ISA.Bengkel
{
    public partial class frmReportViewer : Form
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        bool _Print = false;

        public frmReportViewer()
        {
            InitializeComponent();
        }

        public frmReportViewer(string reportPath, List<ReportParameter> param, DataTable data, string datasetName)
        {
            InitializeComponent();
            //this.reportViewer1.DataBindings.Add(new Binding());
            //this.reportViewer1.LocalReport.ReportPath = reportPath;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ISA.Bengkel." + reportPath;            
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "ISA.Trading.Communicator.rptUploadStatusToko.rdlc";
            this.reportViewer1.LocalReport.SetParameters(param);
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource(datasetName, data.DefaultView));
        }

        public frmReportViewer(string reportPath, List<ReportParameter> param, List<DataTable> data, List<string> datasetName)
        {
            InitializeComponent();
            //this.reportViewer1.DataBindings.Add(new Binding());
            //this.reportViewer1.LocalReport.ReportPath = reportPath;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ISA.Bengkel." + reportPath;
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "ISA.Trading.Communicator.rptUploadStatusToko.rdlc";
            this.reportViewer1.LocalReport.SetParameters(param);
            for (int i = 0; i < data.Count; i++)
            {
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource(datasetName[i], data[i].DefaultView));
            }
            
        }


        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        public void Print()
        {

            this.reportViewer1.RefreshReport();
            _Print = true;

            Export(this.reportViewer1.LocalReport);
            m_currentPageIndex = 0;
            PrintDirectly();

        }

        public void Print(double lebar, double tinggi)
        {

            this.reportViewer1.RefreshReport();
            _Print = true;

            Export(this.reportViewer1.LocalReport, lebar, tinggi);
            m_currentPageIndex = 0;
            PrintDirectly();

        }

        private void Export(LocalReport report)
        {
            Random rnd = new Random();
            report.DisplayName = report.DisplayName + rnd.Next(0, 100).ToString();
            //Setting Print page
            string deviceInfo =
              "<DeviceInfo>" +
              "  <OutputFormat>EMF</OutputFormat>" +
              "  <PageWidth>8.8in</PageWidth>" +
              "  <PageHeight>11.7in</PageHeight>" +
              "  <MarginTop>0.15in</MarginTop>" +
              "  <MarginLeft>0.15in</MarginLeft>" +
              "  <MarginRight>0.15in</MarginRight>" +
              "  <MarginBottom>5.3in</MarginBottom>" +
              "</DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }


        private void Export(LocalReport report, double lebar, double tinggi)
        {
            Random rnd = new Random();
            report.DisplayName = report.DisplayName + rnd.Next(0, 100).ToString();
            //Setting Print page
            string deviceInfo =
              "<DeviceInfo>" +
              "  <OutputFormat>EMF</OutputFormat>" +
              "  <PageWidth>" + lebar.ToString() + "in</PageWidth>" +
              "  <PageHeight>" + tinggi.ToString() + "in</PageHeight>" +
              "  <MarginTop>0.15in</MarginTop>" +
              "  <MarginLeft>0.15in</MarginLeft>" +
              "  <MarginRight>0.15in</MarginRight>" +
             "  <MarginBottom>0.15in</MarginBottom>" +
              "</DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in (m_streams))
                stream.Position = 0;
        }

        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new FileStream(@"c:\Temp\" + name +
               "." + fileNameExtension, FileMode.Create);
            m_streams.Add(stream);
            return stream;
        }

        public void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }


        private void PrintDirectly()
        {
            const string printerName =
               "Microsoft Office Document Image Writer";
            if (m_streams == null || m_streams.Count == 0)
                return;
            //get printer //
            //string printer = Convert.ToString(AppSetting.GetValue("INKJET"));

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = GetPrinterName();
            //buat pilih printer
            //printDoc.PrinterSettings.PrinterName = GetPrinterNameInkjet(printer);
            if (!printDoc.PrinterSettings.IsValid)
            {
                string msg = String.Format(
                   "Can't find printer \"{0}\".", printerName);
                MessageBox.Show(msg, "Print Error");
                return;
            }
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.Print();

            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }

        public string GetPrinterName()
        {
            PrintDocument doc = new PrintDocument();
            return doc.PrinterSettings.PrinterName;
            //return "Send To OneNote 2007";
        }


    }
}