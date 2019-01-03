using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Bengkel.Library;
using ISA.Bengkel;
using ISA.Bengkel.Helper;

namespace ISA.Bengkel.Master
{
    public partial class frmCustomerBrowse : ISA.Bengkel.BaseForm
    {
        enum enumSelectedGrid { HeaderSelected, Detail1Selected, Detail2Selected, None };
        enumSelectedGrid selectedGrid = enumSelectedGrid.None;
        DataTable dtHeader, dtDetail1, dtDetail2;

        Guid _customerServiceRowID, _rowIDdetail = Guid.Empty;

        public Guid CustomerServiceRowID
        {
            get
            {
                return _customerServiceRowID;
            }
            set
            {
                _customerServiceRowID = value;
            }
        }

        Guid _motorServiceRowID;
        public Guid MotorServiceRowID
        {
            get
            {
                return _motorServiceRowID;
            }
        }

        string _idCust;
        public string IdCust
        {
            get
            {
                return _idCust;
            }
        }

        string _kodeCust;
        public string KodeCust
        {
            get
            {
                return _kodeCust;
            }
        }

        string _namaCust;
        public string NamaCust
        {
            get
            {
                return _namaCust;
            }
        }

        string _pemilik;
        public string Pemilik
        {
            get
            {
                return _pemilik;
            }
        }

        string _noID;
        public string NoID
        {
            get
            {
                return _noID;
            }
        }

        string _alamat;
        public string Alamat
        {
            get
            {
                return _alamat;
            }
        }

        string _kota;
        public string Kota
        {
            get
            {
                return _kota;
            }
        }

        string _daerah;
        public string Daerah
        {
            get
            {
                return _daerah;
            }
        }

        string _noTelp;
        public string NoTelp
        {
            get
            {
                return _noTelp;
            }
        }

        string _noPol;
        public string NoPol
        {
            get
            {
                return _noPol;
            }
        }

        string _kodeSpm;
        public string KodeSpm
        {
            get
            {
                return _kodeSpm;
            }
        }

        string _jnsSpm;
        public string JnsSpm
        {
            get
            {
                return _jnsSpm;
            }
        }

        string _spm;
        public string Spm
        {
            get
            {
                return _spm;
            }
        }

        string _noMesin;
        public string NoMesin
        {
            get
            {
                return _noMesin;
            }
        }

        string _noRangka;
        public string NoRangka
        {
            get
            {
                return _noRangka;
            }
        }

        string _warna;
        public string Warna
        {
            get
            {
                return _warna;
            }
        }

        string _tahun;
        public string Tahun
        {
            get
            {
                return _tahun;
            }
        }

        Guid _memberServiceRowID;
        public Guid MemberServiceRowID
        {
            get
            {
                return _memberServiceRowID;
            }
        }

        string _idMember;
        public string IdMember
        {
            get
            {
                return _idMember;
            }
        }

        public frmCustomerBrowse()
        {
            InitializeComponent();
        }

        public frmCustomerBrowse(string searchArg)
        {
            InitializeComponent();
            txtNama.Text = searchArg;
        }    

        private void frmCustomerBrowse_Load(object sender, EventArgs e)
        {
            LoadDataHeader();
            LoadDataDetail1();
            if (GlobalVar.Gudang.ToString().Trim().Substring(0, 2) == "28")
            {
                LoadDataDetail2();
            }
            if (GlobalVar.Gudang.ToString().Trim().Substring(0, 2) != "28")
            {
                dgvDetail2.Visible = false;
            }

            if (dgvDetail2.Rows.Count > 0)
            {
                dgvDetail2.Rows[0].Cells["id_member"].Selected = true;
            }

            if (dgvDetail1.Rows.Count > 0)
            {
                dgvDetail1.Rows[0].Cells["no_pol"].Selected = true;
            }

            if (dgvHeader.Rows.Count > 0)
            {
                dgvHeader.Rows[0].Cells["kd_cust"].Selected = true;
                dgvHeader.Focus();
            }
        }

