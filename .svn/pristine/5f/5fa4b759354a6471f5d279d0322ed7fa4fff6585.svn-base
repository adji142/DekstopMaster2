using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlTypes;
using ISA.Toko;

namespace ISA.Toko.Penjualan
{
    public partial class frmNotaReturJualUpdate : ISA.Toko.BaseForm
    {
        Guid _rowID;
        DataTable dt;

        public frmNotaReturJualUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmNotaReturJualUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dt = new DataTable();                
                DataTable dtPenerima = new DataTable();
                DateTime tglGudang;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_StaffPenjualan_LIST")); // cek heri
                    db.Commands.Add(db.CreateCommand("usp_ReturPenjualan_LIST")); //cek heri
                    db.Commands[1].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    
                    dtPenerima = db.Commands[0].ExecuteDataTable();
                    dt = db.Commands[1].ExecuteDataTable();
                }
                cboPenerimaBrg.DataSource = dtPenerima;
                cboPenerimaBrg.DisplayMember = "Nama";
                cboPenerimaBrg.ValueMember = "Nama";
                cboPenerimaBrg.SelectedValue = Tools.isNull(dt.Rows[0]["Penerima"], "").ToString(); 

                txtCabang1.Text = Tools.isNull(dt.Rows[0]["Cabang1"], "").ToString();
                txtCabang2.Text = Tools.isNull(dt.Rows[0]["Cabang2"], "").ToString();
                txtTglRQRetur.DateValue = (DateTime)dt.Rows[0]["TglRqRetur"];
                txtTglMPR.DateValue = (DateTime)dt.Rows[0]["TglMPR"];
                if (dt.Rows[0]["TglGudang"].ToString() == string.Empty)
                {
                    tglGudang = DateTime.Now;
                }
                else
                {
                    tglGudang = (DateTime)dt.Rows[0]["TglGudang"];
                }
                txtTglGudang.DateValue = tglGudang;
                txtNoMPR.Text = Tools.isNull(dt.Rows[0]["NoMPR"], "").ToString();
                txtNoNotaRetur.Text = Tools.isNull(dt.Rows[0]["NoNotaRetur"], "").ToString();
                txtBagPenjualan.Text = Tools.isNull(dt.Rows[0]["BagPenjualan"], "").ToString();
                txtNamaToko.Text = Tools.isNull(dt.Rows[0]["NamaToko"], "").ToString();
                txtAlamat.Text = Tools.isNull(dt.Rows[0]["AlamatKirim"], "").ToString();
                txtKota.Text = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                txtNilaiRetur.Text = Tools.isNull(dt.Rows[0]["NilaiRetur"], "").ToString();               

              
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


            //  Toko harus ada
            if (cboPenerimaBrg.SelectedValue == null)
            {
                MessageBox.Show("Pilih Nama Penerima");
                valid = false;
            }
            return valid;
        }


        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            { return; }
            try
            {
                
                this.Cursor = Cursors.WaitCursor;

                string noNota, numeratorDoc = "NOMOR_NOTA_RJ", depan = "", belakang = "";
                int iNomor =  0, lebar = 0;
                noNota = txtNoNotaRetur.Text;

                bool generateNoNota = false;
                if (noNota == "")
                {
                    // Generate No Nota Retur bila belum ada No Nota Retur
                    DataTable dtNum = Tools.GetGeneralNumerator(numeratorDoc);
                    lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                    depan = "RJ";//Tools.GeneralInitial();
                    belakang = dtNum.Rows[0]["Belakang"].ToString();
                    iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                    iNomor++;
                    noNota = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
                    generateNoNota = true;
                }
                
                

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ReturPenjualan_UPDATE")); // cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, dt.Rows[0]["Cabang1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang2", SqlDbType.VarChar, dt.Rows[0]["Cabang2"]));
                    db.Commands[0].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, dt.Rows[0]["ReturID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@noMPR", SqlDbType.VarChar, dt.Rows[0]["NoMPR"]));
                    db.Commands[0].Parameters.Add(new Parameter("@noNotaRetur", SqlDbType.VarChar, noNota));
                    db.Commands[0].Parameters.Add(new Parameter("@noTolak", SqlDbType.VarChar, dt.Rows[0]["NoTolak"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglMPR", SqlDbType.DateTime, dt.Rows[0]["TglMPR"]));

                    if (dt.Rows[0]["TglNotaRetur"].ToString() == string.Empty)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@tglNotaRetur", SqlDbType.DateTime, txtTglGudang.DateValue));
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@tglNotaRetur", SqlDbType.DateTime, dt.Rows[0]["TglNotaRetur"]));
                    }
                    

                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, dt.Rows[0]["KodeToko"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglTolak", SqlDbType.DateTime, dt.Rows[0]["TglTolak"]));
                    db.Commands[0].Parameters.Add(new Parameter("@pengambilan", SqlDbType.VarChar, dt.Rows[0]["Pengambilan"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglPengambilan", SqlDbType.DateTime, dt.Rows[0]["TglPengambilan"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglGudang", SqlDbType.DateTime, txtTglGudang.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@bagPenjualan", SqlDbType.VarChar, dt.Rows[0]["BagPenjualan"]));
                    db.Commands[0].Parameters.Add(new Parameter("@penerima", SqlDbType.VarChar, cboPenerimaBrg.SelectedValue.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@linkID", SqlDbType.VarChar, dt.Rows[0]["LinkID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, false));
                    db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, dt.Rows[0]["NPrint"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglRQRetur", SqlDbType.DateTime, dt.Rows[0]["TglRQRetur"]));
                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    if (generateNoNota)
                    {
                        db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE")); //cek heri
                        db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, numeratorDoc));
                        db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                        db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                        db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                        db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                        db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        //EXECUTE COMMANDS
                        db.BeginTransaction();
                        db.Commands[0].ExecuteNonQuery();
                        db.Commands[1].ExecuteNonQuery();
                        db.CommitTransaction();
                    }
                    else
                    {
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data telah tersimpan");
                this.DialogResult = DialogResult.OK;
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNotaReturJualUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmNotaReturJualBrowse)
                {
                    frmNotaReturJualBrowse frmCaller = (frmNotaReturJualBrowse)this.Caller;
                    //frmCaller.RefreshDataReturJual();
                    frmCaller.RefreshRowDataReturJual(_rowID.ToString());
                    frmCaller.FindHeader("HeaderRowID", _rowID.ToString());
                }
            }
        }
    }
}
