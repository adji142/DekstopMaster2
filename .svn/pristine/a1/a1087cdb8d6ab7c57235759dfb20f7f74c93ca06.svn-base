using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance.GL
{
    public partial class frmPerkiraanKoneksiArusKasBrowse : ISA.Finance.BaseForm
    {
        public frmPerkiraanKoneksiArusKasBrowse()
        {
            InitializeComponent();
        }

        private void RefreshKode()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksiKode_LIST"));
                dt = db.Commands[0].ExecuteDataTable();
            }
            dt.DefaultView.Sort = "Kode";
            gridKode.DataSource = dt.DefaultView;
        }

        private void RefreshHeader()
        {
            if (gridKode.SelectedCells.Count > 0)
            {
                string kode = gridKode.SelectedCells[0].OwningRow.Cells["kKode"].Value.ToString();
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksi_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@kode", SqlDbType.VarChar, kode));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dt.DefaultView.Sort = "Kode";
                gridHeader.DataSource = dt.DefaultView;
            }
        }

        private void RefreshDetail()
        {
            if (gridKode.SelectedCells.Count > 0 && gridHeader.SelectedCells.Count > 0)
            {
                Guid headerID = new Guid(gridHeader.SelectedCells[0].OwningRow.Cells["hRowID"].Value.ToString() );
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksiDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, headerID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dt.DefaultView.Sort = "NoPerkiraan";
                gridDetail.DataSource = dt.DefaultView;
            }
        }

        private void frmPerkiraanKoneksiArusKasBrowse_Load(object sender, EventArgs e)
        {
            RefreshKode();
            RefreshHeader();
            RefreshDetail();
        }

        private void gridKode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridKode.SelectedCells.Count > 0)
            {
                RefreshHeader();
            }
        }

        private void gridHeader_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridHeader.SelectedCells.Count > 0)
            {
                RefreshDetail();
            }
        }

        private void gridKode_SelectionChanged(object sender, EventArgs e)
        {
            if (gridKode.SelectedCells.Count > 0)
            {
                RefreshHeader();
            }
        }

        private void gridHeader_SelectionChanged(object sender, EventArgs e)
        {
            if (gridHeader.SelectedCells.Count > 0)
            {
                RefreshDetail();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (gridDetail.SelectedCells.Count > 0)
            {
                Guid rowID = new Guid( gridDetail.SelectedCells[0].OwningRow.Cells["dRowID"].Value.ToString());
                string noPerk = gridDetail.SelectedCells[0].OwningRow.Cells["dNoPerkiraan"].Value.ToString();
                string ket = gridDetail.SelectedCells[0].OwningRow.Cells["dUraian"].Value.ToString();
                GL.frmPerkiraanKoneksiArusKasUpdate ifrmChild = new GL.frmPerkiraanKoneksiArusKasUpdate(noPerk,ket);
                ifrmChild.ShowDialog();
                if (ifrmChild.DialogResult == DialogResult.OK)
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksiDetail_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, ifrmChild.Keterangan));
                        db.Commands[0].ExecuteNonQuery();                        
                    }
                    gridDetail.SelectedCells[0].OwningRow.Cells["dUraian"].Value = ifrmChild.Keterangan;
                    MessageBox.Show(ISA.Common.Messages.Confirm.UpdateSuccess);
                }

            }
        }

    }
}
