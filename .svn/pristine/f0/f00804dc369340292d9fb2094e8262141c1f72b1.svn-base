using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance.Controls
{
    public partial class LookupSO : UserControl
    {
        Guid rowid = Guid.Empty;
        string norequest, tgldo, nodo, namatoko, alamat, kota, kodetoko, rpnet;
        public event EventHandler SelectData;

        public Guid RowID
        {
            get
            {
                return rowid;
            }
            set
            {
                rowid = value;
            }
        }

        public string NoRequest
        {
            get
            {
                return norequest;
            }
            set
            {
                norequest = value;
            }
        }

        public string TglDO
        {
            get
            {
                return tgldo;
            }
            set
            {
                tgldo = value;
            }
        }

        public string NoDO
        {
            get
            {
                return nodo;
            }
            set
            {
                nodo = value;
            }
        }

        public string KodeToko
        {
            get
            {
                return kodetoko;
            }
            set
            {
                kodetoko = value;
            }
        }

        public string NamaToko
        {
            get
            {
                return namatoko;
            }
            set
            {
                namatoko = value;
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

        public string Kota
        {
            get
            {
                return kota;
            }
            set
            {
                kota = value;
            }
        }

        public string RpNet
        {
            get
            {
                return rpnet;
            }
            set
            {
                rpnet = value;
            }
        }

        public LookupSO()
        {
            InitializeComponent();
        }

        private void LookupSO_Load(object sender, EventArgs e)
        {

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
                DataTable dtSO = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Lookup_SO"));
                    db.Commands[0].Parameters.Add(new Parameter("@str", SqlDbType.VarChar, commonTextBox1.Text));
                    dtSO = db.Commands[0].ExecuteDataTable();
                }
                frmSOLookup ifrmDialog = new frmSOLookup(dtSO);
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

        private void GetDialogResult(frmSOLookup dialogForm)
        {
            this.rowid = dialogForm._RowID;
            this.kodetoko = dialogForm._KodeToko;
            this.norequest = dialogForm._NoRequest;
            this.tgldo = dialogForm._TglDO;
            this.namatoko = dialogForm._NamaToko;
            this.alamat = dialogForm._Alamat;
            this.kota = dialogForm._Kota;
            this.commonTextBox1.Text = dialogForm._NoDO;            
            this.rpnet = dialogForm._RpNet;
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

    }
}
