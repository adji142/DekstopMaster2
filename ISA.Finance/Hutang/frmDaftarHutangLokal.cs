using System.Data.SqlTypes;
using System;
using System.Data;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;


namespace ISA.Finance.Hutang
{
    public partial class frmDaftarHutangLokal : ISA.Controls.BaseForm
    {

        string _InvoiceHeaderRowID, _InvoiceNo;
        bool _statusLunas = false;
        DataTable dtHeader = new DataTable();
        DataTable dtDetail = new DataTable();
        DataTable dtDetail2 = new DataTable();
        DataTable dtDetail4 = new DataTable();
        Guid PemasokRowID;
        string KodePemasok = string.Empty;
        
        public void fillComboBoxVendor()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Vendor_LIST_V2"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                //dt.DefaultView.Sort = "VendorID";
                dt.DefaultView.Sort = "NamaVendor";
                //dt.DefaultView.RowFilter = "IsAktif = True ";
                //comBoxVendor.DisplayMember = "VendorID";
                comBoxVendor.DisplayMember = "NamaVendor";
                comBoxVendor.ValueMember = "RowID";
                //comBoxVendor.ValueMember = "VendorID";
                comBoxVendor.DataSource = dt.DefaultView;
                //KodePemasok = comBoxVendor.SelectedValue.ToString();
                PemasokRowID = (Guid)comBoxVendor.SelectedValue;

                //cboSupplier.DisplayMember = "NamaVendor";
                //cboSupplier.ValueMember = "VendorID";
                //cboSupplier.DataSource = dt.DefaultView;
                //KodePemasok = cboSupplier.SelectedValue.ToString();
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

        public void RefreshDataDaftarHutang()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_DaftarHutangLokal_LIST_FILTER_StatusLunas"));
                    db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, (Guid)comBoxVendor.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@StatusLunas", SqlDbType.Bit, _statusLunas));
                    dtHeader = db.Commands[0].ExecuteDataTable();

                }
                dtHeader.DefaultView.Sort = "TglInvoice DESC,InvoiceNo";
                dgDaftarHutang.DataSource = dtHeader.DefaultView;

                if (dgDaftarHutang.SelectedCells.Count > 0)
                {
                    _InvoiceHeaderRowID = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
                    RefreshDataPembayaranHutang(new Guid(_InvoiceHeaderRowID));
                    txtSaldoIDR.Text = Convert.ToDouble(dtHeader.Compute("Sum(SisaHutangIDR)", "")).ToString();
                }
                else
                {
                    dtDetail.Clear();
                    dgListPembayaranHutang.DataSource = dtDetail.DefaultView;

                    dtDetail2.Clear();
                    dgBlmIden.DataSource = dtDetail2.DefaultView;
                    txtSaldoIDR.Text = "0";
                    dtDetail4.Rows.Clear();
                }

