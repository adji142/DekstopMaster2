using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;

namespace ISA.Toko.Fixrute
{
    public partial class frmGetDataKunjungan : ISA.Toko.BaseForm
    {
        DataTable dt = new DataTable();
        string _KdSales, _filterHari, _kota, _daerah;
        DateTime _tgl1, _tgl2;

        public frmGetDataKunjungan(Form caller, string sales, string hari, string kota, string daerah, DateTime tglfrom, DateTime tglto)
        {
            this.Caller = caller;
            _KdSales = sales;
            _filterHari = hari;
            _kota = kota;
            _daerah = daerah;
            _tgl1 = tglfrom;
            _tgl2 = tglto;
            InitializeComponent();
            refreshData();
        }

        public frmGetDataKunjungan(Form caller, string tmt)
        {
            this.Caller=caller;
            dateTextBox1.Text = tmt;
        }

        public frmGetDataKunjungan()
        {
            InitializeComponent();
        }

        private void frmGetDataKunjungan_Load(object sender, EventArgs e)
        {
            cmdSave.Enabled = false;
            refreshData();
        }

        public void refreshData()
        {
            
            customGridView1.AutoGenerateColumns = false;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_fixKunjunganSales_List"));
                db.Commands[0].Parameters.Add(new Parameter("@kodesales", SqlDbType.VarChar, _KdSales));
                db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, _tgl1));
                db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, _tgl2));
                if (_kota == "")
                {
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, _kota));
                }
                if (_daerah == "")
                {
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, _daerah));
                }
                if (_filterHari == "ALL")
                {
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@hari", SqlDbType.VarChar, _filterHari));
                }
                dt = db.Commands[0].ExecuteDataTable();
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int nhari = 0;
                    
                    if (dt.Rows[i]["m1"] != "")
                    {
                        nhari = nhari + 1;
                    }
                    if (dt.Rows[i]["m2"] != "")
                    {
                        nhari = nhari + 1;
                    }
                    if (dt.Rows[i]["m3"] != "")
                    {
                        nhari = nhari + 1;
                    }
                    if (dt.Rows[i]["m4"] != "")
                    {
                        nhari = nhari + 1;
                    }

                    if (dt.Rows[i]["m5"] != "")
                    {
                        nhari = nhari + 1;
                    }

                    //nhari = (h1 + h2 + h3 + h4 + h5);
                    DataGridViewComboBoxColumn col = (DataGridViewComboBoxColumn)this.customGridView1.Columns[11];
                    if (nhari == 2)
                    {
                        col.ValueMember = "B";
                    }
                    if (nhari == 1)
                    {
                        col.ValueMember = "W";
                    }
                    else
                    {
                        col.ValueMember = "M";
                    }

                    dt.Rows[i]["jenis"] = col.ValueMember;
                    customGridView1.DataSource = dt;
                }
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void simpan()
        {
            int i = 0;
            for (i = 0; i < customGridView1.Rows.Count; i++)
            {
               using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        db.BeginTransaction();
                    db.Commands.Add(db.CreateCommand("usp_FixRuteSalesLink_Insert"));
                    db.Commands[0].Parameters.Add(new Parameter("@kd_sales", SqlDbType.VarChar, customGridView1.Rows[i].Cells["KodeSales"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@hari", SqlDbType.VarChar, customGridView1.Rows[i].Cells["Harii"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, dateTextBox1.DateValue));
                    //db.Commands[0].Parameters.Add(new Parameter("@tmt2", SqlDbType.DateTime, ));
                    if (customGridView1.Rows[i].Cells["Jenis"].Value.ToString()=="")
                    {
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@jenis", SqlDbType.VarChar, customGridView1.Rows[i].Cells["Jenis"].Value.ToString()));
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@namatoko", SqlDbType.VarChar, customGridView1.Rows[i].Cells["NamaToko"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, customGridView1.Rows[i].Cells["Alamat"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, customGridView1.Rows[i].Cells["Kota"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, customGridView1.Rows[i].Cells["Daerah"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@kecamatan", SqlDbType.VarChar, customGridView1.Rows[i].Cells["Kecamatan"].Value.ToString()));
                    if (customGridView1.Rows[i].Cells["Jenis"].Value.ToString() == "B")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@mg1", SqlDbType.Bit, 1));
                        db.Commands[0].Parameters.Add(new Parameter("@mg2", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@mg3", SqlDbType.Bit, 1));
                        db.Commands[0].Parameters.Add(new Parameter("@mg4", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@mg5", SqlDbType.Bit, 1));
                    }
                    if (customGridView1.Rows[i].Cells["Jenis"].Value.ToString() == "W")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@mg1", SqlDbType.Bit, 1));
                        db.Commands[0].Parameters.Add(new Parameter("@mg2", SqlDbType.Bit, 1));
                        db.Commands[0].Parameters.Add(new Parameter("@mg3", SqlDbType.Bit, 1));
                        db.Commands[0].Parameters.Add(new Parameter("@mg4", SqlDbType.Bit, 1));
                        db.Commands[0].Parameters.Add(new Parameter("@mg5", SqlDbType.Bit, 1));
                    }
                    if (customGridView1.Rows[i].Cells["Jenis"].Value.ToString() == "M")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@mg1", SqlDbType.Bit, 1));
                        db.Commands[0].Parameters.Add(new Parameter("@mg2", SqlDbType.Bit, 1));
                        db.Commands[0].Parameters.Add(new Parameter("@mg3", SqlDbType.Bit, 1));
                        db.Commands[0].Parameters.Add(new Parameter("@mg4", SqlDbType.Bit, 1));
                        db.Commands[0].Parameters.Add(new Parameter("@mg5", SqlDbType.Bit, 1));
                    }
                    db.Commands[0].ExecuteNonQuery();
                    db.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        db.RollbackTransaction();
                        MessageBox.Show("Gagal Menyimpan Data");
                    }
                }
            }
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah data ini mau disimpan...?? ", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                simpan();
                frmFixRuteSalesman frmCaller = (frmFixRuteSalesman)this.Caller;
                frmCaller.RefreshRencana();
                this.Close();
            }
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
                frmReportViewer ifrmReport = new frmReportViewer("Fixrute.RptCetakGetDataKunjungan.rdlc", rptParams, dt, "dzCetakGetDataKunjungan_Data");
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

        private void print()
        {
            DataTable dt2 = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_fixKunjunganSales_List"));
                db.Commands[0].Parameters.Add(new Parameter("@kodesales", SqlDbType.VarChar, _KdSales));
                db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, _tgl1));
                db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, _tgl2));
                if (_kota == "")
                {
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, _kota));
                }
                if (_daerah == "")
                {
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, _daerah));
                }
                if (_filterHari == "ALL")
                {
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@hari", SqlDbType.VarChar, _filterHari));
                }
                dt2 = db.Commands[0].ExecuteDataTable();
                customGridView1.DataSource = dt2;

                if (dt2.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada");
                    return;
                }
                else
                {
                    cetak(dt);
                }
            }
        }

        public void cmdPrint_Click(object sender, EventArgs e)
        {
            print();
        }

        private void dateTextBox1_TextChanged(object sender, EventArgs e)
        {
            cmdSave.Enabled = true;
        }

    }
}
