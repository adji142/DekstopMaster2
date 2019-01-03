using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Finance.Controls
{
    public partial class PartnerComboBox : ComboBox
    {
        public PartnerComboBox()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Partner_LIST]"));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                dt.Rows.Add("");
                dt.DefaultView.Sort = "Display ASC";
                this.DropDownStyle = ComboBoxStyle.DropDownList;
                this.DisplayMember = "Display";
                this.ValueMember = "PartnerID";
                this.DataSource = dt.DefaultView;

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }


        public string PartnerID
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
