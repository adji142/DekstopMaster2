using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Bengkel.Helper;
using ISA.Bengkel.Library;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
namespace ISA.Bengkel.Master
{
    public partial class frmCustMotorUpdate : ISA.Bengkel.BaseForm
    {
        FormTools.enumFormMode formMode;
        Guid rowID, headerID, rowIDDetail;
        DataTable dt;
        string oldNoPol = string.Empty;
        private bool _isEnable = false;
        string filename;
        string[] imgBase64 = new string[3];
        string[] imgName = new string[3];
        public frmCustMotorUpdate(Form caller)
        {
            InitializeComponent();
            formMode = FormTools.enumFormMode.New;
            this.Caller = caller;
        }

        public frmCustMotorUpdate(Form caller, Guid _rowID)
        {
            InitializeComponent();
            formMode = FormTools.enumFormMode.Update;
            rowID  = _rowID;
            this.Caller = caller;            
        }

        public frmCustMotorUpdate(Form caller, Guid _rowID, FormTools.enumFormMode _formMode)
        {
            InitializeComponent();
            formMode = _formMode;
            if (formMode == FormTools.enumFormMode.Update)
            {
                rowID = _rowID;
            }
            else
            {
                headerID = _rowID;
            }
            this.Caller = caller;
        }

        public frmCustMotorUpdate(Form caller, Guid _rowID, Guid _rowIDDetail, FormTools.enumFormMode _formMode)
        {
            InitializeComponent();
            formMode = _formMode;
            if (formMode == FormTools.enumFormMode.Update)
            {
                rowID = _rowID;
                rowIDDetail = _rowIDDetail;
            }
            else
            {
                headerID = _rowID;
            }
            this.Caller = caller;
        }

