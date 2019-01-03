using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Finance;
using ISA.Finance.Class;
using ISA.Common;
using ISA.DAL;

namespace ISA.Finance.GL
{
    public partial class frmSubJournalDetailUpdate : ISA.Finance.BaseForm
    {
        Guid _RowID = new Guid();
        string _RecordID = "";
        string _PartnerID = "";
        Guid _SubJournalID = new Guid();
        string _SubJournalRecordID = "";
        decimal _totalPercent=0;
        double _totalAmount = 0;
        double _totalDJournal = 0;
        double _orignalAmount = 0;


        enum enumFormMode { New, Update };
        enumFormMode _formMode;

        public frmSubJournalDetailUpdate(Guid subJournalID, string subJournalRecordID, string partnerID)
        {
            InitializeComponent();
            _SubJournalID = subJournalID;
            _SubJournalRecordID = subJournalRecordID;
            _PartnerID = partnerID;
        }

        public frmSubJournalDetailUpdate(Guid rowID)
        {
            InitializeComponent();
            _RowID = rowID;           
            _formMode = enumFormMode.Update;
        }

        private void frmSubJournalDetailUpdate_Load(object sender, EventArgs e)
        {

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (InputIsValid())
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    if (_formMode == enumFormMode.New)
                    {
                        _RowID = Guid.NewGuid();
                        string recordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                        string partnerID = ((DataRowView)partnerComboBox1.SelectedItem)["PartnerID"].ToString();
                        string partnerNo = ((DataRowView)partnerDetailComboBox1.SelectedItem)["PartnerNo"].ToString();
                        string namaPartner = ((DataRowView)partnerDetailComboBox1.SelectedItem)["Nama"].ToString();
                        decimal persen = Convert.ToDecimal(txtPersen.GetDoubleValue);
                        string currency = txtCurrency.Text;
                        double amount = txtAmount.GetDoubleValue;
                        Journal.AddSubJournalDetail(db, _RowID, _SubJournalID, recordID, _SubJournalRecordID, _PartnerID, partnerNo, namaPartner, persen, currency, amount);
                    }
                    else
                    {
                        Guid rowID = _RowID;
                        string recordID = _RecordID;
                        string partnerID = ((DataRowView)partnerComboBox1.SelectedItem)["PartnerID"].ToString();
                        string partnerNo = ((DataRowView)partnerDetailComboBox1.SelectedItem)["PartnerNo"].ToString();
                        string namaPartner = ((DataRowView)partnerDetailComboBox1.SelectedItem)["Nama"].ToString();
                        decimal persen = Convert.ToDecimal(txtPersen.GetDoubleValue);
                        string currency = txtCurrency.Text;
                        double amount = txtAmount.GetDoubleValue;
                        Journal.UpdateSubJournalDetail(db, _RowID, _SubJournalID, recordID, _SubJournalRecordID, partnerID, partnerNo, namaPartner, persen, currency, amount);

                    }
                }
                this.DialogResult = DialogResult.OK;
                MessageBox.Show(Messages.Confirm.UpdateSuccess);
                this.Close();
            }
        }


        private bool InputIsValid()
        {
            bool valid = true;
            double maxAmount = _totalDJournal - _totalAmount  + _orignalAmount;
            if (txtAmount.GetDoubleValue > maxAmount)
            {
                valid = false;
                MessageBox.Show("Tidak bisa input Amount lebih besar dari " + maxAmount.ToString("#,##0"));
            }
            return valid;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSubJournalDetailUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmSubJournalBrowse)
                {
                    frmSubJournalBrowse frmParent = (frmSubJournalBrowse)this.Caller;
                    frmParent.RefreshRowSubJournal(_SubJournalID.ToString());
                    frmParent.RefreshRowSubJournalDetail(_RowID.ToString());
                }
            }
        }

        private void frmSubJournalDetailUpdate_Shown(object sender, EventArgs e)
        {


            //Populate Controls
            if (_formMode == enumFormMode.Update)
            {
                DataTable dt;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    dt = Journal.GetSubJournalDetail(db, _RowID);
                }
                if (dt.Rows.Count > 0)
                {
                    _RecordID = dt.Rows[0]["RecordID"].ToString();
                    _SubJournalID = new Guid(dt.Rows[0]["HeaderID"].ToString());
                    _SubJournalRecordID = dt.Rows[0]["HRecordID"].ToString();
                    partnerComboBox1.SelectedIndex = partnerComboBox1.FindString(dt.Rows[0]["PartnerID"].ToString() + " - ");
                    partnerDetailComboBox1.SelectedIndex = partnerDetailComboBox1.FindString(dt.Rows[0]["PartnerNo"].ToString() + " - ");
                    txtPersen.Text = Convert.ToDouble(dt.Rows[0]["Persen"].ToString()).ToString("##0.00");
                    txtCurrency.Text = dt.Rows[0]["Currency"].ToString();
                    _orignalAmount = Convert.ToDouble(dt.Rows[0]["Amount"].ToString());
                    txtAmount.Text = _orignalAmount.ToString("#,##0");
                }
                else
                {
                    MessageBox.Show(Messages.Error.NotFound);
                    this.Close();
                }
            }
            else
            {
                partnerComboBox1.SelectedIndex = partnerComboBox1.FindString(_PartnerID + " - ");
            }

            //Populate Constraint
            using (Database db = new Database(GlobalVar.DBName))
            {
                DataTable dt = Journal.GetSubJournalHeader(db, _SubJournalID);
                if (dt.Rows.Count > 0)
                {
                    _totalPercent = Convert.ToDecimal(dt.Rows[0]["Persen"]);
                    _totalAmount = Convert.ToDouble(dt.Rows[0]["Amount"]);
                    DataTable dtDJournal = Journal.GetDetail(db, new Guid(dt.Rows[0]["JournalDetailID"].ToString()));
                    if (dtDJournal.Rows.Count > 0)
                    {
                        _totalDJournal = Convert.ToDouble(dtDJournal.Rows[0]["Debet"]) + Convert.ToDouble(dtDJournal.Rows[0]["Kredit"]);
                    }
                }
            }
        }

        private void partnerComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (partnerComboBox1.SelectedIndex >= 0)
            {
                string partnerID = ((DataRowView)partnerComboBox1.SelectedItem)["PartnerID"].ToString();
                partnerDetailComboBox1.PartnerID = partnerID;
            }
        }


        private void txtPersen_KeyUp(object sender, KeyEventArgs e)
        {
            double persen = txtPersen.GetDoubleValue;
            txtAmount.Text = (_totalDJournal * (persen / 100.00)).ToString("#,##0");
        }

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            double amount = txtAmount.GetDoubleValue;
            txtPersen.Text = ((txtAmount.GetDoubleValue / _totalDJournal) * 100.00).ToString("#,##0.00");
        }
    }
}
