using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;


namespace ISA.Toko.Persediaan
{
public partial class frmStokOpnameDownload : ISA.Toko.BaseForm
    {
    public frmStokOpnameDownload()
        {
        InitializeComponent();
        }

    private void cmdCancel_Click(object sender, EventArgs e)
        {
        this.Close();
        }

    private void frmStokOpnameDownload_Load(object sender, EventArgs e)
        {
        dateTextBox1.DateValue=DateTime.Now;
        }

    private void cmdYes_Click(object sender, EventArgs e)
    {
    if(MessageBox.Show("Download Saldo Akhir?", "Download", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
        {
            try
                {
                    this.Cursor=Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("psp_Opname_Download"));
                        db.Commands[0].Parameters.Add(new Parameter("@TglProses", SqlDbType.DateTime, dateTextBox1.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang ", SqlDbType.VarChar, GlobalVar.Gudang));
                        db.Commands[0].ExecuteNonQuery();

                        MessageBox.Show("Download saldo akhir sudah selesai.");
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
