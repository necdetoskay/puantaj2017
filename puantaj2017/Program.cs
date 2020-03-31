using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraLayout.Customization;
using DevExpress.XtraPrinting.Native;
using lib;
using puantaj2017.DAL;
using PtakipDAL;


namespace puantaj2017
{
    internal static class Program{
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {

          
           
            //var oo=new ptakipBL();
            //oo.RaporTara();
            ////var f=new TEST();
            ////f.ShowDialog();//return;


            //#endregion
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // var f = new BES();
            // f.ShowDialog();
            //return;

            if (Debugger.IsAttached){
                var form = new Form1();
                form.ShowDialog();
            }
            else
            {
                var form = new Form1();
                Util.CheckLic("353350a7c1a4e9a2a90129c31fd35b05", form);
            }

          

            //var f=new testt();//f.Tag = per.db;

            //var f = new PTakip();
            //Application.Run(f);
            //return;

            //Process[] processesBefore = Process.GetProcessesByName("excel");

           
            //Process[] processesAfter = Process.GetProcessesByName("excel");
            //int processID = 0;
            //foreach (Process process in processesAfter)
            //{
            //    if (!processesBefore.Select(p => p.Id).Contains(process.Id))
            //    {
            //        processID = process.Id;
            //    }
            //}if (processID != 0)
            //{
            //    Process process = Process.GetProcessById(processID);
            //    process.Kill();
            //}

        }
    }
}