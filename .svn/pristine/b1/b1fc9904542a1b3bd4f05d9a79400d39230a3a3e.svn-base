using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlTypes;
using ISA.Finance.DataTemplates;
using Microsoft.Reporting.WinForms;
using ISA.Finance.Class;
using ISA.Finance;


namespace ISA.Finance.Hutang
{
    public partial class frmPembayaranHutangHI : ISA.Controls.BaseForm
    {
        DataRow drH, drD, drT, drK;
        Guid RowH, RowD, PrID;
        enum enumFormMode { New, Update };
        DataTable dtMt = new DataTable();
        bool ok = false;
        enumFormMode FormMode;
        string _flag = "";
        Guid _PerusahaanRowID;
        Guid _PerusahaanKeRowID;

        string Local = "usp_DaftarUangMukaBlmIdentifikasiLokal";
        string Local2 = "usp_DaftarUangMukaBlmIdentifikasiLokalVendorLain";
        string Import = "usp_DaftarUangMukaBlmIdentifikasiLokal_FromImport";

        public frmPembayaranHutangHI(Form caller, DataRow drH_, string flag)
        {
            InitializeComponent();
            this.Caller = caller;
            drH = drH_;
            if (flag.Equals("1"))
            {
                FormMode = enumFormMode.New;
            }
            else if (flag.Equals("2"))
            {
                FormMode = enumFormMode.Update;
            }
        }

