using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.Common;
using ISA.Toko.Controls;

namespace ISA.Toko.Persediaan
{
    public partial class frmStokOpname : ISA.Toko.BaseForm
    {
        int prevGrid1Row = -1;

        #region "Var"
        enum enumSelectedGrid { Header, Detail1, Detail2, Detail3 };
        enumSelectedGrid SelectedGrid = enumSelectedGrid.Header;

        Boolean Finish;

        //Header
        Guid _RowID;
        DateTime _Tgl;
        string _KodeBarang, _NamaBarang, _RecordID;
        DataTable dtKoderak = new DataTable("KodeRak");
        DataTable dt = new DataTable("Opname");
        DataTable dtBarang = new DataTable("Barang");
        string sort = "";

        #endregion

        #region "Function"
        private void FillHeader()
        {
            _RowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            _Tgl = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglStok"].Value;
            _RecordID = dataGridHeader.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();
            _KodeBarang = dataGridHeader.SelectedCells[0].OwningRow.Cells["KodeBarang"].Value.ToString();
            _NamaBarang = dataGridHeader.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();
        }

        private void FillHP()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_GetHrgBeli"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, _KodeBarang));

                    db.Commands[0].Parameters.Add(new Parameter("@Tgl", SqlDbType.DateTime, _Tgl));
                    db.Commands[0].Parameters.Add(new Parameter("@Mode", SqlDbType.VarChar, "AVG"));

                    dt = db.Commands[0].ExecuteDataTable();
                    txtHPP.Text = Tools.isNull(dt.Rows[0]["HrgBeli"], "0").ToString();
                    lblNamaStok.Text = _NamaBarang;
                    dt.Dispose();
                    db.Dispose();
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

        private void RefreshHeader()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Opname_List"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (comboBox1.SelectedValue.ToString() == "KodeRak")
                {
                    sort = "KodeRak, RowNo";
                }
                else
                {
                    sort = "RowNo";
                }

                dt.DefaultView.Sort = sort;
                dataGridHeader.DataSource = dt.DefaultView;
                if (dataGridHeader.SelectedCells.Count > 0)
                {
                    FillHeader();
                    FillHP();
                    RefreshDetail();
                    ChekingGrid();
                }
                else
                {
                    dataGridDetail1.DataSource = null;
                    dataGridDetail2.DataSource = null;
                    dataGridDetail3.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                Finish = true;
            }
        }

