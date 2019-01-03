using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Fixrute
{
    public partial class frmMasterFixSalesUpdate : ISA.Trading.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _Rowid;
        DataTable dt, dtLoadUpdate;
        public frmMasterFixSalesUpdate()
        {
            InitializeComponent();
        }

        public frmMasterFixSalesUpdate(Form caller)
        {
            this.Caller = caller;
            formMode = enumFormMode.New;
            InitializeComponent();
        }


        public frmMasterFixSalesUpdate(Form caller, Guid Rowid)
        {
            this.Caller = caller;
            _Rowid = Rowid;
            formMode = enumFormMode.Update;
            InitializeComponent();
        }


        private void frmMasterFixSalesUpdate_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case enumFormMode.New:
                    try
                    {
                        
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }

                    break;

                case enumFormMode.Update:
                    try
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_fixSalesList_update"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, _Rowid));
                            dtLoadUpdate = db.Commands[0].ExecuteDataTable();
                            
                        }
                        lookupSales1.NamaSales = dtLoadUpdate.Rows[0]["nm_sales"].ToString();
                        lookupSales1.SalesID = dtLoadUpdate.Rows[0]["kd_sales"].ToString();
                        lookupSales1.Enabled = false;
                        if (dtLoadUpdate.Rows[0]["idrec"].ToString() == "L")
                        {
                            checkBox1.Checked = true;
                        }
                        else
                        {
                            checkBox1.Checked = false;
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


                    break;
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbSave_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case enumFormMode.New:
                    try
                    {
                        
                        DataTable dt = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_fixsales_Insert"));
                            db.Commands[0].Parameters.Add(new Parameter("@kodesales", SqlDbType.VarChar, lookupSales1.SalesID.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@namasales", SqlDbType.VarChar, lookupSales1.NamaSales.ToString()));
                            if (checkBox1.Checked == true)
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, "L"));
                            }
                            else
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, " "));
                            }
                            db.Commands[0].Parameters.Add(new Parameter("@user", SqlDbType.VarChar, SecurityManager.UserID));
                            //dt = db.Commands[0].ExecuteDataTable();
                            Object hasil = db.Commands[0].ExecuteScalar();

                            if (hasil != null)
                            {
                                MessageBox.Show("Data gagal disimpan karena sales sudah pernah ditambahkan.");
                            }
                            else 
                            {
                                MessageBox.Show("Data Berhasil Di simpan");
                                frmMasterFixSales frmCaller = (frmMasterFixSales)this.Caller;
                                frmCaller.RefreshData();
                                this.Close();
                            }
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
                    break;

                case enumFormMode.Update:
                    try
                    {
                        DataTable dt = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_fixSales_Edit"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, _Rowid));
                            db.Commands[0].Parameters.Add(new Parameter("@NamaSales", SqlDbType.VarChar, lookupSales1.NamaSales.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, lookupSales1.SalesID.ToString()));
                            if (checkBox1.Checked == true)
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, "L"));
                            }
                            else
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, " "));
                            }
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                            MessageBox.Show("Data Berhasil Di simpan");
                            frmMasterFixSales frmCaller = (frmMasterFixSales)this.Caller;
                            frmCaller.RefreshData();
                            this.Close();
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                        MessageBox.Show("Gagal Menyimpan Data");
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                    break;
            }
        }

        private void frmMasterFixSalesUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {


            if (this.Caller is frmMasterFixSales)
            {
                frmMasterFixSales ifrm = (frmMasterFixSales)this.Caller;
                ifrm.RefreshData();
                ifrm.FindRowHeader(_Rowid);

            }
        }
    }
}
