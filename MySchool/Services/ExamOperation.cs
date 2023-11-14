using MySchool.DAL;
using MySchool.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Services
{
  public  class ExamOperation
    {
        //اضافة بيانات امتحان
        public static int AddExamData(Exam exam)
        {
            return DataAccessLayer.ExciutCommond("AddExam", () => AddExamDataParametersIsert(exam.ExamName, exam.GradeMax, exam.termid, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات امتحان
        public static void AddExamDataParametersIsert(string name, int grademax, int termid, SqlCommand command)
        {
            try
            {
                command.Parameters.Add("examname", SqlDbType.Text).Value = name;
                command.Parameters.Add("grademax", SqlDbType.Int).Value = grademax;
                command.Parameters.Add("termid", SqlDbType.Int).Value = termid;
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }



        //تحديث بيانات امتحان
        public static int UpdateExamData(Exam exam)
        {
            return DataAccessLayer.ExciutCommond("UpdateExam", () => UpdateExamDataParametersIsert(exam.id, exam.ExamName, exam.GradeMax, exam.termid, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات تحديث بيانات امتحان
        public static void UpdateExamDataParametersIsert(int id, string name, int grademax, int termid, SqlCommand command)
        {
            try
            {
                command.Parameters.Add("Id", SqlDbType.Int).Value = id;
                command.Parameters.Add("examname", SqlDbType.Text).Value = name;
                command.Parameters.Add("grademax", SqlDbType.Int).Value = grademax;
                command.Parameters.Add("termid", SqlDbType.Int).Value = termid;

            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }


        //حذف بيانات امتحان
        public static int ExamDataDelete(Exam exam)
        {
            return DataAccessLayer.ExciutCommond("DeleteExam", () => ExamDeletParameterInsert(exam.id, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات حذف امتحان
        public static void ExamDeletParameterInsert(int id, SqlCommand command)
        {
            command.Parameters.Add("Id", SqlDbType.Int).Value = id;
        }

        //التحقق من وجود امتحان
        public static DataTable ExistItem(Exam exam)
        {
            return DataAccessLayer.SelectData("ExamExist", () => ExistItemParameterInsert(exam.ExamName, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات التحقق من وجود امتحان
        public static void ExistItemParameterInsert(string name, SqlCommand command)
        {
            command.Parameters.Add("examname", SqlDbType.Text).Value = name;
        }

        // جلب جميع الامتحانات
        public static DataTable GetAllExams()
        {
            DataTable dt = DataAccessLayer.SelectData("GetAllExams", null);
            return dt;
        }
        // جلب جميع الامتحانات في فصل دراسي معين
        public static DataTable GetExamsWithTerm(int termid)
        {
            DataTable dt = DataAccessLayer.SelectData("GetExamsWithTerm", () => GetExamsWithTermParameterInsert(termid, DataAccessLayer.sqlcm));
            return dt;
        }
        // اضافة بارامترات جلب جميع الامتحانات في فصل دراسي معين
        public static void GetExamsWithTermParameterInsert(int termid, SqlCommand command)
        {
            command.Parameters.Add("termid", SqlDbType.Int).Value = termid;
        }
    }
  
}
