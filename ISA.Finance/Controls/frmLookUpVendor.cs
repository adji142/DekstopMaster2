using System;
using System.Data;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Finance.Controls
{
    public partial class frmLookUpVendor : ISA.Controls.BaseForm
    {
        DataTable dt = new DataTable("Vendor");
        DataRow dr;
        string _SearchArg = string.Empty;
        bool local = false;

        public DataRow GetVendor
        {
            get { return dr; }
        }

        public frmLookUpVendor()
        {
            InitializeComponent();
        }

        public frmLookUpVendor(string SearchArg, bool lokal)
        {
            if (lokal)
            {
                local = true;
            }
            _SearchArg = SearchArg;
            InitializeComponent();
        }


        public frmLookUpVendor(DataTable dtt)
        {
            dt = dtt.Copy();
            InitializeComponent();
        }


        private void RefreshData()
        {
            try
            {
                DataTable d = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[psho_usp_Pemasok_LIST_V2]"));
                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, _SearchArg.Trim()));
                    d = db.Commands[0].ExecuteDataTable();
                }

                dt = d.Copy();
                customGridView1.DataSource = dt;

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void ConfirmSelect()
        {
            if (customGridView1.SelectedCells.Count == 1)
            {
                string _PemasokID = customGridView1.SelectedCells[0].OwningRow.Cells["PemasokID"].Value.ToString();
                dt.DefaultView.RowFilter = "PemasokID='" + _PemasokID + "'";
                dr = dt.DefaultView.ToTable().Rows[0];
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmLookUpVendor_Load(object sender, EventArgs e)
        {
            customGridView1.AutoGenerateColumns = false;
            //RefreshData();
            customGridView1.DataSource = dt.DefaultView;
            customGridView1.Focus();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void customGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && customGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void customGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void commandButton3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                dt.DefaultView.RowFilter = "Nama LIKE '%" + textBox1.Text.Trim() + "%' OR PemasokID LIKE '%" + textBox1.Text.Trim() + "%'";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                dt.DefaultView.RowFilter = "";
            }
        }
    }
}
