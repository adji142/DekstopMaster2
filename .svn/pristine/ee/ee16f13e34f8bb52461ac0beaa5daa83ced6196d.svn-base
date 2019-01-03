using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko;
using System.Data.SqlTypes;

namespace ISA.Toko.PO
{
    public partial class frmSpikeOrder : BaseForm
    {
       enum enumFormMode { Load, New, Update };
        enumFormMode formMode;
        DataTable dtSpikeOrder, dtOK;
        string _KodeBarang, _spike;
        bool Closing;

        public frmSpikeOrder(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }
        public frmSpikeOrder(Form caller, string kodeBarang, bool CLosing_)
        {
            InitializeComponent();
            formMode = enumFormMode.Load;
            _KodeBarang = kodeBarang;
            this.Caller = caller;
            Closing = CLosing_;
        }


        private void frmSpikeOrder_Load(object sender, EventArgs e)
        {
            //dtOK= new DataTable();
            this.Title = "SPIKE ORDER";
            try
            {
                dtSpikeOrder = new DataTable();
                DataTable dt1 = new DataTable();
                using (Database db = new Database())
                {
                    if (formMode == enumFormMode.Load)
                    {
                        db.Commands.Add(db.CreateCommand("usp_POSpikeOrder"));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _KodeBarang));
                        dtSpikeOrder = db.Commands[0].ExecuteDataTable();
                    }

                }

                if (formMode == enumFormMode.Load)
                {

                    txtNamaStok.Text = dtSpikeOrder.Rows[0]["NamaStok"].ToString();
                    txtIdBarang.Text = dtSpikeOrder.Rows[0]["BarangID"].ToString();
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            frmGetDetailPO frmCaller = (frmGetDetailPO)this.Caller;
            this.Close();
            this.Spike = this.txtSpikeOrder.Text;
            this.keterangan = this.txtKeterangan.Text.Replace(Environment.NewLine, string.Empty).TrimEnd();
            this.DialogResult = DialogResult.OK;
        }
        public string Spike = null;
        public string keterangan = null;


    }
}
