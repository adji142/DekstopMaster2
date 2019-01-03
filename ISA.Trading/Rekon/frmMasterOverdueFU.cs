using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Rekon
{
    public partial class frmMasterOverdueFU : ISA.Trading.BaseForm
    {
        DataTable dtHeader = new DataTable();


        private void refreshGrid()
        {
            try
            {
                using (Database db = new Database())
                {

                    dtHeader = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_OverduFue_List"));
                    
                    dtHeader = db.Commands[0].ExecuteDataTable();
                    dtHeader.DefaultView.Sort = "IDKP";
                    dataGridPromo.DataSource = dtHeader.DefaultView;
                }
                 
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }
        
        public frmMasterOverdueFU()
        {
            InitializeComponent();
        }

        private void frmMasterOverdueFU_Load(object sender, EventArgs e)
        {
            dataGridPromo.AutoGenerateColumns = true;
            refreshGrid();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            Rekon.frmDownloadOverdueFU ifrmChild = new Rekon.frmDownloadOverdueFU();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
