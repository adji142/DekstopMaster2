using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using ISA.Controls;

namespace ISA.Pin
{
   
    public partial class frmPin : Form
    {
        string pin;
        public frmPin()
        {
            InitializeComponent();
        }

        public void commandButton1_Click(object sender, EventArgs e)
        {
            string cabang = "9999";
            string kodeCabang = "99";
            if (comboBox1.SelectedItem != null)
            {
                cabang = comboBox1.SelectedItem.ToString();
                kodeCabang = cabang.Substring(cabang.Length - 2);
            }
            
            if (txtId.Text == "1")
            {
                txtPin.Text = key.CreateDailyPin(DateTime.Today, cabang, key.BaseCode.Rekon, key.BaseCodeMultiplier.Rekon);
            }
            else if (txtId.Text == "3")
            {
                //string pinCI;
                //pinCI = createPINPSReportCi(DateTime.Today, cabang);
                //txtPin.Text = pinCI;
                txtPin.Text = key.CreateDailyPin(DateTime.Today, cabang, key.BaseCode.PSReportCI, key.BaseCodeMultiplier.PSReportCI);
            }
            else if (txtId.Text == "4" )
            {
                //string pinCI;
                //pinCI = createPINPSReportKun(DateTime.Today, cabang);
                //txtPin.Text = pinCI;
                txtPin.Text = key.CreateDailyPin(DateTime.Today, cabang, key.BaseCode.PSReportKS, key.BaseCodeMultiplier.PSReportKS);
            }

            else if (txtId.Text == "13")
            {
                txtPin.Text = key.CreateDailyPin(DateTime.Today, cabang, key.BaseCode.PO, key.BaseCodeMultiplier.PO);
            }


            else if (txtId.Text == "14")
            {
                txtPin.Text = key.CreateDailyPin(DateTime.Today, cabang, key.BaseCode.RekonsPJT, key.BaseCodeMultiplier.RekonsPJT);
            }

            else if (txtId.Text == "11")
            {
                txtPin.Text = key.CreateDailyPin(DateTime.Today, cabang, key.BaseCode.CetakRegister, key.BaseCodeMultiplier.CetakRegister);
            }

            else if (txtId.Text == "9")
            {
                txtPin.Text = key.CreateDailyPin(DateTime.Today, cabang, key.BaseCode.ClosingRegister, key.BaseCodeMultiplier.ClosingRegister);
            }

            else if (txtId.Text == "15")
            {
                txtPin.Text = key.CreateDailyPin(DateTime.Today, cabang, key.BaseCode.FilterBySales, key.BaseCodeMultiplier.FilterBySales);
            }

            else if (txtId.Text == "16")
            {
                txtPin.Text = key.CreateDailyPin(DateTime.Today, cabang, key.BaseCode.CetakRegisterSPV, key.BaseCodeMultiplier.CetakRegisterSPV);
            }
            else if (txtId.Text == "17")
            {
                txtPin.Text = key.CreateDailyPin(DateTime.Today, cabang, key.BaseCode.CetakRegisterSupport, key.BaseCodeMultiplier.CetakRegisterSupport);
            }
            else if (txtId.Text == "18")
            {
                txtPin.Text = key.CreateDailyPin(DateTime.Today, cabang, key.BaseCode.CetakRegisterPKP, key.BaseCodeMultiplier.CetakRegisterPKP);
            }

            else if (txtId.Text == "19")
            {
                txtPin.Text = key.CreateDailyPin(DateTime.Today, cabang, key.BaseCode.OASPV, key.BaseCodeMultiplier.OASPV);
            }

            else if (txtId.Text == "20")
            {
                txtPin.Text = key.CreateDailyPin(DateTime.Today, cabang, key.BaseCode.OASupport, key.BaseCodeMultiplier.OAYYK);
            }

            else if (txtId.Text == "2" || txtId.Text == "5" || txtId.Text == "6" || txtId.Text == "7" || txtId.Text == "8" || txtId.Text == "12" || txtId.Text == "22")
            {
                if (txtKey.Text.ToString() == string.Empty)
                {
                    MessageBox.Show("Key harus diisi");
                    return;
                }

                if (txtKey.Text.ToString().Length < 4)
                {
                    MessageBox.Show("Key yang anda masukan salah");
                    return;
                }

                if (txtKey.Text.ToString().Substring(0, 2) != kodeCabang ||
                    txtKey.Text.ToString().Substring(2, 2) != txtId.Text.PadLeft(2, '0'))
                {
                    MessageBox.Show("Key yang anda masukan salah");
                    return;
                }

                MD5 md5Hash = MD5.Create();
                string pin = key.GetMd5Hash(md5Hash, txtKey.Text);
                txtPin.Text = pin;
            }
            else
            {
                if (txtKey.Text.ToString().Length != 7)
                {
                    MessageBox.Show("Key Harus 7 digit");
                    return;
                }

                if (txtKet.Text.Trim() == "")
                {
                    MessageBox.Show("keterangan masih kosong");
                    return;
                }

                if (txtKey.Text.ToString().Substring(0, 2) != kodeCabang)
                {
                    MessageBox.Show("Key yang anda masukan salah");
                    return;
                }

                pin = key.proses(txtKey.Text, Convert.ToInt32(txtId.Text), kodeCabang);
                txtPin.Text = pin;
            }

        }