                if (txtSuppName.Text == "SASS11")
                {
                    cmdADD.Enabled = false;
                    cmdEDIT.Enabled = false;
                    cmdDELETE.Enabled = false;
                    cmdHide.Enabled = false;
                }
                else
                {
                    cmdADD.Enabled = true;
                    cmdEDIT.Enabled = true;
                    cmdDELETE.Enabled = true;
                    cmdHide.Enabled = true;
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        public void RefreshRowDataGridHeader(Guid rowID_)
        {
            DataTable dt = new DataTable();
            DataTable dtRefresh;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_DaftarHutangLokal_LIST_FILTER_StatusLunas"));
                db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, (Guid)comBoxVendor.SelectedValue));
                db.Commands[0].Parameters.Add(new Parameter("@StatusLunas", SqlDbType.Bit, _statusLunas));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                dgDaftarHutang.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID_.ToString());
                dgDaftarHutang.FindRow("RowID", rowID_.ToString());
                dtHeader.AcceptChanges();
                txtSaldoIDR.Text = Convert.ToDouble(dtHeader.Compute("Sum(SisaHutangIDR)", "")).ToString();

            }
            else
            {
                txtSaldoIDR.Text = "0";
            }
        }

        public void RefreshDataPembayaranHutang(Guid headerID_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                cmdHide.Visible = false;
                if (tabControl1.SelectedIndex == 0)
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_PembayaranHutangLokal_LIST_FILTER_NoInvoice"));
                        db.Commands[0].Parameters.Add(new Parameter("@InvoiceRowID", SqlDbType.UniqueIdentifier, headerID_));
                        dtDetail = db.Commands[0].ExecuteDataTable();
                    }
                    dtDetail.DefaultView.Sort = "TglPembayaran";
                    dgListPembayaranHutang.DataSource = dtDetail.DefaultView;

                    if (dtDetail.Rows.Count > 0)
                    {
                        txtTPembayaran.Text = Convert.ToDouble(dtDetail.Compute("SUM(PembIDRAmount)", "")).ToString();
                    }
                    else
                    {

                        txtTPembayaran.Text = "0";

                    }
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    string Local = "usp_DaftarUangMukaBlmIdentifikasiLokal";
                    string Import = "usp_DaftarUangMukaBlmIdentifikasiLokal_FromImport";
                    string spp = "";
                    string RowID_ = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
                    DataRow[] drH = dtHeader.Select("RowID='" + RowID_ + "'");

                    if (IsImportToLocal((Guid)drH[0]["PLRowID"]))
                    {
                        spp = Import;
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_DaftarUangMukaBlmIdentifikasiLokal_FromImport"));
                            db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, SqlGuid.Null));
                            db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanID));
                            db.Commands[0].Parameters.Add(new Parameter("@IsHide", SqlDbType.Bit, 0));
                            dtDetail2 = db.Commands[0].ExecuteDataTable();
                        }
                    }
                    else
                    {
                        spp = Local;
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_DaftarUangMukaBlmIdentifikasi"));
                            db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, (Guid)comBoxVendor.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanID));
                            db.Commands[0].Parameters.Add(new Parameter("@IsHide", SqlDbType.Bit, 0));
                            dtDetail2 = db.Commands[0].ExecuteDataTable();
                        }

                    }

                    dtDetail2.DefaultView.Sort = "Tanggal";
                    dgListPembayaranHutang.DataSource = dtDetail2.DefaultView;
                    cmdHide.Text = "hide";
                    cmdHide.Visible = true;
                }
                else if (tabControl1.SelectedIndex == 2)
                {
                    string Local = "usp_DaftarUangMukaBlmIdentifikasiLokal";
                    string Import = "usp_DaftarUangMukaBlmIdentifikasiLokal_FromImport";
                    string spp = "";
                    string RowID_ = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
                    DataRow[] drH = dtHeader.Select("RowID='" + RowID_ + "'");

                    if (IsImportToLocal((Guid)drH[0]["PLRowID"]))
                    {
                        spp = Import;
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_DaftarUangMukaBlmIdentifikasiLokal_FromImport"));
                            db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, SqlGuid.Null));
                            db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanID));
                            db.Commands[0].Parameters.Add(new Parameter("@IsHide", SqlDbType.Bit, 1));
                            dtDetail4 = db.Commands[0].ExecuteDataTable();
                        }
                    }
                    else
                    {
                        spp = Local;
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_DaftarUangMukaBlmIdentifikasi"));
                            db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, (Guid)comBoxVendor.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanID));
                            db.Commands[0].Parameters.Add(new Parameter("@IsHide", SqlDbType.Bit, 1));
                            dtDetail4 = db.Commands[0].ExecuteDataTable();
                        }

                    }

                    dtDetail4.DefaultView.Sort = "Tanggal";
                    GVSudahIdent.DataSource = dtDetail2.DefaultView;
                    cmdHide.Text = "Show";
                    cmdHide.Visible = true;
                }

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }


        }

        public void RefreshRowDataGridDetail(Guid RowID_, Guid Header_)
        {
            DataTable dt = new DataTable();
            DataTable dtRefresh;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PembayaranHutangLokal_LIST_FILTER_NoInvoice"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                RefreshRowDataGridHeader(Header_);
                dgListPembayaranHutang.RefreshDataRow(dtRefresh.Rows[0], "RowID", RowID_.ToString());
                dgListPembayaranHutang.FindRow("PmbRowID", RowID_.ToString());
                dtDetail.AcceptChanges();

                txtTPembayaran.Text = Convert.ToDouble(dtDetail.Compute("SUM(PembIDRAmount)", "")).ToString();
            }
            else
            {
                txtTPembayaran.Text = "0";
            }

        }

        public void deletePabrik()
        {
            Guid rowID = (Guid)dgDaftarHutang.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            string NoBukti = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["InvoiceNo"].Value.ToString();
            if (MessageBox.Show("Hapus Invoice :  " + NoBukti + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_HutangPembelian_Delete"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    int i = 0;
                    int n = 0;
                    i = dgDaftarHutang.SelectedCells[0].RowIndex;
                    n = dgDaftarHutang.SelectedCells[0].ColumnIndex;
                    DataRowView dv = (DataRowView)dgDaftarHutang.SelectedCells[0].OwningRow.DataBoundItem;
                    DataRow dr = dv.Row;
                    dr.Delete();
                    dtHeader.AcceptChanges();
                    dgDaftarHutang.Focus();
                    if (dgDaftarHutang.RowCount > 0)
                    {
                        if (i == 0)
                        {
                            dgDaftarHutang.CurrentCell = dgDaftarHutang.Rows[0].Cells[n];
                            dgDaftarHutang.RefreshEdit();
                        }
                        else
                        {
                            dgDaftarHutang.CurrentCell = dgDaftarHutang.Rows[i - 1].Cells[n];
                            dgDaftarHutang.RefreshEdit();
                        }
                        txtSaldoIDR.Text = Convert.ToDouble(dtHeader.Compute("Sum(SisaHutangIDR)", "")).ToString();
                    }
                    else
                    {
                        txtSaldoIDR.Text = "0";
                        txtTPembayaran.Text = "0";
                        dtDetail.Rows.Clear();


                    }


                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void deleteData()
        {

            Guid rowID = (Guid)dgListPembayaranHutang.SelectedCells[0].OwningRow.Cells["PmbRowID"].Value;
            Guid HeaderID_ = (Guid)dgListPembayaranHutang.SelectedCells[0].OwningRow.Cells["HeaderID"].Value;
            string NoBukti = dgListPembayaranHutang.SelectedCells[0].OwningRow.Cells["NoBukti"].Value.ToString();
            if (MessageBox.Show("Hapus Pembayaran  " + NoBukti + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_PembayaranHutang_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    int i = 0;
                    int n = 0;
                    i = dgListPembayaranHutang.SelectedCells[0].RowIndex;
                    n = dgListPembayaranHutang.SelectedCells[0].ColumnIndex;
                    DataRowView dv = (DataRowView)dgListPembayaranHutang.SelectedCells[0].OwningRow.DataBoundItem;
                    DataRow dr = dv.Row;
                    dr.Delete();
                    dtDetail.AcceptChanges();
                    dgListPembayaranHutang.Focus();
                    if (dgListPembayaranHutang.RowCount > 0)
                    {
                        if (i == 0)
                        {
                            dgListPembayaranHutang.CurrentCell = dgListPembayaranHutang.Rows[0].Cells[n];
                            dgListPembayaranHutang.RefreshEdit();
                        }
                        else
                        {
                            dgListPembayaranHutang.CurrentCell = dgListPembayaranHutang.Rows[i - 1].Cells[n];
                            dgListPembayaranHutang.RefreshEdit();
                        }
                        txtTPembayaran.Text = Convert.ToDouble(dtDetail.Compute("SUM(PembIDRAmount)", "")).ToString();
                    }
                    else
                    {
                        txtTPembayaran.Text = "0";
                    }
                    RefreshRowDataGridHeader(HeaderID_);

                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }

        }


        private bool IsImportToLocal(Guid PlRowID_)
        {
            bool iya = false;

            int Count = 0;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[fsp_CekImportToLocal]"));
                db.Commands[0].Parameters.Add(new Parameter("@PLRowID", SqlDbType.UniqueIdentifier, PlRowID_));
                Count = (Int32)db.Commands[0].ExecuteScalar();

            }
            if (Count > 0)
            {
                iya = true;
            }

            return iya;

        }

        private bool ReFlagPembayaran(Guid RowID_, int flag_, string noBkti_)
        {
            bool val = false;

            if (MessageBox.Show("Ubah  " + noBkti_ + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_UPDATE_IsHideIden"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                        db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.Bit, flag_));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    val = true;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                    val = false;
                }
                return val;
            }
            return val;
        }

        public frmDaftarHutangLokal()
        {
            InitializeComponent();
        }

        private void frmDaftarHutangLokal_Load(object sender, EventArgs e)
        {
            fillComboBoxVendor();
            cboStatusLunas.SelectedIndex = 0;
            btnSubmit.PerformClick();

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comBoxVendor.Text.ToString()))
            {
                MessageBox.Show("Nama Supplier belum diisi");
                return;
            }
            if (string.IsNullOrEmpty(cboStatusLunas.Text.ToString()))
            {
                _statusLunas = false;
                cboStatusLunas.Text = "Belum Lunas";
            }

            if (cboStatusLunas.Text == "Belum Lunas")
            {
                _statusLunas = false;
            }
            else
            {
                _statusLunas = true;
            }


            try
            {
                RefreshDataDaftarHutang();
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void comBoxVendor_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comBoxVendor.DataSource != null)
            {
                DataRowView dv = (DataRowView)comBoxVendor.Items[comBoxVendor.SelectedIndex];
                txtSuppName.Text = dv.Row["NamaVendor"].ToString();
                btnSubmit.PerformClick();

                if (txtSuppName.Text == "KP-PSHO")
                {
                    cmdADD.Enabled = false;
                    cmdEDIT.Enabled = false;
                    cmdDELETE.Enabled = false;
                    cmdHide.Enabled = false;
                }
                else
                {
                    cmdADD.Enabled = true;
                    cmdEDIT.Enabled = true;
                    cmdDELETE.Enabled = true;
                    cmdHide.Enabled = true;
                }
            }
        }

        private void cmdLinkInvoiceKehutang_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtp = new DataTable();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetKodePemasok"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)comBoxVendor.SelectedValue));
                    dtp = db.Commands[0].ExecuteDataTable();
                }
                if (dtp.Rows.Count > 0)
                {
                    //KodePemasok = Tools.isNull(dtp.Rows[0]["KodePemasok"], "").ToString();
                    KodePemasok = Tools.isNull(dtp.Rows[0]["PemasokID"], "").ToString();
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

            Hutang.frmLinkInvoiceKeHutangLokal ifrmChild = new frmLinkInvoiceKeHutangLokal(this, new Guid(comBoxVendor.SelectedValue.ToString()));
            ifrmChild.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgDaftarHutang.SelectedCells.Count > 0)
            {
                string Flag_ = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["Flag"].Value.ToString();

                if (Flag_.Equals("PABRIK"))
                {
                    MessageBox.Show("Non Pabrik Only !!!");
                    return;
                }
                string Category_ = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["Category"].Value.ToString();
                if (Category_.ToUpper().Equals("LUNAS"))
                {
                    MessageBox.Show("Sudah Lunas");
                    return;
                }
                string rowID_ = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
                DataRow[] dr = dtHeader.Select("RowID='" + rowID_ + "'");
                Hutang.frmLinkInvoiceKeHutangManualLokal ifrmChild = new Hutang.frmLinkInvoiceKeHutangManualLokal(this, dr[0], "1");
                ifrmChild.ShowDialog();
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void dgDaftarHutang_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dgDaftarHutang.SelectedCells.Count > 0)
            {
                _InvoiceHeaderRowID = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
                _InvoiceNo = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["InvoiceNo"].Value.ToString();

                string lable = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["Lable"].Value.ToString();
                //cmdLinkInvoicePerNoBukti.Text = lable;
                RefreshDataPembayaranHutang(new Guid(_InvoiceHeaderRowID.ToString()));
            }
        }

        private void cmdLinkInvoicePerNoBukti_Click(object sender, EventArgs e)
        {
            if (dgDaftarHutang.SelectedCells.Count > 0)
            {
                double Sisa = Convert.ToDouble(Tools.isNull(dgDaftarHutang.SelectedCells[0].OwningRow.Cells["SisaHutangIDR"].Value, 0).ToString());
                if (Sisa != 0)
                {
                    MessageBox.Show("Masih ada Saldo Hutang..!");
                    return;
                }

                Guid rowID = (Guid)dgDaftarHutang.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                string NoBukti = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["InvoiceNo"].Value.ToString();
                string lable = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["Lable"].Value.ToString();
                if (MessageBox.Show("Invoice  " + NoBukti + " ?", lable, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_HutangPembelian_UPDATE_StatusLunas"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.Bit, lable == "Lunas" ? 1 : 0));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        int i = 0;
                        int n = 0;
                        i = dgDaftarHutang.SelectedCells[0].RowIndex;
                        n = dgDaftarHutang.SelectedCells[0].ColumnIndex;
                        DataRowView dv = (DataRowView)dgDaftarHutang.SelectedCells[0].OwningRow.DataBoundItem;
                        DataRow dr = dv.Row;
                        dr.Delete();
                        dtHeader.AcceptChanges();

                        dgDaftarHutang.Focus();
                        if (dgDaftarHutang.RowCount > 0)
                        {
                            if (i == 0)
                            {
                                dgDaftarHutang.CurrentCell = dgDaftarHutang.Rows[0].Cells[n];
                                dgDaftarHutang.RefreshEdit();
                            }
                            else
                            {
                                dgDaftarHutang.CurrentCell = dgDaftarHutang.Rows[i - 1].Cells[n];
                                dgDaftarHutang.RefreshEdit();
                            }
                            txtSaldoIDR.Text = Convert.ToDouble(dtHeader.Compute("Sum(SisaHutangIDR)", "")).ToString();

                        }
                        else
                        {
                            dtDetail.Clear();
                            dgListPembayaranHutang.DataSource = dtDetail.DefaultView;

                            dtDetail2.Clear();
                            dgBlmIden.DataSource = dtDetail2.DefaultView;

                            txtSaldoIDR.Text = "0";

                        }


                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {


            if (dgDaftarHutang.SelectedCells.Count > 0)
            {
                string Flag_ = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["Flag"].Value.ToString();
                if (Flag_.Equals("SAP"))
                {
                    if (dgListPembayaranHutang.RowCount > 0)
                    {
                        MessageBox.Show("Sudah ada pembayaran, hapus detail terlebih dahulu !!!");
                        return;

                    }

                }

                string Category_ = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["Category"].Value.ToString();
                if (Category_.ToUpper().Equals("LUNAS"))
                {
                    MessageBox.Show("Sudah Lunas");
                    return;
                }
                deletePabrik();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgDaftarHutang.SelectedCells.Count > 0)
            {
                string Flag_ = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["Flag"].Value.ToString();

                //tutup untuk input saldo awal Hutang Dagang PS
                //if (Flag_.Equals("SAP"))
                //{
                //    MessageBox.Show("Pabrik Only !!!");
                //    return;
                //}
                string Category_ = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["Category"].Value.ToString();
                if (Category_.ToUpper().Equals("LUNAS"))
                {
                    MessageBox.Show("Sudah Lunas");
                    return;
                }
                string rowID_ = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();

                DataRow[] dr = dtHeader.Select("RowID='" + rowID_ + "'");
                Hutang.frmLinkInvoiceKeHutangManualLokal ifrmChild = new Hutang.frmLinkInvoiceKeHutangManualLokal(this, dr[0], "2");
                ifrmChild.ShowDialog();
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            if (dgListPembayaranHutang.SelectedCells.Count > 0 && tabControl1.SelectedIndex == 0)
            {
                string Category_ = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["Category"].Value.ToString();
                if (Category_.ToUpper().Equals("LUNAS"))
                {
                    MessageBox.Show("Sudah Lunas");
                    return;
                }
                
                DateTime _tglPembayaran = (DateTime)Tools.isNull(dgListPembayaranHutang.SelectedCells[0].OwningRow.Cells["TglPembayaran"].Value, DBNull.Value);

                /*validasi closing stok*/
                if (!ValidasiTanggalTerima(_tglPembayaran))
                {
                    MessageBox.Show("Sudah Closing, tidak bisa dihapus.");
                    return;
                }

                /*validasi TglTerima tidak boleh mundur ke bulan sebelumnya*/
                DateTime dTglawal;
                dTglawal = DateTime.Today.AddDays((GlobalVar.DateTimeOfServer.Day * -1) + 1);

                if (_tglPembayaran < dTglawal)
                {
                    MessageBox.Show("Tidak bisa Hapus data bulan sebelumnya.");
                    return;
                }
                deleteData();
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private bool ValidasiTanggalTerima(DateTime TanggalTerima)
        {
            Boolean result = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtc = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_LastClosingStok_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@tipe", SqlDbType.VarChar, "STK"));
                    dtc = db.Commands[0].ExecuteDataTable();
                }
                if (dtc.Rows.Count > 0)
                {
                    DateTime TglClosingSTK = (DateTime)Tools.isNull(dtc.Rows[0]["TglAkhir"], "");
                    string cTglcls = TglClosingSTK.ToString("dd/MM/yyyy");
                    DateTime dTglcls = DateTime.ParseExact(cTglcls, "dd/MM/yyyy", null);
                    DateTime TglTerimaPB = TanggalTerima;
                    string cTglTrm = TglTerimaPB.ToString("dd/MM/yyyy");
                    DateTime dTglTrm = DateTime.ParseExact(cTglTrm, "dd/MM/yyyy", null);
                    if (dTglTrm <= dTglcls)
                    {
                        result = false;
                    }
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
            return result;
        }


        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (dgListPembayaranHutang.SelectedCells.Count > 0 && tabControl1.SelectedIndex == 0)
            {
                string Category_ = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["Category"].Value.ToString();
                if (Category_.ToUpper().Equals("LUNAS"))
                {
                    MessageBox.Show("Sudah Lunas");
                    return;
                }


                string rowID_ = dgListPembayaranHutang.SelectedCells[0].OwningRow.Cells["PmbRowID"].Value.ToString();
                string HeaderID_ = dgListPembayaranHutang.SelectedCells[0].OwningRow.Cells["HeaderID"].Value.ToString();
                DataRow[] dr = dtHeader.Select("RowID='" + HeaderID_ + "'");
                DataRow[] drd = dtDetail.Select("RowID='" + rowID_ + "'");
                //Keuangan.Hutang.frmPembayaranHutangLokal_n ifrmChild = new Keuangan.Hutang.frmPembayaranHutangLokal_n(this, dr[0], drd[0]);
                //ifrmChild.MdiParent = Program.MainForm;
                //Program.MainForm.RegisterChild(ifrmChild);
                //ifrmChild.Show();
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            if (dgDaftarHutang.SelectedCells.Count > 0 && tabControl1.SelectedIndex == 0)
            {
                double Sisa = Convert.ToDouble(Tools.isNull(dgDaftarHutang.SelectedCells[0].OwningRow.Cells["SisaHutangIDR"].Value, 0).ToString());
                if (Sisa == 0)
                {
                    MessageBox.Show("Nota ini sudah tidak mempunyai Saldo Hutang");
                    return;
                }

                string Category_ = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["Category"].Value.ToString();
                if (Category_.ToUpper().Equals("LUNAS"))
                {
                    MessageBox.Show("Sudah Lunas");
                    return;
                }
                string RowID_ = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
                DataRow[] dr = dtHeader.Select("RowID='" + RowID_ + "'");
                Hutang.frmPembayaranHutangLokal_n ifrmChild = new Hutang.frmPembayaranHutangLokal_n(this, dr[0], "1");

                //Guid vrid = new Guid(dtHeader.Rows[0]["VendorRowID"].ToString());
                //DataRow[] dr = dtHeader.Select("VendorRowID='" + vrid + "'");
                //Hutang.frmPembayaranHutangLokal_n ifrmChild = new Hutang.frmPembayaranHutangLokal_n(this, dr[0], "1");
                
                
                ifrmChild.ShowDialog();


            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdHide_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1 && dgBlmIden.SelectedCells.Count > 0)
            {
                Guid RowID_ = (Guid)dgBlmIden.SelectedCells[0].OwningRow.Cells["PengeluaranUangRowID"].Value;
                string BK = dgBlmIden.SelectedCells[0].OwningRow.Cells["dataGridViewTextBoxColumn3"].Value.ToString();
                if (ReFlagPembayaran(RowID_, 1, BK))
                {
                    dgBlmIden.Rows.Remove(dgBlmIden.SelectedCells[0].OwningRow);
                }

            }
            else if (tabControl1.SelectedIndex == 2 && GVSudahIdent.SelectedCells.Count > 0)
            {

                Guid RowID_ = (Guid)GVSudahIdent.SelectedCells[0].OwningRow.Cells["RowIDNotIden"].Value;
                string BK = GVSudahIdent.SelectedCells[0].OwningRow.Cells["dataGridViewTextBoxColumn6"].Value.ToString();
                if (ReFlagPembayaran(RowID_, 0, BK))
                {
                    GVSudahIdent.Rows.Remove(GVSudahIdent.SelectedCells[0].OwningRow);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string Flag_ = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["Flag"].Value.ToString();
            //string Category_ = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["Category"].Value.ToString();
            //if (Category_.ToUpper().Equals("LUNAS"))
            //{
            //    MessageBox.Show("Sudah Lunas");
            //    return;
            //}
            //string rowID_ = dgDaftarHutang.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
            //DataRow[] dr = dtHeader.Select("RowID='" + rowID_ + "'");
            //Hutang.frmLinkInvoiceKeHutangManualLokal ifrmChild = new Hutang.frmLinkInvoiceKeHutangManualLokal(this, dr[0], "1");
            //ifrmChild.ShowDialog();

            //Hutang.frmDaftarHutangManualLokal_SaldoAwal ifrmChild = new Hutang.frmDaftarHutangManualLokal_SaldoAwal();
            //ifrmChild.ShowDialog();
        }

    }
}
