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
    class TeacherOperation
    {

        //اضافة معلم
        public static int AddTeacher(bool isactive, string name, int sex, string major, string phon, string cardnum)
        {
            return DataAccessLayer.ExciutCommond("InsertTeacher", () => TeacherDataParametersIsert(isactive, name, sex, major, phon, cardnum, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات اضافة  اضافة معلم 
        public static void TeacherDataParametersIsert(bool isactive, string name, int sex, string major, string phon, string cardnum, SqlCommand command)
        {
            command.Parameters.Add("Teach_name", SqlDbType.Text).Value = name;
            command.Parameters.Add("Teach_active", SqlDbType.Bit).Value = isactive;
            command.Parameters.Add("Teach_sex",SqlDbType.Int).Value = sex;
            command.Parameters.Add("Teach_major", SqlDbType.Text).Value = major;
            command.Parameters.Add("Phon_Num", SqlDbType.Text).Value = phon;
            command.Parameters.Add("Card_Num", SqlDbType.Text).Value = cardnum;
        }




        //تحديث بيانات معلم
        public static int UpdateDataTeacher(int id, bool isactive, string name, int sex, string major, string phon, string cardnum)
        {
            return DataAccessLayer.ExciutCommond("UpdateTeacher", () => UpdateDataTeacherParametersIsert(id, isactive, name, sex, major, phon, cardnum, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات تحديث بيانات معلم 
        public static void UpdateDataTeacherParametersIsert(int id, bool isactive, string name, int sex, string major, string phon, string cardnum, SqlCommand command)
        {
            command.Parameters.Add("Teach_id", SqlDbType.Int).Value = id;
            command.Parameters.Add("Teach_name", SqlDbType.Text).Value = name;
            command.Parameters.Add("Teach_active", SqlDbType.Bit).Value = isactive;
            command.Parameters.Add("Teach_sex", SqlDbType.Int).Value = sex;
            command.Parameters.Add("Teach_major", SqlDbType.Text).Value = major;
            command.Parameters.Add("Phon_Num", SqlDbType.Text).Value = phon;
            command.Parameters.Add("Card_Num", SqlDbType.Text).Value = cardnum;
        }


        //حذف بيانات معلم
        public static int TeacherDelete(int id)
        {
            return DataAccessLayer.ExciutCommond("DeleteTeacher", () => TeacherDeleteParameterInsert(id, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات حذف بيانات معلم
        public static void TeacherDeleteParameterInsert(int id, SqlCommand command)
        {
            command.Parameters.Add("Teach_id", SqlDbType.Int).Value = id;
        }

        //التحقق من وجود المعلم في هذا العام الدراسي
        public static DataTable ExistItem(string name)
        {
            return DataAccessLayer.SelectData("TeacherExistInYear", () => ExistItemParameterInsert(name, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات التحقق من وجود المعلم في هذا العام الدراسي
        public static void ExistItemParameterInsert(string name, SqlCommand command)
        {
            command.Parameters.Add("teach_name", SqlDbType.Text).Value = name;
        }

        public static DataTable GetAllTeachers()
        {
            DataTable dt = DataAccessLayer.SelectData("GetAllTeacher", null);
            return dt;
        }
       
    }
}
