using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using ISA.DAL;
using System.Data;

namespace ISA.Toko.Controls
{
    class ComboBoxStaffAdsdanOps : ComboBox
    {
        public string RowID
        {
            get
            {
                string id = "";
                if (this.SelectedValue != null)
                    id = this.SelectedValue.ToString();
                return id;
            }
            set
            {
                this.SelectedValue = value;
            }
        }

        public ComboBoxStaffAdsdanOps()
        {
            this.Height = 22;
            this.Width = 180;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SetControl();
        }      

        private void SetControl()
        {
            this.Height = 22;
            this.Width = 180;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Font = new Font(this.Font.FontFamily, 8, FontStyle.Regular);

            if (this.DesignMode)
                return;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_StaffPenjualan_LIST]"));
                    db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, true));
                    dt = db.Commands[0].ExecuteDataTable();
                }
               // DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "RowID + ' | ' + Nama");
                //dt.Columns.Add(cConcatenated);
                //dt.Rows.Add("");
                //dt.DefaultView.Sort = "Nama ASC";

                this.DataSource = dt;
                this.DisplayMember = "Nama";
                this.ValueMember = "RowID";
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