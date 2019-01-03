using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.VLapW
{
    public partial class frmKoliToneBrowse : ISA.Trading.BaseForm
    {
        int prevGrid1Row = -1;
        public frmKoliToneBrowse()
        {
            InitializeComponent();
        }

        private void frmKoliToneBrowse_Load(object sender, EventArgs e)
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
                    db.Commands.Add(db.CreateCommand("usp_KoliTone_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                }
            }
            catch(Exception ex)
            {
                Error.LogError(ex);
            }
        }
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert) //tambah
            {
                VLapW.frmKoliToneUpdate ifrmChild = new VLapW.frmKoliToneUpdate(this);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            else if (e.KeyCode == Keys.End) //edit
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    VLapW.frmKoliToneUpdate ifrmChild = new VLapW.frmKoliToneUpdate(this, rowID);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
                else
                {
                    MessageBox.Show(Messages.Error.RowNotSelected);
                }
            }
            else if (e.KeyCode == Keys.Delete)//delete
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        try
                        {
                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_KoliTone_DELETE"));
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
                    MessageBox.Show(Messages.Error.RowNotSelected);
                }
            }
            else
            {
                this.Show();
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {   if (dataGridView1.RowCount>0)
            {
            VLapW.frmKoliToneUpdate ifrmChild = new VLapW.frmKoliToneUpdate(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
            }
            
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                VLapW.frmKoliToneUpdate ifrmChild = new VLapW.frmKoliToneUpdate(this, rowID);
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
            if (dataGridView1.SelectedCells.Count > 0)
            {
                if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_KoliTone_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }

                        MessageBox.Show("Record telah dihapus");
                        this.DialogResult = DialogResult.OK;
                        this.RefreshData();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
        }

        public void FindHeader(Guid _RowID)
        {
            dataGridView1.FindRow("RowID", _RowID.ToString());
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }
        
    }
}
