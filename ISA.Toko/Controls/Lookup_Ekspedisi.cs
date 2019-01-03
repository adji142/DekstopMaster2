using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Controls
{
    public partial class Lookup_Ekspedisi : UserControl
    {
        public event EventHandler SelectData;

        private string _KodeExpedisi = string.Empty;
        private string _Expedisi = string.Empty;
        private string _kelompok = string.Empty;
        private int _jw = 0;
        private int _js = 0;
        private string _lastKeterangan = string.Empty;


        public string KodeExpedisi
        {
            get { return Tools.isNull(_KodeExpedisi, string.Empty).ToString(); }
            set
            {
                _KodeExpedisi = value;
                GetKodeJenisTransaksi(value);
            }
        }

        public string Expedisi
        {
            get { return _Expedisi; }
            set 
            {
                _Expedisi = value;
            }
        }

       


        public Lookup_Ekspedisi()
        {
            _lastKeterangan = string.Empty;

            InitializeComponent();
        }

        public void SetNamaTransaksi(string nama)
        {
            txtLookupName.Text = nama;
            _lastKeterangan = nama;
        }

        private void txtLookupName_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void ShowDialogForm()
        {
            frm_Ekspedisi ifrmDialog = new frm_Ekspedisi();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
            else
            {
                txtLookupName.Focus();
            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            frm_Ekspedisi ifrmDialog = new frm_Ekspedisi(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
            else
            {
                txtLookupName.Focus();
            }
        }

        private void GetDialogResult(frm_Ekspedisi dialogForm)
        {
            _KodeExpedisi = dialogForm.KodeExpedisi;
            txtLookupName.Text = dialogForm.Expedisi;
            txtLookupCode.Text = dialogForm.KodeExpedisi;
            _Expedisi = dialogForm.Expedisi;
            
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void Clear()
        {
            _KodeExpedisi = string.Empty;
            txtLookupName.Text = "";
            _lastKeterangan = txtLookupName.Text;
            txtLookupCode.Text = "";
            _Expedisi = string.Empty;
            _kelompok = string.Empty;
            _jw = 0;
            _js = 0;

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void cmdLookup_Click(object sender, EventArgs e)
        {
            ShowDialogForm();
        }

        public void ShowDialogFormValidation()
        {
            if (txtLookupName.Text != "")
            {
                SearchJenisTransaksi();
            }
        
        }

        public void SearchJenisTransaksi()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_ExpedisiCbo_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@Aktif", SqlDbType.Bit, true));
                    db.Commands[0].Parameters.Add(new Parameter("@SearchArg", SqlDbType.VarChar, txtLookupName.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count == 1)
                    {
                        txtLookupName.Text = Tools.isNull(dt.Rows[0]["Expedisi"], string.Empty).ToString();
                        txtLookupCode.Text = Tools.isNull(dt.Rows[0]["KodeExpedisi"], string.Empty).ToString();
                        _lastKeterangan = txtLookupCode.Text;

                        _KodeExpedisi = Tools.isNull(dt.Rows[0]["KodeExpedisi"], string.Empty).ToString();
                        _Expedisi = Tools.isNull(dt.Rows[0]["Expedisi"], string.Empty).ToString();

                        if (this.SelectData != null)
                        {
                            this.SelectData(this, new EventArgs());
                        }
                    }
                    else
                    {
                        ShowDialogForm(txtLookupName.Text, dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
 
        }

        public void GetKodeJenisTransaksi(String Kode)
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_ExpedisiCbo_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@Aktif", SqlDbType.Bit, true));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeExpedisi", SqlDbType.VarChar, Kode));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count == 1)
                    {
                        txtLookupName.Text = Tools.isNull(dt.Rows[0]["Expedisi"], string.Empty).ToString();
                        txtLookupCode.Text = Tools.isNull(dt.Rows[0]["KodeExpedisi"], string.Empty).ToString();
                        _lastKeterangan = txtLookupCode.Text;

                        _KodeExpedisi = Tools.isNull(dt.Rows[0]["KodeExpedisi"], string.Empty).ToString();
                        _Expedisi = Tools.isNull(dt.Rows[0]["Expedisi"], string.Empty).ToString();

                        if (this.SelectData != null)
                        {
                            this.SelectData(this, new EventArgs());
                        }
                    }
                    else
                    {
                        //ShowDialogForm(txtLookupName.Text, dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }


        private void txtLookupName_Validating(object sender, CancelEventArgs e)
        {
            if (_lastKeterangan.Trim() != txtLookupName.Text.Trim())
            {
                if (txtLookupName.Text != "")
                {
                    SearchJenisTransaksi();
                }
                else
                {
                    Clear();
                }
            }
        }

        private void Lookup_Ekspedisi_Load(object sender, EventArgs e)
        {
            if (GlobalVar.Gudang == "2803")
            {
                try
                {
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();

                        db.Commands.Add(db.CreateCommand("usp_JenisTransaksi_DO"));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeTr", SqlDbType.VarChar, "KG"));
                        dt = db.Commands[0].ExecuteDataTable();
                        if (dt.Rows.Count == 1)
                        {
                            txtLookupName.Text = Tools.isNull(dt.Rows[0]["Expedisi"], string.Empty).ToString();
                            txtLookupCode.Text = Tools.isNull(dt.Rows[0]["KodeExpedisi"], string.Empty).ToString();

                            _KodeExpedisi = Tools.isNull(dt.Rows[0]["KodeExpedisi"], string.Empty).ToString();
                            _Expedisi = Tools.isNull(dt.Rows[0]["Expedisi"], string.Empty).ToString();

                            if (this.SelectData != null)
                            {
                                this.SelectData(this, new EventArgs());
                            }
                        }
                        else
                        {
                            ShowDialogForm(txtLookupName.Text, dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }
    }
}
