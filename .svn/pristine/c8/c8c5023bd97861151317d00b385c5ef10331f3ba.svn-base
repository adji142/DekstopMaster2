using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance.DKNForm
{
    public partial class frmDebetKreditNotaCabangBrowse : ISA.Finance.BaseForm
    {
        public frmDebetKreditNotaCabangBrowse()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDebetKreditNotaCabangBrowse_Load(object sender, EventArgs e)
        {
            gridCabang.ReadOnly = true;
            RefreshData();

        }

        private void RefreshData()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_DKNCabang_LIST"));
                dt = db.Commands[0].ExecuteDataTable();
            }
            dt.DefaultView.Sort = "KodeCabang";
            gridCabang.DataSource = dt.DefaultView;
        }

        public void RefreshRowData(string rowID)
        {
            DataTable dt = new DataTable();
            DataTable dtRefresh;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_DKNCabang_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@KodeCabang", SqlDbType.VarChar, rowID));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                gridCabang.RefreshDataRow(dtRefresh.Rows[0], "KodeCabang", rowID);
            }
        }


        public void FindRow(string columnName, string value)
        {
            gridCabang.FindRow(columnName, value);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            DKNForm.frmDebetKreditNotaCabangUpdate ifrmChild = new DKNForm.frmDebetKreditNotaCabangUpdate(this);
            //ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.ShowDialog();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            string rowID = gridCabang.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString();
            DKNForm.frmDebetKreditNotaCabangUpdate ifrmChild = new DKNForm.frmDebetKreditNotaCabangUpdate(this, rowID);
            //ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.ShowDialog();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Messages.Question.AskDelete, "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    string rowID = gridCabang.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString();
                    db.Commands.Add(db.CreateCommand("usp_DKNCabang_DELETE"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeCabang", SqlDbType.VarChar, rowID));
                    db.Commands[0].ExecuteNonQuery();
                }
                gridCabang.Rows.Remove(gridCabang.SelectedCells[0].OwningRow);
            }
        }



        
    }
}
