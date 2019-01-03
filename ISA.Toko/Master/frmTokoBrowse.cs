using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.VisualBasic;

namespace ISA.Toko.Master
{
    public partial class frmTokoBrowse : ISA.Toko.BaseForm
    {
        enum enumFormMode { Header, Detail, Status};
        enumFormMode _selectedGrid;
        DataTable dtToko = new DataTable();
        public frmTokoBrowse()
        {
            InitializeComponent();
        }

        private void frmTokoBrowse_Load(object sender, EventArgs e)
        {
            RefreshDataToko();
            //RefreshDataStatusToko();
            //RefreshDataCabang();
            //dataGridCabang.FindRow("CabangID", GlobalVar.CabangID);
        }

        public void RefreshDataToko()
        {
            try
            {
                using (Database db = new Database())
                {

                    dtToko = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@namaToko", SqlDbType.VarChar, txtSearch.Text));
                    dtToko = db.Commands[0].ExecuteDataTable();
                    dataGridToko.DataSource = dtToko;
                }
                if (dataGridToko.SelectedCells.Count > 0)
                {
                    lblToko.Text = "\"" + (dataGridToko.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString())
                    + "\"  "
                    + (dataGridToko.SelectedCells[0].OwningRow.Cells["Alamat"].Value.ToString());

                    
                        RefreshDataStatusToko();
                    
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void RefreshDataCabang()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dtCabang = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
                    dtCabang = db.Commands[0].ExecuteDataTable();
                    dataGridCabang.DataSource = dtCabang;
                }
                if (dataGridCabang.SelectedCells.Count > 0 && dataGridToko.SelectedCells.Count > 0)
                {
                    RefreshDataStatusToko();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void RefreshDataStatusToko()
        {
            try
            {
                string _kodeToko = dataGridToko.SelectedCells[0].OwningRow.Cells["TokoID"].Value.ToString();

                if (_kodeToko == "")
                {
                    return;
                }
                using (Database db = new Database())
                {
                    DataTable dtStsToko = new DataTable();

                    
                    db.Commands.Add(db.CreateCommand("usp_StatusToko_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                    dtStsToko = db.Commands[0].ExecuteDataTable();
                    dataGridStsToko.DataSource = dtStsToko;
                }
            }
            catch (Exception ex)
            { 
                Error.LogError(ex);
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataToko();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            //Master.frmTokoUpdate ifrmChild = new Master.frmTokoUpdate(this);
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show(); 
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            
        }

        public void FindRow(string columnName, string value)
        {
            dataGridToko.FindRow(columnName, value);
        }



        public void RefreshPlafon()
        {
            try
            {
                string _kodeToko = dataGridToko.SelectedCells[0].OwningRow.Cells["TokoID"].Value.ToString();
               
                using (Database db = new Database())
                {
                    DataTable dtPlafon = new DataTable();

                    
                    db.Commands.Add(db.CreateCommand("usp_PlafonToko_List"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                    dtPlafon = db.Commands[0].ExecuteDataTable();
                    datagridPlafon.DataSource = dtPlafon;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        private void dataGridToko_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //RefreshPlafon();
            _selectedGrid = enumFormMode.Header;
        }

        private void dataGridToko_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridToko.SelectedCells.Count > 0)
            {
                try
                {
                   

                    if (e.Shift == true && e.KeyCode == Keys.K)
                    {
                        string _KodeToko = dataGridToko.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
                        string val = dataGridToko.SelectedCells[0].OwningRow.Cells["Cabang2"].Value.ToString().Trim();
                        dataGridToko.SelectedCells[0].OwningRow.Cells["Cabang2"].Value = EditPT(_KodeToko, val);
                        dataGridToko.RefreshEdit();
                    }

                    
                    if (e.Shift == true && e.KeyCode == Keys.L)
                    {

                        ListToko();

                    }

                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }
               
            }


            switch (e.KeyCode)
            {
                case Keys.Insert:
                    cmdadd.PerformClick();
                    break;
                case Keys.Space:
                    cmdEdit.PerformClick();
                    break;
                case Keys.F5:
                    RefreshDataToko();
                    break;
            }



        }

        private void ListToko()
        {

            DataTable da = dtToko.DefaultView.ToTable().Copy();
            Microsoft.Office.Interop.Excel.ApplicationClass ExcelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
            ExcelApp.Application.Workbooks.Add(Type.Missing);

            progressBar1.Visible = true;
            progressBar1.Maximum = dataGridToko.Rows.Count;
            progressBar1.Value = 0;
            //for (int i = 1; i < dataGridToko.Columns.Count + 1; i++)
            //{
            //    //ExcelApp.Cells[1, i] = dataGridToko.Columns[i - 1].HeaderText;
            //    ExcelApp.Cells[1, 1] = dataGridToko.Columns[0].HeaderText;
            //    ExcelApp.Cells[1, 2] = dataGridToko.Columns[1].HeaderText;
            //}

            ExcelApp.Cells[1, 1] = "Nama Toko";
            ExcelApp.Cells[1, 2] = "Id.Wil";
            ExcelApp.Cells[1, 3] = "Id.Toko";
            ExcelApp.Cells[1, 4] = "K";
            ExcelApp.Cells[1, 5] = "Alamat";
            ExcelApp.Cells[1, 6] = "Kota";
            ExcelApp.Cells[1, 7] = "Daerah";
            ExcelApp.Cells[1, 8] = "Propinsi";
            ExcelApp.Cells[1, 9] = "No.Telp";
            ExcelApp.Cells[1,10] = "Penanggung Jawab";
            ExcelApp.Cells[1,11] = "Hari Sales";
            ExcelApp.Cells[1,12] = "Hari Kirim";
            ExcelApp.Cells[1,13] = "Status";

            int x = 0;
            int i = 0;
            foreach (DataRow dr in da.Rows)
            {
                Application.DoEvents();
                this.Invalidate();

                progressBar1.Value = x;
                x++;
                ExcelApp.Cells[i + 2, 1] = Tools.isNull(dr["NamaToko"],"").ToString().Trim();
                ExcelApp.Cells[i + 2, 2] = Tools.isNull(dr["WilID"],"").ToString().Trim();
                ExcelApp.Cells[i + 2, 3] = Tools.isNull("'"+dr["TokoID"], "").ToString().Trim();
                ExcelApp.Cells[i + 2, 4] = Tools.isNull(dr["Cabang2"],"").ToString().Trim();
                ExcelApp.Cells[i + 2, 5] = Tools.isNull(dr["Alamat"],"").ToString().Trim();
                ExcelApp.Cells[i + 2, 6] = Tools.isNull(dr["Kota"],"").ToString().Trim();
                ExcelApp.Cells[i + 2, 7] = Tools.isNull(dr["Daerah"],"").ToString().Trim();
                ExcelApp.Cells[i + 2, 8] = Tools.isNull(dr["Propinsi"],"").ToString().Trim();
                ExcelApp.Cells[i + 2, 9] = Tools.isNull("'"+dr["Telp"],"").ToString().Trim();
                ExcelApp.Cells[i + 2,10] = Tools.isNull(dr["PenanggungJawab"],"").ToString().Trim();
                ExcelApp.Cells[i + 2,11] = Tools.isNull(dr["HariSales"],"").ToString().Trim();
                ExcelApp.Cells[i + 2,12] = Tools.isNull(dr["JangkaWaktuKredit"],"").ToString().Trim();
                ExcelApp.Cells[i + 2,13] = Tools.isNull(dr["StatusAktif"], "").ToString().Trim();
                i++;
            }

           
            //for (int i = 0; i < dataGridToko.Rows.Count; i++)
            //{
            //    Application.DoEvents();
            //    this.Invalidate();

            //    progressBar1.Value = x;
            //    x++;
            //    for (int j = 0; j < dataGridToko.Columns.Count; j++)
            //    {
            //        //ExcelApp.Cells[i + 2, j + 1] = dataGridToko.Rows[i].Cells[j].Value.ToString();
            //        //ExcelApp.Cells[i + 2, j + 1] = Tools.isNull(dataGridToko.Rows[i].Cells[j].Value,"").ToString();
            //          ExcelApp.Cells[i + 2, 1] = Tools.isNull(dataGridToko.Rows[i].Cells[0].Value, "").ToString();
            //          ExcelApp.Cells[i + 2, 2] = Tools.isNull(dataGridToko.Rows[i].Cells[1].Value, "").ToString();
                    
            //    }
            //}



            ExcelApp.ActiveWorkbook.SaveCopyAs("C:\\Temp\\Toko.xls");
            ExcelApp.ActiveWorkbook.Saved = true;
            ExcelApp.Quit();
            progressBar1.Visible = false;
        }      

        private void EditUraianKpiutang(string txt_, string _kodeToke)
        {
            try
            {
                using (Database db = new Database())
                {
                    //dataGridHeader.SelectedCells[0].OwningRow.Cells["KeteranganTagihan"].Value


                    db.Commands.Add(db.CreateCommand("[usp_Toko_KodePos]"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodePOs", SqlDbType.VarChar, txt_));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, _kodeToke));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private string EditPT(string _KodeToko, string val)
        {
           
                val = (val == "PT" ? "" : "PT");
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_Toko_Cabang2]"));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, val));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, _KodeToko));
                    db.Commands[0].ExecuteNonQuery();
                }

                return val;
        }

        private void dataGridToko_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridToko.SelectedCells.Count > 0)
            {
                lblToko.Text = "\"" + (dataGridToko.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString())
                    + "\"  "
                    + (dataGridToko.SelectedCells[0].OwningRow.Cells["Alamat"].Value.ToString());

               
                    RefreshDataStatusToko();
                

                RefreshPlafon();
            }
        }

        private void dataGridCabang_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridCabang.SelectedCells.Count > 0 && dataGridToko.SelectedCells.Count > 0)
            {
                RefreshDataStatusToko();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridToko_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //RefreshPlafon();
            _selectedGrid = enumFormMode.Header;
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {

            
            if(_selectedGrid == enumFormMode.Header){
                if (dataGridToko.SelectedCells.Count > 0)
                {
                    string _tokoID = dataGridToko.SelectedCells[0].OwningRow.Cells["TokoID"].Value.ToString();

                    
                        Guid rowID = (Guid)dataGridToko.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        Master.frmTokoUpdate ifrmChild = new Master.frmTokoUpdate(this, rowID);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    
                }
                else { MessageBox.Show(Messages.Error.RowNotSelected); }
            }
            else if (_selectedGrid == enumFormMode.Detail)
            {

                if (datagridPlafon.SelectedCells.Count <= 0)
                {
                    MessageBox.Show(Messages.Error.RowNotSelected);
                    return;
                }
                if ((DateTime)datagridPlafon.SelectedCells[0].OwningRow.Cells["tanggal"].Value < GlobalVar.DateOfServer)
                {
                    MessageBox.Show("Tanggal plafon kurang dari tanggal server : " + GlobalVar.DateOfServer.ToString());
                    return;
                }
                if (datagridPlafon.SelectedCells.Count > 0)
                {
                    string _tokoKode = dataGridToko.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
                    Guid rowID = (Guid)datagridPlafon.SelectedCells[0].OwningRow.Cells["Row"].Value;
                    Master.frmTokoPlafonUpdate ifrmChild = new Master.frmTokoPlafonUpdate(this, _tokoKode, rowID);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();


                }
                else { MessageBox.Show(Messages.Error.RowNotSelected); }
            }
            else {
                if (dataGridStsToko.SelectedCells.Count <= 0)
                {
                    MessageBox.Show(Messages.Error.RowNotSelected);
                    return;
                }
                if (Convert.ToDateTime(dataGridStsToko.SelectedCells[0].OwningRow.Cells["TglAktif"].Value.ToString()) < GlobalVar.DateOfServer)
                {
                    MessageBox.Show("Tanggal aktif Kurang dari Tanggal Server(" + GlobalVar.DateOfServer + ")");
                    return; }


                if (datagridPlafon.SelectedCells.Count > 0)
                {
                    string _tokoKode = dataGridToko.SelectedCells[0].OwningRow.Cells["TokoID"].Value.ToString();

                    Guid rowID = (Guid)dataGridStsToko.SelectedCells[0].OwningRow.Cells["StsTokoRowID"].Value;
                    Master.frmTokoStatusUpdate ifrmChild = new Master.frmTokoStatusUpdate(this, _tokoKode, rowID);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();


                }
                else { MessageBox.Show(Messages.Error.RowNotSelected); }
            }
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            Master.frmTokoDownloadData ifrmChild = new Master.frmTokoDownloadData();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void datagridPlafon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectedGrid = enumFormMode.Detail;
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (_selectedGrid == enumFormMode.Header)
            {
                
                   

                    Master.frmTokoUpdate ifrmChild = new Master.frmTokoUpdate(this);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();

                
            }
            else if (_selectedGrid == enumFormMode.Detail)
            {
                if (dataGridToko.SelectedCells.Count > 0)
                {
                    string _tokoKode = dataGridToko.SelectedCells[0].OwningRow.Cells["TokoID"].Value.ToString();
                    Master.frmTokoPlafonUpdate ifrmChild = new Master.frmTokoPlafonUpdate(this, _tokoKode);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
                else
                {
                    MessageBox.Show(Messages.Error.RowNotSelected);
                }

            }
            else {

                if (dataGridToko.SelectedCells.Count > 0)
                {
                    string _tokoKode = dataGridToko.SelectedCells[0].OwningRow.Cells["TokoID"].Value.ToString();
                    Master.frmTokoStatusUpdate ifrmChild = new Master.frmTokoStatusUpdate(this, _tokoKode);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
                else
                {
                    MessageBox.Show(Messages.Error.RowNotSelected);
                }
            }

        }

        private void datagridPlafon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void datagridPlafon_Click(object sender, EventArgs e)
        {
            _selectedGrid = enumFormMode.Detail;
        }

        private void dataGridToko_Click(object sender, EventArgs e)
        {
            _selectedGrid = enumFormMode.Header;
        }

        private void dataGridStsToko_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridStsToko_Click(object sender, EventArgs e)
        {
            _selectedGrid = enumFormMode.Status;
        }

        private void datagridPlafon_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    cmdadd.PerformClick();
                    break;
                case Keys.Space:
                    cmdEdit.PerformClick();
                    break;
                case Keys.F5:
                    RefreshPlafon();
                    break;
            }
        }

        private void dataGridStsToko_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    cmdadd.PerformClick();
                    break;
                case Keys.Space:
                    cmdEdit.PerformClick();
                    break;
                case Keys.F5:
                    RefreshDataStatusToko();
                    break;
            }
        }

        private void dataGridToko_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void datagridPlafon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            datagridPlafon.Columns["Rp_plafon"].DefaultCellStyle.Format = "#,##0";
        }

        private void dataGridToko_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridToko.SelectedCells.Count > 0)
            {
                lblToko.Text = "\"" + (dataGridToko.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString())
                    + "\"  "
                    + (dataGridToko.SelectedCells[0].OwningRow.Cells["Alamat"].Value.ToString());


                RefreshDataStatusToko();


                RefreshPlafon();
            }
        }
        
    
    }

      
    
}
