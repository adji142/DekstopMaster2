using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlTypes;

namespace ISA.Toko.AKC
{
    public partial class frmCollectorUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string collectorID;
        DataTable dtCollector;

        private bool validasi()
        {
            if (txtKode.Text == "")
            {
                MessageBox.Show("Silahkan Masukkan Kode");
                return false;
            }else if (txtNama.Text == "")
            {
                MessageBox.Show("Silahkan Masukkan Nama");
                return false;
            }
            
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_AKC_Collector_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, txtKode.Text));
               dt = db.Commands[0].ExecuteDataTable();

            }

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Kode Sudah ada");
                return false;
            }

            return true;
        }

        private void RefreshGridCaller()
        {
            if (this.Caller is frmMasterCollector)
            {
                frmMasterCollector frmCaller = (frmMasterCollector)this.Caller;
                frmCaller.RefreshRowData(collectorID);
               // frmCaller.RefreshDataCollector();
            }
        }

        private void fillUpdateField(){

            dtCollector = new DataTable();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtCollector = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_AKC_Collector_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, collectorID));
                    dtCollector = db.Commands[0].ExecuteDataTable();

                }
                //txtTahunBerdiri.DateValue = Convert.ToDateTime(dtH.Rows[0]["dbangun"]);
                txtKode.Text = dtCollector.Rows[0]["Kode"].ToString();
                txtNama.Text = dtCollector.Rows[0]["Nama"].ToString();
                 if (!dtCollector.Rows[0]["TglLahir"].ToString().Equals(""))
                {
                    txtTglLahir.DateValue = Convert.ToDateTime(dtCollector.Rows[0]["TglLahir"]);
                }
                 txtAlamat.Text = dtCollector.Rows[0]["Alamat"].ToString();
                 txtTarget.Text = dtCollector.Rows[0]["Target"].ToString();
                 if (!dtCollector.Rows[0]["TglMasuk"].ToString().Equals(""))
                 {
                     txtTglMasuk.DateValue = Convert.ToDateTime(dtCollector.Rows[0]["TglMasuk"]);
                 }
                 if (!dtCollector.Rows[0]["TglKeluar"].ToString().Equals(""))
                 {
                    txtTglKlr.DateValue = Convert.ToDateTime(dtCollector.Rows[0]["TglKeluar"]);
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

        private void UpdateData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string _collection = collectorID;
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_AKC_Collector_LIST_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, _collection));
                    db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, txtKode.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, txtAlamat.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@TglLahir", SqlDbType.DateTime, txtTglLahir.DateValue.HasValue ? txtTglLahir.DateValue.Value : SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@Target", SqlDbType.Int, txtTarget.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@TglMasuk", SqlDbType.DateTime, txtTglMasuk.DateValue.HasValue ? txtTglMasuk.DateValue.Value : SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@TglKeluar", SqlDbType.DateTime, txtTglKlr.DateValue.HasValue ? txtTglKlr.DateValue.Value : SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
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
                string _collection = DateTime.Now.ToString("DDMMyyyyHH:mm:ss tt ");
                collectorID = _collection;
                using (Database db = new Database())
                { 

                    db.Commands.Add(db.CreateCommand("usp_AKC_Collector_LIST_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, _collection));
                    db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, txtKode.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, txtAlamat.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@TglLahir", SqlDbType.DateTime , txtTglLahir.DateValue.HasValue ? txtTglLahir.DateValue.Value : SqlDateTime.Null ));
                    db.Commands[0].Parameters.Add(new Parameter("@Target", SqlDbType.Int, txtTarget.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@TglMasuk", SqlDbType.DateTime, txtTglMasuk.DateValue.HasValue ? txtTglMasuk.DateValue.Value : SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@TglKeluar", SqlDbType.DateTime, txtTglKlr.DateValue.HasValue ? txtTglKlr.DateValue.Value : SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0 ));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
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


        public frmCollectorUpdate()
        {
            InitializeComponent();
        }

        public frmCollectorUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmCollectorUpdate(Form caller , string _collectorID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            this.Caller = caller;
            collectorID = _collectorID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
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
                        UpdateData();
                        break;
                }
                this.DialogResult = DialogResult.OK;

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

        private void frmCollectionUpdate_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case enumFormMode.New :
                    this.Title = "Insert Collector";
                    this.Text = "AKC Collector";
                    break;
                case enumFormMode.Update :
                    this.Title = "Update Collector";
                    this.Text = "AKC Collector";
                    txtKode.ReadOnly = true;
                    fillUpdateField();
                    break;

            }
            
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
