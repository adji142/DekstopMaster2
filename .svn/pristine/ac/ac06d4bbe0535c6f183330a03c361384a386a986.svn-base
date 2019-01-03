using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.Class;


namespace ISA.Toko.Persediaan
    {
    public partial class frmStokOpnameTransfer : ISA.Toko.BaseForm
        {
        public frmStokOpnameTransfer()
            {
            InitializeComponent();
            }

        private void frmStokOpnameTransfer_Load(object sender, EventArgs e)
            {
            dateTextBox1.DateValue=DateTime.Now;
            }

        private void cmdNo_Click(object sender, EventArgs e)
            {
            this.Close();
            }

        private void cmdYes_Click(object sender, EventArgs e)
            {
            if(MessageBox.Show("Transfer Opname ?", "Transfer", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
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
                        db.Commands.Add(db.CreateCommand("psp_Opname_Transfer"));
                        db.Commands[0].Parameters.Add(new Parameter("@TglOpname", SqlDbType.DateTime, dateTextBox1.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar,GlobalVar.Gudang));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();

                        MessageBox.Show("Transfer opname telah selesai.");
                        this.Close();
                        }
                    }
                catch(Exception ex)
                    {
                    Error.LogError(ex);
                    }
                finally
                    {
                    this.Cursor=Cursors.Default;
                    }
                }
            }
        }
    }
