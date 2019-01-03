using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Reporting.WinForms;
using ISA.Trading.DataTemplates;
using ISA.DAL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;
using ISA.Trading.POS;

namespace ISA.Trading.POS.Bayar
{
    public partial class FrmBayar : ISA.Trading.BaseForm
    {
        string datapassing; // tambahan
        string kodetoko, namatoko;
        DateTime tgljatuhtempo, tglsekarang; 
        int jumlahhutang;
        bool _isCetakNota = true;

        public FrmBayar(Form caller)
        {
            InitializeComponent();
            
            this.Caller = caller;          
        }

        public FrmBayar(Form caller, bool isCetakNota)
        {
            InitializeComponent();

            this.Caller = caller;
            _isCetakNota = isCetakNota;
        }    

        private void FrmBayar2_Load(object sender, EventArgs e)
        {
            if (this.Caller is FrmPOS)
            {
                POS.FrmPOS frmCaller = (POS.FrmPOS)this.Caller;
                TxtNeto.Text = frmCaller.label12.Text.ToString();
                kodetoko=frmCaller.LblKodeToko.Text.ToString();  
                namatoko=frmCaller.TxtNamaToko.Text.ToString();               
            }
            else if (this.Caller is FrmPOS0401)
            {
                POS.FrmPOS0401 frmCaller = (POS.FrmPOS0401)this.Caller;
                TxtNeto.Text = frmCaller.label12.Text.ToString();
                kodetoko = frmCaller.LblKodeToko.Text.ToString();
                namatoko = frmCaller.TxtNamaToko.Text.ToString();
            }

            //DateTime.Now  ;
            LblNota.Visible = false;
            label1.Visible = false;
            CmdPrint.Enabled = false;
            textBox2.Focus();
        }
        private void commandButton3_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void commandButton2_Click(object sender, EventArgs e)
        {
            if (this.Caller is FrmPOS)
            {
                double RpNota = 0, RpBayar = 0;
                RpNota = Convert.ToDouble(Tools.isNull(TxtNeto.Text, "0").ToString());
                RpBayar = Convert.ToDouble(Tools.isNull(textBox2.Text, "0").ToString());

                if (RpNota == 0)
                {
                    MessageBox.Show("Rp Nota Kosong");
                    return;
                }
                if (RpBayar == 0)
                {
                    MessageBox.Show("Rp Bayar Kosong");
                    return;
                }

                /*ditutup, pembayaran dikembalikan ke penjualantunai*/
                //if (RpNota > RpBayar)
                //{
                //    MessageBox.Show("Pembayaran kurang.");
                //    return;
                //}

                //if (RpNota > 0) // && RpBayar > 0)
                //{
                    POS.FrmPOS frmCaller = (POS.FrmPOS)this.Caller;
                    frmCaller.txtBayar.Text = Convert.ToDouble(Tools.isNull(textBox2.Text, "0")).ToString("N0");
                    frmCaller.Save_DONOTA(sender, e);
                    LblNota.Text = frmCaller.LblNoNota.Text.ToString();

                    if (_isCetakNota)
                    {
                        if (!frmCaller.PengajuanHarga)
                        {
                            DialogResult dialogResult = MessageBox.Show("Data dengan Nomor Nota : " + Convert.ToString(LblNota.Text) + ", Nomor DO : " + Convert.ToString(LblNota.Text) + " Telah Disimpan" + "\n\n\n" + "CETAK NOTA ?", "KONFIRMASI", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                CmdPrint_Click(sender, e);
                                this.Close();
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                this.Close();
                            }
                        }
                        else
                        {
                            this.Close();
                        }
                        POS.FrmPOS ifrmChild = new POS.FrmPOS();
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
                    else
                    {
                        this.Close();
                    }
                //}
            }

            else if(this.Caller is FrmPOS0401)
            {
                POS.FrmPOS0401 frmCaller = (POS.FrmPOS0401)this.Caller;
                frmCaller.Save_DONOTA(sender, e);
                LblNota.Text = frmCaller.LblNoNota.Text.ToString();

                if (_isCetakNota)
                {
                    DialogResult dialogResult = MessageBox.Show("Data dengan Nomor Nota : " + Convert.ToString(LblNota.Text) + ", Nomor DO : " + Convert.ToString(LblNota.Text) + " Telah Disimpan" + "\n\n\n" + "CETAK NOTA ?", "KONFIRMASI", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        CmdPrint_Click(sender, e);
                        this.Close();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        this.Close();
                    }

                    POS.FrmPOS0401 ifrmChild = new POS.FrmPOS0401();
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
                else
                {
                    this.Close();
                }
            }

            else if (this.Caller is FrmPOSbengkel)
            {
                POS.FrmPOSbengkel frmCaller = (POS.FrmPOSbengkel)this.Caller;
                frmCaller.Save_DONOTA(sender, e);
                LblNota.Text = frmCaller.LblNoNota.Text.ToString();
                this.DialogResult = DialogResult.OK;

                if (_isCetakNota)
                {
                    DialogResult dialogResult = MessageBox.Show("Data dengan Nomor Nota : " + Convert.ToString(LblNota.Text) + ", Nomor DO : " + Convert.ToString(LblNota.Text) + " Telah Disimpan" + "\n\n\n" + "CETAK NOTA ?", "KONFIRMASI", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        CmdPrint_Click(sender, e);
                        this.Close();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        this.Close();
                    }

                    POS.FrmPOSbengkel ifrmChild = new POS.FrmPOSbengkel();
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
                else
                {
                    this.Close();
                }
            }
            label1.Visible = true;
            LblNota.Visible = true;
           // CmdPrint.Enabled = true;            
        }


       
        private void PrintNota()
        {

            DataSet dt = new DataSet();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("rsp_Cetak_POS_nota"));
                db.Commands[0].Parameters.Add(new Parameter("@NoNota", SqlDbType.VarChar, LblNota.Text));
                dt = db.Commands[0].ExecuteDataSet();
            }
            if (dt.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Data tidak ada.....");
                Close();
            }
            else
            {
                DisplayReport(dt);
                using (Database db = new Database())
                {
                    DataTable dtupdate = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_nPrint_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@NoDO", SqlDbType.VarChar, LblNoDO_.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@NoNota", SqlDbType.VarChar, LblNota.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, 1));
                    dtupdate = db.Commands[0].ExecuteDataTable();

                }

            }
            this.Cursor = Cursors.Default;
        }
        private void DisplayReport(DataSet ds)
        {
            List<ReportParameter> rptParams = new List<ReportParameter>();

            //rptParams.Add(new ReportParameter("fromdate", rangeDateBox1.FromDate.Value.ToString("dd-MMM-yyyy")));
            //rptParams.Add(new ReportParameter("ToDate", rangeDateBox1.ToDate.Value.ToString("dd-MMM-yyyy")));
            //rptParams.Add(new ReportParameter("namasales", _sales));
            DataTable dt0 = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];

