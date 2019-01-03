using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using ISA.DAL;
using ISA.Common;
using ISA.Finance.Class;
using ISA.Finance.DataTemplates;
using Microsoft.Reporting.WinForms;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using System.Data.SqlClient;

namespace ISA.Finance.Tac
{
    public partial class frmSalesEntry : ISA.Controls.BaseForm
    {
        string cKodeSales = string.Empty,
               cNamaSales = string.Empty;

        DataTable dts = new DataTable();

        public frmSalesEntry(Form caller)
        {
            InitializeComponent();
            this.Caller = caller;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSalesEntry_Load(object sender, EventArgs e)
        {
            this.Location = new Point(420, 230);
        }

        private void lookupSales1_SelectData(object sender, EventArgs e)
        {
            try
            {
                cKodeSales = lookupSales1.SalesID;
                cNamaSales = lookupSales1.NamaSales;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Sales_TabelTac_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(lookupSales1.SalesID,"").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaSales", SqlDbType.VarChar, Tools.isNull(lookupSales1.NamaSales,"").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                MessageBox.Show(Messages.Confirm.UpdateSuccess);
                this.DialogResult = DialogResult.OK;
                if (this.Caller is frmSales)
                {
                    frmSales frmCaller = (frmSales)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.TokoFindRow("SalesID", lookupSales1.SalesID);
                    this.Close();
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


            Cursor.Current = Cursors.WaitCursor;
            try
            {
                dts = new DataTable(GlobalVar.DBName);
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Sales_TabelTac_GET"));
                    dts = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex) { Error.LogError(ex); }
            finally { Cursor.Current = Cursors.Default; }


            if (dts.Rows.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        int index = 0;

                        foreach (DataRow dr in dts.Rows)
                        {
                            db.Commands.Add(db.CreateCommand("usp_KotaToko_INSERT"));
                            db.Commands[index].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["KodeToko"], "").ToString()));
                            db.Commands[index].Parameters.Add(new Parameter("@NamaToko", SqlDbType.VarChar, Tools.isNull(dr["NamaToko"], "").ToString()));
                            db.Commands[index].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, Tools.isNull(dr["Alamat"], "").ToString()));
                            db.Commands[index].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, Tools.isNull(dr["Kota"], "").ToString()));
                            db.Commands[index].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, Tools.isNull(dr["WilID"], "").ToString()));
                            db.Commands[index].Parameters.Add(new Parameter("@TokoID", SqlDbType.VarChar, Tools.isNull(dr["TokoID"], "").ToString()));
                            db.Commands[index].Parameters.Add(new Parameter("@Daerah", SqlDbType.VarChar, Tools.isNull(dr["Daerah"], "").ToString()));
                            db.Commands[index].Parameters.Add(new Parameter("@Propinsi", SqlDbType.VarChar, Tools.isNull(dr["Propinsi"], "").ToString()));
                            db.Commands[index].Parameters.Add(new Parameter("@LastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserID));
                            index++;
                        }

                        db.BeginTransaction();
                        foreach (Command cmd in db.Commands)
                        {
                            cmd.ExecuteNonQuery();
                        }
                        db.CommitTransaction();

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex) { Error.LogError(ex); }
                finally { Cursor.Current = Cursors.Default; }
            }
        }
    }
}
