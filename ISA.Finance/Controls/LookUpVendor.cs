using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Finance.Controls
{
    public partial class LookUpVendor : UserControl
    {
        public event EventHandler SelectData;
        DataTable dt = new DataTable();

        string _NamaVendor = string.Empty;
        string _PemasokID = string.Empty;
        Guid _RowIDPemasok = Guid.Empty;

        [Browsable(true)]



        public string NamaVendor
        {
            get { return _NamaVendor; }
            set
            {
                _NamaVendor = value;
                this.txtNamaVendor.Text = _NamaVendor;
            }
        }

        public string PemasokID
        {
            get { return _PemasokID; }
            set
            {
                _PemasokID = value;
                lblVendorID.Text = _PemasokID;
            }
        }

        public Guid RowIDPemasok
        {
            get { return _RowIDPemasok; }
            set
            {
                _RowIDPemasok = value;
                //lblVendorID.Text = _PemasokID;
            }
        }


        public LookUpVendor()
        {
            InitializeComponent();
            Clear();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            ShowDialogForm();
            Validate();
        }

        private void ShowDialogForm()
        {
            bool l = false;

            DataTable dtg = new DataTable();

            dtg = GetData(txtNamaVendor.Text.Trim(), l);

            if (dtg.Rows.Count == 0)
            {
                return;
            }

            if (dtg.Rows.Count == 1)
            {
                GetResult(dtg.Rows[0]);
            }
            else
            {
                frmLookUpVendor ifrmDialog = new frmLookUpVendor(dtg);
                ifrmDialog.ShowDialog();
                if (ifrmDialog.DialogResult == DialogResult.OK)
                {
                    GetDialogResult(ifrmDialog);
                }

            }
        }

        private void GetDialogResult(frmLookUpVendor dialogForm)
        {
            NamaVendor = dialogForm.GetVendor["Nama"].ToString();
            PemasokID = dialogForm.GetVendor["PemasokID"].ToString();
            RowIDPemasok = (Guid)dialogForm.GetVendor["RowID"];

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void GetResult(DataRow dialogForm)
        {
            NamaVendor = dialogForm["Nama"].ToString();
            PemasokID = dialogForm["PemasokID"].ToString();
            RowIDPemasok = (Guid)dialogForm["RowID"];

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private DataTable GetData(string SearchArg, bool lokal)
        {
            DataTable d = new DataTable();
            DataTable dtv = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[usp_Pemasok_LookUp]"));
                db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, SearchArg.Trim()));
                d = db.Commands[0].ExecuteDataTable();
            }

            dtv = d.Copy();
            return dtv;


        }

        public void Clear()
        {

            NamaVendor = string.Empty;
            PemasokID = string.Empty;
        }

        private void txtNamaVendor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNamaVendor.Text.Trim() != "" || txtNamaVendor.Text != NamaVendor)
                {
                    cmdSearch.PerformClick();
                }
            }
        }

        private void txtNamaVendor_TextChanged(object sender, EventArgs e)
        {
            if (txtNamaVendor.Text.Trim() == "")
            {
                Clear();
            }
            Validate();
        }

        public void SetVendor(String PemasokID)
        {
            DataTable d = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[psho_usp_Pemasok_LIST_V2]"));
                db.Commands[0].Parameters.Add(new Parameter("@PemasokID", SqlDbType.UniqueIdentifier, PemasokID));
                d = db.Commands[0].ExecuteDataTable();
            }

            if (d.Rows.Count == 1)
            {
                NamaVendor = d.Rows[0]["NamaVendor"].ToString();
                PemasokID = d.Rows[0]["VendorID"].ToString();
                RowIDPemasok = (Guid)d.Rows[0]["RowID"];

            }
            Validate();
        }


    }


}
