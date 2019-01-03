using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ISA.Finance
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        public static frmMain _mainForm;
        public static frmLogin _loginForm;

        public static frmLogin LoginForm
        {
            get
            {
                return _loginForm;
            }
        }


        public static frmMain MainForm
        {
            get
            {
                return _mainForm;
            }
            set
            {
                _mainForm = value;
            }
        }
        [STAThread]
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _mainForm = new frmMain();
            _loginForm = new frmLogin();

            Application.Run(_loginForm);
        }
    }
}
