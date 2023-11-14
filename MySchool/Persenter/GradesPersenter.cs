using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using MySchool.BSL;
using MySchool.Models;
using MySchool.Services;
using MySchool.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySchool.Persenter
{
   public class GradesPersenter
    {
        Grades grades;
        IGradesView view;
        decimal MaxGrade;
        public GradesPersenter(IGradesView view)
        {
            this.view = view;
            //InitializeControl();
            view.gridview.RowClick += Gridview_RowClick;
            view.lkpterm.EditValueChanged += Lkpterm_EditValueChanged;
            view.lkpclass.EditValueChanged += Lkpclass_EditValueChanged;
            view.lkpexam.EditValueChanged += Lkpexam_EditValueChanged;
            view.lkpsubject.EditValueChanged += Lkpsubject_EditValueChanged;
            view.spnMark.ValueChanged += SpnMark_ValueChanged;
            view.ListStud.SelectedIndexChanged += ListStud_SelectedIndexChanged;
           
          
            titel();
            InitializeControl();
            New();
        }

        private void SpnMark_ValueChanged(object sender, EventArgs e)
        {
            //set();
            decimal gradLimit = 0;
            if (view.lkpexam.GetColumnValue("gradMax") != null)
            {
                gradLimit =Convert.ToDecimal (view.lkpexam.GetColumnValue("gradMax")); 
            }
           
            if (view.spnMark.Value > gradLimit)
            {
                view.spnMark.Value = gradLimit;
            }
        }

     

        private void ListStud_SelectedIndexChanged(object sender, EventArgs e)
        {
            view.lkpStudent.EditValue = view.ListStud.SelectedValue;
            view.txeSubject.Text = view.lkpsubject.Text;
            view.spnMark.Focus();
            titel();
        }

       
        private void Lkpsubject_EditValueChanged(object sender, EventArgs e)
        {
            view.txeSubject.Text = view.lkpsubject.Text;
            RefreshData();
            titel();
        }

        private void Lkpexam_EditValueChanged(object sender, EventArgs e)
        {
            MaxGrade =( view.lkpexam.GetColumnValue(view.lkpexam.Properties.Columns["gradeMax"]) as int ?)??0;
            SpnMark_ValueChanged(null, null);
            RefreshData();
            titel();
        }

        private void ListStud_SelectedValueChanged(object sender, EventArgs e)
        {
            view.lkpStudent.EditValue = view.ListStud.SelectedValue;
            view.txeSubject.Text = view.lkpsubject.Text;
            view.spnMark.Focus();
            titel();
        }

      

        private void Lkpclass_EditValueChanged(object sender, EventArgs e)
        {
            set();
            view.ListStud.DataSource = StudentsOperations.GetAllStudents(grades.classId, grades.yearId);
            view.lkpStudent.Properties.DataSource = StudentsOperations.GetAllStudents(grades.classId, grades.yearId);
            view.lkpsubject.Properties.DataSource = SubjectClassOperation.GetAllClassSubjects(grades.classId);
            RefreshData();
            titel();
        }

        private void Lkpterm_EditValueChanged(object sender, EventArgs e)
        {
            set();
            if (grades.termId==(int)Master.Terms.term1)
                view.lkpexam.Properties.DataSource = Master.ListExamTerm1; 
            else 
                view.lkpexam.Properties.DataSource = Master.ListExamTerm2; 
            titel();
        }

        private void Gridview_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (!e.RowHandle.Equals(null))
                {
                    New();
                    grades.Id = Convert.ToInt32(view.gridview.GetFocusedRowCellValue("id"));
                    grades.yearId = (int)view.gridview.GetFocusedRowCellValue("year_id");
                    grades.termId = (int)(view.gridview.GetFocusedRowCellValue("term_id"));
                    grades.classId = (int)view.gridview.GetFocusedRowCellValue("class_id");
                    grades.studId = (int)view.gridview.GetFocusedRowCellValue("stud_id");
                    view.txeSubject.Text= view.gridview.GetFocusedRowCellValue("sub_name").ToString();
                    grades.subjectId = (int)view.gridview.GetFocusedRowCellValue("sub_id");
                    grades.examId = (int)view.gridview.GetFocusedRowCellValue("exam_id");
                    grades.mark = (decimal)view.gridview.GetFocusedRowCellValue("mark");
                    get();
                }
            }
            catch (Exception) { }
           
        }

        void InitializeControl()
        {
            //view.lkpname.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            view.lkpyear.Properties.DataSource = YearsOperation.GetAllyears();
           
            view.lkpyear.Properties.DisplayMember = "year_name";
            view.lkpyear.Properties.ValueMember = "year_id";

            
            view.lkpterm.Properties.DataSource = Master.Listterms;
            view.lkpterm.Properties.DisplayMember = "Term_name";
            view.lkpterm.Properties.ValueMember = "id";
           
            view.lkpclass.Properties.DataSource = ClassesOperations.GetAllClass();
            view.lkpclass.Properties.DisplayMember = "class_name";
            view.lkpclass.Properties.ValueMember = "class_id";

            view.lkpexam.Properties.DisplayMember = "Name";
            view.lkpexam.Properties.ValueMember = "ID";

            view.lkpsubject.Properties.DisplayMember = "sub_name";
            view.lkpsubject.Properties.ValueMember = "sub_id";

            view.ListStud.DisplayMember = "stud_name";
            view.ListStud.ValueMember = "stud_id";

            view.lkpStudent.Properties.DisplayMember = "stud_name";
            view.lkpStudent.Properties.ValueMember = "stud_id";
            view.gridview.OptionsBehavior.Editable = false;
        }
       void titel()
        {
            view.LblTitel1.Text = "إدخال درجات ";
            view.LblTitel2.Text = " " + "الـصف :" + " " + view.lkpclass.Text;
            view.LblTitel3.Text=  " "+ "الـمادة :" +" "+  view.lkpsubject.Text;
            view.LblTitel4.Text = view.lkpexam.Text;
        }
       
        void IntiolDataSuorceGrid(DataTable Table, GridControl gc)
       {
            
                List<ReportGrade> ListReport = new List<ReportGrade>();
                foreach (DataRow row in Table.Rows)
                {
                    string year = row["year_name"].ToString();
                    string classname = row["class_name"].ToString();
                    string termname = row["term_name"].ToString();
                    string studname = row["stud_name"].ToString();
                    string subname = row["sub_name"].ToString();
                    string examname = row["exam_name"].ToString();
                    decimal mark = Convert.ToDecimal(row["mark"]);
                    decimal markMax = Convert.ToDecimal(row["gradeMax"]);

                    ReportGrade regrd = ListReport.Find(x => x.stdname == studname);
                    if (regrd == null)
                    {
                        regrd = new ReportGrade { yrname = year, trmname = termname, clsname = classname, stdname = studname };
                        ListReport.Add(regrd);
                    }
                 sub  sbj = ListReport.Find(x => x.stdname == studname).sublist.Find(y => y.sbname == subname);
                    if (sbj == null)
                    {
                        sbj = new sub { sbname = subname };
                       regrd.sublist.Add(sbj);
                    }
                    mrks mrk = new mrks { mark = mark, gmax = markMax };
                    sbj.marklist.Add(mrk);

                }
            gc.DataSource = ListReport;
            

            //// إنشاء جدول جديد لتخزين النتائج
            //DataTable newTable = new DataTable();

            //// إضافة حقول الطالب والصف الدراسي والفصل الدراسي والمادة الدراسية إلى الجدول الجديد
            //newTable.Columns.Add("اسم الطالب");
            //newTable.Columns.Add("اسم الصف الدراسي");
            //newTable.Columns.Add("اسم الفصل الدراسي");
            //newTable.Columns.Add("اسم المادة الدراسية");

            //// استخدام Pivot لتحويل البيانات
            //var query = from row in tabel.AsEnumerable()
            //            group row by new
            //            {
            //                StudentName = row.Field<string>("stud_name"),
            //                ClassName = row.Field<string>("class_name"),
            //                //SectionName = row.Field<string>("اسم الفصل الدراسي"),
            //                SubjectName = row.Field<string>("sub_name")
            //            } into grp
            //            select new
            //            {
            //                StudentName = grp.Key.StudentName,
            //                ClassName = grp.Key.ClassName,
            //                //SectionName = grp.Key.SectionName,
            //                SubjectName = grp.Key.SubjectName,
            //                Exams = grp.Select(row => new
            //                {
            //                    ExamName = row.Field<string>("exam_name"),
            //                    Grade = row.Field<decimal>("mark")
            //                })
            //            };

            //// إضافة حقول الامتحانات ودرجات الطالب في تلك الامتحانات إلى الجدول الجديد
            //foreach (var item in query)
            //{
            //    foreach (var exam in item.Exams)
            //    {
            //        if (!newTable.Columns.Contains(exam.ExamName))
            //        {
            //            newTable.Columns.Add(exam.ExamName);
            //        }
            //    }
            //}

            //// إضافة البيانات إلى الجدول الجديد
            //foreach (var item in query)
            //{
            //    DataRow newRow = newTable.NewRow();
            //    newRow["اسم الطالب"] = item.StudentName;
            //    newRow["اسم الصف الدراسي"] = item.ClassName;
            //    //newRow["اسم الفصل الدراسي"] = item.SectionName;
            //    newRow["اسم المادة الدراسية"] = item.SubjectName;

            //    foreach (var exam in item.Exams)
            //    {
            //        newRow[exam.ExamName] = exam.Grade;
            //    }

            //    newTable.Rows.Add(newRow);
            //}
            //gc.DataSource = null;
            //gc.DataSource = newTable;

        }
        void IntiolDataSuorceGrid1(DataTable tabel, GridControl gc)
        {
            // إنشاء جدول جديد
            DataTable newTable = new DataTable();
            newTable.Columns.Add("اسم الطالب");
            newTable.Columns.Add("اسم الصف الدراسي");
            newTable.Columns.Add("اسم الفصل الدراسي");
            newTable.Columns.Add("اسم المادة الدراسية");

            // حلقة لمراجعة الصفوف في الجدول الأصلي
            foreach (DataRow row in tabel.Rows)
            {
                string studentName = row["stud_name"].ToString();
                string className = row["class_name"].ToString();
                //string semesterName = row["اسم الفصل الدراسي"].ToString();
                string subjectName = row["sub_name"].ToString();

                // إضافة صف جديد في الجدول الجديد
                DataRow newRow = newTable.NewRow();
                newRow["اسم الطالب"] = studentName;
                newRow["اسم الصف الدراسي"] = className;
                //newRow["اسم الفصل الدراسي"] = semesterName;
                newRow["اسم المادة الدراسية"] = subjectName;

                // إنشاء أعمدة جديدة بناءً على الامتحانات وتعيين قيمها
                foreach (DataColumn column in tabel.Columns)
                {
                    if (column.ColumnName== "exam_name")
                    {
                        if (newTable.Columns.Contains("exam_name"))
                        {
                            newRow["exam_name"] = row["mark"];
                        }
                        else
                        {
                        string examName = column.ColumnName;
                        double examGrade = Convert.ToDouble(row["mark"]);
                        newTable.Columns.Add(examName, typeof(double));
                        newRow[examName] = examGrade;
                            
                        }

                    }
                }

                //newTable.Rows.Add(newRow);
            }

            gc.DataSource = newTable;
        }
        void RefreshData()
        {
            New();
            //view.gridcontrol.DataSource=null;
            //view.gridcontrol.RefreshDataSource();
            set(); /*GradesReportOperation.GetAllGrades(yearid, termid, classid)*/
            //IntiolDataSuorceGrid(GradesReportOperation.GetAllGrades(
            //  grades.yearId, grades.termId, grades.classId/*, grades.examId, grades.subjectId*/), view.gridcontrolTest);
            view.gridcontrol.DataSource = GradesOperations.GetAllGrades(
                grades.yearId, grades.termId, grades.classId, grades.examId, grades.subjectId);
        }
        void set()
        {
            grades.Id = view.id;
            grades.yearId = (view.lkpyear.EditValue as int?) ?? 0;
            grades.termId = (view.lkpterm.EditValue as int?) ?? 0;
            grades.classId = (view.lkpclass.EditValue as int?) ?? 0;
            grades.examId = (view.lkpexam.EditValue as int?) ?? 0;
            grades.studId = (view.lkpStudent.EditValue as int?) ?? 0;
            grades.subjectId = (view.lkpsubject.EditValue as int?) ?? 0;
            grades.mark = view.spnMark.Value;
        }

        void get()
        {
            view.id = grades.Id;
            view.lkpyear.EditValue = grades.yearId;
            view.lkpterm.EditValue = grades.termId;
            view.lkpclass.EditValue = grades.classId;
            view.lkpexam.EditValue = grades.examId;
            view.lkpStudent.EditValue = grades.studId;
            view.lkpsubject.EditValue = grades.subjectId;
            view.spnMark.Value = grades.mark;
        }
        public void New()
        {
            grades = new Grades();
            int itemActive=0;
            int yearactive=0;
            if (TermOperation.ExistItem().Rows.Count>0)
                itemActive = Convert.ToInt32(TermOperation.ExistItem().Rows[0][0]);
            if (YearsOperation.ActiveYear().Rows.Count > 0)
                yearactive = Convert.ToInt32(YearsOperation.ActiveYear().Rows[0][0]); 
            
            view.lkpyear.EditValue = yearactive;
            view.lkpterm.EditValue = itemActive;
            //get();
        }

        public void Delete()
        {
            set();

            if (grades.Id == 0)
            {
                MessageBox.Show("لايوجد عنصر محدد لحذفه");
            }
            else
            {
                if (MessageBox.Show("تأكيد الحذف!!", "هل انت متاكد انك تريد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    GradesOperations.GradesDelete(grades);
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

                if (grades.Id == 0)
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
                RefreshData();

            }
        }

        void Add()
        {
            GradesOperations.AddGrades(grades);
            MessageBox.Show("تم الاظافة بنجاح");
        }

        void Update()
        {
            GradesOperations.UpdateGrades(grades);
            MessageBox.Show("تم التحديث بنجاح");

        }


        //التحقق من الحقول ليست فارغة
        bool IsDataValid()
        {
            int errors = 0;
            if (view.lkpyear.EditValue == null)
            {
                view.lkpyear.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            if (view.lkpterm.EditValue == null)
            {
                view.lkpterm.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            if (view.lkpclass.EditValue == null)
            {
                view.lkpclass.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            if (view.lkpexam.EditValue == null)
            {
                view.lkpexam.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            return errors == 0;

        }
        bool IsExist()
        {
            if (GradesOperations.ExistItem(grades).Rows.Count > 0)
            {
                MessageBox.Show("هذا العنصر مجود من قبل");
                return true;
            }
            else
                return false;
        }
       
    }
}
