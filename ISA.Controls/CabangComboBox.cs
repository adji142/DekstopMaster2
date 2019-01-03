using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using ISA.DAL;
using System.Data;
using ISA.Controls;

namespace ISA.Controls
{
    public class CabangComboBox : ComboBox
    {
        public string CabangID
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

        public CabangComboBox()
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
                DataTable dtCabang = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
                    dtCabang = db.Commands[0].ExecuteDataTable();
                }
                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "CabangID + ' | ' + Nama");
                dtCabang.Columns.Add(cConcatenated);
                dtCabang.Rows.Add("");
                dtCabang.DefaultView.Sort = "CabangID ASC";

                this.DataSource = dtCabang;
                this.DisplayMember = "Concatenated";
                this.ValueMember = "CabangID";
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}