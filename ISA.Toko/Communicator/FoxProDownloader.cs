using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using ISA.DAL;
using System.Windows.Forms;

namespace ISA.Toko.Communicator
{
    class FoxProDownloader
    {
        public enum enDownloadType 
        { 
            BMK,
            Sales,
            Stock,
            Toko
        }

        enDownloadType _tableType;

        public FoxProDownloader(enDownloadType tableType)
        {
            _tableType = tableType;
        }

        public static void OpenFile()
        {

        }

        public static void DownloadBMK()
        {

        }
    }
}
