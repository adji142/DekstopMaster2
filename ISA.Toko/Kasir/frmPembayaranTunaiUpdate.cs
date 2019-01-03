using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.Class;

namespace ISA.Toko.Kasir
{
    public partial class frmPembayaranTunaiUpdate : ISA.Toko.BaseForm
    {
        Guid _rowID;
        DataTable dt;


        public frmPembayaranTunaiUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            _rowID = rowID;
            this.Caller = caller;
           

        }

        private void frmPembayaranTunaiUpdate_Load(object sender, EventArgs e)
        {
            if (this.Caller is Kasir.frmPJTUpdate)
            {
                this.cmdCLOSE.Enabled = false;
                this.cmdCLOSE.Visible = false;
            }
            this.Text = "PJT";
            GetDataNota();

            txtNoNota.Text = dt.Rows[0]["NoNota"].ToString();
            txtTglNota.DateValue = (DateTime)dt.Rows[0]["TglNota"];
            txtNamaToko.Text = dt.Rows[0]["NamaToko"].ToString();
            txtKodeSales.Text = dt.Rows[0]["KodeSales"].ToString();
            txtNoPerkiraan.Text = "";//GetNoPerkiraan();
            txtUraian.Text = 
                txtNoPerkiraan.Text.Trim() + ", NOTA : " + txtNoNota.Text 
                + " " + ((DateTime)txtTglNota.DateValue).ToString("dd-MM-yyyy");
            txtBayar.Text = dt.Rows[0]["RpNet3"].ToString();
            txtPLL.Text = "0";
            txtPot.Text = "0";

        }

        private void GetDataNota()
        {
            try
            {
                this.Cursor = Cursors.Default;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_RowID"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();
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
        private string GetNoPerkiraan()
        {
            string noPerkiraan = "";
            try
            {

                this.Cursor = Cursors.WaitCursor;

                string kodeTrn = "COL" + dt.Rows[0]["WilID"].ToString().Substring(0, 1);
                noPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail(kodeTrn).Rows[0]["NoPerkiraan"].ToString();
                
                //this.Cursor = Cursors.WaitCursor;
                //DataTable dtGL = new DataTable();
                //using (Database db = new Database())
                //{
                //    db.Commands.Add(db.CreateCommand("usp_GetNoPerkiraan"));
                //    db.Commands[0].Parameters.Add(new Parameter("@kode", SqlDbType.VarChar, "PJT"));
                //    dtGL = db.Commands[0].ExecuteDataTable(); 
                //}
                //if (dtGL.Rows.Count > 0)
                //{
                //    noPerkiraan = dtGL.Rows[0]["NoPerkiraan"].ToString();
                //}
                //else 
                //{
                //    MessageBox.Show("Kode PJT untuk cabang " + GlobalVar.CabangID + " belum ada di tabel, hubungi manager Anda", "Perhatian");
                //}
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return noPerkiraan;
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            string rpNet3 = dt.Rows[0]["RpNet3"].ToString();
            double n = double.Parse(rpNet3) - double.Parse(txtBayar.Text);
            txtPLL.Text = (0).ToString();
            txtPot.Text = (0).ToString();
            if (n > 0 && n <= 1000)
            {
                txtPot.Text = n.ToString();
            }
            if (n < 0 && n >= -1000)
            {
                txtPLL.Text = Math.Abs(n).ToString();
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_PJT_LinkToKasir_ISA"));
                    
                    db.Commands[0].Parameters.Add(new Parameter("@notaID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@nilaiBayar", SqlDbType.Money, double.Parse(txtBayar.Text)));
                    db.Commands[0].Parameters.Add(new Parameter("@noPerkiraan", SqlDbType.VarChar, txtNoPerkiraan.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@uraian", SqlDbType.VarChar, txtUraian.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@nilaiPOT", SqlDbType.Money, double.Parse(txtPot.Text)));
                    db.Commands[0].Parameters.Add(new Parameter("@nilaiPLL", SqlDbType.Money, double.Parse(txtPLL.Text)));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                MessageBox.Show("Data telah disimpan");
                this.Close();
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
            if (this.Caller is frmPJTUpdate)
            {
                MessageBox.Show("Tidak Boleh Close", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            this.Close();
        }

        //untuk disable close di kanan atas
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        } 

        private void frmPembayaranTunaiUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        
    }
}
