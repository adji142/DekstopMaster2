using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;
using ISA.Toko.Class;
using ISA.Toko;

namespace ISA.Toko.xpdc
{
    public partial class frm_detail_xpdc_Jkoli : ISA.Controls.BaseForm
    {
        DataTable dtGet,dtGetx;
        Guid _rowID = Guid.Empty;
        string cKoli= string.Empty;
        string cPcs = string.Empty;
        string cKet = string.Empty;
        int nKoli, nPcs;
        
        public frm_detail_xpdc_Jkoli(Form Caller, Guid rowID)
        {
            InitializeComponent();
            _rowID = rowID;
            this.Caller = Caller;
        }

        private void frm_detail_xpdc_Jkoli_Load(object sender, EventArgs e)
        {
            dtGet = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PengirimanXpdcDetail_GRIDLIST"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                dtGet = db.Commands[0].ExecuteDataTable();
                //MessageBox.Show(dtGet.Rows.Count.ToString());
            }
            dataGridxpdcDetailKoli.DataSource = dtGet;
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            UpdateDataKoli(dtGet);
            if (this.Caller is frm_kirim)
            {
                frm_kirim frmCaller = (frm_kirim)this.Caller;
                frmCaller.RefreshDataDetail();
            }
            this.Close();
        }


        private void UpdateDataKoli(DataTable dtGetx)
        {
            try
            {
                using (Database db = new Database())
                {
                    for (int i = 0; i < dtGetx.Rows.Count; i++)
                    {
                        string cKet = string.Empty;
                        int nKoli= 0;
                        int nPcs = 0;

                        nKoli = Convert.ToInt16(dtGetx.Rows[i]["JumlahKoli"]);
                        nPcs = Convert.ToInt16(dtGetx.Rows[i]["JumlahPcs"]);
                        
                        if (nKoli > 0 && nPcs > 0)
                        {
                            cKet = Convert.ToString(nKoli) + " Coly, " + Convert.ToString(nPcs) + " Pcs";
                        }
                        else
                        {
                            if (nKoli > 0 && (nPcs == 0 || nPcs == null))
                            {
                                cKet = Convert.ToString(nKoli) + " Coly";
                            }
                            else
                            {
                                cKet = "";
                            }
                        }

                        db.Commands.Add(db.CreateCommand("[usp_PengirimanXpdcDetail_UPDATEKOLI]"));
                        db.Commands[i].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[i].Parameters.Add(new Parameter("@Koli", SqlDbType.Int, dtGetx.Rows[i]["JumlahKoli"]));
                        db.Commands[i].Parameters.Add(new Parameter("@Pcs", SqlDbType.Int, dtGetx.Rows[i]["JumlahPcs"]));
                        db.Commands[i].Parameters.Add(new Parameter("@KetKoli", SqlDbType.VarChar, cKet));
                        db.Commands[i].Parameters.Add(new Parameter("@barcode", SqlDbType.VarChar, dataGridxpdcDetailKoli.Rows[i].Cells["barcode"].Value.ToString()));
                    }
                    db.BeginTransaction();
                    for (int j = 0; j < db.Commands.Count; j++)
                    {
                        db.Commands[j].ExecuteNonQuery();
                    }
                    db.CommitTransaction();
                    this.Close();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

    }
}
