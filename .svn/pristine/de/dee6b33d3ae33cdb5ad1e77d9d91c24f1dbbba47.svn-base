using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Master
{
    public partial class FrmBudgetPembelianAddEdit : ISA.Trading.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        DataTable dt;

        public FrmBudgetPembelianAddEdit(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public FrmBudgetPembelianAddEdit(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
        }

        private void FrmBudgetPembelianAddEdit_Load(object sender, EventArgs e)
        {
            dateTextBoxTmt.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            numericTextBoxBudget.Focus();

            try
            {
                if (formMode == enumFormMode.Update)
                {
                    BudgetPembelianFilterRowid();
                    dateTextBoxTmt.DateValue = (DateTime)dt.Rows[0]["Tmt"];
                    numericTextBoxBudget.Text = Tools.isNull(dt.Rows[0]["Budget"], "").ToString();
                    dateTextBoxTmt.Enabled = false;
                    
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {                 
            
            if (numericTextBoxBudget.GetDoubleValue <= 0)
            {
                MessageBox.Show("Budget tidak boleh kosong");
                numericTextBoxBudget.Focus();
                return;
            }
            try
            {
                if (dateTextBoxTmt.DateValue <= GlobalVar.LastClosingDate)
                {
                    throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                }   
                switch (formMode)
                {
                    case enumFormMode.New:
                        using (Database db = new Database())
                        {
                            _rowID = Guid.NewGuid();
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_BudgetPembelian_Insert"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@Tmt", SqlDbType.DateTime,dateTextBoxTmt.DateValue.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@Budget", SqlDbType.Int, numericTextBoxBudget.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                            db.Close();
                            db.Dispose();
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("TMT " + dateTextBoxTmt.Text + " sudah sudah ada");
                                numericTextBoxBudget.Focus();
                                return;
                            }
                        }
                        break;
                    case enumFormMode.Update:

                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_BudgetPembelian_update"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@Budget", SqlDbType.Int, numericTextBoxBudget.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                            db.Close();
                            db.Dispose();
                                             
                        }
                        break;
                }
                this.DialogResult = DialogResult.OK;
                FrmBudgetPembelian frmCaller = (FrmBudgetPembelian)this.Caller;
                frmCaller.BrowseBudgetPembelian();
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBudgetPembelianAddEdit_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is FrmBudgetPembelian)
                {                   
                    BudgetPembelianFilterRowid();
                    FrmBudgetPembelian frmCaller = (FrmBudgetPembelian)this.Caller;
                    frmCaller.FindRow("RowID", _rowID.ToString());
                }
            }            
            
        }

        private void BudgetPembelianFilterRowid()
        {
            dt = new DataTable();
            using (Database db = new Database())
            {
                db.Open();
                db.Commands.Add(db.CreateCommand("usp_BudgetPembelian_list_filter_rowid"));
                db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, _rowID));
                dt = db.Commands[0].ExecuteDataTable();
                db.Close();
                db.Dispose();
            }
        }
                      
        
    }
}
