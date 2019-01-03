using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlTypes;
using ISA.Finance.DataTemplates;
using Microsoft.Reporting.WinForms;
using ISA.Finance.Class;
using ISA.Finance;


namespace ISA.Finance.Hutang
{
    public partial class frmLinkInvoiceKeHutangManualLokal : ISA.Controls.BaseForm
    {

        DataRow drH;
        enum enumFormMode { New, Update };

        enumFormMode FormMode;


        private void Save()
        {
            Guid gg;
            gg = Guid.NewGuid();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[usp_HutangPembelianLokal_INSERT_N]"));

                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, gg));
                db.Commands[0].Parameters.Add(new Parameter("@BLHeaderRowID", SqlDbType.UniqueIdentifier, SqlGuid.Null));
                db.Commands[0].Parameters.Add(new Parameter("@InvoiceHeaderRowID", SqlDbType.UniqueIdentifier, drH["RowID"] ));
                db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, drH["VendorRowID"]));
                db.Commands[0].Parameters.Add(new Parameter("@PLRowID", SqlDbType.UniqueIdentifier, SqlGuid.Null));
                db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.UniqueIdentifier, drH["MataUangRowID"]));
                db.Commands[0].Parameters.Add(new Parameter("@TglInvoice", SqlDbType.DateTime, Convert.ToDateTime(drH["TglInvoice"])));
                db.Commands[0].Parameters.Add(new Parameter("@InvoiceNo", SqlDbType.VarChar, drH["InvoiceNo"].ToString()));

                db.Commands[0].Parameters.Add(new Parameter("@Import", SqlDbType.Bit, 0));
                db.Commands[0].Parameters.Add(new Parameter("@StatusLunas", SqlDbType.Bit, 0));
                db.Commands[0].Parameters.Add(new Parameter("@IsMultyCurrency", SqlDbType.Bit, 0));
                db.Commands[0].Parameters.Add(new Parameter("@IsMultyVendor", SqlDbType.Bit, 0));

                db.Commands[0].Parameters.Add(new Parameter("@OriginalMataUang", SqlDbType.VarChar, drH["MataUangID"].ToString()));
                db.Commands[0].Parameters.Add(new Parameter("@OriginalAmount", SqlDbType.Money, tbSaldoHutang.Text));
                db.Commands[0].Parameters.Add(new Parameter("@USDAmount", SqlDbType.Money, 0));
                db.Commands[0].Parameters.Add(new Parameter("@IDRAmount", SqlDbType.Money, tbSaldoHutang.Text ));
                db.Commands[0].Parameters.Add(new Parameter("@Potongan", SqlDbType.Money, drH["Potongan"]));
                db.Commands[0].Parameters.Add(new Parameter("@Komisi", SqlDbType.Money, 0));
                db.Commands[0].Parameters.Add(new Parameter("@NilaiTambahan", SqlDbType.Money, 0));
                db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                db.Commands[0].ExecuteNonQuery();

            }
            RefreshGrid(gg);
        }

        private void Update()
        {
                        using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_HutangPembelianLokal_UPDATE"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, drH["RowID"]));
                db.Commands[0].Parameters.Add(new Parameter("@IDRAmount", SqlDbType.Money, tbSaldoHutang.GetDoubleValue));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdateBy", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].ExecuteNonQuery();
            }

            RefreshGrid((Guid)drH["RowID"]);
           
        }

        private void RefreshGrid(Guid _RowID)
        {
            if (this.Caller is frmDaftarHutangLokal)
            {
                frmDaftarHutangLokal frmCaller = (frmDaftarHutangLokal)this.Caller;
                frmCaller.RefreshRowDataGridHeader(_RowID);
            }
        }

        private bool NotValid()
        {
            bool val = false;
            ErrorProvider err = new ErrorProvider();

            if (tbSaldoHutang.GetDoubleValue <= 0)
            {
                err.SetError(tbSaldoHutang, "Harus di ISI !!!");
                val = true;
            }
            return val;
        }

        public frmLinkInvoiceKeHutangManualLokal()
        {
            InitializeComponent();
        }

        public frmLinkInvoiceKeHutangManualLokal(Form caller , DataRow drH_ , string flag)
        {
            InitializeComponent();
            drH = drH_;
            if (flag.Equals("1"))
            {
                FormMode = enumFormMode.New;
            }
            else if (flag.Equals("2"))
            {
                FormMode = enumFormMode.Update;
            }

            this.Caller = caller;
        }

        private void frmLinkInvoiceKeHutangManualLokal_Load(object sender, EventArgs e)
        {
            switch(FormMode){
                case enumFormMode.New:
                    tbNoInvoice.Text = drH["InvoiceNo"].ToString();
                    tbTglInvoice.DateValue = Convert.ToDateTime(drH["TglInvoice"]);
                    tbSaldoHutang.Text =  drH["IDRAmount"].ToString();
                    break;
                case enumFormMode.Update :
                    tbNoInvoice.Text = drH["InvoiceNo"].ToString();
                    tbTglInvoice.DateValue = Convert.ToDateTime(drH["TglInvoice"]);
                    tbSaldoHutang.Text = drH["IDRAmount"].ToString();
                    break;
                    break;
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                if (NotValid())
                {
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                switch (FormMode)
                {
                    case enumFormMode.New:
                        Save();
                        break;

                    case enumFormMode.Update:
                        Update();
                        break;
                }
                this.Close();
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
}
