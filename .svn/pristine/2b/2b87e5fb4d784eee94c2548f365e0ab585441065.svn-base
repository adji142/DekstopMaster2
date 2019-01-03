using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.Class;
using ISA.Common;

namespace ISA.Toko.Kasir
{
    public partial class frmLookupVoucherGiroTitipUpdate : ISA.Toko.BaseForm
    {
        Guid _titipID;
        string _titipRecID, _bankID, _namaBank, jnsSlip = "", _noVoucher, asalGiro, noBKM, _mengetahui="";
        DateTime tglCair;
        DataTable dtBKMHeader, dtBKMDetail;
        public frmLookupVoucherGiroTitipUpdate(Form caller, Guid titipID, string titipRecID, string bankID, string namaBank, string noVoucher, string mengetahui)
        {
            InitializeComponent();
            _titipID = titipID;
            _titipRecID = titipRecID;
            _bankID = bankID;
            _namaBank = namaBank;
            _noVoucher = noVoucher;
            _mengetahui = mengetahui;
            this.Caller = caller;
        }

        public frmLookupVoucherGiroTitipUpdate()
        {
            InitializeComponent();
        }

        private void frmLookupVoucherGiroTitipUpdate_Load(object sender, EventArgs e)
        {
            gridDetail.AutoGenerateColumns = false;
            try
            {
                DataTable dtVoucherGiroTtp = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    dtVoucherGiroTtp = Giro.ListLookupVoucherGiroTitip(db);
                }


                dtVoucherGiroTtp.DefaultView.Sort = "CHBG,Nomor";
                gridDetail.DataSource = dtVoucherGiroTtp.DefaultView;

                gridDetail.Focus();

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void titipGiro()
        {

            try
            {
                Guid _GiroID = (Guid)gridDetail.SelectedCells[0].OwningRow.Cells["GiroID"].Value;
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("usp_Giro_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@GiroID", SqlDbType.UniqueIdentifier, _GiroID));
                    db.Commands[0].Parameters.Add(new Parameter("@TitipID", SqlDbType.UniqueIdentifier, _titipID));
                    db.Commands[0].Parameters.Add(new Parameter("@TitipRecID", SqlDbType.VarChar, _titipRecID));
                    db.Commands[0].Parameters.Add(new Parameter("@TglTitip", SqlDbType.DateTime, DateTime.Today));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    if (jnsSlip == "" || jnsSlip == "Titip")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, _bankID));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaBanki", SqlDbType.VarChar, _namaBank));
                    }
                    else if (jnsSlip == "Tunai")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@CHBG", SqlDbType.VarChar, "K"));
                        db.Commands[0].Parameters.Add(new Parameter("@CairTolak", SqlDbType.VarChar, "C"));
                        db.Commands[0].Parameters.Add(new Parameter("@TglCair", SqlDbType.VarChar, DateTime.Today));
                    }
                    db.Commands[0].ExecuteNonQuery();
                }

                if (jnsSlip == "Tunai")
                    cetakLaporan();

                frmVoucherGiroTitipanBrowse frm = new frmVoucherGiroTitipanBrowse();
                frm = (frmVoucherGiroTitipanBrowse)Caller;
                frm.HeaderRowRefresh(_titipID);
                frm.DetailRowRefresh(_GiroID);
                frm.DetailFindRow("GiroID", _GiroID.ToString());
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        #region cetak laporan
        public void cetakLaporan()
        {

            int i = 0;
            double total = 0, jumlah;
            string _Terima, _NoBukti, _Tanggal, _Lampiran, _Kasir;
            _Terima = asalGiro;
            _NoBukti = noBKM;
            _Lampiran = " ";
            _Tanggal = tglCair.ToString("dd-MMM-yyyy");
            _Kasir = SecurityManager.UserName;

            try
            {
                BuildString lap = new BuildString();
                lap.Initialize();

                lap.PageLLine(33);
                lap.LeftMargin(1);
                lap.FontCPI(12);
                lap.LineSpacing("1/6");
                lap.DoubleWidth(true);
                lap.PROW(true, 1, "[BUKTI KAS MASUK]");
                lap.DoubleWidth(false);

                lap.PROW(true, 1, lap.PrintTopLeftCorner() + lap.PrintHorizontalLine(41) + lap.PrintTTOp()
                + lap.PrintHorizontalLine(41) + lap.PrintTopRightCorner());
                lap.PROW(true, 1, lap.PrintVerticalLine() + "Di Terima Dari : ".PadRight(41) +
                    lap.PrintVerticalLine() + ("Nomor   : " + _NoBukti).PadRight(41) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + _Terima.PadRight(41) + lap.PrintVerticalLine() + ("Tanggal : " +
                    _Tanggal).PadRight(30) + ("Hal : 1/1").PadRight(11) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(41) + lap.PrintTBottom()
                    + lap.PrintHorizontalLine(41) + lap.PrintTRight());
                lap.PROW(true, 1, lap.PrintVerticalLine() + "No. Prk".PadRight(10) + lap.PadCenter(58, "URAIAN") + lap.SPACE(15) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());

                foreach (DataRow dr in dtBKMDetail.Rows)
                {
                    jumlah = Convert.ToDouble(dr["Jumlah"].ToString());

                    lap.PROW(true, 1, lap.PrintVerticalLine() + "".ToString().Trim().PadRight(10) + dr["Uraian"].ToString().ToUpper().PadRight(58).Substring(0, 58) + jumlah.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());
                    total += Convert.ToDouble(dr["Jumlah"].ToString());
                    i++;
                }
                if (i < 10)
                {
                    for (int j = 0; j < 10 - i; j++)
                    {
                        lap.PROW(true, 1, lap.PrintVerticalLine() + lap.SPACE(83) + lap.PrintVerticalLine());
                    }
                }

                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
                lap.PROW(true, 1, lap.PrintVerticalLine() + "Terbilang".PadRight(58) + "Jumlah Rp.".PadRight(10) +
                    total.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
                lap.PROW(true, 1, lap.PrintVerticalLine() + Tools.Terbilang(total).PadRight(83) + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTTOp()
                    + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTRight());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "Pembukuan") + lap.PrintVerticalLine() + lap.PadCenter(20, "Mengetahui")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "Kasir") + lap.PrintVerticalLine() + lap.PadCenter(20, "Penerima") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                    + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintVerticalLine() + "(" + lap.PadCenter(18, "") + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, "")
                    + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _Kasir.Trim()) + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _Terima.Trim()) + ")" +
                    lap.PrintVerticalLine());
                lap.PROW(true, 1, lap.PrintBottomLeftCorner() + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintTBottom()
                    + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintBottomRightCorner());
                lap.PROW(true, 1, String.Format("{0:yyyyMMddhhmmss}", DateTime.Now) + " " + SecurityManager.UserName);
                lap.Eject();

                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("rsp_CetakBukti"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _titipID));
                    db.Commands[0].ExecuteNonQuery();
                }
                lap.SendToPrinter("laporan.txt");


            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        #endregion

        private void gridDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridDetail.SelectedCells[0].OwningRow.Cells["CHBG"].Value.ToString() == "S")
            {
                gbSlip.Visible = true;
                gbLookup.Enabled = false;
            }
            else
                titipGiro();
        }

        private void gridDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (gridDetail.SelectedCells[0].OwningRow.Cells["CHBG"].Value.ToString() == "S")
                {
                    gbSlip.Visible = true;
                    gbLookup.Enabled = false;
                }
                else
                    titipGiro();
            }

            if (e.KeyCode == Keys.Delete || e.KeyCode==Keys.Back)
            {
                
                    string search = tbSearch.Text;
                    if (search.Length > 0)
                    {
                        search = search.Substring(0, search.Length - 1);
                        tbSearch.Text = search;
                    }
                
            }
            
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (gridDetail.SelectedCells[0].OwningRow.Cells["CHBG"].Value.ToString() == "S")
            {
                gbSlip.Visible = true;
                gbLookup.Enabled = false;
            }
            else
                titipGiro();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdTunai_Click(object sender, EventArgs e)
        {
            jnsSlip = "Tunai";
            cmdTitip.Enabled = false;
            gbTglCair.Enabled = true;
            tbTglCair.DateValue = DateTime.Today;
            tbTglCair.Focus();
        }

        private void cmdTitip_Click(object sender, EventArgs e)
        {
            jnsSlip = "Titip";
            cmdTunai.Enabled = false;
            titipGiro();
        }

        private void tbTglCair_Leave(object sender, EventArgs e)
        {
            //cair slip
            try
            {
                string _noGiro=gridDetail.SelectedCells[0].OwningRow.Cells["Nomor"].Value.ToString();
                if (MessageBox.Show("Proses Cair Slip " + _noGiro + " ??", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    DataTable dtCekBukti = new DataTable();
                    dtCekBukti = Inden.CekRelasiInden("Bukti", "RowID", _titipID.ToString(), "", "");
                    string RecordIDBKM = _titipRecID.Substring(0, 22) + "S";
                    Guid _GiroID = (Guid)gridDetail.SelectedCells[0].OwningRow.Cells["GiroID"].Value;
                    string _GiroRecID = gridDetail.SelectedCells[0].OwningRow.Cells["GiroRecID"].Value.ToString();
                    string noPerk = Perkiraan.GetPerkiraanKoneksiDetail("BGTRM").Rows[0]["NoPerkiraan"].ToString();
                    string uraian = "SLIP #" + _noGiro + " (" + _noVoucher + ")";
                    string jumlah = gridDetail.SelectedCells[0].OwningRow.Cells["Nominal"].Value.ToString();
                    tglCair = (DateTime)tbTglCair.DateValue;
                    using (Database db = new Database(GlobalVar.DBFinance))
                    {
                        db.BeginTransaction();
                        if (dtCekBukti.Rows.Count == 0)
                        {
                            noBKM = Numerator.BookNumerator("BKM");
                            asalGiro = gridDetail.SelectedCells[0].OwningRow.Cells["_asalgiro"].Value.ToString();
                            BKM.AddHeader(db, _titipID, _titipID, RecordIDBKM, noBKM, "K", "SLP", tglCair, asalGiro, "", "", SecurityManager.UserName, "");
                        }
                        else
                        {
                            dtBKMHeader = new DataTable();
                            dtBKMHeader = BKM.ListHeaderperRow(_titipID);
                            asalGiro = dtBKMHeader.Rows[0]["Kepada"].ToString();
                            noBKM = dtBKMHeader.Rows[0]["NoBukti"].ToString();
                            tglCair = (DateTime)dtBKMHeader.Rows[0]["TglBukti"];
                        }
                        BKM.AddDetail(db, _GiroID, _titipID, _GiroRecID, RecordIDBKM, "", "", "", "", noPerk, uraian, jumlah);
                        db.CommitTransaction();
                        dtBKMDetail = new DataTable();
                        dtBKMDetail = BKM.ListDetail(db, _titipID);
                    }

                    titipGiro();
                }
                else
                {
                    jnsSlip = "";
                    cmdTitip.Enabled = true;
                    gbTglCair.Enabled = false;
                    gbSlip.Visible = false;
                    gbLookup.Enabled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void gridDetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (gridDetail.SelectedCells[0].ColumnIndex == 0)
            //{
                if (char.IsNumber(e.KeyChar))
                {
                    string search = tbSearch.Text;
                    search += e.KeyChar;
                    tbSearch.Text = search;
                }
           // }
        }

        private void gridDetail_SelectionChanged(object sender, EventArgs e)
        {
            if (gridDetail.SelectedCells.Count > 0)
            {
                if (gridDetail.SelectedCells[0].ColumnIndex != 1)
                {
                  //  tbSearch.Clear();
                }
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length > 0)
            {
                string search = tbSearch.Text;
                for (int i = 0; i < (gridDetail.Rows.Count); i++)
                {
                    if (gridDetail.Rows[i].Cells["Nomor"].Value.ToString().StartsWith(search))
                    {
                        gridDetail.Rows[i].Cells["Nomor"].Selected = true;
                        return; // stop looping
                    }
                }
            }
        }

        
    }
}
