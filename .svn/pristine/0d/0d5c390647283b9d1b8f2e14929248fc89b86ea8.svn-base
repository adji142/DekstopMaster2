using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;

namespace ISA.Toko.VLapW
{
    public partial class frmRptLapBrgA : ISA.Toko.BaseForm
    {
        public frmRptLapBrgA()
        {
            InitializeComponent();
        }

        private void frmRptLapBrgA_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            rangeDateBox1.Focus();
            rdbToko.Checked = true;
            rdbBruto.Checked = true;
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {

            if (rdbToko.Checked==true)
            {
                CetakToko();
            }
            if (rdbType.Checked == true)
            {
                CetakTipe();
            }
            if (rdbBarang.Checked==true)
            {
                CetakBarang();
            }
            
        }

        private void CetakToko()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_VLapW_BrgA]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@Report", SqlDbType.Int, 1));
                    if (rdbNetto.Checked == true)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Netto", SqlDbType.Bit, 1));
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Netto", SqlDbType.Bit, 0));
                    }

                    if (txtKelompok.Text != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@KLP", SqlDbType.VarChar, txtKelompok.Text));
                    }

                    if (txtNamaStok.Text.Trim() != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@NamaBarang", SqlDbType.VarChar, txtNamaStok.Text));
                    }

                    if (lookupGudang.GudangID != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Gudang", SqlDbType.VarChar, lookupGudang.GudangID));
                    }

                    if (cabangComboBox1.CabangID != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar,cabangComboBox1.CabangID));
                    }


                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data...!");
                    return;
                }
                DisplayReport(dt);
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

        private void CetakBarang()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_VLapW_BrgA]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@Report", SqlDbType.Int, 2));
                    if (rdbNetto.Checked == true)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Netto", SqlDbType.Bit, 1));
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Netto", SqlDbType.Bit, 0));
                    }

                    if (txtKelompok.Text != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@KLP", SqlDbType.VarChar, txtKelompok.Text));
                    }

                    if (txtNamaStok.Text.Trim() != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@NamaBarang", SqlDbType.VarChar, txtNamaStok.Text));
                    }

                    if (lookupGudang.GudangID != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Gudang", SqlDbType.VarChar, lookupGudang.GudangID));
                    }

                    if (cabangComboBox1.CabangID != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, cabangComboBox1.CabangID));
                    }


                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data...!");
                    return;
                }
                DisplayReport(dt);
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

        private void CetakTipe()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_VLapW_BrgA]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@Report", SqlDbType.Int, 3));
                    if (rdbNetto.Checked == true)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Netto", SqlDbType.Bit, 1));
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Netto", SqlDbType.Bit, 0));
                    }

                    if (txtKelompok.Text != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@KLP", SqlDbType.VarChar, txtKelompok.Text));
                    }

                    if (txtNamaStok.Text.Trim() != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@NamaBarang", SqlDbType.VarChar, txtNamaStok.Text));
                    }

                    if (lookupGudang.GudangID != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Gudang", SqlDbType.VarChar, lookupGudang.GudangID));
                    }

                    if (cabangComboBox1.CabangID != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, cabangComboBox1.CabangID));
                    }


                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data...!");
                    return;
                }
                DisplayReport(dt);
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

        private void DisplayReport(DataTable dt)
        {
                     

            string periode;
            string option;
            string Init;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));
            if (rdbBruto.Checked==true)
            {
                option = "LAPORAN PENJUALAN -BRUTO  BARANG A Kelp." + txtKelompok.Text.Trim();
            }  else
            {
                option = "LAPORAN PENJUALAN -Netto  BARANG A Kelp." + txtKelompok.Text.Trim();
            }
           
            Init = GlobalVar.PerusahaanID;
            rptParams.Add(new ReportParameter("KLP", option));
            rptParams.Add(new ReportParameter("Init", Init));
            
            
            if (rdbToko.Checked==true)
            {
                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("VLapW.rptLapBrgA1.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
                ifrmReport.Show();
            }

            if (rdbType.Checked==true)
            {
                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("VLapW.rptLapBrgA3.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
                ifrmReport.Show();
            }

            if (rdbBarang.Checked == true)
            {
                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("VLapW.rptLapBrgA2.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
                ifrmReport.Show();
            }  
           

        }

        private void lookupGudang_Leave(object sender, EventArgs e)
        {
            if (lookupGudang.NamaGudang.Trim()=="")
            {
                lookupGudang.GudangID = "";
            }
        }
    }
}
