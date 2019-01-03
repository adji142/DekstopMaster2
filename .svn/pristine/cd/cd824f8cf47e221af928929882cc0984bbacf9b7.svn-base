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
using ISA.Trading.Class;
using System.IO;

namespace ISA.Trading.XPDC
{
    public partial class frmCetakPackingList : ISA.Trading.BaseForm
    {
        string _kodeToko, _expedisi;
   
        DateTime _tgl0 ;
        DateTime _tgl;
        Guid _RowID = Guid.Empty;
        public frmCetakPackingList(Form caller, string kodeToko, string expedisi, DateTime tgl)
        {
            InitializeComponent();
            _kodeToko = kodeToko;
            _tgl = tgl;
            _expedisi = expedisi;
            this.Caller = caller;
        }

        public frmCetakPackingList(Form caller, string kodeToko, string expedisi, DateTime tgl, Guid RowID_)
        {
            InitializeComponent();
            _kodeToko = kodeToko;
            _tgl = tgl;
            _expedisi = expedisi;
            _RowID = RowID_;
            this.Caller = caller;
        }

        public frmCetakPackingList(Form caller, string kodeToko, string expedisi, DateTime tgl0, DateTime tgl, Guid RowID_)
        {
            InitializeComponent();
            _kodeToko = kodeToko;
            _tgl = tgl;
            _tgl0 = tgl0;
            _expedisi = expedisi;
            _RowID = RowID_;
            this.Caller = caller;
        }

