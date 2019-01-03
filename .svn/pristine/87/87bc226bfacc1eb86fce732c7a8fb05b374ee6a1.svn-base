using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using ISA.DAL;
using ISA.Common;
using ISA.Finance.Class;
using ISA.Finance.DataTemplates;
using Microsoft.Reporting.WinForms;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using System.Data.SqlClient;

namespace ISA.Finance.Tac
{
    public partial class frmKotaTmp : ISA.Controls.BaseForm
    {
        DataTable dtk;

        public frmKotaTmp()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKotaTmp_Load(object sender, EventArgs e)
        {
            InitializeComponents();
            RefreshData(); 
        }

        public void RefreshData()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_GetKota_LIST"));
                dt = db.Commands[0].ExecuteDataTable();
            }
            customGridView1tmp.DataSource = dt.DefaultView;
        }

        public void InitializeComponents()
        {
            this.Location = new Point(500, 250);
        }

        private void customGridView1tmp_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    string cFlag = Tools.isNull(customGridView1tmp.SelectedCells[0].OwningRow.Cells["Flag"].Value,"").ToString();
                    if (cFlag == "1")
                    {
                        cFlag = "";
                        customGridView1tmp.SelectedCells[0].OwningRow.DefaultCellStyle.BackColor = Color.White;
                    }
                    else
                    {
                        cFlag = "1";
                        customGridView1tmp.SelectedCells[0].OwningRow.DefaultCellStyle.BackColor = Color.Cyan;
                    }
                    customGridView1tmp.SelectedCells[0].OwningRow.Cells["Flag"].Value = cFlag;
                    break;
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (customGridView1tmp.Rows.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        int index = 0;

                        foreach (DataGridViewRow row in customGridView1tmp.Rows)
                        {
                            string cFlag = Tools.isNull(row.Cells[Flag.Name].Value, string.Empty).ToString();
                            if (cFlag == "1")
                            {
                                db.Commands.Add(db.CreateCommand("usp_Kota_INSERT"));
                                db.Commands[index].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, row.Cells[Kota.Name].Value.ToString()));
                                db.Commands[index].Parameters.Add(new Parameter("@LastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserID));
                                index++;
                            }
                        }

                        db.BeginTransaction();
                        foreach (Command cmd in db.Commands)
                        {
                            cmd.ExecuteNonQuery();
                        }
                        db.CommitTransaction();

                        //this.DialogResult = DialogResult.OK;
                        //this.Close();
                    }
                }
                catch (Exception ex) { Error.LogError(ex); }
                finally { Cursor.Current = Cursors.Default; }


                //Update Tabel tac_TOKO
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    dtk = new DataTable(GlobalVar.DBName);
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_KotaToko_LIST"));
                        dtk = db.Commands[0].ExecuteDataTable();
                    }
                }
                catch (Exception ex) { Error.LogError(ex); }
                finally { Cursor.Current = Cursors.Default; }


                if (dtk.Rows.Count > 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            int index = 0;

                            foreach (DataRow dr in dtk.Rows)
                            {
                                db.Commands.Add(db.CreateCommand("usp_KotaToko_INSERT"));
                                db.Commands[index].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["KodeToko"],"").ToString()));
                                db.Commands[index].Parameters.Add(new Parameter("@NamaToko", SqlDbType.VarChar, Tools.isNull(dr["NamaToko"], "").ToString()));
                                db.Commands[index].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, Tools.isNull(dr["Alamat"], "").ToString()));
                                db.Commands[index].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, Tools.isNull(dr["Kota"], "").ToString()));
                                db.Commands[index].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, Tools.isNull(dr["WilID"], "").ToString()));
                                db.Commands[index].Parameters.Add(new Parameter("@TokoID", SqlDbType.VarChar, Tools.isNull(dr["TokoID"], "").ToString()));
                                db.Commands[index].Parameters.Add(new Parameter("@Daerah", SqlDbType.VarChar, Tools.isNull(dr["Daerah"], "").ToString()));
                                db.Commands[index].Parameters.Add(new Parameter("@Propinsi", SqlDbType.VarChar, Tools.isNull(dr["Propinsi"], "").ToString()));
                                db.Commands[index].Parameters.Add(new Parameter("@LastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserID));
                                index++;
                            }

                            db.BeginTransaction();
                            foreach (Command cmd in db.Commands)
                            {
                                cmd.ExecuteNonQuery();
                            }
                            db.CommitTransaction();

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    catch (Exception ex) { Error.LogError(ex); }
                    finally { Cursor.Current = Cursors.Default; }
                }

            }
        }
   }
}
