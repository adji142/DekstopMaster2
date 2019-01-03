using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.Class;


namespace ISA.Trading.Persediaan
{
    public partial class frmStokOpnameTransfer : ISA.Trading.BaseForm
    {
        public frmStokOpnameTransfer()
        {
            InitializeComponent();
        }

        private void frmStokOpnameTransfer_Load(object sender, EventArgs e)
        {
            dateTextBox1.DateValue = DateTime.Now;
            rbTglopname.PerformClick();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Transfer Opname ?", "Transfer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (PeriodeClosing.IsHPPClosed(dateTextBox1.DateValue.Value))
                {
                    MessageBox.Show("Sudah CLosing HPP");
                    return;
                }

                this.Cursor = Cursors.WaitCursor;

                try
                {
                    if (rbTgltransfer.Checked)
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("psp_Opname_Transfer"));
                            db.Commands[0].Parameters.Add(new Parameter("@TglOpname", SqlDbType.DateTime, dateTextBox1.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                            MessageBox.Show("Transfer opname telah selesai.");
                            this.Close();
                        }
                    }
                    else
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("psp_Opname_Transfer_Berjalan"));
                            db.Commands[0].Parameters.Add(new Parameter("@TglOpname", SqlDbType.DateTime, dateTextBox1.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                            MessageBox.Show("Transfer opname telah selesai.");
                            this.Close();
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
        }
    }
}
