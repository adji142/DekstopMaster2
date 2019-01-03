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
    public partial class frmSubJournalUpdate : ISA.Finance.BaseForm
    {
        Guid _RowID = new Guid();
        string _RecordID = "";
        Guid _JournalDetailID = new Guid();
        string _JournalDetailRecordID="";


        enum enumFormMode { New, Update };
        enumFormMode _formMode;

        public frmSubJournalUpdate(Guid journalDetailID, string journalDetailRecordID)
        {
            InitializeComponent();
            _JournalDetailID = journalDetailID;
            _JournalDetailRecordID = journalDetailRecordID;
            _formMode = enumFormMode.New;
        }

        public frmSubJournalUpdate(Guid rowID)
        {
            InitializeComponent();
            _RowID = rowID;           
            _formMode = enumFormMode.Update;
        }

        private void frmSubJournalUpdate_Load(object sender, EventArgs e)
        {
            if (_formMode == enumFormMode.Update)
            {
                DataTable dt;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    dt = Journal.GetSubJournalHeader(db, _RowID);
                }
                if (dt.Rows.Count > 0)
                {
                    _RecordID = dt.Rows[0]["RecordID"].ToString();
                    _JournalDetailID = new Guid(dt.Rows[0]["JournalDetailID"].ToString());
                    _JournalDetailRecordID = dt.Rows[0]["JournalDetailRecID"].ToString();
                    txtPersen.Text = dt.Rows[0]["Persen"].ToString();
                    txtAmount.Text = dt.Rows[0]["Amount"].ToString();
                    partnerComboBox1.SelectedIndex = partnerComboBox1.FindString(dt.Rows[0]["PartnerID"].ToString()+" - ");

                    txtUraian.Text = dt.Rows[0]["Keterangan"].ToString();
                }
                else
                {
                    MessageBox.Show(Messages.Error.NotFound);
                    this.Close();
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
           using (Database db = new Database(GlobalVar.DBName))
           {
               if (_formMode == enumFormMode.New)
               {
                   _RowID = Guid.NewGuid();
                   string recordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                   string partnerID = ((DataRowView) partnerComboBox1.SelectedItem)["PartnerID"].ToString();
                   string uraian = txtUraian.Text;

                   Journal.AddSubJournalHeader(db, _RowID, recordID, _JournalDetailID, _JournalDetailRecordID, partnerID, uraian);
               }
               else
               {
                   Guid rowID = _RowID;
                   string recordID = _RecordID;
                   string partnerID = ((DataRowView)partnerComboBox1.SelectedItem)["PartnerID"].ToString();
                   string uraian = txtUraian.Text;

                   Journal.UpdateSubJournalHeader(db, rowID, recordID, _JournalDetailID, _JournalDetailRecordID, partnerID, uraian);

               }
           }
           this.DialogResult = DialogResult.OK;
           MessageBox.Show(Messages.Confirm.UpdateSuccess);
           this.Close();
        }

        private void frmSubJournalUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmSubJournalBrowse)
                {
                    frmSubJournalBrowse frmParent = (frmSubJournalBrowse)this.Caller;
                    frmParent.RefreshRowSubJournal(_RowID.ToString());
                }
            }
        }




    }
}
