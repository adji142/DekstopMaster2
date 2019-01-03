using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Finance.Kasir
{
    public partial class frmRecalculateKasirLog : ISA.Finance.BaseForm
    {
        public frmRecalculateKasirLog()
        {
            InitializeComponent();
        }

        
        private void frmRecalculateKasirLog_Load(object sender, EventArgs e)
        {
            tbFromDate.DateValue = DateTime.Today;
            tbToDate.DateValue = DateTime.Today;
        }
        private void cmdYes_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_KasirLog_Recalculate"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, (DateTime)tbFromDate.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, (DateTime)tbToDate.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                this.Cursor = Cursors.Arrow;
                MessageBox.Show("Recalculate Kasir Log \nperiode " + tbFromDate.DateValue.ToString() + " s/d " + tbToDate.DateValue.ToString() + " \nSelesai.");
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
