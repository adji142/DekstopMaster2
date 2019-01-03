using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Data.SqlClient;


namespace ISA.Trading.PO
{
    public partial class frmJadwalPO : ISA.Trading.BaseForm
    {
        DataTable dt;
        public frmJadwalPO()
        {
            InitializeComponent();
        }

        private void frmJadwalPO_Load(object sender, EventArgs e)
        {
            this.Title = "Tabel Schedule PO";
            this.Text = "PO";

            txtCatatan.ReadOnly = true;
            txtJadwalXpdc.ReadOnly = true;
            txtJadwalPo.ReadOnly = true;
            

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_POJadwal"));
                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                dt = db.Commands[0].ExecuteDataTable();
            }
            customGridView1.DataSource = dt;
            customGridView1.Focus();
            txtJadwalPo.Text = dt.Rows[0]["hari_po"].ToString();
            txtJadwalXpdc.Text = dt.Rows[0]["hari_xpdc"].ToString();
            txtCatatan.Text = dt.Rows[0]["catatan"].ToString();
            cbKodeGdg.Text = dt.Rows[0]["kd_gdg"].ToString();

            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DataSet GetSyncData()
        {
            DataSet dsSync = new DataSet();
            DataTable dt1 = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_TanggalPO_ISA"));
                dt1 = db.Commands[0].ExecuteDataTable();
                dt1.TableName = "RefilPO_Jadwal";
                if (dt1.Rows.Count > 0)
                {
                    dsSync.Tables.Add(dt1);
                }
            }
            return dsSync;
        }

        public void _upload()
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                try
                {
                    DataSet dsSync = GetSyncData();
                    this.Cursor = Cursors.WaitCursor;
                    if (dsSync.Tables.Count > 0)
                    {
                        string pathString = @"c:\temp\upload";

                        if (!System.IO.Directory.Exists(pathString))
                        {
                            System.IO.Directory.CreateDirectory(pathString);
                        }
                        string Target = GlobalVar.Gudang;
                        string fileOuput = pathString + "\\" + "Jadwal_PO-" + DateTime.Now.ToString("yyyyMMdd hhmmss") + " " + Guid.NewGuid().ToString() + ".xml";
                        dsSync.WriteXml(fileOuput);
                        MessageBox.Show(Messages.Confirm.UploadSuccessful + "\n" + fileOuput);

                        //using (Database db = new Database())
                        //{
                        //    db.Commands.Clear();
                        //    db.Commands.Add(db.CreateCommand("psp_UPLOAD_JadwalPOUpdateSynchFlag_ISA"));
                        //    db.Commands[0].ExecuteDataTable();
                        //}
                    }
                    else
                    {
                        MessageBox.Show(Messages.Confirm.NoDataAvailable);
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
        }

        public void _download()
        {
            PO.frmJadwalDownload ifrmChild = new frmJadwalDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
            
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Mau Upload Jadwal PO & Pengiriman ?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _upload();
            }
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Mau download Jadwal PO & Pengiriman ??", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _download();
            }
        }
            
    }
}
