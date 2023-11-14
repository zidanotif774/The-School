using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySchool.Views.Interfaces;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using MySchool.Persenter;

namespace MySchool.FORMS
{
    public partial class FRM_ClassSubjects: FRM_Master, ISubjectClassView
    {
        private int ID=0;
        SubjectClassPersenter subclasspersenter;

        #region Property
        public int id
        {
            get
            {
              return  ID;
            }

            set
            {
                ID = value;
            }
        }

        public LookUpEdit lkpClass
        {
            get
            {
                return lkpclass;
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
        public CheckedListBoxControl SubListbox { get {return subListBox1 ; } }
        #endregion

      
        public FRM_ClassSubjects()
        {
            InitializeComponent();
            subclasspersenter = new SubjectClassPersenter(this);
          
           
          
        }
        public override void Save()
        {
            subclasspersenter.Save();
            //SetData();
            //if (IsValid())
            //{
            //    subClassManger.SaveChengs();
            //    base. Save();
            //    New();
            //    LoadDataInDataGridViwe();
            //}

        }
        public override void New()
        {
            subclasspersenter. New();
            subclasspersenter.get();
            //subClassManger = new SubjectClassManger();
            //GetData();
        }
        public override void GetData()
        {
            //    lokclass.EditValue = subClassManger._classeId;
            //    loksubject.EditValue = subClassManger._SubjectId;
            //base.GetData();
        }
    public override void SetData()
        {
            //subClassManger._classeId =(int) lokclass.EditValue;
            //subClassManger._SubjectId = (int)loksubject.EditValue;
            // base.SetData();
        }
        public void getEndItem()
        {
            
        }
        public override void Delete()
        {
            subclasspersenter.Delete();
            //if (subClassManger._subjectclassId != 0)
            //{
            //    if (MessageBox.Show("هل حقا تريد حذف هذا الصف الدراسي ..", "تأكيد الحذف!", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            //    {
            //        subClassManger.DeletClassSubject();
            //        base.Delete();
            //        New();
            //        LoadDataInDataGridViwe();
            //    }
            //}
        }
        public bool IsValid()
        {
            //if (subClassManger._classeId==0)
            //{
            //    lokclass.ErrorText = "اختيار الصف مطلوب "; lokclass.Focus(); return false;
            //}
            //if (subClassManger._SubjectId == 0)
            //{
            //    loksubject.ErrorText = "اختيار المادة مطلوب"; loksubject.Focus(); return false;
            //}
            //if (subClassManger.ClassSubjecIsExist().Rows.Count != 0)
            //{
            //    MessageBox.Show("هذه المادة موجودة مسبقا في هذا الصف "); loksubject.Focus(); return false;
            //}
            return true;
        }
        public void fillCombo()
        {
            //ClassesManger ClsMang = new ClassesManger();
            //SubjectManger SubMang = new SubjectManger();

            //lokclass.Properties.DataSource = ClsMang.GetAllClass ();
            //lokclass.Properties.DisplayMember = ClsMang.GetAllClass().Columns[1].ToString();
            //lokclass.Properties.ValueMember = ClsMang.GetAllClass().Columns[0].ToString();
            

            //loksubject.Properties.DataSource = SubMang.GetAllSubjects();
            //loksubject.Properties.DisplayMember = SubMang.GetAllSubjects().Columns[1].ToString();
            //loksubject.Properties.ValueMember = SubMang.GetAllSubjects().Columns[0].ToString(); ;

        }
        public override void LoadDataInDataGridViwe()
        {
            //gridControl1.DataSource = subClassManger.GetAllClassSubjects();
           
            //base.LoadDataInDataGridViwe();
        }

        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            //New();
            //subClassManger._subjectclassId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ClSu_id"));
            //subClassManger._classeId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("classe_id"));
            //subClassManger._SubjectId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("sub_id")); 
            //GetData();
        }

        private void FRM_Classes_Load(object sender, EventArgs e)
        {
            //gridView1.Columns["class_name"].Caption = "اسم الصف الدراسي :";
            //gridView1.Columns["sub_name"].Caption = "اسم المادة الدراسية :";
            //gridView1.Columns[0].Visible = false;
            //gridView1.Columns[1].Visible = false;
            //gridView1.Columns[2].Visible = false;
        }

        private void lkpclass_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
