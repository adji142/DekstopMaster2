using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;
using ISA.Toko.Class;
using ISA.Toko;

namespace ISA.Toko.xpdc
{
    public partial class frm_detail_xpdc : ISA.Controls.BaseForm
    {
        DateTime _fromDate, _toDate;
        DataTable dtHeader, dtDetail, sekarang, dtGet, dtGetx;
        int nDay, nYear, nMonth;
        Guid _HeaderID = Guid.Empty;
        Guid rID;
        Guid RowID_ = Guid.Empty;
        string _RecordID = string.Empty;
        string _SFlag = string.Empty;
        string cFlag = string.Empty;
        string TglKirim_ = string.Empty;

        public frm_detail_xpdc(Form caller)
        {
            InitializeComponent();
        }

        public frm_detail_xpdc(Form caller, Guid rowID, String _TglKirim)
        {
            InitializeComponent();
            //formMode = enumFormMode.Update;
            _HeaderID = rowID;
            rID = rowID;
            this.Caller = caller;
            TglKirim_ = _TglKirim; 
        }

        private void Detail_xpdc_Load(object sender, EventArgs e)
        {
            nDay = DateTime.Today.Day+1;
            _fromDate = DateTime.Today.AddDays(-nDay); 
            _toDate = DateTime.Now;
            rangeDateBox1.FromDate = _fromDate;
            rangeDateBox1.ToDate = _toDate;    
            rangeDateBox1.Focus();  
            RefreshDataXpdc_GetNotaAg();
        }

        public void RefreshDataXpdc_GetNotaAg()
        {
            _fromDate = (DateTime)rangeDateBox1.FromDate;
            _toDate = (DateTime)rangeDateBox1.ToDate;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtGet = new DataTable();
                using (Database db = new Database())
                {
                    //db.Commands.Add(db.CreateCommand("usp_PengirimanXpdc_GetNotaJualAg_LIST"));
                    db.Commands.Add(db.CreateCommand("usp_PengirimanXpdcDetail_TMP"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@Gudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    dtGet = db.Commands[0].ExecuteDataTable();
                }
                dataGridView1.DataSource = dtGet;

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


        public void RefreshDataXpdc_GetNotaAgList()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtGet = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PengirimanXpdcDetail_TMPLIST"));
                    dtGet = db.Commands[0].ExecuteDataTable();
                }
                dataGridView1.DataSource = dtGet;

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
            RefreshDataXpdc_GetNotaAg();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            InsertData(dtGet);
            if (this.Caller is frm_kirim)
            {
                frm_kirim frmCaller = (frm_kirim)this.Caller;
                frmCaller.RefreshDataDetail();
            }
        }

        private void InsertData(DataTable dtGetx)
        {
            try
            {
                using (Database db = new Database())
                //using (Database db = new Database(GlobalVar.DBName))
                {
                    for (int i = 0; i < dtGetx.Rows.Count; i++)
                        {
                        db.Commands.Add(db.CreateCommand("[usp_PengirimanXpdcDetail_INSERT]"));
                        db.Commands[i].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderID));
                        db.Commands[i].Parameters.Add(new Parameter("@NotaJualID", SqlDbType.UniqueIdentifier, dtGetx.Rows[i]["NotaJualID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@TglSuratJalan", SqlDbType.DateTime, dtGetx.Rows[i]["TglSuratJalan"]));
                        db.Commands[i].Parameters.Add(new Parameter("@NoSuratJalan", SqlDbType.VarChar, dtGetx.Rows[i]["NoSuratJalan"]));
                        db.Commands[i].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, dtGetx.Rows[i]["KodeToko"]));
                        db.Commands[i].Parameters.Add(new Parameter("@Barcode", SqlDbType.VarChar, dtGetx.Rows[i]["Barcode"]));
                        db.Commands[i].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, dtGetx.Rows[i]["TransactionType"]));
                        db.Commands[i].Parameters.Add(new Parameter("@LastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[i].Parameters.Add(new Parameter("@SFlag", SqlDbType.VarChar, dtGetx.Rows[i]["SFlag"]));
                        db.Commands[i].Parameters.Add(new Parameter("@KeteranganKoli", SqlDbType.VarChar, dtGetx.Rows[i]["KeteranganKoli"]));
                        db.Commands[i].Parameters.Add(new Parameter("@TglKirim", SqlDbType.DateTime, TglKirim_));
                            //db.Commands[i].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                    }
                    db.BeginTransaction();
                    for (int j = 0; j < db.Commands.Count; j++)
                    {
                        db.Commands[j].ExecuteNonQuery();
                    }
                    db.CommitTransaction();
                    this.Close(); 
                }
                //RefreshData();
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            //this.Close();
        }

