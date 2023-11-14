using MySchool.BSL;
using MySchool.Models;
using MySchool.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySchool.Persenter
{
   public class StudentPersenter
    {
        Student student;
        IStudentView view;

        public StudentPersenter(IStudentView view)
        {
            this.view = view;
            InitializeControl();
            view.gridview.RowClick += Gridview_RowClick;
            RefreshData();
            InitializeControl();
        }

        private void Gridview_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            New();
            student.Id = Convert.ToInt32(view.gridview.GetFocusedRowCellValue("stud_id"));
            student.StudentName = view.gridview.GetFocusedRowCellValue("stud_name").ToString();
            student.SexId = (int)(view.gridview.GetFocusedRowCellValue("stud_sex_id"));
            student.StudentTitel = view.gridview.GetFocusedRowCellValue("stud_addres").ToString();
            student.PerthOfDate = (DateTime)view.gridview.GetFocusedRowCellValue("stud_bod_m");
            get();
        }

        void InitializeControl()
        {
            //view.lkpname.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            view.lkpsex.Properties.DataSource = new List<StudentSex>()
            {
                new StudentSex() {Id=1,stud_sex="ذكر" },
                new StudentSex() {Id=2,stud_sex="انثى" }
            };
            view.lkpsex.Properties.DisplayMember = "stud_sex";
            view.lkpsex.Properties.ValueMember = "Id";

            view.gridview.OptionsBehavior.Editable = false;
        }
        //void lookcolumn(LookUpEdit lkp)
        //{
        //    lkp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo
        //    {
        //        FieldName = "teach_id",
        //        Caption="سس",
        //        Visible=false
        //    }
        //        );
        //    lkp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo
        //    {
        //        FieldName = "teach_name_",
        //        Caption = "اسم المعلم",
        //        Visible = true
        //    }
        //        );
        //}

        void RefreshData()
        {
            view.gridcontrol.DataSource = StudentsOperations.GetAllStudents();
            New();
        }
        void set()
        {
            student.Id           = view.id;
             student.StudentName = view.txeStudent.Text;
             student.SexId       = (view.lkpsex.EditValue as int?) ?? 0;
            student.StudentTitel = view.txeTitl.Text;
            student.PerthOfDate  =( view.datPrthdate.EditValue as DateTime?)?? DateTime.UtcNow;
        }

        void get()
        {
            view.id = student.Id;
            view.txeStudent.Text = student.StudentName;
            view.lkpsex.EditValue = student.SexId;
            view.txeTitl.Text = student.StudentTitel;
            view.datPrthdate.DateTime = student.PerthOfDate;
        }
        public void New()
        {
            student = new Student();

            get();
        }

        public void Delete()
        {
            set();

            if (student.Id == 0)
            {
                MessageBox.Show("لايوجد عنصر محدد لحذفه");
            }
            else
            {
                if (MessageBox.Show("تأكيد الحذف!!", "هل انت متاكد انك تريد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    StudentsOperations.StudentDelete(student.Id);
                    MessageBox.Show("تم الحذف بنجاح");
                    RefreshData();

                }
            }
        }


        public void Save()
        {
            if (IsDataValid())
            {
                set();
                if (!IsExist())
                {
                    if (student.Id == 0)
                    {
                        Add();
                    }
                    else
                    {
                        Update();
                    }
                    RefreshData();
                }
            }
        }

        void Add()
        {
            StudentsOperations.AddStudent(student.StudentName,student.PerthOfDate,student.SexId,student.StudentTitel);
            MessageBox.Show("تم الاظافة بنجاح");
        }

        void Update()
        {
            StudentsOperations.UpdateStudent(student.Id, student.StudentName, student.PerthOfDate, student.SexId, student.StudentTitel);
            MessageBox.Show("تم التحديث بنجاح");

        }


        //التحقق من الحقول ليست فارغة
        bool IsDataValid()
        {
            int errors = 0;
            if (view.txeStudent.Text.Trim() == string.Empty)
            {
                view.txeStudent.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            if (view.lkpsex.Text == null)
            {
                view.lkpsex.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            if (view.txeTitl.Text.Trim() == string.Empty)
            {
                view.txeTitl.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            if (view.datPrthdate.Text.Trim() == string.Empty)
            {
                view.datPrthdate.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            return errors == 0;

        }
        bool IsExist()
        {
            if (StudentsOperations.ExistItem(student.StudentName.Trim()).Rows.Count > 0)
            {
                MessageBox.Show("هذا العنصر مجود من قبل");
                return true;
            }
            else
                return false;
        }
        public class StudentSex
        {
            public int Id { get; set; }
            public string stud_sex { get; set; }
        }
        public class StudentStatus
        {
            public int Id { get; set; }
            public string stud_status { get; set; }
        }
    }
}
