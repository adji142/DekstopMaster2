using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Common;
using ISA.DAL;
using ISA.FTP;

namespace ISA.Finance.Kasir
{
    public partial class frmBudgetUpload : ISA.Finance.BaseForm
    {
        public frmBudgetUpload()
        {
            InitializeComponent();
        }

        private void frmBudgetUpload_Load(object sender, EventArgs e)
        {
            dataGridView.AutoGenerateColumns = true;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            if (dataGridView.RowCount == 0)
            {
                MessageBox.Show("Tidak bisa upload record. Tidak ada data yang berubah. Hubungi Manager anda");
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = GetSyncData();

                if (ds.Tables.Count > 0)
                {
                    string fileOuput = FtpEngine.UploadDirectory + "\\" + "BudgetRencana-" + DateTime.Now.ToString("yyyyMMdd hhmmss") + " " + Guid.NewGuid().ToString() + ".xml";
                    ds.WriteXml(fileOuput);
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
                //DataTable dt = new DataTable();
                DataTable dt = (DataTable)dataGridView.DataSource;
                foreach (DataRow row in dt.Rows)
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("usp_Budget_UpdateSyncFlag"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, (Guid)row["RowID"]));
                        db.Commands[0].ExecuteDataTable();
                    }
                }
                //using (Database db = new Database(GlobalVar.DBName))
                //{
                //    db.Commands.Clear();
                //    db.Commands.Add(db.CreateCommand("usp_Budget_UpdateSyncFlag"));
                //    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, KodeGudang));
                //    dt = db.Commands[0].ExecuteDataTable();
                //}
                this.Cursor = Cursors.Default;
                MessageBox.Show("Upload budget rencana sudah selesai");
                //this.Close();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DataSet GetSyncData()
        {
            this.Cursor = Cursors.WaitCursor;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string InitPerusahaan = GlobalVar.PerusahaanID;
            string KodeGudang = GlobalVar.Gudang;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_Budget"));
                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, KodeGudang));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "BudgetRencana";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
            }
            this.Cursor = Cursors.Default;
            return ds;
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet dss = new DataSet();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Budget_Upload"));
                    dss = db.Commands[0].ExecuteDataSet();

                    dataGridView.DataSource = dss.Tables[0];

                    if (dataGridView.RowCount == 0)
                    {
                        MessageBox.Show("Tidak bisa upload record. Tidak ada data yang berubah. Hubungi Manager anda");
                        return;
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
        }
    }
}
