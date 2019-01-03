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
    public partial class frmStokBarcodeUpdate : ISA.Toko.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        string _barangID, _namastok, _headerID, _generate;
        DataTable dt = new DataTable();
        public frmStokBarcodeUpdate()
        {
            InitializeComponent();
        }

        public frmStokBarcodeUpdate(Form caller, string RowIDHeader, string barangid)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _headerID = RowIDHeader;
            _barangID = barangid;
            this.Caller = caller;

        }
        public frmStokBarcodeUpdate(Form caller, string RowIDHeader, string barangid, string generate)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _headerID = RowIDHeader;
            _barangID = barangid;
            _generate = generate;
            this.Caller = caller;
        }

        public frmStokBarcodeUpdate(Form caller, Guid rowID, string barangid, string namastok)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            _barangID = barangid;
            _namastok = namastok;
            this.Caller = caller;
            
        }

        private void frmStokBarcodeUpdate_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case enumFormMode.New:
                    try
                    {
                        using (Database db = new Database())
                        {

                            db.Commands.Add(db.CreateCommand("usp_Stok_List"));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, _barangID));
                            dt = db.Commands[0].ExecuteDataTable();

                        }
                        if (dt.Rows.Count > 0)
                        {
                            txtKodeBarang.Text = Tools.isNull(dt.Rows[0]["BarangID"], "").ToString();
                            txtNamaBarang.Text = Tools.isNull(dt.Rows[0]["NamaStok"], "").ToString();

                        }
                        //txtKodeBarang.ReadOnly = true;
                        //txtNamaBarang.ReadOnly = true;
                        txtKodeBarcode.Select();
                        if (_generate == "generate")
                        {
                           generateBarcode();
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
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_StokBarcode_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        if (dt.Rows.Count > 0)
                        {
                            txtKodeBarang.Text = Tools.isNull(dt.Rows[0]["id_brgdg"], "").ToString();
                            txtNamaBarang.Text = Tools.isNull(dt.Rows[0]["NamaStok"], "").ToString();
                            txtKodeBarcode.Text = Tools.isNull(dt.Rows[0]["barcode"], "").ToString();
                            txtGroupBarcode.Text = Tools.isNull(dt.Rows[0]["groupbc"], "").ToString();


                        }
                        //txtKodeBarang.ReadOnly = true;
                        //txtNamaBarang.ReadOnly = true;
                        txtKodeBarcode.Select();
                        if (_generate == "generate")
                        {
                            generateBarcode();
                        }
                    }
                        
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    break;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
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
                    try
                    {

                        if(Tools.cekDataOnDatabase("StokBarcode","barcode",txtKodeBarcode.Text))
                        {
                            MessageBox.Show("code barcode "+txtKodeBarcode.Text+" sudah ada di Database.");
                            txtKodeBarcode.Focus();
                            return;
                        }
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_StokBarcode_INSERT"));
                                db.Commands[0].Parameters.Add(new Parameter("@header", SqlDbType.VarChar, _headerID.ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@id_brg", SqlDbType.VarChar, txtKodeBarang.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@barcode", SqlDbType.VarChar, txtKodeBarcode.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@grup", SqlDbType.VarChar, txtGroupBarcode.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@namaBarang", SqlDbType.VarChar, txtNamaBarang.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                                db.BeginTransaction();
                                db.Commands[0].ExecuteNonQuery();

                                db.CommitTransaction();
                                db.Dispose();
                                frmStokBarcode frmCaller = (frmStokBarcode)this.Caller;
                                frmCaller.RefreshDataStokBarcode();
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

                        if (Tools.cekDuplikasiDataOnDatabase("StokBarcode", "barcode", txtKodeBarcode.Text, "RowID",_rowID.ToString()))
                        {
                            MessageBox.Show("code barcode " + txtKodeBarcode.Text + " sudah ada di Database.");
                            txtKodeBarcode.Focus();
                            return;
                        }
                        using (Database db = new Database())
                        {
                            //_rowID = ;

                            db.Commands.Add(db.CreateCommand("usp_StokBarcode_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@row", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@barcode", SqlDbType.VarChar, txtKodeBarcode.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@grup", SqlDbType.NChar, txtGroupBarcode.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                            this.DialogResult = DialogResult.OK;
                            

                            frmStokBarcode frmCaller = (frmStokBarcode)this.Caller;
                            frmCaller.RefreshDataStokBarcode();
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

        private void frmStokBarcodeUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
  
        }

        private void frmStokBarcodeUpdate_KeyDown(object sender, KeyEventArgs e)
        {
      
        }

        private void txtKodeBarcode_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtKodeBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                cmdSave.Select();
            }
        }

        private void CMDGenerate_Click(object sender, EventArgs e)
        {
            generateBarcode();
        }


        private void generateBarcode()
        {
            Random seeder = new Random();
            txtKodeBarcode.Text = "";            
            int text = 0;
            string tmb = "";
                for (int i = 0; i < 4; i++)
                {
                    text = seeder.Next(65, 10000);
                    if (text > 90)
                    {
                        if (text == 10000)
                        {
                            tmb = "0";
                        }
                        else
                        {
                            tmb = (text - 90).ToString();
                        }
                    }
                    //else
                    //{
                    //    tmb = ((Char)text).ToString();
                    //}
                    txtKodeBarcode.Text = txtKodeBarcode.Text + "" + tmb;
                    
                }            
        }

    }
}
