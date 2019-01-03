using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Penjualan
{
    public partial class frmPotonganVNotaBrowse : ISA.Trading.BaseForm
    {
        int prevGrid1Row = -1;
        string _kodeToko, _tokoID, _nama, _alamat, _kota, namaStok;
        Guid _rowID;
        string _noNota;
        //DateTime _tglNota;
        //double _rpNetto;

        public Guid rowId
        {
            get
            {
                return _rowID;
            }
            set
            {
                _rowID = value;
            }
        }

        public string noNota
        {
            get
            {
                return _noNota;
            }
            set
            {
                _noNota = value;
            }
        }

       // public DateTime  tglNota
       // {
       //     get
       //     {
       //         return _tglNota;
       //     }
       //     set
       //     {
       //         _tglNota = value;
       //     }
       // }

       //public double rpNetto
       // {
       //     get
       //     {
       //         return _rpNetto;
       //     }
       //     set
       //     {
       //         _rpNetto = value;
       //     }
       // }

        public frmPotonganVNotaBrowse(Form caller, string tokoID)
        {
            InitializeComponent();
            this.Caller = caller;
            _tokoID = tokoID;
        }

        private void frmPotonganVNotaBrowse_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            try
            {
                DataTable dt = new DataTable();
                DataTable dts = new DataTable();
                DataTable dtp = new DataTable();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Toko_SEARCH"));
                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar,_tokoID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                
                if (dt.Rows.Count > 0)
                {
                    _nama = Tools.isNull(dt.Rows[0]["NamaToko"], "").ToString();
                    _alamat = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                    _kota = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                    _kodeToko = Tools.isNull(dt.Rows[0]["KodeToko"],"").ToString();
                    label1.Text += _nama + " " + _alamat + " " + _kota;
                    RefreshDataNotaPenjualan();
                    //using (Database db = new Database())
                    //{
                    //    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST"));
                    //    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                    //    dts = db.Commands[0].ExecuteDataTable();
                    //}
                }

                //if (dts.Rows.Count > 0)
                //{
                //    dataGridView1.DataSource = dts;
                //    Guid _headerID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                //    using (Database db = new Database())
                //    {
                //        db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_LIST"));
                //        db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                //        dtp = db.Commands[0].ExecuteDataTable();
                //        namaStok = Tools.isNull(dtp.Rows[0]["NamaBarang"],"").ToString();
                //    }
                    
                //}

                //if (dtp.Rows.Count > 0)
                //{
                //    dataGridView2.DataSource = dtp;
                //}
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            
        }

        public void RefreshDataNotaPenjualan()
        {
            DataTable dts = new DataTable();
            DataTable dtp = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                dts = db.Commands[0].ExecuteDataTable();
                dataGridView1.DataSource = dts;
            }

            if (dataGridView1.SelectedCells.Count > 0)
            {
                RefreshDataNotaPenjualanDetail();
                //Guid _headerID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                //using (Database db = new Database())
                //{
                //    db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_LIST"));
                //    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                //    dtp = db.Commands[0].ExecuteDataTable();
                //    namaStok = Tools.isNull(dtp.Rows[0]["NamaBarang"], "").ToString();
                //    dataGridView2.DataSource = dtp;
                //}
            }
            else
            {
                dataGridView2.DataSource = null;
            }
            
        }

        public void RefreshDataNotaPenjualanDetail()
        {
            try
            {
                DataTable dtp = new DataTable();
                Guid _headerID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_LIST_FILTER_HeaderID"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                    dtp = db.Commands[0].ExecuteDataTable();
                    namaStok = Tools.isNull(dtp.Rows[0]["NamaBarang"], "").ToString();
                    dataGridView2.DataSource = dtp;
                }
                if (dataGridView2.SelectedCells.Count > 0)
                {
                    lblNamaStok.Text = namaStok;
                }
                else
                {
                    lblNamaStok.Text = " ";
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dataGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void ConfirmSelect()
        {
            if (dataGridView1.SelectedCells.Count == 1)
            {
                _rowID = new Guid(dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                _noNota = dataGridView1.SelectedCells[0].OwningRow.Cells["NoNota"].Value.ToString();
                //_tglNota = Convert.ToDateTime(dataGridView1.SelectedCells[0].OwningRow.Cells["TglNota"].Value.ToString);
                //_rpNetto = Convert.ToDouble(dataGridView1.SelectedCells[0].OwningRow.Cells["RpNett"].Value.ToString );
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dataGridView1_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                    RefreshDataNotaPenjualanDetail();

            }
            else
            {
                lblNamaStok.Text = " ";
            }
        }



     
    }
}
