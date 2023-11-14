using MySchool.DAL;
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
  public  class GradesReportOperation
    {
        //  جلب درجات جميع الطلاب  في فصل دراسي في صف دراسي
        public static DataTable GetAllGrades(int yearid, int termid, int classid)
        {
            DataTable dt = DataAccessLayer.SelectData("GetDataToGradeReportF1", () => GetAllGradesParameterInsert(
                yearid, termid, classid, DataAccessLayer.sqlcm));
            return dt;
        }
        //  اضافة باراميترات جلب درجات جميع الطلاب  في فصل دراسي في صف دراسي 
        static void GetAllGradesParameterInsert(int yearid, int termid, int classid, SqlCommand command)
        {
            command.Parameters.Add("yearid", SqlDbType.Int).Value = yearid;
            command.Parameters.Add("termid", SqlDbType.Int).Value = termid;
            command.Parameters.Add("classid", SqlDbType.Int).Value = classid;

        }
        // جلب درجات جميع الطلاب  في عام دراسي في صف دراسي
        public static DataTable GetAllGrades(int yearid, int classid)
        {
            DataTable dt = DataAccessLayer.SelectData("GetDataToGradeReportF2", () => GetAllGradesParameterInsert(
                yearid, classid, DataAccessLayer.sqlcm));
            return dt;
        }
        //  اضافة باراميترات جلب درجات جميع الطلاب  في عام دراسي في صف دراسي
        static void GetAllGradesParameterInsert(int yearid, int classid, SqlCommand command)
        {
            command.Parameters.Add("yearid", SqlDbType.Int).Value = yearid;
            command.Parameters.Add("classid", SqlDbType.Int).Value = classid;

        }
    }
   
}
