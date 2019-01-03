using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Reporting.WinForms;
using ISA.Toko.DataTemplates;
using ISA.DAL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;
using ISA.Toko.POS;

namespace ISA.Toko.POS.Bayar
{
    public partial class FrmBayar : ISA.Toko.BaseForm
    {
        string datapassing; // tambahan
        string kodetoko, namatoko;
        DateTime tgljatuhtempo, tglsekarang; 
        int jumlahhutang;
        bool _isCetakNota = true;

        public FrmBayar(Form caller)
        {
            InitializeComponent();
            
            this.Caller = caller;          
        }

        public FrmBayar(Form caller, bool isCetakNota)
        {
            InitializeComponent();

            this.Caller = caller;
            _isCetakNota = isCetakNota;
        }    

        private void FrmBayar2_Load(object sender, EventArgs e)
        {
            if (this.Caller is FrmPOS)
            {
                POS.FrmPOS frmCaller = (POS.FrmPOS)this.Caller;
                TxtNeto.Text = frmCaller.label12.Text.ToString();
                kodetoko=frmCaller.LblKodeToko.Text.ToString();  
                namatoko=frmCaller.TxtNamaToko.Text.ToString();               
            }
            
              //DateTime.Now  ;
            LblNota.Visible = false;
            label1.Visible = false;
            CmdPrint.Enabled = false;
        }
        private void commandButton3_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void commandButton2_Click(object sender, EventArgs e)
        {
            if (this.Caller is FrmPOS)
            {
                POS.FrmPOS frmCaller = (POS.FrmPOS)this.Caller;
                frmCaller.Save_DONOTA(sender, e);
                

                LblNota.Text = frmCaller.LblNoNota.Text.ToString();
               
                
                
                // LblNoDO_.Text = frmCaller.LblNoDO.Text.ToString();

                //if (_isCetakNota)
                //{
                //    DialogResult dialogResult = MessageBox.Show("Data dengan Nomor Nota : " + Convert.ToString(LblNota.Text) + ", Nomor DO : " + Convert.ToString(LblNota.Text) + " Telah Disimpan" + "\n\n\n" + "CETAK NOTA ?", "KONFIRMASI", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //    if (dialogResult == DialogResult.Yes)
                //    {
                //        //ini yang nanti diganti;
                //        //CmdPrint_Click(sender, e);
                //        frmCaller.cetakNota();
                //        this.Close();
                //    }
                //    else if (dialogResult == DialogResult.No)
                //    {
                //        this.Close();
                //    }
                    this.Close();
                    POS.FrmPOS ifrmChild = new POS.FrmPOS();
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                //}
                //else
                //{
                //    this.Close();
                //}
             }
            label1.Visible = true;
            LblNota.Visible = true;
            CmdPrint.Enabled = true;            
        }
       
        private void PrintNota()
        {
            DataSet dt = new DataSet();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("rsp_Cetak_POS_nota"));
                db.Commands[0].Parameters.Add(new Parameter("@NoNota", SqlDbType.VarChar, LblNota.Text));
                dt = db.Commands[0].ExecuteDataSet();
            }
            if (dt.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Data tidak ada.....");
                Close();
            }
            else
            {
                DisplayReport(dt);
                using (Database db = new Database())
                {
                    DataTable dtupdate = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_nPrint_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@NoDO", SqlDbType.VarChar, LblNoDO_.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@NoNota", SqlDbType.VarChar, LblNota.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, 1));
                    dtupdate = db.Commands[0].ExecuteDataTable();

                }
            }
            this.Cursor = Cursors.Default;
        }
        private void DisplayReport(DataSet ds)
        {
            List<ReportParameter> rptParams = new List<ReportParameter>();

            //rptParams.Add(new ReportParameter("fromdate", rangeDateBox1.FromDate.Value.ToString("dd-MMM-yyyy")));
            //rptParams.Add(new ReportParameter("ToDate", rangeDateBox1.ToDate.Value.ToString("dd-MMM-yyyy")));
            //rptParams.Add(new ReportParameter("namasales", _sales));
            DataTable dt0 = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];

            List<DataTable> dt2 = new List<DataTable>();
            List<string> dtName = new List<string>();

            dt2.Clear();
            //dtName.Clear();

            dt2.Add(dt0);
            dt2.Add(dt1);

            dtName.Add("CetakPOSNota_PosNota");
            dtName.Add("CetakPOSNota_DataPerusahaan");

            //frmReportViewer ifrmReport = new frmReportViewer("POS.CETAK.RptCetakPosNota2.rdlc", rptParams, dt2, dtName);
            frmReportViewer ifrmReport = new frmReportViewer("POS.CETAK.rptCetakNotaPOSTax.rdlc", rptParams, dt2, dtName);
            //frmReportViewer ifrmReport = new frmReportViewer("PO.cetak.rptCetakPO.rdlc", rptParams, dt, "dsCetakPO_Detail");
            //frmReportViewer ifrmReport = new frmReportViewer("POS.CETAK.RptCetakPosNota2.rdlc", rptParams, dt, "CetakPOSNota_PosNota");

            ifrmReport.Show();
        }

        private void CmdPrint_Click(object sender, EventArgs e)
        {
            //PrintNota();
            if (this.Caller is FrmPOS)
            {
                POS.FrmPOS frmCaller = (POS.FrmPOS)this.Caller;
                frmCaller.cekcetak();
            }
        }
    }
}
