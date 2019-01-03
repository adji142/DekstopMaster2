using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using ISA.Toko.Class;
using Microsoft.Reporting.WinForms;

namespace ISA.Toko.Persediaan
    {
    public partial class frmRptMasterPerKodeRak : ISA.Toko.BaseForm
        {

        private void DisplayReport(DataTable dt)
            {

            //construct parameter
            List<ReportParameter> rptParams=new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("RakKe",txtKodeRak.Text));

            //call report viewer
            frmReportViewer ifrmReport=new frmReportViewer("Persediaan.rptMasterPerKodeRak.rdlc", rptParams, dt, "dsOpname_Data");
            ifrmReport.Show();

            }

        public frmRptMasterPerKodeRak()
            {
            InitializeComponent();
            }

        private void cmdNo_Click(object sender, EventArgs e)
            {
            this.Close();
            }

        private void cmdYes_Click(object sender, EventArgs e)
            {
            try
                {
                this.Cursor=Cursors.WaitCursor;
                using (Database db = new Database())
                    {
                    DataTable dt=new DataTable();
                    db.Commands.Add(db.CreateCommand("rsp_Opname_MasterPerKodeRak"));
                    db.Commands[0].Parameters.Add(new Parameter("@RakKe", SqlDbType.VarChar, txtRakKe.Value.ToString()));

                    switch (txtRakKe.Value.ToString())
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

                    if(dt.Rows.Count==0)
                        {
                        MessageBox.Show("Tidak Ada Data");
                        return;
                        }
                    //DisplayReport(dt);
                    PrintRawSPPB2(dt);
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

        private void frmRptMasterPerKodeRak_Load(object sender, EventArgs e)
            {

            }

        private void PrintRawSPPB(DataTable dt)
        {

            BuildString sppb = new BuildString();
            int No = 1;
            int n = dt.Rows.Count;
            int i = 0;
            int p = 0;
            int s = 0;
            p = n / 13;
            s = n % 13;

            bool _repeat = true;


            #region "Header"
            sppb.Initialize();
            sppb.LeftMargin(1);
            sppb.BottomMargin(1);
            
            sppb.PROW(true, 1, "KODE RAK :                                                                                  				      TANGGAL :");
            
            #endregion


            string _NamaStok = string.Empty;
            string _Pcs = string.Empty;
            string _Lok = string.Empty;
           
            string _Header1 = sppb.PrintTopLeftCorner() + sppb.PrintDoubleLine(4) + sppb.PrintTTOp() + sppb.PrintDoubleLine(77) + sppb.PrintTTOp() + sppb.PrintDoubleLine(3) + sppb.PrintTTOp() + sppb.PrintDoubleLine(15) + sppb.PrintTTOp() + sppb.PrintDoubleLine(15) + sppb.PrintTTOp() + sppb.PrintDoubleLine(15) + sppb.PrintTTOp() + sppb.PrintDoubleLine(7) + sppb.PrintTopRightCorner();
            string _Header2 = sppb.PrintVerticalLine() + "No. " + sppb.PrintVerticalLine() + "                       N  A  M  A      B  A  R  A  N  G                      " + sppb.PrintVerticalLine() + "SAT" + sppb.PrintVerticalLine() + "        1      " + sppb.PrintVerticalLine() + "       2       " + sppb.PrintVerticalLine() + "       3       " + sppb.PrintVerticalLine() + "   OK. " + sppb.PrintVerticalLine();
            string _Header3 = sppb.PrintTLeft() + sppb.PrintDoubleLine(4) + sppb.PrintTMidlle() + sppb.PrintDoubleLine(77) + sppb.PrintTMidlle() + sppb.PrintDoubleLine(3) + sppb.PrintTMidlle() + sppb.PrintDoubleLine(15) + sppb.PrintTMidlle() + sppb.PrintDoubleLine(15) + sppb.PrintTMidlle() + sppb.PrintDoubleLine(15) + sppb.PrintTMidlle() + sppb.PrintDoubleLine(7) + sppb.PrintTRight();
            string _Footer1 = sppb.PrintTLeft() + sppb.PrintHorizontalLine(4) + sppb.PrintTMidlle() + sppb.PrintHorizontalLine(77) + sppb.PrintTMidlle() + sppb.PrintHorizontalLine(3) + sppb.PrintTMidlle() + sppb.PrintHorizontalLine(15) + sppb.PrintTMidlle() + sppb.PrintHorizontalLine(15) + sppb.PrintTMidlle() + sppb.PrintHorizontalLine(15) + sppb.PrintTMidlle() + sppb.PrintHorizontalLine(7) + sppb.PrintTRight();
            string _Footer2 = sppb.PrintBottomLeftCorner() + sppb.PrintHorizontalLine(4) + sppb.PrintTBottom() + sppb.PrintHorizontalLine(77) + sppb.PrintTBottom() + sppb.PrintHorizontalLine(3) + sppb.PrintTBottom() + sppb.PrintHorizontalLine(15) + sppb.PrintTBottom() + sppb.PrintHorizontalLine(15) + sppb.PrintTBottom() + sppb.PrintHorizontalLine(15) + sppb.PrintTBottom() + sppb.PrintHorizontalLine(7) + sppb.PrintBottomRightCorner();
            string _temp = sppb.PrintVerticalLine() + "               " + sppb.PrintVerticalLine() + "               " + sppb.PrintVerticalLine() + "               " + sppb.PrintVerticalLine();
            foreach (DataRow dr in dt.Rows)
            {

#region "Header"
                if (i==0 && _repeat)
                {
                    sppb.PROW(true, 1, _Header1);
                    sppb.PROW(true, 1, _Header2);
                    sppb.PROW(true, 1, _Header3);
                }
                
#endregion
                if (i<=13)
                {
                    _NamaStok = dr["NamaStok"].ToString();
                    _Pcs = dr["SatJual"].ToString();
                    _Lok = dr["Lokasi"].ToString();



                    sppb.PROW(true, 1, sppb.PrintVerticalLine() + No.ToString().PadLeft(4, ' ') + sppb.PrintVerticalLine() + _NamaStok.PadRight(73, '.') + sppb.SPACE(4) + sppb.PrintVerticalLine() + _Pcs.PadLeft(3, ' ') + _temp + _Lok.PadLeft(7, ' ') + sppb.PrintVerticalLine());
                    
                    sppb.PROW(true, 1, (No==n || i==12) ? _Footer2 : _Footer1  );

                    _repeat = false;
                    if (i == 12 || No == n)
                    {
                        sppb.PROW(true, 1, " ");
                        _repeat = true;
                        i = -1;
                        sppb.Eject();
                    }
                }
              
                i++;
                No++;
            }
            


            
            sppb.SendToPrinter("sppb.txt",sppb.ToString());
        }


        private void PrintRawSPPB2(DataTable dt)
        {
            BuildString sppb = new BuildString();

            
            string _NamaStok = string.Empty;
            string _Pcs = string.Empty;
            string _Lok = string.Empty;
            int No = 0;
            int n = dt.Rows.Count;
            int i = 0;
            int p = 0;
            int s = 0;
            p = n / 13;
            s = n % 13;

#region "First Header"
            //sppb.Initialize();
            //sppb.LeftMargin(1);
            //sppb.BottomMargin(1);
            //sppb.PROW(true, 1, string.Empty);
            sppb.AddCR();
            sppb.PROW(false, 1, "KODE RAK :                                                                                  				     TANGGAL :");
            sppb.Append(PrintHeader(No, n));
#endregion
            
#region "Detail"
            foreach (DataRow dr in dt.Rows)
            {
                No++;
                i++;
                _NamaStok = dr["NamaStok"].ToString();
                _Pcs = dr["SatJual"].ToString();
                _Lok = dr["Lokasi"].ToString();

                sppb.PROW(true, 1, sppb.PrintVerticalLine() + No.ToString().PadLeft(4, ' ') + sppb.PrintVerticalLine() + _NamaStok.PadRight(73, '.') + sppb.SPACE(4) + sppb.PrintVerticalLine() + _Pcs.PadLeft(3, ' ') + sppb.PrintVerticalLine() + "              " + sppb.PrintVerticalLine() + "              " + sppb.PrintVerticalLine() + "              " + sppb.PrintVerticalLine() + _Lok.PadLeft(7, ' ') + sppb.PrintVerticalLine());
                if (i==28 || No==n)
                {
                     sppb.PROW(true, 1,sppb.PrintBottomLeftCorner() + sppb.PrintHorizontalLine(4) + sppb.PrintTBottom() + sppb.PrintHorizontalLine(77) + sppb.PrintTBottom() + sppb.PrintHorizontalLine(3) + sppb.PrintTBottom() + sppb.PrintHorizontalLine(14) + sppb.PrintTBottom() + sppb.PrintHorizontalLine(14) + sppb.PrintTBottom() + sppb.PrintHorizontalLine(14) + sppb.PrintTBottom() + sppb.PrintHorizontalLine(7) + sppb.PrintRightBottomCorner());
                     sppb.Eject();
                     i=0;

                    if (i==0 && No!=n)
                    {
                     
                        sppb.Append(PrintHeader(No, n));
                    }
                     
                } 
                else
                {
                     sppb.PROW(true, 1,  sppb.PrintTLeft() + sppb.PrintHorizontalLine(4) + sppb.PrintTMidlle() + sppb.PrintHorizontalLine(77) + sppb.PrintTMidlle() + sppb.PrintHorizontalLine(3) + sppb.PrintTMidlle() + sppb.PrintHorizontalLine(14) + sppb.PrintTMidlle() + sppb.PrintHorizontalLine(14) + sppb.PrintTMidlle() + sppb.PrintHorizontalLine(14) + sppb.PrintTMidlle() + sppb.PrintHorizontalLine(7) + sppb.PrintTRight() );
                }

            }
#endregion

            sppb.SendToPrinter("sppb.txt", sppb.GenerateString());
        }

        private string PrintHeader(int nUrut, int nMaxHal)
        {
            BuildString header = new BuildString();
            int nHal = (int)Math.Round((nUrut / 18) + 0.4, 0) + 1;

            header.PROW(true,1, header.PrintTopLeftCorner() + header.PrintDoubleLine(4) + header.PrintTTOp() + header.PrintDoubleLine(77) + header.PrintTTOp() + header.PrintDoubleLine(3) + header.PrintTTOp() + header.PrintDoubleLine(14) + header.PrintTTOp() + header.PrintDoubleLine(14) + header.PrintTTOp() + header.PrintDoubleLine(14) + header.PrintTTOp() + header.PrintDoubleLine(7) + header.PrintTopRightCorner());
            header.PROW(true,1,header.PrintVerticalLine() + "No. " + header.PrintVerticalLine() + "                       N  A  M  A      B  A  R  A  N  G                      " + header.PrintVerticalLine() + "SAT" + header.PrintVerticalLine() + "        1     " + header.PrintVerticalLine() + "       2      " + header.PrintVerticalLine() + "       3      " + header.PrintVerticalLine() + "   OK. " + header.PrintVerticalLine());
            header.PROW(true,1,header.PrintTLeft() + header.PrintDoubleLine(4) + header.PrintTMidlle() + header.PrintDoubleLine(77) + header.PrintTMidlle() + header.PrintDoubleLine(3) + header.PrintTMidlle() + header.PrintDoubleLine(14) + header.PrintTMidlle() + header.PrintDoubleLine(14) + header.PrintTMidlle() + header.PrintDoubleLine(14) + header.PrintTMidlle() + header.PrintDoubleLine(7) + header.PrintTRight());

            return header.GenerateString();
        }


        private  string _temp()
        {
            BuildString sppb = new BuildString();
            string _temp = sppb.PrintVerticalLine() + "              " + sppb.PrintVerticalLine() + "              " + sppb.PrintVerticalLine() + "              " + sppb.PrintVerticalLine();
            return sppb.GenerateString();
        }

        
        }
    }
