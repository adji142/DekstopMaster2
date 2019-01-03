using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ISA.Trading;
using ISA.Controls;
using ISA.DAL;
using ISA.Trading.Controls;
using System.Windows.Forms;

namespace ISA.Trading.CSM
{
    public partial class frmCustKontrak6Update : Form
    {
        enum enumFormMode { New, Update };
               
        string initCab = GlobalVar.CabangID;
        public frmCustKontrak6Update()
        {
            InitializeComponent();
        }
        
       
        private void frmCustomerIntiUpdate_Load(object sender, EventArgs e)
        {

        }

       // public event EventHandler TextChanged;


        //private void lookupToko_Validating(object sender, CancelEventArgs e)
        //{
        //    if (txtStatus.Text.Trim() == "" && lookupToko.NamaToko.Trim() != "")
        //    {
        //        lookupToko.SearchToko();
        //        lookupToko.Focus();
        //       // txtStatus = txtToko.
        //    }
        //}

        //private void lookupToko_ValueChanged (
        private void lookupToko_SelectData(object sender, EventArgs e)
        {
            try
            {
                DataTable dtToko = new DataTable();
                DataTable dtStsToko = new DataTable();
                object stsToko;

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetStatusToko"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglDO", SqlDbType.DateTime, DateTime.Now));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, lookupToko.KodeToko));
                    db.Commands[0].Parameters.Add(new Parameter("@c1", SqlDbType.VarChar, initCab));
                    stsToko = db.Commands[0].ExecuteScalar();

                    db.Commands.Add(db.CreateCommand("usp_StsToko_LIST"));
                    db.Commands[1].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, lookupToko.KodeToko));
                    dtStsToko = db.Commands[1].ExecuteDataTable();
                }

                string stsTk = stsToko.ToString();
                //if (stsTk == "" || stsTk == null)
                //{
                //    MessageBox.Show("Toko " + lookupToko.NamaToko.Trim() + " di " + initCab + "belum ada statusnya");
                //    txtStatus.Text = "";
                //    txtAlamatKirim.Text = "";
                //    txtKota.Text = "";
                //    return;
                //}

                //int jml = dtStsToko.Rows.Count;
                //for (int i = 0; i < jml; i++)
                //{
                //    string cabang1 = dtStsToko.Rows[i]["CabangID"].ToString();
                //    if (cabang1 != initCab)
                //    {
                //        MessageBox.Show("Toko ini bentrok dengan " + cabang1);
                //    }
                //}

                txtStatus.Text = stsToko.ToString();
                
                txtAlamatKirim.Text = lookupToko.Alamat;
                txtKota.Text = lookupToko.Kota;
                txtTokoID.Text = lookupToko.TokoID;
                
               

               // txtHariSales.Text = txtToko.HariSales.ToString();//Tools.GetHariSales(txtTransactionType.Text, txtToko.HariSales).ToString();
               // txthariKirim.Text = GetHariKirim().ToString();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void lookupToko_Load(object sender, EventArgs e)
        {

                }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtTelp_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void RadioMilik_CheckedChanged(object sender, EventArgs e)
        {
            
            tglRangeKontrak.Enabled = false;

        }

        private void RadioKontrak_CheckedChanged(object sender, EventArgs e)
        {
            tglMilik.Enabled = false;
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

       
        }

    }

