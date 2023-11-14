using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySchool.BSL;
using MySchool.Services;
using MySchool.Views.FORMS;

namespace MySchool.Reports
{
    public partial class FRM_SendParameters : DevExpress.XtraEditors.XtraForm
    {
        public FRM_SendParameters()
        {
            InitializeComponent();
            lkpyear.Properties.DataSource = YearsOperation.GetAllyears();
            lkpyear.Properties.DisplayMember = "year_name";
            lkpyear.Properties.ValueMember = "year_id";

            lkpterm.Properties.DataSource = Master.Listterms; 
            lkpterm.Properties.DisplayMember = "Term_name";
            lkpterm.Properties.ValueMember = "id";

            lkpclass.Properties.DataSource = ClassesOperations.GetAllClass();
            lkpclass.Properties.DisplayMember = "class_name";
            lkpclass.Properties.ValueMember = "class_id";
            int itemActive = 0;
            int yearactive = 0;
            if (TermOperation.ExistItem().Rows.Count>0)
                 itemActive = Convert.ToInt32(TermOperation.ExistItem().Rows[0][0]);
            if (YearsOperation.ActiveYear().Rows.Count > 0)
                yearactive = Convert.ToInt32(YearsOperation.ActiveYear().Rows[0][0]); 
            lkpyear.EditValue = yearactive;
            lkpterm.EditValue = itemActive;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FRM_main.yearid = (lkpyear.EditValue as int ?)??0;
            FRM_main.termid = (lkpterm.EditValue as int?) ?? 0;
            FRM_main.classid = (lkpclass.EditValue as int?) ?? 0;
            this.Close();
        }
    }
}