using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Controls;
using ISA.Bengkel.Helper;
using ISA.Bengkel;

namespace ISA.Bengkel.Lookup
{
    public partial class frmSupplierLookup : ISA.Bengkel.BaseForm
    {
        string _kodeSupplier;
        private CustomGridView customGridView1;
        private DataGridViewTextBoxColumn nama;
        private DataGridViewTextBoxColumn Alamat;
        string _namaSupplier;
        private CustomGridView dataGridView;
        private DataGridViewTextBoxColumn NamaPemasok;
        private DataGridViewTextBoxColumn AlamatPemasok;

        string cNama = "";
        

        public frmSupplierLookup()
        {
            InitializeComponent();
        }

        //public frmSupplierLookup(string searchArg, DataTable dt)
        //{
        //    InitializeComponent();
        //    txtNama.Text = searchArg;
        //    dtp = dt;
        //    MessageBox.Show("masuk2");
        //}

        public frmSupplierLookup(string searchArg)
        {
            InitializeComponent();
            if (Tools.isNull(searchArg, "").ToString() != "")
            {
                txtNama.Text = Tools.isNull(searchArg, "").ToString();
                cNama = searchArg;
            }
        }       


        public string KodeSupplier
        {
            get
            {
                return _kodeSupplier;
            }
        }

        public string NamaSupplier
        {
            get
            {
                return _namaSupplier;
            }
        }


        private void frmSupplierLookUp_Load(object sender, EventArgs e)
        {
            //RefreshData();
            if (customGridView1.Rows.Count > 0)
            {
                customGridView1.Focus();
            }
        }

        public void RefreshData()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Bkl_Pemasok_LIST"));
                    if (cNama != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@nama", SqlDbType.VarChar, txtNama.Text));
                    }
                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count > 0)
                    {
                        dataGridView.DataSource = dt;
                        dataGridView.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void txtNama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
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
                _kodeSupplier = customGridView1.SelectedCells[0].OwningRow.Cells["PemasokID"].Value.ToString();
                _namaSupplier = customGridView1.SelectedCells[0].OwningRow.Cells["nama"].Value.ToString();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && customGridView1.SelectedCells.Count == 1)
            {
                e.SuppressKeyPress = true;
                ConfirmSelect();
                
            }
        }

        private void InitializeComponent()
        {
            this.dataGridView = new ISA.Controls.CustomGridView();
            this.NamaPemasok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlamatPemasok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NamaPemasok,
            this.AlamatPemasok});
            this.dataGridView.Location = new System.Drawing.Point(9, 67);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView.Size = new System.Drawing.Size(577, 262);
            this.dataGridView.StandardTab = true;
            this.dataGridView.TabIndex = 5;
            this.dataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_KeyDown);
            // 
            // NamaPemasok
            // 
            this.NamaPemasok.DataPropertyName = "Nama";
            this.NamaPemasok.HeaderText = "Pemasok";
            this.NamaPemasok.Name = "NamaPemasok";
            this.NamaPemasok.ReadOnly = true;
            this.NamaPemasok.Width = 200;
            // 
            // AlamatPemasok
            // 
            this.AlamatPemasok.DataPropertyName = "Alamat";
            this.AlamatPemasok.HeaderText = "Alamat";
            this.AlamatPemasok.Name = "AlamatPemasok";
            this.AlamatPemasok.ReadOnly = true;
            this.AlamatPemasok.Width = 350;
            // 
            // frmSupplierLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(594, 341);
            this.Controls.Add(this.dataGridView);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmSupplierLookup";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmSupplierLookup_Load_1);
            this.Controls.SetChildIndex(this.dataGridView, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void frmSupplierLookup_Load_1(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("pilihan");
            this.Close();
        }



    }
}
