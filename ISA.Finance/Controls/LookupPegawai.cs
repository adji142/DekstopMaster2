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
    public partial class LookupPegawai : UserControl
    {
        string nip, unitkerja, lp, jabatan, alamat;
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

        

        public LookupPegawai()
        {
            InitializeComponent();
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
                frmPegawaiLookup ifrmDialog = new frmPegawaiLookup(dtPegawai);
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



        private void GetDialogResult(frmPegawaiLookup dialogForm)
        {
            this.nip = dialogForm._NIP;
            this.commonTextBox1.Text = dialogForm._Nama;
            this.unitkerja = dialogForm._UnitKerja;
            this.lp = dialogForm._LP;
            this.jabatan = dialogForm._Jabatan;
            this.alamat = dialogForm._Alamat;
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }
    }
}
