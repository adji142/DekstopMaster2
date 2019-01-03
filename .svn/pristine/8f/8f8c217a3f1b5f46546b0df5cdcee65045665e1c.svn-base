using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Communicator
{
    public partial class frmTosFormDownload : ISA.Controls.BaseForm
    {
        public frmTosFormDownload()
        {
            InitializeComponent();
        }

        private void cmb_PULL_Click(object sender, EventArgs e)
        {
            this.PullFireBase_v2();
        }

        private void PullFireBase_v2()
        {
            try
            {
                this.cmb_PULL.Enabled = false;
                this.lblStatusDownload.Visible = true;
                this.lblStatusDownload.Text = "Proses Download";
                this.Cursor = Cursors.WaitCursor;

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_TosFormToko_INSERT_v2"));
                    db.Commands[0].Parameters.Add(new Parameter("@IsUser", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.lblStatusDownload.Text = "Selesai";
                this.cmb_PULL.Enabled = true;
            }
        }

        private void frmTosFormDownload_Load(object sender, EventArgs e)
        {
            rdTanggal.FromDate = GlobalVar.DateOfServer.AddDays(-1 * (GlobalVar.DateOfServer.AddDays(-1).Day));
            rdTanggal.ToDate = GlobalVar.DateOfServer;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RetreiveDataTosForm();
        }

        private void RetreiveDataTosForm()
        {
            try
            {
                DataTable tblTos = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_TosFormToko_LIST_Filter_Tanggal"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rdTanggal.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rdTanggal.ToDate));
                    tblTos = db.Commands[0].ExecuteDataTable();
                }
                this.dgTos.DataSource = tblTos;
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
    }
}
