using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using ISA.Trading.Class;



namespace ISA.Trading.Communicator
{
    public partial class frmBonusPengajuanKe11Upload : ISA.Trading.BaseForm
    {
        DataTable dt;
        string _dbfName = "Bnstmp", _txtName = "UplBns";
        string _fileZip = GlobalVar.DbfUpload + "\\ACCBNS.zip";

        public frmBonusPengajuanKe11Upload()
        {
            InitializeComponent();
        }

        private void frmBonusPengajuanKe11Upload_Load(object sender, EventArgs e)
        {
            this.Title = "ACC Bonus Upload";
            this.Text = "Pengajuan ke 11";
            dataGridView1.AutoGenerateColumns = false;
            RefreshDataPerolehanBonus();
        }

        private void RefreshDataPerolehanBonus()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PerolehanBonusSales_UPLOAD"));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                dataGridView1.DataSource = dt;
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

        private void UploadDBF()
        {
            string dbfFile = GlobalVar.DbfUpload + "\\" + _dbfName + ".dbf";

            if (File.Exists(dbfFile))
            {
                File.Delete(dbfFile);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("KodeSales", "kd_sales", Foxpro.enFoxproTypes.Char,11));
            fields.Add(new Foxpro.DataStruct("Periode", "periode", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("Tanggal", "tanggal", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("NoACC", "no_acc", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("TglACC", "tgl_acc", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("RpBonus", "rp_bonus", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("RpACC", "rp_acc", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("nPrint", "nprint", Foxpro.enFoxproTypes.Numeric, 1));
            fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("LinkID", "id_link", Foxpro.enFoxproTypes.Char, 1));

            Foxpro.WriteFile(GlobalVar.DbfUpload, _dbfName, fields, dt, progressBar1); 
        }

        private void UploadTXT()
        {
            string txtFile = GlobalVar.DbfUpload + "\\" + _txtName + ".txt";

            if (File.Exists(txtFile))
            {
                File.Delete(txtFile);
            }

            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(txtFile, false);

                #region WriteFile

                string periode = "";
                if (dt.Rows.Count != 0)
                {
                    periode = dt.Rows[0]["Periode"].ToString();
                }

                sw.Write(System.Environment.NewLine + "PENGAJUAN ACC BONUS");
                sw.Write(System.Environment.NewLine + "PERIODE  : " + periode);
                sw.Write(System.Environment.NewLine + "-- 00 -- : " + GlobalVar.CabangID);
                sw.Write(System.Environment.NewLine + "============================================================================");
                sw.Write(System.Environment.NewLine + "|     |            |             |             |               |           |");
                sw.Write(System.Environment.NewLine + "| NO. |    SALES   | TOTAL BONUS | TOTAL BONUS |   NO.ACC 11   |  TGL.ACC  |");
                sw.Write(System.Environment.NewLine + "|     |            | YG DIAJUKAN | YG DITERIMA |               |           |");
                sw.Write(System.Environment.NewLine + "|     |            |             |             |               |           |");
                sw.Write(System.Environment.NewLine + "----------------------------------------------------------------------------");

                double totBonus=0, totACC=0;
                for (int i=0; i<dt.Rows.Count; i++)
                {
                    int no = i+1;
                    double rpBonus = double.Parse(dt.Rows[i]["RpBonus"].ToString());
                    double rpACC = double.Parse(dt.Rows[i]["RpACC"].ToString());
                    string tglACC = "";
                    if (Tools.isNull(dt.Rows[i]["RpACC"], "").ToString() == "")
                        tglACC = ((DateTime)dt.Rows[i]["RpACC"]).ToString("dd-MMM-yyyy");
                    totBonus = totBonus + rpBonus;
                    totACC = totACC + rpACC;

                    sw.Write(System.Environment.NewLine + "| " + no.ToString().PadLeft(4));
                    sw.Write("| " + dt.Rows[i]["kodeSales"].ToString().PadRight(11)); 
                    sw.Write("|  " + rpBonus.ToString("#,##0").PadLeft(11)); 
                    sw.Write("|  " + rpACC.ToString("#,##0").PadLeft(11)); 
                    sw.Write("|" + dt.Rows[i]["NoACC"].ToString().PadRight(10)); 
                    sw.Write("     |" + tglACC.PadRight(11)); 
                    sw.Write("|"); 
                }

                sw.Write(System.Environment.NewLine + "----------------------------------------------------------------------------");
                sw.Write(System.Environment.NewLine + "|                  |  " + totBonus.ToString("#,##0").PadLeft(11));
                sw.Write("|  " + totACC.ToString("#,##0").PadLeft(11) + "|               |           |");
                sw.Write(System.Environment.NewLine + "============================================================================");
                sw.Write(System.Environment.NewLine + "");
            
                #endregion

                sw.WriteLine();
                sw.Close();

                System.Diagnostics.Process.Start(txtFile);

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void ZipFiles()
        {
            List<string> files = new List<string>();

            string fileDBF = GlobalVar.DbfUpload + "\\" + _dbfName + ".dbf";
            string fileTXT = GlobalVar.DbfUpload + "\\" + _txtName + ".txt";

            files.Add(fileDBF);
            files.Add(fileTXT);

            if (File.Exists(_fileZip))
            {
                File.Delete(_fileZip);
            }

            Zip.ZipFiles(files, _fileZip);

            if (File.Exists(fileDBF))
            {
                File.Delete(fileDBF);
            }
        }

        private void UpdatedPerolehanBonusSyncFlag()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor; 
                using(Database db = new Database())
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        db.Commands.Add(db.CreateCommand("usp_PerolehanBonusSales_UPDATE"));
                        db.Commands[i].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, dt.Rows[i]["RowID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, true));
                        db.Commands[i].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    }

                    db.BeginTransaction();
                    for (int j = 0; j < db.Commands.Count; j++)
                    {
                        db.Commands[j].ExecuteNonQuery();
                    }
                    db.CommitTransaction();
                } 
                if (MessageBox.Show("Kirim Hasil Upload di " + _fileZip, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.None) == DialogResult.OK)
                {
                    this.Close();
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
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                UploadDBF();
                UploadTXT();
                ZipFiles();
                UpdatedPerolehanBonusSyncFlag();                
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

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
