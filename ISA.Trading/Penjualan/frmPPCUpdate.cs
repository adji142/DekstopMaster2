using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlTypes;

namespace ISA.Trading.Penjualan
{
    public partial class frmPPCUpdate : ISA.Trading.BaseForm
    {
        DataRow _row;
        Guid _doID, _rowID;
        string _htrID;

        public frmPPCUpdate(Form caller, DataRow row, Guid doID, string htrID)
        {
            InitializeComponent();
            _row = row;
            _doID = doID;
            _htrID = htrID;
            this.Caller = caller;
        }

        private void frmPPCUpdate_Load(object sender, EventArgs e)
        {
            txtBarangID.Text = _row["BarangID"].ToString();
            txtNamaBarang.Text = _row["NamaBarang"].ToString();
            txtQtySisa.Text = _row["QtySisa"].ToString();
            txtQtyDO.Text = _row["QtySisa"].ToString();            
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (txtQtyDO.GetIntValue == 0 || txtQtyDO.GetIntValue > txtQtySisa.GetIntValue)
            {
                txtQtyDO.Text = txtQtySisa.Text;
                txtQtyDO.Focus();
                return;
            }

            string _doDetailRecID = Tools.CreateFingerPrint();
            bool find = FindDOinDPJPPC();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    _rowID = Guid.NewGuid();
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _doID));
                    db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, _doDetailRecID));
                    db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, _htrID));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _row["BarangID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@qtyRequest", SqlDbType.Int, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@qtyDO", SqlDbType.Int, _row["QtyDO"]));
                    db.Commands[0].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _row["KodeToko"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglSuratJalan", SqlDbType.DateTime ,SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal ,0));
                    db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@pot", SqlDbType.Money, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@noDOBO", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    if (find)
                    {
                        db.Commands.Add(db.CreateCommand("usp_DPJPPC_INSERT"));
                        db.Commands[1].Parameters.Add(new Parameter("@doDetailRecID", SqlDbType.VarChar, _doDetailRecID));
                        db.Commands[1].Parameters.Add(new Parameter("@doHtrID", SqlDbType.VarChar, _htrID));
                        db.Commands[1].Parameters.Add(new Parameter("@HPCID", SqlDbType.VarChar, ""));
                        db.Commands[1].Parameters.Add(new Parameter("@PPCID", SqlDbType.VarChar, _row["JRecID"]));
                        db.Commands[1].Parameters.Add(new Parameter("@RPPCRecID", SqlDbType.VarChar, _row["RRecID"]));
                        db.Commands[1].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _row["BarangID"]));
                        db.Commands[1].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _row["KodeToko"]));
                        db.Commands[1].Parameters.Add(new Parameter("@qtyDO", SqlDbType.Int, txtQtyDO.GetIntValue));
                        db.Commands[1].Parameters.Add(new Parameter("@qtySJ", SqlDbType.Int, 0));
                    }

                    db.BeginTransaction();
                    db.Commands[0].ExecuteNonQuery();
                    if (find)
                    {
                        db.Commands[1].ExecuteNonQuery();
                    }
                    db.CommitTransaction();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
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

        private bool FindDOinDPJPPC()
        {
            bool find = false;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_DPJPPC_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@doHtrID", SqlDbType.VarChar, _htrID));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count > 0)
                    {
                        find = true;
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

            return find;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void frmPPCUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                TabelDO frmCaller = (TabelDO)this.Caller;
                frmCaller.RefreshDataDetailDO();
                frmCaller.FindHeader("RowID", _rowID.ToString());
            }
        }

        private void txtQtyDO_Validating(object sender, CancelEventArgs e)
        {
            if (txtQtyDO.Text == "")
                txtQtyDO.Text = txtQtySisa.Text;
        }
    }
}
