using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Toko.Controls
{
    public partial class frmJenisTransaksiLookUp : ISA.Toko.BaseForm
    {
        private string _idTr = string.Empty;
        private string _keterangan = string.Empty;
        private string _kelompok = string.Empty;
        private int _jw = 0;
        private int _js = 0;

        public string IdTr
        {
            get { return _idTr; }
        }

        public string Keterangan
        {
            get { return _keterangan; }
        }

        public string Kelompok
        {
            get { return _kelompok; }
        }

        public int JW
        {
            get { return _jw; }
        }

        public int JS
        {
            get { return _js; }
        }


        public frmJenisTransaksiLookUp()
        {
            InitializeComponent();
        }

        public frmJenisTransaksiLookUp(string searchArg, DataTable dt)
        {
            InitializeComponent();
            txtNama.Text = searchArg;
            dt.DefaultView.Sort = "Kode";
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt.DefaultView;
        }

        private void frmJenisTransaksiLookUp_Load(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Focus();
            }
        }

        public void RefreshData()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_JenisTransaksi_DO"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeTr", SqlDbType.VarChar, txtNama.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    dt.DefaultView.Sort = "Kode";
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = dt.DefaultView;
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Focus();
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
            if (dataGridView1.SelectedCells.Count == 1)
            {                
                ConfirmSelect();
            }
        }

        private void ConfirmSelect()
        {
            if (dataGridView1.SelectedCells.Count == 1)
            {
                _idTr = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["KodeTr"].Value, string.Empty).ToString();
                _keterangan = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["NamaTr"].Value, string.Empty).ToString();
                _kelompok = dataGridView1.SelectedCells[0].OwningRow.Cells["KelompokTr"].Value.ToString();
                _jw = int.Parse(Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["JwTr"].Value, "0").ToString());
                _js = int.Parse(Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["JsTr"].Value, "0").ToString());
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dataGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }


    }
}
