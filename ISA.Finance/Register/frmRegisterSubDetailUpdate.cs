using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using System.Drawing.Printing;
using ISA.Common;
using ISA.Finance.Class;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data.SqlTypes;
using Microsoft.Reporting.WinForms;
using ISA.Finance.DataTemplates;

namespace ISA.Finance.Register
{
    public partial class frmRegisterSubDetailUpdate : ISA.Finance.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        DataTable dt = new DataTable();
        Guid _RowID = Guid.Empty;
        Guid _HeaderID = Guid.Empty;
        string _RecordID = string.Empty;
        string _HRecordID = string.Empty;
        Double _Rp = 0;
        bool _Lcabang;

        private void SetDt()
        {
            dt.Columns.Add("RowID");
            dt.Columns.Add("HeaderID");
            dt.Columns.Add("RecordID");
            dt.Columns.Add("HRecordID");
            dt.Columns.Add("TanggalKunjung");
            dt.Columns.Add("Keterangan");
            dt.Columns.Add("RpInd");
            dt.Columns.Add("SyncFlag");
            dt.Rows.Add(_RowID,_HeaderID,_RecordID,_HRecordID,dateTextBox1.DateValue,cboKeterangan.Text,_Rp,false);
        }

        private void RefreshForms()
        {
            if (this.Caller is frmRegisterBrowser)
            {
                frmRegisterBrowser frmCaller = (frmRegisterBrowser)this.Caller;
                //frmCaller.RefreshRowDetail(_RowID);
                frmCaller.RefreshRowDataSubDetail("RowID", _RowID.ToString(), dt);
                frmCaller.FindGridSubDetail("RowID", _RowID.ToString());
            }
        }

        public frmRegisterSubDetailUpdate()
        {
            InitializeComponent();
        }
        public frmRegisterSubDetailUpdate(Form caller_ , bool Lcabang_, Guid HeaderID_, string HRecordID_)
        {
            this.Caller = caller_;
            formMode = enumFormMode.New;
            _Lcabang = Lcabang_;
            _HeaderID = HeaderID_;
            _HRecordID = HRecordID_;
            InitializeComponent();
        }

        public frmRegisterSubDetailUpdate(Form caller_, bool Lcabang_, Guid RowID_)
        {
            this.Caller = caller_;
            _Lcabang = Lcabang_;
            formMode = enumFormMode.Update;
            _RowID = RowID_;
            InitializeComponent();
        }

       

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (GlobalVar.Gudang != "2808")
            {
                if (cboKeterangan.Text == "")
                {
                    MessageBox.Show("Pilih Keterangan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            switch (formMode)
            {
                case enumFormMode.New:
                    if (GlobalVar.Gudang != "2808")
                    {
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_TagihanSubDetail_Populate"));
                                _RowID = Guid.NewGuid();
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderID));
                                _RecordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                                db.Commands[0].Parameters.Add(new Parameter("@RecorDID", SqlDbType.VarChar, _RecordID));
                                db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, _HRecordID));
                                db.Commands[0].Parameters.Add(new Parameter("@TanggalKunjung", SqlDbType.DateTime, dateTextBox1.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, cboKeterangan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@RpInd", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserInitial));
                                db.Commands[0].ExecuteNonQuery();
                            }

                            SetDt();
                            RefreshForms();

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
                    else
                    {
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_TagihanSubDetail"));
                                _RowID = Guid.NewGuid();
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderID));
                                _RecordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                                db.Commands[0].Parameters.Add(new Parameter("@RecorDID", SqlDbType.VarChar, _RecordID));
                                db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, _HRecordID));
                                db.Commands[0].Parameters.Add(new Parameter("@TanggalKunjung", SqlDbType.DateTime, dateTextBox1.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, cKet.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@RpInd", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserInitial));
                                db.Commands[0].ExecuteNonQuery();
                            }

                            //SetDt();
                            RefreshForms();

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
                    break;


                case enumFormMode.Update:
                    if (GlobalVar.Gudang != "2808")
                    {
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("[usp_TagihanSubDetail_Update]"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderID));
                                db.Commands[0].Parameters.Add(new Parameter("@RecorDID", SqlDbType.VarChar, _RecordID));
                                db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, _HRecordID));
                                db.Commands[0].Parameters.Add(new Parameter("@TanggalKunjung", SqlDbType.DateTime, dateTextBox1.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, cboKeterangan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@RpInd", SqlDbType.Money, numericTextBox1.GetDoubleValue));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserInitial));
                                db.Commands[0].ExecuteNonQuery();
                            }

                            SetDt();
                            RefreshForms();

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
                    else
                    {
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("[usp_TagihanSubDetail_Update]"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderID));
                                db.Commands[0].Parameters.Add(new Parameter("@RecorDID", SqlDbType.VarChar, _RecordID));
                                db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, _HRecordID));
                                db.Commands[0].Parameters.Add(new Parameter("@TanggalKunjung", SqlDbType.DateTime, dateTextBox1.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, cKet.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@RpInd", SqlDbType.Money, numericTextBox1.GetDoubleValue));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserInitial));
                                db.Commands[0].ExecuteNonQuery();
                            }

                            //SetDt();
                            RefreshForms();
                            //RefreshSubDetail((Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value);

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
                    break;
            }

            this.Close();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRegisterSubDetailUpdate_Load(object sender, EventArgs e)
        {
            if (_Lcabang)
            {
                label4.Visible = false;
                numericTextBox1.Visible = false;
            } 
            else
            {
                label4.Visible = true;
                numericTextBox1.Visible = true;
            }

            if (GlobalVar.Gudang == "2808")
            {
                label5.Visible = true;
                cKet.Visible = true;
                label2.Visible = false;
                cboKeterangan.Visible = false;
            }
            else
            {
                label5.Visible = false;
                cKet.Visible = false;
                label2.Visible = true;
                cboKeterangan.Visible = true;

            }

            switch (formMode)
            {
            case enumFormMode.New:
                    dateTextBox1.DateValue = DateTime.Now;
                    dateTextBox1.Focus();
                    dateTextBox1.SelectAll();
            	break;
            case enumFormMode.Update:
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dta = new DataTable();
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_TagihanSubDetail_List]"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                        dta = db.Commands[0].ExecuteDataTable();

                    }

                    if (dta.Rows.Count==1)
                    {
                        dateTextBox1.DateValue = (DateTime)dta.Rows[0]["TanggalKunjung"];

                        if (GlobalVar.Gudang != "2808")
                            cboKeterangan.Text = dta.Rows[0]["Keterangan"].ToString();
                        else
                            cKet.Text = dta.Rows[0]["Keterangan"].ToString();

                        _Rp = Convert.ToDouble(Tools.isNull(dta.Rows[0]["RpInd"],"0").ToString());
                        numericTextBox1.Text = _Rp.ToString("#,##0");
                        _HeaderID = (Guid)dta.Rows[0]["HeaderID"];
                        _HRecordID = dta.Rows[0]["HRecordID"].ToString();
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
                break;
            }
        }
    }
}
