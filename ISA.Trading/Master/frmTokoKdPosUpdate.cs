using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Master
{
    public partial class frmTokoKdPosUpdate : ISA.Trading.BaseForm
    {
        public string KodePos
        {
            get;
            set;
        }

        public frmTokoKdPosUpdate( string KodePos_)
        {
           // this.Caller = caller_;
            KodePos = KodePos_;
            InitializeComponent();
        }
        public frmTokoKdPosUpdate()
        {
            InitializeComponent();
        }

        private void frmTokoKdPosUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_KodePos_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dt.Rows.Add("");
                dt.DefaultView.Sort = "KodePos ASC";
                this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "KodePos";
                comboBox1.ValueMember = "KodePos";
                comboBox1.SelectedValue = KodePos;
                comboBox1.Focus();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
           
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            KodePos = comboBox1.SelectedValue.ToString();
        }
    }
}