        private void frmPembayaranHutangHI_Load(object sender, EventArgs e)
        {
            try
            {
                InitJenisTransaksi();
                setInfoInvoice();
                InitDrT();

                switch (FormMode)
                {
                    case enumFormMode.New:
                        {
                            cboJenisPembayaran.SelectedIndex = 0;
                            txtTglPembayaran.DateValue = GlobalVar.DateOfServer;
                            txtTglRelasi.DateValue = GlobalVar.DateOfServer;
                            _flag = "I";
                        }
                        break;
                    case enumFormMode.Update:
                        {
                            cboJenisPembayaran.SelectedValue = drD["JnsPembayaranHutang"].ToString();
                            cboJenisPembayaran.Enabled = false;
                            //LoadData();
                            txtTglRelasi.DateValue = GlobalVar.DateOfServer;
                            _flag = "E";
                        }
                        break;
                }

                try
                {
                    DataTable dtPerusahaan = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Perusahaan2_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@flag", SqlDbType.VarChar, "I"));
                        dtPerusahaan = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtPerusahaan.Rows.Count > 0)
                    {
                        _PerusahaanRowID = new Guid(dtPerusahaan.Rows[0]["RowID"].ToString());
                        //dtPerusahaan.DefaultView.Sort = "InitPerusahaan ASC";
                        cboPerusahaan.DataSource = dtPerusahaan;
                        cboPerusahaan.DisplayMember = "Nama";
                        cboPerusahaan.ValueMember = "RowID";
                        //cboPerusahaan.ValueMember = "InitPerusahaan";
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void InitJenisTransaksi()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_KategoriPembayaran_list"));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (drH["RowID"].ToString() == "")
            {
                cTools.DeleteDataTable(dt, "Kategori='Koreksi Beli'");
            }
            cboJenisPembayaran.DataSource = dt.DefaultView;
            cboJenisPembayaran.ValueMember = "KategoriID";
            cboJenisPembayaran.DisplayMember = "Kategori";
        }

        private void setInfoInvoice()
        {
            try
            {
                RowH = (Guid)drH["RowID"];
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_DaftarHutang_AntarPT_LIST_FILTER_StatusLunas]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, drH["RowID"]));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    txtNoInvoice.Text = dt.Rows[0]["InvoiceNo"].ToString();
                    txtTglInvoice.Text = Convert.ToDateTime(dt.Rows[0]["TglInvoice"]).ToString("dd/MM/yyyy");
                    txtSaldoIdr.Text = Convert.ToDouble(dt.Rows[0]["IDRAmount"]).ToString("N4");
                    txtHIDR.Text = Convert.ToDouble(dt.Rows[0]["SisaHutangIDR"]).ToString("N4");
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

        private void InitDrT()
        {
            DataSet ds = new dsPembayaranHutang();
            drT = ds.Tables["dtTemplate"].NewRow();
            txtKet.Text = "";
            txtNoBuktiKasir.Text = "";
            txtPmbKasirIDR.Text = "0";
            txtIden.Text = "0";
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (cboJenisPembayaran.Text.ToString() == "Pembayaran Normal" || cboJenisPembayaran.Text.ToString() == "Uang Muka")
                {
                    initLookUpBukti();
                }
                else if (cboJenisPembayaran.Text.ToString() == "Koreksi Beli")
                {
                    //initLookUpKoreksi();
                }
                else if (cboJenisPembayaran.Text.ToString() == "DKN")
                {
                    //GetDNKN(SqlGuid.Null);
                }
                else if (cboJenisPembayaran.Text.ToString() == "Retur Beli")
                {
                    //GetRetur(SqlGuid.Null);
                }

                else if (cboJenisPembayaran.Text.ToString() == "Koreksi Retur Beli")
                {
                    //GetKoret(SqlGuid.Null);
                }

                else if (cboJenisPembayaran.Text.ToString() == "Pembayaran Ke Vendor Lain")
                {
                    //initLookUpBuktiVendorLain();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void initLookUpBukti()
        {
            try
            {
                DataTable dtg = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_GetPerusahaanRowID]"));
                    dtg = db.Commands[0].ExecuteDataTable();
                }
                if (dtg.Rows.Count > 0)
                {
                    PrID = (Guid)dtg.Rows[0]["RowID"];
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


            string spp = "";
            spp = Local;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_DaftarUangMukaBlmIdentifikasiLokalAntarPT"));
                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDrID", SqlDbType.UniqueIdentifier, PrID));
                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeID", SqlDbType.UniqueIdentifier, _PerusahaanRowID));
                //db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, drH["VendorRowID"]));
                //db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, PrID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count == 0)
            {
                ok = false;
                throw new Exception("Tidak Ada Pembayaran ke Perusahaan ini !!");
            }
            frmPembayaranGetBuktiHI ifrm = new frmPembayaranGetBuktiHI(dt, "Pengeluaran Kasir");
            ifrm.ShowDialog();

            if (ifrm.DialogResult == DialogResult.OK)
            {
                drT["PengeluaranUangRowID"] = ifrm.GetData["RowID"];
                drT["KoreksiBeliRowID"] = DBNull.Value;
                drT["Tanggal"] = ifrm.GetData["Tanggal"];
                drT["PmbReferensi"] = ifrm.GetData["NoBukti"];
                drT["Keterangan"] = ifrm.GetData["Uraian"];
                drT["MataUangRowID"] = ifrm.GetData["MataUangRowID"];
                drT["MataUangID"] = ifrm.GetData["MataUangID"];
                drT["PembORI"] = ifrm.GetData["Nominal"];
                drT["PembIDR"] = ifrm.GetData["NominalRp"];
                drT["SisaORI"] = ifrm.GetData["RpSisaOriginal"];
                drT["SisaIDR"] = ifrm.GetData["RpSisaIDR"];
                drT["PerusahaanDariRowID"] = ifrm.GetData["PerusahaanDariRowID"];
                //drT["PerusahaanKeRowID"] = ifrm.GetData["PerusahaanKeRowID"];
                _PerusahaanKeRowID = (Guid)ifrm.GetData["PerusahaanKeRowID"];

                txtPmbKasirIDR.Text = Convert.ToDouble(drT["PembIDR"]).ToString("N2");
                txtNoBuktiKasir.Text = drT["PmbReferensi"].ToString();
                txtTglPembayaran.DateValue = (DateTime)drT["Tanggal"];
                txtKet.Text = drT["Keterangan"].ToString();
                txtIden.Text = Convert.ToDouble(drT["SisaIDR"]).ToString("N2");
                ok = true;
            }
            else
            {
                ok = false;
                throw new Exception("Tak Ada Data yang di pilih !!");
            }
        }

        private void cboJenisPembayaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitDrT();
            txtIden.ReadOnly = false;
            txtIden.Text = "0";
            txtTglPembayaran.ReadOnly = true;
            switch (cboJenisPembayaran.Text)
            {
                case "Uang Muka":
                    GBBukti.Visible = true;
                    LableKas.Text = "NoBukti";
                    break;
                case "Pembayaran Normal":
                    GBBukti.Visible = true;
                    LableKas.Text = "NoBukti";
                    break;
                case "Potongan":
                    GBBukti.Visible = false;
                    if (FormMode == enumFormMode.New)
                    {
                        txtTglPembayaran.ReadOnly = true;
                        txtTglPembayaran.DateValue = GlobalVar.DateOfServer;
                    }
                    txtTglRelasi.DateValue = GlobalVar.DateOfServer;
                    break;
                case "Koreksi Beli":
                    GBBukti.Visible = true;
                    LableKas.Text = "NoKoreksi";
                    txtIden.ReadOnly = true;
                    break;

                case "DKN":
                    GBBukti.Visible = true;
                    LableKas.Text = "NoDKN";

                    break;
                case "Retur Beli":
                    GBBukti.Visible = true;
                    LableKas.Text = "NoRetur";

                    break;

                case "Koreksi Retur Beli":
                    GBBukti.Visible = true;
                    LableKas.Text = "NoKoreksi";
                    txtIden.ReadOnly = true;
                    break;
            }
        }

        private void cboPerusahaan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPerusahaan.Text == "")
            {
                _PerusahaanRowID = Guid.Empty;
            }
            else
            {
                DataRowView row = (DataRowView)cboPerusahaan.SelectedItem;
                if (row != null)
                {
                    _PerusahaanRowID = new Guid(row[0].ToString());
                }
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (NotValid())
            {
                return;
            }
            try
            {
                switch (FormMode)
                {
                    case enumFormMode.New:
                        {
                            if (cboJenisPembayaran.Text == "Potongan")
                            {
                                //InsertPotongan();
                            }
                            else
                            {
                                Insert();
                            }

                        }
                        break;

                    case enumFormMode.Update:
                        {

                            if (cboJenisPembayaran.Text == "Potongan")
                            {
                                //UpdateDataPotongan();
                            }
                            else
                            {
                                //UpdateData();
                            }


                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private bool NotValid()
        {
            bool val = false;
            ErrorProvider err = new ErrorProvider();

            if (FormMode == enumFormMode.New)
            {
                switch (cboJenisPembayaran.Text)
                {
                    case "Uang Muka":
                        {
                            if (txtIden.GetDoubleValue > Convert.ToDouble(drT["SisaIDR"]))
                            {
                                err.SetError(txtIden, "Max Identifikasi : " + Convert.ToDouble(drT["SisaORI"]).ToString("n4"));
                                val = true;
                            }
                            if (!ok)
                            {
                                err.SetError(btnCari, "Data Tidak Update, Pilih Ulang Data !!!");
                                val = true;
                            }
                        }

                        break;
                    case "Pembayaran Normal":
                        {
                            if (txtIden.GetDoubleValue > Convert.ToDouble(drT["SisaIDR"]))
                            {
                                err.SetError(txtIden, "Max Identifikasi : " + Convert.ToDouble(drT["SisaORI"]).ToString("n4"));
                                val = true;
                            }

                            if (!ok)
                            {
                                err.SetError(btnCari, "Data Tidak Update, Pilih Ulang Data !!!");
                                val = true;
                            }
                        }
                        break;
                    case "Potongan":
                        {
                            if (txtIden.GetDoubleValue <= 0)
                            {
                                err.SetError(txtIden, "Harus di ISI !!!");
                                val = true;
                            }
                        }
                        break;
                    case "Koreksi Beli":
                        {
                            if (!ok)
                            {
                                err.SetError(btnCari, "Data Tidak Update, Pilih Ulang Data !!!");
                                val = true;
                            }
                        }
                        break;
                    case "DNKN":
                        {
                            if (txtIden.GetDoubleValue > Convert.ToDouble(drT["SisaORI"]))
                            {
                                err.SetError(txtIden, "Max Identifikasi : " + Convert.ToDouble(drT["SisaORI"]).ToString("n4"));
                                val = true;
                            }

                            if (!ok)
                            {
                                err.SetError(btnCari, "Data Tidak Update, Pilih Ulang Data !!!");
                                val = true;
                            }
                        }

                        break;
                    case "Retur Beli":
                        {
                            if (txtIden.GetDoubleValue > Convert.ToDouble(drT["SisaORI"]))
                            {
                                err.SetError(txtIden, "Max Identifikasi : " + Convert.ToDouble(drT["SisaORI"]).ToString("n4"));
                                val = true;
                            }

                            if (!ok)
                            {
                                err.SetError(btnCari, "Data Tidak Update, Pilih Ulang Data !!!");
                                val = true;
                            }
                        }

                        break;



                }

            }
            else if (FormMode == enumFormMode.Update)
            {
                switch (cboJenisPembayaran.Text)
                {
                    case "Uang Muka":
                        {
                            if (txtIden.GetDoubleValue > Convert.ToDouble(txtPmbKasirIDR.Text))
                            {
                                err.SetError(txtIden, "Max Identifikasi : " + Convert.ToDouble(drT["SisaORI"]).ToString("n4"));
                                val = true;
                            }

                        }

                        break;
                    case "Pembayaran Normal":
                        {
                            if (txtIden.GetDoubleValue > Convert.ToDouble(txtPmbKasirIDR.Text))
                            {
                                err.SetError(txtIden, "Max Identifikasi : " + Convert.ToDouble(drT["SisaORI"]).ToString("n4"));
                                val = true;
                            }


                        }
                        break;
                    case "Potongan":
                        {
                            if (txtIden.GetDoubleValue <= 0)
                            {
                                err.SetError(txtIden, "Harus di ISI !!!");
                                val = true;
                            }
                        }
                        break;
                }
            }

            if (txtNoPembayaran.Text == "")
            {
                //err.SetError(txtNoPembayaran, "Harus di ISI !!!");
                //val = true;
            }

            return val;
        }


        private void Insert()
        {
            RowD = Guid.NewGuid();
            if (cTools.isNull(txtNoPembayaran.Text, "").ToString() == "")
            {
                txtNoPembayaran.Text = cTools.GetNomorDokumen("PEMBAYARAN_UANG_MUKA_ANTAR_PT", "", "/BPH/" + string.Format("{0:yyMM}", GlobalVar.DateOfServer), 3, false, true);
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //DateTime a = Convert.ToDateTime(txtTglRelasi.DateValue);
                //if (Tools.isExpired7(a) == true)
                //{
                //    MessageBox.Show("Tanggal tidak valid");
                //    return;
                //}

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PembayaranHutangLokal_AntarPT_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowD));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, RowH));
                    db.Commands[0].Parameters.Add(new Parameter("@JnsPembayaranHutang", SqlDbType.Int, (int)cboJenisPembayaran.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@NoBuktiPmb", SqlDbType.VarChar, txtNoPembayaran.Text.Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@TglPembayaran", SqlDbType.DateTime, txtTglPembayaran.DateValue.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@TglRelasi", SqlDbType.Date, txtTglRelasi.DateValue.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@PembUSDAmount", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@PembOriginalAmount", SqlDbType.Money, txtIden.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@PembIDRAmount", SqlDbType.Money, txtIden.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@USDToIDRRate", SqlDbType.Money, 1));
                    db.Commands[0].Parameters.Add(new Parameter("@USDToOriRate", SqlDbType.Money, 1));
                    db.Commands[0].Parameters.Add(new Parameter("@TglKonfirmasi", SqlDbType.DateTime, SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@PengeluaranUangRowID", SqlDbType.UniqueIdentifier, drT["PengeluaranUangRowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@KoreksiBeliRowID", SqlDbType.UniqueIdentifier, drT["KoreksiBeliRowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, drT["MataUangRowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@PmbReferensi", SqlDbType.VarChar, drT["PmbReferensi"].ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@KeteranganPmbHutang", SqlDbType.VarChar, txtKet.Text.Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@KeteranganKonfirmasi", SqlDbType.VarChar, string.Empty));
                    db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@HiRowID", SqlDbType.UniqueIdentifier, drT["HiRowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@ReturBeliRowID", SqlDbType.UniqueIdentifier, drT["ReturBeliRowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@KoreksiReturBeliRowID", SqlDbType.UniqueIdentifier, drT["KoreksiReturBeliRowID"]));
                    //db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, drT["PerusahaanDariRowID"]));
                    db.Commands[0].ExecuteNonQuery();
                }

                RefreshGrid();
                this.Close();
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

        private void RefreshGrid()
        {
            if (this.Caller is frmDaftarHutangLokal)
            {
                frmDaftarHutangLokal frmCaller = (frmDaftarHutangLokal)this.Caller;
                frmCaller.RefreshRowDataGridDetail(RowD, RowH);
            }
        }
    }
}
