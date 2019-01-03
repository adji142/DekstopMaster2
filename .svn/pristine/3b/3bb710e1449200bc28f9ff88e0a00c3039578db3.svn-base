using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ISA.DAL;
using System.Windows.Forms;
using ISA.FTP;

namespace ISA.Trading.Rekon
{
    public partial class frmTokoDispen : ISA.Trading.BaseForm

    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        
        DataSet dsResult = new DataSet();
        DataTable dttkdispen;
        int counter1 = 0;

        public frmTokoDispen()
        {
            InitializeComponent();
        }

        private void frmTokoDispen_Load(object sender, EventArgs e)
        {
            refreshDataTokodispen();
        }

        public void refreshDataTokodispen()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dttkdispen = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Rekon_tokodispen"));
                    dttkdispen = db.Commands[0].ExecuteDataTable();
                    customGridView1.DataSource = dttkdispen;
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

        private void txtAlasan1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAlasan2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttmt1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttmt2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtgudang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                switch (formMode)
                {
                    case enumFormMode.New:
                        this.Cursor = Cursors.WaitCursor;

                        _rowID = Guid.NewGuid();
                        string _recID = Tools.CreateFingerPrint();

                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_Rekon_tokodispen_Insert"));
                            //db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@namatoko", SqlDbType.VarChar, txtNamaToko.NamaToko));
                            db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, txtNamaToko.KodeToko));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));;
                           // db.Commands[0].Parameters.Add(new Parameter("@kd_gdg", SqlDbType.VarChar, txtdrgdg.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtNamaToko.Alamat));
                            db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtNamaToko.Kota));
                            db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, txtNamaToko.Daerah));
                            db.Commands[0].Parameters.Add(new Parameter("@idwil", SqlDbType.VarChar, txtNamaToko.WilID));
                            db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, DateTime.Today));
                            db.Commands[0].Parameters.Add(new Parameter("@tmt2", SqlDbType.DateTime, DateTime.Today));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, txtAlasan1.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan2", SqlDbType.VarChar, txtAlasan2.Text));                 
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        refreshDataTokodispen();
                        break;
                        case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_Rekon_tokodispen_update"));
                            //db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@namatoko", SqlDbType.VarChar, txtNamaToko.NamaToko));
                            db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, txtNamaToko.KodeToko));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtNamaToko.Alamat));
                            db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtNamaToko.Kota));
                            db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, txtNamaToko.Daerah));
                            db.Commands[0].Parameters.Add(new Parameter("@idwil", SqlDbType.VarChar, txtNamaToko.WilID));
                            db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, DateTime.Today));
                            db.Commands[0].Parameters.Add(new Parameter("@tmt2", SqlDbType.DateTime, DateTime.Today));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, txtAlasan1.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan2", SqlDbType.VarChar, txtAlasan2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                MessageBox.Show("Data telah tersimpan");
                this.DialogResult = DialogResult.OK;
               // this.Close();
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

        private void txtNamaToko_SelectData(object sender, EventArgs e)
        {
            txtAlamat.Text = txtNamaToko.Alamat;
            txtKota.Text = txtNamaToko.Kota;
            txtDaerah.Text = txtNamaToko.Daerah;
            txtIdwil.Text = txtNamaToko.WilID;
        }

        private void txtNamaToko_Load(object sender, EventArgs e)
        {

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data akan dihapus...?", "Hapus Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    Guid _rowID = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Rekon_tokodispen_Delete"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.BeginTransaction();
                        db.Commands[0].ExecuteNonQuery();
                        db.CommitTransaction();
                    }

                    MessageBox.Show("Record telah dihapus");
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

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DataSet GetSyncData()
        {
            progressBar1.Value = 0;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            using (Database db = new Database())
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_SYNC_UPLOAD_TKDISPEN"));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "tokodispen";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    counter1++;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum= ds.Tables[0].Rows.Count;
                    
                    progressBar1.Increment(1);
                }
                return ds;
            }
        }
        
        private void cmdUpload_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = GetSyncData();

                if (ds.Tables.Count > 0)
                {
                    {
                        string pathString = @"c:\temp\upload";
                        if (!System.IO.Directory.Exists(pathString))
                        {
                            System.IO.Directory.CreateDirectory(pathString);
                        }

                        string fileOuput = pathString + "\\" + "TKD-" + DateTime.Now.ToString("yyyyMMdd hhmmss") + " " + Guid.NewGuid().ToString() + ".xml";

                        ds.WriteXml(fileOuput);

                        MessageBox.Show(Messages.Confirm.UploadSuccessful + "\n" + fileOuput);
                        
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

        private void cmdDownload_Click_1(object sender, EventArgs e)
        {
            Rekon.tkdispendownload ifrmChild = new Rekon.tkdispendownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }
    }
}
