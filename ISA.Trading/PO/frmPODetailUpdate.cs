using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.PO
{
    public partial class frmPODetailUpdate : ISA.Trading.BaseForm
    {
        public enum enumFormMode { Insert };
        enumFormMode _formMode;
        DataTable dtPODetail, dtPO;
        string strNoPO;
        Guid _rowID, _headerID;
        public frmPODetailUpdate(Form caller, Guid rowID, enumFormMode formMode)
        {
             InitializeComponent();
            _formMode = formMode;
            if (_formMode == enumFormMode.Insert)
            {
                _rowID = rowID;
            }
            else
            {
                _headerID = rowID;
            }
            this.Caller = caller;
        }
        

        private void frmPODetailUpdate_Load(object sender, EventArgs e)
        {
            this.Title = "Update PO Detail";
            this.Text = "PO";
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    if (_formMode == enumFormMode.Insert)
                    {
                        dtPODetail = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_POD_List"));
                        db.Commands[0].Parameters.Add(new Parameter("@row", SqlDbType.UniqueIdentifier, _rowID));
                        dtPODetail = db.Commands[0].ExecuteDataTable();
                    }
                    else
                    {
                        dtPO = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_POH_List"));
                        db.Commands[0].Parameters.Add(new Parameter("@row", SqlDbType.UniqueIdentifier, _headerID));

                        dtPO = db.Commands[0].ExecuteDataTable();
                    }
            }

                if (_formMode == enumFormMode.Insert)
                {
                    lookupStock.BarangID = dtPODetail.Rows[0]["id_brg"].ToString();
                    lookupStock.NamaStock = dtPODetail.Rows[0]["nama_stok"].ToString();
                    tbNOPO.Text = dtPODetail.Rows[0]["id_brg"].ToString();
                    tbRefil.Text = dtPODetail.Rows[0]["qrefill"].ToString();
                    tbBO.Text = dtPODetail.Rows[0]["qbo"].ToString();
                    tbStock.Text = dtPODetail.Rows[0]["qstok"].ToString();
                    tbBuffer.Text = dtPODetail.Rows[0]["qbuffer"].ToString();
                    textBox6.Text = dtPODetail.Rows[0]["tgl_opnm"].ToString();
                    tbQSamp.Text = dtPODetail.Rows[0]["qopnm"].ToString();
                    tbFisik.Text = dtPODetail.Rows[0]["qfisik"].ToString();
                    tbSpike.Text = dtPODetail.Rows[0]["qspike"].ToString();
                    tbPO.Text = dtPODetail.Rows[0]["qpo"].ToString();
                    txtAlasan.Text = dtPODetail.Rows[0]["keterangan"].ToString().Replace(Environment.NewLine, string.Empty).TrimEnd();
                    tbPO.ReadOnly = true;
                    btProses.Enabled = false;
                    lookupStock.Enabled = false;
               }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbSave_Click(object sender, EventArgs e)
        {
            UpdatePODetail(strNoPO);
            frmPO frmCaller = (frmPO)this.Caller;
            frmCaller.RefreshHeader();
            this.Close();
        }

        private void UpdatePODetail(string NoPO)
        {
            //MessageBox.Show("masuk ke insert");
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                try
                {

                    db.Commands.Add(db.CreateCommand("usp_PODetail_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@fisik", SqlDbType.NChar, tbFisik.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@spike", SqlDbType.NChar, tbSpike.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@po", SqlDbType.NChar, tbPO.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@ket", SqlDbType.VarChar, txtAlasan.Text.Replace(Environment.NewLine, string.Empty).TrimEnd()));
                    db.Commands[0].ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Di simpan");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    db.RollbackTransaction();
                    MessageBox.Show("Gagal Menyimpan Data");
                }
            }
        }

        private void tbFisik_TextChanged(object sender, EventArgs e)
        {
            int _Po = Convert.ToInt32(tbBO.Text);
            int _fisik = Convert.ToInt32(Tools.isNull((tbFisik.Text), "0"));
            int _BO = Convert.ToInt32(tbBO.Text);
            int _spike = Convert.ToInt32(Tools.isNull((tbSpike.Text), "0"));
            int _buffer = Convert.ToInt32(tbBuffer.Text);

            if (_buffer != 0)
            {
                _Po = _buffer - _fisik + _spike;
            }
            else
            {
                _Po = _BO - _fisik + _spike;
            }
            string po = _Po.ToString();
            tbPO.Text = po;
        }

        private void tbSpike_TextChanged(object sender, EventArgs e)
        {
            int _Po = Convert.ToInt32(tbPO.Text);
            int _fisik = Convert.ToInt32(Tools.isNull((tbFisik.Text), "0"));
            int _BO = Convert.ToInt32(tbBO.Text);
            int _spike = Convert.ToInt32(Tools.isNull((tbSpike.Text), "0"));
            int _buffer = Convert.ToInt32(tbBuffer.Text);

            if (_buffer != 0)
            {
                _Po = _buffer - _fisik + _spike;
            }
            else
            {
                _Po = _BO - _fisik + _spike;
            }
            string po = _Po.ToString();
            tbPO.Text = po;
        }
    }
}
