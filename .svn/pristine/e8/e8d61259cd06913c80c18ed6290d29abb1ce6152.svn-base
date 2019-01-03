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

namespace ISA.Trading.VLapW
{
    public partial class frmRptRekapPembayaranDanPenjualan : ISA.Trading.BaseForm
    {
        string Kode;

        private string Valid()
        {
            string tipe = "";
            if (checkBox1.Checked==true)
            {
                tipe = "OCAHBVTLZGJ24";
            }  else
            {
                foreach (Control ctr in groupBox1.Controls)
                {
                    if (ctr is CheckBox)
                    {
                        CheckBox chk = (CheckBox)ctr;

                        if (chkO.Checked == true)
                        {
                            tipe = tipe +"O";
                        }
                        if (chkA.Checked == true)
                        {
                            tipe = tipe + "A";
                        }
                        if (chkL.Checked == true)
                        {
                            tipe = tipe + "L";
                        }
                        if (chkZ.Checked == true)
                        {
                            tipe = tipe + "Z";
                        }
                        if (chk2.Checked == true)
                        {
                            tipe = tipe + "2";
                        }
                        if (chkC.Checked == true)
                        {
                            tipe = tipe + "C";
                        }
                        if (chkV.Checked == true)
                        {
                            tipe = tipe + "V";
                        }
                        if (chkB.Checked == true)
                        {
                            tipe = tipe + "B";
                        }
                        if (chkJ.Checked == true)
                        {
                            tipe = tipe + "J";
                        }
                        if (chk4.Checked == true)
                        {
                            tipe = tipe + "4";
                        }
                        if (chkT.Checked == true)
                        {
                            tipe = tipe + "T";
                        }
                        if (chkH.Checked == true)
                        {
                            tipe = tipe + "H";
                        }
                        if (chkG.Checked == true)
                        {
                            tipe = tipe + "G";
                        }

                        break;

                    }
                }
            }

            
            return tipe.Trim();
        }

        public frmRptRekapPembayaranDanPenjualan()
        {
            InitializeComponent();
        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (Control ctr in groupBox1.Controls)
            {
                if (ctr is CheckBox)
                {
                    CheckBox chk = (CheckBox)ctr;
                    chk.Checked = checkBox1.Checked;
                }
            }
        }

        private void frmRptRekapPembayaranDanPenjualan_Load(object sender, EventArgs e)
        {
            foreach (Control ctr in groupBox1.Controls)
            {
                if (ctr is CheckBox)
                {
                    CheckBox chk = (CheckBox)ctr;
                    chk.Click+=new EventHandler(UncheckALL);
                }
            }

            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            rangeDateBox1.Focus();

            txtCabang.Text = GlobalVar.PerusahaanID;
            Kode = "";
        }

        private void UncheckALL(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (!this.rangeDateBox1.FromDate.HasValue || !this.rangeDateBox1.ToDate.HasValue)
            {
                rangeDateBox1.Focus();
                return;
            }
            if (dateTextBox1.Text=="")
            {
                dateTextBox1.Focus();
                return;
            }


            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    DataSet ds = new DataSet();
                    db.Commands.Add(db.CreateCommand("[rsp_VLapW_RekapPembelianDanPenjualan]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@CutOff", SqlDbType.DateTime, dateTextBox1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, txtCabang.Text));
                    Kode = Valid();
                    if (Kode=="")
                    {
                        Kode = "OCAHBVTLZGJ24";
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@KodeIdtr", SqlDbType.VarChar, Kode));

                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count==0)
                    {
                        MessageBox.Show("No Data");
                        return;
                    }

                    DisplayReport(dt);
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

        private void DisplayReport(DataTable dt)
        {
            string periode;
            string Init;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
           
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));
            if (txtCabang.Text.Trim()=="")
            {
                Init = "SAS-" + GlobalVar.PerusahaanID;
            }  else
            {
                Init = "SAS-" + txtCabang.Text;
            }
            
            rptParams.Add(new ReportParameter("Init", Init));

            // call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("VLapW.rptRekapPembayaranDanPenjualan.rdlc", rptParams, dt, "dsKartuPiutang_Data");
            ifrmReport.Show();

           


        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
           if (checkBox1.Checked==true)
           {
               foreach (Control ctr in groupBox1.Controls)
               {
                   if (ctr is CheckBox)
                   {
                       CheckBox chk = (CheckBox)ctr;
                       chk.Checked = checkBox1.Checked;
                   }
               }
           }   else
           {
               foreach (Control ctr in groupBox1.Controls)
               {
                   if (ctr is CheckBox)
                   {
                       CheckBox chk = (CheckBox)ctr;
                       chk.Checked = checkBox1.Checked;
                   }
               }
           }
        }

       
    }
}
