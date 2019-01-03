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
    public partial class frmTipeTransaksiBrowse : ISA.Toko.BaseForm
    {
        public frmTipeTransaksiBrowse()
        {
            InitializeComponent();
        }

        private void frmTipeTransaksiBrowse_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Open();

                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_TransactionType_list"));
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
            Master.frmTipeTransaksiUpdate ifrmChild = new Master.frmTipeTransaksiUpdate(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid rowid = new Guid(dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                Master.frmTipeTransaksiUpdate ifrmChild = new Master.frmTipeTransaksiUpdate(this, rowid);
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
            DeleteData();
        }

        private void DeleteData()
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid _rowid = new Guid(dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());

                if (MessageBox.Show("Hapus TransactionType : " + dataGridView1.SelectedCells[0].OwningRow.Cells["Keterangan"].Value.ToString() + "?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            db.Open();

                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_TransactionType_Insert_Update_Delete"));
                            db.Commands[0].Parameters.Add(new Parameter("@do", SqlDbType.Int, 2));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowid));
                            
                            dt = db.Commands[0].ExecuteDataTable();

                            db.Close();
                            db.Dispose();
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show(dt.Rows[0]["pesan"].ToString());
                                
                            }
                        }
                       // MessageBox.Show("Data sudah dihapus.");
                        this.RefreshData();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
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

        public void FindRow(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
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
            if (e.ColumnIndex == 4 ) {
                e.Value = e.Value.ToString() == "True" ? "Aktif" : "Pasif";
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        } 

       

       

       
    }
}
