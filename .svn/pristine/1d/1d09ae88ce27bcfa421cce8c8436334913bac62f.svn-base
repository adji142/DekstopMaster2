using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using ISA.DAL;

namespace ISA.Trading.Controls
{
    class CommandButton:Button
    {
        ToolTip tipText = new ToolTip();
        int defaultHeight = 40;
        int defaultWidth = 100;
        public enum enCommandType
        {
            None,
            Add,
            Edit,
            Delete,
            SearchS,
            SearchL,
            Save,
            Close,
            Yes,
            No,
            Download,
            Upload,
            Print
        }

        enCommandType _commandType;
        string _buttonType = "";

        public enCommandType CommandType
        {
            get
            {
                return _commandType;
            }
            set
            {                
                _commandType = value;
                SetControl();
            }
        }

        public CommandButton()
        {
            this.TextImageRelation = TextImageRelation.ImageBeforeText;               
            this.Width = 120;
            this.Height = 40;
            this.CommandType = enCommandType.None;

        }

        public string ReportName
        {
            get { return _buttonType; }
            set { _buttonType = value; }
        }

        protected override void OnCreateControl()
        {            
            base.OnCreateControl();
            SetControl();
        }

        private void SetControl()
        {
            this.Font = new Font(this.Font.FontFamily, 9, FontStyle.Bold);
            this.ImageAlign = ContentAlignment.MiddleLeft;
            this.Height = defaultHeight;
            this.Width = defaultWidth;
            tipText.IsBalloon = true;
                      
            switch (_commandType)
            {
                case enCommandType.None:
                    this.Font = new Font(this.Font.FontFamily, (float)8.25, FontStyle.Regular);
                    this.Image = null;
                    break;
                case enCommandType.Add:
                    this.Image = global::ISA.Trading.Properties.Resources.Add32;
                    this.Text = "ADD";                    
                    tipText.SetToolTip(this, "Ctrl+N");                    
                    break;
                case enCommandType.Edit:
                    this.Image = global::ISA.Trading.Properties.Resources.Edit32;
                    this.Text = "EDIT";
                    tipText.SetToolTip(this, "Ctrl+E");
                    break;
                case enCommandType.Delete:
                    this.Image = global::ISA.Trading.Properties.Resources.Delete32;
                    this.Text = "DELETE";                    
                    break;
                case enCommandType.SearchS:
                    this.Image = global::ISA.Trading.Properties.Resources.Search16;
                    this.Font = new Font(this.Font.FontFamily, (float)8.25, FontStyle.Bold);
                    this.ImageAlign = ContentAlignment.TopLeft;
                    this.Text = "Search";
                    this.Height = 23;
                    this.Width = 80;
                    break;
                case enCommandType.SearchL:
                    this.Image = global::ISA.Trading.Properties.Resources.Search24;
                    this.Text = "SEARCH";
                    break;
                case enCommandType.Save:
                    this.Image = global::ISA.Trading.Properties.Resources.Save32;
                    this.Text = "SAVE";
                    tipText.SetToolTip(this, "Ctrl+S");
                    break;
                case enCommandType.Close:
                    this.Image = global::ISA.Trading.Properties.Resources.Close32;
                    this.Text = "CLOSE";
                    break;
                case enCommandType.Yes:
                    this.Image = global::ISA.Trading.Properties.Resources.Ok32;
                    this.Text = "YES";
                    break;
                case enCommandType.No:
                    this.Image = global::ISA.Trading.Properties.Resources.Cancel32;
                    this.Text = "CANCEL";
                    break;
                case enCommandType.Download :
                    this.Image = global::ISA.Trading.Properties.Resources.Download32;
                    this.Text = "DOWNLOAD";
                    this.Width = 128;
                    break;
                case enCommandType.Upload:
                    this.Image = global::ISA.Trading.Properties.Resources.Upload32;
                    this.Text = "UPLOAD";
                    this.Width = 128;
                    break;
                case enCommandType.Print:
                    this.Image = global::ISA.Trading.Properties.Resources.Printer32;
                    this.Text = "PRINT";
                    tipText.SetToolTip(this, "Ctrl+P");
                    break;
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (_commandType == enCommandType.Print)
            {
                Form frmParent;
                if (this.Parent is System.Windows.Forms.Form)
                {
                    frmParent = (Form)this.Parent;
                }
                else
                {
                    frmParent = (Form)this.TopLevelControl;
                }
                string _ReportName = frmParent.Name + " : " + this.ReportName;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ReportHistory_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@ReportName", System.Data.SqlDbType.VarChar, _ReportName));
                    db.Commands[0].Parameters.Add(new Parameter("@UserID", System.Data.SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
        }

    }
}
