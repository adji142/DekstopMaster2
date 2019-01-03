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
    public partial class frmStokOpnameTransfer_LIST : ISA.Controls.BaseForm
    {
        DataTable dt = new DataTable();

        public frmStokOpnameTransfer_LIST()
        {
            InitializeComponent();
        }

        private void frmStokOpnameTransfer_LIST_Load(object sender, EventArgs e)
        {
            dateTextBox1.DateValue = DateTime.Now;
            this.DialogResult = DialogResult.No;
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Get Data Transfer Opname ?", "Transfer", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                if (PeriodeClosing.IsHPPClosed(dateTextBox1.DateValue.Value))
                {
                    MessageBox.Show("Sudah CLosing HPP");
                    return;
                }
                
                try
                {
                    this.Cursor=Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("psp_Opname_Transfer_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@TglOpname", SqlDbType.DateTime, dateTextBox1.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar,GlobalVar.Gudang));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show(dt.Rows.Count.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Tidak ada data");
                    }
                    this.DialogResult = DialogResult.OK;
                }
                catch(Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Cursor=Cursors.Default;
                }

                this.Close();
            }
        }
    }
}
