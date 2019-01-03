using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using ISA.Bengkel.Helper;
using ISA.Bengkel.Library;
using ISA.Bengkel.Class;
using ISA.Trading;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
using ISA.Trading.Class;


namespace ISA.Bengkel.Laporan
{
    public partial class frmRptOrderPembelianBarang : ISA.Controls.BaseForm
    {
        string PrnAktif = "0";
        DataTable dtf;
        DataTable dtNum;
        DataTable dtForm;

        public frmRptOrderPembelianBarang()
        {
            InitializeComponent();
        }

        private void frmRptOrderPembelianBarang_Load(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdCetak_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_cekPrinterAktif"));
                    db.Commands[0].Parameters.Add(new Parameter("@LookupCode", SqlDbType.VarChar, "ORDERBKL"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                    PrnAktif = "0";
                else
                    PrnAktif = dt.Rows[0]["Value"].ToString();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            if (PrnAktif != "0")
                CetakFormOrder_Inkjet();
            //else
                //CetakFormOrder();

        }


        private void CetakFormOrder_Inkjet()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtForm = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_createFormData_LIST"));
                    dtForm = db.Commands[0].ExecuteDataTable();
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

            double Total = 0;
            double TotalDisc = 0;
            string _no = "", numeratorDoc = "NOMOR_ORDER_BKL", depan = "", belakang = "";
            int iNomor = 0, lebar = 0;

            try
            {
                depan = "D" + GlobalVar.Gudang.Trim().Substring(2, 2);
                dtNum = Tools.GetGeneralNumerator(numeratorDoc, depan);
                if (dtNum.Rows.Count > 0)
                {
                    lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                    belakang = dtNum.Rows[0]["Belakang"].ToString();
                    iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                    iNomor++;
                    _no = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
                }
                else
                {
                    lebar = 4;
                    belakang = "";
                    iNomor = 0;
                    iNomor++;
                    _no = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
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

            string Nomor = _no;
            string Tanggal = GlobalVar.DateOfServer.ToString("dd-MMM-yyyy");
            string UserID = SecurityManager.UserName.ToString();

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", UserID));
            rptParams.Add(new ReportParameter("Nomor", Nomor));
            rptParams.Add(new ReportParameter("Tanggal", Tanggal));

            int nPrint = 0;
            nPrint = int.Parse(Tools.isNull(PrnAktif,"0").ToString());

            for (int i = 1; i <= nPrint; i++)
            {
                if (i == 1)
                {
                    frmReportViewer ifrmReport = new frmReportViewer("Laporan.rptCetakFormOrder.rdlc", rptParams, dtForm, "dsCetakNotaBengkel_Data");
                    ifrmReport.Print();
                    //ifrmReport.Print(8.5, 6.4);
                    //ifrmReport.Show();
                }
                if (i == 2)
                {
                    frmReportViewer ifrmReport = new frmReportViewer("Laporan.rptCetakFormOrder_copy1.rdlc", rptParams, dtForm, "dsCetakNotaBengkel_Data");
                    ifrmReport.Print();
                    //ifrmReport.Print(8.5, 6.4);
                    //ifrmReport.Show();
                }
                if (i > 2)
                {
                    frmReportViewer ifrmReport = new frmReportViewer("Laporan.rptCetakFormOrder_copy2.rdlc", rptParams, dtForm, "dsCetakNotaBengkel_Data");
                    ifrmReport.Print();
                    //ifrmReport.Print(8.5, 6.4);
                    //ifrmReport.Show();
                }
            }

            if (dtNum.Rows.Count > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, numeratorDoc));
                        db.Commands[0].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                        db.Commands[0].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                        db.Commands[0].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                        db.Commands[0].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.BeginTransaction();
                        db.Commands[0].ExecuteNonQuery();
                        db.CommitTransaction();
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
            else
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        MessageBox.Show(numeratorDoc);
                        db.Commands.Add(db.CreateCommand("usp_bkl_numerator_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, numeratorDoc));
                        db.Commands[0].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                        db.Commands[0].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                        db.Commands[0].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                        db.Commands[0].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.BeginTransaction();
                        db.Commands[0].ExecuteNonQuery();
                        db.CommitTransaction();
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
        }
    }
}
