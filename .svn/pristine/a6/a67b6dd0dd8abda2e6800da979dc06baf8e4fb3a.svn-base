using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ISA.DAL;
using ISA.Common;
using System.IO;
using System.Windows.Forms;

namespace ISA.Finance.Kasir.Budget
{
    public partial class frmPerkiraanAccBiaya : ISA.Controls.BaseForm
    {
        enum enumModus { New, Update, Clear };
        enumModus Modus = enumModus.Clear;
        protected DataTable dtPerkiraan;

        public frmPerkiraanAccBiaya()
        {
            InitializeComponent();
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPerkiraanBudget_Load(object sender, EventArgs e)
        {
            SetupEnableDisable();
            RefreshGrid();
        }

        #region functions
        private void SetupEnableDisable()
        {
            panel1.Enabled = Modus != enumModus.Clear;
            cmdADD.Enabled = false; //Modus == enumModus.Clear;
            cmdEDIT.Enabled = false; // Modus == enumModus.Clear && dgPerkiraan.RowCount > 0;
            cmdDELETE.Enabled = false; // Modus == enumModus.Clear && dgPerkiraan.RowCount > 0;
            cmdSAVE.Enabled = Modus != enumModus.Clear;
            cmdCANCEL.Enabled = Modus != enumModus.Clear;
            cmdDOWNLOAD.Enabled = Modus == enumModus.Clear;
        }
        private void RefreshGrid()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_AccBy_Tabel_LIST"));
                dt = db.Commands[0].ExecuteDataTable();
                dgPerkiraan.DataSource = dt;
            }
        }
        private void RefreshText()
        {
            if (dgPerkiraan.SelectedCells.Count > 0)
            {
                lookupPerkiraan1.NoPerkiraan = dgPerkiraan.SelectedCells[0].OwningRow.Cells["NoPerkiraan"].Value.ToString();
                lookupPerkiraan1.NamaPerkiraan = dgPerkiraan.SelectedCells[0].OwningRow.Cells["Uraian"].Value.ToString();
            }
        }
        private DataTable ValidateFile(string fileName, DataTable table)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    table = Foxpro.ReadFile(fileName);

                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show("File: " + fileName + " tidak ditemukan !");
                table = null;
            }
            return table;
        }
        private bool CekISA(DataTable dt)
        {
            bool YesISA = false;
            int JmlField = dt.Columns.Count;
            for (int n = 0; n <= JmlField - 1; n++)
            {
                if (dt.Columns[n].ColumnName.ToLower() == "Rowid")
                {
                    YesISA = true;
                }
            }
            return YesISA;
        }
        #endregion

        private void cmdADD_Click(object sender, EventArgs e)
        {
            Modus = enumModus.New;
            lookupPerkiraan1.NamaPerkiraan = "";
            SetupEnableDisable();
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            Modus = enumModus.Update;
            SetupEnableDisable();
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            if ( MessageBox.Show("Anda yakin?", "Hapus data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes )
            {
                Guid _RowID = (Guid)dgPerkiraan.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_AccBy_Tabel_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].ExecuteNonQuery();
                }
                SetupEnableDisable();
                RefreshGrid();
                RefreshText();
            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            Guid _RowID = Guid.Empty;
            if (Modus == enumModus.Update) _RowID = (Guid)dgPerkiraan.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            string _NoPerkiraan = lookupPerkiraan1.NoPerkiraan;
            string _Uraian = lookupPerkiraan1.NamaPerkiraan;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_AccBy_Tabel_UPDATE"));
                if (Modus == enumModus.Update) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, _NoPerkiraan));
                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, _Uraian));
                db.Commands[0].ExecuteNonQuery();
            }
            Modus = enumModus.Clear;
            SetupEnableDisable();
            RefreshGrid();
            RefreshText();
        }

        private void cmdCANCEL_Click(object sender, EventArgs e)
        {
            Modus = enumModus.Clear;
            SetupEnableDisable();
            RefreshText();
        }

        private void dgPerkiraan_SelectionChanged(object sender, EventArgs e)
        {
            SetupEnableDisable();
            RefreshText();
        }

        private void cmdDOWNLOAD_Click(object sender, EventArgs e)
        {
            string fileZipName = GlobalVar.DbfDownload + "\\tbKodePerkiraanACCBiaya.zip";
            string _tempPath  = GlobalVar.DbfDownload + "\\AccBy\\";
            if (!Directory.Exists(_tempPath)) Directory.CreateDirectory(_tempPath);
            else
            {
                string[] files = Directory.GetFiles(_tempPath);
                foreach (string file in files)
                {
                    File.Delete(file);
                }
            }

            if (File.Exists(fileZipName))
            {
                Zip.UnZipFiles(fileZipName, _tempPath, false);
            }
            else
            {
                MessageBox.Show("Tidak ditemukan file " + fileZipName);
                return;
            }
            string fileName = _tempPath + "BiayaTmp.DBF";
            DataTable result = ValidateFile(fileName, dtPerkiraan);
            bool YesISA = CekISA(result);
            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("psp_AccBy_DownloadPerkiraan"));
                    foreach (DataRow dr in result.Rows)
                    {

                        db.Commands[0].Parameters.Clear();
                        if (YesISA == true) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.VarChar, Tools.isNull(dr["RowID"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(dr["No_perk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr["Uraian"], "").ToString().Trim()));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("Proses download telah selesai!");
            RefreshGrid();
            RefreshText();
        }

    }
}
