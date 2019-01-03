using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Fixrute
{
    public partial class frmMonitoringFixrute : ISA.Trading.BaseForm
    {
        DataTable dtLoad, dtSearch;
        public frmMonitoringFixrute()
        {
            InitializeComponent();
        }

        private void frmMonitoringFixrute_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " dd,MMMM,yyyy";
            dateTimePicker1.ShowUpDown = true;

            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = " dd,MMMM,yyyy";
            dateTimePicker2.ShowUpDown = true;
            RefreshData();
        }

        public void RefreshData()
        {
            DateTime _tanggal = DateTime.Today;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_fixMonitoring_List"));
                db.Commands[0].Parameters.Add(new Parameter("@tanggal", SqlDbType.DateTime, _tanggal));
                dtLoad = db.Commands[0].ExecuteDataTable();
                customGridView1.DataSource = dtLoad.DefaultView;
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void search()
        {
            DateTime _from = dateTimePicker1.Value;
            DateTime _to = dateTimePicker2.Value;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_fixMonitoring_Search"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _from));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _to));
                dtSearch = db.Commands[0].ExecuteDataTable();
                customGridView1.DataSource = dtSearch.DefaultView;
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void customGridView1_SelectionRowChanged(object sender, EventArgs e)
        {
            label1.Text = customGridView1.SelectedCells[0].OwningRow.Cells["Alamat"].Value.ToString();
        }

        private void simpan()
        {
            int _sku = Convert.ToInt32(customGridView1.SelectedCells[0].OwningRow.Cells["SKU"].Value);
            int _order = Convert.ToInt32(customGridView1.SelectedCells[0].OwningRow.Cells["Rp_Order"].Value);
            try
            {
                
                Guid _RowID = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                string _ket = customGridView1.SelectedCells[0].OwningRow.Cells["Keterangan"].Value.ToString();
                string _catatan = customGridView1.SelectedCells[0].OwningRow.Cells["Catatan"].Value.ToString();
                
                
                
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_fixMonitoring_Update"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.VarChar, _RowID.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@rporder", SqlDbType.NChar, _order));
                    db.Commands[0].Parameters.Add(new Parameter("@sku", SqlDbType.NChar, _sku));
                    db.Commands[0].Parameters.Add(new Parameter("@ket", SqlDbType.VarChar, _ket));
                    db.Commands[0].Parameters.Add(new Parameter("@cat", SqlDbType.VarChar, _catatan));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    dt = db.Commands[0].ExecuteDataTable();
                    MessageBox.Show("Data Berhasil Di simpan");
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cbSave_Click(object sender, EventArgs e)
        {
            string _namaToko = customGridView1.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString();
            if (MessageBox.Show("Simpan Data : " + _namaToko + " ?", "SIMPAN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                simpan();
                RefreshData();
                this.Close();
            }
        }
        
    }
}
