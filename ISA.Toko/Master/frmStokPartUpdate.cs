using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Master
{
    public partial class frmStokPartUpdate : ISA.Toko.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        //Detail
        Guid  _rowID;
        string _barangID, _namastok, _headerID;
        string docNo = "Nomor_StokPart";
        public frmStokPartUpdate()
        {
            InitializeComponent();
        }
        public frmStokPartUpdate(Form caller, string RowIDHeader, string barangid)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _headerID = RowIDHeader;
            _barangID = barangid;
            this.Caller = caller;
            //MessageBox.Show(_headerID.ToString());
        }
        public frmStokPartUpdate(Form caller, Guid rowID, string barangid, string namastok)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            _barangID = barangid;
            _namastok = namastok;
            this.Caller = caller;
            MessageBox.Show(_rowID.ToString());
        }

        private void frmStokPartUpdate_Load(object sender, EventArgs e)
        {
           
            switch (formMode)
            {
                case enumFormMode.New:
                    try
                    {

                        DataTable dt = new DataTable();
                        using (Database db = new Database())
                        {

                            db.Commands.Add(db.CreateCommand("usp_StokPart_List"));
                            db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                            dt = db.Commands[0].ExecuteDataTable();

                        }
                        if (dt.Rows.Count > 0)
                        {
                            txtNamaStok.Text = Tools.isNull(dt.Rows[0]["nama_stok"], "").ToString();
                            txtIDBarang.Text = Tools.isNull(dt.Rows[0]["BarangID"], "").ToString();
                            txtKLP.Text = Tools.isNull(dt.Rows[0]["KodeBarang"], "").ToString();
                            txtSatuan.Text = Tools.isNull(dt.Rows[0]["sat_jual"], "").ToString();
                            txtPasif.Text = Tools.isNull(dt.Rows[0]["lpasif"], "").ToString();
                            txtIDM.Text = Tools.isNull(dt.Rows[0]["IDM"], "").ToString();

                        }
                        txtNamaStok.ReadOnly = true;
                        txtIDBarang.ReadOnly = true;
                        txtKLP.ReadOnly = true;
                        txtSatuan.ReadOnly = true;
                        txtPasif.ReadOnly = true;
                        txtIDM.ReadOnly = true;
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    break;

                case enumFormMode.Update:
                    try
                    {

                        DataTable dt = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_StokPart_List"));
                            db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        if (dt.Rows.Count > 0)
                        {
                            txtNamaStok.Text = Tools.isNull(dt.Rows[0]["nama_stok"], "").ToString();
                            txtIDBarang.Text = Tools.isNull(dt.Rows[0]["BarangID"], "").ToString();
                            txtKLP.Text = Tools.isNull(dt.Rows[0]["KodeBarang"], "").ToString();
                            txtSatuan.Text = Tools.isNull(dt.Rows[0]["sat_jual"], "").ToString();
                            txtPasif.Text = Tools.isNull(dt.Rows[0]["lpasif"], "").ToString();
                            txtIDM.Text = Tools.isNull(dt.Rows[0]["IDM"], "").ToString();
                            txtMerek.Text = Tools.isNull(dt.Rows[0]["merek"], "").ToString();
                            txtJenis.Text = Tools.isNull(dt.Rows[0]["jenis"], "").ToString();
                            txtCash.Text = Tools.isNull(dt.Rows[0]["cash"], "").ToString();
                            txtTop10.Text = Tools.isNull(dt.Rows[0]["top10"], "").ToString();
                            txtEndu.Text = Tools.isNull(dt.Rows[0]["enduser"], "").ToString();
                            textBox1.Text = Tools.isNull(dt.Rows[0]["kelompok"], "").ToString();
                            txtIDTR.Text = Tools.isNull(dt.Rows[0]["id_tr"], "").ToString();
                            txtsuplier.Text = Tools.isNull(dt.Rows[0]["supplier"], "").ToString();
                        }
                        txtNamaStok.ReadOnly = true;
                        txtIDBarang.ReadOnly = true;
                        txtKLP.ReadOnly = true;
                        txtSatuan.ReadOnly = true;
                        txtPasif.ReadOnly = true;
                        txtIDM.ReadOnly = true;
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    break;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

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
                    MessageBox.Show(_headerID.ToString());
                    try
                    {
                       using (Database db = new Database())

                        {
                            db.Commands.Add(db.CreateCommand("usp_StokPart_INSERT"));
                            //db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                            db.Commands[0].Parameters.Add(new Parameter("@header", SqlDbType.VarChar, _headerID.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@nama_stok", SqlDbType.VarChar, txtNamaStok.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@id_brg", SqlDbType.VarChar, txtIDBarang.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@satuan", SqlDbType.VarChar, txtSatuan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@merek", SqlDbType.VarChar, txtMerek.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@jenis", SqlDbType.VarChar, txtJenis.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, textBox1.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@suplier", SqlDbType.VarChar, txtsuplier.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@idtr", SqlDbType.VarChar, txtIDTR.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@pasif", SqlDbType.VarChar, txtPasif.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@cash", SqlDbType.NChar, txtCash.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@top", SqlDbType.NChar, txtTop10.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@enduser", SqlDbType.NChar, txtEndu.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            
                            db.BeginTransaction();
                            db.Commands[0].ExecuteNonQuery();

                            db.CommitTransaction();
                            db.Dispose();
                            frmStokPartBrowse frmCaller = (frmStokPartBrowse)this.Caller;
                            frmCaller.RefreshDataStokPart();
                            this.Close();
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                    }
                   
                    break;

                case enumFormMode.Update:
                    try
                    {
                        MessageBox.Show(_rowID.ToString());
                        using (Database db = new Database())
                        {
                            //_rowID = ;

                            db.Commands.Add(db.CreateCommand("usp_StokPart_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@row", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@jenis", SqlDbType.VarChar, txtJenis.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@cash", SqlDbType.NChar, txtCash.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@top10", SqlDbType.NChar, txtTop10.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@endu", SqlDbType.NChar, txtEndu.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, textBox1.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@idtr", SqlDbType.VarChar, txtIDTR.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@pasif", SqlDbType.Bit, txtPasif.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@suplier", SqlDbType.VarChar, txtsuplier.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                            this.DialogResult = DialogResult.OK;
                            cmdClose.PerformClick();

                            frmStokPartBrowse frmCaller = (frmStokPartBrowse)this.Caller;
                            frmCaller.RefreshDataStokPart();
                            this.Close();
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                    }

                    break;
            }

        }
    }
}
