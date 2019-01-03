using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Globalization;

namespace ISA.Finance.Kasir
{
    public partial class frmKasirLogBrowse : ISA.Finance.BaseForm
    {
        DataTable dtKasirLog;
        DataTable dtKasOpname;
        int jml, idx;
        string imgBase64;
        public frmKasirLogBrowse()
        {
            InitializeComponent();
        }

        private void frmKasirLogBrowse_Load(object sender, EventArgs e)
        {
            ListKasirLog();
            idx = jml - 1;
            DetailKasirLog(idx);
        }

        private void ListKasirLog()
        {
            try
            {
                //Untuk Menambah kolom Attachment apabila kolom tersebut belum ada
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_KasOpname_ADDCOLUMN"));
                    db.Commands[0].ExecuteDataTable();
                }

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_KasirLog_LIST"));
                    dtKasirLog = db.Commands[0].ExecuteDataTable();
                }
                jml = dtKasirLog.Rows.Count;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void GetAttachmentKas() {
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_KasirLogDataTransaksi_List"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglOpname", SqlDbType.DateTime, tbTanggal.DateValue));

                    dtKasOpname = db.Commands[0].ExecuteDataTable();
                }
                if (dtKasOpname.Rows.Count > 0)
                {
                    akGV.DataSource = dtKasOpname.DefaultView;
                    
                    SetTransactionName(dtKasOpname);

                    imgBase64 = akGV.SelectedCells[0].OwningRow.Cells["AttachmentSource"].Value.ToString();

                    string state = akGV.SelectedCells[0].OwningRow.Cells["AttachmentKas"].Value.ToString();

                    AutoPreviewAttachment(state);
                }
            }
            catch (Exception ex) 
            {
                Error.LogError(ex);
            }
        }

        private void DetailKasirLog(int index)
        {
            CultureInfo ind= CultureInfo.GetCultureInfo("id-ID");

            tbTanggal.DateValue = (DateTime)dtKasirLog.Rows[index]["Tanggal"];
            tbDay.Text = ind.DateTimeFormat.DayNames[(int)((DateTime)dtKasirLog.Rows[index]["Tanggal"]).DayOfWeek];

            tbKasAwal.Text = dtKasirLog.Rows[index]["KasAwal"].ToString();
            tbKasMasuk.Text = dtKasirLog.Rows[index]["KasMasuk"].ToString();
            tbKasKeluar.Text = dtKasirLog.Rows[index]["KasKeluar"].ToString();
            tbKasAkhir.Text = dtKasirLog.Rows[index]["KasAkhir"].ToString();

            tbKasIndenAwal.Text = dtKasirLog.Rows[index]["KasIndenAwal"].ToString();
            tbKasIndenMasuk.Text = dtKasirLog.Rows[index]["KasIndenMasuk"].ToString();
            tbKasIndenKeluar.Text = dtKasirLog.Rows[index]["KasIndenKeluar"].ToString();
            tbKasIndenAkhir.Text = dtKasirLog.Rows[index]["KasIndenAkhir"].ToString();

            tbBGDAwal.Text = dtKasirLog.Rows[index]["BGDAwal"].ToString();
            tbBGDMasuk.Text = dtKasirLog.Rows[index]["BGDMasuk"].ToString();
            tbBGDKeluar.Text = dtKasirLog.Rows[index]["BGDKeluar"].ToString();
            tbBGDAkhir.Text = dtKasirLog.Rows[index]["BGDAkhir"].ToString();

            tbBGTAwal.Text = dtKasirLog.Rows[index]["BGTAwal"].ToString();
            tbBGTMasuk.Text = dtKasirLog.Rows[index]["BGTMasuk"].ToString();
            tbBGTKeluar.Text = dtKasirLog.Rows[index]["BGTKeluar"].ToString();
            tbBGTAkhir.Text = dtKasirLog.Rows[index]["BGTAkhir"].ToString();

            tbBGIndenAwal.Text = dtKasirLog.Rows[index]["BGIndenAwal"].ToString();
            tbBGIndenMasuk.Text = dtKasirLog.Rows[index]["BGIndenMasuk"].ToString();
            tbBGIndenKeluar.Text = dtKasirLog.Rows[index]["BGIndenKeluar"].ToString();
            tbBGIndenAkhir.Text = dtKasirLog.Rows[index]["BGIndenAkhir"].ToString();

            tbBGTolakAwal.Text = dtKasirLog.Rows[index]["BGTolakAwal"].ToString();
            tbBGTolakMasuk.Text = dtKasirLog.Rows[index]["BGTolakMasuk"].ToString();
            tbBGTolakKeluar.Text = dtKasirLog.Rows[index]["BGTolakKeluar"].ToString();
            tbBGTolakAkhir.Text = dtKasirLog.Rows[index]["BGTolakAkhir"].ToString();

            tbBGInternalAwal.Text = dtKasirLog.Rows[index]["BGInternalAwal"].ToString();
            tbBGInternalMasuk.Text = dtKasirLog.Rows[index]["BGInternalMasuk"].ToString();
            tbBGInternalKeluar.Text = dtKasirLog.Rows[index]["BGInternalKeluar"].ToString();
            tbBGInternalAkhir.Text = dtKasirLog.Rows[index]["BGInternalAkhir"].ToString();

            tbBankAwal.Text = dtKasirLog.Rows[index]["BankAwal"].ToString();
            tbBankMasuk.Text = dtKasirLog.Rows[index]["BankMasuk"].ToString();
            tbBankKeluar.Text = dtKasirLog.Rows[index]["BankKeluar"].ToString();
            tbBankAkhir.Text = dtKasirLog.Rows[index]["BankAkhir"].ToString();

            tbTrnIndenAwal.Text = dtKasirLog.Rows[index]["TrnIndenAwal"].ToString();
            tbTrnIndenMasuk.Text = dtKasirLog.Rows[index]["TrnIndenMasuk"].ToString();
            tbTrnIndenKeluar.Text = dtKasirLog.Rows[index]["TrnIndenKeluar"].ToString();
            tbTrnIndenAkhir.Text = dtKasirLog.Rows[index]["TrnIndenAkhir"].ToString();

            tbPKAwal.Text = dtKasirLog.Rows[index]["PKAwal"].ToString();
            tbPKMasuk.Text = dtKasirLog.Rows[index]["PKMasuk"].ToString();
            tbPKKeluar.Text = dtKasirLog.Rows[index]["PKKeluar"].ToString();
            tbPKAkhir.Text = dtKasirLog.Rows[index]["PKAkhir"].ToString();

            tbBSAwal.Text = dtKasirLog.Rows[index]["BSAwal"].ToString();
            tbBSMasuk.Text = dtKasirLog.Rows[index]["BSMasuk"].ToString();
            tbBSKeluar.Text = dtKasirLog.Rows[index]["BSKeluar"].ToString();
            tbBSAkhir.Text = dtKasirLog.Rows[index]["BSAkhir"].ToString();
        }

        private void cmdPrev_Click(object sender, EventArgs e)
        {
            if (idx - 1 >=0)
            {
                idx -= 1;
                DetailKasirLog(idx);
            }
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            if (idx + 1 < jml)
            {
                idx += 1;
                DetailKasirLog(idx);
            }
        }

        private void frmKasirLogBrowse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageDown)
            {
                if (idx - 1 >= 0)
                {
                    idx -= 1;
                    DetailKasirLog(idx);
                }
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                if (idx + 1 < jml)
                {
                    idx += 1;
                    DetailKasirLog(idx);
                }
            }
            else if (e.KeyCode == Keys.F2)
            {
                DataTable dt = new DataTable();
                dt = dtKasirLog.Copy();
                dt.DefaultView.RowFilter = "Tanggal>='"+tbTanggal.DateValue+"'";
                frmKasirLogModeBrowse frm = new frmKasirLogModeBrowse(dt.DefaultView.ToTable());
                frm.ShowDialog();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbTanggal_TextChanged(object sender, EventArgs e)
        {
            GetAttachmentKas();
        }

        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private void akGV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (dtKasOpname.Rows.Count > 0)
            {
                Image img = Base64ToImage(imgBase64);
                picPreview.Image = img;
            }
            else 
            {
                picPreview.Image = null;
            }*/
        }

        private void akGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (dtKasOpname.Rows.Count > 0)
            {
                string statue = akGV.SelectedCells[0].OwningRow.Cells["AttachmentKas"].Value.ToString();
                string imgSource = akGV.SelectedCells[0].OwningRow.Cells["AttachmentSource"].Value.ToString();
                if (statue == "1")
                {
                    ShowImage(imgSource);
                }
                else {
                    HideImage();
                }
            }
            else
            {
                if (picPreview.Image == null)
                {
                    HideImage();
                }
            }
        }

        private void kasBonGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (e.RowIndex < 0)
            {
                return;
            }
            if (picPreview.Image != null)
            {
                //picPreview.Image.Dispose();
                picPreview.Image = null;
            }*/
        }

        public static DataTable OpnameList(Database db, DateTime TglOpname)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_KasOpname_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, TglOpname));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        private void SetTransactionName(DataTable dt)
        {
            if(dt.Rows[0]["AttachmentKas"].ToString() == "0")
            {
                akGV.Rows[0].Cells[0].Value = dt.Rows[0]["NamaTransaksi"].ToString() + " [Not Found]";
            }
            /*if (dt.Rows[1]["AttachmentKas"].ToString() == "0")
            {
                akGV.Rows[1].Cells[0].Value = dt.Rows[1]["NamaTransaksi"].ToString() + " [Not Found]";
            }
            if (dt.Rows[2]["AttachmentKas"].ToString() == "0")
            {
                akGV.Rows[2].Cells[0].Value = dt.Rows[2]["NamaTransaksi"].ToString() + " [Not Found]";
            }*/
        }

        private void ShowImage(string source) 
        {
            picPreview.Image = Base64ToImage(source);
        }

        private void HideImage()
        {
            if (picPreview.Image == null)
            {
                return;
            }
            else
            {
                picPreview.Image.Dispose();
                picPreview.Image = null;
            }
        }

        private void AutoPreviewAttachment(string state) 
        {
            if (state == "0")
            {
                if (imgBase64 == "")
                {
                    picPreview.Image = null;
                    return;
                }
                else
                {
                    picPreview.Image.Dispose();
                    picPreview.Image = null;
                }
            }
            else 
            {
                picPreview.Image = Base64ToImage(imgBase64);
            }
        }
    }
}
