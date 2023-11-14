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
    public partial class FRM_Exam : FRM_Master, IExamView
    {
        private int ID;
        ExamPersenter exampersener;
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

        public SpinEdit SpEdGradeMax
        {
            get
            {
                return spinEdit1;
            }
        }

        public TextEdit txeExamName
        {
            get
            {
                return textEdit1;
            }
        }

        public LookUpEdit lkpTerm
        {
            get
            {
                return lookUpEdit1;
            }
        }
        #endregion

        public FRM_Exam()
        {
            InitializeComponent();
            exampersener = new Persenter.ExamPersenter(this);
        }
        public override void Save()
        {
            exampersener.Save();
        }
        public override void New()
        {
            exampersener.New();
        }
        public override void Delete()
        {
            exampersener.Delete();
        }

    }
}
