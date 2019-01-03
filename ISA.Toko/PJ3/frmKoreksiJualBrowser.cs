using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.PJ3
{
    public partial class frmKoreksiJualBrowser : ISA.Toko.BaseForm
    {
        Guid _notaJualDetailID;
        DataTable dtNotaDetail;
        bool _acak;
        string _format, _recID;

        public frmKoreksiJualBrowser(Form caller, Guid notaJualDetailID, string recID)
        {
            InitializeComponent();
            _notaJualDetailID = notaJualDetailID;
            _recID = recID;
            this.Caller = caller;
        }

        private void frmKoreksiJualBrowse_Load(object sender, EventArgs e)
        {
            _acak = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Focus();
            RefreshDataKoreksiJual();
        }

        public void RefreshDataKoreksiJual()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtKoreksi = new DataTable();
                using (Database db = new Database())
                {
                    
                    db.Commands.Add(db.CreateCommand("usp_KoreksiPenjualan_LIST")); //cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@notaJualDetailID", SqlDbType.UniqueIdentifier, _notaJualDetailID));

                    dtKoreksi = db.Commands[0].ExecuteDataTable();
                }

            dataGridView1.DataSource = dtKoreksi;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != 0)
            {
                MessageBox.Show("Sudah ada koreksi," + System.Environment.NewLine
                        + "tidak bisa buat koreksi lagi!");
                return;
            }
            if (ChekKoreksi())
            {
                return;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtNotaDetail = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_LIST_FILTER_RowID")); //cek heri 12032013
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _notaJualDetailID));

                    dtNotaDetail = db.Commands[0].ExecuteDataTable();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            //MessageBox.Show(_notaJualDetailID.ToString());
            PJ3.frmKoreksiJualUpdate ifrmChild = new PJ3.frmKoreksiJualUpdate(this, dtNotaDetail);
            ifrmChild.ShowDialog();
            if (ifrmChild.DialogResult == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                return;
            }
            if (_recID.Substring(0, 3) != GlobalVar.PerusahaanID)
            {
                MessageBox.Show("Maaf, hapus koreksi hanya dapat dilakukan di cabang/posko "+GlobalVar.PerusahaanID+" saja");
                return;
            }
            if (dataGridView1.SelectedCells[0].OwningRow.Cells["LinkID"].Value.ToString() != "")
            {
                MessageBox.Show("DATA SUDAH LINK !, TIDAK BISA DIHAPUS...");
                return;
            }
            if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                try
                {
                    GlobalVar.LastClosingDate = (DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglKoreksi"].Value;
                    if ((DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglKoreksi"].Value <= GlobalVar.LastClosingDate)
                    {
                        throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                    }
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_KoreksiPenjualan_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                        db.Commands[0].ExecuteNonQuery();
                    }

                    MessageBox.Show("Record telah dihapus");
                    this.RefreshDataKoreksiJual();
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

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    AcakTampilHrg();
                    break;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            double hrgJualBaru = double.Parse(Tools.isNull(dataGridView1.Rows[e.RowIndex].Cells["HrgJual"].Value, 0).ToString());
            double hrgJualKor = double.Parse(Tools.isNull(dataGridView1.Rows[e.RowIndex].Cells["HrgJualKoreksi"].Value, 0).ToString());

            dataGridView1.Rows[e.RowIndex].Cells["HrgJual"].Style.Format = "#,##0";
            dataGridView1.Rows[e.RowIndex].Cells["HrgJualKoreksi"].Style.Format = "#,##0";

            dataGridView1.Rows[e.RowIndex].Cells["HrgJualAck"].Value = Tools.GetAntiNumeric(hrgJualBaru.ToString("#,##0"));
            dataGridView1.Rows[e.RowIndex].Cells["HrgJualKoreksiAck"].Value = Tools.GetAntiNumeric(hrgJualKor.ToString("#,##0"));

            dataGridView1.Rows[e.RowIndex].Cells["HrgJualAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Rows[e.RowIndex].Cells["HrgJualKoreksiAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            
        }

        private void AcakTampilHrg()
        {
            _acak = !_acak;

            dataGridView1.Columns["HrgJual"].Visible = !_acak;
            dataGridView1.Columns["HrgJualKoreksi"].Visible = !_acak;

            dataGridView1.Columns["HrgJualAck"].Visible = _acak;
            dataGridView1.Columns["HrgJualKoreksiAck"].Visible = _acak;            
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void FindRow(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }

        private void frmKoreksiJualBrowser_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is frmPJ3Browser)
            {
                frmPJ3Browser frmCaller = (frmPJ3Browser)this.Caller;
                frmCaller.RefreshRowDataNotaJualDetail(_notaJualDetailID.ToString());
            }

            if (this.Caller is frmPJ3BrowserISA)
            {
                frmPJ3BrowserISA frmCaller = (frmPJ3BrowserISA)this.Caller;
                frmCaller.RefreshRowDataNotaJualDetail(_notaJualDetailID.ToString());
            }
           
        }

        private bool ChekKoreksi()
        {

            frmPJ3BrowserISA frmCaller = (frmPJ3BrowserISA)this.Caller;
           // frmCaller.RefreshRowDataNotaJualDetail(_notaJualDetailID.ToString());

            //if (frmCaller.CekSudahPernahKoreksi())
            //{
            //    MessageBox.Show("Record ini sudah pernah di Koreksi, tidak boleh dikoreksi");
            //    return true;
            //}

            if (frmCaller.CekSudahPernahRetur())
            {
                MessageBox.Show("Record ini sudah pernah diretur, tidak boleh dikoreksi");
                return true;
            }
            if (frmCaller.CekSudahAdaPotongan())
            {
                MessageBox.Show("Nota ini sudah pernah terjadi potongan (DIL), tidak boleh dikoreksi");
                return true;
            }

            return false;
        }
    }
}