        private void commandButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*private void customGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridNotaJual.SelectedCells.Count > 0)
            {
                try
                {
                    MessageBox.Show("Masuk dep?");
                    Guid rowID = (Guid)dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NotaJualID"].Value;
                    MessageBox.Show(rowID.ToString());
                    //MessageBox.Show(rowID.ToString());
                    //xpdc.Header_xpdc ifrmChild = new xpdc.Header_xpdc(this, rowID);
                    //ifrmChild.MdiParent = Program.MainForm;
                    //Program.MainForm.RegisterChild(ifrmChild);
                    //ifrmChild.Show();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }*/

        private void SaveFlag_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                try
                {
                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["NotaJualID"].Value;
                    _SFlag = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                    if (_SFlag == "N")
                    {
                        _SFlag = "Y";
                    }
                    else
                    {
                        _SFlag = "N";
                    }

                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        try
                        {
                            db.Commands.Add(db.CreateCommand("usp_PengirimanXpdcDetail_TEMPUPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@SFlag", SqlDbType.VarChar, _SFlag));
                            db.Commands[0].ExecuteNonQuery();
                            RefreshDataXpdc_GetNotaAgList();
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            db.RollbackTransaction();
                            MessageBox.Show("Gagal Menyimpan Data");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void dataGridNotaJual_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
       {
          if(dataGridView1.Columns[e.ColumnIndex].Name == "SFlag" && e.Value != null && e.Value.ToString() == "Y")
          dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;  
       }

       private void dataGridNotaJual_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
       {
           if (dataGridView1.Columns[e.ColumnIndex].Name == "SFlag" && e.Value.ToString() == "Y")
               {
               foreach (DataGridViewCell dc in dataGridView1.Rows[e.RowIndex].Cells)
               {
                   dataGridView1.Rows[e.RowIndex].Cells[dc.ColumnIndex].Style.BackColor = Color.Cyan;
               }
           }
       }


       private void dataGridNotaJual_KeyDown(object sender, KeyEventArgs e)
       {
           if (dataGridView1.RowCount > 0 && dataGridView1.SelectedCells.Count > 0)
           {
               if (e.Control == true && e.KeyCode == Keys.P)
               {
                   MessageBox.Show("Ctrl P");
                   //cmdPrint.PerformClick();
               }
           }

           switch (e.KeyCode)
           {
               case Keys.Insert:
                   {
                       MessageBox.Show("Insert");
                       //Register.frmRegisterUpdate ifrmChild = new Register.frmRegisterUpdate(this, _lcabang);
                       //ifrmChild.ShowDialog();
                   }
                   break;

               case Keys.Space:
                   {
                       if (dataGridView1.SelectedCells.Count > 0)
                       {
                           Guid RowID_ = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["NotaJualID"].Value;
                           xpdc.frm_barcode ifrmChild = new xpdc.frm_barcode(this, RowID_,"TMP");
                           ifrmChild.MdiParent = Program.MainForm;
                           Program.MainForm.RegisterChild(ifrmChild);
                           ifrmChild.Show();
                       }
                   }
                   break;

               case Keys.Delete:
                   if (dataGridView1.SelectedCells.Count > 0)
                   {
                       if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                       {
                           return;
                       }
                       /*
                       string NPrint_ = dataGridNotaJual.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString();
                       if (NPrint_ != "0")
                       {
                           if (!SecurityManager.IsManager())
                           {
                               if (!SecurityManager.AskPasswordManager())
                               {
                                   return;
                               }
                           }
                       }*/
                   }
                   break;

               case Keys.F2:
                   {
                       MessageBox.Show("F2");
                       /*
                       if (dataGridNotaJual.SelectedCells.Count == 0)
                       {
                           return;
                       }
                       int index = -1;
                       index = dataGridNotaJual.SelectedCells[0].OwningRow.Index;
                       bool Flag_ = Convert.ToBoolean(dataGridNotaJual.SelectedCells[0].OwningRow.Cells["Flag"].Value);

                       DataRowView dv = (DataRowView)dataGridNotaJual.SelectedCells[0].OwningRow.DataBoundItem;
                       DataRow dr = dv.Row;
                       dr["Flag"] = !Flag_;
                       dtHeader.AcceptChanges();
                       dataGridNotaJual.RefreshEdit();*/
                   }
                   break;

           }
       }

       private void commandButton4_Click(object sender, EventArgs e)
       {
           RefreshDataXpdc_GetNotaAgList();
       }


    }
}
