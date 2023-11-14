using MySchool.FORMS;
using MySchool.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using MySchool.Persenter;

namespace MySchool.Views.FORMS
{
    public partial class FRM_TeachersInYear : FRM_Master , ITeacherInYearView
    {
        private int ID;
        TeacherInYearPersenter teachPersenter;

        #region My Property

        public GridControl gridcontrol
        {
            get
            {
                return gridControl1;
            }
        }

        public GridView gridview
        {
            get
            {
               return gridView1;
            }
        }

        public int id
        {
            get
            {
                return ID;
            }

            set
            {
                ID = value;
            }
        }

        public LookUpEdit lokYear
        {
            get
            {
                return lookUpEdit1;
            }
        }

        public CheckedListBoxControl SubListbox
        {
            get
            {
                return checkedListBoxControl1;
            }
        }
        #endregion
        public FRM_TeachersInYear()
        {
            InitializeComponent();
            teachPersenter = new Persenter.TeacherInYearPersenter(this);
        }

        public override void New()
        {
            teachPersenter.New();
            teachPersenter.get();

        }
        public override void GetData()
        {

        }
        public override void Save()
        {
            teachPersenter.Save();
        }
        public override void Delete()
        {
            teachPersenter.Delete();
        }
    }
}
