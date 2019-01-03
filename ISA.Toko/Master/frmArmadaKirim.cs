using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Master
{
    public partial class frmArmadaKirim : ISA.Controls.BaseForm
    {
        public frmArmadaKirim()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmArmadaKirimUpdate frm = new frmArmadaKirimUpdate(this);
            frm.ShowDialog();
        }

        private void frmArmadaKirim_Load(object sender, EventArgs e)
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
                    db.Commands.Add(db.CreateCommand("usp_ArmadaKirim"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                gvArmadaKirim.DataSource = dt;
            }
            catch(Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvArmadaKirim.Rows.Count > 0)
            {
                try
                {
                    Guid _RowID = (Guid)gvArmadaKirim.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_ArmadaKirim"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                        db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.VarChar, "delete"));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    RefreshData();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
