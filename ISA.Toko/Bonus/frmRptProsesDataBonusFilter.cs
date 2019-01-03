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
using System.Data.SqlTypes;

namespace ISA.Toko.Bonus
{
    public partial class frmRptProsesDataBonusFilter : ISA.Toko.BaseForm
    {
        DataSet ds = new DataSet();

        public frmRptProsesDataBonusFilter()
        {
            InitializeComponent();
        }

        private void frmProsesDataBonusFilter_Load(object sender, EventArgs e)
        {
            this.Title = "Proses Data Bonus";
            this.Text = "Bonus";
            rgbPeriode.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbPeriode.ToDate = ((DateTime)rgbPeriode.FromDate).AddMonths(1).AddDays(-1);
            txtInitPrs.Text = GlobalVar.PerusahaanID;
            LoadGroupNamaStokComboBox();
        }

        private void LoadGroupNamaStokComboBox()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_StokGroup_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dt.Rows.Add("");
                dt.DefaultView.Sort = "NamaGroup";
                cboGroupBrg.DataSource = dt;
                cboGroupBrg.DisplayMember = "NamaGroup";
                cboGroupBrg.ValueMember = "StokGroupID";
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

        private bool ValidateInput()
        {
            bool valid = true;

            if (rgbPeriode.FromDate.ToString() == "" || rgbPeriode.ToDate.ToString() == "")
            {
                errorProvider1.SetError(rgbPeriode, "Periode masih kosong");
                valid = false;
            }
            return valid;
        }

        private void cmdYES_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                string tipeLap = "N";
                if (rdoBrutto.Checked)
                {
                    tipeLap = "B";
                }

