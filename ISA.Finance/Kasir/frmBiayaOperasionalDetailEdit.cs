using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Common;
using ISA.DAL;

namespace ISA.Finance.Kasir
{
    public partial class frmBiayaOperasionalDetailEdit : ISA.Controls.BaseForm
    {
        private Guid _rowId;
        DataTable dtSisaBudget;
        DateTime _Tanggal;
        string _NoPerkiraan;
        string _Uraian;

        public frmBiayaOperasionalDetailEdit(Guid rowID, DateTime Tanggal, string NoPerkiraan, string Uraian)
        {
            _rowId = rowID;
            _Tanggal = Tanggal;
            _NoPerkiraan = NoPerkiraan;
            _Uraian = Uraian;

            InitializeComponent();
        }

        private void frmBiayaOperasionalDetailEdit_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                DataTable dt = new DataTable();

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_BiayaOperasionalDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowId));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];

                    txtUraian.Text = dr["Uraian"].ToString();
                    txtRpBiaya.Text = dr["RpBiaya"].ToString();
                    txtRpBiayaAcc.Text = Tools.isNull(dr["RpBiayaAcc"], "0").ToString();
                    if (txtRpBiayaAcc.Text == "0")
                        txtRpBiayaAcc.Text = txtRpBiaya.Text;
                    txtKeterangan.Text = Tools.isNull(dr["Keterangan"], string.Empty).ToString();
                }
            }
            catch (Exception ex) { Error.LogError(ex); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private StringBuilder GetMessages()
        {
            StringBuilder sb = new StringBuilder();

            if (txtRpBiayaAcc.GetDoubleValue > txtRpBiaya.GetDoubleValue)
                sb.AppendLine("Rp Biaya ACC lebih besar dari Rp Biaya.");

            return sb;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKeterangan.Text))
            {
                MessageBox.Show("Keterangan tidak boleh kosong");
                txtKeterangan.Focus();
                return;
            }

            SisaBudget();

            if (dtSisaBudget.Rows.Count == 0)
            {
                MessageBox.Show("Budget biaya operasional belum diisi");
                return;
            }

            double _SisaBudget = double.Parse(dtSisaBudget.Rows[0]["SisaBudget"].ToString());

            //if (_SisaBudget < txtRpBiayaAcc.GetDoubleValue)
            if (_SisaBudget < 0)
            {
                MessageBox.Show("Biaya " + _Uraian + " Over Budget Rp " + _SisaBudget.ToString("#,##0") + "\nSegera minta ACC PSHO");
            }

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                StringBuilder sb = GetMessages();
                if (sb.Length > 0)
                {
                    MessageBox.Show(sb.ToString());
                    return;
                }
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_BiayaOperasionalDetail_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowId));
                    db.Commands[0].Parameters.Add(new Parameter("@RpBiayaAcc", SqlDbType.Money, txtRpBiayaAcc.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text.Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@SisaBudget", SqlDbType.Money, _SisaBudget));
                    db.Commands[0].ExecuteNonQuery();
                }

                this.Close();
            }
            catch (Exception ex) { Error.LogError(ex); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SisaBudget()
        {
            try
            {
                dtSisaBudget = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_BiayaOperasionalDetail_CekSisaBudget"));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, _Tanggal));
                    db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, _NoPerkiraan));
                    db.Commands[0].Parameters.Add(new Parameter("@RpBiayaAcc", SqlDbType.Money, txtRpBiayaAcc.GetDoubleValue));
                    dtSisaBudget = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

    }
}
