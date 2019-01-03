using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlTypes;
using ISA.DAL;
using ISA.Finance.DataTemplates;
using Microsoft.Reporting.WinForms;
using ISA.Finance.Class;
using ISA.Finance;


namespace ISA.Finance.Hutang
{
    public partial class frmPembayaranGetBukti : ISA.Controls.BaseForm
    {

        DataTable dtH = new DataTable("PLL");
        DataRow[] dr;

        public frmPembayaranGetBukti()
        {
            InitializeComponent();
        }

        public DataRow GetData
        {
            get {

                return dr[0];
            }
        }

        public frmPembayaranGetBukti(DataTable dt)
        {
            InitializeComponent();
            dtH = dt.Copy();
        }
        public frmPembayaranGetBukti(DataTable dt, string Title_)
        {
            InitializeComponent();
            dtH = dt.Copy();
            this.Text = Title_;
            this.Title = Title_;
        }

        private void frmPembayaranGetBukti_Load(object sender, EventArgs e)
        {
            customGridView1.AutoGenerateColumns = true;
            
            customGridView1.DataSource = dtH;
            foreach (DataGridViewColumn col in customGridView1.Columns)
            {
                if (col.Name.Contains("Row"))
                {
                    col.Visible = false;
                }

                if (col.Name.Contains("Tanggal") || col.Name.Contains("Tgl"))
                {
                    col.DefaultCellStyle.Format = "dd-MM-yyyy";
                }

                if (col.Name.Contains("MataUangID")  )
                {
                    col.HeaderText = "M.Uang";
                }

                if (col.Name.Contains("MataUangID"))
                {
                    col.HeaderText = "M.Uang";
                }

                if (col.Name.Contains("Rp") || col.Name.Contains("Amount") || col.Name.Contains("Nominal"))
                {
                    col.DefaultCellStyle.Format = "N2";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            customGridView1.Focus();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void ConfirmSelect()
        {
            if (customGridView1.SelectedCells.Count == 1)
            {
                string _rowID = customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
                dr= dtH.Select("RowID='" + _rowID + "'");
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void customGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && customGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void customGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }
    }
}
