using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

namespace PathfinderRaceBuilder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Adapted from http://stackoverflow.com/questions/629712/how-to-set-c-sharp-library-path-for-an-application
            AppDomain.CurrentDomain.AssemblyResolve += (s, e) =>
            {
                var filename = new AssemblyName(e.Name).Name;
                var path = string.Format(Application.StartupPath + @"\Data\{0}.dll", filename);
                return Assembly.LoadFrom(path);
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread updateThread = new Thread(new ThreadStart(UpdateChecker.FindUpdate));
            updateThread.Start();

            SplashForm splash = new SplashForm();
            splash.ShowDialog();

            Application.Run(new RaceBuilderForm());
            
            updateThread.Abort();

            if (UpdateChecker.foundUpdate)
            {
                if (MessageBox.Show("An update is available for " + Application.ProductName + ".  Would you like to visit the website?", "Update Found!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    Process.Start(UpdateChecker.url);
            }
        }
    }
}
