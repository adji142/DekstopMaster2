using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using System.Drawing.Printing;
using ISA.Common;
using ISA.Finance.Class;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data.SqlTypes;

namespace ISA.Finance.Piutang
{
    public partial class frmPlafonRefresh : ISA.Finance.BaseForm
    {
        string _KodeToko = "";
        DataTable _dtToko = new DataTable();


        private void REfresh()
        {
            if (this.Caller is frmPlafon)
            {
                frmPlafon frmCaller = (frmPlafon)this.Caller;
                //frmCaller.RefreshRowDataReturJualDetail(_rowID.ToString());
                //frmCaller.FindDetail("DetailRowID", _rowID.ToString());
          
                frmCaller.RefreshHeader();
                frmCaller.FindGridHeader("KodeToko", _KodeToko);

            }
        }
        public frmPlafonRefresh()
        {
            InitializeComponent();
        }

        public frmPlafonRefresh(Form Caller_ ,DataTable dtToko_ ,string KodeToko_)
        {
            this.Caller = Caller_;
            _dtToko = dtToko_.Copy();
            _KodeToko = KodeToko_;
            InitializeComponent();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPlafonRefresh_Load(object sender, EventArgs e)
        {
            dateTextBox1.DateValue = DateTime.Now;
            progressBar1.Visible = false;
            progressBar1.Maximum = _dtToko.Rows.Count;
            lblToko.Text = "";
            comboBox1.SelectedIndex = 0;

        }

        private void commandButton1_Click(object sender, EventArgs e)
        {

            
            try
            {
                this.Cursor = Cursors.WaitCursor;
                commandButton1.Enabled = false;
                progressBar1.Visible = true;
                
                DateTime dkp = dateTextBox1.DateValue.Value.AddMonths((-1)*Convert.ToInt32(comboBox1.Text.ToString()));
                DateTime dgt = dateTextBox1.DateValue.Value.AddMonths(-6);

                DataTable dt = new DataTable();

                foreach (DataRow dr in _dtToko.Rows)
                {
                    lblToko.Text = dr["NamaToko"].ToString();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("[usp_detailPlafon_Get]"));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, dr["KodeToko"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, dateTextBox1.DateValue.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@TanggalKP", SqlDbType.DateTime, dkp));
                        db.Commands[0].Parameters.Add(new Parameter("@TanggalGiro", SqlDbType.DateTime, dgt));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    if (dt.Rows.Count>0)
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("[usp_detailPlafon_Refresh]"));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, dr["KodeToko"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, dateTextBox1.DateValue.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@RpBayar", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dt.Rows[0]["RpBayar"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@RpGiro", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dt.Rows[0]["RpGiro"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@RpGiroTolak", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dt.Rows[0]["RpGiroTolak"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserInitial));
                            db.Commands[0].Parameters.Add(new Parameter("@Flag", SqlDbType.VarChar, "ada"));
                            db.Commands[0].Parameters.Add(new Parameter("@nBulan", SqlDbType.Int, Convert.ToInt32(comboBox1.Text.ToString())));
                            db.Commands[0].ExecuteNonQuery();
                        }

                    } 
                    else
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("[usp_detailPlafon_Refresh]"));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, dr["KodeToko"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, dateTextBox1.DateValue.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@RpBayar", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@RpGiro", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@RpGiroTolak", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserInitial));
                            db.Commands[0].Parameters.Add(new Parameter("@Flag", SqlDbType.VarChar, "tdk"));
                            db.Commands[0].Parameters.Add(new Parameter("@nBulan", SqlDbType.Int, Convert.ToInt32(comboBox1.Text.ToString())));
                            db.Commands[0].ExecuteNonQuery();
                        }

                    }
                    progressBar1.Increment(1);
                    this.Refresh();
                    Application.DoEvents();
                }

                progressBar1.Visible = false;
                lblToko.Text = "";
                commandButton1.Enabled = true;
                REfresh();
                this.Close();
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
    }
}
