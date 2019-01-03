using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ISA.DAL;
using System.IO;
using System.Drawing.Printing;
using ISA.Common;
using ISA.Trading.Class;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data.SqlTypes;
using Microsoft.Reporting.WinForms;

using System.Linq;
using System.Collections;
using ISA.Controls;
using System.Globalization;

namespace ISA.Trading.VWil
{
    public partial class coba : ISA.Controls.BaseForm
    {
        public coba()
        {
            InitializeComponent();
        }

        private void coba_Load(object sender, EventArgs e)
        {

        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            PrintOutDotMatrix();
        }

        private void PrintOutDotMatrix()
        {
            BuildString data = new BuildString();

            data.Initialize();
            data.PageLLine(33);
            data.LeftMargin(1);
            data.BottomMargin(1);

            data.LetterQuality(false);
            data.FontBold(true);
            data.FontCondensed(true);
            data.DoubleHeight(true);

            data.PROW(true, 1, "");

            data.DoubleWidth(true);
            data.DoubleHeight(true);
            data.FontCPI(12);
            data.LineSpacing("1/8");
            //data.PROW(false, 2, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)12));
            data.PROW(true, 1, "Register Tagihan");
            data.DoubleWidth(false);
            data.DoubleHeight(false);

            /*                  12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890*/
            /*                           1         2         3         4         5         6         7         8         9         10        11        12        13        14*/
            data.FontCondensed(true);
            data.PROW(true, 1, "    Customer                                    Part Number             Q t y    Harga Sat     Disc(%)   Pot          Jumlah Harga");
            data.PROW(true, 1, data.PrintDoubleLine(134));

            //foreach (DataRow dr in dt.Rows)
            //{
            string _customer1 = "YATIK", _customer2 = "RAYZA LUTHFI", _customer3 = "RAFA ANADA RADITIYA AHMAD";
                int panjanghuruf = _customer1.Length;
                if (panjanghuruf >= 25)
                {
                    _customer1 = _customer1.Substring(0, 30);
                }
                int panjanghuruf2 = _customer1.Length;
                if (panjanghuruf2 >= 25)
                {
                    _customer2 = _customer2.Substring(0, 30);
                }
                string sTemp = "";
                sTemp = sTemp + _customer1.PadRight(25, ' ') + " | ";
                data.PROW(true, 1, sTemp);

                sTemp = "";
                sTemp = sTemp + _customer2.PadRight(25, ' ') + " | ";
                data.PROW(true, 1, sTemp);

                sTemp = "";
                sTemp = sTemp + _customer3.PadRight(25, ' ') + " | ";
                data.PROW(true, 1, sTemp);

                //}



            data.Eject();
            data.SendToPrinter("Register_Tagihan.txt");

            //data.SendToTxt("Register_Tagihan.txt", data.GenerateString());
            //detail.SendToPrinter("Register_Tagihan.txt");   //, detail.GenerateString());

            MessageBox.Show("Proses Cetak Selesai..");
        }

    }
}
