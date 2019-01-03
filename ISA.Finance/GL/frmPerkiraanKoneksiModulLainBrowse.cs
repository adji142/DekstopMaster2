using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance.GL
{
    public partial class frmPerkiraanKoneksiModulLainBrowse : ISA.Finance.BaseForm
    {
        public frmPerkiraanKoneksiModulLainBrowse()
        {
            InitializeComponent();
        }

        private void frmPerkiraanKoneksiModulLainBrowse_Load(object sender, EventArgs e)
        {
            //lookupGudang1.GudangID = "0901";
            lookupGudang1.GudangID = GlobalVar.Gudang;
        }


        private void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (lookupGudang1.GudangID != "")
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksiDetail_LIST_NonKasir"));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeCabang", SqlDbType.VarChar, lookupGudang1.GudangID));                        
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    dt.DefaultView.Sort = "Mdl, KodeTrn, NoPerkiraan";
                    customGridView1.DataSource = dt.DefaultView;
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

        private void frmPerkiraanKoneksiModulLainBrowse_Shown(object sender, EventArgs e)
        {            
            RefreshData();
        }

        private void lookupGudang1_SelectData(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
