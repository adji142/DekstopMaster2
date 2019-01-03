using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;


namespace ISA.Finance.Controls
{
    public partial class LookupPegawaiHRD : UserControl
    {
        public LookupPegawaiHRD()
        {
            InitializeComponent();
        }

        string nip, unitkerja, lp, jabatan, alamat, no_telp, keterangan;
        DateTime tgl_lahir, tgl_masuk;
        public event EventHandler SelectData;

        public string Nip
        {
            get
            {
                return nip;
            }
            set
            {
                nip = value;
            }
        }

        public string Nama
        {
            get
            {
                return commonTextBox1.Text;
            }
            set
            {
                commonTextBox1.Text = value;
            }
        }

        public string Unitkerja
        {
            get
            {
                return unitkerja;
            }
            set
            {
                unitkerja = value;
            }
        }


        public string LP
        {
            get
            {
                return lp;
            }
            set
            {
                lp = value;
            }
        }

        public string Jabatan
        {
            get
            {
                return jabatan;
            }
            set
            {
                jabatan = value;
            }
        }

        public string Alamat
        {
            get
            {
                return alamat;
            }
            set
            {
                alamat = value;
            }
        }

        public string NoTelp
        {
            get
            {
                return no_telp;
            }
            set
            {
                no_telp = value;
            }
        }

        public DateTime TglLahir
        {
            get
            {
                return tgl_lahir;
            }
            set
            {
                tgl_lahir = value;
            }
        }

        public DateTime TglMasuk
        {
            get
            {
                return tgl_masuk;
            }
            set
            {
                tgl_masuk = value;
            }
        }
        

        public string Keterangan
        {
            get
            {
                return keterangan;
            }
            set
            {
                keterangan = value;
            }
        }


     

        private void commonTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ShowDialogForm();
            }
        }

        private void ShowDialogForm()
        {
            try
            {
                DataTable dtPegawai = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Lookup_Pegawai"));
                    db.Commands[0].Parameters.Add(new Parameter("@str", SqlDbType.VarChar, commonTextBox1.Text));
                    dtPegawai = db.Commands[0].ExecuteDataTable();
                }
                frmPegawaiLookupHRD ifrmDialog = new frmPegawaiLookupHRD(dtPegawai);
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



        private void GetDialogResult(frmPegawaiLookupHRD dialogForm)
        {
            this.nip = dialogForm._NIP;
            this.commonTextBox1.Text = dialogForm._Nama;
            this.unitkerja = dialogForm._Unitkerja;
            this.lp = dialogForm._LP;
            this.jabatan = dialogForm._Jabatan;
            this.alamat = dialogForm._Alamat;
            this.no_telp = dialogForm._NoTelp;
            this.tgl_lahir = dialogForm._TglLahir;
            this.tgl_masuk = dialogForm._TglMasuk;            
            this.keterangan = dialogForm._Keterangan;

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }
    }
}
