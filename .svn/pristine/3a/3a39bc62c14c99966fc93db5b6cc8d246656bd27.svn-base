using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Fixrute
{
    public partial class frmMasterArea : ISA.Toko.BaseForm
    {
        DataTable dt = new DataTable();
        string sort = "";
        Boolean Finish;

        public frmMasterArea()
        {
            InitializeComponent();
        }

        

        public void RefreshHeader()
        {
            try
            {
                int i = 0;
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_FixMasterArea_List"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (comboBox1.SelectedValue.ToString() == "Wilayah")
                {
                    sort = "Wilayah, RowNo";
                }
                else
                {
                    sort = "RowNo";
                }
                dt.DefaultView.Sort = sort;
                customGridView1.DataSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                Finish = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length > 0)
            {
                string search = textBox1.Text.Trim();
                for (int i = 0; i < (customGridView1.Rows.Count); i++)
                {
                    string col = "";
                    switch (comboBox1.Text)
                    {
                        case "RowNo":
                            col = "RowNo";
                            break;
                        case "Wilayah":
                            col = "Wilayah";
                            break;
                        case "Kabupaten":
                            col = "Kabupaten";
                            break;
                        case "CodeWil":
                            col = "CodeWil";
                            break;

                    }
                    if (customGridView1.Rows[i].Cells[col].Value.ToString().StartsWith(search))
                    {
                        customGridView1.Rows[i].Cells[col].Selected = true;
                        return; // stop looping
                    }
                }
            }
        }

        private void SearchType(object sender, KeyPressEventArgs e)
        {


            string search = textBox1.Text.Trim();
            if (search.Length > 0)
            {
                for (int i = 0; i < (customGridView1.Rows.Count); i++)
                {
                    string col = "";
                    switch (comboBox1.Text)
                    {
                        case "RowNo":
                            col = "RowNo";
                            break;
                        case "Wilayah":
                            col = "Wilayah";
                            break;
                        case "Kabupaten":
                            col = "Kabupaten";
                            break;
                        case "Code Wilayah":
                            col = "CodeWil";
                            break;
                    }
                    if (customGridView1.Rows[i].Cells[col].Value.ToString().StartsWith(search))
                    {
                        customGridView1.Rows[i].Cells[col].Selected = true;
                        return; // stop looping
                    }
                }
            }

        }

        private void frmMasterArea_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            DataTable dtTemp = new DataTable();
            DataColumn dc = new DataColumn("TR");
            dtTemp.Columns.Add(dc);
            dtTemp.Rows.Add("RowNo");
            dtTemp.Rows.Add("Wilayah");
            dtTemp.Rows.Add("Kabupaten");
            dtTemp.Rows.Add("CodeWil");

            dtTemp.DefaultView.Sort = "TR DESC";

            comboBox1.DataSource = dtTemp.DefaultView;
            comboBox1.DisplayMember = "TR";
            comboBox1.ValueMember = "TR";
            Finish = false;

            customGridView1.AutoGenerateColumns = false;
            customGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            RefreshHeader();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdGetSalesman_Click(object sender, EventArgs e)
        {
            Fixrute.frmSalesArea ifrmChild = new frmSalesArea(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }


    }
}
