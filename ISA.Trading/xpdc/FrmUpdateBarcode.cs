using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;


namespace ISA.Trading.xpdc
{
    public partial class FrmUpdateBarcode : ISA.Trading.BaseForm
    {

        public FrmUpdateBarcode()
        {
            InitializeComponent();
        }

        private void FrmUpdateBarcode_Load(object sender, EventArgs e)
        {
            int ndays = DateTime.Today.Day - 1;
            rangeDateBox1.FromDate = DateTime.Today.AddDays(-ndays);
            rangeDateBox1.ToDate = DateTime.Now;
            rangeDateBox1.Focus();
            RefreshData();
           
        }


        public void RefreshData()
        {
            try
            {
                DateTime _fromDate = Convert.ToDateTime(rangeDateBox1.FromDate);
                DateTime _toDate = Convert.ToDateTime(rangeDateBox1.ToDate);

                this.Cursor = Cursors.WaitCursor;
                DataTable dtHeader = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Xpdc_CekBarcode"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _toDate));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                }
                DataGridViewXpdcDetail.DataSource = dtHeader;
//                dataGridxpdc.DataSource = dtHeader;

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



        private void commandButton2_Click(object sender, EventArgs e)
        {
            RefreshData();
        }



        private void CmdEdit_Click(object sender, EventArgs e)
        {
            if (DataGridViewXpdcDetail.SelectedCells.Count > 0)
            {
                try
                {
                    Guid rowID = (Guid)DataGridViewXpdcDetail.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    xpdc.FrmUpdateBarcode_Update ifrmChild = new xpdc.FrmUpdateBarcode_Update(this, rowID);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();

                    this.Close();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void DataGridViewXpdcDetail_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    {
                        CmdEdit_Click(sender, e);
                    }
                    break;
            }
        }



    }
}
