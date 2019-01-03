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

namespace ISA.Bengkel.Master
{
    public partial class frmStandarBiayaServiceUpdate : ISA.Controls.BaseForm
    {
        FormTools.enumFormMode formMode;
        Guid _rowID;
        DataTable dt;
        Double nKode;
        string cKode = string.Empty;

        public frmStandarBiayaServiceUpdate(Form caller)
        {
            InitializeComponent();
            formMode = FormTools.enumFormMode.New;
            this.Caller = caller;
        }

        public frmStandarBiayaServiceUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = FormTools.enumFormMode.Update;
            _rowID  = rowID;
            this.Caller = caller;            
        }


        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStandarBiayaServiceUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (formMode == FormTools.enumFormMode.New)
                {
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_bkl_GetLastKodeService"));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    if (dt.Rows.Count > 0)
                    {
                        cKode = (Convert.ToDouble(Tools.isNull(dt.Rows[0]["kode"], "").ToString()) + 1).ToString().PadLeft(3, '0');
                    }
                    kode.Text = cKode;
                }
                else
                {
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_StandarService_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    if (dt.Rows.Count > 0)
                    {
                        kategori.Text = Tools.isNull(dt.Rows[0]["kategori"], "").ToString();
                        kode.Text = Tools.isNull(dt.Rows[0]["kode"], "").ToString();
                        lookupSepedaMotor1.NamaSepedaMotor = Tools.isNull(dt.Rows[0]["jns_spm"], "").ToString();
                        lookupSepedaMotor1.KodeSepedaMotor = Tools.isNull(dt.Rows[0]["kd_spm"], "").ToString();
                        biaya.Text = Tools.isNull(dt.Rows[0]["biaya"], "0").ToString(); 
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

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                switch (formMode)
                {
                    case FormTools.enumFormMode.New:
                        _rowID = Guid.NewGuid();
                        string HtrId = GlobalVar.PerusahaanID + Tools.CreateFingerPrint().Substring(0, 16) + SecurityManager.UserInitial;
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_StandarService_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@kategori", SqlDbType.VarChar, kategori.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kode", SqlDbType.VarChar, kode.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@biaya", SqlDbType.Money, biaya.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@jns_spm", SqlDbType.VarChar, lookupSepedaMotor1.NamaSepedaMotor));
                            db.Commands[0].Parameters.Add(new Parameter("@kd_spm", SqlDbType.VarChar, lookupSepedaMotor1.KodeSepedaMotor));
                            db.Commands[0].Parameters.Add(new Parameter("@htrid", SqlDbType.VarChar, HtrId));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, false));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        break;

                    case FormTools.enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_StandarService_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@kategori", SqlDbType.VarChar, kategori.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kode", SqlDbType.VarChar, kode.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@biaya", SqlDbType.Money, biaya.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@jns_spm", SqlDbType.VarChar, lookupSepedaMotor1.NamaSepedaMotor));
                            db.Commands[0].Parameters.Add(new Parameter("@kd_spm", SqlDbType.VarChar, lookupSepedaMotor1.KodeSepedaMotor));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, false));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
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


        private void closeForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmStandarBiayaServiceBrowse)
                {
                    frmStandarBiayaServiceBrowse frmCaller = (frmStandarBiayaServiceBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("kode", kode.Text);
                }
            }
        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (Tools.isNull(kategori.Text,"")=="")
            {
                MessageBox.Show("Kategori masih kosong..!");
                valid = false;
                goto finish;
            }

            if (Tools.isNull(kode.Text,"")=="")
            {
                MessageBox.Show("Kode Kategori masih kosong..!");
                valid = false;
                goto finish;
            }

            if (Tools.isNull(lookupSepedaMotor1.NamaSepedaMotor,"")=="")
            {
                MessageBox.Show("Jenis Sepeda Motor masih kosong..!");
                valid = false;
                goto finish;
            }

            if (biaya.Text.ToString()=="0")
            {
                MessageBox.Show("Biaya masih kosong..!");
                valid = false;
                goto finish;
            }

        finish:
            return valid;
        }
    }
}