        private void frmCustMotorUpdate_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.cmdbrows, "Pilih Foto");
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //Bind Data Jenis Sepeda Motor
                DataTable dtSPM = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_bkl_mMotor_LIST"));
                    dtSPM = db.Commands[0].ExecuteDataTable();
                }
                cmbSPMType.DisplayMember = "jns_spm";
                cmbSPMType.ValueMember = "kode";
                cmbSPMType.DataSource = dtSPM;

                switch (formMode)                
                {
                    case FormTools.enumFormMode.New:
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_bkl_mCustomerService_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, headerID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        txtCustName.Text = Tools.isNull(dt.Rows[0]["nama_cust"], "").ToString();
                        txtAlamat.Text = Tools.isNull(dt.Rows[0]["alamat"], "").ToString();
                        txtKota.Text = Tools.isNull(dt.Rows[0]["kota"], "").ToString();
                        txtDaerah.Text = Tools.isNull(dt.Rows[0]["daerah"], "").ToString();
                        txtNoTelp.Text = Tools.isNull(dt.Rows[0]["no_telp"], "").ToString();
                        txtNoKTP.Text = Tools.isNull(dt.Rows[0]["no_id"], "").ToString();
                        txtIDMember.Text = Tools.isNull(dt.Rows[0]["no_member"], "").ToString();
                        txtKeterangan.Text = Tools.isNull(dt.Rows[0]["ket"], "").ToString();
                        txtInstansi.Text = Tools.isNull(dt.Rows[0]["instansi"], "").ToString();
                        break;

                    case FormTools.enumFormMode.Update:
                        dt = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_bkl_mMotorService_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowIDDetail));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        txtNoPol.Text = Tools.isNull(dt.Rows[0]["no_pol"], "").ToString();
                        this.oldNoPol = txtNoPol.Text;
                        txtSPM.Text = Tools.isNull(dt.Rows[0]["spm"], "").ToString();
                        txtTahun.Text = Tools.isNull(dt.Rows[0]["tahun"], "").ToString();
                        txtWarna.Text = Tools.isNull(dt.Rows[0]["warna"], "").ToString();
                        txtNoMesin.Text = Tools.isNull(dt.Rows[0]["no_mesin"], "").ToString();
                        txtNoRangka.Text = Tools.isNull(dt.Rows[0]["no_rangka"], "").ToString();
                        cmbSPMType.SelectedValue = Tools.isNull(dt.Rows[0]["kode"], "").ToString();
                        txtSPMTypeDesc.Text = Tools.isNull(dt.Rows[0]["jns_spm"], "").ToString();

                        dt = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_bkl_mCustomerService_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        txtCustName.Text = Tools.isNull(dt.Rows[0]["nama_cust"], "").ToString();
                        txtAlamat.Text = Tools.isNull(dt.Rows[0]["alamat"], "").ToString();
                        txtKota.Text = Tools.isNull(dt.Rows[0]["kota"], "").ToString();
                        txtDaerah.Text = Tools.isNull(dt.Rows[0]["daerah"], "").ToString();
                        txtNoTelp.Text = Tools.isNull(dt.Rows[0]["no_telp"], "").ToString();
                        txtNoKTP.Text = Tools.isNull(dt.Rows[0]["no_id"], "").ToString();
                        txtIDMember.Text = Tools.isNull(dt.Rows[0]["no_member"], "").ToString();
                        txtKeterangan.Text = Tools.isNull(dt.Rows[0]["ket"], "").ToString();
                        txtInstansi.Text = Tools.isNull(dt.Rows[0]["instansi"], "").ToString();
                        string base64 = Tools.isNull(dt.Rows[0]["pic"], "").ToString();//gridDetail.SelectedCells[0].OwningRow.Cells["Pict1Src"].Value.ToString();
                        if (base64 != "")
                        {
                            LoadImage(base64);
                        }
                        else
                        {
                            UnLoadImage();
                        }
                        break;
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
        private void saveJpeg(string path, Bitmap img, long quality)
        {
            // Encoder parameter for image quality
            EncoderParameter qualityParam = new EncoderParameter(
                    System.Drawing.Imaging.Encoder.Quality, (long)quality);

            // Jpeg image codec
            ImageCodecInfo jpegCodec = getEncoderInfo("image/jpeg");

            if (jpegCodec == null)
            {
                MessageBox.Show("Can't find JPEG encoder?", "saveJpeg()");
                return;
            }
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            img.Save(path, jpegCodec, encoderParams);
        }
        private ImageCodecInfo getEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];

            return null;
        }
        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            Database db = new Database();

            try
            {
                this.Cursor = Cursors.WaitCursor;
                switch (formMode)
                {
                    case FormTools.enumFormMode.New:
                        rowID = Guid.NewGuid();
                        using (db)
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_bkl_mMotorService_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, headerID));
                            db.Commands[0].Parameters.Add(new Parameter("@no_pol", SqlDbType.VarChar,  txtNoPol.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@spm", SqlDbType.VarChar, txtSPM.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@tahun", SqlDbType.VarChar, txtTahun.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@warna", SqlDbType.VarChar, txtWarna.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@no_mesin", SqlDbType.VarChar, txtNoMesin.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@no_rangka", SqlDbType.VarChar, txtNoRangka.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kode", SqlDbType.VarChar, cmbSPMType.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@jns_spm", SqlDbType.VarChar, txtSPMTypeDesc.Text));

                            db.Commands[0].Parameters.Add(new Parameter("@pemilik", SqlDbType.VarChar, txtCustName.Text));                          
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));                          
                            db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text));                          
                            db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, txtDaerah.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@no_telp", SqlDbType.VarChar, txtNoTelp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@no_id", SqlDbType.VarChar, txtNoKTP.Text));                          
                            db.Commands[0].Parameters.Add(new Parameter("@id_member", SqlDbType.VarChar, txtIDMember.Text));                          
                            db.Commands[0].Parameters.Add(new Parameter("@ket", SqlDbType.VarChar, txtKeterangan.Text));                          
                            db.Commands[0].Parameters.Add(new Parameter("@instansi", SqlDbType.VarChar, txtInstansi.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, false));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@pic", SqlDbType.VarChar, imgBase64[0]));

                           
                            dt = db.Commands[0].ExecuteDataTable();

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Sepeda Motor dengan No Polisi : " + txtNoPol.Text + " Sudah terdaftar di database");
                                txtNoPol.Text = string.Empty;
                                txtNoPol.Focus();
                                return;
                            }
                        }
                        break;
                    case FormTools.enumFormMode.Update:
                        using (db)
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_bkl_mMotorService_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowIDDetail));
                            db.Commands[0].Parameters.Add(new Parameter("@no_pol", SqlDbType.VarChar, txtNoPol.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@spm", SqlDbType.VarChar, txtSPM.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@tahun", SqlDbType.VarChar, txtTahun.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@warna", SqlDbType.VarChar, txtWarna.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@no_mesin", SqlDbType.VarChar, txtNoMesin.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@no_rangka", SqlDbType.VarChar, txtNoRangka.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kode", SqlDbType.VarChar, cmbSPMType.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@jns_spm", SqlDbType.VarChar, txtSPMTypeDesc.Text));

                            db.Commands[0].Parameters.Add(new Parameter("@pemilik", SqlDbType.VarChar, txtCustName.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, txtDaerah.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@no_telp", SqlDbType.VarChar, txtNoTelp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@no_id", SqlDbType.VarChar, txtNoKTP.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@id_member", SqlDbType.VarChar, txtIDMember.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@ket", SqlDbType.VarChar, txtKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@instansi", SqlDbType.VarChar, txtInstansi.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, false));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@pic", SqlDbType.VarChar, imgBase64[0]));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                this.DialogResult = DialogResult.OK;
                closeForm();
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

        private bool ValidateInput()
        {
            bool valid = true;


            if (FormTools.IsBlank(txtNoPol))
            {
                valid = false;
                goto finish;
            }

            if (FormTools.IsBlank(txtCustName))
            {
                valid = false;
                goto finish;
            }

            //if (formMode == FormTools.enumFormMode.New || (formMode == FormTools.enumFormMode.Update && txtNoPol.Text != this.oldNoPol))
            //{
            //    if (FormTools.IsDataExist("usp_Bkl_mMotorService_LIST", "@no_pol", SqlDbType.VarChar, txtNoPol.Text))
            //    {
            //        valid = false;
            //        goto finish;
            //    }
            //}

            finish:
            return valid;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCustMotorUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeForm();
        }

        private void closeForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmCustomerBrowse)
                {
                    frmCustomerBrowse frmCaller = (frmCustomerBrowse)this.Caller;
                    frmCaller.RefreshData(FormTools.detailIndex.detail1);
                    //frmCaller.FindRow(FormTools.detailIndex.detail1, "no_pol", txtNoPol.Text);
                }
            }
            //this.Close();
        }
        #region Private Method

        //private void SetEnable(bool bole)
        //{
        //    txtCustName.Enabled = bole;
        //    txtAlamat.Enabled = bole;
        //    txtKota.Enabled = bole;
        //    txtDaerah.Enabled = bole;
        //    txtNoTelp.Enabled = bole;
        //    txtNoKTP.Enabled = bole;
        //    txtIDMember.Enabled = bole;
        //    txtKeterangan.Enabled = bole;
        //    txtInstansi.Enabled = bole;
        //}

        #endregion

        private void cmbSPMType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtSPM = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_bkl_mMotor_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@kode", SqlDbType.VarChar, cmbSPMType.SelectedValue));
                dtSPM = db.Commands[0].ExecuteDataTable();
                txtSPMTypeDesc.Text = Tools.isNull(dtSPM.Rows[0]["jns_spm"], "").ToString();
            }
        }

        private void cmdbrows_Click(object sender, EventArgs e)
        {
            if (fileUpload.ShowDialog() == DialogResult.OK)
            {
                filename = fileUpload.FileName;
                string strFileName = fileUpload.SafeFileName;
                string strPathName = fileUpload.FileName;
                byte[] bytes = File.ReadAllBytes(fileUpload.FileName);
                imgBase64[0] = Convert.ToBase64String(bytes);
                loadori(filename);
            }
        }
        private void loadori(string name) {
            Cursor = Cursors.AppStarting;
            pictureBox1.Image = Image.FromFile(name);
            Cursor = Cursors.Default;
        }
        private void LoadImage(string base64String)
        {
            if (GetFileExtension(base64String) == "pdf")
            {
                //DialogResult dr = MessageBox.Show("Lampiran berupa File pdf. Anda ingin membukanya?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //if (dr == DialogResult.No)
                //{
                UnLoadImage();
                return;
                //}
                //OpenPDF(base64String);
            }
            else
            {
                pictureBox1.Image = Base64ToImage(base64String);
            }

        }
        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        public static string GetFileExtension(string base64String)
        {
            var data = base64String.Substring(0, 5);

            switch (data.ToUpper())
            {
                case "IVBOR":
                    return "png";
                case "/9J/4":
                    return "jpg";
                case "AAAAF":
                    return "mp4";
                case "JVBER":
                    return "pdf";
                case "AAABA":
                    return "ico";
                case "UMFYI":
                    return "rar";
                case "E1XYD":
                    return "rtf";
                case "U1PKC":
                    return "txt";
                case "MQOWM":
                case "77U/M":
                    return "srt";
                default:
                    return string.Empty;
            }
        }
        private void UnLoadImage()
        {
            pictureBox1.Image = null;
        }

        private void OpenPDF(string base64string)
        {
            try
            {
                string pathFileName = @"c:\Temp\pdfFile.pdf";
                byte[] sPDFDecoded = Convert.FromBase64String(base64string);

                File.WriteAllBytes(pathFileName, sPDFDecoded);

                System.Diagnostics.Process.Start(pathFileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadLine();
            }
        }
        private void LoadImageState()
        {
            string base64 = "";//gridDetail.SelectedCells[0].OwningRow.Cells["Pict1Src"].Value.ToString();
            if (base64 != "")
            {
                LoadImage(base64);
            }
            else
            {
                UnLoadImage();
            }
        }

    }
}
