using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using System.Drawing.Printing;
using ISA.Common;
using ISA.Finance.Class;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data.SqlTypes;

namespace ISA.Finance.Controls
{
    public partial class LookupNotaPiutang : UserControl
    {
        Guid kpid = Guid.Empty, tagihDetailID = Guid.Empty, rowidorderpenjualan = Guid.Empty;
        string kodeToko, tglJTempo,rpNota, rpTagih, noReg, kprecid, jenis, tagihDetailRecID, tgltransaksi;
        DateTime tglReg;
        public event EventHandler SelectData;

        public string KodeToko
        {
            get
            {
                return kodeToko;
            }
            set
            {
                kodeToko = value;
            }
        }

        public string TglTransaksi
        {
            get
            {
                return tgltransaksi;
            }
            set
            {
                tgltransaksi = value;
            }
        }

        public string NoReg
        {
            get
            {
                return noReg;
            }
            set
            {
                noReg = value;
            }
        }

        public string Jenis
        {
            get
            {
                return jenis;
            }
            set
            {
                jenis = value;
            }
        }

        public string KPrecID
        {
            get
            {
                return kprecid;
            }
            set
            {
                kprecid = value;
            }
        }

        public Guid TagihDetailID
        {
            get
            {
                return tagihDetailID;
            }
            set
            {
                tagihDetailID = value;
            }
        }

        public string TagihDetailRecID
        {
            get
            {
                return tagihDetailRecID;
            }
            set
            {
                tagihDetailRecID = value;
            }
        }

        public string NoNota
        {
            get
            {
                return TextBox.Text;
            }
            set
            {
                TextBox.Text = value;
            }
        }

        public Guid KPID
        {
            get
            {
                return kpid;
            }
            set
            {
                kpid = value;
            }
        }

        public string TglJTempo
        {
            get
            {
                return tglJTempo;
            }
            set
            {
                tglJTempo = value;
            }
        }

        public string RpNota
        {
            get
            {
                return rpNota;
            }
            set
            {
                rpNota = value;
            }
        }

        public string RpTagih
        {
            get
            {
                return rpTagih;
            }
            set
            {
                rpTagih = value;
            }
        }

        public Guid RowIDOrderPenjualan
        {
            get
            {
                return rowidorderpenjualan;
            }
            set
            {
                rowidorderpenjualan = value;
            }
        }

        public LookupNotaPiutang()
        {
            InitializeComponent();
        }      


        private void ShowDialogForm()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_LookUp_NotaToko_KartuPiutang"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kodeToko));
                    if(TextBox.Text!="")
                        db.Commands[0].Parameters.Add(new Parameter("@str", SqlDbType.VarChar, TextBox.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                frmNotaPiutangLookup ifrmDialog = new frmNotaPiutangLookup(dt);
                ifrmDialog.ShowDialog();
                if (ifrmDialog.DialogResult == DialogResult.OK)
                {
                    GetDialogResult(ifrmDialog);
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            
        }

        private void GetDialogResult(frmNotaPiutangLookup dialogForm)
        {
            if (noReg != "")
            {
                this.kpid = dialogForm.RowID;
                this.TextBox.Text = dialogForm.NoNota;
                this.tglJTempo = dialogForm.TglJatuhTempo;
                this.rpNota = dialogForm.RpNota;
                this.rpTagih = dialogForm.RpTagih;
                this.kprecid = dialogForm.RecordID;
                this.jenis = dialogForm.Jenis;
                this.tgltransaksi = dialogForm.TglTransaksi;
                this.rowidorderpenjualan = dialogForm.RowIDOrderPenjualan;

                DataTable dtTagihan = cekNoRegNota();
                if (dtTagihan.Rows.Count > 0)
                {
                    this.tagihDetailID = (Guid)dtTagihan.Rows[0]["RowID"];
                    this.tagihDetailRecID = dtTagihan.Rows[0]["RecordID"].ToString();
                    this.tglReg = (DateTime)dtTagihan.Rows[0]["TglReg"];
                }
                else
                {
                    this.kpid = Guid.Empty;
                    MessageBox.Show("Nota belum terdaftar di register.");
                    TextBox.Focus();
                }
                //this.tagihDetailID = Guid.NewGuid();
                //this.tagihDetailRecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                //if (this.SelectData != null)
                //{
                //    this.SelectData(this, new EventArgs());
                //}
            }
            else
            {
                this.kpid = dialogForm.RowID;
                this.TextBox.Text = dialogForm.NoNota;
                this.tglJTempo = dialogForm.TglJatuhTempo;
                this.rpNota = dialogForm.RpNota;
                this.rpTagih = dialogForm.RpTagih;
                this.kprecid = dialogForm.RecordID;
                this.jenis = dialogForm.Jenis;
                this.tgltransaksi = dialogForm.TglTransaksi;
                this.rowidorderpenjualan = dialogForm.RowIDOrderPenjualan;
            }
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }

            //else
            //{
            //    this.kpid = dialogForm.RowID;
            //    //DataTable dtTagihan = cekNoRegNota();
            //    //if (dtTagihan.Rows.Count > 0)
            //    //{
            //        this.TextBox.Text = dialogForm.NoNota;
            //        this.tglJTempo = dialogForm.TglJatuhTempo;
            //        this.rpNota = dialogForm.RpNota;
            //        this.rpTagih = dialogForm.RpTagih;
            //        this.kprecid = dialogForm.RecordID;
            //        this.jenis = dialogForm.Jenis;
            //        this.tagihDetailID = Guid.NewGuid();
            //        this.tagihDetailRecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
            //        //this.tagihDetailID = (Guid)dtTagihan.Rows[0]["RowID"];
            //        //this.tagihDetailRecID = dtTagihan.Rows[0]["RecordID"].ToString();
            //    //}
            //    //else
            //    //{
            //    //    this.kpid = Guid.Empty;
            //    //    MessageBox.Show("Nota belum terdaftar di register.");
            //    //    TextBox.Focus();
            //    //}
            //    if (this.SelectData != null)
            //    {
            //        this.SelectData(this, new EventArgs());
            //    }
            //}
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ShowDialogForm();
            }
        }

        private DataTable cekNoRegNota()
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_CekNotaTagihan"));
                    db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.UniqueIdentifier, kpid));
                    db.Commands[0].Parameters.Add(new Parameter("@NoReg", SqlDbType.VarChar, noReg));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }


            return dt;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
