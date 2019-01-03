using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance.Kasir
{
    public partial class frmBiayaOperasionalAdd : ISA.Controls.BaseForm
    {
        private Guid _headerRowId;
        string cekjnstr = "0";
        public Guid HeaderRowId
        {
            get { return _headerRowId; }
        }

        public frmBiayaOperasionalAdd()
        {
            _headerRowId = Guid.Empty;
            InitializeComponent();
        }

        private void frmBiayaOperasionalAdd_Load(object sender, EventArgs e)
        {
            txtPos.Text = GlobalVar.PerusahaanID;
            txtTanggal.Text = GlobalVar.DateOfServer.ToString("dd/MM/yyyy");
            cekjnstr = Class.AppSetting.GetValue("JnsTransaksi");
        }

        private void lupStaff_SelectData(object sender, EventArgs e)
        {
            //txtUnitKerja.Text = lupStaff.Unitkerja.Trim();
        }

        private void txtUnitKerja_TextChanged(object sender, EventArgs e)
        {
            //txtKeperluan.Text = "OPERASIONAL " + txtUnitKerja.Text;
        }

        private StringBuilder GetMessages()
        {
            StringBuilder sb = new StringBuilder();

            if (lupStaff.Nama.Trim() == string.Empty)
                sb.AppendLine("Nama harus diisi.");

            //if (txtUnitKerja.Text.Trim() == string.Empty)
            //    sb.AppendLine("Unit kerja harus diisi.");

            if (txtKeperluan.Text.Trim() == string.Empty)
                sb.AppendLine("Keperluan harus diisi.");

            if (dgvDetail.Rows.Count == 0)
                sb.AppendLine("Biaya Operasional Detail harus diisi.");

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

                Guid rowId = Guid.NewGuid();
                string nomor = Numerator.GetNumeratorPeriode("BIAYA_OPERASIONAL");
                string publicKey = ISA.Pin.Generator.CreateKey(GlobalVar.Gudang + Class.PinId.ModulId.BiayaOperasional);
                string recordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                string KodeGudang = GlobalVar.Gudang;

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.BeginTransaction();

                    try
                    {
                        db.Commands.Add(db.CreateCommand("usp_BiayaOperasional_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowId));
                        db.Commands[0].Parameters.Add(new Parameter("@NIP", SqlDbType.VarChar, lupStaff.Nip.Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, lupStaff.Nama.Trim()));
                        //db.Commands[0].Parameters.Add(new Parameter("@UnitKerja", SqlDbType.VarChar, txtUnitKerja.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Nomor", SqlDbType.VarChar, nomor));
                        db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, txtTanggal.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@Keperluan", SqlDbType.VarChar, txtKeperluan.Text.Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@PublicKey", SqlDbType.VarChar, publicKey));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, KodeGudang));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, recordID));
                        db.Commands[0].ExecuteNonQuery();

                        int counter = 0;
                        foreach (DataGridViewRow row in dgvDetail.Rows)
                        {
                            Guid rowIdDet = Guid.NewGuid();
                            string uraian = Tools.isNull(row.Cells["Uraian"].Value, string.Empty).ToString();
                            double rpBiaya = double.Parse(Tools.isNull(row.Cells["RpBiaya"].Value, "0").ToString().Replace(",", string.Empty).Replace(".", string.Empty));
                            string keterangan = Tools.isNull(row.Cells["Keterangan"].Value, string.Empty).ToString();
                            string NoPerkiraan = Tools.isNull(row.Cells["NoPerkiraan"].Value, string.Empty).ToString();

                            if (uraian != string.Empty && rpBiaya > 0)
                            {
                                counter++;

                                db.Commands.Add(db.CreateCommand("usp_BiayaOperasionalDetail_INSERT"));
                                db.Commands[counter].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowIdDet));
                                db.Commands[counter].Parameters.Add(new Parameter("@BiayaOperasionalRowID", SqlDbType.UniqueIdentifier, rowId));
                                db.Commands[counter].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, uraian.ToUpper()));
                                db.Commands[counter].Parameters.Add(new Parameter("@RpBiaya", SqlDbType.Money, rpBiaya));
                                db.Commands[counter].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, keterangan.ToUpper()));
                                db.Commands[counter].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[counter].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, NoPerkiraan.ToUpper()));
                                db.Commands[counter].ExecuteNonQuery();
                            }
                        }

                        db.CommitTransaction();
                        //txtUraian.Text = Uraian.ToString();
                        txtNomor.Text = nomor;
                        _headerRowId = rowId;

                        MessageBox.Show(Messages.Confirm.UpdateSuccess);

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        db.RollbackTransaction();
                        Cursor.Current = Cursors.Default;
                        Error.LogError(ex);
                    }
                }
            }
            catch (Exception ex) { Error.LogError(ex); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == RpBiaya.Index)
            {
                try
                {
                    double totalBiaya = 0;

                    foreach (DataGridViewRow row in dgvDetail.Rows)
                    {
                        if (row.Cells[RpBiaya.Index].Value != null)
                        {
                            totalBiaya += double.Parse(Tools.isNull(row.Cells[RpBiaya.Index].Value, "0").ToString());
                        }
                    }

                    txtTotalBiaya.Text = totalBiaya.ToString();
                }
                catch (Exception ex) { Error.LogError(ex); }

            }
        }

        private void txtUraian_Leave(object sender, EventArgs e)
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                DataTable dt = new DataTable();

                if (cekjnstr == "1")
                {
                    db.Commands.Add(db.CreateCommand("usp_PerkiraanJenistransaksi_LOOKUP"));
                }
                else
                {
                    db.Commands.Add(db.CreateCommand("usp_PerkiraanBiaya_LOOKUP"));
                }
                db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtUraian.Text));
                dt = db.Commands[0].ExecuteDataTable();
                dgvDetail.DataSource = dt;
                txtTotalBiaya.Text = "0";
            }
        }

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvDetail_DoubleClick(object sender, EventArgs e)
        {
            txtUraian.Text = dgvDetail.SelectedCells[0].OwningRow.Cells["Uraian"].Value.ToString();
        }


    }
}
