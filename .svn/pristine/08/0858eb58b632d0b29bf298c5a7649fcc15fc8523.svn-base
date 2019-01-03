using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using System.Drawing.Printing;
using ISA.Common;
using ISA.Toko.Class;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data.SqlTypes;

namespace ISA.Toko.Register
{
    public partial class frmRegisterUpdate : ISA.Toko.BaseForm
    {
        bool _Lcabang;
        DataTable TagihDetail = new DataTable("TagihanDetail");
        Guid RowID_ = Guid.Empty;
        string RecordID_ = string.Empty;
        #region "Procedure"
        private void UncheckALL(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }

        private string Valid()
        {
            string tipe = "";
            if (checkBox1.Checked == true)
            {
                tipe = "OCAHBVTLZGJ24";
            }
            else
            {
                foreach (Control ctr in groupBox1.Controls)
                {
                    if (ctr is CheckBox)
                    {
                        CheckBox chk = (CheckBox)ctr;

                        if (chkO.Checked == true)
                        {
                            tipe = tipe + "O";
                        }
                        if (chkA.Checked == true)
                        {
                            tipe = tipe + "A";
                        }
                        if (chkL.Checked == true)
                        {
                            tipe = tipe + "L";
                        }
                        if (chkZ.Checked == true)
                        {
                            tipe = tipe + "Z";
                        }
                        if (chk2.Checked == true)
                        {
                            tipe = tipe + "2";
                        }
                        if (chkC.Checked == true)
                        {
                            tipe = tipe + "C";
                        }
                        if (chkV.Checked == true)
                        {
                            tipe = tipe + "V";
                        }
                        if (chkB.Checked == true)
                        {
                            tipe = tipe + "B";
                        }
                        if (chkJ.Checked == true)
                        {
                            tipe = tipe + "J";
                        }
                        if (chk4.Checked == true)
                        {
                            tipe = tipe + "4";
                        }
                        if (chkT.Checked == true)
                        {
                            tipe = tipe + "T";
                        }
                        if (chkH.Checked == true)
                        {
                            tipe = tipe + "H";
                        }
                        if (chkG.Checked == true)
                        {
                            tipe = tipe + "G";
                        }

                        break;

                    }
                }
            }


            return tipe.Trim();
        }

        private void InsertData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DataTable dtNum = Tools.GetGeneralNumerator("REG", GlobalVar.DBFinance);

                //   string Nomor_ = Numerator.GetNumerator("REG");
                int lebar = 4;
                int iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                string depan = Tools.Right(DateTime.Now.Year.ToString(), 1) + Tools.Right("0" + DateTime.Now.Month.ToString(), 2);
                string belakang = dtNum.Rows[0]["Belakang"].ToString();
                iNomor++;

                txtRegister.Text = Tools.FormatNumerator(iNomor, lebar, depan, "");
                RowID_ = Guid.NewGuid();
                RecordID_ = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("usp_Tagihan_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordID_));
                    db.Commands[0].Parameters.Add(new Parameter("@NoReg", SqlDbType.VarChar, txtRegister.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@TglReg", SqlDbType.DateTime, dateTextBox1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, textBox2.SelectedValue.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Wilayah", SqlDbType.VarChar, textBox1.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Periode1", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@Periode2", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    double Tlama_ = 0;
                    if (_Lcabang)
                    {
                        Tlama_ = Convert.ToDouble(TagihDetail.Compute("SUM(RpSisa)", string.Empty));
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@TLama", SqlDbType.Money, _Lcabang ? Tlama_ : 0));
                    db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, string.Empty));
                    db.Commands[0].Parameters.Add(new Parameter("@Nprint", SqlDbType.Int, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserID));
                    // db.Commands[0].ExecuteNonQuery();

                    db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                    db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, "REG"));
                    db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                    db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                    db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                    db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                    db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    //db.Commands.Clear();
                    //MessageBox.Show(TagihDetail.Rows.Count.ToString());

