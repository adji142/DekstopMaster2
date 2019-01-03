using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;


namespace ISA.Toko.xpdc
{
    public partial class FrmUpdateBarcode_Update : ISA.Toko.BaseForm
    {
        Guid _rowID = Guid.Empty;
        DataTable dtBarcodeCek, dtBarcode, dtBarcodeUpdate;


        public FrmUpdateBarcode_Update()
        {
            InitializeComponent();
        }

        public FrmUpdateBarcode_Update(Form Caller, Guid rowID)
        {
            InitializeComponent();
            _rowID = rowID;
            this.Caller = Caller;
        }

        private void FrmUpdateBarcode_Update_Load(object sender, EventArgs e)
        {
            DtTanggalSj.Enabled = false;
            txtNomorNota.Enabled = false;
            txtNamaToko.Enabled = false;
            txtAlamat.Enabled = false;
            txtWillID.Enabled = false;

            RefreshData();


        }

        public void RefreshData()
        {
            try
            {
             
                this.Cursor = Cursors.WaitCursor;
                //DataTable dtBarcode = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Xpdc_CekBarcode_Update"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    dtBarcode = db.Commands[0].ExecuteDataTable();
                }

                DtTanggalSj.Text = Convert.ToString(dtBarcode.Rows[0]["TglSuratJalan"].ToString());
                txtNomorNota.Text = Convert.ToString(dtBarcode.Rows[0]["NoSuratJalan"].ToString());
                txtNamaToko.Text = Convert.ToString(dtBarcode.Rows[0]["NamaToko"].ToString());
                txtAlamat.Text = Convert.ToString(dtBarcode.Rows[0]["Alamat"].ToString());
                txtWillID.Text = Convert.ToString(dtBarcode.Rows[0]["WilID"].ToString());
                txtBarcode.Text = Convert.ToString(dtBarcode.Rows[0]["Barcode"].ToString());

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

        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
            xpdc.FrmUpdateBarcode ifrmChild = new xpdc.FrmUpdateBarcode();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void CmdSave_Click(object sender, EventArgs e)
        {
            UpdateBarcode();
        }

        public void UpdateBarcode()
        {
            try
            {
                CekBarcode();
                    if (dtBarcodeCek.Rows.Count >= 1)
                    {
                        MessageBox.Show("Sudah Ada Barcode");
                        MessageBox.Show("Gagal Menyimpan Data");
                        return;
                    }
                    else
                    {
                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_Xpdc_CekBarcode_Update_Sav"));
                            db.Commands[0].Parameters.Add(new Parameter("@Barcode", SqlDbType.VarChar, txtBarcode.Text.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            dtBarcodeUpdate = db.Commands[0].ExecuteDataTable();
                        }

                        MessageBox.Show("Data Berhasil Di simpan");
                        this.Close();

                        xpdc.FrmUpdateBarcode ifrmChild = new xpdc.FrmUpdateBarcode();
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
                MessageBox.Show("Gagal Menyimpan Data");
                return;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }



        public void CekBarcode()
        {
            try
            {

                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Xpdc_CekBarcode_Update_Look"));
                    db.Commands[0].Parameters.Add(new Parameter("@Barcode", SqlDbType.VarChar, txtBarcode.Text.ToString()));
                    dtBarcodeCek = db.Commands[0].ExecuteDataTable();


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