        private void RefreshHeader(string Like)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Opname_List"));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaStok", SqlDbType.VarChar, Like));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (comboBox1.SelectedValue.ToString() == "KodeRak")
                {
                    sort = "KodeRak, RowNo";
                }else
                {
                    sort = "RowNo";
                }
                
                dt.DefaultView.Sort = sort;
                dataGridHeader.DataSource = dt.DefaultView;
                if (dataGridHeader.SelectedCells.Count > 0)
                {
                    FillHeader();
                    FillHP();
                    RefreshDetail();
                    ChekingGrid();
                }
                else
                {
                    dataGridDetail1.DataSource = null;
                    dataGridDetail2.DataSource = null;
                    dataGridDetail3.DataSource = null;
                }
            
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                Finish = true;
            }
        }

       
        public void RefreshDetail()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt1 = new DataTable();
                    DataTable dt2 = new DataTable();
                    DataTable dt3 = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_opnameDetail1_list"));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _RowID));

                    db.Commands.Add(db.CreateCommand("usp_opnameDetail2_list"));
                    db.Commands[1].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _RowID));

                    db.Commands.Add(db.CreateCommand("usp_opnameDetail3_list"));
                    db.Commands[2].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _RowID));


                    dt1 = db.Commands[0].ExecuteDataTable();
                    dt2 = db.Commands[1].ExecuteDataTable();
                    dt3 = db.Commands[2].ExecuteDataTable();

                    dataGridDetail1.DataSource = dt1;
                    dataGridDetail2.DataSource = dt2;
                    dataGridDetail3.DataSource = dt3;
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

        private void DeleteAll()
        {
            if (dataGridDetail3.SelectedCells.Count > 0)
            {
                if (MessageBox.Show("Hapus record Hitung 3 ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_OpnameDetail3_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dataGridDetail3.SelectedCells[0].OwningRow.Cells["RowID3"].Value));

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
                        RefreshDetail();
                    }
                }
            }

            //Data2
            if (dataGridDetail2.SelectedCells.Count > 0)
            {
                if (MessageBox.Show("Hapus record Hitung 2 ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_OpnameDetail2_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dataGridDetail2.SelectedCells[0].OwningRow.Cells["RowID2"].Value));

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
                        RefreshDetail();
                    }
                }
            }

            if (dataGridDetail1.SelectedCells.Count > 0)
            {
                if (MessageBox.Show("Hapus record Hitung 1?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_OpnameDetail1_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dataGridDetail1.SelectedCells[0].OwningRow.Cells["RowID1"].Value));

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
                        RefreshDetail();
                    }
                }
            }

        }

        private void ChekingGrid()
        {
            if (dataGridHeader.SelectedCells.Count > 0 && dataGridDetail1.SelectedCells.Count == 0)
            {
                SelectedGrid = enumSelectedGrid.Detail1;
            }

            if (dataGridDetail2.SelectedCells.Count == 0 && dataGridDetail1.SelectedCells.Count > 0)
            {
                SelectedGrid = enumSelectedGrid.Detail2;
            }

            if (dataGridDetail3.SelectedCells.Count == 0 && dataGridDetail2.SelectedCells.Count > 0)
            {
                SelectedGrid = enumSelectedGrid.Detail3;
            }
        }
        #endregion

        public frmStokOpname()
        {
            InitializeComponent();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            switch (this.ActiveControl.Name)
            {
                case "dataGridDetail1": SelectedGrid = enumSelectedGrid.Detail1; break;
                case "dataGridDetail2": SelectedGrid = enumSelectedGrid.Detail2; break;
                case "dataGridDetail3": SelectedGrid = enumSelectedGrid.Detail3; break;
            }

            switch (SelectedGrid)
            {
                //             case enumSelectedGrid.Header:
                // 
                //                 DeleteAll();
                //             break;
                case enumSelectedGrid.Detail3:
                    if (dataGridDetail3.SelectedCells.Count > 0)
                    {
                        if (MessageBox.Show("Hapus record Hitung 3 ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                this.Cursor = Cursors.WaitCursor;
                                using (Database db = new Database())
                                {
                                    DataTable dt = new DataTable();
                                    db.Commands.Add(db.CreateCommand("usp_OpnameDetail3_DELETE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dataGridDetail3.SelectedCells[0].OwningRow.Cells["RowID3"].Value));

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
                    }
                    break;
                case enumSelectedGrid.Detail2:
                    if (dataGridDetail2.SelectedCells.Count > 0 && dataGridDetail3.SelectedCells.Count == 0)
                    {
                        if (MessageBox.Show("Hapus record Hitung 2 ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                this.Cursor = Cursors.WaitCursor;
                                using (Database db = new Database())
                                {
                                    DataTable dt = new DataTable();
                                    db.Commands.Add(db.CreateCommand("usp_OpnameDetail2_DELETE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dataGridDetail2.SelectedCells[0].OwningRow.Cells["RowID2"].Value));

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
                    }
                    break;
                case enumSelectedGrid.Detail1:
                    if (dataGridDetail1.SelectedCells.Count > 0 && dataGridDetail2.SelectedCells.Count == 0)
                    {
                        if (MessageBox.Show("Hapus record Hitung 1 ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                this.Cursor = Cursors.WaitCursor;
                                using (Database db = new Database())
                                {
                                    DataTable dt = new DataTable();
                                    db.Commands.Add(db.CreateCommand("usp_OpnameDetail1_DELETE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dataGridDetail1.SelectedCells[0].OwningRow.Cells["RowID1"].Value));

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
                    }
                    break;
            }

            RefreshDetail();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            switch (this.ActiveControl.Name)
            {
                case "dataGridDetail1": SelectedGrid = enumSelectedGrid.Detail1; break;
                case "dataGridDetail2": SelectedGrid = enumSelectedGrid.Detail2; break;
                case "dataGridDetail3": SelectedGrid = enumSelectedGrid.Detail3; break;
            }

            switch (SelectedGrid)
            {
                case enumSelectedGrid.Header:

                    break;
                case enumSelectedGrid.Detail1:
                    if (dataGridHeader.SelectedCells.Count > 0)
                    {
                        Persediaan.frmStokOpnameDetailUpdate ifrmChild = new Persediaan.frmStokOpnameDetailUpdate(this, 1, _RowID, _RecordID, _NamaBarang);
                        //ifrmChild.MdiParent = Program.MainForm;
                        //Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.ShowDialog();
                    }
                    break;
                case enumSelectedGrid.Detail2:
                    if (dataGridDetail1.SelectedCells.Count > 0)
                    {
                        Persediaan.frmStokOpnameDetailUpdate ifrmChild = new Persediaan.frmStokOpnameDetailUpdate(this, 2, _RowID, _RecordID, _NamaBarang);
                        //ifrmChild.MdiParent = Program.MainForm;
                        //Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.ShowDialog();
                    }
                    break;
                case enumSelectedGrid.Detail3:
                    if (dataGridDetail2.SelectedCells.Count > 0)
                    {
                        Persediaan.frmStokOpnameDetailUpdate ifrmChild = new Persediaan.frmStokOpnameDetailUpdate(this, 3, _RowID, _RecordID, _NamaBarang);
                        //ifrmChild.MdiParent = Program.MainForm;
                        //Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.ShowDialog();
                    }
                    break;
            }
            return;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StokOpname_Load(object sender, EventArgs e)
        {

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            DataTable dtTemp = new DataTable();
            DataColumn dc = new DataColumn("TR");
            dtTemp.Columns.Add(dc);
            dtTemp.Rows.Add("Nama Barang");
            dtTemp.Rows.Add("KodeRak");
            dtTemp.Rows.Add("RowNo");
            dtTemp.Rows.Add("KodeRak2");
            dtTemp.Rows.Add("KodeRak3");
            //mus tambah
            dtTemp.Rows.Add("Barcode");
            //mus selesai tambah
            dtTemp.DefaultView.Sort = "TR DESC";

            comboBox1.DataSource = dtTemp.DefaultView;
            comboBox1.DisplayMember = "TR";
            comboBox1.ValueMember = "TR";
            Finish = false;

            lblNamaStok.Text = "";
            dataGridHeader.AutoGenerateColumns = false;
            dataGridDetail1.AutoGenerateColumns = false;
            dataGridDetail2.AutoGenerateColumns = false;
            dataGridDetail3.AutoGenerateColumns = false;
            NamaStok.MinimumWidth = 300;
            NamaStok.Width = 400;
            dataGridHeader.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            NamaStok.MinimumWidth = 300;
            NamaStok.Width = 400;

            RowNo.Width = 75;
            KodeBarang.Width = 120;

            RefreshHeader();
           

 
          

        }

        private void dataGridHeader_Click(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                FillHeader();
                ChekingGrid();
            }
        }

        private void dataGridDetail1_Click(object sender, EventArgs e)
        {
            SelectedGrid = enumSelectedGrid.Detail1;
        }

        private void dataGridDetail2_Click(object sender, EventArgs e)
        {
            SelectedGrid = enumSelectedGrid.Detail2;
        }

        private void dataGridDetail3_Click(object sender, EventArgs e)
        {
            SelectedGrid = enumSelectedGrid.Detail3;
        }

        private void dataGridHeader_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridHeader.Rows.Count > 0)
            {
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                {

                    string search = txtSeacrh.Text;
                    if (search.Length > 0)
                    {
                        search = search.Substring(0, search.Length - 1);
                        txtSeacrh.Text = search;
                    }

                }

                switch (e.KeyCode)
                {
                    case Keys.Insert:
                        if (dataGridHeader.SelectedCells.Count > 0 && dataGridDetail1.SelectedCells.Count == 0)
                        {
                            SelectedGrid = enumSelectedGrid.Detail1;
                        }

                        if (dataGridDetail2.SelectedCells.Count == 0 && dataGridDetail1.SelectedCells.Count > 0)
                        {
                            SelectedGrid = enumSelectedGrid.Detail2;
                        }

                        if (dataGridDetail3.SelectedCells.Count == 0 && dataGridDetail2.SelectedCells.Count > 0)
                        {
                            SelectedGrid = enumSelectedGrid.Detail3;
                        }
                        //cmdAdd.PerformClick();
                        break;
                    case Keys.Space:
                        {
                            if (dataGridDetail1.SelectedCells.Count > 0)
                            {
                                SelectedGrid = enumSelectedGrid.Detail1;
                            }

                            if (dataGridDetail2.SelectedCells.Count > 0)
                            {
                                SelectedGrid = enumSelectedGrid.Detail2;
                            }

                            if (dataGridDetail3.SelectedCells.Count > 0)
                            {
                                SelectedGrid = enumSelectedGrid.Detail3;
                            }
                            //cmdEdit.PerformClick();
                        }

                        break;
                    case Keys.Delete:
                        {

                            cmdDelete.PerformClick();
                        }
                        break;
                }
            }

        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            switch (SelectedGrid)
            {

                case enumSelectedGrid.Detail1:
                    if (dataGridDetail1.SelectedCells.Count > 0)
                    {
                       
                        Persediaan.frmStokOpnameDetailUpdate ifrmChild = new Persediaan.frmStokOpnameDetailUpdate(this, 1, (Guid)dataGridDetail1.SelectedCells[0].OwningRow.Cells["RowID1"].Value,_NamaBarang);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
                    break;
                case enumSelectedGrid.Detail2:
                    if (dataGridDetail2.SelectedCells.Count > 0)
                    {
                        Persediaan.frmStokOpnameDetailUpdate ifrmChild = new Persediaan.frmStokOpnameDetailUpdate(this, 2, (Guid)dataGridDetail2.SelectedCells[0].OwningRow.Cells["RowID2"].Value, _NamaBarang);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
                    break;
                case enumSelectedGrid.Detail3:
                    if (dataGridDetail3.SelectedCells.Count > 0)
                    {
                        Persediaan.frmStokOpnameDetailUpdate ifrmChild = new Persediaan.frmStokOpnameDetailUpdate(this, 3, (Guid)dataGridDetail3.SelectedCells[0].OwningRow.Cells["RowID3"].Value, _NamaBarang);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
                    break;
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            Finish = false;
            RefreshHeader("");
        }

       
        public void FindHeader(string columnName, string value)
        {
            dataGridHeader.FindRow(columnName, value);
        }
        public void FindDetail1(string columnName, string value)
        {
            dataGridDetail1.FindRow(columnName, value);
        }
        public void FindDetail2(string columnName, string value)
        {
            dataGridDetail2.FindRow(columnName, value);
        }
        public void FindDetail3(string columnName, string value)
        {
            dataGridDetail3.FindRow(columnName, value);
        }

        private void dataGridDetail1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmdDelete.PerformClick();
            }
        }

        private void dataGridDetail2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmdDelete.PerformClick();
            }
        }

        private void dataGridDetail3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmdDelete.PerformClick();
            }
        }

        private void dataGridHeader_Validated(object sender, EventArgs e)
        {
          
        }

        private void txtSeacrh_TextChanged(object sender, EventArgs e)
        {
            if (txtSeacrh.Text.Trim().Length > 0)
            {
                string search = txtSeacrh.Text.Trim();
                for (int i = 0; i < (dataGridHeader.Rows.Count); i++)
                {
                    string col = "";
                    switch (comboBox1.Text)
                    {
                        case "KodeRak":
                            col = "KodeRak";
                            break;
                        case "Nama Barang":
                            col = "NamaStok";
                            break;
                        case "RowNo":
                            col = "RowNo";
                            break;
                        case "KodeRak2":
                            col = "KdRak2";
                            break;
                        case "KodeRak3":
                            col = "KodeRak3";
                            break;
                        case "Barcode":
                            col = "Barcode";
                            break;
                            
                    }
                    if (dataGridHeader.Rows[i].Cells[col].Value.ToString().StartsWith(search))
                    {
                        dataGridHeader.Rows[i].Cells[col].Selected = true;
                        return; // stop looping
                    }
                }
            }

        }

        private void dataGridHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            
                if (dataGridHeader.SelectedCells.Count > 0)
                {
                    FillHeader();
                    FillHP();
                    RefreshDetail();
                    ChekingGrid();
                }else
                {
                     dataGridDetail1.DataSource = null;
                    dataGridDetail2.DataSource = null;
                    dataGridDetail3.DataSource = null;
                }
            }

        private void dataGridHeader_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                string searchs = txtSeacrh.Text;
                searchs += e.KeyChar;
                txtSeacrh.Text = searchs;
            }
        }

        private void SearchType(object sender, KeyPressEventArgs e)
        {
          

            string search = txtSeacrh.Text.Trim();
            if (search.Length>0)
            {
                for (int i = 0; i < (dataGridHeader.Rows.Count); i++)
                {
                    string col = "";
                    switch (comboBox1.Text)
                    {
                        case "KodeRak":
                            col = "KodeRak";
                            break;
                        case "Nama Barang":
                            col = "NamaStok";
                            break;
                        case "RowNo":
                            col = "RowNo";
                            break;
                    }
                    if (dataGridHeader.Rows[i].Cells[col].Value.ToString().StartsWith(search))
                    {
                        dataGridHeader.Rows[i].Cells[col].Selected = true;
                        return; // stop looping
                    }
                }
            }
          
        }

    }

}
