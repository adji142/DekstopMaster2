using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Fixrute
{
    public partial class frmRencanaKunjunganSalesman : ISA.Toko.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _RowID;
        string _sales, cek;

        public frmRencanaKunjunganSalesman(Form caller, Guid RowID, string sales)
        {
            this.Caller = caller;
            _RowID = RowID;
            _sales = sales;
            formMode = enumFormMode.Update;
            InitializeComponent();
        }

        public frmRencanaKunjunganSalesman(Form caller, string sales)
        {
            this.Caller = caller;
            _sales = sales;
            formMode = enumFormMode.New;
            InitializeComponent();
        }
        public frmRencanaKunjunganSalesman()
        {
            InitializeComponent();
        }

        private void frmRencanaKunjunganSalesman_Load(object sender, EventArgs e)
        {
            switch (formMode)
         {
         case enumFormMode.New:
                 try
                 {
                     txtKodeSales.Text = _sales;
                     txtKodeSales.Enabled = false;
                     rgbTglBerlaku.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                     rgbTglBerlaku.ToDate = DateTime.Now;
                     dateTextBox2.Enabled = false;
                     dateTextBox1.Enabled = false;
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
                lookupToko1.KodeToko = Tools.isNull(dt.Rows[0]["kd_sales"], "").ToString();
                txtKodeSales.Text = Tools.isNull(dt.Rows[0]["kd_sales"], "").ToString();
                txtAlamat.Text = Tools.isNull(dt.Rows[0]["alamat"], "").ToString();
                txtKota.Text = Tools.isNull(dt.Rows[0]["kota"], "").ToString();
                txtKecamatan.Text = Tools.isNull(dt.Rows[0]["kecamatan"], "").ToString();
                cbHari.SelectedItem = Tools.isNull(dt.Rows[0]["hari"], "").ToString();
                cbJenis.SelectedItem = Tools.isNull(dt.Rows[0]["jenis"], "").ToString();
                dateTextBox1.Text = Tools.isNull(dt.Rows[0]["tmt1"], "").ToString();
                dateTextBox2.Text = Tools.isNull(dt.Rows[0]["tmt2"], "").ToString();
                lookupToko1.Enabled = false;
                txtAlamat.Enabled = false;
                txtKodeSales.Enabled = false;
                txtKota.Enabled = false;
                txtKecamatan.Enabled = false;
                rgbTglBerlaku.Enabled = false;
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
            rgbTglBerlaku.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTglBerlaku.ToDate = DateTime.Now;
            string _alamat = lookupToko1.Alamat;
            txtAlamat.Text = _alamat;
            string _kota = lookupToko1.Kota;
            txtKota.Text = _kota;
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
            }
            else 
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
            }
            if (cbJenis.SelectedItem == "B")
            {
                
                checkBox2.Checked = true;
                checkBox4.Checked = true;
                
            }
        }

        private void simpan()
        {
            switch (formMode)
            {
                case enumFormMode.New:
                    try
                    {
                        DataTable dt = new DataTable();

                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_fixRencana_Insert"));
                            db.Commands[0].Parameters.Add(new Parameter("@kd_sales", SqlDbType.VarChar, txtKodeSales.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, rgbTglBerlaku.FromDate.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@tmt2", SqlDbType.DateTime, rgbTglBerlaku.ToDate.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@hari", SqlDbType.VarChar, cbHari.SelectedItem.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@jenis", SqlDbType.VarChar, cbJenis.SelectedItem.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@namatoko", SqlDbType.VarChar, lookupToko1.NamaToko.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, lookupToko1.Daerah.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@kecamatan", SqlDbType.VarChar, txtKecamatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@mg1", SqlDbType.Bit, checkBox1.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@mg2", SqlDbType.Bit, checkBox2.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@mg3", SqlDbType.Bit, checkBox3.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@mg4", SqlDbType.Bit, checkBox4.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@mg5", SqlDbType.Bit, checkBox5.Checked));
                            dt = db.Commands[0].ExecuteDataTable();
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
                            db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, dateTextBox1.Text));
                            if (dateTextBox2.Text == "")
                            {
                            }
                            else
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@tmt2", SqlDbType.DateTime, dateTextBox2.Text));
                            }
                            db.Commands[0].Parameters.Add(new Parameter("@hari", SqlDbType.VarChar, cbHari.SelectedItem.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@jenis", SqlDbType.VarChar, cbJenis.SelectedItem.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@namatoko", SqlDbType.VarChar, lookupToko1.NamaToko.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text));
                            if (txtKecamatan.Text == "")
                            {
                            }
                            else
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@kecamatan", SqlDbType.VarChar, txtKecamatan.Text));
                            }
                            db.Commands[0].Parameters.Add(new Parameter("@mg1", SqlDbType.Bit, checkBox1.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@mg2", SqlDbType.Bit, checkBox2.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@mg3", SqlDbType.Bit, checkBox3.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@mg4", SqlDbType.Bit, checkBox4.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@mg5", SqlDbType.Bit, checkBox5.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                            MessageBox.Show("Data Berhasil Di simpan");
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                        MessageBox.Show("Gagal Menyimpan Data");
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }


                    break;
            }
        }


        private void cbSave_Click(object sender, EventArgs e)
        {
            simpan();
            frmFixRuteSalesman frmCaller = (frmFixRuteSalesman)this.Caller;
            frmCaller.RefreshRencana();
            this.Close();
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

                if (lookupToko1.NamaToko == "")
                {
                    txtAlamat.Text = "";
                    txtKota.Text = "";
                    txtKecamatan.Text = "";
                }
            }
        }
    }
}
