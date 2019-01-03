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
    public partial class frmLinkInvoiceKeHutangLokal : ISA.Controls.BaseForm
    {
        Guid _VendorRowID;
        DataTable dt = new DataTable();
        List<Guid> ListPLGuid = new List<Guid>();
        bool flagIDR = false;
        
        public void RefreshData()
        {
            try
            {
               this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_LinkInvoiceKeHutangLokal_LIST_n"));
                    db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, _VendorRowID ));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dt.DefaultView.Sort = "TglInvoice DESC";
                dgListInvoiceKeHutang.ReadOnly = false;

                foreach (DataGridViewColumn col in dgListInvoiceKeHutang.Columns)
                {
                    col.ReadOnly = true;
                }
                dgListInvoiceKeHutang.Columns["Checked"].ReadOnly = false;

                dgListInvoiceKeHutang.DataSource = dt.DefaultView;
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

        private void RefreshGrid(Guid _RowID)
        {
            if (this.Caller is frmDaftarHutangLokal)
            {

                frmDaftarHutangLokal frmCaller = (frmDaftarHutangLokal)this.Caller;
                frmCaller.RefreshRowDataGridHeader(_RowID);
            }
        }

        public void SaveData()
        {


            DataTable dtT = dt.DefaultView.ToTable(true, "RowID", "ok");
            dtT.DefaultView.RowFilter = "ok=true or ok=1";
            if (dtT.DefaultView.Count == 0)
            {
                throw new Exception("Tak Ada Data yang di pilih");
            }
            if (flagIDR)
            {
                MessageBox.Show("Data IDR 0 Tidak Bisa di Simpan");
            }

            DataTable dtI = dt.Clone();

            DataTable dtOK = dtT.DefaultView.ToTable(true, "RowID");

            foreach (DataRow dr in dtOK.Rows)
            {
                DataRow[] drr = dt.Select("RowID = '" + dr[0].ToString() + "'");

                foreach (DataRow dr1 in drr)
                {
                    using (Database db = new Database())
                    {
                        Guid gg;
                        gg = Guid.NewGuid();
                        ListPLGuid.Add(gg);

                        Guid _HutangRowID = (Guid)dr1["RowID"];
                        db.Commands.Add(db.CreateCommand("[usp_HutangPembelianLokal_INSERT_N]"));

                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dr1["RowID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@BLHeaderRowID", SqlDbType.UniqueIdentifier, SqlGuid.Null));
                        db.Commands[0].Parameters.Add(new Parameter("@InvoiceHeaderRowID", SqlDbType.UniqueIdentifier, SqlGuid.Null));
                        db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, dr1["VendorRowID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@PLRowID", SqlDbType.UniqueIdentifier, dr1["RowID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.UniqueIdentifier, dr1["MataUangRowID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@TglInvoice", SqlDbType.DateTime, Convert.ToDateTime(dr1["TglInvoice"])));
                        db.Commands[0].Parameters.Add(new Parameter("@InvoiceNo", SqlDbType.VarChar, dr1["InvoiceNo"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Import", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@StatusLunas", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@IsMultyCurrency", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@IsMultyVendor", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@OriginalMataUang", SqlDbType.VarChar, dr1["MataUangID"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@OriginalAmount", SqlDbType.Money, dr1["IDRNominalNetto"]));
                        db.Commands[0].Parameters.Add(new Parameter("@USDAmount", SqlDbType.Money, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@IDRAmount", SqlDbType.Money, dr1["IDRNominalNetto"]));
                        db.Commands[0].Parameters.Add(new Parameter("@Potongan", SqlDbType.Money, dr1["Potongan"]));
                        db.Commands[0].Parameters.Add(new Parameter("@Komisi", SqlDbType.Money, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@NilaiTambahan", SqlDbType.Money, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }

        public frmLinkInvoiceKeHutangLokal()
        {
            InitializeComponent();
        }

        public frmLinkInvoiceKeHutangLokal(Form caller, Guid selectedSupplier)
        {
            InitializeComponent();
            _VendorRowID = selectedSupplier;
            this.Caller = caller;
        }


        private void frmLinkInvoiceKeHutangLokal_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                SaveData();
                foreach (Guid gg in ListPLGuid)
                {
                    RefreshGrid(gg);
                }
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

        

        private void dgListInvoiceKeHutang_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                flagIDR = false;
                if (dgListInvoiceKeHutang.SelectedCells.Count > 0)
                {
                    if (Convert.ToDouble(dgListInvoiceKeHutang.Rows[e.RowIndex].Cells["IDRNominal"].Value) == 0)
                    {

                        DataRowView dv = (DataRowView)dgListInvoiceKeHutang.SelectedCells[0].OwningRow.DataBoundItem;
                        DataRow dr = dv.Row;
                        dr.BeginEdit();
                        dr["ok"] = false;
                        dr.EndEdit();
                        dt.AcceptChanges();
                        dgListInvoiceKeHutang.Rows[e.RowIndex].Cells["Checked"].Value = false;
                        flagIDR = true;

                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


    }
}
