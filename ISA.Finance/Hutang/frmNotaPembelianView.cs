using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Finance;

namespace ISA.Finance.Hutang
{
    public partial class frmNotaPembelianView : ISA.Controls.BaseForm
    {
        string NoNota_ = string.Empty;
        Guid PemasokID_ ;

        public frmNotaPembelianView(string _NoNota, Guid _PemasokID)
        {
            InitializeComponent();
            NoNota_ = _NoNota;
            PemasokID_ = _PemasokID;
        }

        private void frmNotaPembelianView_Load(object sender, EventArgs e)
        {
            GetDataPembelian();
        }

        private void GetDataPembelian()
        {
           try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtBeli = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPembelian_Hutang_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@NoNota", SqlDbType.VarChar, NoNota_));
                    db.Commands[0].Parameters.Add(new Parameter("@PemasokID", SqlDbType.VarChar, PemasokID));
                    dtBeli = db.Commands[0].ExecuteDataTable();
                }
                customGridView1.DataSource = dtBeli; 
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
