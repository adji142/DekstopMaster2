using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Toko.Kasir
{
    public partial class frmTransaksiPencairanGiro : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _GiroID;
        Guid _rowIDBBM;
        DateTime _TglJT;
        string _NewRecordID; 

        public frmTransaksiPencairanGiro()
        {
            InitializeComponent();
        }

        public frmTransaksiPencairanGiro(Form caller, Guid GiroID,Guid rowIDBBM, DateTime tglJT)
        {
            InitializeComponent();
            _GiroID = GiroID;
            _rowIDBBM = rowIDBBM;
            _TglJT = tglJT;
            this.Caller = caller;

        }



        private void frmTransaksiPencairanGiro_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Add(db.CreateCommand("usp_TransaksiPencairanGiro_LOAD"));

                db.Commands[0].Parameters.Add(new Parameter("@GiroID", SqlDbType.UniqueIdentifier, _GiroID));
                dt = db.Commands[0].ExecuteDataTable();
            }

            txtGiroBank.Text = Tools.isNull(dt.Rows[0]["GiroBank"], "").ToString();
            txtNoGiro.Text = Tools.isNull(dt.Rows[0]["NomorGiro"], "").ToString();
            numNilaiGiro.Text = Tools.isNull(dt.Rows[0]["Nominal"], "").ToString();
            dbTglGiro.Text = Tools.isNull(((DateTime)dt.Rows[0]["TglGiro"]).ToString("dd-MM-yyyy"), "").ToString();
            dbTglJTempo.Text = Tools.isNull(((DateTime)dt.Rows[0]["TglJTempo"]).ToString("dd-MM-yyyy"), "").ToString();
            txtAsalGiro.Text = Tools.isNull(dt.Rows[0]["AsalGiro"], "").ToString();

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (cmbTrans.Text == "" || (cmbTrans.Text != "C" && cmbTrans.Text != "T" && cmbTrans.Text != "B"))
            {
                MessageBox.Show("Cair/Tolak Harus Diisi");
                cmbTrans.Focus();
                return;
            }

            if(dbTglCairBank.Text=="")
            {
                MessageBox.Show("Tanggal Cair Harus Diisi");
                dbTglCairBank.Focus();
                return;
            }

            //if (dbTglCairBank.DateValue < _TglJT)
            //{
            //    MessageBox.Show("Tanggal Cair Tidak Boleh Lebih Kecil dari Tgl J.Tempo.");
            //    dbTglCairBank.Focus();
            //    return;
            //}

            if (MessageBox.Show("Data Akan Disimpan?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GiroCairTolakBatal();
            }
        }


        private void GiroCairTolakBatal()
        {
            string ctb = cmbTrans.Text;
            double NilaiGiro = numNilaiGiro.GetDoubleValue;
            string alasan = txtAlasan.Text;
            _NewRecordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial); 

            try
            {
                using(Database db = new Database(GlobalVar.DBFinance))
                {
                    db.BeginTransaction();
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_Giro_CairTolakBatal_UPDATE"));

                    db.Commands[0].Parameters.Add(new Parameter("@RowIDBBM", SqlDbType.UniqueIdentifier, _rowIDBBM));
                    db.Commands[0].Parameters.Add(new Parameter("@GiroID", SqlDbType.UniqueIdentifier, _GiroID));
                    db.Commands[0].Parameters.Add(new Parameter("@CTB", SqlDbType.VarChar, ctb));
                    db.Commands[0].Parameters.Add(new Parameter("@NilaiGiro", SqlDbType.Money, NilaiGiro));
                    db.Commands[0].Parameters.Add(new Parameter("@NewRecordID", SqlDbType.VarChar, _NewRecordID));                    
                    db.Commands[0].Parameters.Add(new Parameter("@TglCair", SqlDbType.DateTime,  dbTglCairBank.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@alasan", SqlDbType.VarChar, alasan));                    
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                    db.CommitTransaction();
                    
                }
                
                    frmGiroCairTolakBatal frmCaller = (frmGiroCairTolakBatal)this.Caller;
                    //frmCaller = (frmGiroCairTolakBatal)this.Caller;
                    frmCaller.RefreshBBM(_rowIDBBM);
                    frmCaller.findRowBBM("RowID", _rowIDBBM.ToString());
                    frmCaller.RefreshGiro(_GiroID);
                    frmCaller.findrowGiro("RowIDGiro", _GiroID.ToString());
                
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }


        }

        private void frmTransaksiPencairanGiro_FormClosed(object sender, FormClosedEventArgs e)
        {
            

                //frmBukaGiro frm = new frmBukaGiro();
                //frm = (frmBukaGiro)this.Caller;
                //frm.RefreshBBK();
                //frm.FindRowBBK("RowIDBBK", _rowIDBBK.ToString());
                //frm.RefreshGiroInternal();
                //frm.FindRowGiroIn("RowIDGiroIn", _rowIDGiroIn.ToString());
        }

        private void cmbTrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTrans.Text == "T")
            {
                dbTglCairBank.Enabled = false;
                dbTglCairBank.ReadOnly = true;
                dbTglCairBank.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            }
            else if (cmbTrans.Text == "B")
            {
                dbTglCairBank.Enabled = true;
                dbTglCairBank.ReadOnly = false;                
            }
            else
            {
                dbTglCairBank.Enabled = true;
                dbTglCairBank.ReadOnly = false;
                
            }
        }

        private void cmbTrans_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string ct = cmbTrans.Text.Trim().ToUpper();
                bool ketemu = false;
                int i=0;
                while (ketemu != true && i <= 1)
                {
                    if (cmbTrans.Items[i].ToString().Contains(ct))
                    {
                        cmbTrans.SelectedIndex = i;
                        ketemu = true;
                    }
                    else
                        i++;
                }
            }
        }



   

 

 

    

  

      
    }
}
