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
    public partial class frmTokoEntry : ISA.Controls.BaseForm
    {
        public frmTokoEntry(Form caller)
        {
            InitializeComponent();
            this.Caller = caller;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTokoEntry_Load(object sender, EventArgs e)
        {
            InitializeComponents();
            this.lookupToko1.Focus();
        }

        public void InitializeComponents()
        {
            this.Location = new Point(300, 165);
        }

        private void lookupToko1_SelectData(object sender, EventArgs e)
        {
            try
            {
                Alamat.Text = lookupToko1.Alamat;
                Kota.Text = lookupToko1.Kota;
                Idwil.Text = lookupToko1.WilID;
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
                    db.Commands.Add(db.CreateCommand("usp_Toko_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, lookupToko1.KodeToko));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaToko", SqlDbType.VarChar, lookupToko1.NamaToko));
                    db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, Alamat.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, Kota.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, Idwil.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                MessageBox.Show(Messages.Confirm.UpdateSuccess);
                this.DialogResult = DialogResult.OK;
                if (this.Caller is frmToko)
                {
                    frmToko frmCaller = (frmToko)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.TokoFindRow("NamaToko", lookupToko1.NamaToko);
                }
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

    }
}
