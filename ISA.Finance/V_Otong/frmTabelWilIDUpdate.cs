using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using System.Drawing.Printing;
using ISA.Common;
using ISA.Finance.Class;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data.SqlTypes;
using Microsoft.Reporting.WinForms;
using ISA.Finance.DataTemplates;

namespace ISA.Finance.V_Otong
{
    public partial class frmTabelWilIDUpdate : ISA.Finance.BaseForm
    {

        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        DataTable dt = new DataTable();
        
        private void SetDt()
        {
            DataColumn dc = new DataColumn("UserID");
            dt.Columns.Add(dc);
            DataColumn dc2 = new DataColumn("UserName");
            dt.Columns.Add(dc2);
            DataColumn dc3 = new DataColumn("WilID");
            dt.Columns.Add(dc3);

            dt.Rows.Add(lookupSecurityUsers1.UserID, lookupSecurityUsers1.UserName,textBox1.Text.Trim());
        }
        private void RefreshForm()
        {
            if (this.Caller is frmTabelWilID)
            {
                frmTabelWilID frmCaller = (frmTabelWilID)this.Caller;
                SetDt();
                //frmCaller.RefreshRowDetail(_RowID);
                frmCaller.RefreshRowData("UserID", lookupSecurityUsers1.UserID, dt);
                frmCaller.FindGridHeader("UserID", lookupSecurityUsers1.UserID);

            }
        }
        public frmTabelWilIDUpdate()
        {
           
            InitializeComponent();
        }

        public frmTabelWilIDUpdate(Form caller_)
        {  this.Caller = caller_;
            formMode = enumFormMode.New;
              
            InitializeComponent();
        }

        public frmTabelWilIDUpdate(Form caller_, string UserID_,string UserName_ ,string WilID_)
        {
            InitializeComponent();
            this.Caller = caller_;
            lookupSecurityUsers1.UserID = UserID_;
            lookupSecurityUsers1.UserName = UserName_;
            lookupSecurityUsers1.Enabled = false;
            textBox1.Text = WilID_;
            formMode = enumFormMode.Update;
           
        }

        private void frmTabelWilIDUpdate_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
          
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (lookupSecurityUsers1.UserID.Equals(string.Empty))
            {
                lookupSecurityUsers1.Focus();
                return;
            }

            switch (formMode)
            {
            case enumFormMode.New:
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_UserWilID_Insert"));
                            db.Commands[0].Parameters.Add(new Parameter("@UserID", SqlDbType.VarChar, lookupSecurityUsers1.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, textBox1.Text.Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }

                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        RefreshForm();
                        this.Cursor = Cursors.Default;

                    }
            	break;

            case enumFormMode.Update:
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_UserWilID_Update"));
                        db.Commands[0].Parameters.Add(new Parameter("@UserID", SqlDbType.VarChar, lookupSecurityUsers1.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, textBox1.Text.Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    RefreshForm();
                    this.Cursor = Cursors.Default;
                }
                break;
            }

            this.Close();
        }
    }
}
