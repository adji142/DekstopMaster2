using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.PSReport
{
    public partial class frmMasterTargetSalesUpdate : ISA.Toko.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _RowID;
        DataTable dtLoadUpdate;

        public frmMasterTargetSalesUpdate()
        {
            InitializeComponent();
        }

        public frmMasterTargetSalesUpdate(Form caller)
        {
            this.Caller = caller;
            formMode = enumFormMode.New;
            InitializeComponent();
        }

        public frmMasterTargetSalesUpdate(Form caller, Guid RowID)
        {
            this.Caller = caller;
            _RowID = RowID;
            formMode = enumFormMode.Update;
            InitializeComponent();
        }

        private void frmMasterTargetSalesUpdate_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case enumFormMode.New:
                    try
                    {
                        dateTimePicker1.Value = DateTime.Now;
                        dateTimePicker1.Format = DateTimePickerFormat.Custom;
                        dateTimePicker1.CustomFormat = " dd,MMMM,yyyy";
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
                            db.Commands.Add(db.CreateCommand("[usp_TabelTargetSales_Update]"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                            dtLoadUpdate = db.Commands[0].ExecuteDataTable();
                        }
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
                            db.Commands.Add(db.CreateCommand("usp_TabelTargetSales_Insert"));
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
                            db.Commands.Add(db.CreateCommand("usp_TabelTargetSales_Edit"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
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
                frmMasterTargetSalesBrowse frmCaller = (frmMasterTargetSalesBrowse)this.Caller;
                frmCaller.RefreshTarget();
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



    }
}
