using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlTypes;

namespace ISA.Toko.Penjualan
{
    public partial class frmMPRUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        DataTable dt;

        string _NoNotaRet, _type;

        int iNomor;

        string docNoDO = "NOMOR_MPR_RJ";

        public frmMPRUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmMPRUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmMPRUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dt = new DataTable();
                DataTable dtCabang1 = new DataTable();
                DataTable dtCabang2 = new DataTable();
                DataTable dtStaffPenjualan = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
                    dtCabang1 = db.Commands[0].ExecuteDataTable();
                    db.Commands.Add(db.CreateCommand("usp_StaffPenjualan_LIST"));
                    dtStaffPenjualan = db.Commands[1].ExecuteDataTable();

                    if (formMode == enumFormMode.Update)
                    {
                        db.Commands.Add(db.CreateCommand("usp_ReturPenjualan_LIST"));
                        db.Commands[2].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[2].ExecuteDataTable();
                    }                     
                }
                DataColumn cCabangConcatenatedCol = new DataColumn("Concatenated", Type.GetType("System.String"));
                cCabangConcatenatedCol.Expression = "CabangID + ' - ' + Nama";
                dtCabang1.Columns.Add(cCabangConcatenatedCol);
                dtCabang2 = dtCabang1.Copy();
                cboCabang1.DataSource = dtCabang1;
                cboCabang1.DisplayMember = "Concatenated";
                cboCabang1.ValueMember = "CabangID";
                cboCabang2.DataSource = dtCabang2;
                cboCabang2.DisplayMember = "Concatenated";
                cboCabang2.ValueMember = "CabangID";

                if (formMode == enumFormMode.Update)
                {
                    cboCabang1.SelectedValue = Tools.isNull(dt.Rows[0]["Cabang1"], "").ToString();
                    cboCabang2.SelectedValue = Tools.isNull(dt.Rows[0]["Cabang2"], "").ToString();
                    txtTglRQRetur.DateValue = (DateTime)dt.Rows[0]["TglRQRetur"];
                    txtTglMemoRetur.DateValue = (DateTime)dt.Rows[0]["TglMPR"];
                    txtNoMemoRetur.Text = Tools.isNull(dt.Rows[0]["NoMPR"], "").ToString();
                    lookupToko.NamaToko = Tools.isNull(dt.Rows[0]["NamaToko"], "").ToString();
                    lookupToko.KodeToko = Tools.isNull(dt.Rows[0]["KodeToko"], "").ToString();
                    txtAlamat.Text = Tools.isNull(dt.Rows[0]["AlamatKirim"], "").ToString();
                    txtKota.Text = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                }
                else
                {
                    txtTglNotRet.DateValue = DateTime.Now;
                    txtTglRQRetur.DateValue = DateTime.Now;
                    txtTglMemoRetur.DateValue = DateTime.Now;

                    cboCabang1.SelectedValue = GlobalVar.CabangID;
                    cboCabang2.SelectedValue = GlobalVar.CabangID;



                    ///**/
                    //DataTable dtNum = Tools.AutoNumbering(,"");
                    //int lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                    //iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                    //string depan = "";
                    //string belakang = dtNum.Rows[0]["Belakang"].ToString();
                    //iNomor++;



                    _NoNotaRet = Tools.AutoNumbering("NoNotaRetur", "ISADBDepoRetail.dbo.ReturPenjualan");
                    txtNoNotaret.Text = _NoNotaRet;
                    //dtNum.Dispose();
                    /**/
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

        private void lookupToko_SelectData(object sender, EventArgs e)
        {
            txtAlamat.Text = lookupToko.Alamat;
            txtKota.Text = lookupToko.Kota;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            { return; }
            if (txtTglRQRetur.DateValue > GlobalVar.DateOfServer)
            {
                MessageBox.Show("Tgl. RQ Retur tidak bisa diisi lebih besar dari tanggal hari ini. Mohon diisi dengan benar. \n");
                txtTglRQRetur.Focus();
                return;
            }
            try
            {
                switch (formMode)
                {
                    case enumFormMode.New:
                        this.Cursor = Cursors.WaitCursor;

                        _rowID = Guid.NewGuid();
                        string _recID = Tools.CreateFingerPrint();
                        
                        //// Generate No Memo (No MPR)
                        //DataTable dtNum = Tools.GetGeneralNumerator(docNoDO);
                        //int lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                        ////int iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                        //string depan = "";
                        //string belakang = dtNum.Rows[0]["Belakang"].ToString();
                        _NoNotaRet = Tools.AutoNumbering("NoNotaRetur", "ISADBDepoRetail.dbo.ReturPenjualan");
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_ReturPenjualan_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, cboCabang1.SelectedValue ?? ""));
                            db.Commands[0].Parameters.Add(new Parameter("@cabang2", SqlDbType.VarChar, cboCabang2.SelectedValue ?? ""));
                            db.Commands[0].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, _recID));
                            db.Commands[0].Parameters.Add(new Parameter("@noMPR", SqlDbType.VarChar, _NoNotaRet));
                            db.Commands[0].Parameters.Add(new Parameter("@noNotaRetur", SqlDbType.VarChar, _NoNotaRet));
                            db.Commands[0].Parameters.Add(new Parameter("@noTolak", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@tglMPR", SqlDbType.DateTime, txtTglNotRet.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@tglNotaRetur", SqlDbType.DateTime, txtTglNotRet.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, lookupToko.KodeToko));
                            db.Commands[0].Parameters.Add(new Parameter("@tglTolak", SqlDbType.DateTime, SqlDateTime.Null));
                            db.Commands[0].Parameters.Add(new Parameter("@pengambilan", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@tglPengambilan", SqlDbType.DateTime, SqlDateTime.Null));
                            //db.Commands[0].Parameters.Add(new Parameter("@tglGudang", SqlDbType.DateTime, txtTglNotRet.DateValue));

                            db.Commands[0].Parameters.Add(new Parameter("@tglGudang", SqlDbType.DateTime, SqlDateTime.Null));
                            db.Commands[0].Parameters.Add(new Parameter("@bagPenjualan", SqlDbType.VarChar, lookupStafAdm1.Kode));
                            db.Commands[0].Parameters.Add(new Parameter("@penerima", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@linkID", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, false));
                            db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@tglRQRetur", SqlDbType.DateTime, DateTime.Now));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                            //db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                            //db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, docNoDO));
                            //db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                            //db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                            //db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                            //db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                            //db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                                        
                            //EXECUTE COMMANDS
                            db.BeginTransaction();
                            db.Commands[0].ExecuteNonQuery();
                            //db.Commands[1].ExecuteNonQuery();
                            db.CommitTransaction();                            
                        }

                        
                        this.Dispose();

                        Guid _headerID = _rowID;
                        Penjualan.frmMPRDetailUpdate ifrmChild2 = new Penjualan.frmMPRDetailUpdate(this, _headerID, frmMPRDetailUpdate.enumFormMode.New);
                        Program.MainForm.RegisterChild(ifrmChild2);
                        ifrmChild2.ShowDialog();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                       
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_ReturPenjualan_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, cboCabang1.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@cabang2", SqlDbType.VarChar, cboCabang2.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, dt.Rows[0]["ReturID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@noMPR", SqlDbType.VarChar, dt.Rows[0]["NoMPR"]));
                            db.Commands[0].Parameters.Add(new Parameter("@noNotaRetur", SqlDbType.VarChar, dt.Rows[0]["NoNotaRetur"]));
                            db.Commands[0].Parameters.Add(new Parameter("@noTolak", SqlDbType.VarChar, dt.Rows[0]["NoTolak"]));
                            db.Commands[0].Parameters.Add(new Parameter("@tglMPR", SqlDbType.DateTime, dt.Rows[0]["TglMPR"]));
                            db.Commands[0].Parameters.Add(new Parameter("@tglNotaRetur", SqlDbType.DateTime, dt.Rows[0]["TglNotaRetur"]));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, lookupToko.KodeToko));
                            db.Commands[0].Parameters.Add(new Parameter("@tglTolak", SqlDbType.DateTime, dt.Rows[0]["TglTolak"]));
                            db.Commands[0].Parameters.Add(new Parameter("@pengambilan", SqlDbType.VarChar, dt.Rows[0]["Pengambilan"]));
                            db.Commands[0].Parameters.Add(new Parameter("@tglPengambilan", SqlDbType.DateTime, dt.Rows[0]["TglPengambilan"]));
                            db.Commands[0].Parameters.Add(new Parameter("@tglGudang", SqlDbType.DateTime, dt.Rows[0]["TglGudang"]));
                            db.Commands[0].Parameters.Add(new Parameter("@bagPenjualan", SqlDbType.VarChar, lookupStafAdm1.Kode));
                            db.Commands[0].Parameters.Add(new Parameter("@penerima", SqlDbType.VarChar, dt.Rows[0]["Penerima"]));
                            db.Commands[0].Parameters.Add(new Parameter("@linkID", SqlDbType.VarChar, dt.Rows[0]["LinkID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, dt.Rows[0]["isClosed"]));
                            db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, dt.Rows[0]["NPrint"]));
                            db.Commands[0].Parameters.Add(new Parameter("@tglRQRetur", SqlDbType.DateTime, txtTglRQRetur.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, dt.Rows[0]["SyncFlag"]));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        MessageBox.Show("Data telah tersimpan");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;
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

        private bool ValidateInput()
        {
            bool valid = true;
            String pesan = "";
            errorProvider1.Clear();
            

            //  Toko harus ada
            if (txtTglRQRetur.Text == "")
            {
                pesan +="- kolom Tgl RQ Retur masih kosong. Mohon diisi.";
                errorProvider1.SetError(txtTglRQRetur, "kolom Tgl RQ Retur masih kosong. Mohon diisi.");
                valid = false;
            }
            

            //  Toko harus ada
            if (lookupToko.NamaToko.Trim() == "")
            {
                pesan += "- kolom Toko masih kosong. Mohon diisi.";
                errorProvider1.SetError(lookupToko, "kolom Toko masih kosong. Mohon diisi.");
                valid = false;
            }
            if (!valid)MessageBox.Show(pesan, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return valid;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMPRUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmMPRBrowser)
                {
                    frmMPRBrowser frmCaller = (frmMPRBrowser)this.Caller;                    
                    frmCaller.RefreshRowDataReturJual((string) _rowID.ToString());
                    if (formMode == enumFormMode.New)
                    {
                        frmCaller.FindHeader("HeaderRowID", _rowID.ToString());
                    }
                }
            }
        }

    }
}
