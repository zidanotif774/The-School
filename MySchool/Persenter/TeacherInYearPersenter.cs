using MySchool.BSL;
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
    public class TeacherInYearPersenter
    {

        //TeacherInYear teachinyear;
        TeacherInYear teachsInYear;
        ITeacherInYearView view;
        List<Teacher> teachersSList;

        public TeacherInYearPersenter(ITeacherInYearView view)
        {
            this.view = view;
           
            view.gridview.RowClick += Gridview_RowClick;
            view.lokYear.EditValueChanged += LokYear_EditValueChanged;

            view.lokYear.Properties.DataSource = YearsOperation.GetAllyears();
            view.lokYear.Properties.DisplayMember = "year_name";
            view.lokYear.Properties.ValueMember = "year_id";



            view.SubListbox.DisplayMember = "teach_name_";
            view.SubListbox.ValueMember = "teach_id";

            RefreshData();
        }

        private void LokYear_EditValueChanged(object sender, EventArgs e)
        {
            New();
            teachsInYear.yearid = (view.lokYear.EditValue as int?) ?? 0;
            teachsInYear = TeacherInYearOperation.GetListTeachersInYear().Where(y => y.yearid == teachsInYear.yearid).SingleOrDefault();

            if (teachsInYear != null)
            {
                foreach (Teacher teach in teachsInYear.teachers)
                {

                    {
                        view.SubListbox.SelectedValue = teach.Teach_id;
                        view.SubListbox.CheckSelectedItems();
                        view.id = teachsInYear.id;
                    }
                }
            }
        }

        private void LkpYear_EditValueChanged(object sender, EventArgs e)
        {
          
        }

        private void Gridview_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //New();
            //view.id = Convert.ToInt32(view.gridview.GetFocusedRowCellValue("ClSu_id"));
            //view.lkpYear.EditValue = view.gridview.GetFocusedRowCellValue("classe_id");

        }



        void RefreshData()
        {

            New();
            get();
            view.gridcontrol.DataSource = TeacherInYearOperation.GetAllTeachersInYear();
        }
        void set()
        {
            teachsInYear = new TeacherInYear();
            teachsInYear.id = view.id;
            teachsInYear.yearid = (view.lokYear.EditValue as int?) ?? 0;
            foreach (var item in view.SubListbox.CheckedItems)
            {
                teachersSList.Add(new Teacher
                {
                    Teach_id = Convert.ToInt32(view.SubListbox.GetItemValue(view.SubListbox.FindItem(item))),
                    Teach_name = view.SubListbox.GetItemText(view.SubListbox.FindItem(item))
                    //Classid = ,
                    //subid =Convert.ToInt32( view.SubListbox.GetItemValue (view.SubListbox.FindItem(item)) ),
                    //subName= view.SubListbox.GetItemText(view.SubListbox.FindItem(item))
                });
            }
            teachsInYear.teachers = teachersSList;
        }

        public void get()
        {
            view.id = teachsInYear.id;
            view.lokYear.EditValue = teachsInYear.yearid;

        }

        public void New()
        {
            //teachinyear = new TeacherInYear();
            teachsInYear = new Models.TeacherInYear();
            teachersSList = new List<Teacher>();
            view.SubListbox.DataSource = TeacherOperation.GetAllTeachers();


        }

        public void Delete()
        {
            set();

            if (teachsInYear.id == 0)
            {
                MessageBox.Show("لايوجد عنصر محدد لحذفه");
            }
            else
            {
                if (MessageBox.Show("تأكيد الحذف!!", "هل انت متاكد انك تريد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    TeacherInYearOperation.DeleteTeachersInYear(teachsInYear.id);
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
                    if (teachsInYear.id == 0)
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
            TeacherInYearOperation.AddTeacherInYearData(teachsInYear);
            MessageBox.Show("تم الاظافة بنجاح");
        }

        void Update()
        {
            TeacherInYearOperation.UpdateTeacherInYearData(teachsInYear);
            MessageBox.Show("تم التحديث بنجاح");

        }

        //int AutoNum()
        //{
        //    return TeacherInYearOperation.GetAllTeachersInYear().Count + 1;
        //}

        //التحقق من الحقول ليست فارغة
        bool IsDataValid()
        {
            int errors = 0;
            if (view.lokYear.Text.Trim() == string.Empty)
            {
                view.lokYear.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            //if (view.lkpSubject.Text.Trim() == string.Empty)
            //{
            //    view.lkpSubject.ErrorText = "هذا الحقل مطلوب";
            //    errors += 1;
            //}

            return errors == 0;

        }
        bool IsExist()
        {
            //if (SubjectClassOperation.ExistItem(sujectclass.Classid,sujectclass.subjectid).Rows.Count > 0)
            //{
            //    MessageBox.Show("هذا العنصر مجود من قبل");
            //    return true;
            //}
            //else
            return false;
        }

    }
}
