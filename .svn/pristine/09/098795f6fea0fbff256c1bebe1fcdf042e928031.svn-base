using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.VWil
{
    public partial class frmRefreshTransaksi : ISA.Toko.BaseForm
    {
        Guid _rowID;
    
        public frmRefreshTransaksi(Guid rowID)
        {
            InitializeComponent();
            _rowID = rowID;
        }

        private void frmRefreshTransaksi_Load(object sender, EventArgs e)
        {
            try{
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ReIDWil_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();        
                }
                if(dt.Rows.Count > 0)
                {
                    lblKeterangan.Text = "Proses ini akan merubah Idwil " 
                        + Tools.isNull(dt.Rows[0]["WilIDOld"],"").ToString()
                        + " menjadi " + Tools.isNull(dt.Rows[0]["WilID"],"").ToString()
                        + " di beberapa file yang menyimpan data Idwil."
                        + " Selain itu proses ini juga akan membentuk journal penyesuaian "
                        + " sejumlah saldo piutang perwilayah sebagaimana terakhir kali "
                        + " diproses Laporan API No.6 (rekap)."
                        + " Untuk menciptakan journal ADJ tersebut, silahkan taruh file "
                        + SecurityManager.UserInitial  
                        + ". DBF yg pernah Anda backup pada folder"
                        + "";//cLokasidokumen;

                    
                }
                else{
                    lblKeterangan.Text="";   
                }
            }
            catch(Exception ex){
                Error.LogError(ex);
            }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_vWil_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, SecurityManager.UserID));
                    db.BeginTransaction();
                    db.Commands[0].ExecuteNonQuery();
                    db.CommitTransaction();
                }
                MessageBox.Show("WildID sudah diupdate ke table dpiutang (foxpro) / Piutang Detail (ISA)", "Refresh Transaksi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
