using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Master
{
    public partial class frmTargetOverdueUpDate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _RowID;
        DataTable dt;

        public frmTargetOverdueUpDate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmTargetOverdueUpDate(Form caller, Guid RowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _RowID = RowID;
            this.Caller = caller;
        }

        private void frmTargetOverdueUpDate_Load(object sender, EventArgs e)
        {
            try
            {
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_TargetOverdue_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));                        
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    monthYearBox1.Enabled = false;                    
                    DateTime _Periode = (DateTime)dt.Rows[0]["Periode"];
                    monthYearBox1.Month = _Periode.Month;
                    monthYearBox1.Year = _Periode.Year;
                    txtTargetRp.Text = Tools.isNull(dt.Rows[0]["TargetRp"], "").ToString();
                    txtKeterangan.Text = Tools.isNull(dt.Rows[0]["Keterangan"], "").ToString();

                }
                else
                {
                    monthYearBox1.Month = GlobalVar.DateOfServer.Month;
                    monthYearBox1.Year = GlobalVar.DateOfServer.Year;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {

            if (double.Parse(txtTargetRp.Text) <= 0)
            {
                MessageBox.Show("Target Rp harus > 0");
                txtTargetRp.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtKeterangan.Text))
            {
                MessageBox.Show("Keterangan tidak boleh kosong");
                txtKeterangan.Focus();
                return;
            }            
            DateTime _Periode = monthYearBox1.LastDateOfMonth;
            double _TargetRp = double.Parse(txtTargetRp.Text);

            try
            {
                switch (formMode)
                {
                    case enumFormMode.New:
                        _RowID = Guid.NewGuid();
                        using (Database db = new Database())                        
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_TargetOverdue_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@Periode", SqlDbType.DateTime, _Periode));
                            db.Commands[0].Parameters.Add(new Parameter("@TargetRp", SqlDbType.Money, _TargetRp));
                            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Periode sudah ada");
                                monthYearBox1.Focus();
                                return;
                            }
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_TargetOverdue_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@TargetRp", SqlDbType.Money, txtTargetRp.Text ));
                            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                this.DialogResult = DialogResult.OK;
                FormClose();
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormClose()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                frmTargetOverdue frmCaller = (frmTargetOverdue)this.Caller;
                frmCaller.RefreshData();
                frmCaller.FindRow("RowID", _RowID.ToString());
            }
        }

    }
}