            List<DataTable> dt2 = new List<DataTable>();
            List<string> dtName = new List<string>();

            dt2.Clear();
            //dtName.Clear();

            dt2.Add(dt0);
            dt2.Add(dt1);

            dtName.Add("CetakPOSNota_PosNota");
            dtName.Add("CetakPOSNota_DataPerusahaan");

            //frmReportViewer ifrmReport = new frmReportViewer("POS.CETAK.RptCetakPosNota2.rdlc", rptParams, dt2, dtName);
            frmReportViewer ifrmReport = new frmReportViewer("POS.CETAK.rptCetakNotaPOSTax.rdlc", rptParams, dt2, dtName);
            //frmReportViewer ifrmReport = new frmReportViewer("PO.cetak.rptCetakPO.rdlc", rptParams, dt, "dsCetakPO_Detail");
            //frmReportViewer ifrmReport = new frmReportViewer("POS.CETAK.RptCetakPosNota2.rdlc", rptParams, dt, "CetakPOSNota_PosNota");

            ifrmReport.Show();
        }

        private void CmdPrint_Click(object sender, EventArgs e)
        {
            //PrintNota();
            if (this.Caller is FrmPOS)
            {
                POS.FrmPOS frmCaller = (POS.FrmPOS)this.Caller;
                frmCaller.cekcetak();
            }
            else if (this.Caller is FrmPOS0401)
            {
                POS.FrmPOS0401 frmCaller = (POS.FrmPOS0401)this.Caller;
                frmCaller.cekcetak();
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            double kembali = 0, RpNota = 0, RpBayar = 0;
            RpNota = double.Parse(Tools.isNull(TxtNeto.Text, "0").ToString());
            RpBayar = double.Parse(Tools.isNull(textBox2.Text, "0").ToString());
            if (RpBayar - RpNota <= 0)
                kembali = 0;
            else
                kembali = RpBayar - RpNota;
            textBox5.Text = kembali.ToString();
        }
    }
}
