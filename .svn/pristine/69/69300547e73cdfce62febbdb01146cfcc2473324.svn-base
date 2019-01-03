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

namespace ISA.Trading.PO
{
    
    public partial class frmPOAdd : ISA.Trading.BaseForm
    {
        string strNoPO, docNoPO = "NOMOR_PO";
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _idtr;

        DataTable dtNum;
        int lebar, iNomor;
        string depan, belakang;
        string _HeaderRowId;
        string CekOrder = "0";

        public frmPOAdd(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmPOAdd(Form caller, string HeaderRowID)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
            this._HeaderRowId = HeaderRowID;
        }

        private void cbSave_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(_headerRowId);
            //DataTable dtNum = Tools.GetGeneralNumerator(docNoPO, Tools.GeneralInitial());
            //lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
            //iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
            ////depan = Tools.GeneralInitial();
            //depan =string.Empty;
            ////belakang = dtNum.Rows[0]["Belakang"].ToString();
            //if (DateTime.Today.Month.ToString().Length == 2)
            //{
            //    belakang = "/" + DateTime.Today.Month.ToString() +
            //    "/" + DateTime.Today.Year.ToString();
            //}
            //else
            //{
            //    belakang = "/0" + DateTime.Today.Month.ToString() +
            //    "/" + DateTime.Today.Year.ToString();
            //}
            //iNomor++;
            //strNoPO = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
            
            ////strNoPO = GlobalVar.Gudang.ToString() + iNomor.ToString() + belakang;
            //    //2811140./04/2013      

            if (validation())
            {
                switch (formMode)
                {
                    case enumFormMode.New:
                        strNoPO = textBox1.Text;
                        InsertPO(strNoPO);
                        break;
                    case enumFormMode.Update:
                        //UpdatePO();
                        break;
                }
            }
            frmPO frmCaller = (frmPO)this.Caller;
            frmCaller.RefreshHeader();
            this.DialogResult = DialogResult.OK;
            frmCaller.POFindRow("idtr", _idtr);
            this.Close();
        }

        private void InsertPO(string NoPO) {
            //MessageBox.Show("masuk ke insert");
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                try {

                    string tglawal = Convert.ToString(dtpAwal.Value.ToString());
                    string tglakhir = Convert.ToString(dtpAkhir.Value.ToString());
                    _idtr = Tools.CreateFingerPrint();
                    db.BeginTransaction();
                    db.Commands.Add(db.CreateCommand("usp_POHeader_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@idtr", SqlDbType.VarChar, _idtr));
                    db.Commands[0].Parameters.Add(new Parameter("@tgl_po", SqlDbType.DateTime, DateTime.Today));
                    db.Commands[0].Parameters.Add(new Parameter("@no_po", SqlDbType.VarChar, NoPO));
                    db.Commands[0].Parameters.Add(new Parameter("@admin", SqlDbType.VarChar, tbAdmin.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@gudang", SqlDbType.VarChar, tbGudang.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, tbCatatan.Text.Replace(Environment.NewLine, string.Empty).TrimEnd()));
                    db.Commands[0].Parameters.Add(new Parameter("@tanggal1", SqlDbType.DateTime, tglawal));
                    db.Commands[0].Parameters.Add(new Parameter("@tanggal2", SqlDbType.DateTime, tglakhir));
                   // MessageBox.Show("masuk ke sp1");
                    // update numerator
                    db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                    db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, docNoPO));
                    db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                    db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                    db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                    db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                    db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    //MessageBox.Show("masuk ke sp2");
                    db.Commands[0].ExecuteNonQuery();
                    db.Commands[1].ExecuteNonQuery();
                    db.CommitTransaction();
                    //MessageBox.Show("Data Berhasil Di simpan");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    db.RollbackTransaction();
                    MessageBox.Show("Gagal Menyimpan Data");
                }
            }
        }

        private bool validation()
        {
           
           string[,,] cek = {{ 
                                {tbAdmin.Text.ToString(),"isNull","admin tidak boleh koosng"}
                                ,{tbGudang.Text.ToString(),"isNull","gudang tidak boleh kosong"}
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
            DataTable dtNum = Tools.GetGeneralNumerator(docNoPO, Tools.GeneralInitial());
            lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
            iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
            //depan = Tools.GeneralInitial();
            depan = string.Empty;
            //belakang = dtNum.Rows[0]["Belakang"].ToString();
            if (DateTime.Today.Month.ToString().Length == 2)
            {
                belakang = "/" + DateTime.Today.Month.ToString() +
                "/" + DateTime.Today.Year.ToString();
            }
            else
            {
                belakang = "/0" + DateTime.Today.Month.ToString() +
                "/" + DateTime.Today.Year.ToString();
            }
            iNomor++;
            //strNoPO = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
            string result;
            result = iNomor.ToString();
            if (iNomor.ToString().Length < lebar)
            {
                int num = lebar - iNomor.ToString().Length;
                for (int i = 0; i < num; i++)
                {
                    result = "0" + result;
                }

                strNoPO = GlobalVar.Gudang.ToString() + result + belakang;
                //2811140./04/2013      
            }
            else
            {
                strNoPO = GlobalVar.Gudang.ToString() + iNomor.ToString() + belakang;
            }

            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("fsp_lastdaypoheader"));
                dt = db.Commands[0].ExecuteDataTable();
            }

            DateTime _tanggalAwal = (DateTime)Tools.isNull(dt.Rows[0]["tanggal"],GlobalVar.DateTimeOfServer.AddDays(-1));
            DateTime _tanggalAkhir = GlobalVar.DateTimeOfServer.AddDays(-1);    // DateTime.Today.AddDays(-1);

            dtpAkhir.Value = _tanggalAkhir;
            dtpAwal.Value = _tanggalAwal;

            dtpTanggal.Format = DateTimePickerFormat.Custom;
            dtpTanggal.CustomFormat = " dd,MMMM,yyyy";

            dtpAwal.Format = DateTimePickerFormat.Custom;
            dtpAwal.CustomFormat = " dd,MMMM,yyyy";

            dtpAkhir.Format = DateTimePickerFormat.Custom;
            dtpAkhir.CustomFormat = "dd,MMMM,yyyy";
            //dtpAkhir.ShowUpDown = true;

            textBox1.Text = strNoPO;

        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpTanggal_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbOrder_CheckedChanged(object sender, EventArgs e)
        {
            string cCatatan = Tools.isNull(this.tbCatatan.Text,"").ToString().Trim();
            if (cCatatan == "POKE00")
                cCatatan = "";

            if (cbOrder.CheckState.ToString() == "Checked")
            {
                CekOrder = "1";
                this.tbCatatan.Enabled = false;
                tbCatatan.Text = "POKE00";
            }
            else
            {
                CekOrder = "0";
                this.tbCatatan.Enabled = true;
                tbCatatan.Text = cCatatan;
            }
        }

    }
}
