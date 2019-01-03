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
using ISA.Toko.DO;

namespace ISA.Toko.DO.BayarDO
{
    public partial class FrmBayarDO : ISA.Toko.BaseForm
    {
        string datapassing; // tambahan
        public FrmBayarDO(Form caller)
        {
            InitializeComponent();
            //this.datapassing ; //tambahan
            
            this.Caller = caller;          
        }
    
        private void FrmBayar_Load(object sender, EventArgs e)
        {
            this.Text = "Pembayaran";
            if (this.Caller is FrmDO)
            {
                DO.FrmDO frmCaller = (DO.FrmDO)this.Caller;
                TxtNeto.Text = frmCaller.label12.Text.ToString();
                
            }
            LblNota.Visible = false;
            label1.Visible = false;
           

        }

        private void commandButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
                               
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void LblNota_Click(object sender, EventArgs e)
        {

        }

        private void DisplayReport(DataSet dt)
        {

           

            List<ReportParameter> rptParams = new List<ReportParameter>();

            //rptParams.Add(new ReportParameter("fromdate", rangeDateBox1.FromDate.Value.ToString("dd-MMM-yyyy")));
            //rptParams.Add(new ReportParameter("ToDate", rangeDateBox1.ToDate.Value.ToString("dd-MMM-yyyy")));
            //rptParams.Add(new ReportParameter("namasales", _sales));
          
            
            DataTable dt0 = dt.Tables[0];
            DataTable dt1 = dt.Tables[1];
          

            List<DataTable> dt2 = new List<DataTable>();
            List<string> dtName = new List<string>();

            dt2.Clear();
            dtName.Clear();

            dt2.Add(dt0);
            dt2.Add(dt1);

            dtName.Add("CetakPOSNota_PosNota");
            dtName.Add("CetakPOSNota_DataPerusahaan");

            frmReportViewer ifrmReport = new frmReportViewer("POS.CETAK.RptCetakPosNota2.rdlc", rptParams, dt2, dtName);
            //frmReportViewer ifrmReport = new frmReportViewer("POS.CETAK.RptCetakPosNota2.rdlc", rptParams, dt, "CetakPOSNota_PosNota");
            
            ifrmReport.Show();


            //}
        }

        private void commandButton3_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        

        private void commandButton2_Click_1(object sender, EventArgs e)
        {

            if (this.Caller is FrmDO2803)
            {
                DO.FrmDO2803 frmCaller = (DO.FrmDO2803)this.Caller;
                //if (GlobalVar.Gudang != "2803")
                //{
                //    frmCaller.InsertTokoPlafon();
                //}
                //frmCaller.Save_DONOTA(sender, e);
                LblNota.Text = frmCaller.LblNoNota.Text.ToString();
                LblNoDO_.Text = frmCaller.LblNoDO.Text.ToString();
                MessageBox.Show("Data dengan Nomor DO : " + Convert.ToString(LblNoDO_.Text) + " Telah Disimpan");
                this.Close();
                DO.FrmDO ifrmChild = new DO.FrmDO(null);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            else
            {
                DO.FrmDO frmCaller = (DO.FrmDO)this.Caller;
                //if (GlobalVar.Gudang != "2803")
                //{
                //    frmCaller.InsertTokoPlafon();
                //}
                frmCaller.Save_DONOTA(sender, e);
                LblNota.Text = frmCaller.LblNoNota.Text.ToString();
                LblNoDO_.Text = frmCaller.LblNoDO.Text.ToString();
                MessageBox.Show("Data dengan Nomor DO : " + Convert.ToString(LblNoDO_.Text) + " Telah Disimpan");
                this.Close();
                DO.FrmDO ifrmChild = new DO.FrmDO(null);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }

            label1.Visible = true;
            LblNota.Visible = true;   
        }

        private void CmdPrint_Click(object sender, EventArgs e)
        {
            try
            {

                this.Cursor = Cursors.WaitCursor;
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

      

       

        


      
    }
}
