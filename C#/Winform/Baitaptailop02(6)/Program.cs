using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsAppAccountManager; // <-- ADD THIS LINE (Replace with your actual namespace if different)

namespace YourProjectNamespace // <-- This might be different from the form's namespace
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmBaiTap2()); // This line should now work
        }
    }
}