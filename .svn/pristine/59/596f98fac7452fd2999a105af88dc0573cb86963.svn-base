using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance.GL
{
    public partial class frmGlReportDesign : ISA.Finance.BaseForm
    {
        string report;
        DataTable dtLookup, dtGL;
        public frmGlReportDesign()
        {
            InitializeComponent();
        }


        private void frmGlReportDesign_Load(object sender, EventArgs e)
        {
            itemLookup();

            dgGL.ReadOnly = false;
            dgGL.AllowUserToAddRows = true;
            dgGL.AllowUserToDeleteRows = true;
            dgGL.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            foreach (DataGridViewColumn col in dgGL.Columns)
            {
                col.ReadOnly = false;
            }

            dgGL.Columns["cRowID"].ReadOnly = true;
            dgGL.Columns["cReport"].ReadOnly = true;
            dgGL.Columns["cRef"].ReadOnly = true;
            
        }

        void dtGL_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            e.Row["RowID"] = Guid.NewGuid();
            e.Row["Report"] = cbLookup.Text;
            e.Row["Ref"] = "";
            e.Row["NoUrut"] = "";
            e.Row["Tipe"] = "";
            e.Row["Keterangan"] = "";
            e.Row["Catatan"] = "";
            e.Row["Formula"] = "";
            e.Row["LMinus"] = 1;
            e.Row["TUnderLine"] = false;
            e.Row["DUnderline"] = false;
            e.Row["Bold"] = false;
        }

        private void itemLookup()
        {
            try
            {
                dtLookup = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Lookup_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@lookupType", SqlDbType.VarChar, "GL_REPORT"));
                    dtLookup = db.Commands[0].ExecuteDataTable();
                }
                if (dtLookup.Rows.Count > 0)
                {
                    dtLookup.DefaultView.Sort = "Value";
                    cbLookup.DataSource = dtLookup.DefaultView;
                    cbLookup.DisplayMember = "Value";
                    cbLookup.BindingContext = this.BindingContext;
                }
                else
                {
                    cbLookup.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cbLookup_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            report = cbLookup.Text;
            try
            {
                dtGL = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_GLReportDesign_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@Report", SqlDbType.VarChar, report));
                    dtGL = db.Commands[0].ExecuteDataTable();
                }
                dtGL.TableNewRow += new DataTableNewRowEventHandler(dtGL_TableNewRow);
                
                    dtGL.DefaultView.Sort = "Report,NoUrut";
                    dgGL.DataSource = dtGL.DefaultView;
                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            
            DataTable dtInsert, dtUpdate, dtDelete;
            dtInsert = dtGL.GetChanges(DataRowState.Added);
            dtUpdate = dtGL.GetChanges(DataRowState.Modified);
            dtDelete = dtGL.GetChanges(DataRowState.Deleted);

            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.BeginTransaction();
                    if (dtInsert != null)
                    {
                        if (dtInsert.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtInsert.Rows)
                            {
                                        db.Commands.Clear();
                                        db.Commands.Add(db.CreateCommand("usp_GLReportDesign_INSERT"));
                                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dr["RowID"]));
                                        db.Commands[0].Parameters.Add(new Parameter("@Report", SqlDbType.VarChar, (string)dr["Report"]));
                                        db.Commands[0].Parameters.Add(new Parameter("@Ref", SqlDbType.VarChar, (string)dr["Ref"]));
                                        db.Commands[0].Parameters.Add(new Parameter("@NoUrut", SqlDbType.VarChar, (string)dr["NoUrut"]));
                                        db.Commands[0].Parameters.Add(new Parameter("@Tipe", SqlDbType.VarChar, (string)dr["Tipe"]));
                                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, (string)dr["Keterangan"]));
                                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, (string)dr["Catatan"]));
                                        db.Commands[0].Parameters.Add(new Parameter("@Formula", SqlDbType.VarChar, (string)dr["Formula"]));
                                        db.Commands[0].Parameters.Add(new Parameter("@LMinus", SqlDbType.Int, (int)dr["LMinus"]));
                                        db.Commands[0].Parameters.Add(new Parameter("@TUnderLine", SqlDbType.Bit, (Boolean)dr["TUnderLine"]));
                                        db.Commands[0].Parameters.Add(new Parameter("@DUnderline", SqlDbType.Bit, (Boolean)dr["DUnderline"]));
                                        db.Commands[0].Parameters.Add(new Parameter("@Bold", SqlDbType.Bit, (Boolean)dr["Bold"]));
                                        db.Commands[0].ExecuteNonQuery();
                                
                            }
                        }
                    }
                    if (dtUpdate != null)
                    {
                        if (dtUpdate.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtUpdate.Rows)
                            {
                                db.Commands.Clear();
                                db.Commands.Add(db.CreateCommand("usp_GLReportDesign_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dr["RowID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@Ref", SqlDbType.VarChar, (string)dr["Ref"]));
                                db.Commands[0].Parameters.Add(new Parameter("@NoUrut", SqlDbType.VarChar, (string)dr["NoUrut"]));
                                db.Commands[0].Parameters.Add(new Parameter("@Tipe", SqlDbType.VarChar, (string)dr["Tipe"]));
                                db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, (string)dr["Keterangan"]));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, (string)dr["Catatan"]));
                                db.Commands[0].Parameters.Add(new Parameter("@Formula", SqlDbType.VarChar, (string)dr["Formula"]));
                                db.Commands[0].Parameters.Add(new Parameter("@LMinus", SqlDbType.Int, (int)dr["LMinus"]));
                                db.Commands[0].Parameters.Add(new Parameter("@TUnderLine", SqlDbType.Bit, (Boolean)dr["TUnderLine"]));
                                db.Commands[0].Parameters.Add(new Parameter("@DUnderline", SqlDbType.Bit, (Boolean)dr["DUnderline"]));
                                db.Commands[0].Parameters.Add(new Parameter("@Bold", SqlDbType.Bit, (Boolean)dr["Bold"]));
                                db.Commands[0].ExecuteNonQuery();
                            }
                        }
                    }
                    if (dtDelete != null)
                    {
                        if (dtDelete.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtDelete.Rows)
                            {
                                db.Commands.Clear();
                                db.Commands.Add(db.CreateCommand("usp_GLReportDesign_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dr["RowID", DataRowVersion.Original]));
                                db.Commands[0].ExecuteNonQuery();
                            }
                        }
                    }
                    db.CommitTransaction();
                }
                RefreshGrid();
                MessageBox.Show("Update Berhasil");
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgGL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                if (dgGL.Columns["cRef"].Visible == true)
                    dgGL.Columns["cRef"].Visible = false;
                else
                    dgGL.Columns["cRef"].Visible = true;
            }
        }

        
    }
}
