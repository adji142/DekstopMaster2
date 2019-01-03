using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.PSReport
{
    public partial class frmMasterTargetPersalesUpdate : ISA.Trading.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _NamaSales, _KodeSales;
        Guid _RowID;
        DataTable dtLoadUpdate;

        public frmMasterTargetPersalesUpdate()
        {
            InitializeComponent();
        }

        public frmMasterTargetPersalesUpdate(Form caller, string namaSales, string kodesales)
        {
            this.Caller = caller;
            formMode = enumFormMode.New;
            _NamaSales = namaSales;
            _KodeSales = kodesales;
            InitializeComponent();
        }

        public frmMasterTargetPersalesUpdate(Form caller, string namaSales, string kodesales, Guid RowID)
        {
            this.Caller = caller;
            formMode = enumFormMode.Update;
            _RowID = RowID;
            _NamaSales = namaSales;
            _KodeSales = kodesales;
            InitializeComponent();
        }

        private void frmMasterTargetPersalesUpdate_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case enumFormMode.New:
                    try
                    {
                        dateTimePicker1.Value = DateTime.Now;
                        dateTimePicker1.Format = DateTimePickerFormat.Custom;
                        dateTimePicker1.CustomFormat = " dd,MMMM,yyyy";
                        txtKodeSales.Text = _KodeSales;
                        txtNamaSales.Text = _NamaSales;
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }

                    break;

                case enumFormMode.Update:
                    try
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_TargetPersales_Update"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                            dtLoadUpdate = db.Commands[0].ExecuteDataTable();
                        }
                        txtKodeSales.Text = Tools.isNull(dtLoadUpdate.Rows[0]["Kd_sales"], "").ToString();
                        txtNamaSales.Text = Tools.isNull(dtLoadUpdate.Rows[0]["NamaSales"], "").ToString();
                        dateTimePicker1.Text = Tools.isNull(dtLoadUpdate.Rows[0]["Tmt"], "").ToString();
                        txtTrgtOmset.Text = Tools.isNull(dtLoadUpdate.Rows[0]["TargetOmset"], 0).ToString();
                        txtTrgtSKU.Text = Tools.isNull(dtLoadUpdate.Rows[0]["TargetSKU"], 0).ToString();
                        txtTrgtOA.Text = Tools.isNull(dtLoadUpdate.Rows[0]["TargetOa"], 0).ToString();
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }


                    break;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Simpan()
        {
            switch (formMode)
            {
                case enumFormMode.New:
                    try
                    {

                        DataTable dt = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("[usp_TabelTargetPerSales_Insert]"));
                            db.Commands[0].Parameters.Add(new Parameter("@NamaSales", SqlDbType.VarChar, _NamaSales));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, _KodeSales));
                            db.Commands[0].Parameters.Add(new Parameter("@Tmt", SqlDbType.DateTime, dateTimePicker1.Value.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@TargetOmset", SqlDbType.NChar, Tools.isNull(txtTrgtOmset.Text, "").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@TargetSKU", SqlDbType.NChar, Tools.isNull(txtTrgtSKU.Text, "").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@TargetOa", SqlDbType.NChar, Tools.isNull(txtTrgtOA.Text, "").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }

                    break;

                case enumFormMode.Update:
                    try
                    {
                        DataTable dt = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("[usp_TabelTargetPerSales_Edit]"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@NamaSales", SqlDbType.VarChar, _NamaSales));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, _KodeSales));
                            db.Commands[0].Parameters.Add(new Parameter("@Tmt", SqlDbType.DateTime, dateTimePicker1.Value.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@TargetOmset", SqlDbType.NChar, Tools.isNull(txtTrgtOmset.Text, "").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@TargetSKU", SqlDbType.NChar, Tools.isNull(txtTrgtSKU.Text, "").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@TargetOa", SqlDbType.NChar, Tools.isNull(txtTrgtOA.Text, "").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
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


                    break;
            }

            
        }
        
        private void cbSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Simpan Data ?", "SIMPAN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Simpan();
                frmMasterTargetPerSales frmCaller = (frmMasterTargetPerSales)this.Caller;
                frmCaller.RefreshTargetSales(_KodeSales);
                this.Close();
            }
        }
    }
}
