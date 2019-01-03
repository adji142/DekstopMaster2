using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ISA.DAL;
using ISA.Common;

namespace ISA.Finance
{
    public class LookupInfoValue
    {
        public static bool CekValidasiRegister()
        {
            string lookupValue = LookupInfo.GetValue("RULE_TOGGLE", "VALIDASI_REGISTER");
            if (lookupValue == string.Empty)
                lookupValue = "1";

            return lookupValue == "1";
        }

        public static bool CekPinCetakRegister()
        {
            string lookupValue = LookupInfo.GetValue("RULE_TOGGLE", "PIN_CETAK_REGISTER");
            if (lookupValue == string.Empty)
                lookupValue = "1";

            return lookupValue == "1";
        }

        public static bool CekIndenTunai()
        {
            string lookupValue = LookupInfo.GetValue("RULE_TOGGLE", "INDEN_TUNAI");
            if (lookupValue == string.Empty)
                lookupValue = "0";

            return lookupValue == "1";
        }

        public static bool CekPrintBs()
        {
            string lookupValue = LookupInfo.GetValue("RULE_TOGGLE", "PRINT_BS");
            if (lookupValue == string.Empty)
                lookupValue = "1";

            return lookupValue == "1";
        }

        public static bool CekPrintBukuBank()
        {
            string lookupValue = LookupInfo.GetValue("RULE_TOGGLE", "PRINT_BUKU_BANK");
            if (lookupValue == string.Empty)
                lookupValue = "1";

            return lookupValue == "1";
        }

        public static bool CekEkspedisi()
        {
            string lookupValue = LookupInfo.GetValue("RULE_TOGGLE", "CEK_EKSPEDISI");
            if (lookupValue == string.Empty)
                lookupValue = "1";

            return lookupValue == "1";
        }
    }
}
