using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Pembelian
{
    public partial class frmNotaBeliInput : ISA.Controls.BaseForm
    {
        Class.Enums.enumClsState _state;
        Guid _rowID;

        public Guid RowID { get { return _rowID; } set { _rowID = value; } }

        public frmNotaBeliInput()
        {
            InitializeComponent();
        }

        public frmNotaBeliInput(Class.Enums.enumClsState tState, Guid tRowID)
        {
            _state = tState;
            _rowID = tRowID;
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNotaBeliInput_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = DBTools.DBGetDataTable("usp_Pemasok_LIST", new List<Parameter>());
                cboSupplier.DisplayMember = "Nama";
                cboSupplier.ValueMember = "PemasokID";
                cboSupplier.DataSource = dt;

                dt = DBTools.DBGetDataTableByRowID("usp_NotaPembelian_LIST", _rowID);
                switch (_state)
                {
                    case Class.Enums.enumClsState.New:
                        txtTanggal.DateValue = GlobalVar.DateOfServer;
                        break;
                    case Class.Enums.enumClsState.Update:
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = dt.Rows[0];
                            txtTanggal.DateValue = (DateTime)DateTime.Parse(dr["TglNota"].ToString());
                            txtNoBukti.Text = dr["NoNota"].ToString();
                            cboSupplier.SelectedValue = dr["Pemasok"].ToString();
                            txtTOP.Value = int.Parse(dr["HariKredit"].ToString());
                            txtCatatan.Text = dr["Catatan"].ToString();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void commonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void smdSave_Click(object sender, EventArgs e)
        {
            using (Database db = new Database())
            try
            {
                Command cmd = db.CreateCommand((_state==Class.Enums.enumClsState.New)?"usp_NotaPembelian_INSERT":"usp_NotaPembelian_UPDATE");
                cmd.AddParameter("@RowID", SqlDbType.UniqueIdentifier, _rowID);
	            cmd.AddParameter("@recordID", SqlDbType.VarChar, "");
	            cmd.AddParameter("@noRequest", SqlDbType.VarChar, "");
	            cmd.AddParameter("@tglRequest", SqlDbType.DateTime, null);
	            cmd.AddParameter("@noDO", SqlDbType.VarChar,"");
	            cmd.AddParameter("@tglTransaksi", SqlDbType.DateTime, txtTanggal.DateValue);
	            cmd.AddParameter("@noNota", SqlDbType.VarChar, txtNoBukti.Text);
	            cmd.AddParameter("@tglNota", SqlDbType.DateTime, txtTanggal.DateValue);
	            cmd.AddParameter("@noSuratJalan", SqlDbType.VarChar, "");
	            cmd.AddParameter("@tglSuratJalan", SqlDbType.DateTime, txtTanggal.DateValue);
	            cmd.AddParameter("@tglTerima", SqlDbType.DateTime, null);
	            cmd.AddParameter("@disc1", SqlDbType.Decimal,0);
	            cmd.AddParameter("@disc2", SqlDbType.Decimal,0); 
	            cmd.AddParameter("@disc3", SqlDbType.Decimal,0); 
	            cmd.AddParameter("@discFormula", SqlDbType.VarChar,"");
	            cmd.AddParameter("@hariKredit", SqlDbType.Int,txtTOP.Value);
	            cmd.AddParameter("@ppn", SqlDbType.Decimal,0);
	            cmd.AddParameter("@pemasok", SqlDbType.VarChar,cboSupplier.SelectedValue.ToString());
	            cmd.AddParameter("@expedisi", SqlDbType.VarChar,"");
	            cmd.AddParameter("@cabang", SqlDbType.VarChar,"");
	            cmd.AddParameter("@catatan", SqlDbType.VarChar,txtCatatan.Text);
	            cmd.AddParameter("@isClosed", SqlDbType.Bit,false);
	            cmd.AddParameter("@syncFlag", SqlDbType.Bit,false);
                cmd.AddParameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID);

                object o = cmd.ExecuteNonQuery();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
    }
}
