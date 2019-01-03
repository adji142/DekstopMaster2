using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Finance.Piutang
{
    public partial class NotaCicilView : ISA.Finance.BaseForm
    {
        Guid _kpRowID;

        public NotaCicilView()
        {
            InitializeComponent();
        }

        public NotaCicilView(Form caller, Guid kpRowID)
        {
            InitializeComponent();
            _kpRowID = kpRowID;
            this.Caller = caller;
        }

        private void NotaCicilView_Load(object sender, EventArgs e)
        {
            cgvNotaCicil.AutoGenerateColumns = false;
            RefreshNotaCicil();
        }

        public void RefreshNotaCicil()
        {
            DataTable dt = new DataTable();
            Database db = new Database(GlobalVar.DBName);
            db.Commands.Add(db.CreateCommand("usp_NotaCicil_LIST"));
            db.Commands[0].Parameters.Add(new Parameter("@NotaID", SqlDbType.UniqueIdentifier, _kpRowID));
            dt = db.Commands[0].ExecuteDataTable();
            dt.DefaultView.Sort = "nCicil ASC";
            cgvNotaCicil.DataSource = dt.DefaultView;

            txtNamaToko.Text = cgvNotaCicil.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString();
            txtWilID.Text = cgvNotaCicil.SelectedCells[0].OwningRow.Cells["IdWil"].Value.ToString();
            txtAlamat.Text = cgvNotaCicil.SelectedCells[0].OwningRow.Cells["Alamat"].Value.ToString();
            txtNoNota.Text = cgvNotaCicil.SelectedCells[0].OwningRow.Cells["NoNota"].Value.ToString();
            txtDateTrans.Text = cgvNotaCicil.SelectedCells[0].OwningRow.Cells["TglNota"].Value.ToString();
            txtRpNota.Text = cgvNotaCicil.SelectedCells[0].OwningRow.Cells["RpNota"].Value.ToString();
            txtRpTagihan.Text = cgvNotaCicil.SelectedCells[0].OwningRow.Cells["RpTagihJT"].Value.ToString();
            TxtRpBayar.Text = cgvNotaCicil.SelectedCells[0].OwningRow.Cells["RpBayar"].Value.ToString();
            TxtRpSisa.Text = cgvNotaCicil.SelectedCells[0].OwningRow.Cells["RpSaldo"].Value.ToString();
        }



    }

}
