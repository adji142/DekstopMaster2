using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Trading.VACCDO
{
    public partial class frmACCDOBrowse : ISA.Trading.BaseForm
    {
        string docNO = "NOMOR_ACC_DO";
        string initPerusahaan = GlobalVar.PerusahaanID;
        string host = Database.Host;

        public frmACCDOBrowse()
        {
            InitializeComponent();
        }

        private void frmACCDOBrowse_Load(object sender, EventArgs e)
        {
            chBoFilter.Checked = true;
            chBoFilter.Text = "Tampilkan seluruhnya";
            rgbTglDO.FromDate = DateTime.Now; //new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTglDO.ToDate = DateTime.Now;
        }

        private void chBoFilter_Click(object sender, EventArgs e)
        {
            if (chBoFilter.Checked == false)
            {
                chBoFilter.Text = "Tampilkan yang belum ACC saja.";
                RefreshDataBelum();
            }
            else
            {
                chBoFilter.Text = "Tampilkan seluruhnya";
                RefreshDataSeluruhnya();
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataSeluruhnya();
        }

        public void RefreshDataSeluruhnya()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_ACCDO_LIST")); //cek heri, 14032013
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglDO.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglDO.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dt.DefaultView.Sort = "TglDO, NoDo";
                dataGridView1.DataSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                //Error.LogError(ex);
                MessageBox.Show(ex.Message);
            }
        }


        public void RefreshRowDataDO(string _rowID)
        {
            Guid rowID = new Guid(_rowID);
            DataTable dtRefresh;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRefresh = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ACCDO_LIST_FILTER_ROWID")); //cek heri, 14032013
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }

                if (dtRefresh.Rows.Count > 0)
                {
                    dataGridView1.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID.ToString());
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

        public void RefreshDataBelum()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_ACCDO_LIST")); //cek heri, 14032013
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglDO.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglDO.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@filter", SqlDbType.VarChar, ""));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                //Error.LogError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdApprove_Click(object sender, EventArgs e)
        {
            Guid doID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_DOID")); //cek heri, 14032013
                    db.Commands[0].Parameters.Add(new Parameter("@doID", SqlDbType.UniqueIdentifier, doID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0 && !SecurityManager.AskPasswordManager())
                {
                    MessageBox.Show("Anda tidak berwenang untuk ACC ulang");
                    return;
                }

                Guid headerID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                string kodeToko = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
                DateTime tglDo = (DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglDO"].Value;
                string noNota, noACCDO, ACCOleh, lokasiDatabase, lokasiDataKasir, lokasiApp, nPrint;
                double Plafon, Gbc = 0, dDibayar, NilaiDO, dDebet;

                lokasiDatabase = LookupInfo.GetValue("VACCDO", "PIUTANG_PATH");
                lokasiDataKasir = LookupInfo.GetValue("VACCDO", "KASIR_PATH");
                //lokasiApp = LookupInfo.GetValue("VACCDO", "STOK_PATH");
                lokasiApp = Application.StartupPath + "\\v_accdo_ISA\\";

                ///////////////////// Fefe Part //////////////////////
                DataTable dtPL = new DataTable();
                DataTable dtOP = new DataTable();
                DataTable dtT = new DataTable();

                if (initPerusahaan.Substring(1, 0) == "0")
                {
                    initPerusahaan = "C";
                }
                else
                {
                    initPerusahaan = "0";
                }

                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_LIST_FILTER_HEADERID"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, headerID));
                    dtPL = db.Commands[0].ExecuteDataTable();

                    if (dtPL.Rows.Count == 0)
                    {
                        NilaiDO = 0;
                    }
                    else
                    {
                        NilaiDO = double.Parse(dtPL.Compute("SUM(HrgNet)", "").ToString());//Tools.isNull(dt.Rows[0]["HrgNet"], "").ToString();
                    }
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_LIST"));
                    db.Commands[1].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, headerID));
                    dtOP = db.Commands[1].ExecuteDataTable();
                    noNota = Tools.isNull(dtOP.Rows[0]["NoACCPiutang"], "").ToString();
                    nPrint = dtOP.Rows[0]["NPrint"].ToString();

                    db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));
                    db.Commands[2].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, kodeToko));
                    dtT = db.Commands[2].ExecuteDataTable();
                    Plafon = Convert.ToDouble(dtT.Rows[0]["Plafon"]);
                }
                //GENERATE Nomor Acc
                DataTable dtNum = Tools.GetGeneralNumerator(docNO);
                int lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                int iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                string depan = Tools.GeneralInitial();
                string belakang = dtNum.Rows[0]["Belakang"].ToString();
                iNomor++;
                string strNoACC = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
                strNoACC = strNoACC.Substring(3, 6);

                DataTable dt1 = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, kodeToko));
                    dt1 = db.Commands[0].ExecuteDataTable();

                    if (dt1.Rows.Count > 0)
                    {
                        db.Commands.Add(db.CreateCommand("usp_fnCekPlafon"));
                        db.Commands[1].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, kodeToko));
                        db.Commands[1].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, headerID));
                        dt1 = db.Commands[1].ExecuteDataTable();
                        if (dt1.Rows.Count > 0)
                        {
                            Plafon = Convert.ToDouble(dt1.Rows[0]["Plafon"]);
                        }
                    }
                    db.Commands.Add(db.CreateCommand("usp_vwDebetDibayarbankGiroTolak"));
                    db.Commands[2].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, kodeToko));
                    dt1 = db.Commands[2].ExecuteDataTable();
                    if (dt1.Rows.Count > 0)
                    {
                        dDebet = Convert.ToDouble(dt1.Rows[0]["Debet"]);
                        dDibayar = Convert.ToDouble(dt1.Rows[0]["Dibayar"]);
                    }
                    else
                    {
                        dDebet = 0;
                        dDibayar = 0;
                    }

                    if (dDebet - dDibayar > 0)
                    {
                        Gbc = Gbc + dDebet;
                    }

                    noACCDO = string.Empty;
                    ACCOleh = SecurityManager.UserID;
                }
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = lokasiApp + "v_accdo_ISA.exe";
                proc.StartInfo.Arguments = Plafon.ToString() + " " + kodeToko + " " + ACCOleh + " " + NilaiDO.ToString() + " " + headerID.ToString() + " " + strNoACC + " " + initPerusahaan + " " + tglDo.ToString("dd/MM/yyyy") + " " + lokasiDatabase + " " + lokasiDataKasir + " " + lokasiApp + " " + host + " " + nPrint;
                proc.Start();
                proc.WaitForExit();
                //RefreshDataSeluruhnya();
                dataGridView1.FindRow("RowID", doID.ToString());
                RefreshRowDataDO(doID.ToString());
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                cmdApprove.PerformClick();
            }
        }
    }
}
