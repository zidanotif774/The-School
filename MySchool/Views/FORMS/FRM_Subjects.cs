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

namespace MySchool.FORMS
{
    public partial class FRM_Subjects: FRM_Master,ISubjectView
    {
        private int ID;
        SubjectPersenter subjectpersenter;

        #region Property
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

       

        public GridView gridview
        {
            get
            {
                return gridView1;
            }
            
        }

        public GridControl gridcontrol
        {
            get
            {
                return gridControl1;
            }

        }

        public TextEdit txtSubject
        {
            get
            {
                return txtsubject;
            }
        }

        #endregion
        //SubjectManger subject;
        public FRM_Subjects()
        {
            InitializeComponent();
            this.Load += FRM_Level_Load;
            subjectpersenter = new Persenter.SubjectPersenter(this);
            New();
            refresh();
        }

        private void FRM_Level_Load(object sender, EventArgs e)
        {
            //gridView1.OptionsBehavior.Editable = false;
            //gridView1.Columns[0].Visible=false;
            //gridView1.Columns[1].Caption = "المادة الدراسية ";
        }

        public override void New()
        {
            subjectpersenter.New();
            //subject = new SubjectManger();
            //GetData();
            //base.New();
        }
        public override void Save()
        {
            subjectpersenter.Save();
            //SetData();
            //if (IsValid())
            //{
            //    subject.SaveChengs();
            //        New();
            base.Save();
            //    refresh();
            //}
        }
        public override void GetData()
        {
            //txtsubject.Text = subject._SubjectName;
            //txtsubject.Focus();
            //base.GetData();
        }
        public override void SetData()
        {
            //subject._SubjectName = txtsubject.Text;
            //base.SetData();
        }
        public override void Delete()
        {
            subjectpersenter.Delete();
            //if (subject._SubjectId!=0)
            //{
            //    if (MessageBox.Show("هل تريد الحذف فعلا !!!","تأكيد الحذف ",MessageBoxButtons.YesNo,MessageBoxIcon.Stop)==DialogResult.Yes )
            //    {
            //        subject.DeletSubject();
            //         base.Delete();
            //        refresh();
            //        New();
            //    }

            //}

        }
        public bool IsValid()
        {
            
            //if (subject._SubjectName==string.Empty)
            //{
            //    txtsubject.ErrorText = "ادخال السم المادة ضروري";txtsubject.Focus(); return false;
            //}
            //if (subject.SubjecIsExist().Rows.Count>0)
            //{
            //    MessageBox.Show("هذه المادة موجودة مسبقا "); return false;
            //}
            return true;
        }
      
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //New();
            //if (gridView1.GetFocusedRowCellValue("sub_id").ToString() != null)
            //{
            //   subject._SubjectId= Convert.ToInt32(gridView1.GetFocusedRowCellValue("sub_id"));
            //    subject._SubjectName = gridView1.GetFocusedRowCellValue("sub_name").ToString();
            //    GetData();
            //}
        }
       public void refresh()
        {
            //gridControl1.DataSource = subject.GetAllSubjects();
        }
        public void getEndItem()
        {
           //subject.GetEndData() ;
        }
    }
}
