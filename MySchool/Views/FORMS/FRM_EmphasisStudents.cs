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
    public partial class FRM_EmphasisStudents : FRM_Master, IEmphasisStudentView
    {
        private int ID;
        EmphasisStudentPersenter emphaStud;
        #region MyProperty
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


        public LookUpEdit lkpClass
        {
            get
            {
                return lokclass;
            }
        }

        public LookUpEdit lkpStat
        {
            get
            {
                return lokstat;
            }
        }

        public LookUpEdit lkpStud
        {
            get
            {
               return  lokstudent;
            }
        }

        public LookUpEdit lkpYear
        {
            get
            {
                return lokyear;
            }
        }
        public SimpleButton btnAddStud
        {
            get
            {
                return BtnAddStud;
            }
        }
        public SimpleButton btnActiveYear
        {
            get
            {
                return BtnActivYear;
            }
        }
         
        #endregion


        public FRM_EmphasisStudents()
        {
            InitializeComponent();
            emphaStud = new Persenter.EmphasisStudentPersenter(this);
        }
        public override void New()
        {
            emphaStud.New();
            emphaStud.get();
        }
        public override void Save()
        {
            emphaStud.Save();
        }

        public override void Delete()
        {
            emphaStud.Delete();
        }

    }
}