        public void RefreshData(FormTools.detailIndex idx)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                switch (idx)
                {
                    case FormTools.detailIndex.header:
                        LoadDataHeader();
                        break;
                    case FormTools.detailIndex.detail1:
                        LoadDataDetail1();
                        break;
                    case FormTools.detailIndex.detail2:
                        //LoadDataDetail2();
                        break;
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

        private void LoadDataHeader()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (Database db = new Database())
                {
                    //db.Commands.Add(db.CreateCommand("usp_bkl_mCustService_LIST"));
                    //db.Commands[0].Parameters.Add(new Parameter("@NoPol", SqlDbType.VarChar, txtNoPol.Text.Trim()));
                    //dtHeader = db.Commands[0].ExecuteDataTable();

                    db.Commands.Add(db.CreateCommand("usp_bkl_mCustomerService_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@nama_cust", SqlDbType.VarChar, txtNama.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@NoPol", SqlDbType.VarChar, txtNoPol.Text.Trim()));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                }

                dgvHeader.DataSource = dtHeader;
                if (dtHeader.Rows.Count == 0)
                {
                    dgvDetail1.DataSource = null;
                    dgvDetail2.DataSource = null;
                }
                else
                {
                    LoadDataDetail1();
                    LoadDataDetail2();
                    dgvHeader.Focus();
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

        public void LoadDataDetail1()
        {
            Guid headerID;
            if (dgvHeader.Rows.Count > 0)
            {
                headerID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            }
            else
            {
                headerID = Guid.NewGuid();
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_bkl_mMotorService_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, headerID));
                    dtDetail1 = db.Commands[0].ExecuteDataTable();
                    dgvDetail1.DataSource = dtDetail1;
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

        public void LoadDataDetail2()
        {
            Guid headerID;
            if (dgvHeader.Rows.Count > 0)
            {
                headerID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            }
            else
            {
                headerID = Guid.NewGuid();
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_bkl_mMemberService_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, headerID));
                    dtDetail2 = db.Commands[0].ExecuteDataTable();
                    dgvDetail2.DataSource = dtDetail2;
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

        private bool CekAddEditDel(ISA.Controls.CustomGridView  dg)
        {
            bool cek = true;

            if (!FormTools.IsRowSelected(dg))
            {
                cek = false;
                goto SelesaiCek;
            }
            

            SelesaiCek:
            return cek;
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            Guid headerID;
            try
            {
                ISA.Bengkel.BaseForm ifrmChild;
                switch (selectedGrid)
                {
                    case enumSelectedGrid.HeaderSelected:
                        ifrmChild = new frmCustomerUpdate(this);
                        ifrmChild.ShowDialog();
                        break;
                    case enumSelectedGrid.Detail1Selected:
                        //ifrmChild = new frmCustomerUpdate(this);
                        //ifrmChild.ShowDialog();
                        //break;
                        if (!FormTools.IsRowSelected(dgvHeader))
                        {
                            return;
                        }
                        headerID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        ifrmChild = new frmCustMotorUpdate(this, headerID, FormTools.enumFormMode.New);
                        ifrmChild.ShowDialog();
                        break;
                    //case enumSelectedGrid.Detail2Selected:
                    //    if (!FormTools.IsRowSelected(dgvHeader))
                    //    {
                    //        return;
                    //    }
                    //    headerID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    //    ifrmChild = new frmCustMemberUpdate(this, headerID, FormTools.enumFormMode.New);
                    //    ifrmChild.ShowDialog();
                    //    break;
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            Guid rowID;

            try
            {
                ISA.Bengkel.BaseForm ifrmChild;
                switch (selectedGrid)
                {
                    case enumSelectedGrid.HeaderSelected:
                        if (dgvHeader.Rows.Count > 0)
                        {
                            if (_rowIDdetail == Guid.Empty)
                            {
                                _rowIDdetail = (Guid)dgvDetail1.SelectedCells[0].OwningRow.Cells["RowID2"].Value;
                            }

                            rowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            ifrmChild = new frmCustomerUpdate(this, rowID, _rowIDdetail, FormTools.enumFormMode.Update);
                            //ifrmChild = new frmCustomerUpdate(this, rowID, _rowIDdetail);
                            ifrmChild.ShowDialog();
                        }
                        break;
                    case enumSelectedGrid.Detail1Selected:
                        if (dgvDetail1.Rows.Count > 0)
                        {
                            rowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            _rowIDdetail = (Guid)dgvDetail1.SelectedCells[0].OwningRow.Cells["RowID2"].Value;
                            ifrmChild = new frmCustMotorUpdate(this, rowID, _rowIDdetail, FormTools.enumFormMode.Update);
                            //ifrmChild = new frmCustomerUpdate(this, rowID, _rowIDdetail);
                            //ifrmChild = new frmCustMotorUpdate(this, rowID);
                            ifrmChild.ShowDialog();
                        }
                        break;
                    case enumSelectedGrid.Detail2Selected:
                        if (dgvDetail2.Rows.Count > 0)
                        {
                            rowID = (Guid)dgvDetail2.SelectedCells[0].OwningRow.Cells["RowID3"].Value;
                            ifrmChild = new frmCustMemberUpdate(this, rowID, FormTools.enumFormMode.Update);
                            ifrmChild.ShowDialog();
                        }
                        break;
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.None:
                    MessageBox.Show(Messages.Error.RowNotSelected);
                    break;
                case enumSelectedGrid.HeaderSelected:
                    DeleteHeader();
                    break;
                case enumSelectedGrid.Detail1Selected:
                    DeleteDetail1();
                    break;
                case enumSelectedGrid.Detail2Selected:
                    DeleteDetail2();
                    break;
            }
        }

        private void DeleteHeader()
        {
            if (FormTools.IsRowSelected(dgvHeader))
            {
                Guid rowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_bkl_mCustomerService_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }

                        MessageBox.Show("Record telah dihapus");
                        this.RefreshData(FormTools.detailIndex.header);
                        this.RefreshData(FormTools.detailIndex.detail1);
                        this.RefreshData(FormTools.detailIndex.detail2);
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
        }

        private void DeleteDetail1()
        {
            if (FormTools.IsRowSelected(dgvDetail1))
            {
                Guid rowID = (Guid)dgvDetail1.SelectedCells[0].OwningRow.Cells["RowID2"].Value;
                if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_bkl_mMotorService_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }

                        MessageBox.Show("Record telah dihapus");
                        this.RefreshData(FormTools.detailIndex.detail1);
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
        }

        private void DeleteDetail2()
        {
            if (FormTools.IsRowSelected(dgvDetail2))
            {
                Guid rowID = (Guid)dgvDetail2.SelectedCells[0].OwningRow.Cells["RowID3"].Value;
                if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_bkl_mMemberService_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }

                        MessageBox.Show("Record telah dihapus");
                        this.RefreshData(FormTools.detailIndex.detail2);
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            if (!this.MaximizeBox)
            {
                this.DialogResult = DialogResult.No;
            }

            this.Close();
        }


        public void FindHeader(string columnName, string value)
        {
            dgvHeader.FindRow(columnName, value);
        }

        public void FindDetail(string columnName, string value)
        {
            dgvDetail1.FindRow(columnName, value);
        }
        
        //public void Findrow(string columnName, string value)
        //{
        //    switch (idx)
        //    {
        //        case FormTools.detailIndex.detail1:
        //            dgvDetail1.FindRow(columnName, value);
        //            break;
        //        case FormTools.detailIndex.detail2:
        //            dgvDetail2.FindRow(columnName, value);
        //            break;
        //    }
        //}

        //public void FindRow(FormTools.detailIndex idx, string columnName, string value)
        //{
        //    switch (idx)
        //    {
        //        case FormTools.detailIndex.detail1:
        //            dgvDetail1.FindRow(columnName, value);
        //            break;
        //        case FormTools.detailIndex.detail2:
        //            dgvDetail2.FindRow(columnName, value);
        //            break;               
        //    }
        //}

        //public void FindRow(Controls.CustomGridView dgv,string columnName, string value)
        //{
        //    dgv.FindRow(columnName, value);
        //}

        private void dgvHeader_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
            if (dgvDetail1.SelectedCells.Count > 0)
            {
                _rowIDdetail = (Guid)dgvDetail1.SelectedCells[0].OwningRow.Cells["RowID2"].Value;
            }
        }

        private void dgvDetail1_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.Detail1Selected;
            if (dgvDetail1.SelectedCells.Count > 0)
            {
                _rowIDdetail = (Guid)dgvDetail1.SelectedCells[0].OwningRow.Cells["RowID2"].Value;
            }
        }

        private void dgvDetail2_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.Detail2Selected;
        }

        private void dgvHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            LoadDataDetail1();
            LoadDataDetail2();
            if (dgvDetail1.SelectedCells.Count > 0)
            {
                _rowIDdetail = (Guid)dgvDetail1.SelectedCells[0].OwningRow.Cells["RowID2"].Value;
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            LoadDataHeader();
        }

        private void txtNama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdSearch.PerformClick();
            }
        }

        private void ConfirmSelect()
        {
            if (!this.MaximizeBox)
            {
                if (FormTools.IsRowSelected(dgvHeader))
                {
                    _customerServiceRowID = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    _idCust = dgvHeader.SelectedCells[0].OwningRow.Cells["idcust"].Value.ToString();
                    _kodeCust = dgvHeader.SelectedCells[0].OwningRow.Cells["kd_cust"].Value.ToString();
                    _namaCust = dgvHeader.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();
                    _noID = dgvHeader.SelectedCells[0].OwningRow.Cells["no_id"].Value.ToString();
                    _alamat = dgvHeader.SelectedCells[0].OwningRow.Cells["alamat"].Value.ToString();
                    _kota = dgvHeader.SelectedCells[0].OwningRow.Cells["kota"].Value.ToString();
                    _daerah = dgvHeader.SelectedCells[0].OwningRow.Cells["daerah"].Value.ToString();
                    _noTelp = dgvHeader.SelectedCells[0].OwningRow.Cells["telpon"].Value.ToString();
                }

                if (FormTools.IsRowSelected(dgvDetail1))
                {
                    _motorServiceRowID = (Guid)dgvDetail1.SelectedCells[0].OwningRow.Cells["RowID2"].Value;
                    _kodeCust = dgvDetail1.SelectedCells[0].OwningRow.Cells["kd_cust2"].Value.ToString();
                    _pemilik = dgvDetail1.SelectedCells[0].OwningRow.Cells["pemilik"].Value.ToString();
                    _noID = dgvDetail1.SelectedCells[0].OwningRow.Cells["no_id2"].Value.ToString();
                    _alamat = dgvDetail1.SelectedCells[0].OwningRow.Cells["alamat2"].Value.ToString();
                    _kota = dgvDetail1.SelectedCells[0].OwningRow.Cells["kota2"].Value.ToString();
                    _daerah = dgvDetail1.SelectedCells[0].OwningRow.Cells["daerah2"].Value.ToString();
                    _noTelp = dgvDetail1.SelectedCells[0].OwningRow.Cells["no_telp2"].Value.ToString();
                    _noPol = dgvDetail1.SelectedCells[0].OwningRow.Cells["no_pol"].Value.ToString(); ;
                    _kodeSpm = dgvDetail1.SelectedCells[0].OwningRow.Cells["kode"].Value.ToString(); ;
                    _jnsSpm = dgvDetail1.SelectedCells[0].OwningRow.Cells["jns_spm"].Value.ToString(); ;
                    _spm = dgvDetail1.SelectedCells[0].OwningRow.Cells["spm"].Value.ToString(); ;
                    _noMesin = dgvDetail1.SelectedCells[0].OwningRow.Cells["no_mesin"].Value.ToString(); ;
                    _noRangka = dgvDetail1.SelectedCells[0].OwningRow.Cells["no_rangka"].Value.ToString(); ;
                    _warna = dgvDetail1.SelectedCells[0].OwningRow.Cells["warna"].Value.ToString(); ;
                    _tahun = dgvDetail1.SelectedCells[0].OwningRow.Cells["tahun"].Value.ToString(); ;
                }

                if (FormTools.IsRowSelected(dgvDetail2))
                {
                    _memberServiceRowID = (Guid)dgvDetail2.SelectedCells[0].OwningRow.Cells["RowID3"].Value;
                    _idMember = dgvDetail2.SelectedCells[0].OwningRow.Cells["id_member"].Value.ToString();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void dgvHeader_DoubleClick(object sender, EventArgs e)
        {
            if (!this.MaximizeBox)
            {
                ConfirmSelect();
            }
        }

        private void dgvHeader_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                cmdADD.PerformClick();
            }
            else if (e.KeyCode == Keys.Space)
            {
                cmdEDIT.PerformClick();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DeleteHeader();
            }
            else
            {
                if (!this.MaximizeBox && FormTools.IsRowSelected(dgvHeader) && e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    ConfirmSelect();
                }
            }
        }

        private void dgvDetail1_DoubleClick(object sender, EventArgs e)
        {
            if (!this.MaximizeBox)
            {
                ConfirmSelect();
            }
        }

        private void dgvDetail1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                cmdADD.PerformClick();
            }
            else if (e.KeyCode == Keys.Space)
            {
                cmdEDIT.PerformClick();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DeleteDetail1();
            }
            else
            {
                if (!this.MaximizeBox && FormTools.IsRowSelected(dgvDetail1) && e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    ConfirmSelect();
                }
            }
        }

        private void dgvDetail2_DoubleClick(object sender, EventArgs e)
        {
            if (!this.MaximizeBox)
            {
                ConfirmSelect();
            }
        }

        private void dgvDetail2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteDetail2();
            }
            else
            {
                if (!this.MaximizeBox && FormTools.IsRowSelected(dgvDetail2) && e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    ConfirmSelect();
                }
            }            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string cNoPol = Tools.isNull(txtNoPol.Text, "").ToString();

                //if (cNoPol != "")
                //{
                //    try
                //    {
                //        using (Database db = new Database())
                //        {
                //            DataTable dt = new DataTable();
                //            db.Commands.Add(db.CreateCommand("usp_bkl_SearchData_LIST"));
                //            db.Commands[0].Parameters.Add(new Parameter("@Search", SqlDbType.VarChar, cNoPol));
                //            dt = db.Commands[0].ExecuteDataTable();
                //            if (dt.Rows.Count > 0)
                //            {
                //                ISA.Bengkel.BaseForm ifrmChild;
                //                ifrmChild = new Master.frmCustomerFilterBrowse(this,dt);
                //                ifrmChild.ShowDialog();


                //                //LoadDataHeader();
                //                //LoadDataDetail1();
                //                //LoadDataDetail2();
                //                //Guid mcRowID = new Guid(Tools.isNull(dt.Rows[0]["CustomerRowID"], Guid.Empty).ToString());
                //                //Guid msRowID = new Guid(Tools.isNull(dt.Rows[0]["MotorRowID"], Guid.Empty).ToString());
                //                //FindHeader("RowID", mcRowID.ToString());
                //                //FindDetail("RowID2", msRowID.ToString());
                //            }
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        Error.LogError(ex);
                //    }
                //}
            }
        }
    }
}
