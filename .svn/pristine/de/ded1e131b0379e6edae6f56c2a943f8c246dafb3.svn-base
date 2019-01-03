using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
using ISA.Trading.Class;
using ISA.Trading;

namespace ISA.Trading.xpdc
{
    public partial class frm_penyelesaian_kiriman : ISA.Controls.BaseForm
    {
        Guid _rowID = Guid.Empty;
        int Sts = 0;
        int nRpBayar = 0;
        string cSts = string.Empty;

        public frm_penyelesaian_kiriman(Form Caller, Guid rowID)
        {
            InitializeComponent();
            _rowID = rowID;
            this.Caller = Caller;
        }

        private void frm_penyelesaian_kiriman_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PengirimanXpdcDetail_GRIDLIST"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            string cStskirim = string.Empty;
            string x = string.Empty;
            
            if (dt.Rows[0]["StsKirim"].ToString() == "1")
            {
                cStskirim = "TERKIRIM";
            }
            else
            {
                if (dt.Rows[0]["StsKirim"].ToString() == "0")
                {
                    cStskirim = "TIDAK";
                }
                else
                {
                    cStskirim = "";
                }
            }

            NamaToko.Text = Tools.isNull(dt.Rows[0]["NamaToko"], "").ToString();
            Alamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
            Kota.Text = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
            TransactionType.Text = Tools.isNull(dt.Rows[0]["TransactionType"], "").ToString();
            TglTerima.Text = string.Format("{0:dd/MM/yyyy}",dt.Rows[0]["TglTrmToko"]);
            StsKirim.Text = cStskirim;
            JnsBayar.Text = dt.Rows[0]["KodeBayar"].ToString();
            RpBayar.Text = string.Format("{0:N}",dt.Rows[0]["NominalBayar"]);       //2 digit dibelakang koma
            //RpBayar.Text = string.Format("{0:N0}", dt.Rows[0]["NominalBayar"]);   //tidak ada digit dibelakang koma
            x = dt.Rows[0]["NominalBayar"].ToString();
            if (x == null || x == "")
            {
                RpBayar.Text = string.Format("{0:N}", nRpBayar);
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                try
                {
                    string cSts = string.Empty;
                    cSts = StsKirim.Text;
                    if (cSts.Trim() == "TERKIRIM")
                    {
                        Sts = 1;
                    }
                    else
                    {
                        Sts = 0;
                    }

                    db.Commands.Add(db.CreateCommand("usp_PengirimanXpdcDetail_PenyelesaianKirim_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@TglTerima", SqlDbType.DateTime, TglTerima.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Stskirim", SqlDbType.Int, Sts));
                    db.Commands[0].Parameters.Add(new Parameter("@JnsBayar", SqlDbType.VarChar, JnsBayar.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@RpBayar", SqlDbType.Money, RpBayar.Text));
                    db.Commands[0].ExecuteNonQuery();
                    MessageBox.Show(Messages.Confirm.UpdateSuccess);

                    if (this.Caller is frm_kirim)
                    {
                        frm_kirim frmCaller = (frm_kirim)this.Caller;
                        frmCaller.RefreshDataDetail();
                    }
                    this.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    db.RollbackTransaction();
                    MessageBox.Show("Gagal Menyimpan Data");
                }
            }

        }

    }
}
