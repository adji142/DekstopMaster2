using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ISA.DAL;

namespace ISA.Toko.Penjualan
{
    public partial class frmRencKunjSalesBrowser : ISA.Toko.BaseForm
    {
        Guid _rowID;
        DateTime _dTglKunjung;
        string _KodeSales, _KodeToko, _KetReal;
        public frmRencKunjSalesBrowser()
        {
            InitializeComponent();
        }

        private void frmRencKunjSalesBrowser_Load(object sender, EventArgs e)
        {
            _dTglKunjung = DateTime.Now;
            dTxtTglKunjung.DateValue = _dTglKunjung;

            nTxtRencKunjung.Enabled = false;
            nTxtTargetOA.Enabled = false;
            nTxtTokoKunjung.Enabled = false;
            nTxtTokoOrder.Enabled = false;

            if ((dTxtTglKunjung.DateValue != null) && (lookupSales1.SalesID == ""))
            {
                cgvKunjSales.AutoGenerateColumns = false;
                Bindata();
            }
            
        }

        public void Bindata()
        {
            _dTglKunjung = dTxtTglKunjung.DateValue.Value;

            DataTable dt = new DataTable();
            Database db = new Database();
            //db.Commands.Add(db.CreateCommand("usp_KunjunganSales_LIST")); lama
            db.Commands.Add(db.CreateCommand("usp_Kunjungan_Sales2"));
            db.Commands[0].Parameters.Add(new Parameter("@DateKunj", SqlDbType.DateTime, _dTglKunjung));
            db.Commands[0].Parameters.Add(new Parameter("@SalesID", SqlDbType.VarChar, lookupSales1.SalesID));
            // db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, null)); matiin by HR
            dt = db.Commands[0].ExecuteDataTable();
            cgvKunjSales.DataSource = dt;
            
        }
               

        private void cmdBtnSearch_Click(object sender, EventArgs e)
        {
            Bindata();
        }


        private void cgvKunjSales_SelectionRowChanged(object sender, EventArgs e)
        {
            _rowID = (Guid)cgvKunjSales.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            _KodeSales = cgvKunjSales.SelectedCells[0].OwningRow.Cells["kd_sales"].Value.ToString();
            _KodeToko = cgvKunjSales.SelectedCells[0].OwningRow.Cells["kd_toko"].Value.ToString();
            _KetReal = cgvKunjSales.SelectedCells[0].OwningRow.Cells["KetRealisasi"].Value.ToString();
            _dTglKunjung = dTxtTglKunjung.DateValue.Value;
            nTxtRealisasi.Text = cgvKunjSales.SelectedCells[0].OwningRow.Cells["Rprealisasi"].Value.ToString();
            nTxtTargetOA.Text = cgvKunjSales.SelectedCells[0].OwningRow.Cells["targetOA"].Value.ToString();
            nTxtRencKunjung.Text = cgvKunjSales.SelectedCells[0].OwningRow.Cells["RencKunj"].Value.ToString();
            nTxtTokoKunjung.Text = cgvKunjSales.SelectedCells[0].OwningRow.Cells["Terkunjungi"].Value.ToString();
            nTxtTokoKunjung.Text = cgvKunjSales.SelectedCells[0].OwningRow.Cells["tokoOrder"].Value.ToString();
            
            if (nTxtRealisasi.Text != "0")
            {
                KetRealiasasi.Enabled = false;
                KetRealiasasi.Text = "ORDERED";
            }
            else
            {
                KetRealiasasi.Enabled = true;
                KetRealiasasi.Text = cgvKunjSales.SelectedCells[0].OwningRow.Cells["KetRealisasi"].Value.ToString();
            }
            
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_KunjunganSales_UPDATE"));// HR, Created SP 19032013
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                db.Commands[0].Parameters.Add(new Parameter("@DateKunj", SqlDbType.Date, _dTglKunjung));
                db.Commands[0].Parameters.Add(new Parameter("@SalesID", SqlDbType.VarChar, _KodeSales));
                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, _KodeToko));
                db.Commands[0].Parameters.Add(new Parameter("@KetRealisasi", SqlDbType.VarChar, _KetReal));
                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].ExecuteNonQuery();
            }                
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (lookupSales1.SalesID == "")
            {
                return;
            }

            Penjualan.frmRencKunjSalesUpdate ifrmChild = new Penjualan.frmRencKunjSalesUpdate(this, lookupSales1.SalesID, _dTglKunjung);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _rowID = (Guid)cgvKunjSales.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_KunjunganSales_DELETE"));//HR, created SP
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].ExecuteNonQuery();
                }
                Bindata();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void KetRealiasasi_Leave(object sender, EventArgs e)
        {
            _KetReal = KetRealiasasi.Text;
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_KunjunganSales_UPDATE")); //HR, Created SP 
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@DateKunj", SqlDbType.Date, _dTglKunjung));
                    db.Commands[0].Parameters.Add(new Parameter("@SalesID", SqlDbType.VarChar, _KodeSales));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, _KodeToko));
                    db.Commands[0].Parameters.Add(new Parameter("@KetRealisasi", SqlDbType.VarChar, _KetReal));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


    }

}
