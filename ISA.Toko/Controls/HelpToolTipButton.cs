using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace ISA.Toko.Controls
{
    class HelpToolTipButton:Button
    {

        public HelpToolTipButton()
        {            
            this.Width = 23;
            this.Height = 23;
            this.BackgroundImage = global::ISA.Toko.Properties.Resources.help;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.Text = " ";
        }
    }
}
