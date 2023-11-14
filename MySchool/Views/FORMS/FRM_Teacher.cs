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
    public partial class FRM_Teacher : FRM_Master, ITeacherView
    {
        private int id;
        TeacherPersenter teachpersenter;
        #region Property
        public int teach_id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public CheckEdit isActive
        {
            get
            {
                return CheckActive;
            }
        }

        public TextEdit txename
        {
            get
            {
                return txeteachname;
            }
        }

        public LookUpEdit lkpsex
        {
            get
            {
                return lokTeachersex;
            }
        }

        TextEdit ITeacherView.txtmajor
        {
            get
            {
                return txtmajor;
            }
        }

        public TextEdit txtteach_phonnum
        {
            get
            {
                return txtPhonNum;
            }
        }

        public TextEdit txtcardnum
        {
            get
            {
                return txtCardNum;
            }
        }
        public GridControl gridcontrol
        {
            get { return gridControl1; }
        }
        public GridView gridview
        {
            get { return gridView1; }
        }


        #endregion
        //TeacherManger teacherManger;
        //Teacher teacher;

        public FRM_Teacher()
        {
            InitializeComponent();
            teachpersenter = new TeacherPersenter(this);

            //New();
            //fillLookup();
            //LoadDataInDataGridViwe();
        }
        public override void Save()
        {
            teachpersenter.Save();

            //SetData();
            //if (IsValid())
            //{
            //    teacherManger.InsertStudent(teacher);
            //    teacherManger.SaveChengs();
            //    base.Save();
            //    getEndItem();
            //    LoadDataInDataGridViwe();
            //}

        }
        public override void New()
        {
            teachpersenter.New();
            teachpersenter.get();
            //teacher = new Teacher();
            //teacherManger = new TeacherManger();
            //GetData();
            //base.New();
        }
        public override void GetData()
        {
            //lokyear.EditValue = teacher.Year_id;
            //lokteachname.Text = teacher.Teach_name;
            //lokTeachersex.EditValue = teacher.Teach_sex;
            //txtmajor.Text = teacher.Teach_major;
            //txtPhonNum.Text = teacher.Teach_PhonNum;
            //txtCardNum.Text = teacher.Teach_CardNum;
            //base.GetData();
        }
        public override void SetData()
        {
            //teacher.Year_id = (lokyear.EditValue as int?) ?? 0;
            //teacher.Teach_name = lokteachname.Text;
            //teacher.Teach_sex = (lokTeachersex.EditValue as int?) ?? 0;
            //teacher.Teach_major = txtmajor.Text;
            //teacher.Teach_PhonNum = txtPhonNum.Text;
            //teacher.Teach_CardNum = txtCardNum.Text;


            base.SetData();
        }
        public void getEndItem()
        {
            //teacher.Teach_id = teacherManger.GetEndData().Teach_id;
            //teacher.Teach_name = teacherManger.GetEndData().Teach_name;

        }
        public override void Delete()
        {
            teachpersenter.Delete();
            //if (teacher.Teach_id != 0)
            //{
            //    if (MessageBox.Show("هل حقا تريد حذف هذا الطالب ..", "تأكيد الحذف!", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            //    {
            //        teacherManger.DeletTeacher(teacher);
            //        base.Delete();
            //        New();
            //        LoadDataInDataGridViwe();
            //    }
            //}
        }
        public bool IsValid()
        {
            ////bool valid = true;
            //if (teacher.Year_id == 0)
            //{
            //    lokyear.ErrorText = " اخيار العام الدراسي مطلوب ..";/*valid = false*/; return false;
            //}
            //if (teacher.Teach_name == string.Empty)
            //{
            //    lokteachname.ErrorText = "هذا الحقل مطلوب !"; return false;
            //}
            //if (teacher.Teach_sex == 0)
            //{
            //    lokTeachersex.ErrorText = "اختيار نوع المعلم  مطلوب .."; return false;
            //}


            //if (teacherManger.StudentIsExistInClassInYearStudy(teacher.Teach_name,teacher.Year_id).Rows.Count > 0)
            //{
            //    MessageBox.Show("هذا المعلم موجود مسبقا في هذا العام .."); return false;
            //}
            return true;
        }
        public bool IsNotExist(string std, int yr, int cls)
        {
            //bool isnotexist = true;
            //if (teacherManger.StudentIsExistInClassInYearStudy(teacher.Teach_name, teacher.Year_id).Rows.Count > 0)
            //{
            //    isnotexist = false;
            //}
            return true;
        }
        public void fillLookup()
        {

            //YearsManger yearmanger = new YearsManger();

            //lokteachname.Properties.DataSource = teacherManger.GetAllTeacher();
            //lokteachname.Properties.DisplayMember = teacherManger.GetAllTeacher().Columns[1].ToString();
            //lokteachname.Properties.ValueMember = teacherManger.GetAllTeacher().Columns[0].ToString();





            //lokyear.Properties.DataSource = yearmanger.GetAllyears();
            //lokyear.Properties.DisplayMember = "year_name";
            //lokyear.Properties.ValueMember = "year_id";
        }
        public override void LoadDataInDataGridViwe()
        {
            //gridControl1.DataSource = teacherManger.GetAllTeacher();

            //base.LoadDataInDataGridViwe();
        }


        public class TeacherSex
        {
            public int Id { get; set; }
            public string Teach_sex { get; set; }
        }
        public class StudentStatus
        {
            public int Id { get; set; }
            public string stud_status { get; set; }
        }


        private void FRM_Teacher_Load(object sender, EventArgs e)
        {
            //lokteachname.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            //lokTeachersex.Properties.DataSource = new List<TeacherSex>()
            //{
            //    new TeacherSex() {Id=1,Teach_sex="ذكر" },
            //    new TeacherSex() {Id=2,Teach_sex="انثى" }
            //};
            //lokTeachersex.Properties.DisplayMember = "Teach_sex";
            //lokTeachersex.Properties.ValueMember = "Id";
            ////lokTeachersex.Properties.Columns[0].Visible = false;
            //gridView1.OptionsBehavior.Editable = false;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //New();
            //teacher.Teach_id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("teach_id"));
            //teacher.Teach_name = gridView1.GetFocusedRowCellValue("teach_name_").ToString();
            //teacher.Teach_sex = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Teacher_sex"));
            //teacher.Teach_major = gridView1.GetFocusedRowCellValue("major").ToString();
            //teacher.Teach_PhonNum = gridView1.GetFocusedRowCellValue("phone").ToString();
            //teacher.Teach_CardNum = gridView1.GetFocusedRowCellValue("Teacher_CardNum").ToString();
            //teacher.Year_id = (int)gridView1.GetFocusedRowCellValue("year_id");


            //GetData();
        }

        private void lokyear_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
    }
