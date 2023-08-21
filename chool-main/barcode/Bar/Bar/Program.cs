using System.Diagnostics;

using System;
namespace Bar
{
    internal static class Program
    {
        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            Log.writeLog(e.ToString());
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new INVCheck());
        }
        
    }
}