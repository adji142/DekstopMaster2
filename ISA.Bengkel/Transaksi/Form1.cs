using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Bengkel.Transaksi
{
    public partial class Form1 : ISA.Bengkel.BaseForm
    {
        DataTable dt = new DataTable();
        string NoPol, nmcust, KodeCust, spdm, kdspm, jnsspm, wrn, thn, kilometer, kluhan, noid,
            no_telp,id_member,alamat;

        public string nopol
        {
            get
            {
                return NoPol;
            }
        }
        public string namacust
        {
            get
            {
                return nmcust;
            }
        }
        public string kodecust
        {
            get
            {
                return KodeCust;
            }
        }
        public string Spm
        {
            get
            {
                return spdm;
            }
        }
        public string Kd_spm
        {
            get
            {
                return kdspm;
            }
        }
        public string Jns_spm
        {
            get
            {
                return jnsspm;
            }
        }
        public string Warna
        {
            get
            {
                return wrn;
            }
        }
        public string Tahun
        {
            get
            {
                return thn;
            }
        }
        public string Km
        {
            get
            {
                return kilometer;
            }
        }
        public string Keluhan
        {
            get
            {
                return kluhan;
            }
        }
        public string Noid
        {
            get
            {
                return noid;
            }
        }
        public string telpon
        {
            get
            {
                return no_telp;
            }
        }
        public string idmember
        {
            get
            {
                return id_member;
            }
        }
        public string Alamat
        {
            get
            {
                return alamat;
            }
        }


        public Form1()
        {
            InitializeComponent();
        }
        public Form1(string searchArg, DataTable dt)
        {
            InitializeComponent();
            textBox1.Text = searchArg;
            dt.DefaultView.Sort = "no_pol";
            dataGridView1.DataSource = dt.DefaultView;            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Focus();
            }

        }
        public void RefreshData()
        {
            
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_bklCust_Search"));
                db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, textBox1.Text));
                dt = db.Commands[0].ExecuteDataTable();
                dt.DefaultView.Sort = "no_pol";
                dataGridView1.DataSource = dt.DefaultView;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void ConfirmSelect()
        {
            if (dataGridView1.SelectedCells.Count == 1)
            {
                NoPol = dataGridView1.SelectedCells[0].OwningRow.Cells["no_pol"].Value.ToString();
                nmcust = dataGridView1.SelectedCells[0].OwningRow.Cells["NamaCust"].Value.ToString();
                KodeCust = dataGridView1.SelectedCells[0].OwningRow.Cells["Kd_cust"].Value.ToString();
                spdm = dataGridView1.SelectedCells[0].OwningRow.Cells["spm"].Value.ToString();
                kdspm = dataGridView1.SelectedCells[0].OwningRow.Cells["kd_spm"].Value.ToString();
                jnsspm = dataGridView1.SelectedCells[0].OwningRow.Cells["jns_spm"].Value.ToString();
                wrn =dataGridView1.SelectedCells[0].OwningRow.Cells["warna"].Value.ToString();
                thn = dataGridView1.SelectedCells[0].OwningRow.Cells["tahun"].Value.ToString();
                kilometer = dataGridView1.SelectedCells[0].OwningRow.Cells["km"].Value.ToString();
                kluhan = dataGridView1.SelectedCells[0].OwningRow.Cells["keluhan"].Value.ToString();
                noid = dataGridView1.SelectedCells[0].OwningRow.Cells["nomorid"].Value.ToString();
                no_telp = dataGridView1.SelectedCells[0].OwningRow.Cells["Telp"].Value.ToString();
                id_member = dataGridView1.SelectedCells[0].OwningRow.Cells["MemberId"].Value.ToString();
                alamat = dataGridView1.SelectedCells[0].OwningRow.Cells["Alamaat"].Value.ToString();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
