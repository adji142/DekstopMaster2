using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; 
using ISA.DAL;
using System;
using System.Globalization;
using Microsoft.Reporting.WinForms;
using System.IO;
using ISA.Trading.Class;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;


namespace ISA.Trading.Fixrute
{
    public partial class frmFixRuteSalesman : ISA.Trading.BaseForm
    {
        DataTable dtSales, dtRencana;

        enum enumSelectedGrid { HeaderSelected, DetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;
        string hari, hari1;
        int tgl,tgl1;

        Guid rowid;
                DateTime tanggal ;
                int bulan,tahun ;
                string day , kodesales = string.Empty;
        Guid rowidRencana;
        DateTime tglFix ;
                DateTime tglFixHari;
                DateTime tanggalAwal;
        DataTable dtHari = new DataTable();
        string _sales;
        string namatoko;
        string alamat;
        string kdtoko;
        int days;
        public frmFixRuteSalesman()
        {
            InitializeComponent();
        }

        private void frmFixRuteSalesman_Load(object sender, EventArgs e)
        {
            cmdKunjunganBaru.Enabled = false;
            cmdProses.Enabled = false;
            cbHari.Enabled = false;
            dateTextBox1.Enabled = false;
            dateTextBox2.Enabled = false;
            btnFilter.Enabled = false;
            commandButton2.Enabled = false;
            cmdAdd2.Enabled = false;

            rgbTglKunjungan.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime fromDate = Convert.ToDateTime(rgbTglKunjungan.FromDate);
            rgbTglKunjungan.ToDate = new DateTime(fromDate.Year, fromDate.Month, DateTime.DaysInMonth(fromDate.Year, fromDate.Month));
            
            rgbTglKunjungan.Enabled = false;
            RefreshSales();
            customGridView1.Focus();
            RefreshRencana();

        }

        public void RefreshSales()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_FixSales_List"));
                dtSales = db.Commands[0].ExecuteDataTable();
                customGridView1.DataSource = dtSales;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        public void RefreshRencana()
        {
            //string _sales = customGridView1.SelectedCells[0].OwningRow.Cells["Kode_Sales"].Value.ToString();
            //using (Database db = new Database())
            //{
            //    db.Commands.Add(db.CreateCommand("usp_FixRencana_List"));
            //    db.Commands[0].Parameters.Add(new Parameter("@kdsales", SqlDbType.VarChar, _sales));
            //    if (cbFilter.Checked == true)
            //    {
            //        db.Commands[0].Parameters.Add(new Parameter("@Tgl1", SqlDbType.DateTime, dateTextBox1.DateValue));
            //    }
            //    dtRencana = db.Commands[0].ExecuteDataTable();
            //    customGridView2.DataSource = dtRencana;
            //    customGridView2.Columns["Tmt1"].DefaultCellStyle.Format = "dd'/'MM'/'yyyy";
            //}
        }
         
        private void customGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmdPrintRegisterKunjungan.Enabled = true;
            string _kode_sales = customGridView1.SelectedCells[0].OwningRow.Cells["Kode_Sales"].Value.ToString();
            txtKodeSales.Text = _kode_sales;
            cbHari.SelectedItem = "ALL";
            cmdKunjunganBaru.Enabled = true;
            RefreshRencana();
        }

        private void customGridView2_Click(object sender, EventArgs e)
        {
            cmdPrintRegisterKunjungan.Enabled = false;
        }

