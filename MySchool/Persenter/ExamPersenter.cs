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
   public class ExamPersenter
    {

        Exam exam;
        IExamView view;
        public ExamPersenter(IExamView view)
        {
            this.view = view;
            view.gridview.RowClick += Gridview_RowClick;
            New();
            RefreshData();
            view.lkpTerm.Properties.DisplayMember = "Name";
            view.lkpTerm.Properties.ValueMember = "ID";
        }

        private void Gridview_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            New();
            view.id = Convert.ToInt32(view.gridview.GetFocusedRowCellValue("id"));
            view.txeExamName.Text = view.gridview.GetFocusedRowCellValue("exam_name").ToString();
            view.SpEdGradeMax.Value =Convert.ToInt32( view.gridview.GetFocusedRowCellValue("gradeMax"));
            view.lkpTerm.EditValue= Convert.ToInt32(view.gridview.GetFocusedRowCellValue("term"));
        }



        void RefreshData()
        {

            New();
            view.lkpTerm.Properties.DataSource = Master.Listterms;

            //view.lkpLevel.Properties.DataSource = LevelsOperations.GetAllLevel();
            //view.lkpLevel.Properties.DisplayMember = LevelsOperations.GetAllLevel().Columns[1].ToString();
            //view.lkpLevel.Properties.ValueMember = LevelsOperations.GetAllLevel().Columns[0].ToString();

            view.gridcontrol.DataSource = ExamOperation.GetAllExams();

        }
        void set()
        {
            exam.id = view.id;
            exam.ExamName = view.txeExamName.Text;
            exam.GradeMax =(int) view.SpEdGradeMax.Value ;
            exam.termid = (view.lkpTerm.EditValue as int?) ?? 0;
        }

        void get()
        {
            view.id = exam.id;
            view.txeExamName.Text = exam.ExamName;
            view.SpEdGradeMax.Value = exam.GradeMax;
            view.lkpTerm.EditValue = exam.termid;
        }
        public void New()
        {
            exam = new Exam();

            get();
        }

        public void Delete()
        {
            set();

            if (exam.id == 0)
            {
                MessageBox.Show("لايوجد عنصر محدد لحذفه");
            }
            else
            {
                if (MessageBox.Show("تأكيد الحذف!!", "هل انت متاكد انك تريد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    ExamOperation.ExamDataDelete(exam);
                    MessageBox.Show("تم الحذف بنجاح");
                    RefreshData();
                    New();
                }
            }
        }


        public void Save()
        {
            if (IsDataValid())
            {
                set();
              
                 if (exam.id == 0)
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
            ExamOperation.AddExamData(exam);
            MessageBox.Show("تم الاظافة بنجاح");
        }

        void Update()
        {
            ExamOperation.UpdateExamData(exam);
            MessageBox.Show("تم التحديث بنجاح");

        }

        //int AutoNum()
        //{
        //    return ClassesOperations.GetAllClass().Rows.Count + 1;
        //}

        //التحقق من الحقول ليست فارغة
        bool IsDataValid()
        {
            int errors = 0;
            if (view.txeExamName.Text.Trim() == string.Empty)
            {
                view.txeExamName.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            if (view.lkpTerm.Text.Trim() == string.Empty)
            {
                view.lkpTerm.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            if (view.SpEdGradeMax.Value ==0)
            {
                view.SpEdGradeMax.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            return errors == 0;

        }
        bool IsExist()
        {
            if (ExamOperation.ExistItem(exam).Rows.Count > 0)
            {
                MessageBox.Show("هذا العنصر مجود من قبل");
                return true;
            }
            else
                return false;
        }


    }
}
