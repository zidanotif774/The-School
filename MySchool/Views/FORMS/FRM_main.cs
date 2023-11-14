using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Reflection;
using MySchool.Properties;
using DevExpress.LookAndFeel;
using MySchool.Reports;

namespace MySchool.Views.FORMS
{
    public partial class FRM_main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FRM_main()
        {
            InitializeComponent();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void ribbon_ItemClick(object sender, ItemClickEventArgs e)
        {
            var tag = e.Item.Tag as string;
            if (tag != string.Empty)
            {
                OpenFormByName(tag);
            }
        }
        private void AccordionControl1_ElementClick(object sender, DevExpress.XtraBars.Navigation.ElementClickEventArgs e)
        {
          
        }

        public static void OpenFormByName(string name)
        {
            var instans = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == name);
            if (instans != null)
            {
                var frm = Activator.CreateInstance(instans) as Form;
                if (Application.OpenForms[frm.Name] != null)
                {
                    frm = Application.OpenForms[frm.Name];
                }
                else
                {
                    frm.Show();
                }
                frm.BringToFront();
            }
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void FRM_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.SkinName = UserLookAndFeel.Default.SkinName;
            Settings.Default.Save();
        }

        private void FRM_main_Load(object sender, EventArgs e)
        {
            UserLookAndFeel.Default.SkinName = Settings.Default.SkinName.ToString();
        }
        public static int yearid = 0;
        public static int termid = 0;
        public static int classid = 0;
        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            FRM_SendParameters frm = new FRM_SendParameters();
            frm.ShowDialog();
            Reports.rpt_Results1 rpt = new Reports.rpt_Results1(yearid, termid, classid);
            rpt.Print();

        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            FRM_SendParameters frm = new FRM_SendParameters();
            frm.lkpterm.Enabled = false;
            frm.ShowDialog();
            Reports.rpt_Results2 rpt = new Reports.rpt_Results2(yearid, classid);
            rpt.Print();
        }
    }
}