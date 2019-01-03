using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.VisualBasic;

namespace ISA.Trading.CSM
{
    public partial class frmCustKontrak6 : ISA.Trading.BaseForm
    {
       // int prevGrid1Row = -1;
        enum enumSelectedGrid { CISelected, DetailCISelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.CISelected;
        DataTable dtToko = new DataTable();
        DataTable dtTokoDetail = new DataTable();
        public frmCustKontrak6()
        {
            InitializeComponent();
        }

        private void MasterCustomerInti_Load(object sender, EventArgs e)
        {
            RefreshDataCustomer();
           // RefreshDataCabang();
           // dataGridCabang.FindRow("CabangID", GlobalVar.CabangID);
        }

        private void dataGridCustomerInti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void RefreshDataCustomer()
        {
            try
            {
                using (Database db = new Database())
                {

                    dtToko = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_CSM_Customer_Inti"));
                    db.Commands[0].Parameters.Add(new Parameter("@namaToko", SqlDbType.VarChar, txtSearch.Text));
                    dtToko = db.Commands[0].ExecuteDataTable();
                    dataGridCustomerInti.DataSource = dtToko;
                }
                if (dataGridCustomerInti.SelectedCells.Count > 0)
                {
                    lblCustToko.Text = "\"" + (dataGridCustomerInti.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString())
                    + "\"  "
                    + (dataGridCustomerInti.SelectedCells[0].OwningRow.Cells["Alamat"].Value.ToString());

                    //if (dataGridCustomerInti.SelectedCells.Count > 0)
                   // {
                    //    RefreshDataStatusToko();
                    //}
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataCustomer();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.CISelected:
                    CSM.frmCustKontrak3Update ifrmChild = new CSM.frmCustKontrak3Update();
                    //ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.ShowDialog();
                    break;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
