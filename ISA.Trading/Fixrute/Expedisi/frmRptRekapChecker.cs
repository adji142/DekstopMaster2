using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
namespace ISA.Trading.Expedisi
{
    public partial class frmRptRekapChecker : ISA.Trading.BaseForm
    {
        //private ISA.Trading.Controls.CommandButton cmdClose;
        //private ISA.Trading.Controls.CommandButton cmdShow;
        //private Label label2;
        //private Label label1;
        //private ISA.Trading.Controls.RangeDateBox rangeDateBox1;
        //private ComboBox cboChecker;
        //private RadioButton radioButton1;
        //private RadioButton radioButton2;
        string checker;
        public frmRptRekapChecker()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    
                    db.Commands.Add(db.CreateCommand("rsp_RekapChecker"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    if (rdoChecker1.Checked == true)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@checker1", SqlDbType.VarChar, cboChecker.SelectedValue));
                        checker = "1";
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@checker2", SqlDbType.VarChar, cboChecker.SelectedValue));
                        checker = "2";
                    }
                    dt = db.Commands[0].ExecuteDataTable();
                  
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

        private void frmRptRekapChecker_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            rdoChecker1.Checked = true;
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Checker_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                    cboChecker.DataSource = dt;
                    cboChecker.DisplayMember = "FirstName";
                    cboChecker.ValueMember = "FirstName";
                    if (cboChecker.Items.Count > 0)
                    {
                        cboChecker.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
           
        }

        private void DisplayReport(DataTable dt)
        {
            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Checker", checker));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Expedisi.rptRekapChecker.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();

        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // frmRptRekapChecker
        //    // 
        //    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        //    this.ClientSize = new System.Drawing.Size(609, 317);
        //    this.Location = new System.Drawing.Point(0, 0);
        //    this.Name = "frmRptRekapChecker";
        //    this.Load += new System.EventHandler(this.frmRptRekapChecker_Load_1);
        //    this.ResumeLayout(false);
        //    this.PerformLayout();

        //}

       

        //private void InitializeComponent()
        //{
        //    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptRekapChecker));
        //    this.cmdClose = new ISA.Trading.Controls.CommandButton();
        //    this.cmdShow = new ISA.Trading.Controls.CommandButton();
        //    this.label2 = new System.Windows.Forms.Label();
        //    this.label1 = new System.Windows.Forms.Label();
        //    this.rangeDateBox1 = new ISA.Trading.Controls.RangeDateBox();
        //    this.cboChecker = new System.Windows.Forms.ComboBox();
        //    this.radioButton1 = new System.Windows.Forms.RadioButton();
        //    this.radioButton2 = new System.Windows.Forms.RadioButton();
        //    this.SuspendLayout();
        //    // 
        //    // cmdClose
        //    // 
        //    this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
        //    this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
        //    this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
        //    this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //    this.cmdClose.Location = new System.Drawing.Point(260, 137);
        //    this.cmdClose.Name = "cmdClose";
        //    this.cmdClose.Size = new System.Drawing.Size(100, 40);
        //    this.cmdClose.TabIndex = 29;
        //    this.cmdClose.Text = "CLOSE";
        //    this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
        //    this.cmdClose.UseVisualStyleBackColor = true;
        //    // 
        //    // cmdShow
        //    // 
        //    this.cmdShow.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
        //    this.cmdShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
        //    this.cmdShow.Image = ((System.Drawing.Image)(resources.GetObject("cmdShow.Image")));
        //    this.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //    this.cmdShow.Location = new System.Drawing.Point(154, 137);
        //    this.cmdShow.Name = "cmdShow";
        //    this.cmdShow.Size = new System.Drawing.Size(100, 40);
        //    this.cmdShow.TabIndex = 28;
        //    this.cmdShow.Text = "YES";
        //    this.cmdShow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
        //    this.cmdShow.UseVisualStyleBackColor = true;
        //    // 
        //    // label2
        //    // 
        //    this.label2.AutoSize = true;
        //    this.label2.Location = new System.Drawing.Point(26, 95);
        //    this.label2.Name = "label2";
        //    this.label2.Size = new System.Drawing.Size(47, 13);
        //    this.label2.TabIndex = 25;
        //    this.label2.Text = "Checker";
        //    // 
        //    // label1
        //    // 
        //    this.label1.AutoSize = true;
        //    this.label1.Location = new System.Drawing.Point(26, 64);
        //    this.label1.Name = "label1";
        //    this.label1.Size = new System.Drawing.Size(102, 13);
        //    this.label1.TabIndex = 23;
        //    this.label1.Text = "Tanggal Surat Jalan";
        //    // 
        //    // rangeDateBox1
        //    // 
        //    this.rangeDateBox1.FromDate = null;
        //    this.rangeDateBox1.Location = new System.Drawing.Point(127, 61);
        //    this.rangeDateBox1.Name = "rangeDateBox1";
        //    this.rangeDateBox1.Size = new System.Drawing.Size(220, 20);
        //    this.rangeDateBox1.TabIndex = 24;
        //    this.rangeDateBox1.ToDate = null;
        //    // 
        //    // cboChecker
        //    // 
        //    this.cboChecker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        //    this.cboChecker.FormattingEnabled = true;
        //    this.cboChecker.Location = new System.Drawing.Point(155, 86);
        //    this.cboChecker.Name = "cboChecker";
        //    this.cboChecker.Size = new System.Drawing.Size(121, 21);
        //    this.cboChecker.TabIndex = 30;
        //    // 
        //    // radioButton1
        //    // 
        //    this.radioButton1.AutoSize = true;
        //    this.radioButton1.Location = new System.Drawing.Point(154, 114);
        //    this.radioButton1.Name = "radioButton1";
        //    this.radioButton1.Size = new System.Drawing.Size(74, 17);
        //    this.radioButton1.TabIndex = 31;
        //    this.radioButton1.TabStop = true;
        //    this.radioButton1.Text = "Checker 1";
        //    this.radioButton1.UseVisualStyleBackColor = true;
        //    // 
        //    // radioButton2
        //    // 
        //    this.radioButton2.AutoSize = true;
        //    this.radioButton2.Location = new System.Drawing.Point(247, 113);
        //    this.radioButton2.Name = "radioButton2";
        //    this.radioButton2.Size = new System.Drawing.Size(74, 17);
        //    this.radioButton2.TabIndex = 32;
        //    this.radioButton2.TabStop = true;
        //    this.radioButton2.Text = "Checker 2";
        //    this.radioButton2.UseVisualStyleBackColor = true;
        //    // 
        //    // frmRptRekapChecker
        //    // 
        //    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        //    this.ClientSize = new System.Drawing.Size(609, 317);
        //    this.Controls.Add(this.radioButton2);
        //    this.Controls.Add(this.radioButton1);
        //    this.Controls.Add(this.cboChecker);
        //    this.Controls.Add(this.cmdClose);
        //    this.Controls.Add(this.cmdShow);
        //    this.Controls.Add(this.label2);
        //    this.Controls.Add(this.label1);
        //    this.Controls.Add(this.rangeDateBox1);
        //    this.Location = new System.Drawing.Point(0, 0);
        //    this.Name = "frmRptRekapChecker";
        //    this.Load += new System.EventHandler(this.frmRptRekapChecker_Load_1);
        //    this.Controls.SetChildIndex(this.rangeDateBox1, 0);
        //    this.Controls.SetChildIndex(this.label1, 0);
        //    this.Controls.SetChildIndex(this.label2, 0);
        //    this.Controls.SetChildIndex(this.cmdShow, 0);
        //    this.Controls.SetChildIndex(this.cmdClose, 0);
        //    this.Controls.SetChildIndex(this.cboChecker, 0);
        //    this.Controls.SetChildIndex(this.radioButton1, 0);
        //    this.Controls.SetChildIndex(this.radioButton2, 0);
        //    this.ResumeLayout(false);
        //    this.PerformLayout();

        //}

     

        

       
    }
}
