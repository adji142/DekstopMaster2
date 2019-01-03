using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.Pin;


using ISA.DAL;

namespace ISA.Toko.Pin
{
    public partial class frmPinDaily : Form
    {
        Form _caller;
        int _bagian;
        DateTime _tanggal;
        string _keterangan;
        Guid _rowID;

        public Form Caller
        {
            get
            {
                return _caller;
            }

            set
            {
                _caller = value;
            }
        }

        public frmPinDaily(Form caller, Guid rowID, int bagian, DateTime tanggal, string keterangan)
        {
            this.Caller = caller;
            this._rowID = rowID;
            this._bagian = bagian;
            this._tanggal = tanggal;
            this._keterangan = keterangan;

            InitializeComponent();
        }

        public frmPinDaily(Form caller, int bagian, DateTime tanggal, string keterangan)
        {
            this.Caller = caller;
            this._bagian = bagian;
            this._tanggal = tanggal;
            this._keterangan = keterangan;

            InitializeComponent();
        }

        private void frmPinDaily_Load(object sender, EventArgs e)
        {
            txtKet.Text = _keterangan;
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (txtPin.Text.ToString().Length != 7)
            {
                MessageBox.Show("Pin Yang anda masukan salah, silhakan Ulangi");
                txtPin.Text = "";

                return;
            }

            string baseCode = string.Empty;
            int multiplier = 1;
            if (this._bagian == PinId.Bagian.Rekon)
            {
                baseCode = key.BaseCode.Rekon;
                multiplier = 16;
            }

            if (this._bagian == PinId.Bagian.PO)
            {
                baseCode = key.BaseCode.PO;
                multiplier =17 ;
            }
            if (this._bagian == PinId.Bagian.RekonsPJT)
            {
                baseCode = key.BaseCode.RekonsPJT;
                multiplier = 18;
            }

            if (this._bagian == PinId.Bagian.OASPV)
            {
                baseCode = key.BaseCode.OASPV;
                multiplier = 25;
            }
            if (this._bagian == PinId.Bagian.OAYYK)
            {
                baseCode = key.BaseCode.OASupport;
                multiplier = 26;
            }

            string dailyPin = ISA.Pin.key.CreateDailyPin(this._tanggal, GlobalVar.Gudang, baseCode, multiplier);

            if (txtPin.Text == dailyPin)
            {

                //GlobalVar.pinResult = true;



                if (this.Caller is Rekon.frmrekonclosing)
                {
                    DataTable dtCekRekon = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Rekon_Cek_Now"));
                        db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, _tanggal));
                        dtCekRekon = db.Commands[0].ExecuteDataTable();
                    }


