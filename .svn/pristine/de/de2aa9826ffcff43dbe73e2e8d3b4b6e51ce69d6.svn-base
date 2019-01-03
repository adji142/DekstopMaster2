using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Finance.Class;

namespace ISA.Finance.Controls
{
    public partial class KodeTransComboBox : ComboBox
    {
        public KodeTransComboBox()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_KodeTransaksi_List]"));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                dt.Rows.Add("", "");
                dt.DefaultView.Sort = "KodeTransaksi ASC";
                this.DropDownStyle = ComboBoxStyle.DropDownList;
                this.DataSource = dt.DefaultView;
                this.DisplayMember = "KodeTransaksi";
                this.ValueMember = "KodeTransaksi";
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }


        public string KodeTransaksi
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
