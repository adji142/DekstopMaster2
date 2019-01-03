using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace ISA.Controls
{
    public class DateTextBox : TextBox 
    {
        string _format = "dd/MM/yyyy";
        ErrorProvider errDate = new ErrorProvider();

        public DateTextBox()
        {
            this.MaxLength = 10;
            this.Width = 80;
        }

        protected override void OnLeave(EventArgs e)
        {
            //Added by Iwan.
            base.OnLeave(e);

            if (this.Text.Length == 8)
            {
                string result;
                string data = this.Text;
                result = data[0].ToString() + data[1].ToString() + "/" + data[2].ToString() + data[3].ToString() + "/" + data[4].ToString() + data[5].ToString() + data[6].ToString() + data[7].ToString();
                this.Text = result;
            }
        }
  
        public DateTime? DateValue
        {
            get
            {
                if (this.Text == "")
                {
                    return null;
                }
                else
                {
                    DateTime dateOut;
                    IFormatProvider iFP = new CultureInfo("en-GB", true);                    
                    DateTimeStyles style = DateTimeStyles.None;
                    string givendate = this.Text;
                                       
                    if (DateTime.TryParse(givendate  , iFP, style  ,out dateOut))
                    {
                        return dateOut;
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            set
            {
                if (value != null)
                {
                    this.Text = ((DateTime)value).ToString(_format);
                }
                else
                {
                    this.Text = "";
                }
                errDate.Clear();
            }
        }

        protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
        {
            base.OnValidating(e);
            if (this.Text != "")
            {
                DateTime dateOut;
                IFormatProvider iFP = new CultureInfo("en-GB", true);
                DateTimeStyles style = DateTimeStyles.None;
                string givendate = this.Text;

                if (!DateTime.TryParse(givendate, iFP, style, out dateOut))
                {
                    errDate.SetError(this, String.Format("Silahkan masukkan tanggal yang valid dalam format ({0})", _format.ToUpper()));
                    e.Cancel = true;
                }
                else
                {
                    this.DateValue = dateOut;
                    errDate.Clear();
                }
            }
        }

        public void SetValue(object dateTime)
        {
            this.Text = "";
            if (dateTime != null)
            {
                if (dateTime.ToString() != "")
                {
                    DateTime dateTimeout;
                    if (DateTime.TryParse(dateTime.ToString(), out dateTimeout))
                    {
                        this.Text = dateTimeout.ToString(_format);
                    }
                }
            }
        }
        
    }
}
