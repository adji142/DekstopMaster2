using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISA.Toko.Laporan.Toko
{

    public class Toko
    {
        public Toko()
        {
            KodeToko = string.Empty;
            Kota = string.Empty;
        }

        public void AVG(int m)
        {
            FB2Omset = Math.Round(FB2Omset / m, 0);
            FB2Hpp = Math.Round(FB2Hpp / m, 0);

            FB4Omset = Math.Round(FB4Omset / m, 0);
            FB4Hpp = Math.Round(FB4Hpp / m, 0);

            FE2Omset = Math.Round(FE2Omset / m, 0);
            FE2Hpp = Math.Round(FE2Hpp / m, 0);

            FE4Omset = Math.Round(FE4Omset / m, 0);
            FE4Hpp = Math.Round(FE4Hpp / m, 0);

            LainyaOmset = Math.Round(LainyaOmset / m, 0);
            LainyaHpp = Math.Round(LainyaHpp / m, 0);
        }
        public string KodeToko
        {
            get;
            set;
        }

        public string Kota
        {
            get;
            set;
        }
        #region Value
        public double FB2Omset
        {
            get;
            set;
        }

        public double FB2Hpp
        {
            get;
            set;
        }

        public double FB2Laba
        {

            get;
            set;
        }


        public double FB4Omset
        {
            get;
            set;
        }

        public double FB4Hpp
        {
            get;
            set;
        }

        public double FB4Laba
        {

            get;
            set;
        }


        public double FE2Omset
        {
            get;
            set;
        }

        public double FE2Hpp
        {
            get;
            set;
        }

        public double FE2Laba
        {

            get;
            set;
        }


        public double FE4Omset
        {
            get;
            set;
        }

        public double FE4Hpp
        {
            get;
            set;
        }

        public double FE4Laba
        {

            get;
            set;
        }


        public double LainyaOmset
        {
            get;
            set;
        }

        public double LainyaHpp
        {
            get;
            set;
        }

        public double LainyaLaba
        {

            get;
            set;
        }

        #endregion

    }

}
