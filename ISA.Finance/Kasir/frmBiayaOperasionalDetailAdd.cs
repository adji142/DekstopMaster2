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
    public partial class frmBiayaOperasionalDetailAdd : ISA.Controls.BaseForm
    {
        private Guid _headerRowId;

        private Guid _rowId;
        public Guid RowId
        {
            get { return _rowId; }
        }

        public frmBiayaOperasionalDetailAdd(Guid headerRowId)
        {
            _rowId = Guid.Empty;
            _headerRowId = headerRowId;

            InitializeComponent();
        }

        private StringBuilder GetMessages()
        {
            StringBuilder sb = new StringBuilder();

            if (lookupPerkiraan1.NamaPerkiraan.Trim() == string.Empty)
                sb.AppendLine("Uraian harus diisi.");

            if (txtRpBiaya.Text == string.Empty || txtRpBiaya.Text == "0")
                sb.AppendLine("Rp Biaya harus diisi.");

            return sb;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (lookupPerkiraan1.NoPerkiraan.Trim() == "[CODE]")
            {
                MessageBox.Show("Uraian belum benar");
                return;
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

                Guid rowId = Guid.NewGuid();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_BiayaOperasionalDetail_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowId));
                    db.Commands[0].Parameters.Add(new Parameter("@BiayaOperasionalRowID", SqlDbType.UniqueIdentifier, _headerRowId));
                    db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, lookupPerkiraan1.NamaPerkiraan.Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@RpBiaya", SqlDbType.Money, txtRpBiaya.GetDoubleValue));
                    //db.Commands[0].Parameters.Add(new Parameter("@RpBiayaAcc", SqlDbType.Money, txtRpBiayaAcc.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text.Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, lookupPerkiraan1.NoPerkiraan.Trim()));
                    db.Commands[0].ExecuteNonQuery();
                }

                _rowId = rowId;

                this.Close();
            }
            catch (Exception ex) { Error.LogError(ex); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
