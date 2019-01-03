using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.FTP;
using ISA.DAL;
using System.IO;

namespace ISA.Trading.CommunicatorISA
{
    public partial class frmSendFile : ISA.Trading.BaseForm
    {
        int counter = 0;

        public frmSendFile()
        {
            InitializeComponent();
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;
                counter = 0;
                lblStatus.Text = "Get Data from Database ...";
                refreshForm();
                DataSet ds = GetSyncData();

                if (ds.Tables.Count > 0)
                {
                    lblStatus.Text = "Write data to XML file ...";
                    refreshForm();
                    string fileOuput = FtpEngine.UploadDirectory + "\\" + GlobalVar.CabangID + "DO" + DateTime.Now.ToString("yyyyMMdd hhmmss") + " " + Guid.NewGuid().ToString() + ".xml";
                    ds.WriteXml(fileOuput);
                    lblStatus.Text = "Uploading data ...";
                    refreshForm();
                    if (File.Exists(fileOuput))
                    {
                        lblStatus.Text = "Confirm data";
                        refreshForm();
                        ConfirmData(ds);
                        MessageBox.Show("File Kokpit" + "\n" + fileOuput);
                    }

                    if (FTP.FtpEngine.Upload(txtTarget.Text, fileOuput))
                    {
                       
                        refreshForm();
                        lblStatus.Text = "Upload Complete";
                    }
                    else
                    {
                        refreshForm();
                        lblStatus.Text = "Upload Failed";
                        MessageBox.Show(Messages.Confirm.UploadFailed);
                        
                    }
                   
                   
                }
                else
                {
                    MessageBox.Show(Messages.Confirm.NoDataAvailable);
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

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSendFile_Load(object sender, EventArgs e)
        {
            txtTarget.Text = LookupInfo.GetValue("FTP", "FTP_COCKPIT");
        }

        private void refreshForm()
        {
            lblUploadCount.Text = counter.ToString("#,##0") + "/" + pbSyncUpload.Maximum.ToString("#,##0");
            pbSyncUpload.Value = counter;
            this.Refresh();
            this.Invalidate();
            Application.DoEvents();
        }

        private DataSet GetSyncData()
        {
            counter = 0;
            
            pbSyncUpload.Value = 0;
            pbSyncUpload.Maximum = 42;

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            using (Database db = new Database())
            {

                counter++;
                lblStatus.Text = "Upload Expedisi";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_Expedisi"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Expedisi";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload Sales";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_Sales"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Sales";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload Pemasok";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_Pemasok"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Pemasok";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload Stok";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_Stok"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Stok";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload Toko";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_Toko"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Toko";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload Kompensasi";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_Kompensasi"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Kompensasi";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload AntarGudang";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_AntarGudang"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "AntarGudang";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload AnterGudangDetail";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_AntarGudangDetail"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "AntarGudangDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload Peminjaman";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_Peminjaman"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Peminjaman";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload PeminjamanDetail";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_PeminjamanDetail"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "PeminjamanDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                counter++;
                lblStatus.Text = "Upload Pengembalian";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_Pengembalian"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Pengembalian";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload PengembalianDetail";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_PengembalianDetail"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "PengembalianDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload Mutasi";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_Mutasi"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Mutasi";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload MutasiDetail";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_MutasiDetail"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "MutasiDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload OpnameHistory";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_OpnameHistory"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "OpnameHistory";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

/*tambahan*/
                counter++;
                lblStatus.Text = "Upload ClosingStokSaldo";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("[psp_SYNC_UPLOAD_ClosingStokSaldo]"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "ClosingStokSaldo";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload OrderPembelian";
                refreshForm();
                
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_OrderPembelian"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "OrderPembelian";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload OrderPembelianDetail";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_OrderPembelianDetail"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "OrderPembelianDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload NotaPembelian";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_NotaPembelian"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "NotaPembelian";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload NotaPembelianDetail";
                refreshForm();


                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_NotaPembelianDetail"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "NotaPembelianDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload KoreksiPembelian";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_KoreksiPembelian"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "KoreksiPembelian";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload ReturPembelian";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_ReturPembelian"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "ReturPembelian";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload ReturPembelianDetail";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_ReturPembelianDetail"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "ReturPembelianDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload ReturPembelianManualDetail";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_ReturPembelianManualDetail"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "ReturPembelianManualDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload KoreksiReturPembelian";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_KoreksiReturPembelian"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "KoreksiReturPembelian";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload OrderPenjualan";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_OrderPenjualan"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "OrderPenjualan";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload OrderPenjualanDetail";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_OrderPenjualanDetail"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "OrderPenjualanDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload NotaPenjualan";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_NotaPenjualan"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "NotaPenjualan";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload NotaPenjualanDetail";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_NotaPenjualanDetail"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "NotaPenjualanDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload KoreksiPenjualan";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_KoreksiPenjualan"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "KoreksiPenjualan";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload PenjualanPotongan";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_PenjualanPotongan"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "PenjualanPotongan";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload ReturPenjualan";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_ReturPenjualan"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "ReturPenjualan";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload ReturPenjualanDetail";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_ReturPenjualanDetail"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "ReturPenjualanDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload ReturPenjualanTarikanDetail";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_ReturPenjualanTarikanDetail"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "ReturPenjualanTarikanDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload KoreksiReturPenjualan";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_KoreksiReturPenjualan"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "KoreksiReturPenjualan";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload Selisih";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_Selisih"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "Selisih";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload SelisihDetail";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_SelisihDetail"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "SelisihDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload RekapKoli";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_RekapKoli"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "RekapKoli";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload RekapKoliDetail";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_RekapKoliDetail"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "RekapKoliDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                counter++;
                lblStatus.Text = "Upload RekapKoliSubDetail";
                refreshForm();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_RekapKoliSubDetail"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "RekapKoliSubDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }


                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("[psp_SYNC_UPLOAD_StandarStok]"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "StandarStok";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                
            }
            return ds;
        }


        private bool ConfirmData(DataSet ds)
        {
            bool success = false;
            int counter = 0;
            pbSyncUpload.Value = ds.Tables.Count;
            try
            {
                using (Database db = new Database())
                {
                    foreach (DataTable dt in ds.Tables)
                    {
                        counter++;
                        lblStatus.Text = "Confirm Data " + dt.TableName;
                        foreach (DataRow dr in dt.Rows)
                        {
                            db.Commands.Clear();
                            if (!(dr["XmlData"] is DBNull) && dr["XmlData"].ToString() != "" )
                            {
                                if (dr["Method"].ToString() == "UPDATE")
                                {
                                    db.Commands.Add(db.CreateCommand("psp_SYNC_CONFIRM_" + dr["TableName"].ToString()));
                                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 1));
                                    db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, dr["XmlData"].ToString()));
                                    db.Commands[0].ExecuteNonQuery();
                                }
                                else if (dr["Method"].ToString() == "DELETE")
                                {

                                    db.Commands.Add(db.CreateCommand("psp_SYNC_CONFIRM_DeletedHistory"));
                                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 1));
                                    db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, dr["XmlData"].ToString()));
                                    db.Commands[0].ExecuteNonQuery();
                                }
                            }
                        }
                        pbSyncUpload.Value = counter;
                        lblUpload.Text = counter.ToString("#,##0") + "/" + ds.Tables.Count.ToString("#,##0");
                        refreshForm();
                        success = true;
                    }
                }
            }
            catch(Exception ex)
            {
                success = false;
                Error.LogError (ex);
            }                            
            return success;
        }
    }
}
