using DevExpress.LookAndFeel;
using MySchool.FORMS;
using MySchool.Properties;
using MySchool.Reports;
using MySchool.Views.FORMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySchool
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
            UserLookAndFeel.Default.SkinName = Settings.Default.SkinName.ToString();
            
            Application.Run(new FRM_main());
        }
    }
}
