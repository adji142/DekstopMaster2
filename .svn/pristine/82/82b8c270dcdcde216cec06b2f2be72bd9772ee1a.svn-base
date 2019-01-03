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

namespace ISA.Toko.Laporan.Barang
{
	public partial class frmRptBackOrderFilter : ISA.Toko.BaseForm
	{
        private ISA.Toko.Controls.LookupGudang listGudang;
        private RadioButton rbToko;
        private RadioButton rbDetail;
        private ISA.Toko.Controls.LookupToko listToko;
        private ISA.Toko.Controls.LookupGudang lookupGudang1;
        private ISA.Toko.Controls.LookupSales listSales;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private ISA.Toko.Controls.LookupStock lookupStock1;
        private Label label8;
        private Label label9;
        private ISA.Toko.Controls.CommonTextBox txtDO;
        private Label label10;
        private Label label11;
        private ISA.Toko.Controls.CommonTextBox txtRequest;
        private ISA.Toko.Controls.CommandButton cmdYes;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private GroupBox grbPilihan;
        private ErrorProvider errorProvider1;
        private IContainer components;
        private Label label12;
        private TextBox txtKota;
        private ISA.Toko.Controls.RangeDateBox rdbDate;
    
		public frmRptBackOrderFilter()
		{
			InitializeComponent();
		}

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptBackOrderFilter));
            this.rdbDate = new ISA.Toko.Controls.RangeDateBox();
            this.listGudang = new ISA.Toko.Controls.LookupGudang();
            this.rbToko = new System.Windows.Forms.RadioButton();
            this.rbDetail = new System.Windows.Forms.RadioButton();
            this.listToko = new ISA.Toko.Controls.LookupToko();
            this.lookupGudang1 = new ISA.Toko.Controls.LookupGudang();
            this.listSales = new ISA.Toko.Controls.LookupSales();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lookupStock1 = new ISA.Toko.Controls.LookupStock();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDO = new ISA.Toko.Controls.CommonTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRequest = new ISA.Toko.Controls.CommonTextBox();
            this.cmdYes = new ISA.Toko.Controls.CommandButton();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.grbPilihan = new System.Windows.Forms.GroupBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtKota = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.grbPilihan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // rdbDate
            // 
            this.rdbDate.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdbDate.FromDate = null;
            this.rdbDate.Location = new System.Drawing.Point(133, 61);
            this.rdbDate.Name = "rdbDate";
            this.rdbDate.Size = new System.Drawing.Size(257, 22);
            this.rdbDate.TabIndex = 0;
            this.rdbDate.ToDate = null;
            // 
            // listGudang
            // 
            this.listGudang.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.listGudang.GudangID = "";
            this.listGudang.KodeCabang = null;
            this.listGudang.Location = new System.Drawing.Point(133, 89);
            this.listGudang.NamaGudang = "";
            this.listGudang.Name = "listGudang";
            this.listGudang.Size = new System.Drawing.Size(276, 54);
            this.listGudang.TabIndex = 1;
            // 
            // rbToko
            // 
            this.rbToko.AutoSize = true;
            this.rbToko.Location = new System.Drawing.Point(13, 12);
            this.rbToko.Name = "rbToko";
            this.rbToko.Size = new System.Drawing.Size(53, 18);
            this.rbToko.TabIndex = 0;
            this.rbToko.Text = "Toko";
            this.rbToko.UseVisualStyleBackColor = true;
            this.rbToko.Click += new System.EventHandler(this.rbToko_Click);
            this.rbToko.CheckedChanged += new System.EventHandler(this.rbToko_CheckedChanged);
            // 
            // rbDetail
            // 
            this.rbDetail.AutoSize = true;
            this.rbDetail.Location = new System.Drawing.Point(84, 12);
            this.rbDetail.Name = "rbDetail";
            this.rbDetail.Size = new System.Drawing.Size(67, 18);
            this.rbDetail.TabIndex = 1;
            this.rbDetail.Text = "Detail";
            this.rbDetail.UseVisualStyleBackColor = true;
            this.rbDetail.Click += new System.EventHandler(this.rbDetail_Click);
            // 
            // listToko
            // 
            this.listToko.Alamat = null;
            this.listToko.Enabled = false;
            this.listToko.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.listToko.KodeToko = "";
            this.listToko.Kota = null;
            this.listToko.Location = new System.Drawing.Point(133, 181);
            this.listToko.NamaToko = "";
            this.listToko.Name = "listToko";
            this.listToko.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.listToko.Size = new System.Drawing.Size(300, 54);
            this.listToko.TabIndex = 2;
            this.listToko.TokoID = null;
            // 
            // lookupGudang1
            // 
            this.lookupGudang1.Enabled = false;
            this.lookupGudang1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang1.GudangID = "";
            this.lookupGudang1.KodeCabang = null;
            this.lookupGudang1.Location = new System.Drawing.Point(133, 324);
            this.lookupGudang1.NamaGudang = "";
            this.lookupGudang1.Name = "lookupGudang1";
            this.lookupGudang1.Size = new System.Drawing.Size(276, 54);
            this.lookupGudang1.TabIndex = 4;
            // 
            // listSales
            // 
            this.listSales.Enabled = false;
            this.listSales.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.listSales.Location = new System.Drawing.Point(133, 264);
            this.listSales.NamaSales = "";
            this.listSales.Name = "listSales";
            this.listSales.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.listSales.SalesID = "";
            this.listSales.Size = new System.Drawing.Size(276, 54);
            this.listSales.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tanggal :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "C2 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 14;
            this.label3.Text = "Toko :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 15;
            this.label4.Text = "Salesman :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 324);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 16;
            this.label5.Text = "C1 :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 14);
            this.label6.TabIndex = 17;
            this.label6.Text = "Kode Toko :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 304);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 14);
            this.label7.TabIndex = 18;
            this.label7.Text = "Kode Sales :";
            // 
            // lookupStock1
            // 
            this.lookupStock1.BarangID = "";
            this.lookupStock1.Enabled = false;
            this.lookupStock1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupStock1.IsiKoli = 0;
            this.lookupStock1.Location = new System.Drawing.Point(133, 436);
            this.lookupStock1.LookUpType = ISA.Toko.Controls.LookupStock.EnumLookUpType.Normal;
            this.lookupStock1.NamaStock = "";
            this.lookupStock1.Name = "lookupStock1";
            this.lookupStock1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupStock1.Satuan = null;
            this.lookupStock1.Size = new System.Drawing.Size(329, 54);
            this.lookupStock1.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 436);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 14);
            this.label8.TabIndex = 20;
            this.label8.Text = "Nama Stok :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 476);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 14);
            this.label9.TabIndex = 21;
            this.label9.Text = "Kode Stok :";
            // 
            // txtDO
            // 
            this.txtDO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDO.Enabled = false;
            this.txtDO.Location = new System.Drawing.Point(133, 384);
            this.txtDO.Name = "txtDO";
            this.txtDO.Size = new System.Drawing.Size(100, 20);
            this.txtDO.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 384);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 14);
            this.label10.TabIndex = 23;
            this.label10.Text = "No. DO :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 410);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 14);
            this.label11.TabIndex = 25;
            this.label11.Text = "No. Request :";
            // 
            // txtRequest
            // 
            this.txtRequest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRequest.Enabled = false;
            this.txtRequest.Location = new System.Drawing.Point(133, 410);
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.Size = new System.Drawing.Size(100, 20);
            this.txtRequest.TabIndex = 6;
            // 
            // cmdYes
            // 
            this.cmdYes.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(12, 517);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 8;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(642, 517);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 9;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // grbPilihan
            // 
            this.grbPilihan.Controls.Add(this.rbDetail);
            this.grbPilihan.Controls.Add(this.rbToko);
            this.grbPilihan.Location = new System.Drawing.Point(133, 139);
            this.grbPilihan.Name = "grbPilihan";
            this.grbPilihan.Size = new System.Drawing.Size(200, 36);
            this.grbPilihan.TabIndex = 28;
            this.grbPilihan.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtKota
            // 
            this.txtKota.Enabled = false;
            this.txtKota.Location = new System.Drawing.Point(133, 241);
            this.txtKota.Name = "txtKota";
            this.txtKota.Size = new System.Drawing.Size(168, 20);
            this.txtKota.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 247);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 14);
            this.label12.TabIndex = 30;
            this.label12.Text = "Kota";
            // 
            // frmRptBackOrderFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(754, 569);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtKota);
            this.Controls.Add(this.grbPilihan);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRequest);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDO);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lookupStock1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listSales);
            this.Controls.Add(this.lookupGudang1);
            this.Controls.Add(this.listToko);
            this.Controls.Add(this.rdbDate);
            this.Controls.Add(this.listGudang);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptBackOrderFilter";
            this.Text = "Back Order";
            this.Title = "Back Order";
            this.Load += new System.EventHandler(this.frmRptBackOrderFilter_Load);
            this.Controls.SetChildIndex(this.listGudang, 0);
            this.Controls.SetChildIndex(this.rdbDate, 0);
            this.Controls.SetChildIndex(this.listToko, 0);
            this.Controls.SetChildIndex(this.lookupGudang1, 0);
            this.Controls.SetChildIndex(this.listSales, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.lookupStock1, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtDO, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtRequest, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.grbPilihan, 0);
            this.Controls.SetChildIndex(this.txtKota, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.grbPilihan.ResumeLayout(false);
            this.grbPilihan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void frmRptBackOrderFilter_Load(object sender, EventArgs e)
        {
            rdbDate.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdbDate.ToDate = DateTime.Now;
            rbToko.Checked = true;
        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (rdbDate.FromDate.ToString() == "" || rdbDate.ToDate.ToString() == "")
            {
                errorProvider1.SetError(rdbDate, "Range Tanggal masih kosong");
                valid = false;
            }

            if (listGudang.GudangID == "")
            {
                errorProvider1.SetError(listGudang, "Kode Gudang masih kosong");
                valid = false;
            }
            return valid;
        }

        private void EnableControls(bool enabled)
        {
            listToko.Enabled = enabled;
            listSales.Enabled = enabled;
            lookupGudang1.Enabled = enabled;
            lookupStock1.Enabled = enabled;
            txtDO.Enabled = enabled;
            txtRequest.Enabled = enabled;
            txtKota.Enabled = enabled;
        }

        private void rbToko_Click(object sender, EventArgs e)
        {
            EnableControls(false);
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            string typeTrans = string.Empty;
            string kodeToko = string.Empty;
            string kodeSales = string.Empty;
            string cabang1 = string.Empty;
            string noDO = string.Empty;
            string noRequest = string.Empty;
            string barangID = string.Empty;
            if (!ValidateInput())
            {
                return;
            }
            if (rbToko.Checked == true)
            {
                typeTrans = "TK";
            }
            else
            {
                typeTrans = "DT";
                kodeToko = Convert.ToString(listToko.KodeToko);
                kodeSales = Convert.ToString(listSales.SalesID);
                cabang1 = Convert.ToString(lookupGudang1.GudangID);
                noDO = txtDO.Text;
                noRequest = txtRequest.Text;
                barangID = Convert.ToString(lookupStock1.BarangID);
            }
            try
            {

                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Laporan_Barang_BackOrder"));
                    db.Commands[0].Parameters.Add(new Parameter("@type", SqlDbType.VarChar, typeTrans));
                    db.Commands[0].Parameters.Add(new Parameter("@DateFrom", SqlDbType.DateTime, rdbDate.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@DateTo", SqlDbType.DateTime, rdbDate.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@gudangID", SqlDbType.VarChar, listGudang.GudangID));
                    db.Commands[0].Parameters.Add(new Parameter("@kdToko", SqlDbType.VarChar, kodeToko));
                    if (kodeToko!="" && txtKota.Text.Trim()!="")
                    {   db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, txtKota.Text));
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@kdSales", SqlDbType.VarChar, kodeSales));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, cabang1));
                    db.Commands[0].Parameters.Add(new Parameter("@noDO", SqlDbType.VarChar, noDO));
                    db.Commands[0].Parameters.Add(new Parameter("@noRequest", SqlDbType.VarChar, noRequest));
                    db.Commands[0].Parameters.Add(new Parameter("@barangId", SqlDbType.VarChar, barangID));
                    db.Commands[0].Parameters.Add(new Parameter("@InitPers", SqlDbType.VarChar,GlobalVar.PerusahaanID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    DisplayReport(dt);
                }
                else
                {
                    MessageBox.Show(Messages.Error.NotFound);
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

        private void DisplayReport(DataTable dt)
        {
            string periode;
            string pengirim;
            periode = String.Format("{0} s/d {1}", ((DateTime)rdbDate.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbDate.ToDate).ToString("dd/MM/yyyy"));
            pengirim = listGudang.GudangID.ToString();

            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("CabangID", GlobalVar.CabangID));
            rptParams.Add(new ReportParameter("Periode", periode));
            if (rbToko.Checked == true)
            {
                rptParams.Add(new ReportParameter("Pengirim", pengirim));
                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Laporan.Barang.rptBackOrder.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
                ifrmReport.Show();
            }
            else
            {
                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Laporan.Barang.rptBackOrderDetail.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
                ifrmReport.Show();
            }
        }

        private void rbDetail_Click(object sender, EventArgs e)
        {
            EnableControls(true);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbToko_CheckedChanged(object sender, EventArgs e)
        {

        }
	}
}