                    if (this._bagian == PinId.Bagian.RekonsPJT)
                    {
                        DataTable dtOVD120 = new DataTable();
                        DataTable dtpjvspiut = new DataTable();
                        DataTable dtRekonNow = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_Rekon_List_Now"));
                            db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, DateTime.Today));
                            dtRekonNow = db.Commands[0].ExecuteDataTable();
                        }

                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("psp_rekons_overdue120"));
                            db.Commands[0].Parameters.Add(new Parameter("@tglclosing", SqlDbType.Date, DateTime.Now));
                            dtOVD120 = db.Commands[0].ExecuteDataTable();
                        }

                        DateTime tglawalrekon = Convert.ToDateTime(dtRekonNow.Rows[0]["periode1"].ToString());
                        DateTime tglakhirrekon = Convert.ToDateTime(dtRekonNow.Rows[0]["periode2"].ToString());

                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("psp_Rekon_Chek_PJKVSPIUT_Prepare"));
                            db.Commands[0].Parameters.Add(new Parameter("@tglclsawal", SqlDbType.Date, tglawalrekon));
                            db.Commands[0].Parameters.Add(new Parameter("@tglclsakhir", SqlDbType.Date, tglakhirrekon));
                            dtpjvspiut = db.Commands[0].ExecuteDataTable();

                        }
                        int hari = (int)DateTime.Now.DayOfWeek;
                        if (hari == 1)
                        {
                            if (dtpjvspiut.Rows.Count > 0 || dtOVD120.Rows.Count > 0)
                            {
                                Pin.frmPinDaily ifrmChild1 = new Pin.frmPinDaily(this, (Guid)dtCekRekon.Rows[0]["RowID"], PinId.Bagian.Rekon, DateTime.Today, "Pin rekon PJK");
                                ifrmChild1.MdiParent = Program.MainForm;
                                Program.MainForm.RegisterChild(ifrmChild1);
                                ifrmChild1.Show();

                            }
                            else
                            {
                                using (Database db = new Database())
                                {
                                    DataTable dt = new DataTable();
                                    db.Commands.Add(db.CreateCommand("usp_Rekon_Clstrans_update"));
                                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, this._rowID));
                                    db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, txtPin.Text));
                                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                    dt = db.Commands[0].ExecuteDataTable();
                                    db.Commands[0].ExecuteNonQuery();

                                    MessageBox.Show("Pin Benar, Proses Rekons Sudah Selesai");
                                }

                            }
                        }
                        else
                        {
                            if (dtpjvspiut.Rows.Count > 0)
                            {
                                Pin.frmPinDaily ifrmChild1 = new Pin.frmPinDaily(this, (Guid)dtCekRekon.Rows[0]["RowID"], PinId.Bagian.Rekon, DateTime.Today, "Pin rekon PJK");
                                ifrmChild1.MdiParent = Program.MainForm;
                                Program.MainForm.RegisterChild(ifrmChild1);
                                ifrmChild1.Show();

                            }
                            else
                            {
                                using (Database db = new Database())
                                {
                                    DataTable dt = new DataTable();
                                    db.Commands.Add(db.CreateCommand("usp_Rekon_Clstrans_update"));
                                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, this._rowID));
                                    db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, txtPin.Text));
                                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                    dt = db.Commands[0].ExecuteDataTable();
                                    db.Commands[0].ExecuteNonQuery();

                                    MessageBox.Show("Pin Benar, Proses Rekons Sudah Selesai");
                                }

                            }
                        }
                        





                       

                    }
                }
                    if (this._bagian == PinId.Bagian.Rekon)
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Rekon_Clstrans_update"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, this._rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, txtPin.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                            db.Commands[0].ExecuteNonQuery();

                            MessageBox.Show("Pin Benar, Proses Rekons Sudah Selesai");
                        }
                    }
                    //using (Database db = new Database())
                    //{
                    //    DataTable dt = new DataTable();
                    //    db.Commands.Add(db.CreateCommand("usp_Rekon_Clstrans_update"));
                    //    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, this._rowID));
                    //    db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, txtPin.Text));
                    //    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    //    dt = db.Commands[0].ExecuteDataTable();
                    //    db.Commands[0].ExecuteNonQuery();

                    //    MessageBox.Show("Pin Benar, Proses Rekons Sudah Selesai");
                    //}
                
                //if (this.Caller is frmMain)
                //{
                //    PSReport.frmLaporanPenjualanPerItem ifrmChild1 = new PSReport.frmLaporanPenjualanPerItem();
                //    ifrmChild1.MdiParent = Program.MainForm;
                //    Program.MainForm.RegisterChild(ifrmChild1);
                //    ifrmChild1.Show();
                //}

                if (this._bagian == PinId.Bagian.PO)
                {
                    PSReport.frmLaporanPenjualanPerItem ifrmChild1 = new PSReport.frmLaporanPenjualanPerItem();
                    ifrmChild1.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild1);
                    ifrmChild1.Show();
                }
                if (this._bagian == PinId.Bagian.OASPV)
                {
                    MessageBox.Show("Pin Benar, Proses Sudah Selesai");
                    if (this.Caller is PSReport.frmLaporanAnalisaOA)
                    {
                        PSReport.frmLaporanAnalisaOA frmCaller = (PSReport.frmLaporanAnalisaOA)this.Caller;
                        frmCaller.Getdata();
                        this.Close();
                    }
                }
                if (this._bagian == PinId.Bagian.OAYYK)
                {
                    MessageBox.Show("Pin Benar, Proses Sudah Selesai");
                    if (this.Caller is PSReport.frmLaporanAnalisaOA)
                    {
                        PSReport.frmLaporanAnalisaOA frmCaller = (PSReport.frmLaporanAnalisaOA)this.Caller;
                        frmCaller.Getdata();
                        this.Close();
                    }
                }

                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_pin_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@keyNumber", SqlDbType.VarChar, string.Empty));
                    db.Commands[0].Parameters.Add(new Parameter("@PinNummber", SqlDbType.VarChar, txtPin.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@id", SqlDbType.Int, _bagian));
                    db.Commands[0].Parameters.Add(new Parameter("@ket", SqlDbType.Text, txtKet.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                this.Close();

            }
            else
            {
                MessageBox.Show("Pin yang anda masukan salah, cek kembali");
            }
        }
    }
}
