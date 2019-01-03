using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISA.Finance
{
    class Setorans
    {
        static int _Year;
        static int _Month;
        static bool _LMin;
        static double _Min;
        static bool _TActual;
        
        public static DateTime TglSetoran
        {
            get { return new DateTime(_Year, _Month, 1).AddMonths(1).AddDays(-1); }
        }
        public static int Year
        {
            get { return    _Year; }
            set { _Year   = value; }
        }

        public static int Month
        {
            get { return _Month; }
            set { _Month = value; }
        }

        public static bool LMin
        {
            get { return _LMin; }
            set {   _LMin = value;
                }
        }

        public static double Min
        {
            get { return _Min; }
            set {   _Min = value;
                }
        }

        public static bool TActual
        {
            get { return _TActual; }
            set { _TActual = value; }
        }

        public static void initialize()
        {
            _Year = DateTime.Now.Year;
            _Month = DateTime.Now.Month;
            _LMin = ISA.Finance.Properties.Settings.Default.LMin ;
            _Min = ISA.Finance.Properties.Settings.Default.Min;
            _TActual = ISA.Finance.Properties.Settings.Default.TActual;
        }

        public static void SetoranSave()
        {
            ISA.Finance.Properties.Settings.Default.LMin = _LMin;
            ISA.Finance.Properties.Settings.Default.Min = _Min;
            ISA.Finance.Properties.Settings.Default.TActual = _TActual;
            ISA.Finance.Properties.Settings.Default.Save();     
        }
    }
     
    class Kasirs
    {
        public static bool Recalculated
        {
            get;
            set;
        }
        public static void initialize()
        {
            Recalculated = false;
        }
    }
}
