using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing.Printing;


namespace ISA.Bengkel.Class
{
    class BuildString1
    {
        const char ESC = (char)27;
        private string dataString;
        private string LF = Convert.ToString((char)10);
        private string CR = Convert.ToString((char)13);

        public BuildString1()
        {
            dataString = string.Empty;
        }

        public void Append(string data)
        {
            dataString = dataString + data;
        }

        public void AppendLine()
        {
            dataString = dataString + "\n";
        }

        public void AppendLine(string data)
        {
            dataString = dataString + "\n" + data;
        }

        public void Insert(int startIndex, string data)
        {
            if (startIndex > dataString.Length)
            {
                AddSpace(startIndex);
                dataString = dataString.Insert(startIndex, data);
            }
            else
            {
                dataString = dataString.Insert(startIndex, data);
            }
        }

        private void AddSpace(int index)
        {
            while (dataString.Length != index)
            {
                dataString = dataString + " ";
            }
        }

        public void Empty()
        {
            dataString = string.Empty;
        }

        public string GenerateString()
        {
            string retVal = dataString;
            dataString = string.Empty;
            return retVal;
        }

        public void PROW(bool newRow, int lenght, string value)
        {
            if (newRow)
            {
                dataString = dataString + CR + LF + SPACE(lenght) + value;
            }
            else
            {
                int index = 0;
                int start = 0;
                //dataString = dataString + CR + SPACE(lenght) + value;

                for (int i = dataString.Length - 1; i >= 0; i--)
                {
                    if (dataString[i].ToString() == LF || dataString[i].ToString() == CR)
                    {
                        index = i;
                        break;
                    }
                }
                start = (index + 1) + lenght;

                Insert(start, value);
            }
        }

        public string SPACE(int n)
        {
            string retVal = string.Empty;

            for (int i = 0; i < n; i++)
            {
                retVal = retVal + " ";
            }

            return retVal;
        }

        public void AddCR()
        {
            dataString = dataString + CR;
        }

        //
        public void Initialize()
        {
            dataString = dataString + ESC + "@";
        }

        public void PageLLine(int n)
        {
            dataString = dataString + ESC + "C" + (char)n;
        }

        public void PageLInch(int n)
        {
            dataString = dataString + ESC + "C" + (char)0 + (char)n;
        }

        public void LeftMargin(int n)
        {
            dataString = dataString + ESC + "l" + (char)n;
        }

        public void BottomMargin(int n)
        {
            dataString = dataString + ESC + "N" + (char)n;
        }

        public void Proportional(bool value)
        {
            string temp = value == true ? ESC + "p" + (char)1 : ESC + "p" + (char)0;
            dataString = dataString + temp;
        }

        public void FontCondensed(bool value)
        {
            char retVal;
            retVal = value == true ? (char)15 : (char)18;

            dataString = dataString + retVal.ToString();
        }

        public void FontCondensed2(bool value)
        {
            string retVal;
            retVal = value == true ? ESC.ToString() + (char)15 : ESC.ToString() + (char)18;

            dataString += retVal;
        }

        public void FontCPI(int n)
        {
            string retVal = string.Empty;
            switch (n)
            {
                case 10: retVal = ESC + "P"; break;
                case 12: retVal = ESC + "M"; break;
                case 15: retVal = ESC + "g"; break;
            }
            dataString = dataString + retVal.ToString();
        }

        public void FontSubScript(bool value)
        {
            string temp = value == true ? ESC + "S" + (char)1 : ESC + "T";
            dataString = dataString + temp;
        }

        public void FontBold(bool value)
        {
            string temp = value == true ? ESC + "E" : ESC + "F";
            dataString = dataString + temp;
        }

        public void FontItalic(bool value)
        {
            string temp = value == true ? ESC + "4" : ESC + "5";
            dataString = dataString + temp;
        }

        public void FontUnderline(bool value)
        {
            string temp = value == true ? ESC + "-" + (char)1 : ESC + "-" + (char)0;
            dataString = dataString + temp;
        }

        public void DoubleWidth(bool value)
        {
            string temp = value == true ? ESC + "W" + (char)1 : ESC + "W" + (char)0;
            dataString = dataString + temp;
        }

        public void DoubleHeight(bool value)
        {
            string temp = value == true ? ESC + "w" + (char)1 : ESC + "w" + (char)0;
            dataString = dataString + temp;
        }

