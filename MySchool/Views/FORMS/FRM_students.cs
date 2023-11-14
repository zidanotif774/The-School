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
    public partial class FRM_students: FRM_Master, IStudentView
    {
        #region My Property
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

        public TextEdit txeStudent
        {
            get
            {
                return txtName;
            }
        }

        public LookUpEdit lkpsex
        {
            get
            {
                return loksex;
            }
        }

        public DateEdit datPrthdate
        {
            get
            {
                return dateparth;
            }
        }

        public TextEdit txeTitl
        {
            get
            {
                return txttitl;
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
              return   gridControl1;
            }
        }
        #endregion

        StudentPersenter studPersenter;
        private int ID;

        public FRM_students()
        {
            InitializeComponent();
            studPersenter = new Persenter.StudentPersenter(this);


            New();
        }
        public override void Save()
        {

            studPersenter.Save();
            //try
            //{
            //SetData();
            //if (IsValid())
            //{
            //StudentsManger.InsertStudent(student);
            //StudentsManger.SaveChengs();
            //base.Save();
            //getEndItem();
            //LoadDataInDataGridViwe();
            //New();
            //}
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message);}
        } 
        public override void New()
        {
            studPersenter.New();
            //student = new Student();
            //GetData();
            //base.New();
            //dateparth.Text = string.Empty;
        }
        public override void GetData()
        {
            //lokyear.EditValue = student.YearId;
            //loklevel.EditValue = student.LevelId;
            //lokclass.EditValue = student.ClassId;
            //lokstut.EditValue = student.StstusId;
            //txtName.Text = student.StudentName;
            //loksex.EditValue = student.SexId;
            //dateparth.EditValue = student.PerthOfDate;
            //txttitl.Text = student.StudentTitel;
            //base.GetData();
        }
        public override void SetData()
        {
            //student.YearId = (lokyear.EditValue as int?) ?? 0;
            //student.LevelId = (loklevel.EditValue as int?) ?? 0;
            //student.ClassId= (lokclass.EditValue as int?) ?? 0;
            //student.StstusId = (lokstut.EditValue as int?) ?? 0;
            //student.StudentName = txtName.Text;
            //student.SexId = (loksex.EditValue as int?) ?? 0;
            //student.PerthOfDate =(DateTime) dateparth.EditValue;
            //student.StudentTitel = txttitl.Text;

            //base.SetData();
        }
        public void getEndItem()
        {
           // student.StudentId=StudentsManger.GetEndData().StudentId;
           //student.StudentName = StudentsManger.GetEndData().StudentName;
            
        }
        public override void Delete()
        {
            studPersenter.Delete();
            //if (student.StudentId!=0)
            //{
            //    if (MessageBox.Show("هل حقا تريد حذف هذا الطالب ..","تأكيد الحذف!",MessageBoxButtons.YesNo,MessageBoxIcon.Stop)==DialogResult.Yes)
            //    {
            //        StudentsManger.DeletClass(student);
            //        base.Delete();
            //        New();
            //        LoadDataInDataGridViwe();
            //    }
            //}
        }
        public bool IsValid()
        {
            //if (student.YearId==0)
            //{
            //    lokyear.ErrorText = " اخيار العام الدراسي مطلوب ..";return false;
            //}
            //if (student.LevelId==0)
            //{
            //    loklevel.ErrorText = "اختيار المرحلة الدراسية مطلوب ..";return false;
            //}
            //if (student.ClassId==0)
            //{
            //    lokclass.ErrorText = "اختيار الصف الدراسي مطلوب ..";return false;
            //}
            //if (student.StstusId==0)
            //{
            //    lokstut.ErrorText = "اختيار حالة الطالب (مستجد _اوباقي) مطلوب ..";return false;
            //}
            //if (student.StudentName==string.Empty)
            //{
            //    txtName.ErrorText = "ادخل اسم الطالب ..";return false;
            //}
            //if (student.SexId==0)
            //{
            //    loksex.ErrorText = "تحديد نوع الطالب مطلوب ..";return false;
            //}
            ////if (StudentsManger.StudentIsExistInClassInYearStudy(student.StudentName, student.YearId, student.ClassId).Rows.Count > 0)
            ////{
            ////    MessageBox.Show("هذا الطالب موجود مسبقا .."); return false;
            ////}
            return true;
        }
        public bool IsNotExist(string std, int yr,int cls)
        {
            bool isnotexist = true;
            //if (StudentsManger.StudentIsExistInClassInYearStudy(std,yr,cls).Rows.Count > 0)
            //{
            //    isnotexist = false;
            //}
            return isnotexist;
        }
        public void fillLookup()
        {
            //classmanger = new ClassesManger();
            //levelmanger = new LevelsManger();
            //YearsManger yearmanger = new YearsManger();

            //loklevel.Properties.DataSource = levelmanger.GetAllLevels();
            //loklevel.Properties.DisplayMember = levelmanger.GetAllLevels().Columns[1].ToString();
            //loklevel.Properties.ValueMember= levelmanger.GetAllLevels().Columns[0].ToString();
           

            //lokclass.Properties.DisplayMember = "class_name";
            //lokclass.Properties.ValueMember = "class_id";

            //lokyear.Properties.DataSource = yearmanger.GetAllyears();
            //lokyear.Properties.DisplayMember = "year_name";
            //lokyear.Properties.ValueMember = "year_id";

        }
        public override void LoadDataInDataGridViwe()
        {
            
           //gridControl1.DataSource = StudentsManger.GetAllStudent();
           // //gridView1.Columns["class_name"].Caption = "اسم الصف الدراسي :";
            //gridView1.Columns["level_name"].Caption = "اسم المرحلة الدراسية :";
            //gridView1.Columns[0].Visible = false;
            //gridView1.Columns[2].Visible = false;
           
            base.LoadDataInDataGridViwe();
        }

        
        public class StudentSex
        {
            public int Id { get; set; }
            public string stud_sex { get ; set; }
        }
        public class StudentStatus
        {
            public int Id { get; set; }
            public string stud_status { get; set; }
        }

        private void FRM_students_Load(object sender, EventArgs e)
        {
            //New();

            //loksex.Properties.DataSource = new List<StudentSex>()
            //{
            //    new StudentSex() {Id=1,stud_sex="ذكر" },
            //    new StudentSex() {Id=2,stud_sex="انثى" } 
            //};
            //loksex.Properties.DisplayMember = "stud_sex";
            //loksex.Properties.ValueMember = "Id";

            //lokstut.Properties.DataSource = new List<StudentStatus>()
            //{
            //    new StudentStatus() {Id=1,stud_status="مستجد" },
            //    new StudentStatus() {Id=2,stud_status="باقي" }
            //};
            //lokstut.Properties.DisplayMember = "stud_status";
            //lokstut.Properties.ValueMember = "Id";

            //gridView1.OptionsBehavior.Editable = false;
            //gridView1.Columns[0].Visible = false;
            //gridView1.Columns[1].Visible = false;
            //gridView1.Columns[2].Visible = false;
            //gridView1.Columns[6].Visible = false;
            //gridView1.Columns[8].Visible = false;
            //gridView1.Columns[10].Visible = false;
            //gridView1.Columns["stud_name"].Caption = "اسم الطالب ";
            //gridView1.Columns["stud_bod_m"].Caption = "تاريخ الميلاد ";
            //gridView1.Columns["sex_name"].Caption = "النوع ";
            //gridView1.Columns["stat_name"].Caption = "حالة القيد ";
            //gridView1.Columns["level_name"].Caption = "المرحلة الدراسية ";
            //gridView1.Columns["class_name"].Caption = "الصف الدراسي ";
            //gridView1.Columns["year_name"].Caption = "السنة الدراسية ";
            //gridView1.Columns["stud_addres"].Caption = "محل الإقامة ";

        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {

            //New();
            //student.StudentId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("stud_id"));
            //student.StudentName = gridView1.GetFocusedRowCellValue("stud_name").ToString();
            //student.LevelId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("level_id"));
            //student.ClassId = (int)(gridView1.GetFocusedRowCellValue("class_id"));
            //student.YearId = (int)(gridView1.GetFocusedRowCellValue("year_id"));
            //student.StstusId = (int)(gridView1.GetFocusedRowCellValue("stud_status_id"));
            //student.PerthOfDate = (DateTime)gridView1.GetFocusedRowCellValue("stud_bod_m");
            //student.SexId = (int)(gridView1.GetFocusedRowCellValue("stud_sex_id"));
            //student.StudentTitel = gridView1.GetFocusedRowCellValue("stud_addres").ToString();

            //lokclass.Properties.DataSource = classmanger.GetClassWithLevel(student.LevelId);
            //GetData();
        }

        private void lokclass_Properties_MouseDown(object sender, MouseEventArgs e)
        {
            //if (loklevel.EditValue!=null)
            //{
            //    lokclass.Properties.DataSource = classmanger.GetClassWithLevel((int)loklevel.EditValue);
            //}
        }

        private void dateparth_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            //string dt = dateparth.Text;
            //MessageBox.Show(dt);
        }


        //public enum Sex
        //{
        //   Male,
        //  female
        //}
    }
}
