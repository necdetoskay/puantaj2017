using System;
using System.Windows.Forms;
using lic;

namespace puantaj2017
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!Util.CheckLic("353350a7c1a4e9a2a90129c31fd35b05")) return;
            Application.Run(new Form1());
        }
    }
}