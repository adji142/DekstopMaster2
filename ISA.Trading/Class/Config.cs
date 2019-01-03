using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ISA.Trading
{
    class Config
    {        
        //private variable
        static int _timeOutLimit=4800;

        //properties
        public static int TimeOutLimit
        {
            get
            {
                return _timeOutLimit;
            }
        }       
    }
}


