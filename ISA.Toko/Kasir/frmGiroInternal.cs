using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Kasir
{
    public partial class frmGiroInternal : ISA.Toko.BaseForm
    {
        String BankID = "";
        public frmGiroInternal(Form caller, string BankID)
        {
            this.Caller = caller;
            this.BankID = BankID;
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGiroInternal_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtGiroIn = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance)) 
                {
                    db.Commands.Add(db.CreateCommand("usp_GiroInternal_ByBankID"));
                    db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, BankID));
                    dtGiroIn = db.Commands[0].ExecuteDataTable();
                }

                customGridView1.DataSource = dtGiroIn;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
    }
}
