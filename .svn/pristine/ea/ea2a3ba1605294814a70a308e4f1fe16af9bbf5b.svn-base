using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Common;
using ISA.DAL;
using System.Globalization;
using Microsoft.Reporting.WinForms;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;


namespace ISA.Trading.Penjualan
{
    public partial class frmACCOverdueBrowse : ISA.Controls.BaseForm
    {
        DataSet dsData = new DataSet();
        
        public frmACCOverdueBrowse()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmACCOverdueBrowse_Load(object sender, EventArgs e)
        {
            rdbTglDO.FromDate = GlobalVar.DateOfServer;
            rdbTglDO.ToDate = GlobalVar.DateOfServer;

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            string _kdgud = GlobalVar.Gudang;
            string _ckovd = string.Empty;

            //if (_kdgud != "2807")
            //{
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    DataTable dt = new DataTable();

                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_HistoryAcc_OVD_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, (DateTime)rdbTglDO.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, (DateTime)rdbTglDO.ToDate));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    dataGridDO.DataSource = dt;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
        //   }
        }

        private void dataGridDO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            Penjualan.frmLaporanAccOverdue ifrmChild = new frmLaporanAccOverdue();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }
    }
}
