using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Master
{
    public partial class frmStafSalesUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _Noid, docNo = "NOMOR_STAFFPENJUALAN", depan, belakang;
        int iNomor, lebar;
        Guid  _rowID;
        string tampNama;
        DataTable dt;

        public void generateNumerator()
        {

            DataTable dtNum = Tools.GetGeneralNumerator(docNo);
            lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
            iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
            depan = dtNum.Rows[0]["Depan"].ToString();
            belakang = dtNum.Rows[0]["Belakang"].ToString();
            iNomor++;

            _Noid = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
           TxtKode.Text = _Noid;
        }

        public frmStafSalesUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
         //   generateNumerator();
        }

        public frmStafSalesUpdate(Form caller, Guid  rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmStafSalesUpdate_Load(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.Update)
            {
                //retrieving data
                try
                {
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Open();
                        db.Commands.Add(db.CreateCommand("usp_Sales_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();

                        db.Close();
                        db.Dispose();
                    }
                    //Kode.Visible = TxtKode.Visible = true;
                    TxtKode.Enabled = false;
                    //display data
                    txtNamaSales.Text = Tools.isNull(dt.Rows[0]["NamaSales"], "").ToString();
                    TxtKode.Text = Tools.isNull(dt.Rows[0]["SalesID"], "").ToString();
                    if (dt.Rows[0]["TglLahir"].ToString()!="") txtdateLahir.DateValue = (DateTime)dt.Rows[0]["TglLahir"];
                    TxtAlamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                    if (dt.Rows[0]["TglMasuk"].ToString() != "") TxtDateMasuk.DateValue = (DateTime)dt.Rows[0]["TglMasuk"];
                    if (dt.Rows[0]["TglKeluar"].ToString() != "") TxtDateKeluar.DateValue = (DateTime)dt.Rows[0]["TglKeluar"];
                    
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNamaSales.Text))
            {
                MessageBox.Show("Nama belum diisi");
                txtNamaSales.Focus();
                return;
            }

            try
            {
                switch (formMode)
                {
                    case enumFormMode.New:
                        try
                        {
                            using (Database db = new Database())
                            {
                                db.Open();
                                _rowID = Guid.NewGuid();
                                DataTable dtMessage = new DataTable();
                                db.Commands.Add(db.CreateCommand("[usp_Sales_INSERT]"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier,_rowID ));
                                db.Commands[0].Parameters.Add(new Parameter("@RecID", SqlDbType.VarChar, "" ));
                                db.Commands[0].Parameters.Add(new Parameter("@NamaSales", SqlDbType.VarChar, txtNamaSales.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, TxtAlamat.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@TglLahir", SqlDbType.DateTime, txtdateLahir.Text == "" ?null: txtdateLahir.DateValue ));
                                db.Commands[0].Parameters.Add(new Parameter("@Target", SqlDbType.Decimal, 0.0 ));
                                db.Commands[0].Parameters.Add(new Parameter("@BatasOD", SqlDbType.Decimal, 0.0 ));
                                db.Commands[0].Parameters.Add(new Parameter("@TglMasuk", SqlDbType.DateTime, TxtDateMasuk.Text==""? null: TxtDateMasuk.DateValue ));
                                db.Commands[0].Parameters.Add(new Parameter("@TglKeluar", SqlDbType.DateTime, TxtDateKeluar.Text==""? null:TxtDateKeluar.DateValue ));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Int, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName ));
                                dtMessage = db.Commands[0].ExecuteDataTable();

                                db.Close();
                                db.Dispose();

                                if (dtMessage.Rows.Count > 0)
                                {
                                    if (dtMessage.Rows[0]["pesan"].ToString() == "Insert Berhasil")
                                    {
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                        
                                    }
                                    else { MessageBox.Show(dtMessage.Rows[0]["pesan"].ToString()); return; }
                                    //if (dt.Rows[0]["pesan"].ToString() == "Data Sudah Ada")
                                    //{
                                    //    txtKode.Text = string.Empty;
                                    //    txtKode.Focus();
                                    //    return;
                                    //}
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                        break;
                    case enumFormMode.Update:
                        try
                        {
                            using (Database db = new Database())
                            {
                                if (Tools.cekDuplikasiDataOnDatabase("Sales", "NamaSales", txtNamaSales.Text, "SalesID", TxtKode.Text))
                                {
                                    MessageBox.Show("Sales Dengan Nama " + txtNamaSales.Text + " Sudah Ada !!");
                                    txtNamaSales.Focus();
                                    return;
                                }
                                db.Open();

                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("[usp_Sales_UPDATE]"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@SalesID", SqlDbType.VarChar, TxtKode.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@RecID", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@NamaSales", SqlDbType.VarChar, txtNamaSales.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@TglLahir", SqlDbType.DateTime, txtdateLahir.Text == "" ? null : txtdateLahir.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@Target", SqlDbType.Decimal, 0.0));
                                db.Commands[0].Parameters.Add(new Parameter("@BatasOD", SqlDbType.Decimal, 0.0));
                                db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, TxtAlamat.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@TglMasuk", SqlDbType.DateTime, TxtDateMasuk.Text == "" ? null : TxtDateMasuk.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@TglKeluar", SqlDbType.DateTime, TxtDateKeluar.Text == "" ? null : TxtDateKeluar.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Int, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                                db.Commands[0].ExecuteNonQuery();

                                db.Close();
                                db.Dispose();
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                        break;
                }
                
                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmStafSalesUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmSalesBrowser)
                {
                    frmSalesBrowser frmCaller = (frmSalesBrowser)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("RowID", _rowID.ToString());
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TxtKeterangan_TextChanged(object sender, EventArgs e)
        {

        }

        private void Kode_Click(object sender, EventArgs e)
        {

        }

        private void TxtKode_TextChanged(object sender, EventArgs e)
        {

        }

       

       

       
    }
}