                this.Cursor = Cursors.WaitCursor;
                ds = new DataSet();
                using (Database db = new Database())
                {
                    //db.Commands.Add(db.CreateCommand("[rsp_Bonus_ProsesDataBonus]"));
                    db.Commands.Add(db.CreateCommand("[rsp_Bonus_ProsesDataBonus_ISA]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbPeriode.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbPeriode.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@tipeLap", SqlDbType.VarChar, tipeLap));

                    if (cboGroupBrg.SelectedValue.ToString() != "")
                        db.Commands[0].Parameters.Add(new Parameter("@stokGroupID", SqlDbType.VarChar, cboGroupBrg.SelectedValue.ToString()));
                    if (lookupSales.NamaSales.Trim() != "")
                        db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, lookupSales.SalesID));
                    if (lookupToko.NamaToko.Trim() != "")
                        db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, lookupToko.KodeToko));
                    if (txtInitPrs.Text.Trim() != "")
                        db.Commands[0].Parameters.Add(new Parameter("@initPrs", SqlDbType.VarChar, txtInitPrs.Text));

                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.....");
                }
                else
                {
                    DisplayReport(ds);
                    if (MessageBox.Show("Update data pengajuan", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        UpdateTable();
                    }
                }                
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

        private void DisplayReport(DataSet ds)
        {
            //construct parameter
            string sales = "Semua";
            if (lookupSales.NamaSales.Trim() != "")
                sales = lookupSales.SalesID;
            string toko = "Semua";
            if (lookupToko.NamaToko.Trim() != "")
                toko = lookupToko.NamaToko;
            string bruttoNetto = "Netto";
            if (rdoBrutto.Checked)
                bruttoNetto = "Brutto";
            string groupBrg = "Semua";
            if (cboGroupBrg.Text != "")
                groupBrg = cboGroupBrg.Text;

            double dQtyTransaksi = 0.0, dNilaiTransaksi = 0.0, dQtyBonus = 0.0, dNilaiBonus = 0.0;

            for (int i = 0; i < ds.Tables.Count; i++)
            {
                if (ds.Tables[i].Rows.Count > 0)
                {
                    string
                        qtyT = ds.Tables[i].Compute("SUM(QtyTransaksi)", "").ToString(),
                        nilaiT = ds.Tables[i].Compute("SUM(NilaiTransaksi)", "").ToString(),
                        qtyB = ds.Tables[i].Compute("SUM(QtyBonus)", "").ToString(),
                        nilaiB = ds.Tables[i].Compute("SUM(NilaiBonus)", "").ToString();
                    dQtyTransaksi = dQtyTransaksi + double.Parse(qtyT);
                    dNilaiTransaksi = dNilaiTransaksi + double.Parse(nilaiT);
                    dQtyBonus = dQtyBonus + double.Parse(qtyB);
                    dNilaiBonus = dNilaiBonus + double.Parse(nilaiB);
                }
            }

            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rgbPeriode.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rgbPeriode.ToDate).ToString("dd/MM/yyyy"));
            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Sales", sales));
            rptParams.Add(new ReportParameter("Toko", toko));
            rptParams.Add(new ReportParameter("GroupBarang", groupBrg));
            rptParams.Add(new ReportParameter("BruttoNetto", bruttoNetto));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("sumQtyTransaksi", dQtyTransaksi.ToString()));
            rptParams.Add(new ReportParameter("sumNilaiTransaksi", dNilaiTransaksi.ToString()));
            rptParams.Add(new ReportParameter("sumQtyBonus", dQtyBonus.ToString()));
            rptParams.Add(new ReportParameter("sumNilaiBonus", dNilaiBonus.ToString()));

            List<DataTable> rptDt = new List<DataTable>();
            rptDt.Add(ds.Tables[0]);

            List<string> rptDs = new List<string>();
            rptDs.Add("dsNotaPenjualan_Data");

            if (ds.Tables.Count == 3)
            {
                rptDt.Add(ds.Tables[1]);
                rptDt.Add(ds.Tables[2]);
                rptDs.Add("dsNotaPenjualan_Data2");
                rptDs.Add("dsNotaPenjualan_Data3");
            }
            else
            {
                DataTable dt = new DataTable();
                rptDt.Add(dt);
                rptDt.Add(dt);
                rptDs.Add("dsNotaPenjualan_Data2");
                rptDs.Add("dsNotaPenjualan_Data3");
            }

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Bonus.rptPerincianPerhitunganBonus.rdlc", rptParams, rptDt, rptDs);
            ifrmReport.Show();
        }

        private void UpdateTable()
        {
            // Update table ACCBonusSales (Header and detail)

            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DateTime tglACC = DateTime.Now;
                    string noACC = SecurityManager.UserInitial.ToUpper() + "-" + tglACC.ToString("ddMMyy");
                    double rpSJ = 0;

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (i==0 || (ds.Tables[0].Rows[i]["NotaID"] != ds.Tables[0].Rows[i-1]["NotaID"]))
                        {
                            //DataView dv = ds.Tables[0].DefaultView;
                            DataView dv = new DataView(ds.Tables[0]);
                            Guid notaID = (Guid)ds.Tables[0].Rows[i]["NotaID"];
                            dv.RowFilter = "NotaID = '" + notaID.ToString() + "'";                               

                            string sRPSJ = ds.Tables[0].Compute("SUM(NilaiBonus)", dv.RowFilter).ToString();
                            rpSJ = double.Parse(sRPSJ);
                        }

                        db.Commands.Add(db.CreateCommand("usp_ACCBonusSales_UPDATE"));
                        db.Commands[i].Parameters.Add(new Parameter("@notaID", SqlDbType.UniqueIdentifier, ds.Tables[0].Rows[i]["NotaID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@notaRecID", SqlDbType.VarChar, ds.Tables[0].Rows[i]["NotaRecID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@notaDetailID", SqlDbType.UniqueIdentifier, ds.Tables[0].Rows[i]["NotaDetailID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@notaDetailRecID", SqlDbType.VarChar, ds.Tables[0].Rows[i]["NotaDetailRecID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                        db.Commands[i].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, ds.Tables[0].Rows[i]["KodeSales"]));
                        db.Commands[i].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, ds.Tables[0].Rows[i]["KodeToko"]));
                        db.Commands[i].Parameters.Add(new Parameter("@tglJatuhTempo", SqlDbType.DateTime, ds.Tables[0].Rows[i]["TglJatuhTempo"]));
                        db.Commands[i].Parameters.Add(new Parameter("@rpSuratJalan", SqlDbType.Money, rpSJ));
                        db.Commands[i].Parameters.Add(new Parameter("@rpSisa", SqlDbType.Money, ds.Tables[0].Rows[i]["RpSisa"]));
                        db.Commands[i].Parameters.Add(new Parameter("@rpGiro", SqlDbType.Money, ds.Tables[0].Rows[i]["RpGiro"]));
                        db.Commands[i].Parameters.Add(new Parameter("@rpRetur", SqlDbType.Money, ds.Tables[0].Rows[i]["RpRetur"]));
                        db.Commands[i].Parameters.Add(new Parameter("@rpPotongan", SqlDbType.Money, ds.Tables[0].Rows[i]["RpPot"]));
                        db.Commands[i].Parameters.Add(new Parameter("@rpLain", SqlDbType.Money, ds.Tables[0].Rows[i]["RpLain"]));
                        db.Commands[i].Parameters.Add(new Parameter("@rpTotal", SqlDbType.Money, ds.Tables[0].Rows[i]["RpTotal"]));
                        db.Commands[i].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, noACC));
                        db.Commands[i].Parameters.Add(new Parameter("@tglACC", SqlDbType.DateTime, tglACC));
                        db.Commands[i].Parameters.Add(new Parameter("@isChecked", SqlDbType.Bit, false));
                        db.Commands[i].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, "J"));
                        db.Commands[i].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, ds.Tables[0].Rows[i]["BarangID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@qtySuratJalan", SqlDbType.Int, ds.Tables[0].Rows[i]["QtyTransaksi"]));
                        db.Commands[i].Parameters.Add(new Parameter("@hrgNetto", SqlDbType.Money, ds.Tables[0].Rows[i]["NilaiTransaksi"]));
                        db.Commands[i].Parameters.Add(new Parameter("@cekHrg", SqlDbType.Bit, ds.Tables[0].Rows[i]["CekHrg"]));
                        db.Commands[i].Parameters.Add(new Parameter("@tglLast", SqlDbType.DateTime, ds.Tables[0].Rows[i]["TglLast"]));
                        db.Commands[i].Parameters.Add(new Parameter("@tglJTBonus", SqlDbType.DateTime, ds.Tables[0].Rows[i]["TglJTBonus"]));
                        db.Commands[i].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    }

                    if (ds.Tables.Count > 1)
                    {
                        int c = db.Commands.Count; // Jumlah command sebelumnya
                        for (int j = 0; j < ds.Tables[1].Rows.Count; j++)
                        {
                            string qtyT = Tools.isNull(ds.Tables[1].Rows[j]["QtyTransaksi"], "0").ToString();
                            string nilaiT = Tools.isNull(ds.Tables[1].Rows[j]["NilaiTransaksi"], "0").ToString();

                            db.Commands.Add(db.CreateCommand("usp_ACCBonusSales_UPDATE"));
                            db.Commands[j+c].Parameters.Add(new Parameter("@notaID", SqlDbType.UniqueIdentifier, ds.Tables[1].Rows[j]["NotaID"]));
                            db.Commands[j+c].Parameters.Add(new Parameter("@notaRecID", SqlDbType.VarChar, ds.Tables[1].Rows[j]["NotaRecID"]));
                            db.Commands[j+c].Parameters.Add(new Parameter("@notaDetailID", SqlDbType.UniqueIdentifier, ds.Tables[1].Rows[j]["NotaDetailID"]));
                            db.Commands[j+c].Parameters.Add(new Parameter("@notaDetailRecID", SqlDbType.VarChar, ds.Tables[1].Rows[j]["NotaDetailRecID"]));
                            db.Commands[j+c].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                            db.Commands[j+c].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, ds.Tables[1].Rows[j]["KodeSales"]));
                            db.Commands[j+c].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, ds.Tables[1].Rows[j]["KodeToko"]));
                            db.Commands[j+c].Parameters.Add(new Parameter("@tglJatuhTempo", SqlDbType.DateTime, SqlDateTime.Null));
                            db.Commands[j+c].Parameters.Add(new Parameter("@rpSuratJalan", SqlDbType.Money, double.Parse(nilaiT) * -1));
                            db.Commands[j+c].Parameters.Add(new Parameter("@rpSisa", SqlDbType.Money, 0.0));
                            db.Commands[j+c].Parameters.Add(new Parameter("@rpGiro", SqlDbType.Money, 0.0));
                            db.Commands[j+c].Parameters.Add(new Parameter("@rpRetur", SqlDbType.Money, 0.0));
                            db.Commands[j+c].Parameters.Add(new Parameter("@rpPotongan", SqlDbType.Money, 0.0));
                            db.Commands[j+c].Parameters.Add(new Parameter("@rpLain", SqlDbType.Money, 0.0));
                            db.Commands[j+c].Parameters.Add(new Parameter("@rpTotal", SqlDbType.Money, 0.0));
                            db.Commands[j+c].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, noACC));
                            db.Commands[j+c].Parameters.Add(new Parameter("@tglACC", SqlDbType.DateTime, tglACC));
                            db.Commands[j+c].Parameters.Add(new Parameter("@isChecked", SqlDbType.Bit, false));
                            db.Commands[j+c].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, "R"));
                            db.Commands[j+c].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, ds.Tables[1].Rows[j]["BarangID"]));
                            db.Commands[j+c].Parameters.Add(new Parameter("@qtySuratJalan", SqlDbType.Int, int.Parse(qtyT) * -1));
                            db.Commands[j+c].Parameters.Add(new Parameter("@hrgNetto", SqlDbType.Money, double.Parse(nilaiT) * -1));
                            db.Commands[j+c].Parameters.Add(new Parameter("@cekHrg", SqlDbType.Bit, false));
                            db.Commands[j+c].Parameters.Add(new Parameter("@tglLast", SqlDbType.DateTime, SqlDateTime.Null));
                            db.Commands[j+c].Parameters.Add(new Parameter("@tglJTBonus", SqlDbType.DateTime, SqlDateTime.Null));
                            db.Commands[j+c].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        }
                    }

                    db.BeginTransaction();
                    for (int k = 0; k < db.Commands.Count; k++)
                    {
                        db.Commands[k].ExecuteNonQuery();
                    }
                    db.CommitTransaction();
                }
                MessageBox.Show("Data telah disimpan");
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