        private void cmdKunjunganBaru_Click(object sender, EventArgs e)
        {
            cbHari.Enabled = true;
            cmdProses.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox1.Checked == true)
            //{
            //    rgbTglKunjungan.Enabled = true;
            //}
            //else
            //{
            //    rgbTglKunjungan.Enabled = false;
            //}
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                txtKota.Enabled = true;
            }
            else
            {
                txtKota.Enabled = false;
                txtKota.Text = "";
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                txtDaerah.Enabled = true;
            }
            else
            {
                txtDaerah.Enabled = false;
                txtDaerah.Text = "";
            }
        }


        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void datetoHari(DateTime tanggal)
        {
            int tgl1 = Convert.ToInt32(tanggal.DayOfWeek);
            switch (tgl1)
            {
                case 1:
                    hari1 = "SENIN";
                    break;
                case 2:
                    hari1 = "SELASA";
                    break;
                case 3:
                    hari1 = "RABU";
                    break;
                case 4:
                    hari1 = "KAMIS";
                    break;
                case 5:
                    hari1 = "JUMAT";
                    break;
                case 6:
                    hari1 = "SABTU";
                    break;
                case 0:
                    hari1 = "MINGGU";
                    break;

            }
        }

        public void hariTodate(string hari)
        {
            //int tgl = Convert.ToInt16(tanggal.DayOfWeek);
            switch (hari)
            {
                case "SENIN":
                    tgl = 1;
                    break;
                case "SELASA":
                    tgl = 2;
                    break;
                case "RABU":
                    tgl = 3;
                    break;
                case "KAMIS":
                    tgl = 4;
                    break;
                case "JUMAT":
                    tgl = 5;
                    break;
                case "SABTU":
                    tgl = 6;
                    break;
                case "MINGGU":
                    tgl = 7;
                    break;

            }
        }
        
        private void cmdProses_Click(object sender, EventArgs e)
        {
            string _KdSales = txtKodeSales.Text.ToString();
            DateTime _tgl1 = rgbTglKunjungan.FromDate.Value;
            DateTime _tgl2 = rgbTglKunjungan.ToDate.Value;
            string _kota = txtKota.Text.ToString();
            string _filterHari = cbHari.SelectedItem.ToString();
            string _daerah = txtDaerah.Text;

            if (rdbKunjungan.Checked == true)
            {
                Fixrute.frmGetDataKunjungan ifrmChild = new frmGetDataKunjungan(this, _KdSales, _filterHari, _kota, _daerah, _tgl1, _tgl2);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            else if (rdbFixroute.Checked == true)
            {
                Fixrute.frmGetdataFixrute ifrmChild = new frmGetdataFixrute(this, _KdSales, _filterHari, _kota, _daerah, _tgl1, _tgl2);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
        }

        private void commandButton4_Click(object sender, EventArgs e)
        {
            Fixrute.frmFixruteSalesList ifrmChild = new frmFixruteSalesList();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void frmFixRuteSalesman_Click(object sender, EventArgs e)
        {
           
        }

        private void commandButton3_Click(object sender, EventArgs e)
        {
            string sales = customGridView1.SelectedCells[0].OwningRow.Cells["Kode_Sales"].Value.ToString();
            Fixrute.frmCetakRencanaKunjungan ifrmChild = new frmCetakRencanaKunjungan(this, sales);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void hapusData()
        {

            if (customGridView2.SelectedCells.Count > 0)
            {
                Guid RowID_ = (Guid)customGridView2.SelectedCells[0].OwningRow.Cells["_RowID"].Value;
                string NamaToko = customGridView2.SelectedCells[0].OwningRow.Cells["_NamaToko"].Value.ToString();
                if (MessageBox.Show("Hapus Data : " + NamaToko + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_FixRencana_Delete"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, RowID_));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        MessageBox.Show("Record telah dihapus");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void Update2FixHari()
        {
            //DataTable dtHari = new DataTable();
            //dtHari.Columns.Add("RowID");
            //dtHari.Columns.Add("Tanggal");
            int i = 0;
            //DataTable dt = new DataTable();
            _sales = customGridView1.SelectedCells[0].OwningRow.Cells["Kode_Sales"].Value.ToString();
            //tanggalAwal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            tanggalAwal = Convert.ToDateTime(customGridView2.SelectedCells[0].OwningRow.Cells["tmt1"].Value);
            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("[usp_FixRencana_Link]"));
                db.Commands[0].Parameters.Add(new Parameter("@kdsales", SqlDbType.VarChar, _sales));
                db.Commands[0].Parameters.Add(new Parameter("@date", SqlDbType.VarChar, tanggalAwal));
                dtRencana = db.Commands[0].ExecuteDataTable();
            }

            for (i = 0; i < dtRencana.Rows.Count; i++)
            {
                //Guid rowidRencana;
                //DateTime tglFixHari;
                //string idrec = Tools.CreateFingerPrint;
                rowid = (Guid)(dtRencana.Rows[i]["RowID"]);
                tanggal = Convert.ToDateTime(dtRencana.Rows[i]["tmt1"]);
                bulan = tanggal.Month;
                tahun = tanggal.Year;
                day = Convert.ToString(dtRencana.Rows[i]["hari"]).ToUpper();
                kodesales = dtRencana.Rows[i]["kd_sales"].ToString();
                namatoko = dtRencana.Rows[i]["namatoko"].ToString();
                alamat = dtRencana.Rows[i]["alamat"].ToString();
                kdtoko = dtRencana.Rows[i]["kd_toko"].ToString();
                days = DateTime.DaysInMonth(tahun, bulan);
                
                for (int n = 1; n <= days; n++)
                {
                   tglFix = new DateTime(tahun, bulan, n);
                   string a = GetWeekOfMonth(tglFix).ToString();
                   Console.WriteLine(tglFix + " - " + a);
                   //MessageBox.Show(dtRencana.Rows[i]["mg1"].ToString());
                   if (dtRencana.Rows[i]["mg1"].ToString() == "True")//&& a=="1")
                   {
                       if (a == "1")
                       {
                           cek();
                       }
                   }
                   if (Convert.ToString(dtRencana.Rows[i]["mg2"]) == "True") //&& a == "2")
                   {
                       if (a == "2")
                       {
                           cek();
                       }
                   }
                   if (Convert.ToString(dtRencana.Rows[i]["mg3"]) == "True")//&& a == "3")
                   {
                       if (a == "3")
                       {
                           cek();
                       }
                   }
                   if (Convert.ToString(dtRencana.Rows[i]["mg4"]) == "True")//&& a == "4")
                   {
                       if (a == "4")
                       {
                           cek();
                       }
                   }
                   if (Convert.ToString(dtRencana.Rows[i]["mg5"]) == "True")//&& a == "5")
                   {
                       if (a == "5")
                       {
                           cek();
                       }
                   }
                   if (Convert.ToString(dtRencana.Rows[i]["mg6"]) == "True")//&& a == "5")
                   {
                       if (a == "6")
                       {
                           cek();
                       }
                   }
                    //hariTodate(day);
                    //datetoHari(tglFix);

                }

            }

            MessageBox.Show("Data Telah Behasil DiLink");
            #region ijo2
            //DateTime tmt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            //for (i = 0; i < dt.Rows.Count; i++)
            //{
            //    using (Database db = new Database())
            //    {
            //        try
            //        {
            //            db.BeginTransaction();
            //            db.Commands.Add(db.CreateCommand("usp_Fix_LinkFixrute"));
            //            db.Commands[0].Parameters.Add(new Parameter("@tmt", SqlDbType.DateTime, tmt));
            //            db.Commands[0].Parameters.Add(new Parameter("@sales", SqlDbType.VarChar, _sales));
            //            db.Commands[0].ExecuteNonQuery();
            //            db.CommitTransaction();
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message);
            //            db.RollbackTransaction();
            //            MessageBox.Show("Gagal Menyimpan Data");
            //        }
            //    }
            //}
            #endregion
        }


        private void cek()
        {
            hariTodate(day);
            datetoHari(tglFix);
            if (day == hari1)
            {
                tglFixHari = tglFix;
                rowidRencana = rowid;

                DataTable dtfix = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_cekFixHari]"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodesales", SqlDbType.VarChar, _sales));
                    db.Commands[0].Parameters.Add(new Parameter("@tanggal", SqlDbType.VarChar, tglFixHari));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaToko", SqlDbType.VarChar, namatoko));
                    db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, alamat));
                    db.Commands[0].Parameters.Add(new Parameter("@kd_toko", SqlDbType.VarChar, kdtoko));
                    dtfix = db.Commands[0].ExecuteDataTable();
                }

                if (dtfix.Rows.Count > 0)
                {
                    Guid Row = (Guid)(dtfix.Rows[0]["RowID"]);
                    DateTime tmt1 = Convert.ToDateTime(dtfix.Rows[0]["tmt1"]);
                    using (Database db = new Database())
                    {
                        db.BeginTransaction();
                        db.Commands.Add(db.CreateCommand("[usp_Fix_insertFixHariLink_update]"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Row));
                        db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, tmt1));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        db.CommitTransaction();
                    }
                }
                else
                {
                    //insert ke fix
                    using (Database db = new Database())
                    {
                        db.BeginTransaction();
                        db.Commands.Add(db.CreateCommand("[usp_Fix_insertFixHariLink]"));
                        db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                        db.Commands[0].Parameters.Add(new Parameter("@tanggal", SqlDbType.DateTime, tglFixHari));
                        db.Commands[0].Parameters.Add(new Parameter("@kodesales", SqlDbType.VarChar, kodesales));
                        db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, tanggalAwal));
                        db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, rowidRencana));
                        db.Commands[0].ExecuteNonQuery();
                        db.CommitTransaction();
                    }
                }
            }
        }
        

        public static int GetWeekOfMonth(DateTime date)
        {
            DateTime beginningOfMonth = new DateTime(date.Year, date.Month, 1);

            while (date.Date.AddDays(1).DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
                date = date.AddDays(1);

            return (int)Math.Truncate((double)date.Subtract(beginningOfMonth).TotalDays / 7f) + 1;
        } 


        private void commandButton2_Click(object sender, EventArgs e)
        {
            if (customGridView2.Rows.Count > 0)
            {
                string _namaSales = customGridView1.SelectedCells[0].OwningRow.Cells["Nama_Sales"].Value.ToString();
                DateTime dTgl = (DateTime)customGridView2.SelectedCells[0].OwningRow.Cells["tmt1"].Value;
                String _TglAwal = dTgl.ToString("dd MMM yyyy");



                if (MessageBox.Show("Apakah data ini mau dijadikan Fixrute Salesman " + _namaSales + " dengan tanggal awal : "+ _TglAwal +" ?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //MessageBox.Show( GetWeekOfMonth(DateTime.Now).ToString());
                    Update2FixHari();
                }
            }
            else
            {
                MessageBox.Show("Tidak ada record.");
            }
        }

        private void cmdPrintRegisterKunjungan_Click(object sender, EventArgs e)
        {
            string sales = customGridView1.SelectedCells[0].OwningRow.Cells["Kode_Sales"].Value.ToString();
            Fixrute.frmCetakRegisterRencanaKunjungan ifrmChild = new frmCetakRegisterRencanaKunjungan(this, sales);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dateTextBox1_TextChanged(object sender, EventArgs e)
        {
            DateTime dTime = Convert.ToDateTime(dateTextBox1.DateValue);
            dateTextBox2.DateValue = dTime.AddMonths(1).AddDays(-1);

            //dateTextBox2.DateValue = new DateTime(dTime.Year, dTime.Month, DateTime.DaysInMonth(dTime.Year, dTime.Month));
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string _sales = customGridView1.SelectedCells[0].OwningRow.Cells["Kode_Sales"].Value.ToString();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_FixRencana_List"));
                db.Commands[0].Parameters.Add(new Parameter("@kdsales", SqlDbType.VarChar, _sales));
                db.Commands[0].Parameters.Add(new Parameter("@Tgl1", SqlDbType.DateTime, dateTextBox1.DateValue));
                dtRencana = db.Commands[0].ExecuteDataTable();
                customGridView2.DataSource = dtRencana;
                customGridView2.Columns["Tmt1"].DefaultCellStyle.Format = "dd'/'MM'/'yyyy";
            }
        }

        private void cbFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFilter.Checked == true)
            {
                dateTextBox1.Enabled = true;
                if (dateTextBox1.DateValue == null)
                {
                    dateTextBox1.DateValue = new DateTime(GlobalVar.DateOfServer.Year, GlobalVar.DateOfServer.Month, 1);
                }
                btnFilter.Enabled = true;
                commandButton2.Enabled = true;
                cmdAdd2.Enabled = true;
                btnFilter.PerformClick();
            }
            else
            {
                dateTextBox1.Enabled = false;
                dateTextBox1.Enabled = false;
                btnFilter.Enabled = false;
                commandButton2.Enabled = false;
                cmdAdd2.Enabled = false;
                RefreshRencana();
                //txtTglFrom2.Enabled = false;
            }
        }

        private void frmFixRuteSalesman_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            //if (e.KeyChar == (char)Keys.Enter) { MessageBox.Show("Enter key pressed"); }
            //if (e.KeyChar == (char)Keys.Insert) { MessageBox.Show("Insert key pressed"); }
            //if (e.KeyChar == (char)Keys.Delete) { MessageBox.Show("Delete key pressed"); }

        }

        private void customGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert) 
            {
                cmdAdd2.PerformClick();
            }
            else if (e.KeyCode == Keys.Space)
            {
                cmdEdit2.PerformClick();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                cmdDelete2.PerformClick();
            }
        }

        private void cmdEdit2_Click(object sender, EventArgs e)
        {
            if (customGridView2.SelectedCells.Count > 0)
            {
                if (customGridView2.Focused || cmdEdit2.Focused)
                {
                    int hasil;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_FixRencana_CekDelete"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, (Guid)customGridView2.SelectedCells[0].OwningRow.Cells["_RowID"].Value));
                        hasil = Convert.ToInt32(db.Commands[0].ExecuteScalar());
                    }
                    if (hasil > 0 && SecurityManager.UserID.ToString().ToUpper() != "MANAGER")
                    {
                        MessageBox.Show("Data tidak bisa diedit karena sudah di link fixroute.");
                    }
                    else
                    {
                        string sales = customGridView2.SelectedCells[0].OwningRow.Cells["kd_Sales"].Value.ToString();
                        String asd = customGridView2.SelectedCells[0].OwningRow.Cells["_RowID"].Value.ToString();
                        Guid RowID = (Guid)customGridView2.SelectedCells[0].OwningRow.Cells["_RowID"].Value;
                        Fixrute.frmRencanaKunjunganSalesman ifrmChild = new frmRencanaKunjunganSalesman(this, RowID, sales);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
                }
            }
        }

        private void cmdDelete2_Click(object sender, EventArgs e)
        {
            if (customGridView2.SelectedCells.Count > 0)
            {
                if (customGridView2.Focused || cmdDelete2.Focused)
                {
                    int hasil;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_FixRencana_CekDelete"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, (Guid)customGridView2.SelectedCells[0].OwningRow.Cells["_RowID"].Value));
                        hasil = Convert.ToInt32(db.Commands[0].ExecuteScalar());
                    }
                    if (hasil > 0 && SecurityManager.UserID.ToString().ToUpper() != "MANAGER")
                    {
                        MessageBox.Show("Data tidak bisa dihapus karena sudah di link fixroute.");
                    }
                    else
                    {
                        hapusData();
                        RefreshRencana();
                    }
                }
            }
        }

        private void cmdAdd2_Click(object sender, EventArgs e)
        {
            if (customGridView2.Focused || cmdAdd2.Focused)
            {
                //if (customGridView2.SelectedCells.Count > 0 || customGridView2.SelectedCells.Count == 0)
                if (customGridView1.SelectedCells.Count > 0 && cmdAdd2.Enabled == true)
                {
                    DateTime dTime = Convert.ToDateTime(dateTextBox1.DateValue);
                    string sales = customGridView1.SelectedCells[0].OwningRow.Cells["Kode_Sales"].Value.ToString();
       
                    Fixrute.frmRencanaKunjunganSalesman ifrmChild = new frmRencanaKunjunganSalesman(this, sales, dTime);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
            }
        }

        private void dateTextBox1_Leave(object sender, EventArgs e)
        {
            DateTime dTime = Convert.ToDateTime(dateTextBox1.DateValue);
            //dateTextBox1.DateValue = new DateTime(dTime.Year, dTime.Month, 1);
        }

        private void rdbFixroute_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFixroute.Checked == true)
            {
                rgbTglKunjungan.Enabled = true;
            }
            else
            {
                rgbTglKunjungan.Enabled = false;
            }
        }

        private void rdbKunjungan_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbKunjungan.Checked == true)
            {
                rgbTglKunjungan.Enabled = true;
            }
            else
            {
                rgbTglKunjungan.Enabled = false;
            }

        }

        public void FindHeader(string columnName, string value)
        {
            customGridView2.FindRow(columnName, value);
        }

        private void customGridView1_SelectionRowChanged(object sender, EventArgs e)
        {
            RefreshRencana();
        }
    }
}
