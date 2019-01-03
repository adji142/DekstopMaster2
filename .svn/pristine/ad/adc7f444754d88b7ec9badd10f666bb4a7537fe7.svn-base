using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Batch;

namespace ISA.Toko.Administrasi
{
    public partial class frmProcessLog : ISA.Controls.BaseForm
    {
        public frmProcessLog()
        {
            InitializeComponent();
        }

        private void frmProcessLog_Load(object sender, EventArgs e)
        {
            rdbProcess.FromDate = DateTime.Today;
            rdbProcess.ToDate = DateTime.Today;

            RefreshLogHeader();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshLogHeader();
        }

        private void dgvLog_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == RowID.Index && e.Value != null)
            {
                e.Value = e.Value.ToString().ToUpper();
            }
            else if (e.ColumnIndex == ProcessStatus.Index && e.Value != null)
            {
                LogTable.ProcessStatusEnum processStatus = (LogTable.ProcessStatusEnum)e.Value;

                e.Value = LogTable.StatusDesc(processStatus);

                switch (processStatus)
                {
                    case LogTable.ProcessStatusEnum.EndWarning:
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.BackColor = Color.Yellow;
                        break;
                    case LogTable.ProcessStatusEnum.EndError:
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = Color.Red;
                        break;
                    case LogTable.ProcessStatusEnum.EndFail:
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = Color.DarkRed;
                        break;
                    default:
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.BackColor = Color.White;
                        break;
                }
            }
        }

        private void dgvLogDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == ProcessDetailStatus.Index && e.Value != null)
            {
                LogTableDetail.ProcessStatusDetailEnum processStatus = (LogTableDetail.ProcessStatusDetailEnum)e.Value;

                e.Value = LogTableDetailsProcess.StatusDesc(processStatus);

                switch (processStatus)
                {
                    case LogTableDetail.ProcessStatusDetailEnum.Warning:
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.BackColor = Color.Yellow;
                        break;
                    case LogTableDetail.ProcessStatusDetailEnum.Error:
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = Color.Red;
                        break;
                    case LogTableDetail.ProcessStatusDetailEnum.Fail:
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = Color.DarkRed;
                        break;
                    default:
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.BackColor = Color.White;
                        break;
                }
            }
        }

        private void dgvLog_SelectionRowChanged(object sender, EventArgs e)
        {
            RefreshLogDetail();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshLogHeader()
        {
            DateTime fromDate = (DateTime)rdbProcess.FromDate.Value;
            DateTime toDate = (DateTime)rdbProcess.ToDate.Value;

            dgvLog.DataSource = LogTable.GetLog(fromDate, toDate);
        }

        private void RefreshLogDetail()
        {
            Guid processLogRowID = new Guid();

            if (dgvLog.SelectedCells.Count > 0)
                processLogRowID = (Guid)dgvLog.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            else
                processLogRowID = Guid.NewGuid();
            
            dgvLogDetail.DataSource = LogTableDetailsProcess.GetLogDetails(processLogRowID);
        }
    }
}
