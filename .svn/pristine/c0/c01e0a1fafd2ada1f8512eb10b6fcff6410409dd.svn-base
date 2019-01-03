using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.Class;
using System.IO;

namespace ISA.Toko.Gudang
{
    public partial class frmDOBeli : ISA.Toko.BaseForm
    {
        private DataTable dtHeader;
        private DataTable dtDetail;

        public frmDOBeli()
        {
            InitializeComponent();
        }

        private void dataGridHeader_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            refreshDataOrderPembelian();
        }

        //  refresh data untuk grid atas
        private void refreshDataOrderPembelian()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (Database db = new Database())
                {
                    // Ditambah 1 karena SPnya tidak mengcover <= 
                    DateTime rgbTglRQNext = Convert.ToDateTime(rgbTglRQ.ToDate).AddDays(1);
                    db.Commands.Add(db.CreateCommand("usp_OrderPembelian_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglRQ.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglRQNext));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                }
                dataGridHeader.DataSource = dtHeader;
                if (dtHeader.Rows.Count > 0)
                {
                    refreshDataOrderPembelianDetail();
                    dataGridHeader.Focus();
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

        // refresh data untuk grid bawah
        public void refreshDataOrderPembelianDetail()
        {
            Guid headerID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
            string tgldo11 = dataGridHeader.SelectedCells[0].OwningRow.Cells["TglRequest"].Value.ToString();
            string headerRec = dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRecID"].Value.ToString();
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPembelianDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, headerID));
                    db.Commands[0].Parameters.Add(new Parameter("@tgldo11", SqlDbType.DateTime, Convert.ToDateTime(tgldo11)));
                    dtDetail = db.Commands[0].ExecuteDataTable();
                }
                dataGridDetail.DataSource = dtDetail;

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

        private void frmDOBeli_Load(object sender, EventArgs e)
        {
            rangeDateTimeStartUpProperties();
        }

        private void rangeDateTimeStartUpProperties()
        {
            rgbTglRQ.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTglRQ.ToDate = DateTime.Now;
            rgbTglRQ.Focus();
        }

        private void dataGridHeader_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                refreshDataOrderPembelianDetail();
            }
        }


        private void dataGridHeader_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.F5: // upload DO ke 11
                    if (!SecurityManager.IsAuditor())
                    {
                        uploadDOKe11();
                    }
                break;
            }
        }

        // upload DO ke 11 langsung gan ..
        private void uploadDOKe11()
        {
            /*if (dataGridHeader.SelectedCells[0].OwningRow.Cells["NoACC"].Value.ToString() == "")
            {
                MessageBox.Show("Belum di ACC");
                return;
            }
            if (dataGridDetail.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada detail");
                return;
            }
            if (dataGridHeader.SelectedCells[0].OwningRow.Cells["Gudang"].Value.ToString() != GlobalVar.PerusahaanID)
            {
                MessageBox.Show("Hanya untuk cabang " + GlobalVar.PerusahaanID);
                return;
            }*/

            Guid rowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
            string noRQ = dataGridHeader.SelectedCells[0].OwningRow.Cells["NoRequest"].Value.ToString();
            if (MessageBox.Show("Upload No.RQ " + noRQ + "?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_OrderPembelianDetail_UPLOAD_11"));
                        db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    Upload(dt);
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

        // dari datatable ke upload file
        private void Upload(DataTable dt)
        {
            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("TglRequest", "tgl_rq", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("NoRequest", "no_rq", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("NamaStok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
            fields.Add(new Foxpro.DataStruct("BarangID", "id_brg", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("QtyRequest", "j_rq", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("C2", "c2", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("QtyBO", "j_bo", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("QtyTambahan", "j_plus", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("QtyAkhir", "j_akhir", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("QtyJual", "j_jual", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("QtyMinimum", "Stok_min", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("QtyMaximum", "Stok_max", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Char, 30));
            fields.Add(new Foxpro.DataStruct("Keterangan", "Keterangan", Foxpro.enFoxproTypes.Char, 30));
            Foxpro.WriteFile(GlobalVar.DbfUpload, "Po_tmp", fields, dt);
            ZipFile("Po_tmp");
            MessageBox.Show("File " + GlobalVar.DbfUpload + "\\dbfmatch.zip", "Succes");
        }

        // making file as compressed file.
        private void ZipFile(string FileName1)
        {
            List<string> files = new List<string>();

            string fileName1 = GlobalVar.DbfUpload + "\\" + FileName1 + ".dbf";


            string fileZipName = GlobalVar.DbfUpload + "\\dbfmatch.zip";
            files.Add(fileName1);


            //Delete File Yg lama jika Ada
            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(files, fileZipName);

            if (File.Exists(fileName1))
            {
                File.Delete(fileName1);

            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
