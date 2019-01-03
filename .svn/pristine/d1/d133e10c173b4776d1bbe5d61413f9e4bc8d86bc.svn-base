using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance
{
    

    public partial class frmGiroCairTolakBatal_PilihGiro : ISA.Finance.BaseForm
    {
        Guid _rowIDHeader;
        enum enumFormMode { New, Update };
        enumFormMode formMode;

        public frmGiroCairTolakBatal_PilihGiro (Form caller,Guid rowIDHeader)
        {
            InitializeComponent();
            _rowIDHeader = rowIDHeader;
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmGiroCairTolakBatal_PilihGiro()
        {
            InitializeComponent();
        }

        private void frmGiroCairTolakBatal_PilihGiro_Load(object sender, EventArgs e)
        {

        }

        public void RefreshVoucherGiroTitip()
        {
            //try
            //{
            //    this.Cursor = Cursors.WaitCursor;
            //    using (Database db = new Database(GlobalVar.DBName))
            //    {
            //        DataTable dtHeader = new DataTable();
            //        db.Commands.Add(db.CreateCommand("usp_BBM_GiroTolakCair_LIST"));
            //        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
            //        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
            //        dtHeader = db.Commands[0].ExecuteDataTable();
            //        gridBBM.DataSource = dtHeader;

            //        if (gridBBM.SelectedCells.Count > 0)
            //        {

            //            RefreshGiro();
            //        }
            //        else
            //        {
            //            gridBBM.DataSource = null;
            //        }
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    Error.LogError(ex);
            //}

            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}
        }
    }
}
