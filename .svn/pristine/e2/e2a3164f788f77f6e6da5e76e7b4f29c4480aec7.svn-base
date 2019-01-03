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

namespace ISA.Trading.Penjualan
{
    public partial class frmBatalDO : ISA.Trading.BaseForm
    {
        DataTable dtNotaJual;
        DataGridViewRow dtRow;

        public frmBatalDO(Form caller, DataGridViewRow dt)
        {
            InitializeComponent();
            dtRow = dt;
            this.Caller = caller;
        }

        private void frmBatalDO_Load(object sender, EventArgs e)
        {
            if (dtRow.Cells["StatusBatal"].Value.ToString().Contains("BATAL"))
            {
                rdbCancel.Visible = true;
            }
            else
            {
                rdbCancel.Visible = false;
            }
            
        }

        private void cmdYES_Click(object sender, EventArgs e)
        {
            Guid _doID = (Guid)dtRow.Cells["RowID"].Value;
            dtNotaJual = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_DOID")); //udah heri cek
                db.Commands[0].Parameters.Add(new Parameter("@doID", SqlDbType.UniqueIdentifier, _doID));
                dtNotaJual = db.Commands[0].ExecuteDataTable();
            }

            if (dtNotaJual.Rows.Count > 0)
            {
                MessageBox.Show("DO ini sudah memiliki nota dan tidak boleh BATAL","Peringatan",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
            else
            {
                string batal = "";
                if (rdoStok.Checked == true)
                    batal = "BATAL01";
                if (rdoPiutang.Checked == true)
                    batal = "BATAL02";
                if (rdoPenjualan.Checked == true)
                    batal = "BATAL03";
                if (rdbCancel.Checked == true)
                    batal = "";
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_UPDATE")); //udah cek heri
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dtRow.Cells["RowID"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, dtRow.Cells["HtrID"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, dtRow.Cells["Cabang1"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, dtRow.Cells["Cabang2"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang3", SqlDbType.VarChar, dtRow.Cells["Cabang3"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@NoRequest", SqlDbType.VarChar, dtRow.Cells["NoRequest"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@TglRequest", SqlDbType.DateTime, dtRow.Cells["TglRequest"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@NoDO", SqlDbType.VarChar, dtRow.Cells["NoDO"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@TglDO", SqlDbType.DateTime, dtRow.Cells["TglDO"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@NoACCPusat", SqlDbType.VarChar, batal.Contains("BATAL")? "BATAL00":""));
                        db.Commands[0].Parameters.Add(new Parameter("@ACCPiutangID", SqlDbType.VarChar, dtRow.Cells["ACCPiutangID"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@NoACCPiutang", SqlDbType.VarChar, dtRow.Cells["NoACCPiutang"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@TglACCPiutang", SqlDbType.DateTime, dtRow.Cells["TglACCPiutang"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@StatusBatal", SqlDbType.VarChar, batal));
                        db.Commands[0].Parameters.Add(new Parameter("@HariKredit", SqlDbType.Int, dtRow.Cells["HariKredit"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, dtRow.Cells["KodeToko"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, dtRow.Cells["KodeSales"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@StsToko", SqlDbType.VarChar, dtRow.Cells["StsToko"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@AlamatKirim", SqlDbType.VarChar, dtRow.Cells["AlamatKirim"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, dtRow.Cells["Kota"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, dtRow.Cells["DiscFormula"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@Disc1", SqlDbType.Decimal, dtRow.Cells["Disc1"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@Disc2", SqlDbType.Decimal, dtRow.Cells["Disc2"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@Disc3", SqlDbType.Decimal, dtRow.Cells["Disc3"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, dtRow.Cells["isClosed"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan1", SqlDbType.VarChar, dtRow.Cells["Catatan1"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan2", SqlDbType.VarChar, dtRow.Cells["Catatan2"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan3", SqlDbType.VarChar, dtRow.Cells["Catatan3"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan4", SqlDbType.VarChar, dtRow.Cells["Catatan4"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan5", SqlDbType.VarChar, dtRow.Cells["Catatan5"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@NoDOBO", SqlDbType.VarChar, dtRow.Cells["NoDOBO"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@TglReorder", SqlDbType.DateTime, dtRow.Cells["TglReorder"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@StatusBO", SqlDbType.Bit, dtRow.Cells["StatusBO"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, dtRow.Cells["LinkID"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, dtRow.Cells["TransactionType"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@Expedisi", SqlDbType.VarChar, dtRow.Cells["Expedisi"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int, dtRow.Cells["HariKirim"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, dtRow.Cells["HariSales"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, dtRow.Cells["NPrint"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    MessageBox.Show("Data telah tersimpan");
                    this.DialogResult = DialogResult.OK;
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
        }

        private void cmdCANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBatalDO_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                TabelDO frmCaller = (TabelDO)this.Caller;
                frmCaller.RefreshDataDO();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
