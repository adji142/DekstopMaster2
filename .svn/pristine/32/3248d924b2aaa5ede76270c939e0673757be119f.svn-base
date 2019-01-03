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
    public partial class frmStokOpnameHarian : ISA.Toko.BaseForm
    {
        private enum enumFormMode { New, Update };
        enumFormMode formMode;

        string kodeBarang = string.Empty;
        string sat = string.Empty;
        Guid rowID;
        DateTime tglOpname;
        int qtyOpname = 0;
        string penghitung = string.Empty;
        string keterangan = string.Empty;

        public frmStokOpnameHarian()
        {
            InitializeComponent();
        }

        public frmStokOpnameHarian(Form caller, string kodeBarang, string sat, String NamaBarang)
        {
            InitializeComponent();
            this.formMode = enumFormMode.New;
            this.Caller = caller;
            this.kodeBarang = kodeBarang;
            this.sat = sat;
            LblKodebarang.Text = kodeBarang;
            LblNamaBarang.Text = NamaBarang;
        }

        public frmStokOpnameHarian(Form caller, Guid rowID, string kodeBarang, string sat, DateTime tglOpname, int qtyOpname, string keterangan, string penghitung)
        {
            InitializeComponent();
            this.formMode = enumFormMode.Update;
            this.Caller = caller;
            this.rowID = rowID;
            this.kodeBarang = kodeBarang;
            this.sat = sat;
            this.tglOpname = tglOpname;
            this.qtyOpname = qtyOpname;
            this.penghitung = penghitung;
            this.keterangan = keterangan;
            //if (!String.IsNullOrEmpty(keterangan))
            //{
            //    this.penghitung = keterangan.Replace("SAMPLING", string.Empty).Trim();
            //    if (this.penghitung.IndexOf("-") > 0)
            //    {
                    
            //    }
            //    this.keterangan = keterangan.Substring(keterangan.IndexOf("-") + 1).Trim();
            //}
        }
        
        private void frmStokOpnameHarian_Load(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.New)
            {
                dtTglOpname.DateValue = DateTime.Now;
                dtTglOpname.Enabled = false;

                label6.Text = sat;
            }
            else
            {
                dtTglOpname.DateValue = this.tglOpname;
                tbQtyOpname.Text = this.qtyOpname.ToString();
                comboBoxStaffAdsdanOps1.RowID = this.penghitung;
                //tbPenghitung.Text = this.penghitung;
                tbKeterangan.Text = this.keterangan;
                label6.Text = this.sat;

                dtTglOpname.ReadOnly = true;
                dtTglOpname.BackColor = this.BackColor;

                //if (!String.IsNullOrEmpty(this.penghitung))
                //{
                //    tbPenghitung.ReadOnly = true;
                //    tbPenghitung.BackColor = this.BackColor;
                //    tbPenghitung.TabStop = false;
                //}
            }
           
        }

        private void Validasi()
        {
            if (string.IsNullOrEmpty(dtTglOpname.Text))
            {
                dtTglOpname.Focus();
                throw new Exception("Tanggal opname belum diisi");
            }

            if (string.IsNullOrEmpty(tbQtyOpname.Text))
            {
                tbQtyOpname.Focus();
                throw new Exception("Qty opname belum diisi");
            }

            //if (string.IsNullOrEmpty(tbPenghitung.Text))
            //{
            //    tbPenghitung.Focus();
            //    throw new Exception("Penghitung belum diisi");
            //}

            if (string.IsNullOrEmpty(tbKeterangan.Text))
            {
                tbKeterangan.Focus();
                throw new Exception("Keterangan belum diisi");
            }
        }

        private void SaveInsert()
        {
            try
            {
                Validasi();

                DateTime tglTerakhir;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_fnGetStokOpname"));
                    db.Commands[0].Parameters.Add(new Parameter("@tgl", SqlDbType.DateTime, DateTime.Now));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeBarang", SqlDbType.VarChar, kodeBarang));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    tglTerakhir = (DateTime)db.Commands[0].ExecuteScalar();
                }

                if (dtTglOpname.DateValue <= tglTerakhir)
                {
                    MessageBox.Show("Tanggal opname harus lebih besar dari tanggal [" + tglTerakhir.ToString("dd/MM/yyyy") + "] opname terkahir");
                    dtTglOpname.Focus();
                    return;
                }
                try
                {
                    using (Database db = new Database())
                    {

                        db.Commands.Add(db.CreateCommand("usp_OpnameHistory_INSERT"));

                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglOpname", SqlDbType.DateTime, dtTglOpname.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyOpname", SqlDbType.Int, tbQtyOpname.GetIntValue));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, kodeBarang));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, tbKeterangan.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Syncflag", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@StaffPenghitungID", SqlDbType.UniqueIdentifier, new Guid(comboBoxStaffAdsdanOps1.RowID)));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    MessageBox.Show("Insert stok opname harian berhasil");

                    frmStokOpnameBrowse frmCaller = (frmStokOpnameBrowse)this.Caller;
                    frmCaller.RefreshDataDetail();

                    this.Close();

                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveUpdate()
        {
            try
            {
                Validasi();

                if (dtTglOpname.DateValue != DateTime.Today)
                {
                    MessageBox.Show("Tanggal opname harus hari ini.");
                    dtTglOpname.Focus();
                    return;
                }

                try
                {
                    //this.keterangan = tbPenghitung.Text.Trim() + " - " + tbKeterangan.Text.Trim();

                    using (Database db = new Database())
                    {

                        db.Commands.Add(db.CreateCommand("usp_OpnameHistory_UPDATE"));

                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, this.rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyOpname", SqlDbType.Int, tbQtyOpname.GetIntValue));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, this.kodeBarang));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, tbKeterangan.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@StaffPenghitungID", SqlDbType.UniqueIdentifier, new Guid(comboBoxStaffAdsdanOps1.RowID)));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    MessageBox.Show("Update stok opname harian berhasil");

                    frmStokOpnameBrowse frmCaller = (frmStokOpnameBrowse)this.Caller;
                    frmCaller.RefreshDataDetail();

                    this.Close();

                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.New)
            {
                SaveInsert();
            }
            else
            {
                SaveUpdate();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStokOpnameHarian_Activated(object sender, EventArgs e)
        {
            int stoka = 0;
            try
            {
                using (Database db = new Database())
                {

                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_getStokAwal"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglOpname", SqlDbType.DateTime, dtTglOpname.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, kodeBarang));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    stoka = (int)db.Commands[0].ExecuteScalar();
                    label5.Text = stoka.ToString();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
           
            
        }

    }
}
