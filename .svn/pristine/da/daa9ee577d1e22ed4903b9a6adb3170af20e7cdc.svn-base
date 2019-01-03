using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.SIP
{
    public partial class frmSIPBrowse : ISA.Trading.BaseForm
    {
        string _KodeToko;
        Guid _RowID;
        bool _finish;
        public frmSIPBrowse()
        {
            InitializeComponent();
        }

        private void frmSIPBrowse_Load(object sender, EventArgs e)
        {
            _KodeToko = "";
           

            _RowID = Guid.NewGuid();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.VirtualMode = true;
            dataGridView1.DataSource = null;
           
            label1.Text = "";
            textBox1.Focus();
            
           
        }

        public void RefreshData(string NamaToko_)
        {
            try
            {
                DataTable dtToko = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_SIP_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, GlobalVar.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaToko", SqlDbType.VarChar, NamaToko_));
                    dtToko = db.Commands[0].ExecuteDataTable();
                }
                dataGridView1.DataSource = dtToko;
                if (dataGridView1.RowCount == 0)
                    dataGridView1.DataSource = null;

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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0 && _finish)
            {
                label1.Text = "\"" + (dataGridView1.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString())
                   + "\"  "
                   + (dataGridView1.SelectedCells[0].OwningRow.Cells["Alamat"].Value.ToString())
                   + "  "
                   + (dataGridView1.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString());
                _KodeToko = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
                _RowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            }
            else
            {
                label1.Text = " ";
                _KodeToko = "";
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.F12 )
            {
                if (_KodeToko != "")
                {
                    SIP.frmRptSIP ifrmChild = new SIP.frmRptSIP(this, _KodeToko,_RowID,false);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
            }


            if (e.KeyCode == Keys.F9)
            {
                if (_KodeToko != "")
                {
                    SIP.frmRptSIP ifrmChild = new SIP.frmRptSIP(this, _KodeToko, _RowID,true);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
            }

            if (e.KeyCode == Keys.F10)
            {
                if (_KodeToko != "")
                {
                    SIP.frmPerbandinganItemToko ifrmChild = new SIP.frmPerbandinganItemToko(this, _KodeToko);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
            }

            if (e.KeyCode == Keys.F11)
            {
                if (_KodeToko != "")
                {
                    string kodeToko = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["KodeToko"].Value, string.Empty).ToString();
                    string namaToko = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["NamaToko"].Value, string.Empty).ToString();
                    string alamatToko = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["Alamat"].Value, string.Empty).ToString();
                    string kotaToko = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["Kota"].Value, string.Empty).ToString();
                    string wilID = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["IdWil"].Value, string.Empty).ToString();

                    SIP.frmRptProgresSKUToko ifrmChild = new SIP.frmRptProgresSKUToko(kodeToko, namaToko, alamatToko, kotaToko, wilID);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
            }            
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            _finish = false;
            RefreshData(textBox1.Text.Trim());
            _finish = true;
            dataGridView1.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdSearch.PerformClick();
            }
        }

    }
}
