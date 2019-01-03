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
    public partial class frmBankKotaBrowse : ISA.Toko.BaseForm
    {
        enum GridSelected { Header, Detail }
        
        [DefaultValue(GridSelected.Header)]
        GridSelected Grid;

        public frmBankKotaBrowse()
        {
            InitializeComponent();
        }

        private void frmBankKotaBrowse_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            try
            {
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Open();

                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_BankKota_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                    db.Close();
                    db.Dispose();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

       
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (Grid == GridSelected.Header)
            {
                Master.frmBankKotaUpdate ifrmChild = new Master.frmBankKotaUpdate(this);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            else
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    Guid HeaderRowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    Master.frmJasaHargaUpdate ifrmChild = new Master.frmJasaHargaUpdate(this, HeaderRowID);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
                else
                {
                    MessageBox.Show(Messages.Error.RowNotSelected);
                }
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                if (Grid == GridSelected.Header)
                {
                    Guid rowid = new Guid(dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                    Master.frmBankKotaUpdate ifrmChild = new Master.frmBankKotaUpdate(this, rowid);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
                
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void DeleteData()
        {
            //if (dataGridView1.SelectedCells.Count > 0)
            //{
            //    Guid _rowid = new Guid(dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());

            //    if (MessageBox.Show("Hapus Jasa : " + dataGridView1.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString() + "?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        try
            //        {
            //            using (Database db = new Database(GlobalVar.DBFinance))
            //            {
            //                db.Open();

            //                DataTable dt = new DataTable();
            //                db.Commands.Add(db.CreateCommand("usp_Jasa_Insert_Update_Delete"));
            //                db.Commands[0].Parameters.Add(new Parameter("@do", SqlDbType.Int, 2));
            //                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowid));
                            
            //                dt = db.Commands[0].ExecuteDataTable();

            //                db.Close();
            //                db.Dispose();
            //                if (dt.Rows.Count > 0)
            //                {
            //                    MessageBox.Show(dt.Rows[0]["pesan"].ToString());
                                
            //                }
            //            }
            //           // MessageBox.Show("Data sudah dihapus.");
            //            this.RefreshData();
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.LogError(ex);
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show(Messages.Error.RowNotSelected);
            //}
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FindRow(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }
        public void FindRowDetail(string columnName, string value)
        {
            
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            
            //switch (e.KeyCode)
            //{
            //    case Keys.Insert:
            //        cmdAdd.PerformClick();
            //        break;
            //    case Keys.Delete:
            //        cmdDelete.PerformClick();
            //        break;
            //    case Keys.Space:
            //        cmdEdit.PerformClick();
            //        break;
            //    case Keys.F5:
            //        RefreshData();
            //        break;
            //}
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 ) {
                e.Value = e.Value.ToString() == "False" ? "Aktif" : "Pasif";
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            Grid = GridSelected.Header;
        }

        private void DataGridView2_Click(object sender, EventArgs e)
        {
            Grid = GridSelected.Detail;
        }

        private void dataGridView1_SelectionRowChanged(object sender, EventArgs e)
        {
           
        } 

       

       

       
    }
}