        public void LineSpacing(string value)
        {
            string retVal = string.Empty;

            if (value.Equals("1/8"))
            {
                retVal = ESC + "0";
            }
            else if (value.Equals("1/6"))
            {
                retVal = ESC + "2";
            }
            else if (value.Contains("/180"))
            {
                retVal = ESC + "3" + (char)int.Parse(value.Replace("/180", ""));
            }
            else if (value.Contains("/360"))
            {
                retVal = ESC + "+" + (char)int.Parse(value.Replace("/360", ""));
            }

            dataString = dataString + retVal;
        }

        public void LetterQuality(bool value)
        {
            string temp = value == true ? ESC + "x" + (char)1 : ESC + "x" + (char)0;
            dataString = dataString + temp;
        }

        public void Eject()
        {
            dataString = dataString + SPACE(58) + Convert.ToString((char)12);
        }

        public string STR(int length, string data)
        {
            return data.PadLeft(length, ' ');
        }

        public string Sales(string data)
        {
            string retVal = string.Empty;
            int count = string.IsNullOrEmpty(data) == true ? 0 : data.Length;

            if (count < 27)
            {
                retVal = data + SPACE(27 - count);
            }
            else
            {
                retVal = data;
            }

            return retVal;
        }

        public string PrintDoubleLine(int lenght)
        {
            string Val = string.Empty;
            for (int i = 1; i <= lenght; i++)
            {
                //Val = Val + "Í"; //Convert.ToString((char)205);
                Val = Val + Convert.ToString((char)205);
            }
            return Val;
        }

        public string Replicate(string value, int lenght)
        {
            string Val = string.Empty;
            for (int i = 1; i <= lenght; i++)
            {
                Val += value;
            }
            return Val;
        }

        public string PrintEqualSymbol(int lenght)
        {
            string Val = string.Empty;
            for (int i = 1; i <= lenght; i++)
            {
                Val = Val + "=";
            }
            return Val;
        }

        public string PrintMinusSymbol(int lenght)
        {
            string Val = string.Empty;
            for (int i = 1; i <= lenght; i++)
            {
                Val = Val + "-";
            }
            return Val;
        }

        public string PrintHorizontalLine(int lenght)
        {
            string Val = string.Empty;
            for (int i = 1; i <= lenght; i++)
            {
                //Val = Val + "Ä"; //Convert.ToString((char)196);
                Val = Val + Convert.ToString((char)196);
            }
            return Val;
        }

        #region "Print T Thick"
        public string PrintTTOp()
        {
            // "Â"
            return Convert.ToString((char)194);
        }

        public string PrintTMidlle()
        {
            // "Å"
            return Convert.ToString((char)197);
        }

        public string PrintTBottom()
        {
            // "Á"
            return Convert.ToString((char)193);
        }

        public string PrintTLeft()
        {
            // "Ã"
            return Convert.ToString((char)195);
        }

        public string PrintTRight()
        {
            // "´"
            return Convert.ToString((char)180);
        }
        #endregion

        public string PrintRightBottomCorner()
        {
            // "¾"
            return Convert.ToString((char)190);
        }

        #region "T Bold"
        public string PrintTBTOp()
        {
            // "Â"
            return Convert.ToString((char)194);
        }

        public string PrintTBMidlle()
        {
            // "Å"
            return Convert.ToString((char)197);
        }

        public string PrintTBBottom()
        {
            // "Á"
            return Convert.ToString((char)193);
        }

        public string PrintTBLeft()
        {
            // "Ã"
            return Convert.ToString((char)195);
        }

        public string PrintTBRight()
        {
            // "´"
            return Convert.ToString((char)180);
        }
        #endregion

        public string PrintVerticalLine()
        {
            //return "³"; // Convert.ToString((char)179);
            return Convert.ToString((char)179);
        }


        public string PrintTopLeftCorner()
        {
            //return "Ú"; // Convert.ToString((char)218);
            return Convert.ToString((char)218);
        }

        public string PrintTopRightCorner()
        {
            //return "¿";// Convert.ToString((char)191);
            return Convert.ToString((char)191);
        }

        public string PrintBottomLeftCorner()
        {
            //return "À"; // Convert.ToString((char)192);
            return Convert.ToString((char)192);
        }

        public string PrintBottomRightCorner()
        {
            //return "Ù"; // Convert.ToString((char)217);
            return Convert.ToString((char)217);
        }

