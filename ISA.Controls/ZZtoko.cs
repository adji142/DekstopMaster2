using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISA.Controls
{
    public partial class ZZtoko : UserControl
    {
        public ZZtoko()
        {
            InitializeComponent();
        }
        ToolTip tipText = new ToolTip();
        private void ZZtoko_Load(object sender, EventArgs e)
        {

           
        }

        public enum enCommandType
        {
            ddmmyyy,
            mmyyy
        }

        enCommandType _commandType;


        public enCommandType tipeTanggal
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

        private void SetControl()
        {
            this.Font = new Font(this.Font.FontFamily, 9, FontStyle.Bold);

            tipText.IsBalloon = true;

            switch (_commandType)
            {
                case enCommandType.ddmmyyy:
                    dtpISA.Width = 100;
                    dtpISA.Format = DateTimePickerFormat.Custom;
                    dtpISA.CustomFormat = " dd,MM,yyyy";
                    dtpISA.ShowUpDown = true;

                    break;
                case enCommandType.mmyyy:
                    dtpISA.Width = 80;
                    dtpISA.Format = DateTimePickerFormat.Custom;
                    dtpISA.CustomFormat = "MM,yyyy";
                    dtpISA.ShowUpDown = true;

                    break;
               
            }
        }
    }
}