        private void frmPin_Load(object sender, EventArgs e)
        {
            txtKey.Focus();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            if (txtId.Text == "1" || txtId.Text == "3" || txtId.Text == "4")
            {
                label1.Visible = false;
                txtKey.Visible = false;
                label5.Text = "PIN berlaku satu hari";
            }
            else if (txtId.Text == "2" || txtId.Text == "5" || txtId.Text == "6" || txtId.Text == "7" || txtId.Text == "8" || txtId.Text == "12" || txtId.Text == "22")
            {
                label1.Visible = true;
                txtKey.Visible = true;
                label5.Text = "Tidak ada pembatasan masa berlaku PIN";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKey.Text = "";
            txtKet.Text = "";
            txtPin.Text = "";
           // MessageBox.Show(comboBox1.SelectedItem.ToString());

        }

        private void txtId_Click(object sender, EventArgs e)
        {

        }

        private void txtPin_TextChanged(object sender, EventArgs e)
        {

        }

        //public static string createPINPSReportCi(DateTime tglPSReport, String kodegudang)
        //{

        //    string cKode = "ZYXWVUTS09876RQPONMLK54321JIHGFEDCBA";        //'RUMAHPEYOT'
        //    string cCode = "ZYXW09VUTS87RQPO65NMLK43JIHG21FEDCBA";

        //    string cGud = kodegudang;
        //    //string cDate = tglPSReport.ToShortDateString();

        //    string cDate = String.Format("{0:MM/dd/yyyy}", tglPSReport);


        //    string cThn = cDate.Substring(6, 4);
        //    string cBln = cDate.Substring(0, 2);
        //    string cTgl = cDate.Substring(3, 2);
        //    //thisform.pin.Value = ckey


        //    //----- PIN CUSTOMER INTI -----*

        //    Double nKodeCi = 0;
        //    nKodeCi = Convert.ToDouble(cThn) * Convert.ToDouble(cBln) * Convert.ToDouble(cTgl) * Convert.ToDouble(cGud) * 16;
        //    string xKodeCi = nKodeCi.ToString();
        //    int nSpkCi = 0;
        //    string SandiCi = "";
        //    if (xKodeCi.Length >= 7)
        //    {

        //        SandiCi = xKodeCi.Substring(xKodeCi.Length - 7, 7);
        //    }
        //    else
        //    {
        //        nSpkCi = 7 - xKodeCi.Length;
        //        SandiCi = xKodeCi.PadLeft(nSpkCi, '0');
        //    }

        //    string cKeyCi = "";
        //    //string cJlt  = "";
        //    int aCi = 0;
        //    int x = 0;
        //    for (int iCi = 1; iCi <= 7; iCi++)
        //    {

        //        if (SandiCi.Substring(iCi - 1, 1) == "0")
        //        {
        //            aCi = 0;
        //        }
        //        else
        //        {
        //            aCi = Convert.ToInt32(SandiCi.Substring(iCi - 1, 1));
        //        }
        //        if (aCi == 0)
        //        {
        //            x = iCi;
        //        }
        //        else if ((iCi * aCi) % (36) == 0)
        //        {
        //            x = iCi;
        //        }

        //        else
        //        {
        //            x = (iCi * aCi) % (36);
        //        }

        //        cKeyCi = cKeyCi + cCode.Substring(x - 1, 1);

        //    }


        //    //thisform.pinci.Value = ckeyci
        //    return cKeyCi;
        //}

        //public static string createPINPSReportKun(DateTime tglPSReport, String kodegudang)
        //{

        //    string cKode = "ZYXWVUTS09876RQPONMLK54321JIHGFEDCBA";        //'RUMAHPEYOT'
        //    string cCode = "ZYXW09VUTS87RQPO65NMLK43JIHG21FEDCBA";

        //    string cGud = kodegudang;
        //    string cDate = String.Format("{0:MM/dd/yyyy}", tglPSReport);


        //    string cThn = cDate.Substring(6, 4);
        //    string cBln = cDate.Substring(0, 2);
        //    string cTgl = cDate.Substring(3, 2);

        //    //----- PIN KUNJUNGAN-----*
        //    Double nKode = 0;
        //    nKode = Convert.ToDouble(cThn) * Convert.ToDouble(cBln) * Convert.ToDouble(cTgl) * Convert.ToDouble(cGud);
        //    string xKode = nKode.ToString();
        //    int nSpk = 0;
        //    string Sandi = "";
        //    if (xKode.Length >= 7)
        //    {

        //        Sandi = xKode.Substring(xKode.Length - 7, 7);
        //    }
        //    else
        //    {
        //        nSpk = 7 - xKode.Length;
        //        Sandi = xKode.PadLeft(nSpk, '0');
        //    }

        //    string cKey = "";
        //    string cJlt = "";
        //    int a = 0;
        //    int x = 0;
        //    for (int i = 1; i <= 7; i++)
        //    {

        //        if (Sandi.Substring(i - 1, 1) == "0")
        //        {
        //            a = 0;
        //        }
        //        else
        //        {
        //            a = Convert.ToInt32(Sandi.Substring(i - 1, 1));
        //        }

        //        if (a == 0)
        //        {
        //            x = i;
        //        }
        //        else if ((i * a) % (36) == 0)
        //        {
        //            x = i;
        //        }

        //        else
        //        {
        //            x = (i * a) % (36);
        //        }

        //        cKey = cKey + cKode.Substring(x - 1, 1);

        //    }
        //    return cKey;
        //}
    }
}
