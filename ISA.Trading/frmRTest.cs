using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using ISA.Trading.Class;
using System.Data.OleDb;
using System.Drawing.Printing;
using System.IO;

namespace ISA.Trading
{
    public partial class frmRTest : Form
    {
        DataTable dt = new DataTable();
        //dsStatusToko.DataDataTable dtReport = new dsStatusToko.DataDataTable();

        public frmRTest()
        {
            InitializeComponent(); 

        }

        private void frmRTest_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int? a;
            a = null;
            int b;
            b = a??0;
            MessageBox.Show(b.ToString());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
       
            openFileDialog1.ShowDialog();
            string fileName1 = openFileDialog1.FileName;
            openFileDialog1.ShowDialog();
            string fileName2 = openFileDialog1.FileName;
            List<string> files = new List<string>();
            files.Add(fileName1);
            files.Add (fileName2);
            
            Zip.ZipFiles(files, "c:\\Temp\\ISA.zip");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Zip.UnZipFiles("c:\\Temp\\ISA.zip", "c:\\Temp\\Output", false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = SecurityManager.EncodePassword("sas11palur");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //FTP.Upload("ftp.zip");
            //MessageBox.Show("Ok");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //FTP.Download("ftp.zip");
            //MessageBox.Show("Ok");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //FTP.Delete("ftp.zip");
            //MessageBox.Show("Ok");
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string _connStrTemplate = "Provider = VFPOLEDB;Data Source={0}";
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    // Get incompleted Job
                    db.Commands.Add(db.CreateCommand("usp_FoxproInjection_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@complete", SqlDbType.Bit, 0));
                    dt = db.Commands[0].ExecuteDataTable();

                    db.Commands.Add(db.CreateCommand("usp_FoxproInjection_UPDATE"));

                    // Loop for each incompleted job
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            string script = dr["script"].ToString();
                            //inject to foxpro

                            string connStr = string.Format(_connStrTemplate, "\\\\JKTDEV\\sasapp$\\DBF Stok Piutang");//LookupInfo.GetValue("WINSERVICES", "KASIR_PATH"));
                            using (OleDbConnection conn = new OleDbConnection(connStr))
                            {
                                //Create Table
                                OleDbCommand cmd = new OleDbCommand();
                                cmd.Connection = conn;
                                cmd.CommandText = dr["Script"].ToString();
                                cmd.CommandType = CommandType.Text;
                                conn.Open();
                                cmd.ExecuteNonQuery();
                            }

                            //Update table FoxproInjection, set complete to true
                            db.Commands[1].Parameters.Clear();
                            db.Commands[1].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, dr["RowID"]));
                            db.Commands[1].Parameters.Add(new Parameter("@complete", SqlDbType.Bit, 1));
                            db.Commands[1].Parameters.Add(new Parameter("@runDate", SqlDbType.DateTime, DateTime.Now));
                            db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, "ISA.WinServices"));
                            db.Commands[1].ExecuteNonQuery();
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string connStr2 = "Provider = VFPOLEDB;Data Source=\\\\jktdev\\sasapp$\\SAS\\database";

            using (OleDbConnection conn = new OleDbConnection(connStr2))
            {
                //Create Table
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandText = "EXECSCRIPT([USE HHTRANSJ]+CHR(13)+CHR(10)+[COPY STRUCTURE TO 'C:\\TEMP\\Temp tes\\JTEMP' WITH CDX])";
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.ExecuteNonQuery();
             }
            MessageBox.Show(":P");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (SecurityManager.AskPasswordManager())
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }

        StringReader myReader;
        private void button10_Click(object sender, EventArgs e)
        {
            
            PrintDocument doc = new PrintDocument();
            //doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.ThePrintDocument_PrintPage);
            myReader = new StringReader(txtPrint1.Text);
            doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.ThePrintDocument_PrintDO);
            doc.Print();
        }

         protected void ThePrintDocument_PrintDO(object sender, System.Drawing.Printing.PrintPageEventArgs ev)
        {

            float linesPerPage = 0;
            float yPosition = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;
            System.Drawing.Font printFont = new Font(new FontFamily("Arial"), ((float)8.0));
            SolidBrush myBrush = new SolidBrush(Color.Black);

            // Work out the number of lines per page, using the MarginBounds.
            //linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);
            //linesPerPage = 33;
            // Iterate over the string using the StringReader, printing each line.
            
            line = myReader.ReadLine();
            while (line != null && line != "\"BREAK\"")
            {
                // calculate the next line position based on 
                // the height of the font according to the printing device
                yPosition = topMargin + (count * printFont.GetHeight(ev.Graphics));

                // draw the next line in the rich edit control

                ev.Graphics.DrawString(line, printFont, myBrush, leftMargin, yPosition, new StringFormat());
                count++;
                line = myReader.ReadLine();
            }

            // If there are more lines, print another page.
            if (line == "\"BREAK\"")
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;

            myBrush.Dispose();

        }
    

         protected void ThePrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs ev)
        {
             StringReader myReader;
              myReader = new StringReader(txtPrint1.Text);

            float linesPerPage = 0;
            float yPosition = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;
            System.Drawing.Font printFont = new Font(new FontFamily ("Arial"), ((float)8.0));
            SolidBrush myBrush = new SolidBrush(Color.Black);

            // Work out the number of lines per page, using the MarginBounds.
            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

            // Iterate over the string using the StringReader, printing each line.
            while (count < linesPerPage && ((line = myReader.ReadLine()) != null))
            {
                // calculate the next line position based on 
                // the height of the font according to the printing device
                yPosition = topMargin + (count * printFont.GetHeight(ev.Graphics));

                // draw the next line in the rich edit control

                ev.Graphics.DrawString(line, printFont, myBrush, leftMargin, yPosition, new StringFormat());
                count++;
            }

            // If there are more lines, print another page.
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;

            myBrush.Dispose();

        }

         private void button11_Click(object sender, EventArgs e)
         {
             //string printerName = "\\\\jktdev\\Canon MP280 series Printer";
             string printerName = "\\\\apw-new\\Epson LQ-2180 ESC/P 2";
             string PrintText = txtPrint1.Text ;
             //string PrintText = "C:\\Temp\\ESC2.TXT";
             RawPrinterHelper.SendStringToPrinter(printerName, PrintText);
             //RawPrinterHelper.SendFileToPrinter(printerName, PrintText);
         }

         private void button12_Click(object sender, EventArgs e)
         {
             
            // BuildString data = new BuildString();
            // StringBuilder result = new StringBuilder();

            // int nHal = 1;
            // int nMaxHal = 1;
            // string Catatan1 = string.Empty;
            // string Catatan3 = string.Empty;
            // string Sales = "1\\1\\HARTONO";
            // string NamaToko = "MUTIARA JAYA MOTOR";
            // string cClass = "K1";
            // string DO = "IFE0390 Kamis,09-Jun-2011";
            // string NoRq = "HTO!09A Kamis,09-Jun-2011";
            // string AlamatKirim = "JL. RAYA PRANCIS NO.33";
            // //string nSpace = NamaToko.Trim() + printESC.SPACE(NamaToko.Trim().Length + (15 - NamaToko.Trim().Length) - 7) + cClass;
            // string Waktu = "30" + " Hari / ";
            // string wilID = "HB-0453";
            // string Daerah = "PRANCIS" + "Wil: " + wilID + ")";
            // string Kota = "JAKARTA BARAT";
            // string Expedisi = "JNE";
            // string NamaExpedisi = "TIKI JNE";
            // int plafon = 10969333;
            // string Grade = string.Empty;
            // string TypePrinter = "LQ";
            //// string cKet = printESC.SPACE(2);

            // nMaxHal = nMaxHal == 0 ? 1 : nMaxHal;

            // #region Header
            // data.Initialize();
            // data.FontCondensed(false);
            // data.FontCPI(17);
            // data.PageLLine(33);
            // data.LeftMargin(1);
            // data.BottomMargin(1);
            // data.FontCondensed(true);
            // if (TypePrinter.Contains("LX"))
            // {
            //     data.DoubleHeight(true);
            // }
            // else
            // {
            //     data.DoubleWidth(true);
            // }

            // data.PROW(true, 1, "DELIVERY ORDER    (" + nHal.ToString() + "/" + nMaxHal.ToString() + ")" + data.SPACE(3) + cKet);
            // data.FontCondensed(false);
            // data.DoubleHeight(false);
            // data.DoubleWidth(false);
            // data.FontCPI(12);
            // data.PROW(true, 1, data.Sales(Sales));
            // data.FontBold(false);
            // data.FontItalic(false);
            // data.LineSpacing("1/8");
            // data.FontItalic(true);
            // data.AddCR();
            // data.Append(" ");
            // data.FontItalic(false);
            // data.PROW(false, 53, data.PrintTopLeftCorner() + data.PrintHorizontalLine(2) + " Pengiriman kepada Toko " + data.PrintHorizontalLine(14) + data.PrintTopRightCorner());
            // data.PROW(true, 1, Catatan1.PadRight(47, ' '));
            // data.PROW(false, 51, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            // data.AddCR();
            // data.PROW(false, 55, nSpace);
            // data.PROW(true, 1, "NOMOR D.O : ");
            // data.FontBold(false);
            // data.FontItalic(true);
            // data.AddCR();
            // data.PROW(false, 13, DO);
            // data.FontItalic(false);
            // data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            // data.FontCondensed(true);
            // data.FontItalic(true);
            // data.AddCR();
            // data.PROW(false, 92, AlamatKirim);
            // data.FontItalic(false);
            // data.FontCondensed(false);
            // data.PROW(true, 1, "JK.WAKTU  : ");
            // data.FontBold(false);
            // data.FontItalic(true);
            // data.AddCR();
            // data.PROW(false,13, Waktu + Catatan3.PadRight(20,' '));
            // data.FontItalic(false);
            // data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            // data.FontItalic(true);
            // data.AddCR();
            // data.PROW(false,55, Daerah);
            // data.FontItalic(false);
            // data.PROW(true,1, "NOMOR RQ. : ");
            // data.FontBold(false);
            // data.FontItalic(true);
            // data.AddCR();
            // data.PROW(false, 13, NoRq);
            // data.FontItalic(false);
            // data.PROW(false, 53, data.PrintVerticalLine() + data.SPACE(40) + data.PrintVerticalLine());
            // data.FontItalic(true);
            // data.AddCR();
            // data.PROW(false, 55, Kota);
            // data.FontItalic(false);

            // data.PROW(true,1, "EXPEDISI  : ");
            // data.FontBold(false);
            // data.FontItalic(true);
            // if (!Expedisi.Equals("SAS"))
            // {
            //     data.PROW(false,13, Expedisi + " (" + NamaExpedisi + ")");
            // }
            // data.FontItalic(false);
            // data.PROW(false, 57, data.PrintVerticalLine() + data.SPACE(31) + "Grade:   " + data.PrintVerticalLine());
            // data.FontItalic(true);
            // data.AddCR();
            // data.PROW(false,55, "Plafon:" + plafon.ToString("#,###"));
            // data.FontItalic(false);
            // data.PROW(false, 91, Grade);
            // data.FontItalic(false);
            // data.PROW(true, 1, data.SPACE(50) + data.PrintBottomLeftCorner() + data.PrintHorizontalLine(40) + data.PrintBottomRightCorner());
            // data.LetterQuality(false);
            // data.FontCondensed(true);
            // data.PROW(true,1, "No. N a m a   B a r a n g                                                     RAK   Dipesan            Dikirim             H.Sat.  Disc./Pot. Jml.Net   Stok");
            // data.PROW(true, 1, data.PrintDoubleLine(157));
            // data.LineSpacing("1/6");
            // #endregion

            // #region Cetak Detail
            // int nUrut = 1;
            // string temp;
            // string KodeRak = "B109284";
            // int JumlahDO = 3;
            // string Satuan = "PCS";
            // string NamaStok = "WIPER BLADE 17\" 4 CLIP W/BLISTER TYPE \"A\"";
            // int nSisa = 30;
            // int nJumlah = 2000000;

            // string CheckLabel = nUrut % 2 == 1 ? printESC.STR(3, nUrut.ToString()) + ".[_______]             " : printESC.STR(16, nUrut.ToString()) + ".[_______]";
            // temp = printESC.STR(2, nUrut.ToString()) + ". " + NamaStok.Trim().PadRight(73, '.') + " " + KodeRak + " " + printESC.STR(5, JumlahDO.ToString()) + " " + Satuan + CheckLabel + printESC.SPACE(27) + nSisa.ToString("#,###");

            // int nUrut2 = 2;
            // string temp2;
            // string KodeRak2 = "C109233";
            // int JumlahDO2 = 5;
            // string NamaStok2 = "GAS TANK CAP L-300/FE-111                   CK";
            // int nSisa2 = 33;

            // string CheckLabel2 = nUrut2 % 2 == 1 ? printESC.STR(3, nUrut2.ToString()) + ".[_______]             " : printESC.STR(16, nUrut2.ToString()) + ".[_______]";
            // temp2 = printESC.STR(2, nUrut2.ToString()) + ". " + NamaStok2.Trim().PadRight(73, '.') + " " + KodeRak2 + " " + printESC.STR(5, JumlahDO2.ToString()) + " " + Satuan + CheckLabel2 + printESC.SPACE(27) + nSisa2.ToString("#,###");

            // data.PROW(true,1, temp);
            // data.PROW(true, 1, temp2);

            // for (int i = 3; i <= 18; i++)
            // {
            //     data.PROW(true, 1, printESC.STR(2, i.ToString()) + ". ");
            // }

            // data.PROW(true, 1, data.PrintDoubleLine(157));
             
            // data.PROW(true,1,"A/R-SAS : " + SecurityManager.UserID + ", Tgl." + DateTime.Now);
            // data.DoubleWidth(true);
            // data.FontItalic(true);
            // data.AddCR();
            // data.PROW(false,43, "Total D.O ");
            // data.PROW(false,59, "Rp." + nJumlah.ToString("#,###"));
            // data.DoubleWidth(false);
            // data.FontItalic(false);
            // data.PROW(true, 1, "");
            // data.PROW(true, 1, " ");
            // data.Append("  (     Bag. Piutang     )          (     Bag. Penjualan     )          (     Bag. Gudang     )        (    Bag. Cheker I    )        (   Bag. Cheker II   )");
            // data.Eject();
            // #endregion

            // // Write the string to a file.
            // //System.IO.StreamWriter file = new System.IO.StreamWriter("D:\\test.txt");
            // //file.WriteLine(data.GenerateString());

            // //file.Close();
            // File.WriteAllBytes("C:\\test.txt", data.GetBytes());

            // string printerName = "\\\\apw-new\\Epson LQ-2180 ESC/P 2";
            // //string PrintText = txtPrint1.Text;
            // //string PrintText = "C:\\Temp\\ESC2.TXT";
            // RawPrinterHelper.SendFileToPrinter(printerName, "C:\\test.txt");

            // MessageBox.Show("Printed");
         }

         private void button13_Click(object sender, EventArgs e)
         {
             //string data = " ";
             //textBox3.Text = data.Insert(1, "kangguru");
             
             BuildString data = new BuildString();
             data.Append(data.PrintDoubleLine(23));

             string temp = "ÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ";

             byte[] tes = new byte[temp.Length];

             for (int i = 0; i < temp.Length; i++)
             {
                 tes[i] = Convert.ToByte(temp[i]);
             }
            // byte[] tes = { 205, 205, 205, 205 };

             
             //System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\test.txt", false, Encoding.UTF8);
             //file.WriteLine(Convert.ToBase64String(tes));
             //file.Close();

             File.WriteAllBytes("C:\\test.txt",tes);
             //File.WriteAllBytes("C:\\test.txt", Encoding.UTF8.GetBytes(data.GenerateString()));
             MessageBox.Show("Printed");
         }

         private void button14_Click(object sender, EventArgs e)
         {
             using (Database db = new Database(),  dbc = new Database())
             {
                 db.Close();
             }
         }

         private void btnali_Click(object sender, EventArgs e)
         {
             string aa = string.Empty;
             txtPrint1.Text = string.Empty;
              //CHR(ASCAN(aGudang,cInitGdg)+64)+CHR(MONTH(DATE())+64)+CHR(VAL(SUBSTR(DTOS(DATE()),4,1))+65)
             string aAbjad = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
             List<string> gudang = new List<string>();
             gudang.Add("0101");
             gudang.Add("0201");
             gudang.Add("0501");
             gudang.Add("0801");
             gudang.Add("0901");
             gudang.Add("0902");
             gudang.Add("0903");
             gudang.Add("1801");
             gudang.Add("1802");
             gudang.Add("1901");
             gudang.Add("1902");
             gudang.Add("2001");
             gudang.Add("2101");
             gudang.Add("2201");

             int i = 0;
             foreach (string hh in gudang)
             {
                 if (hh == txtali.Text)
                 {
                     break;
                 }
                 i++;
             }
             string kodeNota = "NOMOR_NOTA_TAX";
           DataTable  dtNum = Tools.GetGeneralNumerator(kodeNota, Tools.GeneralInitial());
          int   lebarOriginal = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
        int     lebar = lebarOriginal - 3;
          int   iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());

          string   belakang = dtNum.Rows[0]["Belakang"].ToString();
             iNomor++;
             string depan = Tools.GeneralInitial();
         string    nomorNota = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
             //string a = i >0 ? Convert.ToString((char)(i+1+64)) : "@";
             //string b = Convert.ToString((char)(DateTime.Now.Month+64));
             //string c = Convert.ToString((char)(  Convert.ToInt32(DateTime.Now.Year.ToString().Substring(3,1)) + 65));
             txtPrint1.Text = nomorNota ;
         }
    }
}
    

