using MySchool.BSL;
using MySchool.FORMS;
using MySchool.Models;
using MySchool.Services;
using MySchool.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySchool.Persenter
{
   public class EmphasisStudentPersenter
    {
        EmphasisStudent emphasisStud;
        IEmphasisStudentView view;
       


        public EmphasisStudentPersenter(IEmphasisStudentView view)
        {
            this.view = view;
            InitializeData();
            view.btnActiveYear.Click += BtnActiveYear_Click;
            view.btnAddStud.Click += BtnAddStud_Click;
            view.gridview.RowClick += Gridview_RowClick;
            view.lkpClass.EditValueChanged += LkpClass_EditValueChanged;
        }

        private void BtnAddStud_Click(object sender, EventArgs e)
        {
            FRM_students frm_stud = new FRM_students();
            frm_stud.ShowDialog();
            RefreshStudent();
        }

        private void BtnActiveYear_Click(object sender, EventArgs e)
        {
            FRM_StudyYears frm_year = new FORMS.FRM_StudyYears();
            frm_year.ShowDialog();
            SelecteYearActive();
        }

        private void LkpClass_EditValueChanged(object sender, EventArgs e)
        {
            RefreshGridView();
            
        }

        
        private void Gridview_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            New();
            emphasisStud.Id = Convert.ToInt32(view.gridview.GetFocusedRowCellValue("id"));
            emphasisStud.Studentid = Convert.ToInt32(view.gridview.GetFocusedRowCellValue("stud_id"));
            emphasisStud.StatId = Convert.ToInt32(view.gridview.GetFocusedRowCellValue("stat_id"));
            emphasisStud.ClassId = Convert.ToInt32(view.gridview.GetFocusedRowCellValue("classe_id"));
            emphasisStud.YearId = Convert.ToInt32(view.gridview.GetFocusedRowCellValue("year_id"));
            get();
        }

        void InitializeData()
        {
            RefreshGridView();
            RefreshStudent();
           
            view.lkpClass.Properties.DataSource = ClassesOperations.GetAllClass();
            view.lkpClass.Properties.DisplayMember = "class_name";
            view.lkpClass.Properties.ValueMember = "class_id";

            view.lkpStud.Properties.DisplayMember = "stud_name";
            view.lkpStud.Properties.ValueMember = "stud_id";

            view.lkpStat.Properties.DataSource = new List<StudentStatus>()
                                                {
                                                    new StudentStatus() {Id=1,stud_status="مستجد" },
                                                    new StudentStatus() {Id=2,stud_status="باقي" }
                                                };
            view.lkpStat.Properties.DisplayMember = "stud_status";
            view.lkpStat.Properties.ValueMember = "Id";

            SelecteYearActive();
            view.lkpYear.Properties.DisplayMember = "year_name";
            view.lkpYear.Properties.ValueMember = "year_id";
        }
        void SelecteYearActive()
        {
            view.lkpYear.Properties.DataSource = YearsOperation.ActiveYear();
            view.lkpYear.EditValue = YearsOperation.ActiveYear().Rows[0][0];
            RefreshGridView();
        }
        void RefreshStudent()
        {
            view.lkpStud.Properties.DataSource = StudentsOperations.GetAllStudents();
        }
       
        void RefreshGridView()
        {
            New();
            set();
            view.gridcontrol.DataSource = EmphasisStudentOperation.GetAllEmphasisStudent(emphasisStud.YearId, emphasisStud.ClassId);
        }
        void set()
        {
            emphasisStud.Id       = view.id;
           emphasisStud.Studentid = (view.lkpStud.EditValue as int?) ?? 0;
           emphasisStud.StatId    = (view.lkpStat.EditValue as int?) ?? 0;
            emphasisStud.ClassId  = (view.lkpClass.EditValue as int?) ?? 0;
            emphasisStud.YearId   = (view.lkpYear.EditValue as int?) ?? 0;
        }

        public void get()
        {
            view.id = emphasisStud.Id;
            //view.lkpClass.EditValue = emphasisStud.ClassId;
            view.lkpStud.EditValue = emphasisStud.Studentid;
            view.lkpStat.EditValue = emphasisStud.StatId;
        }

        public void New()
        {
            emphasisStud = new EmphasisStudent();
        }

        public void Delete()
        {
            set();

            if (emphasisStud.Id == 0)
            {
                MessageBox.Show("لايوجد عنصر محدد لحذفه");
            }
            else
            {
                if (MessageBox.Show("تأكيد الحذف!!", "هل انت متاكد انك تريد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    EmphasisStudentOperation.DeleteEmphasisStudentData(emphasisStud.Id);
                    MessageBox.Show("تم الحذف بنجاح");
                    RefreshGridView();

                }
            }
        }


        public void Save()
        {
            if (IsDataValid())
            {
                set();

                if (emphasisStud.Id == 0)
                {
                    if (!IsExist())
                    {
                        Add();
                    }
                }
                else
                {
                    Update();
                }
                RefreshGridView();

            }
        }

        void Add()
        {
            EmphasisStudentOperation.AddEmphasisStudent(emphasisStud);
            MessageBox.Show("تم الاظافة بنجاح");
        }

        void Update()
        {
            EmphasisStudentOperation.UpdateEmphasisStudent(emphasisStud);
            MessageBox.Show("تم التحديث بنجاح");

        }


        //التحقق من الحقول ليست فارغة
        bool IsDataValid()
        {
            int errors = 0;
            if (view.lkpClass.Text.Trim() == string.Empty)
            {
                view.lkpClass.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            if (view.lkpStud.Text.Trim() == string.Empty)
            {
                view.lkpStud.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            if (view.lkpStat.Text.Trim() == string.Empty)
            {
                view.lkpStat.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            if (view.lkpYear.Text.Trim() == string.Empty)
            {
                view.lkpYear.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            return errors == 0;

        }
        bool IsExist()
        {
            if (EmphasisStudentOperation.ExistItem( emphasisStud.YearId,emphasisStud.Studentid).Rows.Count > 0)
            {
                MessageBox.Show("هذا العنصر مجود من قبل");
                return true;
            }
            else
                return false;
        }
        public class StudentStatus
        {
            public int Id { get; set; }
            public string stud_status { get; set; }
        }
    }
}
