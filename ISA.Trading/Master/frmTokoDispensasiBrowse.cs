using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Master
{
    public partial class frmTokoDispensasiBrowse : ISA.Trading.BaseForm
    {
        DataTable dtDispen = new DataTable();
        public frmTokoDispensasiBrowse()
        {
            InitializeComponent();
        }
         
        private void LoadData()
        {
            try
            {
                using (Database db = new Database())
                {
                    dtDispen = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_TokoDispensasi_Seacrh"));
                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtSearch.Text));
                    dtDispen = db.Commands[0].ExecuteDataTable();
                    DataGridTokoDispen.DataSource = dtDispen;
                }
                if (dtDispen.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data");
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cmbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbDownload_Click(object sender, EventArgs e)
        {
            Communicator.frmFoxproDownloader ifrmChild = new Communicator.frmFoxproDownloader(ISA.Trading.Communicator.frmFoxproDownloader.enDownloadType.TokoDispensasi);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.MinimizeBox = false;
            ifrmChild.Show();
        }

        private void cmbUpload_Click(object sender, EventArgs e)
        {
            frmTokoDispensasiUpload ifrmChild = new frmTokoDispensasiUpload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.MinimizeBox = false;
            ifrmChild.Show();
        }

        private void frmTokoDispensasiBrowse_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

    }
}