                    //if (_Lcabang && TagihDetail.Rows.Count > 0)
                    if (TagihDetail.Rows.Count > 0)
                        {
                        for (int i = 0; i < TagihDetail.Rows.Count; i++)
                        {
                            db.Commands.Add(db.CreateCommand("[usp_TagihanDetail_INSERT]"));
                            db.Commands[i + 2].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                            db.Commands[i + 2].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, RowID_));
                            db.Commands[i + 2].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateShortFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial, i)));
                            db.Commands[i + 2].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, RecordID_));
                            db.Commands[i + 2].Parameters.Add(new Parameter("@KPID", SqlDbType.UniqueIdentifier, (Guid)TagihDetail.Rows[i]["RowID"]));
                            db.Commands[i + 2].Parameters.Add(new Parameter("@KPRecID", SqlDbType.VarChar, TagihDetail.Rows[i]["KPID"].ToString()));
                            if(Convert.ToInt32(TagihDetail.Rows[i]["Cicil"])==0)
                                db.Commands[i + 2].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, string.Empty));
                            else
                                db.Commands[i + 2].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, "KONTRAK"));

                            db.Commands[i + 2].Parameters.Add(new Parameter("@KodeTagih", SqlDbType.VarChar, TagihDetail.Rows[i]["KodeTransaksi"].ToString()));
                            db.Commands[i + 2].Parameters.Add(new Parameter("@RpNota", SqlDbType.Money, Convert.ToDouble(Tools.isNull(TagihDetail.Rows[i]["RpJual"], "0"))));
                            db.Commands[i + 2].Parameters.Add(new Parameter("@RpBayar", SqlDbType.Money, Convert.ToDouble(Tools.isNull(TagihDetail.Rows[i]["RpKredit"], "0"))));
                            db.Commands[i + 2].Parameters.Add(new Parameter("@RpTagih", SqlDbType.Money, Convert.ToDouble(Tools.isNull(TagihDetail.Rows[i]["RpSisa"], "0"))));
                            db.Commands[i + 2].Parameters.Add(new Parameter("@LastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserID));
                        }

                    }



                    db.BeginTransaction();
                    for (int j = 0; j < db.Commands.Count; j++)
                    {
                        db.Commands[j].ExecuteNonQuery();
                    }

                    db.CommitTransaction();
                    //  string a = Numerator.BookNumerator("REG");
                }

                RefreshData();
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            this.Close();
        }

        private void GetCollector()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_Collector_LIST]"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
               //dt.Rows.Add(""); //- matiin heri
                dt.DefaultView.Sort = "Nama ASC";
                textBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                textBox2.DataSource = dt;
                textBox2.DisplayMember = "Nama";
                textBox2.ValueMember = "Kode";
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void RefreshData()
        {
            if (this.Caller is frmRegisterBrowser)
            {
                frmRegisterBrowser frmCaller = (frmRegisterBrowser)this.Caller;
                //frmCaller.RefreshRowDetail(_RowID);
                frmCaller.RefreshRowDataHeader(RowID_);
                frmCaller.FindGridHeader("RowIDHeader", RowID_.ToString());
            }
        }
        #endregion

        public frmRegisterUpdate(Form caller_, bool Lcabang_)
        {
            _Lcabang = Lcabang_;
            this.Caller = caller_;
            InitializeComponent();
        }

        public frmRegisterUpdate()
        {
            InitializeComponent();
        }

        private void frmRegisterUpdate_Load(object sender, EventArgs e)
        {
            
            foreach (Control ctr in groupBox1.Controls)
            {
                if (ctr is CheckBox)
                {
                    CheckBox chk = (CheckBox)ctr;
                    chk.Click += new EventHandler(UncheckALL);
                }
            }
            if (PeriodeClosing.IsPJTClosed(DateTime.Now))
            {
                dateTextBox1.DateValue = PeriodeClosing.LastClosingPJT.AddDays(1);
            }
            else
            {
                dateTextBox1.DateValue = DateTime.Now;
            }
            checkBox1.Checked = true;
            CheckBoxUmur.Checked = true;
            numericTextBox1.Enabled = false;
            lookupSales1.Enabled = false;
            // string docNoDO = "NOMOR_REGISTER";

            DataTable dtNum = Tools.GetGeneralNumerator("REG", GlobalVar.DBFinance);

            int lebar = 4;
            int iNomor;
            try
            {
                iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
            }
            catch
            {
                iNomor = 0;
            }
            string depan = Tools.Right(DateTime.Now.Year.ToString(), 1) + Tools.Right("0" + DateTime.Now.Month.ToString(), 2);
            string belakang;
            try
            {
                belakang = dtNum.Rows[0]["Belakang"].ToString();
            }
            catch
            {
                belakang = "";
            }
            iNomor++;

            txtRegister.Text = Tools.FormatNumerator(iNomor, lebar, depan, "");
            rangeDateBox1.FromDate = DateTime.Now.AddDays(-7);
            rangeDateBox1.ToDate = DateTime.Now;
            GetCollector();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (lookupStafAdm1.Nama == "")
            {
                lookupStafAdm1.Focus();
                errorProvider1.SetError(lookupStafAdm1, "Kollektor Wajib Di Isi");
                return;
            }


            if (rangeDateBox1.FromDate.HasValue == false || rangeDateBox1.ToDate.HasValue == false)
            {
                rangeDateBox1.Focus();
                errorProvider1.SetError(rangeDateBox1, "Wajib Di Isi");
                return;
            }
            if (textBox1.Text == "")
            {
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Wajib Di Isi");
                return;

            }

            try
            {


                this.Cursor = Cursors.WaitCursor;

                DataTable dt = new DataTable();
                if (_Lcabang)
                {
                    using (Database db = new Database(GlobalVar.DBFinance))
                    {
                        db.Commands.Add(db.CreateCommand("usp_TagihanDetail_Vw"));
                        db.Commands[0].Parameters.Add(new Parameter("@Today", SqlDbType.DateTime, dateTextBox1.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                        string KodeTransaksi_ = string.Empty;

                        KodeTransaksi_ = Valid();

                        if (KodeTransaksi_ == string.Empty)
                        {
                            KodeTransaksi_ = "OCAHBVTLZGJ24";
                        }
                        db.Commands[0].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, KodeTransaksi_));
                        db.Commands[0].Parameters.Add(new Parameter("@Chek", SqlDbType.Bit, CheckBoxUmur.Checked ? 1 : 0));
                        db.Commands[0].Parameters.Add(new Parameter("@Umur", SqlDbType.Int, numericTextBox1.GetIntValue));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, lookupSales1.SalesID));
                        db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, textBox1.Text.Trim()));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No Data !!!");
                        return;
                    }


                    frmRegisterView ifrmDialog = new frmRegisterView(dt);
                    ifrmDialog.ShowDialog();
                    if (ifrmDialog.DialogResult == DialogResult.OK)
                    {
                        TagihDetail = ifrmDialog.GetDT.Copy();
                    }

                    if (TagihDetail == null || TagihDetail.Rows.Count == 0)
                    {
                        MessageBox.Show("No Selected Data");
                        return;
                    }
                }

                InsertData();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                foreach (Control ctr in groupBox1.Controls)
                {
                    if (ctr is CheckBox)
                    {
                        CheckBox chk = (CheckBox)ctr;
                        chk.Checked = checkBox1.Checked;
                    }
                }
            }
            else
            {
                foreach (Control ctr in groupBox1.Controls)
                {
                    if (ctr is CheckBox)
                    {
                        CheckBox chk = (CheckBox)ctr;
                        chk.Checked = checkBox1.Checked;
                    }
                }
            }
        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (Control ctr in groupBox1.Controls)
            {
                if (ctr is CheckBox)
                {
                    CheckBox chk = (CheckBox)ctr;
                    chk.Checked = checkBox1.Checked;
                }
            }
        }

        private void CheckBoxUmur_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxUmur.Checked)
            {

                numericTextBox1.Enabled = true;
                numericTextBox1.Text = "0";
                numericTextBox1.SelectAll();
            }
            else
            {
                numericTextBox1.Text = "0";
                numericTextBox1.Enabled = false;
                numericTextBox1.SelectAll();
            }
        }

        private void lookupSales1_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("hgfhj");
        }

        private void cbfilterbysales_CheckedChanged(object sender, EventArgs e)
        {
            if (cbfilterbysales.Checked)
            {
                pin.frmPinHarian ifrmpin = new pin.frmPinHarian(this, Class.IdPIN.Bagian.PinRegisterBySales, DateTime.Today, "Pin Filter By Sales ");
                ifrmpin.StartPosition = FormStartPosition.CenterScreen;
                ifrmpin.MaximizeBox = false;
                //ifrmpin.MdiParent = Program.MainForm;
                //Program.MainForm.RegisterChild(ifrmpin);
                ifrmpin.ShowDialog();
            }
            else
            {
                lookupSales1.Enabled = false;
            }
        }

        public void AfterPIN()
        {
            cbfilterbysales.Checked = true;
            lookupSales1.Enabled = true;
        }
    }
}
