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

namespace MySchool.BSL
{
    class GradesOperations 
    {
        //اضافة درجات  طالب
        public static int AddGrades(Grades grades)
        {
            return DataAccessLayer.ExciutCommond("AddGrade", () => AddGradesParametersIsert(
                grades.yearId, grades.termId, grades.classId, grades.studId, grades.examId, grades.subjectId, grades.mark, DataAccessLayer.sqlcm)
                );
        }
        //اضافة بارامترات اضافة درجات طالب 
        public static void AddGradesParametersIsert(int yearid, int termid, int classid, int studid, int examid, int subid, decimal mark, SqlCommand command)
        {
            command.Parameters.Add("yearid", SqlDbType.Int).Value = yearid;
            command.Parameters.Add("termid", SqlDbType.Int).Value = termid;
            command.Parameters.Add("classid", SqlDbType.Int).Value = classid;
            command.Parameters.Add("studid", SqlDbType.Int).Value = studid;
            command.Parameters.Add("examid", SqlDbType.Int).Value = examid;
            command.Parameters.Add("subid", SqlDbType.Int).Value = subid;
            command.Parameters.Add("mrk", SqlDbType.Decimal).Value = mark;
        }




        //تحديث بيانات درجات طالب
        public static int UpdateGrades(Grades grades)
        {
            return DataAccessLayer.ExciutCommond("UpdateGrade", () => UpdateGradesParametersIsert(
                grades.Id, grades.yearId, grades.termId, grades.classId, grades.studId, grades.examId, grades.subjectId, grades.mark, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات تحديث بيانات درجات طالب 
        public static void UpdateGradesParametersIsert(int id, int yearid, int termid, int classid, int studid, int examid, int subid, decimal mark, SqlCommand command)
        {
            command.Parameters.Add("id", SqlDbType.Int).Value = id;
            command.Parameters.Add("yearid", SqlDbType.Int).Value = yearid;
            command.Parameters.Add("termid", SqlDbType.Int).Value = termid;
            command.Parameters.Add("classid", SqlDbType.Int).Value = classid;
            command.Parameters.Add("studid", SqlDbType.Int).Value = studid;
            command.Parameters.Add("examid", SqlDbType.Int).Value = examid;
            command.Parameters.Add("subid", SqlDbType.Int).Value = subid;
            command.Parameters.Add("mrk", SqlDbType.Decimal).Value = mark;

        }


        //حذف بيانات درجات طالب
        public static int GradesDelete(Grades grades)
        {
            return DataAccessLayer.ExciutCommond("DeleteGrade", () => GradesDeleteParameterInsert(grades.Id, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات حذف بيانات درجات طالب
        public static void GradesDeleteParameterInsert(int id, SqlCommand command)
        {
            command.Parameters.Add("id", SqlDbType.Int).Value = id;
        }



        //جلب درجة طالب 
        public static DataTable GetAllGrades(int yearid, int termid, int classid, int examid, int subid)
        {
            DataTable dt = DataAccessLayer.SelectData("GetGradesAllStudentInYearInClassInTermInExam", () => GetAllGradesParameterInsert(
                yearid, termid, classid, examid, subid, DataAccessLayer.sqlcm));
            return dt;
        }
        //اضافة بارمترات جلب درجة طالب 
        public static void GetAllGradesParameterInsert(int yearid, int termid, int classid, int examid, int subid, SqlCommand command)
        {
            command.Parameters.Add("yearid", SqlDbType.Int).Value = yearid;
            command.Parameters.Add("termid", SqlDbType.Int).Value = termid;
            command.Parameters.Add("classid", SqlDbType.Int).Value = classid;
            command.Parameters.Add("examid", SqlDbType.Int).Value = examid;
            command.Parameters.Add("subid", SqlDbType.Int).Value = subid;
        }
        //التحقق من وجود درجة الطالب
        public static DataTable ExistItem(Grades grades)
        {
            return DataAccessLayer.SelectData("GradeIsExist", () => ExistItemParameterInsert(
                grades.yearId, grades.termId, grades.classId, grades.studId, grades.examId, grades.subjectId, DataAccessLayer.sqlcm));
        }

        //اضافة بارمترات التحقق من وجود درجة الطالب
        public static void ExistItemParameterInsert(int yearid, int termid, int classid, int studid, int examid, int subid, SqlCommand command)
        {
            command.Parameters.Add("yearid", SqlDbType.Int).Value = yearid;
            command.Parameters.Add("termid", SqlDbType.Int).Value = termid;
            command.Parameters.Add("classid", SqlDbType.Int).Value = classid;
            command.Parameters.Add("studid", SqlDbType.Int).Value = studid;
            command.Parameters.Add("examid", SqlDbType.Int).Value = examid;
            command.Parameters.Add("subid", SqlDbType.Int).Value = subid;
        }

    }
    
}