        public string GetDayName(string day)
        {
            string retVal = string.Empty;
            switch (day.ToLower())
            {
                case "monday": retVal = "Senin"; break;
                case "tuesday": retVal = "Selasa"; break;
                case "wednesday": retVal = "Rabu"; break;
                case "thursday": retVal = "Kamis"; break;
                case "friday": retVal = "Jumat"; break;
                case "saturday": retVal = "Sabtu"; break;
                case "sunday": retVal = "Minggu"; break;
                default: retVal = day; break;
            }

            return retVal;
        }

        public string Alamat(string alamat)
        {
            return alamat.PadRight(60, ' ');
        }

        public string Daerah(string daerah)
        {
            return daerah.PadRight(22, ' ');
        }

        public string Kota(string kota)
        {
            return kota.PadRight(20, ' ');
        }

        public string NamaStok(string namaStok)
        {
            return namaStok.PadRight(73, '.');
        }

        public byte[] GetBytes()
        {
            byte[] retVal = new byte[dataString.Length];

            for (int i = 0; i < dataString.Length; i++)
            {
                retVal[i] = Convert.ToByte(dataString[i]);
            }

            return retVal;
        }

        public byte[] GetBytes(string contents)
        {
            byte[] retVal = new byte[contents.Length];

            for (int i = 0; i < contents.Length; i++)
            {
                retVal[i] = Convert.ToByte(contents[i]);
            }

            return retVal;
        }

        public void SendToPrinter(string fileName, string contents)
        {
            string FilePath = Properties.Settings.Default.OutputFile + "\\" + fileName;

            File.WriteAllBytes(Properties.Settings.Default.OutputFile + "\\" + fileName, GetBytes(contents));

            string printerName = GetPrinterName();
            RawPrinterHelper.SendFileToPrinter(printerName, FilePath);
        }

        public void SendToPrinter(string fileName)
        {
            /* Original Code
            string FilePath = Properties.Settings.Default.OutputFile + "\\" + fileName;
            File.WriteAllBytes(Properties.Settings.Default.OutputFile + "\\" + fileName, GetBytes());

            string printerName = GetPrinterName();
            RawPrinterHelper.SendFileToPrinter(printerName, FilePath);
            */
            string printerName = GetPrinterName();
            RawPrinterHelper.SendBytesFileToPrinter(printerName, GetBytes());
        }

        public void SendToFile(string fileName)
        {

            string FilePath = Properties.Settings.Default.OutputFile + "\\" + fileName;
            File.WriteAllBytes(Properties.Settings.Default.OutputFile + "\\" + fileName, GetBytes());

            //string printerName = GetPrinterName();
            //RawPrinterHelper.SendFileToPrinter(printerName, FilePath);

            string printerName = GetPrinterName();
            RawPrinterHelper.SendBytesFileToPrinter(printerName, GetBytes());
        }

        public void SendToPrinter()
        {
            string printerName = GetPrinterName();
            RawPrinterHelper.SendBytesFileToPrinter(printerName, GetBytes());
        }

        private void WriteToFile(string fullFileName, string contents)
        {


            //set up a filestream
            FileStream fs = new
            FileStream(fullFileName, FileMode.Create, FileAccess.Write);

            //set up a streamwriter for adding text

            StreamWriter sw = new StreamWriter(fs);

            //find the end of the underlying filestream

            sw.BaseStream.Seek(0, SeekOrigin.Begin);

            //add the text 
            sw.Write(contents);
            //sw.WriteLine(contents);
            //add the text to the underlying filestream

            sw.Flush();
            //close the writer
            sw.Close();


        }

        public string PadCenter(int length, string value)
        {
            string retval = string.Empty;
            int padValue = 0;
            int temp = 0;
            if (string.IsNullOrEmpty(value))
            {
                retval = SPACE(length);
            }
            else
            {
                if (value.Length >= length)
                {
                    retval = value.PadRight(length);
                }
                else
                {
                    temp = length - value.Length;
                    padValue = temp / 2;

                    if (temp % 2 == 0)
                    {
                        retval = SPACE(padValue) + value + SPACE(padValue);
                    }
                    else
                    {
                        retval = SPACE(padValue) + value + SPACE(padValue + 1);
                    }
                }
            }
            return retval;
        }

        public string GetPrinterName()
        {
            PrintDocument doc = new PrintDocument();

            return doc.PrinterSettings.PrinterName;
        }
    }
}
