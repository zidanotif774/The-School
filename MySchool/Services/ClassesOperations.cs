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
    class ClassesOperations
    {
        //اضافة بيانات صف دراسي
        public static int AddClassData(int lvlid, string name)
        {
            return DataAccessLayer.ExciutCommond("Insertclass", () => AddClassDataParametersIsert(lvlid, name, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات اضافة بيانات صف دراسي
        public static void AddClassDataParametersIsert(int lvlid, string name, SqlCommand command)
        {
            command.Parameters.Add("lvl_id", SqlDbType.Int).Value = lvlid;
            command.Parameters.Add("cls_name", SqlDbType.Text).Value = name;
        }



        //تحديث بيانات صف دراسي
        public static int UpdateClassData(int lvlid, int id, string name)
        {
            return DataAccessLayer.ExciutCommond("UpdateClassStudy", () => UpdateClassDataParametersIsert(lvlid, id, name, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات تحديث بيانات صف دراسي
        public static void UpdateClassDataParametersIsert(int lvlid, int id, string name, SqlCommand command)
        {
            command.Parameters.Add("lvl_id", SqlDbType.Int).Value = lvlid;
            command.Parameters.Add("cls_id", SqlDbType.Int).Value = id;
            command.Parameters.Add("cls_name", SqlDbType.Text).Value = name;
        }


        //حذف بيانات صف دراسي
        public static int ClassDataDelete(int id)
        {
            return DataAccessLayer.ExciutCommond("DeleteClass", () => ClassDataDeleteParameterInsert(id, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات حذف صف دراسي
        public static void ClassDataDeleteParameterInsert(int id, SqlCommand command)
        {
            command.Parameters.Add("cls_id", SqlDbType.Int).Value = id;
        }


        //التحقق من وجود الصف في المرحلة الدراسية
        public static DataTable ExistItem(string name, int lvlid)
        {
            return DataAccessLayer.SelectData("ClassExist", () => ExistItemParameterInsert(name, lvlid, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات التحقق من وجود الصف  في المرحلة الدراسية
        public static void ExistItemParameterInsert(string name, int lvlid, SqlCommand command)
        {
            command.Parameters.Add("cls_name", SqlDbType.Text).Value = name;
            command.Parameters.Add("lvl_id", SqlDbType.Int).Value = lvlid;
        }

        public static DataTable GetAllClassAndLevel()
        {
            DataTable dt = DataAccessLayer.SelectData("SelectAllClasses", null);
            return dt;
        }
        public static DataTable GetAllClass()
        {
            DataTable dt = DataAccessLayer.SelectData("GetAllClasses", null);
            return dt;
        }
       

    }
}
