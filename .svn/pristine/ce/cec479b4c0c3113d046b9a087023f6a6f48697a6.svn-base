using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using System.Drawing.Printing;
using ISA.Common;
using ISA.Finance.Class;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data.SqlTypes;
using Microsoft.Reporting.WinForms;
using ISA.Finance.DataTemplates;

namespace ISA.Finance.Register
{
    public partial class FrmScanBarcode : ISA.Finance.BaseForm
    {
        string cekfisik, barcode_lempar, tglfisik;
        Guid rowidheader;
        int countD_, d, c, psn;
        string dd, bb, pesan, pesan2;
        DataGridView datadetail;
        //string rowidheader;
        //DataTable dtupdate;
        public FrmScanBarcode(Form caller, Guid _rowidheader, string _cekfisik, string _barcode, int countD, string _tglfisik)
        {
            InitializeComponent();
            rowidheader = _rowidheader;
            cekfisik = _cekfisik;
            barcode_lempar = _barcode;
            countD_ = countD;
            tglfisik = _tglfisik;
            this.Caller = caller;
        }

        private void FrmScanBarcode_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(rowidheader.ToString()+"--"+barcode_lempar.ToString()+"--"+cekfisik.ToString());
            TxtNoBarcode.Select();
        }

        private void BtnScan_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (TxtNoBarcode.Text == "")
                {
                    TxtNoBarcode.Select();
                    return;
                }
                if (tglfisik != "")
                {
                    MessageBox.Show("Tanggal Kembali Fisik sudah diupdate sebelumnya..");
                    return;
                }
                //else
                //{               
                        int i = 0;
                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_TagihanDetail_Barcode_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@barcode", SqlDbType.VarChar, TxtNoBarcode.Text.Substring(0,12)));
                            db.Commands[0].Parameters.Add(new Parameter("@rowidheader", SqlDbType.UniqueIdentifier, rowidheader));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();                           
                        }
                       
                            if (this.Caller is frmRegisterBrowser)
                            {
                                frmRegisterBrowser frmCaller = (frmRegisterBrowser)this.Caller;
                                frmCaller.RefreshDetail(rowidheader);
                                datadetail = frmCaller.dataGridDetail;                               
                            }
                    /* start message berhasil atau tidak dengan cara cek apakah barcode tersebut ada di detail/sudah ke update */
                            psn = 0;
                            datadetail.Rows[d].Cells[0].Selected = true;
                            bb = datadetail.SelectedCells[0].OwningRow.Cells["Barcode"].Value.ToString();
                            if (bb == TxtNoBarcode.Text.ToString().Substring(0,12))
                            {
                                psn = psn + 1;
                            }
                            else
                            {
                                psn = psn + 0;
                            }
                            int countpesan = countD_ - 1;
                            for (c = 1; c <= countpesan; c++)
                            {
                                datadetail.Rows[c].Cells[0].Selected = true;
                                bb = datadetail.SelectedCells[0].OwningRow.Cells["Barcode"].Value.ToString();
                                if (bb == TxtNoBarcode.Text.ToString().Substring(0,12))
                                {
                                    psn = psn + 1;
                                }
                                else
                                {
                                    psn = psn + 0;
                                }
                            }
                            //MessageBox.Show(psn.ToString());
                            if (psn > 0)
                            {
                                MessageBox.Show("Scan barcode berhasil..");
                            }
                            else
                            {
                                MessageBox.Show("Barcode dengan nomor '" + TxtNoBarcode.Text.ToString() + "'  tidak ada dalam daftar nota...");
                                TxtNoBarcode.Select();
                                return;
                            }
                    /* end pesan scan barcode */

                    // update tanggal di header jika detail udah ijo semua
                  
                        datadetail.Rows[0].Cells[0].Selected = true;
                        dd = datadetail.SelectedCells[0].OwningRow.Cells["CekFisik"].Value.ToString();

                        if (dd == "True")
                        {
                            i = i + 1;
                        }
                        else
                        {
                            i = 0;
                        }


                        int count2 = countD_ - 1;
                        for (d = 1; d <= count2; d++)
                        {
                            datadetail.Rows[d].Cells[0].Selected = true;
                            dd = datadetail.SelectedCells[0].OwningRow.Cells["CekFisik"].Value.ToString();
                            if (dd == "True")
                            {
                                i = i + 1;
                            }
                            else
                            {
                                i = 0;
                            }
                        }
                            /* start : mengembalikan posisi row terselect ke paling atas */
                                datadetail.Rows[0].Cells[0].Selected = true;
                                dd = datadetail.SelectedCells[0].OwningRow.Cells["CekFisik"].Value.ToString();
                            /* end */

                        if (i == countD_) // jika jumlah rows yang TRUE sama dengan jumlah keseluruhan rows detail
                        {
                            this.Cursor = Cursors.WaitCursor;
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_Tagihan_Barcode_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowidheader", SqlDbType.UniqueIdentifier, rowidheader));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();                               
                            }
                            MessageBox.Show("Update tanggal header berhasil..");
                            if (this.Caller is frmRegisterBrowser)
                            {
                                frmRegisterBrowser frmCaller = (frmRegisterBrowser)this.Caller;
                                frmCaller.RefreshRowDataHeader(rowidheader);
                            }
                            Close();
                        }
                        else
                        {
                            Close();
                        }
                //} // end if ELSE jika tglfisikkembali belum diupdate
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

        private void TxtNoBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnScan_Click(sender, e);
            }
        }

        private void TxtNoBarcode_Validated(object sender, EventArgs e)
        {
            
        }
    }
}
