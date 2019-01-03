using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Toko.Master
{
    public partial class frmPenanggungjawabRakBrowse : ISA.Toko.BaseForm
    {
        int prevGrid1Row = -1;

        public frmPenanggungjawabRakBrowse()
        {
            InitializeComponent();
        }
        
        private void frmPenanggungJawabRakBrowser_Load(object sender, EventArgs e)
        {
            //RefreshData();
        }
        
        public void RefreshData()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dtStok = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_StokPenanggungjawabRak_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaBarang", SqlDbType.VarChar, txtNama.Text));
                    dtStok = db.Commands[0].ExecuteDataTable();
                    dgvStock.DataSource = dtStok;
                }

                if (dgvStock.SelectedCells.Count > 0)
                {
                    RefreshDataPJ();
                    lblNamaBarang.Text = dgvStock.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();
                    lblNamaTertera.Text = dgvStock.SelectedCells[0].OwningRow.Cells["NamaTertera"].Value.ToString();
                }
            }
            catch(Exception ex)
            {
                Error.LogError(ex );
            }
        }

        public void RefreshDataPJ()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dtPJ = new DataTable();

                    string rowID = dgvStock.SelectedCells[0].OwningRow.Cells["KodeRak"].Value.ToString();

                    db.Commands.Add(db.CreateCommand("usp_PenanggungjawabRak_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeRak", SqlDbType.VarChar, rowID));
                    dtPJ = db.Commands[0].ExecuteDataTable();
                    dgvPenanggungjawabRak.DataSource = dtPJ;
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
            //try
            //{

            //    DataTable dt = new DataTable();
            //    using (Database db = new Database())
            //    {

            //        db.Commands.Add(db.CreateCommand("usp_StokPenanggungjawabRak_LIST"));

            //        db.Commands[0].Parameters.Add(new Parameter("@NamaBarang", SqlDbType.VarChar, txtNama.Text));
            //        dt = db.Commands[0].ExecuteDataTable();
            //        dgvStock.DataSource = dt;
                 
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Error.LogError(ex);
            //}
           
        }

        private void txtNama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            string kode = dgvStock.SelectedCells[0].OwningRow.Cells["KodeRak"].Value.ToString();
            kode = kode.Trim();
            if (kode != "")
            {
                Master.frmPenanggungjawabRakUpdate ifrmChild = new Master.frmPenanggungjawabRakUpdate(this, kode);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            else
            {
                MessageBox.Show("Tidak dapat entry data, karena data kode rak tidak ada");
            }
             
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dgvStock.SelectedCells.Count > 0 && dgvPenanggungjawabRak.SelectedCells.Count > 0)
            {
                //kodeRak
                string kode = dgvStock.SelectedCells[0].OwningRow.Cells["KodeRak"].Value.ToString();
                //rowid punya penanggungjawab rak
                Guid rowID = (Guid)dgvPenanggungjawabRak.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                //nama dari penannggungjawab rak
                string nama = dgvPenanggungjawabRak.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();

                Master.frmPenanggungjawabRakUpdate ifrmChild = new Master.frmPenanggungjawabRakUpdate(this, kode, rowID, nama);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();

            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (dgvStock.SelectedCells.Count > 0 && dgvPenanggungjawabRak.SelectedCells.Count > 0)
            {
                if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Guid rowID = (Guid)dgvPenanggungjawabRak.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    string kode = dgvStock.SelectedCells[0].OwningRow.Cells["KodeRak"].Value.ToString();
                    using (Database db = new Database())
                    {
                        db.Open();

                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_PenanggungjawabRak_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                        dt = db.Commands[0].ExecuteDataTable();

                        db.Close();
                        db.Dispose();
                    }

                    MessageBox.Show("Record telah dihapus");
                    this.RefreshDataPJ();
                }
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FindHeader(string columnName, string value)
        {
            dgvStock.FindRow(columnName, value);
        }

        public void FindDetail(string columnName, string value)
        {
            dgvPenanggungjawabRak.FindRow(columnName, value);
        }

        private void dgvStock_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dgvStock.SelectedCells.Count > 0)
            {
                RefreshDataPJ();
                lblNamaBarang.Text = dgvStock.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();
                lblNamaTertera.Text = dgvStock.SelectedCells[0].OwningRow.Cells["NamaTertera"].Value.ToString();
            }
        } 
    }

}