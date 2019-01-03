using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading;
using System.Data.SqlTypes;

namespace ISA.Trading.Gudang
{
    
    public partial class frmPOAdd : ISA.Trading.BaseForm
    {
        string strNoPO, docNoPO = "NOMOR PO";
        enum enumFormMode { New, Update };
        enumFormMode formMode;

        DataTable dtNum;
        int lebar, iNomor;
        string depan, belakang;

        public frmPOAdd(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        private void cbSave_Click(object sender, EventArgs e)
        {
            DataTable dtNum = Tools.GetGeneralNumerator(docNoPO, Tools.GeneralInitial());
            lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
            iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
            depan = Tools.GeneralInitial();
            belakang = dtNum.Rows[0]["Belakang"].ToString();
            iNomor++;
            strNoPO = Tools.FormatNumerator(iNomor, lebar, depan, belakang);

            if (validation())
            {
                switch (formMode)
                {
                    case enumFormMode.New:
                        InsertPO(strNoPO);
                        break;
                    case enumFormMode.Update:
                        //UpdatePO();
                        break;
                }
            }
           
            
        }

        private void InsertPO(string NoPO) {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                try {

                    db.BeginTransaction();
                    db.Commands.Add(db.CreateCommand("usp_POHeader_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@idtr", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                    db.Commands[0].Parameters.Add(new Parameter("@no_po", SqlDbType.VarChar, NoPO));
                    db.Commands[0].Parameters.Add(new Parameter("@admin", SqlDbType.VarChar, tbAdmin.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@gudang", SqlDbType.VarChar, tbGudang.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, tbGudang.Text));
                    MessageBox.Show("masuk ke sp1");
                    // update numerator
                    db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                    db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, docNoPO));
                    db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                    db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                    db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                    db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                    db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    MessageBox.Show("masuk ke sp2");
                    db.Commands[0].ExecuteNonQuery();
                    db.Commands[1].ExecuteNonQuery();
                    db.CommitTransaction();
                    MessageBox.Show("Data Berhasil Di simpan");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    db.RollbackTransaction();
                    MessageBox.Show("Gagal Menyimpan Data");
                }
            }

            if (this.Caller is frmPO)
            {
                Gudang.frmPO frmCaller = (Gudang.frmPO)this.Caller;
                frmCaller.RefreshHeader();
                this.Close();
            }
        }

        private bool validation()
        {
           
           string[,,] cek = {{ 
                                {tbAdmin.Text.ToString(),"isNull","admin tidak boleh koosng"}
                                ,{tbGudang.Text.ToString(),"isNull","gudang tidak boleh koosng"}
                             }};

           return Class.validation.error(cek);
        }

        private void tbGudang_TextChanged(object sender, EventArgs e)
        {
            //Class.validation onlyInt = new Class.validation();
            //onlyInt.validateTextInteger(sender,e);

        }

        private void frmPOAdd_Load(object sender, EventArgs e)
        {
            dtpTanggal.Format = DateTimePickerFormat.Custom;
            dtpTanggal.CustomFormat = " dd,MMMM,yyyy";


            

        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
