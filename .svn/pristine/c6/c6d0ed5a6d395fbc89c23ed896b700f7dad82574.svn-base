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
using System.IO;
using ISA.Trading.Class;

namespace ISA.Trading.Persediaan
    {
    public partial class frmRptDetailPerKodeRak : ISA.Trading.BaseForm
        {

        private void DisplayReport(DataTable dt)
        {

            ////construct parameter
            //List<ReportParameter> rptParams=new List<ReportParameter>();
            //rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            ////call report viewer
            //frmReportViewer ifrmReport=new frmReportViewer("Persediaan.rptDetailPerKodeRak.rdlc", rptParams, dt, "dsOpname_Data");
            //ifrmReport.Show();
            int i=0;
            BuildString detail = new BuildString();
            detail.FontCondensed(true);
            detail.LeftMargin(3);
            foreach (DataRowView dr in dt.DefaultView)
            {
                i++;


                detail.PROW(true, 1, detail.PrintTopLeftCorner() + detail.PrintHorizontalLine(42) + detail.PrintTTOp() +
                    detail.PrintHorizontalLine(42) + detail.PrintTTOp() + detail.PrintHorizontalLine(42) + detail.PrintTopRightCorner());

                detail.PROW(true, 1, detail.PrintVerticalLine() + "Tanggal :".PadRight(42) + detail.PrintVerticalLine() + "No. Form :".PadRight(42) 
                    + detail.PrintVerticalLine() + detail.PadCenter(42, "KODE RAK :" + dr["Lokasi"].ToString())+ detail.PrintVerticalLine());

                detail.PROW(true, 1, detail.PrintTLeft() + detail.PrintHorizontalLine(5)+ detail.PrintTTOp()+
                    detail.PrintHorizontalLine(36) + detail.PrintTBottom() + detail.PrintHorizontalLine(42) + detail.PrintTBottom() +
                    detail.PrintHorizontalLine(20) + detail.PrintTTOp() + detail.PrintHorizontalLine(5) + detail.PrintTTOp() + 
                    detail.PrintHorizontalLine(15) + detail.PrintTRight());
                
                detail.PROW(true, 1, detail.PrintVerticalLine() + detail.PadCenter(5, "NO.") + detail.PrintVerticalLine() + detail.PadCenter(100, "NAMA BARANG") 
                    + detail.PrintVerticalLine() + detail.PadCenter(5, "SAT") + detail.PrintVerticalLine() + detail.PadCenter(15, "PENGHITUNG") + detail.PrintVerticalLine());

                detail.PROW(true, 1, detail.PrintTLeft() + detail.PrintHorizontalLine(5) + detail.PrintTMidlle() +
                    detail.PrintHorizontalLine(100)+ detail.PrintTMidlle() + detail.PrintHorizontalLine(5) + detail.PrintTMidlle() +
                    detail.PrintHorizontalLine(15) + detail.PrintTRight());
                
                //detail.PROW(true, 1, detail.PrintVerticalLine() + detail.PadCenter(5, "") + detail.PrintVerticalLine() + detail.PadCenter(100, "")
                //   + detail.PrintVerticalLine() + detail.PadCenter(5, "") + detail.PrintVerticalLine() + detail.PadCenter(15, "") + detail.PrintVerticalLine());
                
                detail.PROW(true, 1, detail.PrintVerticalLine() + i.ToString().PadLeft(5) + detail.PrintVerticalLine() + dr["NamaStok"].ToString().PadRight(100)
                    + detail.PrintVerticalLine() + detail.PadCenter(5, dr["SatJual"].ToString()) + detail.PrintVerticalLine() + detail.PadCenter(15, "") + detail.PrintVerticalLine());

                //detail.PROW(true, 1, detail.PrintVerticalLine() + detail.PadCenter(5, "") + detail.PrintVerticalLine() + detail.PadCenter(100, "")
                //    + detail.PrintVerticalLine() + detail.PadCenter(5, "") + detail.PrintVerticalLine() + detail.PadCenter(15, "") + detail.PrintVerticalLine());

                detail.PROW(true, 1, detail.PrintTLeft() + detail.PrintHorizontalLine(5) + detail.PrintTBottom() +
                    detail.PrintHorizontalLine(22) + detail.PrintTTOp() + detail.PrintHorizontalLine(28) + detail.PrintTTOp() +
                    detail.PrintHorizontalLine(28) + detail.PrintTTOp() + detail.PrintHorizontalLine(19) + detail.PrintTBottom() + 
                    detail.PrintHorizontalLine(5) + detail.PrintTBottom() + detail.PrintHorizontalLine(15) + detail.PrintTRight());
                
                detail.PROW(true, 1, detail.PrintVerticalLine() + detail.PadCenter(28, "BAIK") + detail.PrintVerticalLine() + detail.PadCenter(28, "CACAT") + detail.PrintVerticalLine()
                    + detail.PadCenter(28, "RUSAK") + detail.PrintVerticalLine() + "Dicatat Oleh,".PadLeft(41)+detail.PrintVerticalLine());

                detail.PROW(true, 1, detail.PrintVerticalLine() + detail.PadCenter(28, "") + detail.PrintVerticalLine() + detail.PadCenter(28, "") + detail.PrintVerticalLine()
                    + detail.PadCenter(28, "") + detail.PrintVerticalLine() + "".PadLeft(41) + detail.PrintVerticalLine());
                detail.PROW(true, 1, detail.PrintVerticalLine() + detail.PadCenter(28, "") + detail.PrintVerticalLine() + detail.PadCenter(28, "") + detail.PrintVerticalLine()
                    + detail.PadCenter(28, "") + detail.PrintVerticalLine() + "".PadLeft(41) + detail.PrintVerticalLine());
                detail.PROW(true, 1, detail.PrintVerticalLine() + detail.PadCenter(28, "") + detail.PrintVerticalLine() + detail.PadCenter(28, "") + detail.PrintVerticalLine()
                    + detail.PadCenter(28, "") + detail.PrintVerticalLine() + "Bag. Adm. Persediaan".PadLeft(41) + detail.PrintVerticalLine());

                detail.PROW(true, 1, detail.PrintBottomLeftCorner() + detail.PrintHorizontalLine(28) + detail.PrintTBottom() + detail.PrintHorizontalLine(28) + detail.PrintTBottom() +
                    detail.PrintHorizontalLine(28) + detail.PrintTBottom() + detail.PrintHorizontalLine(41) + detail.PrintBottomRightCorner());
                

                if ((i % 2 == 0)&&(i%4!=0))
                {
                    for (int j=0;j<10;j++)
                    {
                        detail.PROW(true, 1, "");
                    }
                }
                else if (i % 4 == 0)
                {
                    detail.Eject();
                }
            }
            if (i % 2 != 0)
                detail.Eject();
         
            
            detail.SendToPrinter("notaJual.txt");

        }

        public frmRptDetailPerKodeRak()
            {
            InitializeComponent();
            }

        private void frmRptDetailPerKodeRak_Load(object sender, EventArgs e)
            {

            }

        private void cmdYes_Click(object sender, EventArgs e)
            {
            if (txtKodeRak.Text=="" )
            {
            txtKodeRak.Focus();
            return;
            }

            if(Convert.ToInt32(txtRakKe.Value)>3||Convert.ToInt32(txtRakKe.Value)<=0||txtRakKe.Value.ToString()=="")
            {
            txtRakKe.Focus();
            return;
            }


            try
                {
                this.Cursor=Cursors.WaitCursor;
                using (Database db = new Database())
                    {
                    DataTable dt=new DataTable();
                    db.Commands.Add(db.CreateCommand("rsp_Opname_MasterPerKodeRak"));
                    db.Commands[0].Parameters.Add(new Parameter("@RakKe", SqlDbType.VarChar, this.txtRakKe.Value.ToString().Trim()));

                    switch(txtRakKe.Value.ToString())
                        {
                        case "1":
                        db.Commands[0].Parameters.Add(new Parameter("@KodeRakKe1", SqlDbType.VarChar, txtKodeRak.Text.Trim()));
                        break;
                        case "2":
                        db.Commands[0].Parameters.Add(new Parameter("@KodeRakKe2", SqlDbType.VarChar, txtKodeRak.Text.Trim()));
                        break;
                        case "3":
                        db.Commands[0].Parameters.Add(new Parameter("@KodeRakKe3", SqlDbType.VarChar, txtKodeRak.Text.Trim()));
                        break;
                        
                        }

                    dt=db.Commands[0].ExecuteDataTable();
                    dt.DefaultView.Sort = "Lokasi";
                    if(dt.Rows.Count==0)
                        {
                        MessageBox.Show("Tidak Ada Data");
                        return;
                        }
                    if (rdb1item.Checked)
                    {
                        DisplayReport(dt);
                    }
                    else
                    {
                        DspReport5(dt);

                    }
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

        private void DspReport5(DataTable dt)
        {
            //List<ReportParameter> rptParams = new List<ReportParameter>();
            //rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            //rptParams.Add(new ReportParameter("GroupLokasi", txtKodeRak.Text));

            ////call report viewer
            //frmReportViewer ifrmReport = new frmReportViewer("Persediaan.rptFrmDetailPerKodeRak5.rdlc", rptParams, dt, "dsOpname_Data");
            //ifrmReport.Show();

            {
                int i = 0;
                int No = 0;
                int n = dt.Rows.Count;
                BuildString detail = new BuildString();
                detail.FontCondensed(true);
                detail.LeftMargin(0);
                detail.PageLLine(33);
                foreach (DataRowView dr in dt.DefaultView)
                {
                    i++;
                    No++;
                    if (i == 1)
                    {
                        detail.PROW(true, 1, "FORM OPNAME 2014                                                                                                   NOMOR :");
                        detail.PROW(true, 1, "                                                                                                                                       ");
                        detail.PROW(true, 1, "Tanggal :                                                                                                          Hitungan ke :");
                        detail.PROW(true, 1, "-------------------------------------------------------------------------------------------------------------------------------------------------------");
                        detail.PROW(true, 1, "|No.  | Nama Barang                                                                                        | Sat. | Kode Rak |  Baik  | Cacat | Rusak |");
                        detail.PROW(true, 1, "-------------------------------------------------------------------------------------------------------------------------------------------------------");
                        //                    |12345|xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx| xxxxx| xxxxxxx  |      |       |       |
                    }
                    detail.PROW(true, 1, "|" + i.ToString().PadLeft(5, ' ') + "|" + dr["NamaStok"].ToString().PadRight(100)
                            + "| " + detail.PadCenter(5, dr["SatJual"].ToString()) + "| " + dr["Lokasi"].ToString() + "  |        |       |       |");
                    detail.PROW(true, 1, "|     |                                                                                                    |      |          |        |       |       |");
                    detail.PROW(true, 1, "-------------------------------------------------------------------------------------------------------------------------------------------------------");

                    if ((No == n) || (i == 5 && No != n)) // eof()
                    {
                        i = 0;
                        detail.PROW(true, 1, "             Penghitung                                                   Pencatat                                         Ka. Area");
                        detail.PROW(true, 1, "                                                                                                                                       ");
                        detail.PROW(true, 1, "                                                                                                                                       ");
                        detail.PROW(true, 1, "          (...............)                                            (..............)                                (................)");
                        detail.Eject();
                    }

                }
                detail.SendToPrinter("detailPerKodeRak.txt");
            }

        }


        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        }
    }
