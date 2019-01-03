using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ISA.DAL;
using ISA.Common;

namespace ISA.Trading
{
    public class LookupInfoValue
    {
        public static bool CekRekonHarian()
        {
            string lookupValue = LookupInfo.GetValue("RULE_TOGGLE", "REKON_HARIAN");
            if (lookupValue == string.Empty)
                lookupValue = "1";

            return lookupValue == "1";
        }

        public static bool CekBmk11()
        {
            string lookupValue = LookupInfo.GetValue("RULE_TOGGLE", "BMK_DARI_11");
            if (lookupValue == string.Empty)
                lookupValue = "0";

            return lookupValue == "1";
        }

        public static bool CekHpp11()
        {
            string lookupValue = LookupInfo.GetValue("RULE_TOGGLE", "HPP_DARI_11");
            if (lookupValue == string.Empty)
                lookupValue = "0";

            return lookupValue == "1";
        }

        public static bool CekBmkPos()
        {
            string lookupValue = LookupInfo.GetValue("RULE_TOGGLE", "POS_VALIDASI_BMK");
            if (lookupValue == string.Empty)
                lookupValue = "1";

            return lookupValue == "1";
        }

        public static bool CekAccDo(string userId)
        {
            string lookupValue = LookupInfo.GetValue("ACC_DO", userId);
            if (lookupValue == string.Empty)
                lookupValue = "0";

            return lookupValue == "1";
        }

        public static bool CekAccRetur(string userId)
        {
            string lookupValue = LookupInfo.GetValue("ACC_Retur", userId);
            if (lookupValue == string.Empty)
                lookupValue = "0";

            return lookupValue == "1";
        }

        public static bool CekAccSO(string userId)
        {
            string lookupValue = LookupInfo.GetValue("ACC_SO", userId);
            if (lookupValue == string.Empty)
                lookupValue = "0";

            return lookupValue == "1";
        }

        public static bool CekFixAreaEnable(string kodeGudang)
        {
            string lookupValue = LookupInfo.GetValue("FIX_AREA_ENABLE", kodeGudang);
            if (lookupValue == string.Empty)
                lookupValue = "0";

            return lookupValue == "1";
        }

        public static bool CekPrintSj()
        {
            string lookupValue = LookupInfo.GetValue("RULE_TOGGLE", "PRINT_SJ");
            if (lookupValue == string.Empty)
                lookupValue = "0";

            return lookupValue == "1";
        }

        public static bool CekEditAccDo()
        {
            string lookupValue = LookupInfo.GetValue("RULE_TOGGLE", "EDIT_ACC_DO");
            if (lookupValue == string.Empty)
                lookupValue = "0";

            return lookupValue == "1";
        }

    }
}
