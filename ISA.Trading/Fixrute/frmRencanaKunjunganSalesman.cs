using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Fixrute
{
    public partial class frmRencanaKunjunganSalesman : ISA.Trading.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _RowID;
        string _sales, cek;
        bool mg6 = false;
        DateTime _tmt;
        string _KodeToko;

        public frmRencanaKunjunganSalesman(Form caller, Guid RowID, string sales)
        {
            this.Caller = caller;
            _RowID = RowID;
            _sales = sales;
            formMode = enumFormMode.Update;
            InitializeComponent();
        }

        public frmRencanaKunjunganSalesman(Form caller, string sales, DateTime tgl)
        {
            this.Caller = caller;
            _sales = sales;
            _tmt = tgl;
            formMode = enumFormMode.New;
            InitializeComponent();
        }
        public frmRencanaKunjunganSalesman()
        {
            InitializeComponent();
        }

        private void frmRencanaKunjunganSalesman_Load(object sender, EventArgs e)
        {
            dateTextBox1.Enabled = true;
            dateTextBox2.Enabled = false;
            switch (formMode)
         {
         case enumFormMode.New:
                 try
                 {
                     txtKodeSales.Text = _sales;
                     txtKodeSales.Enabled = false;
                     dateTextBox1.DateValue = new DateTime(_tmt.Year, _tmt.Month, 1);
                     cek_mg6();
                     //dateTextBox1.DateValue = (DateTime)GlobalVar.DateTimeOfServer;
                     txtAlamat.Enabled = false;
                     txtKota.Enabled = false;
                     txtKecamatan.Enabled = true;
                 }
                 catch (System.Exception ex)
                 {
                     Error.LogError(ex);
                 }
                 finally
                 {
                     this.Cursor = Cursors.Default;
                 }

         	break;

         case enumFormMode.Update:
            try
            {
                DataTable dt = new DataTable();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_FixRencana_Update"));
                    //db.Commands[0].Parameters.Add(new Parameter("@kdsales", SqlDbType.VarChar, _sales));
                    db.Commands[0].Parameters.Add(new Parameter("@row", SqlDbType.UniqueIdentifier, _RowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                
                lookupToko1.NamaToko = Tools.isNull(dt.Rows[0]["namatoko"],"").ToString();
                lookupToko1.KodeToko = Tools.isNull(dt.Rows[0]["kd_toko"], "").ToString();
                txtKodeSales.Text = Tools.isNull(dt.Rows[0]["kd_sales"], "").ToString();
                txtAlamat.Text = Tools.isNull(dt.Rows[0]["alamat"], "").ToString();
                txtKota.Text = Tools.isNull(dt.Rows[0]["kota"], "").ToString();
                txtKecamatan.Text = Tools.isNull(dt.Rows[0]["kecamatan"], "").ToString();
                cbHari.SelectedItem = Tools.isNull(dt.Rows[0]["hari"], "").ToString().ToUpper();
                cbJenis.SelectedItem = Tools.isNull(dt.Rows[0]["jenis"], "").ToString();
                _KodeToko = Tools.isNull(dt.Rows[0]["kd_toko"], "").ToString();

                if (Tools.isNull(dt.Rows[0]["mg1"], "").ToString().ToLower() == "true") { checkBox1.Checked = true; } else { checkBox1.Checked = false; }
                if (Tools.isNull(dt.Rows[0]["mg2"], "").ToString().ToLower() == "true") { checkBox2.Checked = true; } else { checkBox2.Checked = false; }
                if (Tools.isNull(dt.Rows[0]["mg3"], "").ToString().ToLower() == "true") { checkBox3.Checked = true; } else { checkBox3.Checked = false; }
                if (Tools.isNull(dt.Rows[0]["mg4"], "").ToString().ToLower() == "true") { checkBox4.Checked = true; } else { checkBox4.Checked = false; }
                if (Tools.isNull(dt.Rows[0]["mg5"], "").ToString().ToLower() == "true") { checkBox5.Checked = true; } else { checkBox5.Checked = false; }
                if (Tools.isNull(dt.Rows[0]["mg6"], "").ToString().ToLower() == "true") { checkBox6.Checked = true; } else { checkBox6.Checked = false; }

                if (dt.Rows[0]["tmt1"].ToString() != "")
                {
                    dateTextBox1.DateValue = (DateTime)dt.Rows[0]["tmt1"];
                }
                if (dt.Rows[0]["tmt2"].ToString() != "")
                {
                    dateTextBox2.DateValue = (DateTime)dt.Rows[0]["tmt2"];
                }
                cek_mg6();
                lookupToko1.Enabled = false;
                txtAlamat.Enabled = false;
                txtKodeSales.Enabled = false;
                txtKota.Enabled = false;
                txtKecamatan.Enabled = false;
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }


            break;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lookupToko1_Load(object sender, EventArgs e)
        {

        }

        private void lookupToko1_Leave(object sender, EventArgs e)
        {
            string _alamat = lookupToko1.Alamat;
            txtAlamat.Text = _alamat;
            string _kota = lookupToko1.Kota;
            txtKota.Text = _kota;
            _KodeToko = lookupToko1.KodeToko;
        }

        private void lookupToko1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbJenis.SelectedItem == "W")
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                if (mg6 == true)
                {
                    checkBox6.Checked = true;
                }
            }
            else if (cbJenis.SelectedItem == "B")
            {
                checkBox1.Checked = false;
                checkBox2.Checked = true;
                checkBox3.Checked = false;
                checkBox4.Checked = true;
                checkBox5.Checked = false ;
                if (mg6 == true)
                {
                    checkBox6.Checked = false;
                }
            }
            else 
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
            }
        }

        private bool simpan()
        {
            String jenis; bool cekSimpan = true;
            int m1 = Convert.ToInt32(checkBox1.Checked);
            int m2 = Convert.ToInt32(checkBox2.Checked);
            int m3 = Convert.ToInt32(checkBox3.Checked);
            int m4 = Convert.ToInt32(checkBox4.Checked);
            int m5 = Convert.ToInt32(checkBox5.Checked);
            int m6 = Convert.ToInt32(checkBox6.Checked);

            int jml_kunjungan = m1 + m2 + m3 + m4 + m5 + m6;
            if ((m1 + m2 == 1 && m3 + m4 == 1 && m5 + m6 == 1)
                || (m1 + m2 == 0 && m3 + m4 == 1 && m5 + m6 == 1)
                || (m1 + m2 == 1 && m3 + m4 == 0 && m5 + m6 == 1)
                || (m1 + m2 == 1 && m3 + m4 == 1 && m5 + m6 == 0))
            {
                jenis = "B";
            }
            else if (jml_kunjungan == 1)
            {
                jenis = "M";
            }
            else
            {
                jenis = "W";
            }
            
            switch (formMode)
            {
                case enumFormMode.New:
                    try
                    {
                        //DataTable dt = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_fixRencana_Insert"));
                            db.Commands[0].Parameters.Add(new Parameter("@kd_sales", SqlDbType.VarChar, txtKodeSales.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, dateTextBox1.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@tmt2", SqlDbType.DateTime, dateTextBox2.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@hari", SqlDbType.VarChar, cbHari.SelectedItem.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@jenis", SqlDbType.VarChar, jenis));
                            db.Commands[0].Parameters.Add(new Parameter("@namatoko", SqlDbType.VarChar, lookupToko1.NamaToko.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, lookupToko1.Daerah.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@kecamatan", SqlDbType.VarChar, txtKecamatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kd_toko", SqlDbType.VarChar, lookupToko1.KodeToko));
                            db.Commands[0].Parameters.Add(new Parameter("@mg1", SqlDbType.Bit, checkBox1.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@mg2", SqlDbType.Bit, checkBox2.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@mg3", SqlDbType.Bit, checkBox3.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@mg4", SqlDbType.Bit, checkBox4.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@mg5", SqlDbType.Bit, checkBox5.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@mg6", SqlDbType.Bit, checkBox6.Checked));
                            object hasil = db.Commands[0].ExecuteScalar();

                            if (hasil != null)
                            {
                                MessageBox.Show("Toko ini sudah ada, silahkan pilih toko yang lain.");
                                cekSimpan = false;
                            }
                            else { cekSimpan = true; }
                        }  
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }

                    break;

                case enumFormMode.Update:
                    try
                    {
                        DataTable dt = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_fixRencanaList_Update"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@kd_sales", SqlDbType.VarChar, txtKodeSales.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, dateTextBox1.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@hari", SqlDbType.VarChar, cbHari.SelectedItem.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@jenis", SqlDbType.VarChar, jenis));
                            db.Commands[0].Parameters.Add(new Parameter("@namatoko", SqlDbType.VarChar, lookupToko1.NamaToko.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text));
                            if (txtKecamatan.Text != "")
                                db.Commands[0].Parameters.Add(new Parameter("@kecamatan", SqlDbType.VarChar, txtKecamatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@mg1", SqlDbType.Bit, checkBox1.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@mg2", SqlDbType.Bit, checkBox2.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@mg3", SqlDbType.Bit, checkBox3.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@mg4", SqlDbType.Bit, checkBox4.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@mg5", SqlDbType.Bit, checkBox5.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@mg6", SqlDbType.Bit, checkBox6.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@kd_toko", SqlDbType.VarChar, lookupToko1.KodeToko));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                            MessageBox.Show("Data Berhasil Di simpan");
                            cekSimpan = true;
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                        MessageBox.Show("Gagal Menyimpan Data");
                        cekSimpan = false;
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                    break;
            }
            return cekSimpan;
        }


        private void cbSave_Click(object sender, EventArgs e)
        {
            bool cek = validasi_save();

            if (cek == true)
            {
                if (simpan() == true)
                {
                    frmFixRuteSalesman frmCaller = (frmFixRuteSalesman)this.Caller;
                    frmCaller.RefreshRencana();
                    frmCaller.FindHeader("_RowID", _RowID.ToString());
                    this.Close();
                }
            }
            else { return; }
        }

        private bool validasi_save()
        {
            bool cek = true;

            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();

            if (Tools.isNull(cbHari.Text, "").ToString() == "")
            {
                errorProvider1.SetError(cbHari, "*Tidak boleh kosong");
                cek = false;
            }
            if (Tools.isNull(cbJenis.Text, "").ToString() == "")
            {
                errorProvider2.SetError(cbJenis, "*Tidak boleh kosong");
                cek = false;
            }
            if (Tools.isNull(checkBox1.Checked, "False").ToString() == "False" &&
                Tools.isNull(checkBox2.Checked, "False").ToString() == "False" &&
                Tools.isNull(checkBox3.Checked, "False").ToString() == "False" &&
                Tools.isNull(checkBox4.Checked, "False").ToString() == "False" &&
                Tools.isNull(checkBox5.Checked, "False").ToString() == "False" &&
                Tools.isNull(checkBox6.Checked, "False").ToString() == "False")
            {
                if (checkBox6.Visible == true)
                {
                    errorProvider3.SetError(checkBox6, "*Checkbox masih kosong semua");
                }
                else
                { errorProvider3.SetError(checkBox5, "*Checkbox masih kosong semua"); }
                
                cek = false;
            }

            return cek;
        }

        private void dateTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lookupToko1_Validating(object sender, CancelEventArgs e)
        {
            if (lookupToko1.NamaToko.ToString() != string.Empty)
            {
                string _alamat = lookupToko1.Alamat;
                txtAlamat.Text = _alamat;
                txtKota.Text = lookupToko1.Kota;
                _KodeToko = lookupToko1.KodeToko;

                if (lookupToko1.NamaToko == "")
                {
                    txtAlamat.Text = "";
                    txtKota.Text = "";
                    txtKecamatan.Text = "";
                    _KodeToko = "";
                }
            }
        }

        private void cek_mg6()
        {
            DateTime dTime2 = Convert.ToDateTime(dateTextBox1.DateValue);
            String day = dTime2.ToString("dddd");
            if (day == "Saturday" && DateTime.DaysInMonth(dTime2.Year, dTime2.Month) == 31)
            {
                checkBox6.Visible = true;
                mg6 = true;
            }
            else
            {
                mg6 = false;
                checkBox6.Visible = false;
                checkBox6.Checked = false;
            }
        }

        private void dateTextBox1_TextChanged(object sender, EventArgs e)
        {
            DateTime dTime = Convert.ToDateTime(dateTextBox1.DateValue);
            dateTextBox2.DateValue = dTime.AddMonths(1).AddDays(-1);
            //dateTextBox2.DateValue = new DateTime(dTime.Year, dTime.Month, DateTime.DaysInMonth(dTime.Year, dTime.Month));
        }

        private void dateTextBox1_Leave(object sender, EventArgs e)
        {
            DateTime dTime = Convert.ToDateTime(dateTextBox1.DateValue);
            //dateTextBox1.DateValue = new DateTime(dTime.Year, dTime.Month, 1);
            cek_mg6();
        }
    }
}
