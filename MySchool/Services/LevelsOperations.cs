using MySchool.DAL;
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
    class LevelsOperations
    {
        //اضافة بيانات المرحلة الدراسية
        public static int AddLevelData(string name)
        {
            return DataAccessLayer.ExciutCommond("Insertlevel", () => AddLevelDataParametersIsert(name, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات اضافة بيانات المرحلة الدراسية
        public static void AddLevelDataParametersIsert(string name, SqlCommand command)
        {
            command.Parameters.Add("lvl_name", SqlDbType.Text).Value = name;
        }



        //تحديث بيانات المرحلة الدراسية
        public static int UpdateLevelData(int id, string name)
        {
            return DataAccessLayer.ExciutCommond("UpdateLevelStudy", () => UpdateLevelDataParametersIsert(id, name, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات تحديث بيانات المرحلة الدراسية
        public static void UpdateLevelDataParametersIsert(int id, string name, SqlCommand command)
        {
            command.Parameters.Add("lvlid", SqlDbType.Int).Value = id;
            command.Parameters.Add("lvlname", SqlDbType.Text).Value = name;
        }


        //حذف بيانات مرحلة
        public static int LevelDataDelete(int id)
        {
            return DataAccessLayer.ExciutCommond("DeleteLevel", () => LevelDataDeleteParameterInsert(id, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات حذف بيانات مرحلة
        public static void LevelDataDeleteParameterInsert(int id, SqlCommand command)
        {
            command.Parameters.Add("lvlid", SqlDbType.Int).Value = id;
        }

        //التحقق من وجود المرحلة الدراسية
        public static DataTable ExistItem(string name)
        {
            return DataAccessLayer.SelectData("LevelExist", () => ExistItemParameterInsert(name, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات التحقق من وجود المرحلة الدراسية
        public static void ExistItemParameterInsert(string name, SqlCommand command)
        {
            command.Parameters.Add("lvlname", SqlDbType.Text).Value = name;
        }

        public static DataTable GetAllLevel()
        {
            DataTable dt = DataAccessLayer.SelectData("selectAllLevel", null);
            return dt;
        }

       
    }
}
