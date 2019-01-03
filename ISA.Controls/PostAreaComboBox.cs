using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Controls;

namespace ISA.Controls
{
    public class PostAreaComboBox : ComboBox
    {
        public PostAreaComboBox()
        {
            this.Width = 200;

            if (this.DesignMode)
                return;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtPostArea = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PostArea_LIST"));
                    dtPostArea = db.Commands[0].ExecuteDataTable();
                }
                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "PostID + ' | ' + PostName");
                dtPostArea.Columns.Add(cConcatenated);
                dtPostArea.Rows.Add("");
                dtPostArea.DefaultView.Sort = "PostID ASC";
                this.DataSource = dtPostArea;
                this.DisplayMember = "Concatenated";
                this.ValueMember = "PostID";
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public string PostID
        {
            get
            {
                string id = "";
                if (this.SelectedIndex >= 0)
                    id = this.SelectedValue.ToString();
                return id;
            }

            set
            {
                this.SelectedValue = value;
            }
        }
    }
}