        private void frmCetakPackingList_Load(object sender, EventArgs e)
        {
            rdbShift1.Checked = true;
            rdbAuto.Checked = true;
            rdbKredit.Checked = true;
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            string bayar, shift;
            if (rdbShift1.Checked == true)
                shift = "1";
            else
                shift = "2";

            if (rdbKredit.Checked == true)
                bayar = "K";
            else
                bayar = "T";


           
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_CetakPackingList"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                    db.Commands[0].Parameters.Add(new Parameter("@expedisi", SqlDbType.VarChar, _expedisi));
                    //db.Commands[0].Parameters.Add(new Parameter("@date", SqlDbType.DateTime, _tgl));
                    db.Commands[0].Parameters.Add(new Parameter("@date", SqlDbType.DateTime, _tgl));
                    db.Commands[0].Parameters.Add(new Parameter("@date0", SqlDbType.DateTime, _tgl0));
                    //db.Commands[0].Parameters.Add(new Parameter("@bayar", SqlDbType.VarChar, bayar));
                    //db.Commands[0].Parameters.Add(new Parameter("@shift", SqlDbType.VarChar, shift));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    CetakPackingList(dt);
                }
                else
                {
                    MessageBox.Show("Tidak ada data packing list");
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

        private void CetakPackingList(DataTable dt)
        {
            BuildString data = new BuildString();
            data.Initialize();

            data.PageLLine(11);
            data.FontCPI(15);
            data.DoubleHeight(true);
            data.DoubleWidth(true);
            data.PROW(true, 1, "");
            data.PROW(true, 1, "PACKING LIST");
            data.PROW(true, 1, "");
            data.DoubleHeight(false);
            data.DoubleWidth(false);
            data.LetterQuality(true);
            data.FontCPI(10);
            data.PROW(true, 1, "Tanggal  : " + ((DateTime)dt.Rows[0]["tglSuratJalan"]).ToString("dd-MMM-yyyy"));
            data.AddCR();
            data.PROW(false, 51, "Dikirim Ke : " + dt.Rows[0]["NamaToko"].ToString().PadRight(31));
            data.PROW(true, 1, "Expedisi : " + dt.Rows[0]["Expedisi"]);
            data.AddCR();
            data.PROW(false, 51, "Alamat     : " + dt.Rows[0]["Kota"].ToString().PadRight(20));
            data.FontCondensed(true);
            data.PROW(true, 1, data.PrintTopLeftCorner() + data.PrintHorizontalLine(139) + data.PrintTopRightCorner());
            data.PROW(true, 1, data.PrintVerticalLine() + "No." + data.PrintVerticalLine() + " NOTA  "
                + data.PrintVerticalLine() + "                       N A M A   B A R A N G                             "
                + data.PrintVerticalLine() + "  QUANTITY  " + data.PrintVerticalLine() + "    NOMOR KOLI     "
                + data.PrintVerticalLine() + "     KETERANGAN     " + data.PrintVerticalLine());
            data.PROW(true, 1, data.PrintBottomLeftCorner() + data.PrintHorizontalLine(139) + data.PrintBottomRightCorner());

            int nUrut = 0;
            string sNoNota, sNamaBrg, sNokoli, sKet, sSatuan;
            int nQty, nSumJmlkoli = 0;

            foreach (DataRow dr in dt.Rows)
            {
                sNoNota = dr["NoSuratJalan"].ToString().Trim();
                sNamaBrg = dr["NamaBarang"].ToString().Trim();
                sNokoli = dr["NoKoli"].ToString().Trim();
                sSatuan = dr["Satuan"].ToString().Trim();
                sKet = dr["KetKoli"].ToString().Trim();
                nQty = int.Parse(dr["QtySuratjalan"].ToString());
                nSumJmlkoli = nSumJmlkoli + int.Parse(dr["JmlKoli"].ToString());
                nUrut++;

                if (rdbAuto.Checked)
                {
                    data.PROW(true, 1, data.PrintVerticalLine() + nUrut.ToString().PadLeft(3)
                        + data.PrintVerticalLine() + sNoNota
                        + data.PrintVerticalLine() + sNamaBrg.PadRight(73, '.')
                        + data.PrintVerticalLine() + nQty.ToString().PadLeft(7) + " " + sSatuan.PadRight(4)
                        + data.PrintVerticalLine() + "  " + sNokoli.PadRight(17)
                        + data.PrintVerticalLine() + sKet.PadRight(20) + data.PrintVerticalLine());
                }
                if (rdbManual.Checked)
                {
                    data.PROW(true, 1, data.PrintVerticalLine() + nUrut.ToString().PadLeft(3)
                       + data.PrintVerticalLine() + sNoNota
                       + data.PrintVerticalLine() + sNamaBrg.PadRight(73, '.')
                       + data.PrintVerticalLine() + nQty.ToString().PadLeft(7) + " " + sSatuan.PadRight(4)
                       + data.PrintVerticalLine() + "_______" + "_____" + "_______"
                       + data.PrintVerticalLine() + "____________________" + data.PrintVerticalLine());
                }
            }

            data.PROW(true, 1, data.PrintBottomLeftCorner() + data.PrintHorizontalLine(139) + data.PrintBottomRightCorner());
            data.PROW(true, 1, "Jumlah : "
                + (rdbAuto.Checked ? nSumJmlkoli.ToString("#,###").PadLeft(10) : "_______")
                + " Koli");

            if (txtKeterangan.Text.Trim() != "" && rdbAuto.Checked)
            {
                data.PROW(true, 1, "");
                data.PROW(true, 1, "Keterangan :");
                data.PROW(true, 1, txtKeterangan.Text);
            }

            data.PROW(true, 1, "");
            data.PROW(true, 1, "         Dibuat Oleh :                                                                        Diterima Oleh :      ");
            data.PROW(true, 1, "");
            data.PROW(true, 1, "");
            data.PROW(true, 1, "");
            data.PROW(true, 1, data.SPACE(8) + data.PrintHorizontalLine(15) + data.SPACE(71) + data.PrintHorizontalLine(15) + data.SPACE(6));
            data.PROW(true, 1, "            Checker                                                                                                ");
            data.PROW(true, 1, "");
            data.PROW(true, 1, " Barang-barang tersebut di atas telah diperiksa & diterima dalam keadaan baik & lengkap");
            data.PROW(true, 1, " Komplain mengenai barang tersebut di atas diterima paling lambat 1 minggu setelah barang diterima.");
            data.Eject();

            data.SendToFile("packingList.txt");
            //data.SendToPrinter("packingList.txt");
        }

        private void DisplayReport(DataTable dt)
        {
            string mode = "1";
            if (rdbManual.Checked == true)
                mode = "2";
            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Keterangan", txtKeterangan.Text.Trim()));
            rptParams.Add(new ReportParameter("Mode", mode));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Expedisi.rptCetakPackingList.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();
        }

        private void rdbAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAuto.Checked == true)
            {
                txtKeterangan.Enabled = true;
            }
        }

        private void rdbManual_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbManual.Enabled == true)
            {
                txtKeterangan.Enabled = false;

            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
