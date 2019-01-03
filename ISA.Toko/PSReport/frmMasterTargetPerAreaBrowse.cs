using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.PSReport
{
    public partial class frmMasterTargetPerAreaBrowse : ISA.Toko.BaseForm
    {
        DataTable dtKota, dtTargetArea;
        public frmMasterTargetPerAreaBrowse()
        {
            InitializeComponent();
        }

        private void frmMasterTargetPerAreaBrowse_Load(object sender, EventArgs e)
        {
            RefreshKota();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void RefreshKota()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Kota_list"));
                dtKota = db.Commands[0].ExecuteDataTable();
            }
            customGridView1.DataSource = dtKota;
            if (dtKota.Rows.Count > 0 && customGridView1.SelectedCells.Count > 0)
            {
                string Kota = customGridView1.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString();
                RefreshTargetArea(Kota);

            }
        }


        public void RefreshTargetArea(string Kota)
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_TargetPerArea_List"));
                db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, Kota));
                dtTargetArea = db.Commands[0].ExecuteDataTable();
            }
            customGridView2.DataSource = dtTargetArea;
        }

        private void customGridView1_SelectionRowChanged(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                string Kota = customGridView1.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString();
                RefreshTargetArea(Kota);

            }
        }

        //private void cmdAdd_Click(object sender, EventArgs e)
        //{
        //    string namaSales = customGridView1.SelectedCells[0].OwningRow.Cells["NamaSales"].Value.ToString();
        //    string kodesales = customGridView1.SelectedCells[0].OwningRow.Cells["KodeSales"].Value.ToString();
        //    PSReport.frmMasterTargetPersalesUpdate ifrmChild = new frmMasterTargetPersalesUpdate(this, namaSales, kodesales);
        //    ifrmChild.MdiParent = Program.MainForm;
        //    Program.MainForm.RegisterChild(ifrmChild);
        //    ifrmChild.Show();
        //}

        //private void cmdEdit_Click(object sender, EventArgs e)
        //{
        //    string namaSales = customGridView1.SelectedCells[0].OwningRow.Cells["NamaSales"].Value.ToString();
        //    string kodesales = customGridView1.SelectedCells[0].OwningRow.Cells["KodeSales"].Value.ToString();
        //    Guid RowID = (Guid)customGridView2.SelectedCells[0].OwningRow.Cells["Row"].Value;
        //    PSReport.frmMasterTargetPersalesUpdate ifrmChild = new frmMasterTargetPersalesUpdate(this, namaSales, kodesales, RowID);
        //    ifrmChild.MdiParent = Program.MainForm;
        //    Program.MainForm.RegisterChild(ifrmChild);
        //    ifrmChild.Show();
        //}

        //private void hapusData()
        //{
        //    Guid RowID_ = (Guid)customGridView2.SelectedCells[0].OwningRow.Cells["Row"].Value;
        //    if (MessageBox.Show("Record ini mau dihapus?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        try
        //        {
        //            using (Database db = new Database())
        //            {
        //                DataTable dt = new DataTable();
        //                db.Commands.Add(db.CreateCommand("usp_TabelTargetPerSales_Delete"));
        //                db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, RowID_));
        //                db.Commands[0].ExecuteNonQuery();
        //            }
        //            MessageBox.Show("Data telah dihapus");
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}

        //private void cmdDelete_Click(object sender, EventArgs e)
        //{
        //    hapusData();
        //    string Kota = customGridView1.SelectedCells[0].OwningRow.Cells["KodeSales"].Value.ToString();
        //    RefreshTargetArea(Kota);
        //}

    }
}
