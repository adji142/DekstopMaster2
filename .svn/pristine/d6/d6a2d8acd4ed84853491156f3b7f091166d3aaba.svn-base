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
    public partial class frmClosingStok : ISA.Toko.BaseForm
    {
        public frmClosingStok()
        {
        InitializeComponent();
        }

        private void frmClosingStok_Load(object sender,EventArgs e)
        {
            dateTextBox1.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        private void cmdYes_Click(object sender,EventArgs e)
        {
        if (MessageBox.Show("Closing Stok","Perhatian",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
        {
        try
            {
                DataTable dt;    
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                    {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("psp_StokGudang_Closing"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar,GlobalVar.Gudang));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                    db.Commands[0].Parameters.Add(new Parameter("@InitUser", SqlDbType.VarChar,SecurityManager.UserInitial));
                    db.Commands[0].Parameters.Add(new Parameter("@ClosingDate", SqlDbType.DateTime, dateTextBox1.DateValue));                    
        			db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    dt = db.Commands[0].ExecuteDataTable();
                    int retVal = int.Parse(dt.Rows[0]["RESULT"].ToString());
                    
                    DateTime tglAkhir = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    tglAkhir = tglAkhir.AddDays(-1);
                    DateTime tglAwal = new DateTime(tglAkhir.Year, tglAkhir.Month, 1);

                    //insert ke Closing Stok
                    DateTime BulanKemarin = Convert.ToDateTime(dateTextBox1.DateValue).AddMonths(-1);
                    DateTime FirstDateBulanKemarin = new DateTime(BulanKemarin.Year, BulanKemarin.Month, 1);
                    DateTime LastDateBulanKemarin = new DateTime(BulanKemarin.Year, BulanKemarin.Month, DateTime.DaysInMonth(BulanKemarin.Year, BulanKemarin.Month));

                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_ClosingStok_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@Tipe", SqlDbType.VarChar, "HPP"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglAwal", SqlDbType.DateTime, FirstDateBulanKemarin));
                    db.Commands[0].Parameters.Add(new Parameter("@TglAkhir", SqlDbType.DateTime, LastDateBulanKemarin));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, "Admin"));
                    db.Commands[0].ExecuteNonQuery();


                    if (retVal == -1)
                    {
                        MessageBox.Show("Belum proses HPP Rata-rata periode " + tglAwal.ToString("dd-MM-yyyy") + " s/d " + tglAkhir.ToString("dd-MM-yyyy"));
                    }
                    else if (retVal == 1)
                    {
                        MessageBox.Show("Periode " + tglAwal.ToString("dd-MM-yyyy") + " s/d " + tglAkhir.ToString("dd-MM-yyyy")+ " sudah closing");
                    }
                    else
                    {
                        MessageBox.Show("Proses closing stok telah selesai");
                    }
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

        }
       
        }

        private void cmdNo_Click(object sender,EventArgs e)
        {
        this.Close();
        }
    }
}
