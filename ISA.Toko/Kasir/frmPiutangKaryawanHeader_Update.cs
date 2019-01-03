using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using System.Data.SqlTypes;

namespace ISA.Toko.Kasir
{
    public partial class frmPiutangKaryawanHeader_Update : ISA.Toko.BaseForm
    {
        private enum enumFormMode { New, Update };
        private enumFormMode formMode;

        private string _nip = string.Empty;

        public frmPiutangKaryawanHeader_Update()
        {
            InitializeComponent();
        }

        public frmPiutangKaryawanHeader_Update(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;        
        }

        public frmPiutangKaryawanHeader_Update(Form caller,string nip)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _nip = nip;
            this.Caller = caller;
        }

        private void frmPiutangKaryawanHeader_Update_Load(object sender, EventArgs e)
        {
            if (_nip != string.Empty)
            {
                txtNIP.Text = _nip;
                txtNIP.Enabled = false;

                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("usp_Staff_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@NIP", SqlDbType.VarChar, txtNIP.Text));
                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count > 0)
                    {
                        txtNIP.Text = dt.Rows[0]["nip"] != DBNull.Value ? dt.Rows[0]["nip"].ToString() : string.Empty;
                        txtNama.Text = dt.Rows[0]["nama"] != DBNull.Value ? dt.Rows[0]["nama"].ToString() : string.Empty;
                        cmbLP.Text = dt.Rows[0]["gender"] != DBNull.Value ? dt.Rows[0]["gender"].ToString() : string.Empty;
                        txtJabatan.Text = dt.Rows[0]["jabatan"] != DBNull.Value ? dt.Rows[0]["jabatan"].ToString() : string.Empty;
                        txtUnitKerja.Text = dt.Rows[0]["c00"] != DBNull.Value ? dt.Rows[0]["c00"].ToString() : string.Empty;
                        txtAlamat.Text = dt.Rows[0]["alamat"] != DBNull.Value ? dt.Rows[0]["alamat"].ToString() : string.Empty;
                        txtNoTlp.Text = dt.Rows[0]["hp"] != DBNull.Value ? dt.Rows[0]["hp"].ToString() : string.Empty;
                        dtbTglLahir.Text = (dt.Rows[0]["tgllahir"] != DBNull.Value) ? ((DateTime)dt.Rows[0]["tgllahir"]).ToString("dd/MM/yyyy") : string.Empty;
                        dtbTglKeluar.Text = (dt.Rows[0]["tglkeluar"] != DBNull.Value) ? ((DateTime)dt.Rows[0]["tglkeluar"]).ToString("dd/MM/yyyy") : string.Empty;
                        dtbTglMasuk.Text = (dt.Rows[0]["tglmasuk"] != DBNull.Value) ? ((DateTime)dt.Rows[0]["tglmasuk"]).ToString("dd/MM/yyyy") : string.Empty;
                    }
                }
            }
        }


        private void btnCloseHeader_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private StringBuilder GetMessages()
        {
            StringBuilder sb = new StringBuilder();

            if (txtNama.Text == string.Empty)
                sb.AppendLine("Nama harus diisi.");
            if (txtJabatan.Text == string.Empty)
                sb.AppendLine("Jabatan harus diisi.");
            if (txtUnitKerja.Text == string.Empty)
                sb.AppendLine("Unit Kerja harus diisi.");
            if (cmbLP.Text == string.Empty)
                sb.AppendLine("Jenis Kelamin harus diisi.");
            if (txtAlamat.Text == string.Empty)
                sb.AppendLine("Alamat harus diisi.");
            if (!dtbTglLahir.DateValue.HasValue)
                sb.AppendLine("Tanggal Lahir harus diisi.");
            if (!dtbTglMasuk.DateValue.HasValue)
                sb.AppendLine("Tanggal Masuk harus diisi.");

            return sb;
        }

        private void AddHeader()
        {            
            if (txtNIP.Text == string.Empty)
            {
                MessageBox.Show("NIP harus diisi.");
                return;
            }

            StringBuilder sb = GetMessages();
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
                return;
            }

            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Add(db.CreateCommand("usp_Staff_INSERT"));
                db.Commands[0].Parameters.Add(new Parameter("@NIP", SqlDbType.VarChar, txtNIP.Text));
                db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                db.Commands[0].Parameters.Add(new Parameter("@Jabatan", SqlDbType.VarChar, txtJabatan.Text));
                db.Commands[0].Parameters.Add(new Parameter("@UnitKerja", SqlDbType.VarChar, txtUnitKerja.Text));
                db.Commands[0].Parameters.Add(new Parameter("@LP", SqlDbType.VarChar, cmbLP.Text));
                db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, txtAlamat.Text));
                db.Commands[0].Parameters.Add(new Parameter("@NoTelp", SqlDbType.VarChar, txtNoTlp.Text));
                db.Commands[0].Parameters.Add(new Parameter("@TglLahir", SqlDbType.DateTime,  dtbTglLahir.DateValue.HasValue ? dtbTglLahir.DateValue.Value : SqlDateTime.Null));
                db.Commands[0].Parameters.Add(new Parameter("@TglMasuk", SqlDbType.DateTime, dtbTglMasuk.DateValue));
                db.Commands[0].Parameters.Add(new Parameter("@TglKeluar", SqlDbType.DateTime, dtbTglKeluar.DateValue.HasValue ? dtbTglKeluar.DateValue.Value : SqlDateTime.Null));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].ExecuteNonQuery();                    
            }

            Kasir.frmPiutangKaryawan frmUtang = new Kasir.frmPiutangKaryawan();
            frmUtang = (frmPiutangKaryawan)this.Caller;
            frmUtang.RefreshPegawai(txtNIP.Text);
            frmUtang.FindRowPegawsai("NIP", txtNIP.Text);
            this.Close();
    
        }


        private void updateHeader()
        {
            try
            {
                StringBuilder sb = GetMessages();
                if (sb.Length > 0)
                {
                    MessageBox.Show(sb.ToString());
                    return;
                }

                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("usp_Staff_Update"));
                    db.Commands[0].Parameters.Add(new Parameter("@NIP", SqlDbType.VarChar, txtNIP.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Jabatan", SqlDbType.VarChar, txtJabatan.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@UnitKerja", SqlDbType.VarChar, txtUnitKerja.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@LP", SqlDbType.VarChar, cmbLP.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, txtAlamat.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@NoTelp", SqlDbType.VarChar, txtNoTlp.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@TglLahir", SqlDbType.DateTime, dtbTglLahir.DateValue.HasValue ? dtbTglLahir.DateValue.Value : SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@TglMasuk", SqlDbType.DateTime, dtbTglMasuk.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@TglKeluar", SqlDbType.DateTime, dtbTglKeluar.DateValue.HasValue ? dtbTglKeluar.DateValue.Value : SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }

                Kasir.frmPiutangKaryawan frmUtang = new Kasir.frmPiutangKaryawan();
                frmUtang = (frmPiutangKaryawan)this.Caller;
                frmUtang.RefreshPegawai(txtNIP.Text);
                frmUtang.FindRowPegawsai("NIP", txtNIP.Text);
                this.Close();
                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }            

        }

        private void btnSaveHeader_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case enumFormMode.New:

                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        DataTable dt = new DataTable();

                        using (Database db = new Database(GlobalVar.DBFinance))
                        {
                            db.Commands.Add(db.CreateCommand("usp_Staff_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@NIP", SqlDbType.VarChar, txtNIP.Text));
                            dt = db.Commands[0].ExecuteDataTable();
                        }

                        if (dt.Rows.Count == 0)
                        {
                            AddHeader();
                        }
                        else
                        {
                            MessageBox.Show("NIP sudah terdaftar.");
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    finally { Cursor.Current = Cursors.Default; }
                    
                    break;

                case enumFormMode.Update:
                    updateHeader();
                    break;
            }            
        }


        private void cmdReplace_Click(object sender, EventArgs e)
        {
            //string targetPath = ISA.Toko.Properties.Settings.Default.DBF_HRD;
            string targetPath = "\\\\"+Database.Host+"\\karyawan\\";

            string fileName = string.Empty;
            string destFile = string.Empty;

            openFileDialog1.Filter = "DBF FILE (*.DBF;*.CDX)" + "All files (*.*)|*.*";            
            openFileDialog1.Multiselect = true;
            openFileDialog1.FileName = "MasterPegawai.DBF";
            

            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            DialogResult dr = openFileDialog1.ShowDialog();

            if(dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach(string fileCollection in openFileDialog1.FileNames)
                {
                    fileName = System.IO.Path.GetFileName(fileCollection);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(fileCollection, destFile, true);
                }
            }



        }
    }
}
