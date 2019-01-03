using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Trading.VWil
{
    public partial class frmRiwayatIDWilBrowse : ISA.Trading.BaseForm
    {
        int prevGrid1Row = -1;

        public frmRiwayatIDWilBrowse()
        {
            InitializeComponent();
        }

        private void frmRiwayatIDWilBrowse_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt.DefaultView;
                }
               
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    RefreshDataDetail();
                    label1.Text = (dataGridView1.SelectedCells[0].OwningRow.Cells["Alamat"].Value.ToString())
                  + "  "
                  + (dataGridView1.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString());

                }
                else
                {
                    dataGridView2.DataSource = null;
                    label1.Text = "";
                }
                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void RefreshDataDetail()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    
                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                    db.Commands.Add(db.CreateCommand("usp_ReIDWil_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    
                }

                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt.DefaultView;
                }
                else
                {
                    dataGridView2.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                if (Convert.ToBoolean(dataGridView2.SelectedCells[0].OwningRow.Cells["upd"].Value) == false && dataGridView2.SelectedCells[0].OwningRow.Cells["IdWilBaru"].Value.ToString() != "")
                {

                    Guid tokoID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["TokoID"].Value;
                    string wilID = dataGridView1.SelectedCells[0].OwningRow.Cells["IdWilBaru"].Value.ToString();
                    Guid rowID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_Toko_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, tokoID));
                        db.Commands[0].Parameters.Add(new Parameter("@wilID", SqlDbType.VarChar, wilID));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        

                        //db.Commands.Add(db.CreateCommand("usp_ReIDWil_UPDATE"));
                        //db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                        //db.Commands[0].Parameters.Add(new Parameter("@lRefresh", SqlDbType.VarChar, wilID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            //if (dataGridView2.SelectedCells.Count > 0)
            //{
                if (dataGridView1.SelectedCells[0].OwningRow.Cells["WilID"].Value.ToString() != "")
                {
                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    string idwil = dataGridView1.SelectedCells[0].OwningRow.Cells["WilID"].Value.ToString();
                    //string lrefresh = dataGridView2.SelectedCells[0].OwningRow.Cells["LRefresh"].Value.ToString();

                    VWil.frmRiwayatIDWilUpdate ifrmChild = new VWil.frmRiwayatIDWilUpdate(this, rowID, idwil);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
            //}

            //else
            //{
                //MessageBox.Show(Messages.Error.RowNotSelected);
            //}
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                if (Convert.ToBoolean(dataGridView2.SelectedCells[0].OwningRow.Cells["Upd"].Value) == false)
                {
                    Guid rowID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["Row"].Value;
                    VWil.frmRiwayatIDWilUpdate ifrmChild = new VWil.frmRiwayatIDWilUpdate(this, rowID);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
                else
                {
                    cmdEdit.Enabled = false;
                }
            }
            
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                if (Convert.ToBoolean(dataGridView2.SelectedCells[0].OwningRow.Cells["Upd"].Value) == false)
                {
                    if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Guid rowID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["Row"].Value;
                        try
                        {
                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_ReIDWil_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                                dt = db.Commands[0].ExecuteDataTable();
                            }

                            MessageBox.Show("Record telah dihapus");
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
                    cmdDelete.Enabled = false;
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FindHeader(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }

        public void FindDetail(string columnName, string value)
        {
            dataGridView2.FindRow(columnName, value);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //cmdAdd.Enabled = false;
            //cmdEdit.Enabled = false;
            //cmdDelete.Enabled = false;

            
            label1.Text = "";
            if (dataGridView1.SelectedCells.Count > 0)
            {
                if (dataGridView1.SelectedCells[0].RowIndex != prevGrid1Row)
                {
       
                    label1.Text = (dataGridView1.SelectedCells[0].OwningRow.Cells["Alamat"].Value.ToString())
                     + "  "
                     + (dataGridView1.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString());
                }
                prevGrid1Row = dataGridView1.SelectedCells[0].RowIndex;


            }
            else
            {
                dataGridView2.DataSource = null;
                label1.Text = "";
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmdAdd.Enabled = true;
            if (dataGridView2.RowCount > 0)
            {
                if (Convert.ToBoolean(dataGridView2.SelectedCells[0].OwningRow.Cells["Upd"].Value) == false)
                {
                    cmdEdit.Enabled = true;
                    cmdDelete.Enabled = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                if (Convert.ToBoolean(dataGridView2.SelectedCells[0].OwningRow.Cells["upd"].Value) == false && dataGridView2.SelectedCells[0].OwningRow.Cells["IdWilBaru"].Value.ToString() != "")
                {
                    string wilID = dataGridView2.SelectedCells[0].OwningRow.Cells["IdWilBaru"].Value.ToString();
                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    Guid reWilRowID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["Row"].Value;

                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_Toko_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@wilID", SqlDbType.VarChar, wilID));
                        db.Commands[0].Parameters.Add(new Parameter("@reWilRowID", SqlDbType.UniqueIdentifier, reWilRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        RefreshData();
                        MessageBox.Show("Refresh data transaksi telah selesai");
                    }
                }
                else
                {
                    MessageBox.Show("Record ini sudah diupload");
                }
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // return;
        }

        private void dataGridView1_SelectionRowChanged(object sender, EventArgs e)
        {
            label1.Text = "";
            if (dataGridView1.SelectedCells.Count > 0)
            {
                    RefreshDataDetail();
                    label1.Text = (dataGridView1.SelectedCells[0].OwningRow.Cells["Alamat"].Value.ToString())
                     + "  "
                     + (dataGridView1.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString());
                    RefreshDataDetail();
            }
            else
            {
                dataGridView2.DataSource = null;
                label1.Text = "";
            }
        }
    }
}
