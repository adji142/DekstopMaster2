using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Ekspedisi
{
    public partial class frmEkspedisiPengirimanDetailUpdate : ISA.Trading.BaseForm
    {
        Guid _rowID;
        string _trID;
        DateTime _fromDate, _toDate;
        DataTable dtRekapKoliDetail;

        public frmEkspedisiPengirimanDetailUpdate(Form caller, Guid rowID, string trID, DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            _rowID = rowID;
            _fromDate = fromDate;
            _toDate = toDate;
            _trID = trID;
            this.Caller = caller;
        }

        private void frmEkspedisiPengirimanDetailUpdate_Load(object sender, EventArgs e)
        {
            //RefreshData();
        }

        public void RefreshData(string noSJ, string namaToko)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    //db.Commands.Add(db.CreateCommand("usp_RekapKoli_LIST_PENGIRIMAN"));
                    db.Commands.Add(db.CreateCommand("usp_RekapKoli_LIST_PENGIRIMAN_ADD"));
                    db.Commands[0].Parameters.Add(new Parameter("@noSuratJalan", SqlDbType.VarChar, noSJ));
                    db.Commands[0].Parameters.Add(new Parameter("@namaToko", SqlDbType.VarChar, namaToko));
                    //db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime , _fromDate));
                    //db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime , _toDate));
                    dt = db.Commands[0].ExecuteDataTable();

                }
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }

                if (dataGridView1.SelectedCells.Count > 0)
                {
                    label1.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString() + " " + dataGridView1.SelectedCells[0].OwningRow.Cells["Alamat"].Value.ToString() + " " + dataGridView1.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString();

                }
                else
                {
                    label1.Text = "";
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

        private void handleGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Guid rekapkoliid = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                    
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                   
                        db.Commands.Add(db.CreateCommand("usp_PengirimanEkspedisiDetail_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier , _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@trID", SqlDbType.VarChar, _trID));
                        db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar , Tools.CreateFingerPrint()));
                        db.Commands[0].Parameters.Add(new Parameter("@rekapKoliID", SqlDbType.UniqueIdentifier , rekapkoliid));
                        db.Commands[0].Parameters.Add(new Parameter("@ketPending", SqlDbType.VarChar , ""));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID ));
                        
                        dt = db.Commands[0].ExecuteDataTable();
                       
                        string uraian;
                        db.Commands.Add(db.CreateCommand("usp_fnUraian"));
                        db.Commands[1].Parameters.Add(new Parameter("@idTr", SqlDbType.VarChar, _trID));
                        DataTable dts = new DataTable();
                        dts = db.Commands[1].ExecuteDataTable();
                        uraian = Tools.isNull(dts.Rows[0]["Uraian"], "").ToString();

                        dtRekapKoliDetail = new DataTable();
                        using (Database dbListDetail = new Database())
                        {
                            dbListDetail.Commands.Add(db.CreateCommand("usp_RekapKoliDetail_LIST"));
                            dbListDetail.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, rekapkoliid));
                            dtRekapKoliDetail = dbListDetail.Commands[0].ExecuteDataTable();
                        }

                        DataTable dtt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_RekapKoliDetail_UPDATE"));

                        db.Commands[2].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, (Guid)dtRekapKoliDetail.Rows[0]["RowID"]));
                        db.Commands[2].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, Tools.isNull(dtRekapKoliDetail.Rows[0]["RecordID"], "").ToString()));
                        db.Commands[2].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, rekapkoliid));
                        db.Commands[2].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, Tools.isNull(dtRekapKoliDetail.Rows[0]["HtrID"], "").ToString()));
                        db.Commands[2].Parameters.Add(new Parameter("@notaJualID", SqlDbType.UniqueIdentifier, (Guid)dtRekapKoliDetail.Rows[0]["NotaJualID"]));
                        db.Commands[2].Parameters.Add(new Parameter("@noNota", SqlDbType.VarChar, Tools.isNull(dtRekapKoliDetail.Rows[0]["NoNota"], "").ToString()));
                        db.Commands[2].Parameters.Add(new Parameter("@notaJualRecID", SqlDbType.VarChar, Tools.isNull(dtRekapKoliDetail.Rows[0]["NotaJualRecID"], "").ToString()));
                        db.Commands[2].Parameters.Add(new Parameter("@tunaiKredit", SqlDbType.VarChar, Tools.isNull(dtRekapKoliDetail.Rows[0]["TunaiKredit"], "").ToString()));
                        db.Commands[2].Parameters.Add(new Parameter("@nominal", SqlDbType.Money, dtRekapKoliDetail.Rows[0]["Nominal"]));
                        db.Commands[2].Parameters.Add(new Parameter("@uraian", SqlDbType.VarChar, uraian));
                        db.Commands[2].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, Tools.isNull(dtRekapKoliDetail.Rows[0]["Keterangan"], "").ToString()));
                        db.Commands[2].Parameters.Add(new Parameter("@noResi", SqlDbType.VarChar, Tools.isNull(dtRekapKoliDetail.Rows[0]["NoResi"], "").ToString()));
                        db.Commands[2].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                        db.Commands[2].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[2].ExecuteNonQuery();
                        dtt = db.Commands[2].ExecuteDataTable();

                        db.Commands.Add(db.CreateCommand("usp_RekapKoli_UPDATE_KP"));
                        db.Commands[3].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rekapkoliid));
                        db.Commands[3].Parameters.Add(new Parameter("@kp", SqlDbType.VarChar, "KP"));
                        db.Commands[3].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[3].ExecuteNonQuery();                        

                        //INSERT INTO CxpdcKp (IdRec,No_Nota,Kd_Sales,Tk,Uraian) VALUES ;
                            //(cIdRec,Dxpdc.No_nota,Dxpdc.Sales,Dxpdc.Tk,cUraian)

                        //db.Commands[1].Parameters.Add(new Parameter("@idTr", SqlDbType.VarChar, _trID));
                         
                    }
                    //if (dt.Rows.Count > 0)
                    //{
                    //    dataGridView1.DataSource = dt;
                    //}

                    //if (dataGridView1.SelectedCells.Count > 0)
                    //{
                    //    label1.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString() + " " + dataGridView1.SelectedCells[0].OwningRow.Cells["Alamat"].Value.ToString() + " " + dataGridView1.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString();

                    //}
                    MessageBox.Show(Messages.Confirm.UpdateSuccess);
                    this.DialogResult = DialogResult.OK;
                    frmEkspedisiPengirimanBrowse frmCaller = (frmEkspedisiPengirimanBrowse)this.Caller;
                    frmCaller.RefreshDataHeader();
                    frmCaller.FindHeader("RowID", _rowID.ToString());
                    this.Close();
                    frmCaller.Show();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                label1.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString() + " " + dataGridView1.SelectedCells[0].OwningRow.Cells["Alamat"].Value.ToString() + " " + dataGridView1.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString();

            }
            else
            {
                label1.Text = "";
            }
               
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            handleGridKey(sender, e);
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData(txtNoSJ.Text, txtNamaToko.Text);
        }
    }
}
