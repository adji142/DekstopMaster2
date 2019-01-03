using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;


namespace ISA.Toko.AKC
{
    public partial class frmKunjunganCollectorUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid rowID;
        DataTable dtKunjColl = new DataTable();


        private bool validasi()
        {
            if (txtTglKunj.Text == "")
            {
                MessageBox.Show("Silahkan Masukkan Tanggal Kunjungan");
                return false;
            }
            else if (lookupToko.NamaToko == "")
            {
                MessageBox.Show("Silahkan Masukkan Nama Toko");
                return false;
            }

            return true;
        }

        private void fillDataKunjunganColl()
        {
           
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_AKC_Kunju_Collector_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@ROWID", SqlDbType.UniqueIdentifier, rowID));
                    dt = db.Commands[0].ExecuteDataTable();

                }

                if (!dt.Rows[0]["tglkunj"].ToString().Equals(""))
                {
                    txtTglKunj.DateValue =  Convert.ToDateTime(dt.Rows[0]["tglkunj"]);
                }
                cbcollector.Text = dt.Rows[0]["nm_coll"].ToString();
                cbTransaksi.Text = dt.Rows[0]["jns_tr"].ToString();

                lookupToko.NamaToko = dt.Rows[0]["namatoko"].ToString();
                txtIDWil.Text = dt.Rows[0]["idwil"].ToString();
                txtAlamat.Text = dt.Rows[0]["alamat"].ToString();
                txtKota.Text = dt.Rows[0]["kota"].ToString();
                txtDaerah.Text = dt.Rows[0]["daerah"].ToString();
                txtNomRP.Text = dt.Rows[0]["nominal"].ToString();
                txtNomBG.Text = dt.Rows[0]["nobg"].ToString();
                txtBuktiTrnfr.Text = dt.Rows[0]["notrf"].ToString();
                txtBank.Text = dt.Rows[0]["bank"].ToString();
                txtCatt.Text = dt.Rows[0]["catatan"].ToString();
           
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


        private void RefreshGridCaller()
        {
            if (this.Caller is frmEntryKunjunganCollector)
            {
                frmEntryKunjunganCollector frmCaller = (frmEntryKunjunganCollector)this.Caller;
                frmCaller.RefreshGridFindRow(rowID);
             
            }
        }

        private void UpdateData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
            
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_AKC_Kunju_Collector_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@ROWID", SqlDbType.UniqueIdentifier, rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@tglkunj ", SqlDbType.DateTime, txtTglKunj.DateValue.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@CollectorRowID", SqlDbType.UniqueIdentifier, cbcollector.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@nm_coll", SqlDbType.VarChar, cbcollector.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@kd_toko", SqlDbType.VarChar, lookupToko.KodeToko));
                    db.Commands[0].Parameters.Add(new Parameter("@namatoko", SqlDbType.VarChar, lookupToko.NamaToko));
                    db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, txtDaerah.Text));

                    db.Commands[0].Parameters.Add(new Parameter("@idwil", SqlDbType.VarChar, txtIDWil.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@jns_tr ", SqlDbType.VarChar, cbTransaksi.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@nominal", SqlDbType.Int, txtNomRP.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@nobg", SqlDbType.VarChar, txtNomBG.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@notrf", SqlDbType.VarChar, txtBuktiTrnfr.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@bank", SqlDbType.VarChar, txtBank.Text));

                    db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatt.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@lastupdateby", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();

                }

                RefreshGridCaller();
                this.Close();
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }


        private void insertData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Guid _guid = Guid.NewGuid();
                rowID = _guid;

                using (Database db = new Database())
                {

                    

                    db.Commands.Add(db.CreateCommand("usp_AKC_Kunju_Collector_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@ROWID", SqlDbType.UniqueIdentifier, rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@tglkunj ", SqlDbType.DateTime ,txtTglKunj.DateValue.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@CollectorRowID", SqlDbType.UniqueIdentifier, cbcollector.SelectedValue ));
                    db.Commands[0].Parameters.Add(new Parameter("@nm_coll", SqlDbType.VarChar, cbcollector.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@kd_toko", SqlDbType.VarChar, lookupToko.KodeToko ));
                    db.Commands[0].Parameters.Add(new Parameter("@namatoko", SqlDbType.VarChar , lookupToko.NamaToko ));
                    db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, txtDaerah.Text));

                    db.Commands[0].Parameters.Add(new Parameter("@idwil", SqlDbType.VarChar, txtIDWil.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@jns_tr ", SqlDbType.VarChar, cbTransaksi.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@nominal", SqlDbType.Int , txtNomRP.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@nobg", SqlDbType.VarChar , txtNomBG.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@notrf", SqlDbType.VarChar, txtBuktiTrnfr.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@bank", SqlDbType.VarChar, txtBank.Text));

                    db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatt.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@lastupdateby", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();

                }

                RefreshGridCaller();
                this.Close();
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }


        }

        private void loadDataColector()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Collector_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();

                }

                dt.DefaultView.Sort = "Nama";
                cbcollector.DataSource = dt.DefaultView;
                cbcollector.DisplayMember = "Nama";
                cbcollector.ValueMember = "ROWID";



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

        public frmKunjunganCollectorUpdate()
        {
            InitializeComponent();
        }

        public frmKunjunganCollectorUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmKunjunganCollectorUpdate(Form caller , Guid _rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            this.Caller = caller;
            rowID = _rowID;
        }

        private void frmKunjunganCollectorUpdate_Load(object sender, EventArgs e)
        {
            loadDataColector();

            switch (formMode)
            {
                case enumFormMode.New:
                    this.Title = "Insert Kunjungan Collector";
                    this.Text = "AKC Kunjungan Collector";
                    txtTglKunj.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    break;
                case enumFormMode.Update:
                    this.Title = "Update Kunjungan Collector";
                    this.Text = "AKC Kunjungan Collector";
                    fillDataKunjunganColl();
                    break;

            }
        }

     

        private void lookupToko_SelectData_1(object sender, EventArgs e)
        {
          
            txtAlamat.Text = lookupToko.Alamat;
            txtKota.Text = lookupToko.Kota;
            txtIDWil.Text = lookupToko.WilID;
            txtDaerah.Text = lookupToko.Daerah;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
                switch (formMode)
                {
                    case enumFormMode.New:
                        if (validasi())
                        {
                            insertData();
                        }
                        break;
                    case enumFormMode.Update:
                        if (validasi())
                        {
                            UpdateData();
                        }
                        break;
                }
        }

    
    }
}
