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
    public partial class frmHPPBrowse : ISA.Toko.BaseForm
    {
        int prevGrid1Row = -1;

        public frmHPPBrowse()
        {
            InitializeComponent();
        }
        
        private void frmHPPBrowse_Load(object sender, EventArgs e)
        {
            //RefreshDataStok();
        } 

        public void RefreshDataStok()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                { 
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Stok_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@namaStok", SqlDbType.VarChar, txtSearch.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Bit", SqlDbType.Bit, true));

                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                }
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    RefreshDataHPP();
                    lblNamaBarang.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["namaStok"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void RefreshDataHPP()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dtHPP = new DataTable();

                    string _barangID = dataGridView1.SelectedCells[0].OwningRow.Cells["BarangID"].Value.ToString();

                    db.Commands.Add(db.CreateCommand("usp_HistoryHPP_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _barangID));
                    dtHPP = db.Commands[0].ExecuteDataTable();
                    dataGridViewHPP.DataSource = dtHPP;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataStok();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void dataGridView1_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                    RefreshDataHPP();
                    lblNamaBarang.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["namaStok"].Value.ToString();
                
            }
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            Master.frmHppDownload ifrmChild = new Master.frmHppDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdadd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0) {
                String KodeBarang= dataGridView1.SelectedCells[0].OwningRow.Cells[BarangID.Name].Value.ToString();
                Master.frmHPPUpdate ifrmChild = new Master.frmHPPUpdate(this, KodeBarang );
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                if (dataGridViewHPP.SelectedCells.Count <= 0)
                {
                    MessageBox.Show(Messages.Error.RowNotSelected);
                    return;
                }

                DateTime TmtCek = (DateTime)dataGridViewHPP.SelectedCells[0].OwningRow.Cells[TMT.Name].Value;
                if (TmtCek != GlobalVar.DateOfServer) { MessageBox.Show("tidak bisa edit data. Tanggal transaksi tidak sesuai dengan tanggal Server."); return; }
                String KodeBarang = dataGridView1.SelectedCells[0].OwningRow.Cells[BarangID.Name].Value.ToString();
                Guid RowID = new Guid(dataGridViewHPP.SelectedCells[0].OwningRow.Cells["HPPRowID"].Value.ToString());
                Master.frmHPPUpdate ifrmChild = new Master.frmHPPUpdate(this, RowID, KodeBarang);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            else { MessageBox.Show(Messages.Error.RowNotSelected); }
        }

        //Saya berharap Bapak/Ibu bersedia meluangkan waktu untuk memberikan kesempatan wawancara, 
        //    sehingga saya dapat menjelaskan secara lebih terperinci tentang potensi diri saya.

        private void frmHPPBrowse_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    cmdadd.PerformClick();
                    break;
                case Keys.Space:
                    cmdEdit.PerformClick();
                    break;
                case Keys.F5:
                    RefreshDataStok();
                    break;
            }
        }
    }
}
