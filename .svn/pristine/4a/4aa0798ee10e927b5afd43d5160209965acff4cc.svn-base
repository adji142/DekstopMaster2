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
    public partial class PartnerDetailComboBox : ComboBox
    {
        string _PartnerID="";
        [Browsable(true)]public string PartnerID
        {
            get
            {
                return _PartnerID;
            }
            set
            {
                _PartnerID = value;
                RefreshData();
            }
        }

        public string PartnerDetailID
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

        public PartnerDetailComboBox()
        {

            RefreshData();
        }

        private void RefreshData()
        {
            try
            {
                DataTable dt = new DataTable();
              using (Database db = new Database(GlobalVar.DBName))
                {                  
                    db.Commands.Add(db.CreateCommand("[usp_PartnerDetail_LIST]"));
                    if (_PartnerID != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@PartnerID", SqlDbType.VarChar, _PartnerID));
                    }
                    dt = db.Commands[0].ExecuteDataTable();
                }

                dt.DefaultView.Sort = "Display ASC";
                this.DropDownStyle = ComboBoxStyle.DropDownList;
                this.DataSource = dt.DefaultView;
                this.DisplayMember = "Display";
                this.ValueMember = "PartnerNo";
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        
        }




    }
}
