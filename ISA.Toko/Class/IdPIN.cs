using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISA.Toko.Class
{
    class IdPIN
    {

        public struct Bagian
        {
            public const int ClosingRegister = 9;
            public const int CetakRegister = 11;
            public const int PinRegisterBySales = 15;
            public const int CetakRegisterSPV = 16;
            public const int CetakRegisterSupport = 17;
            public const int CetakRegisterPKP = 18;
        }

        //public struct ModulId
        //{
        //    public const string RekonClosing = "01";
        //    public const string OverduePenjualan = "02";
        //    public const string ReturPenjualan = "03";
        //    public const string SalesmanScoreKunjunganSales = "04";
        //}

        public struct Periode
        {

            public const int Hari = 0;
            public const int Minggu = 1;
            public const int Bulan = 2;
            public const int Tahun = 2;
        }
    }
}
