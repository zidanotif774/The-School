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
    class StudentsOperations
    {
        //اضافة طالب
        public static int AddStudent(string name, DateTime bodate, int sex, string titel)
        {
            return DataAccessLayer.ExciutCommond("InsertStudent", () => AddStudentParametersIsert(name, bodate, sex, titel, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات ضافة طالب 
        public static void AddStudentParametersIsert(string name, DateTime bodate, int sex, string titel, SqlCommand command)
        {
            command.Parameters.Add("st_name", SqlDbType.Text).Value = name;
            command.Parameters.Add("bodm", SqlDbType.Date).Value = bodate;
            command.Parameters.Add("sx", SqlDbType.Int).Value = sex;
            command.Parameters.Add("titl", SqlDbType.Text).Value = titel;
        }




        //تحديث بيانات طالب
        public static int UpdateStudent(int id, string name, DateTime bodate, int sex, string titel)
        {
            return DataAccessLayer.ExciutCommond("UpdateStudent", () => UpdateStudentParametersIsert(id, name, bodate, sex, titel, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات تحديث بيانات طالب 
        public static void UpdateStudentParametersIsert(int id, string name, DateTime bodate, int sex, string titel, SqlCommand command)
        {
            command.Parameters.Add("studId", SqlDbType.Int).Value = id;
            command.Parameters.Add("studname", SqlDbType.Text).Value = name;
            command.Parameters.Add("bodm", SqlDbType.Date).Value = bodate;
            command.Parameters.Add("sx", SqlDbType.Int).Value = sex;
            command.Parameters.Add("titl", SqlDbType.Text).Value = titel;

        }


        //حذف بيانات طالب
        public static int StudentDelete(int id)
        {
            return DataAccessLayer.ExciutCommond("DeleteStudent", () => StudentDeleteParameterInsert(id, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات حذف بيانات طالب
        public static void StudentDeleteParameterInsert(int id, SqlCommand command)
        {
            command.Parameters.Add("studid", SqlDbType.Int).Value = id;
        }


        //جلب جميع الطلاب
        public static DataTable GetAllStudents()
        {
            DataTable dt = DataAccessLayer.SelectData("GetAllStudent", null);
            return dt;
        }
        // جلب جميع طلاب الصف في العام
        public static DataTable GetAllStudents(int classid, int yearid)
        {
            DataTable dt = DataAccessLayer.SelectData("GetAllStudentwithYearAndClass", () => GetAllStudentsParameterInsert(classid, yearid, DataAccessLayer.sqlcm));
            return dt;
        }
        //اضافة بارمترات جلب جميع طلاب الصف في العام
        public static void GetAllStudentsParameterInsert(int classid, int yearid, SqlCommand command)
        {
            command.Parameters.Add("classid", SqlDbType.Int).Value = classid;
            command.Parameters.Add("yearid", SqlDbType.Int).Value = yearid;
        }
        //التحقق من وجود الطالب 
        public static DataTable ExistItem(string name)
        {
            return DataAccessLayer.SelectData("StudentIsExist", () => ExistItemParameterInsert(name, DataAccessLayer.sqlcm));
        }

        //اضافة بارمترات التحقق من وجود الطالب
        static bool result;
        public static void ExistItemParameterInsert(string name, SqlCommand command)
        {
            command.Parameters.Add("stud_name", SqlDbType.Text).Value = name;
        }
       
    }
}
