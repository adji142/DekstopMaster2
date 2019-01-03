using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.Master;
using System.Data.SqlTypes;

namespace ISA.Toko.Penjualan
{
    public partial class frmNotaJualDetailUpdate : ISA.Toko.BaseForm
    {
        Guid _RowID;
        DataTable dt = new DataTable();


        public frmNotaJualDetailUpdate()
        {
            InitializeComponent();
        }

        public frmNotaJualDetailUpdate(Form caller,Guid _rowID)
        {
            this.Caller = caller;
            _RowID = _rowID;
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmNotaJualDetailUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_LIST")); //udah cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count==0)
                {
                    return;
                }

                lookupStock1.NamaStock = dt.Rows[0]["NamaBarang"].ToString();
                lookupStock1.BarangID = dt.Rows[0]["BarangID"].ToString();
                numericTextBox1.Text = dt.Rows[0]["QtyDO"].ToString();
                numericTextBox2.Text = dt.Rows[0]["QtySuratJalan"].ToString();
                numericTextBox2.Focus();
              
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

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (numericTextBox2.GetIntValue == 0)
            {
                this.Close();
            }
            else
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_UPDATE")); // cek heri
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                        db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, (Guid)dt.Rows[0]["HeaderID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@doID", SqlDbType.UniqueIdentifier, (Guid)dt.Rows[0]["DoID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@doDetailID", SqlDbType.UniqueIdentifier, (Guid)dt.Rows[0]["DODetailID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, dt.Rows[0]["htrID"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@RecID", SqlDbType.VarChar, dt.Rows[0]["RecordID"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, dt.Rows[0]["BarangID"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, double.Parse(dt.Rows[0]["HrgJual"].ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, double.Parse(dt.Rows[0]["disc1"].ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, double.Parse(dt.Rows[0]["disc2"].ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, double.Parse(dt.Rows[0]["disc3"].ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@pot", SqlDbType.Money, double.Parse(dt.Rows[0]["pot"].ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, dt.Rows[0]["discFormula"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, dt.Rows[0]["KodeGudang"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@qtySJ", SqlDbType.Int, numericTextBox2.GetIntValue));
                        db.Commands[0].Parameters.Add(new Parameter("@qtyNota", SqlDbType.Int, int.Parse(dt.Rows[0]["qtyNota"].ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@qtyKoli", SqlDbType.Int, int.Parse(dt.Rows[0]["qtyKoli"].ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@koliAwal", SqlDbType.Int, int.Parse(dt.Rows[0]["koliAwal"].ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@koliAkhir", SqlDbType.Int, int.Parse(dt.Rows[0]["koliAkhir"].ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@noKoli", SqlDbType.VarChar, dt.Rows[0]["noKoli"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, dt.Rows[0]["catatan"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@ketKoli", SqlDbType.VarChar, dt.Rows[0]["ketKoli"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));


                        db.Commands[0].ExecuteNonQuery();
                    }
                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
                RefreshNotaDetail();
                this.Close();
            }
        }

        private void numericTextBox2_Validated(object sender, EventArgs e)
        {
            if (numericTextBox2.Text.Trim()=="")
            {
                numericTextBox2.Text = "0";
            }
        }

        private void RefreshNotaDetail()
        {
            frmNotaJualBrowser frmCaller = (frmNotaJualBrowser)this.Caller;
            frmCaller.RefreshDataNotaJualDetail();
            frmCaller.FindDetail("NotaDetailRowID", _RowID.ToString());
        }
    }
}
