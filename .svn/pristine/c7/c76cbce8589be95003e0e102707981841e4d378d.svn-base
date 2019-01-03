using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;

namespace ISA.Toko.Fixrute
{
    public partial class frmMasterOutletBaru : ISA.Toko.BaseForm
    {
        DataTable dtLoad, dtSyncData, dtFlag;

        public frmMasterOutletBaru()
        {
            InitializeComponent();
        }

        private void frmMasterOutletBaru_Load(object sender, EventArgs e)
        {
            Refreshdata();
            
        }

        public void Refreshdata()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_fixNewOutlet"));
                dtLoad = db.Commands[0].ExecuteDataTable();
                customGridView1.DataSource = dtLoad.DefaultView;

            }

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DataSet GetSyncData()
        {
            DataSet dsSynch = new DataSet();
            
            using (Database db = new Database())
            {


                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_FixNewOutlet_Upload"));
                dtSyncData = db.Commands[0].ExecuteDataTable();
                dtSyncData.TableName = "Fix_tokoob";
                if (dtSyncData.Rows.Count > 0)
                {
                    dsSynch.Tables.Add(dtSyncData);
                }
            }
            return dsSynch;
        }

        private void upload()
        {
            //this.Cursor = Cursors.WaitCursor;
            DataSet dsSynch = GetSyncData();
            if (dsSynch.Tables.Count > 0)
            {
                string pathString = @"c:\temp\upload";
                if (!System.IO.Directory.Exists(pathString))
                {
                    System.IO.Directory.CreateDirectory(pathString);
                }
                string Target = GlobalVar.Gudang;
                string fileOuput = pathString + "\\" + "MasterOutletBaru-" + DateTime.Now.ToString("yyyyMMdd hhmmss") + " " + Guid.NewGuid().ToString() + ".xml";
                dsSynch.WriteXml(fileOuput);
                MessageBox.Show(Messages.Confirm.UploadSuccessful + "\n" + fileOuput);
                //update synchflag
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("psp_FixNewOutletSyncFlag_Upload"));
                    db.Commands[0].ExecuteDataTable();
                }
            }
            Refreshdata();
            
        }
 

        private void customGridView1_DoubleClick(object sender, EventArgs e)
        {
            if ((bool)customGridView1.SelectedCells[0].OwningRow.Cells["SyncFlag"].Value == true)
            {
                Guid _row = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_FixNewOutlet_SyncFlag"));
                    db.Commands[0].Parameters.Add(new Parameter("@row", SqlDbType.UniqueIdentifier, _row));
                    dtFlag = db.Commands[0].ExecuteDataTable();
                }
                customGridView1.DataSource = dtFlag.DefaultView;
                if (dtFlag.Rows.Count > 1)
                {

                }
                Refreshdata();
            }
            else
            {
                Guid _row = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_FixNewOutlet_SyncFlag1"));
                    db.Commands[0].Parameters.Add(new Parameter("@row", SqlDbType.UniqueIdentifier, _row));
                    dtFlag = db.Commands[0].ExecuteDataTable();
                }
                customGridView1.DataSource = dtFlag.DefaultView;
                if (dtFlag.Rows.Count > 1)
                {

                }
                Refreshdata();
            }
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            upload();
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {

                Fixrute.frmMasterOutletBaruDownload ifrmChild = new Fixrute.frmMasterOutletBaruDownload();
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            Print();
        }



        private void cetak(DataTable dt)
        {
            try
            {

                this.Cursor = Cursors.WaitCursor;
                //string tt = string.Format("{0:dd-MMM-yyyy}", dt.Rows[0]["tgl_po"]);
                List<ReportParameter> rptParams = new List<ReportParameter>();
                //rptParams.Add(new ReportParameter("tgl_po", tt.Contains("1900") ? "" : tt));
                //rptParams.Add(new ReportParameter("no_po", dt.Rows[0]["no_po"].ToString()));
                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Fixrute.RptCetakOutletBaru.rdlc", rptParams, dt, "dsCetakOutletBaru_Data");
                ifrmReport.Text = "Data Pegawai";
                ifrmReport.Show();
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


        private void Print()
        {
                //Guid _RowID = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("rsp_CetakFixNewOutlet"));
                        //db.Commands[0].Parameters.Add(new Parameter("@row", SqlDbType.UniqueIdentifier, _RowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Data tidak ada");
                        return;
                    }
                    else
                    {
                        cetak(dt);
                    }
                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }
            
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            Fixrute.frmMasterOutletBaruUpdate ifrmChild = new frmMasterOutletBaruUpdate(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            Guid _row = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            Fixrute.frmMasterOutletBaruUpdate ifrmChild = new frmMasterOutletBaruUpdate(this, _row);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void hapusData()
        {

            if (customGridView1.SelectedCells.Count > 0)
            {
                Guid RowID_ = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                string NamaToko = customGridView1.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString();
                if (MessageBox.Show("Hapus Data : " + NamaToko + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_FixNewOutlet_Delete"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, RowID_));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        MessageBox.Show("Data telah dihapus");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            hapusData();
            Refreshdata();
        }

        private void customGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int i = 0;
            for (i = 0; i < dtLoad.Rows.Count; i++)
            {
                bool _flag;
                _flag = (bool)customGridView1.Rows[i].Cells["SyncFlag"].Value;

                if(_flag == false)
                {
                    customGridView1.Rows[i].Cells["NamaToko"].Style.BackColor = Color.GreenYellow;
                }
            }
           // customGridView1.DataSource = dtLoad.DefaultView;
        }
    }
}
