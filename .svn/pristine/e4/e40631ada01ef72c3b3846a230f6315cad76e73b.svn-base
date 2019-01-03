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
    public partial class frmSalesArea : ISA.Trading.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        DataTable dt = new DataTable();


        public frmSalesArea(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        private void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_FixMasterArea_List"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                customGridView1.DataSource = dt.DefaultView;
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

        private void frmSalesArea_Load(object sender, EventArgs e)
        {
            customGridView1.AutoGenerateColumns = false;
            customGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            RefreshData();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMasterArea frmCaller = (frmMasterArea)this.Caller;
            frmCaller.RefreshHeader();
            this.Close();
        }

        private void txtKabupaten_TextChanged(object sender, EventArgs e)
        {
            if (txtKabupaten.Text.Trim().Length > 0)
            {
                string search = txtKabupaten.Text.Trim();
                for (int i = 0; i < (customGridView1.Rows.Count); i++)
                {

                    if (customGridView1.Rows[i].Cells["Kabupaten"].Value.ToString().StartsWith(search))
                    {
                        customGridView1.Rows[i].Cells["Kabupaten"].Selected = true;
                        return; // stop looping
                    }
                }
            }
        }

        private void SearchTypeKabupaten(object sender, KeyPressEventArgs e)
        {

            string search = txtKabupaten.Text.Trim();
            if (search.Length > 0)
            {
                for (int i = 0; i < (customGridView1.Rows.Count); i++)
                {
                    if (customGridView1.Rows[i].Cells["Kabupaten"].Value.ToString().StartsWith(search))
                    {
                        customGridView1.Rows[i].Cells["Kabupaten"].Selected = true;
                        return; // stop looping
                    }
                }
            }
        }

        private void txtWilayah_TextChanged(object sender, EventArgs e)
        {
            if (txtWilayah.Text.Trim().Length > 0)
            {
                string search = txtWilayah.Text.Trim();
                for (int i = 0; i < (customGridView1.Rows.Count); i++)
                {

                    if (customGridView1.Rows[i].Cells["Wilayah"].Value.ToString().StartsWith(search))
                    {
                        customGridView1.Rows[i].Cells["Wilayah"].Selected = true;
                        return; // stop looping
                    }
                }
            }
        }

        private void SearchTypeWilayah(object sender, KeyPressEventArgs e)
        {

            string search = txtWilayah.Text.Trim();
            if (search.Length > 0)
            {
                for (int i = 0; i < (customGridView1.Rows.Count); i++)
                {
                    if (customGridView1.Rows[i].Cells["Wilayah"].Value.ToString().StartsWith(search))
                    {
                        customGridView1.Rows[i].Cells["Wilayah"].Selected = true;
                        return; // stop looping
                    }
                }
            }
        }

        private void Simpan()
        {
            try
            {
                string _codearea = customGridView1.SelectedCells[0].OwningRow.Cells["CodeArea"].Value.ToString();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    MessageBox.Show(checkBox1.Text.ToString());
                    db.Commands.Add(db.CreateCommand("usp_FixEntrySalesArea_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@kd_sales", SqlDbType.VarChar, lookupSales1.SalesID));
                    db.Commands[0].Parameters.Add(new Parameter("@kab", SqlDbType.VarChar, txtKabupaten.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Wil", SqlDbType.VarChar, txtWilayah.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@mg1", SqlDbType.Bit, checkBox1.Checked));
                    db.Commands[0].Parameters.Add(new Parameter("@mg2", SqlDbType.Bit, checkBox2.Checked));
                    db.Commands[0].Parameters.Add(new Parameter("@mg3", SqlDbType.Bit, checkBox3.Checked));
                    db.Commands[0].Parameters.Add(new Parameter("@mg4", SqlDbType.Bit, checkBox4.Checked));
                    db.Commands[0].Parameters.Add(new Parameter("@mg5", SqlDbType.Bit, checkBox5.Checked));
                    db.Commands[0].Parameters.Add(new Parameter("@codearea", SqlDbType.VarChar, _codearea));
                    dt = db.Commands[0].ExecuteDataTable();
                    
                    if (checkBox1.Checked == true )
                    {
                        customGridView1.SelectedCells[0].OwningRow.Cells["mg1"].Value = 1;
                    }
                    else
                    {
                        customGridView1.SelectedCells[0].OwningRow.Cells["mg1"].Value = 0;
                    }
                    if (checkBox2.Checked == true)
                    {
                        customGridView1.SelectedCells[0].OwningRow.Cells["mg2"].Value = 1;
                    }
                    else
                    {
                        customGridView1.SelectedCells[0].OwningRow.Cells["mg2"].Value = 0;
                    }
                    if (checkBox3.Checked == true)
                    {
                        customGridView1.SelectedCells[0].OwningRow.Cells["mg3"].Value = 1;
                    }
                    else
                    {
                        customGridView1.SelectedCells[0].OwningRow.Cells["mg3"].Value = 0;
                    }
                    if (checkBox4.Checked == true)
                    {
                        customGridView1.SelectedCells[0].OwningRow.Cells["mg4"].Value = 1;
                    }
                    else
                    {
                        customGridView1.SelectedCells[0].OwningRow.Cells["mg4"].Value = 0;
                    }
                    if (checkBox5.Checked==true)
                    {
                        customGridView1.SelectedCells[0].OwningRow.Cells["mg5"].Value = 1;
                    }
                    else
                    {
                        customGridView1.SelectedCells[0].OwningRow.Cells["mg5"].Value = 0;
                    }
                    MessageBox.Show("Data Sales Berhasil Disimpan");
                }
            }
                
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;

                //customGridView1.DataSource = dt;
            }
        }

        private void cbSave_Click(object sender, EventArgs e)
        {
            Simpan();
            RefreshData();
        }
        
    }
}
