using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Bengkel;
using ISA.Bengkel.Helper;
using System.Data.SqlTypes;
using ISA.Bengkel.Library;
using System;

namespace ISA.Bengkel.Transaksi
{
    public partial class frmLookupPemasok : ISA.Bengkel.BaseForm
    {
        DataTable dt = new DataTable("Vendor");
        DataRow dr;
        string _SearchArg = string.Empty,_Pemasok = "";
        bool local = false;
        Guid _rowID;

        public DataRow  GetVendor
        {
            get {return dr;}
        }

        public frmLookupPemasok()
        {
            InitializeComponent();
        }

        public frmLookupPemasok(DataTable dtt,string Pemasok)
        {
            dt = dtt.Copy();
            InitializeComponent();
            _Pemasok = Tools.isNull(Pemasok,"").ToString();
            txtPemasok.Text = _Pemasok;
        }

        private void RefreshData()
        {
            try
            {
                DataTable d = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_bkl_pemasok_LIST]"));
                    //db.Commands[0].Parameters.Add(new Parameter("@nama", SqlDbType.VarChar, _SearchArg.Trim()));
                    d = db.Commands[0].ExecuteDataTable();
                }
                dt = d.Copy();
                customGridView1.DataSource = dt;
                if (_Pemasok != "")
                    dt.DefaultView.RowFilter = "Nama LIKE '%" + _Pemasok + "%'";
                customGridView1.Focus();
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmLookupPemasok_Load(object sender, System.EventArgs e)
        {
            txtPemasok.TabStop = false;
            cmdCari.TabStop = false;
            customGridView1.AutoGenerateColumns = false;
            RefreshData();
            customGridView1.DataSource = dt.DefaultView;
            customGridView1.Focus();
        }

        private void cmdClose_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void ConfirmSelect()
        {
            _rowID = new Guid(Tools.isNull(customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value, Guid.Empty).ToString());
            dt.DefaultView.RowFilter = "RowID='" + _rowID + "'";
            dr = dt.DefaultView.ToTable().Rows[0];
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtPemasok_TextChanged(object sender, System.EventArgs e)
        {
            if (txtPemasok.Text.Trim() == "")
            {
                dt.DefaultView.RowFilter = "";
            }
        }

        private void cmdCari_Click(object sender, System.EventArgs e)
        {
            if (txtPemasok.Text.Trim() != "")
            {
                dt.DefaultView.RowFilter = "Nama LIKE '%" + _Pemasok + "%'"; 
            }
        }

        private void customGridView1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmSelect();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cmdYes_Click(object sender, System.EventArgs e)
        {
            ConfirmSelect();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void customGridView1_DoubleClick(object sender, EventArgs e)
        {
            ConfirmSelect();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
