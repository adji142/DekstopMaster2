using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;

namespace ISA.Common
{
    class Printer
    {
        StringReader myReader;
        public void PrintFile(string fileName)
        {
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.ThePrintDocument_PrintPage);
            myReader = new StringReader("Hello");
            doc.Print();
        }

        protected void ThePrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPosition = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;
            System.Drawing.Font printFont = new Font(new FontFamily ("Arial"), ((float)8.0));
            SolidBrush myBrush = new SolidBrush(Color.Black);

            // Work out the number of lines per page, using the MarginBounds.
            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

            // Iterate over the string using the StringReader, printing each line.
            while (count < linesPerPage && ((line = myReader.ReadLine()) != null))
            {
                // calculate the next line position based on 
                // the height of the font according to the printing device
                yPosition = topMargin + (count * printFont.GetHeight(ev.Graphics));

                // draw the next line in the rich edit control

                ev.Graphics.DrawString(line, printFont, myBrush, leftMargin, yPosition, new StringFormat());
                count++;
            }

            // If there are more lines, print another page.
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;

            myBrush.Dispose();

        }

    }
}
