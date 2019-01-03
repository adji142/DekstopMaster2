using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using ISA.DAL;
using System.Data;

namespace ISA.Toko.Controls
{
    class CommonTextBox:TextBox
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
             this.CharacterCasing = CharacterCasing.Upper;        
        }



        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "'")
            {
                e.Handled = true;
            }
            
        }
        
    }
}
