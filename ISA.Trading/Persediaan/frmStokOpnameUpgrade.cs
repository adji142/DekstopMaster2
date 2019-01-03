using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;


namespace ISA.Trading.Persediaan
    {
    public partial class frmStokOpnameUpgrade : ISA.Trading.BaseForm
        {
        public frmStokOpnameUpgrade()
            {
            InitializeComponent();
            }

        private void cmdOK_Click(object sender, EventArgs e)
            {
            if(MessageBox.Show("Upgrade Data Stok (Menghapus Data Opname Sebelumnya) ?", "Upgrade", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    //if (!SecurityManager.AskPasswordManager())
                    //{
                    //    return;
                    //}
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("psp_Opname_UPGRADE"));
                            db.Commands[0].Parameters.Add(new Parameter("@TglStok", SqlDbType.DateTime, dateTextBox1.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        MessageBox.Show("Stok sudah berhasil diupgrade.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cmdCancel_Click(object sender, EventArgs e)
            {
            this.Close();
            }

        private void frmStokOpnameUpgrade_Load(object sender, EventArgs e)
            {
            dateTextBox1.DateValue=DateTime.Now;
            }
        }
    }
