using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Finance.Register
{
    public partial class frmRegisterView : ISA.Finance.BaseForm
    {
        DataTable dt = new DataTable();

        public DataTable GetDT
        {
            get{
                
                return dt.DefaultView.ToTable();}
        }

        public frmRegisterView(Form caller_ , DataTable dt_)
        {
            this.Caller = caller_;
            dt = dt_.Copy();
            InitializeComponent();
        }


        public frmRegisterView( DataTable dt_)
        {
          
            dt = dt_.Copy();
            InitializeComponent();
        }
        public frmRegisterView()
        {
            InitializeComponent();
        }

        private void frmRegisterView_Load(object sender, EventArgs e)
        {
            customGridView1.DataSource = dt;

        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void customGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (customGridView1.SelectedCells.Count == 0)
                    {
                        return;
                    }
                    try
                    {
                        int i = 0;
                        int n = 0;
                        i = customGridView1.SelectedCells[0].RowIndex;
                        n = customGridView1.SelectedCells[0].ColumnIndex;
                        DataRowView dv = (DataRowView)customGridView1.SelectedCells[0].OwningRow.DataBoundItem;
                        DataRow dr = dv.Row;
                        dr.Delete();
                        dt.AcceptChanges();
                        customGridView1.Focus();
                        if (customGridView1.RowCount > 0)
                        {
                            if (i == 0)
                            {
                                customGridView1.CurrentCell = customGridView1.Rows[0].Cells[n];
                                customGridView1.RefreshEdit();
                            }
                            else
                            {
                                //customGridView1.CurrentCell = customGridView1.Rows[i - 1].Cells[n];
                                customGridView1.CurrentCell = customGridView1.Rows[i].Cells[n];
                                customGridView1.RefreshEdit();
                            }

                        }
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                    }




                    break;
            }

            if (e.KeyCode == Keys.Enter && customGridView1.RowCount>0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            if (customGridView1.RowCount>0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


    }
}
