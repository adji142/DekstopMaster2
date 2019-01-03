using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Trading.CommunicatorISA
{
    public partial class frmDataViewer : ISA.Trading.BaseForm
    {
        DataSet ds = new DataSet();
        public frmDataViewer()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectFile()
        {            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ds.ReadXml (openFileDialog1.FileName);
            }            
        }

        private void frmDataViewer_Load(object sender, EventArgs e)
        {
            SelectFile();
            foreach (DataTable dt in ds.Tables)
            {
                cboTableName.Items.Add(dt.TableName);
            }
            if (cboTableName.Items.Count > 0)
            {
                cboTableName.SelectedIndex = 0;
            }
        }

        private void cboTableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            customGridView1.DataSource = ds.Tables[cboTableName.SelectedItem.ToString()];
        }

        private void customGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataRowView dr =  (DataRowView) customGridView1.Rows[e.RowIndex].DataBoundItem;
                if (dr.Row.Table.Columns.Contains("XmlData"))
                {
                    if (!(dr["XmlData"] is DBNull) && dr["XmlData"].ToString() != "")
                    {
                        CommunicatorISA.frmDataViewerDetail ifrmChild = new CommunicatorISA.frmDataViewerDetail(dr["XmlData"].ToString());
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.ShowDialog();
                    }
                }
            }
        }
    }
}
