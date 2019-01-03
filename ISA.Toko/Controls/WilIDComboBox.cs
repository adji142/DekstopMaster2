using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;
namespace ISA.Toko.Controls
{
    class WilIDComboBox:ComboBox
    {
        public WilIDComboBox()
        {
            this.Width = 100;

            if (this.DesignMode)
                return;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtPostArea = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_WilayahID_LIST"));
                    dtPostArea = db.Commands[0].ExecuteDataTable();
                }
                dtPostArea.Rows.Add("");
                dtPostArea.DefaultView.Sort = "WilID ASC";
                this.DataSource = dtPostArea;
                this.DisplayMember = "WilID";
                this.ValueMember = "WilID";
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

        public string WilID
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
