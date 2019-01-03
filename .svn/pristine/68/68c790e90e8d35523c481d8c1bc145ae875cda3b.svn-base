using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace ISA.Controls
{
    public class NumericTextBox : TextBox
    {
        ErrorProvider err = new ErrorProvider();

        string _format;

        [Browsable(true), DefaultValue ("#,##0")]
        public string Format
        {
            get
            {
                if (_format == "" || _format == null)
                {
                    _format = "#,##0";
                }
                return _format;
            }
            set
            {
                _format = value;
            }
        }

        private string removeFormat()
        {
            return base.Text.Replace(",", "");
        }

        public int GetIntValue
        {
            get
            {
                int result = 0;
                int.TryParse(removeFormat(), out result);

                return result;
            }
        }

        public double GetDoubleValue
        {
            get
            {
                double result = 0;
                double.TryParse(removeFormat(), out result);

                return result;
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = ConvertNumeric( value).ToString(this.Format);
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',' && e.KeyChar != '-')
            {
                e.Handled = true;
            }                        
        }

        protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
        {
            base.OnValidating(e);
            if (!e.Cancel)
            {
            
            if (this.Text != "")
            {
                double parseResult;
                if (double.TryParse(this.Text, out parseResult))
                {
                    this.Text = parseResult.ToString(this.Format);
                    err.Clear();
                }
                else
                {
                    err.SetError(this, "Harus diisi angka");
                    e.Cancel = true;
                }
                string val = ConvertNumeric(this.Text).ToString(this.Format);
                base.Text = val;
                e.Cancel = false;

            }
            else
            {
                err.Clear();
            }
            }
        }


        private double ConvertNumeric(string value)
        {
            double parseResult;
            if (double.TryParse(value, out parseResult))
            {
                return parseResult;
            }
            else
            {
                return 0;
            }
        }
    }
}
