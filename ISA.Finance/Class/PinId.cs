using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISA.Finance.Class
{
    class PinId
    {
        public struct Bagian
        {
            public const int Stok = 1;
            public const int Penjualan = 2;
            public const int Direksi = 3;
            public const int Keuangan = 4;
            public const int Piutang = 5;
            public const int KPJ = 28;
        }

        public struct ModulId
        {
            public const string SalesmanScore = "01";
            public const string OrderPembelianAddCekB = "02";
            public const string SalesmanScoreSuratJalan = "03";
            public const string SalesmanScoreKunjunganSales = "04";
            public const string RekapKunjunganSales = "05";
            public const string TempoSpesial = "06";
            public const string PenerimaanTunai = "07";
            public const string OrderPenjualanTagihan = "08";
            public const string NotaTT = "09";
            public const string BiayaOperasional = "10";
            public const string BankTutup = "11";
            public const string ToleransiMundurGiro = "12";
            public const string AdjPiutang11 = "13";
            public const string AdjAccounting11 = "14";
        }

        public struct Periode
        {

            public const int Hari = 0;
            public const int Minggu = 1;
            public const int Bulan = 2;
            public const int Tahun = 2;
        }
    }
}
