using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;
using ISA.Toko.Class;
using Microsoft.VisualBasic;


namespace ISA.Toko.Penjualan
{
    public partial class frmFTagihBrowser : ISA.Toko.BaseForm
    {
        DataTable dtTagihan;
        public frmFTagihBrowser()
        {
            InitializeComponent();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_RencanaTagihan")); //HR, 18032013
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeTagihan.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeTagihan.ToDate));
                    dtTagihan = db.Commands[0].ExecuteDataTable();

                    gvTagih.DataSource = dtTagihan;
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

        private void frmFTagihBrowser_Load(object sender, EventArgs e)
        {
            rangeTagihan.FromDate = DateTime.Today;
            rangeTagihan.ToDate = DateTime.Today;
        }

        private void commandButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            if (gvTagih.RowCount > 0)
            {
                int nMulai = 0;
                string noMulai = Interaction.InputBox("Mulai No:", "Cetak", "0", 100, 100);

                if (!string.IsNullOrEmpty(noMulai))
                {
                    if (int.TryParse(noMulai, out nMulai))
                    {
                        GetCetakData(nMulai);
                    }
                    else
                    {
                        MessageBox.Show("Mulai no yang diinput salah");
                        commandButton2.PerformClick();
                    }
                }
            }
            else
            {
                MessageBox.Show("Tidak ada data untuk diprint");
            }
        }

        private void GetCetakData(int nMulai)
        {
            DataTable dtCetak = new DataTable();
            string KodeToko = gvTagih.SelectedCells[0].OwningRow.Cells["gvKodeToko"].Value.ToString();
            dtCetak = dtTagihan.DefaultView.ToTable().Copy();
            dtCetak.DefaultView.RowFilter = "KodeToko='" + KodeToko + "'";
            try
            {
                this.Cursor = Cursors.WaitCursor;
                #region ijo2
                //using (Database db = new Database())
                //{
                //    db.Commands.Add(db.CreateCommand("rsp_RencanaTagihan"));
                //    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeTagihan.FromDate));
                //    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeTagihan.ToDate));
                //    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, KodeToko));
                //    dtCetak = db.Commands[0].ExecuteDataTable();

                //    if (nMulai > 0)
                //    {
                //        CetakTagih2(dtCetak, nMulai);
                //    }
                //    else
                //    {
                //        CetakTagih1(dtCetak);
                //    }
                //}
                #endregion
                if (dtCetak.DefaultView.Count > 0)
                {
                    if (nMulai > 0)
                    {
                        CetakTagih2(dtCetak.DefaultView.ToTable(), nMulai);
                    }
                    else
                    {
                        CetakTagih1(dtCetak.DefaultView.ToTable());
                    }
                }
                else
                {
                    MessageBox.Show("Tidak ada data yang dicetak");
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

        private string CetakHeader(string NamaToko, string Alamat, string Daerah)
        {
            BuildString PrintHeader = new BuildString();

            PrintHeader.FontCondensed(true);
            PrintHeader.PageLLine(33);
            PrintHeader.PROW(true, 1, "ÕÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ¸");
            PrintHeader.PROW(true, 1, "³TOKO    : " + NamaToko + PrintHeader.SPACE(82 - NamaToko.Length) + "³");
            PrintHeader.PROW(true, 1, "³ALAMAT  : " + Alamat + PrintHeader.SPACE(82 - Alamat.Length) + "³");
            PrintHeader.PROW(true, 1, "³DAERAH  : " + Daerah + PrintHeader.SPACE(82 - Daerah.Length) + "³");
            PrintHeader.PROW(true, 1, "ÃÄÄÂÄÄÄÄÄÄÄÄÄÄÄÂÄÄÄÄÄÄÄÂÄÄÄÂÄÄÄÄÄÄÄÄÄÄÄÄÂÄÄÂÄÄÄÄÄÄÄÄÄÄÄÂÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄ´");
            PrintHeader.PROW(true, 1, "³  ³           ³       ³KD ³            ³  ³           ³             PEMBAYARAN              ³");
            PrintHeader.PROW(true, 1, "³NO³TGL.TERIMA ³NO.NOTA³BRG³   SALES    ³JW³TGL.J.TEMPOÃÄÄÄÄÄÄÄÄÄÄÄÄÄÂÄÄÄÄÄÄÄÄÄÄÄÂÄÄÄÄÄÄÄÄÄÄÄ´");
            PrintHeader.PROW(true, 1, "³  ³           ³       ³   ³            ³  ³           ³    NILAI    ³  TITIPAN  ³   SALDO   ³");
            PrintHeader.PROW(true, 1, "ÃÄÄÅÄÄÄÄÄÄÄÄÄÄÄÅÄÄÄÄÄÄÄÅÄÄÄÅÄÄÄÄÄÄÄÄÄÄÄÄÅÄÄÅÄÄÄÄÄÄÄÄÄÄÄÅÄÄÄÄÄÄÄÄÄÄÄÄÄÅÄÄÄÄÄÄÄÄÄÄÄÅÄÄÄÄÄÄÄÄÄÄÄ´");

            return PrintHeader.GenerateString();

        }

        private void CetakTagih1(DataTable dtCetak)
        {
            BuildString PrintTagih = new BuildString();

            string NamaToko = dtCetak.Rows[0]["NamaToko"].ToString();
            string Alamat = dtCetak.Rows[0]["AlamatKirim"].ToString();
            string Kota = dtCetak.Rows[0]["Kota"].ToString();
            string Daerah = dtCetak.Rows[0]["Daerah"].ToString();
            string Propinsi = dtCetak.Rows[0]["Propinsi"].ToString();
            string WilID = dtCetak.Rows[0]["WilID"].ToString();
            string InfoTagih = dtCetak.Rows[0]["RefCollector"].ToString();
            string Telp = dtCetak.Rows[0]["Telp"].ToString();

            Alamat += ", " + Kota;
            Daerah = (string.IsNullOrEmpty(Daerah) == true ? string.Empty : Daerah + ", ") +
                     (string.IsNullOrEmpty(Propinsi) == true ? string.Empty : Propinsi + "  ") +
                     (string.IsNullOrEmpty(WilID) == true ? string.Empty : "(" + WilID + ")");
            NamaToko += string.IsNullOrEmpty(Telp) == true ? string.Empty : "  ==>  TELPON : " + Telp;

            PrintTagih.FontCondensed(true);
            PrintTagih.PageLLine(33);
            PrintTagih.Append(CetakHeader(NamaToko, Alamat, Daerah));

            int ctr = 1;
            double Total = 0;
            string NoNota = string.Empty;
            string IdTr = string.Empty;
            string KodeSales = string.Empty;
            string HariKredit = string.Empty;
            DateTime TglTerima;
            DateTime TglJT;
            double RpNet3 = 0;

            foreach (DataRowView dr in dtCetak.DefaultView)
            {
                NoNota = dr["NoNota"].ToString();
                IdTr = dr["TransactionType"].ToString();
                TglTerima = DateTime.Parse(dr["TglTerima"].ToString());
                KodeSales = dr["KodeSales"].ToString();
                HariKredit = dr["HariKredit"].ToString();
                TglJT = DateTime.Parse(dr["TglJT"].ToString());
                RpNet3 = double.Parse(dr["RpNet3"].ToString());
                Total += RpNet3;

                PrintTagih.PROW(true, 1, "³" + ctr.ToString().PadLeft(2) +
                          "³ " + TglTerima.ToString("dd-MM-yyyy") +
                          "³" + NoNota +
                          "³" + IdTr +
                          " ³" + KodeSales.PadRight(11) +
                          " ³" + HariKredit.PadLeft(2) +
                          "³ " + TglJT.ToString("dd-MM-yyyy") +
                          "³" + RpNet3.ToString("#,##0").PadLeft(13) +
                          "³           ³           ³");

                if (ctr == 12)
                {
                    PrintTagih.PROW(true, 1, "ÔÍÍÏÍÍÍÍÍÍÍÍÍÍÍÏÍÍÍÍÍÍÍÏÍÍÍÏÍÍÍÍÍÍÍÍÍÍÍÍÏÍÍÏÍÍÍÍÍÍÍÍÍÍÍÏÍÍÍÍÍÍÍÍÍÍÍÍÍÏÍÍÍÍÍÍÍÍÍÍÍÏÍÍÍÍÍÍÍÍÍÍÍ¾");
                    PrintTagih.PROW(true, 1, "                                             Jumlah     " + Total.ToString("#,##0").PadLeft(13));
                    PrintTagih.Eject();
                    ctr = 0;
                    Total = 0;
                    PrintTagih.Append(CetakHeader(NamaToko, Alamat, Daerah));
                }

                ctr++;
            }
            
            int n = 12 - ctr;
            
            for (int i = 1; i <= n + 1; i++)
            {
                PrintTagih.PROW(true, 1, "³" + ctr.ToString().PadLeft(2) + "³" + "           ³       ³   ³            ³  ³           ³             ³           ³           ³");
                ctr++;
            }
            PrintTagih.PROW(true, 1, "ÔÍÍÏÍÍÍÍÍÍÍÍÍÍÍÏÍÍÍÍÍÍÍÏÍÍÍÏÍÍÍÍÍÍÍÍÍÍÍÍÏÍÍÏÍÍÍÍÍÍÍÍÍÍÍÏÍÍÍÍÍÍÍÍÍÍÍÍÍÏÍÍÍÍÍÍÍÍÍÍÍÏÍÍÍÍÍÍÍÍÍÍÍ¾");
            PrintTagih.PROW(true, 1, "                                             Jumlah     " + Total.ToString("#,##0").PadLeft(13));
            PrintTagih.PROW(true, 1, "Info Tagih : " + InfoTagih);
            PrintTagih.FontCondensed(false);
            PrintTagih.Eject();

            PrintTagih.SendToPrinter("RencanaTagihan.txt");
        }

        private void CetakTagih2(DataTable dtCetak, int nMulai)
        {
            BuildString PrintTagih = new BuildString();

            string NamaToko = dtCetak.Rows[0]["NamaToko"].ToString();
            string Alamat = dtCetak.Rows[0]["AlamatKirim"].ToString();
            string Kota = dtCetak.Rows[0]["Kota"].ToString();
            string Daerah = dtCetak.Rows[0]["Daerah"].ToString();
            string Propinsi = dtCetak.Rows[0]["Propinsi"].ToString();
            string WilID = dtCetak.Rows[0]["WilID"].ToString();
            string InfoTagih = dtCetak.Rows[0]["RefCollector"].ToString();
            string Telp = dtCetak.Rows[0]["Telp"].ToString();
            int nn = nMulai;
            int nRec = dtCetak.Rows.Count;

            Alamat += ", " + Kota;
            Daerah = (string.IsNullOrEmpty(Daerah) == true ? string.Empty : Daerah + ", ") +
                     (string.IsNullOrEmpty(Propinsi) == true ? string.Empty : Propinsi + "  ") +
                     (string.IsNullOrEmpty(WilID) == true ? string.Empty : "(" + WilID + ")");
            NamaToko += string.IsNullOrEmpty(Telp) == true ? string.Empty : "  ==>  TELPON : " + Telp;

            PrintTagih.FontCondensed(true);
            PrintTagih.PageLLine(33);

            for (int i = 1; i <= 9 + (nn-1); i++)
            {
                PrintTagih.PROW(true, 1, "");
            }
 
            int ctr = 1;
            double Total = 0;
            string NoNota = string.Empty;
            string IdTr = string.Empty;
            string KodeSales = string.Empty;
            string HariKredit = string.Empty;
            DateTime TglTerima;
            DateTime TglJT;
            double RpNet3 = 0;
            

            foreach (DataRowView dr in dtCetak.DefaultView)
            {
                NoNota = dr["NoNota"].ToString();
                IdTr = dr["TransactionType"].ToString();
                TglTerima = DateTime.Parse(dr["TglTerima"].ToString());
                KodeSales = dr["KodeSales"].ToString();
                HariKredit = dr["HariKredit"].ToString();
                TglJT = DateTime.Parse(dr["TglJT"].ToString());
                RpNet3 = double.Parse(dr["RpNet3"].ToString());

                if (nn >= nMulai)
                {
                    PrintTagih.PROW(true, 1, "  " +
                                   "   " + TglTerima.ToString("dd-MM-yyyy") +
                                   " " + NoNota +
                                   " " + IdTr +
                                   "  " + KodeSales +
                                   "  " + HariKredit.PadLeft(2) +
                                   "  " + TglJT.ToString("dd-MM-yyyy") +
                                   " " + RpNet3.ToString("#,##0").PadLeft(13) +
                                   "                         ");
                }

                if (nn == 12)
                {
                    PrintTagih.Eject();
                    break;
                }
                nn++;
            }

            //int ii = 1;
            ctr = 1;
            Total = 0;

            if (nRec > 12)
            {
                PrintTagih.Append(CetakHeader(NamaToko, Alamat, Daerah));
                foreach (DataRow dr in dtCetak.Rows)
                {
                    NoNota = dr["NoNota"].ToString();
                    IdTr = dr["TransactionType"].ToString();
                    TglTerima = DateTime.Parse(dr["TglTerima"].ToString());
                    KodeSales = dr["KodeSales"].ToString();
                    HariKredit = dr["HariKredit"].ToString();
                    TglJT = DateTime.Parse(dr["TglJT"].ToString());
                    RpNet3 = double.Parse(dr["RpNet3"].ToString());
                    Total += RpNet3;

                    //if (nn > 12) // <- Logic yg aneh dr sistem yg lama
                    //{
                        PrintTagih.PROW(true, 1, "³" + ctr.ToString().PadLeft(2) +
                           "³ " + TglTerima.ToString("dd-MM-yyyy") +
                           "³" + NoNota +
                           "³" + IdTr +
                           " ³" + KodeSales +
                           " ³" + HariKredit.PadLeft(2) +
                           "³ " + TglJT.ToString("dd-MM-yyyy") +
                           "³" + RpNet3.ToString("#,##0").PadLeft(13) +
                           "³           ³           ³");

                        if (ctr == 12) //<- Original if (ii == 13), logic yg aneh. ?? 
                        {
                            PrintTagih.PROW(true, 1, "ÔÍÍÏÍÍÍÍÍÍÍÍÍÍÍÏÍÍÍÍÍÍÍÏÍÍÍÏÍÍÍÍÍÍÍÍÍÍÍÍÏÍÍÏÍÍÍÍÍÍÍÍÍÍÍÏÍÍÍÍÍÍÍÍÍÍÍÍÍÏÍÍÍÍÍÍÍÍÍÍÍÏÍÍÍÍÍÍÍÍÍÍÍ¾");
                            PrintTagih.PROW(true, 1, "                                             Jumlah     " + Total.ToString("#,##0").PadLeft(13));
                            PrintTagih.Eject();
                            ctr = 0;
                            //ii = 1;
                            Total = 0;
                            PrintTagih.Append(CetakHeader(NamaToko, Alamat, Daerah));
                        }
                    //}

                    ctr++;
                    //ii++;
                    nn++;
                }
                
                nn = (12 - ctr);
                for (int j = 1; j <= (nn+1); j++)
                {
                    PrintTagih.PROW(true, 1, "³" + ctr.ToString().PadLeft(2) + "³" + "           ³       ³   ³            ³  ³           ³             ³           ³           ³");
                    ctr++;
                }
                PrintTagih.PROW(true, 1, "ÔÍÍÏÍÍÍÍÍÍÍÍÍÍÍÏÍÍÍÍÍÍÍÏÍÍÍÏÍÍÍÍÍÍÍÍÍÍÍÍÏÍÍÏÍÍÍÍÍÍÍÍÍÍÍÏÍÍÍÍÍÍÍÍÍÍÍÍÍÏÍÍÍÍÍÍÍÍÍÍÍÏÍÍÍÍÍÍÍÍÍÍÍ¾");
                PrintTagih.PROW(true, 1, "                                             Jumlah     " + Total.ToString("#,##0").PadLeft(13));
            }

            PrintTagih.FontCondensed(false);
            PrintTagih.Eject();
            PrintTagih.SendToPrinter("RencanaTagihan2.txt");
        }
    }
}
