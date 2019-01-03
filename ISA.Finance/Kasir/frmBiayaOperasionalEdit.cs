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
    public partial class frmBiayaOperasionalEdit : ISA.Controls.BaseForm
    {
        private Guid _rowId;

        public frmBiayaOperasionalEdit(Guid rowId)
        {
            _rowId = rowId;
            InitializeComponent();
        }

        private void frmBiayaOperasionalEdit_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                DataTable dt = new DataTable();

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_BiayaOperasional_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowId));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];

                    txtPos.Text = GlobalVar.PerusahaanID;
                    txtTanggal.DateValue = (DateTime)dr["Tanggal"];
                    txtNomor.Text = dr["Nomor"].ToString();
                    txtNama.Text = dr["Nama"].ToString();
                    //txtUnitKerja.Text = dr["UnitKerja"].ToString();
                    txtKeperluan.Text = dr["Keperluan"].ToString();
                }
            }
            catch (Exception ex) { Error.LogError(ex); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private StringBuilder GetMessages()
        {
            StringBuilder sb = new StringBuilder();

            if (txtKeperluan.Text.Trim() == string.Empty)
                sb.AppendLine("Keperluan harus diisi.");

            return sb;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
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
                    db.Commands.Add(db.CreateCommand("usp_BiayaOperasional_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowId));
                    db.Commands[0].Parameters.Add(new Parameter("@Keperluan", SqlDbType.VarChar, txtKeperluan.Text.Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();

                    this.Close();
                }
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
