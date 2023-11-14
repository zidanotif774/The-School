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
    class SubjectOperation
    {
        //اضافة  المادة الدراسية
        public static int AddSubject(string name)
        {
            return DataAccessLayer.ExciutCommond("InsertSubject", () => SubjectDataParametersIsert(name, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات اضافة  المادة الدراسية 
        private static void SubjectDataParametersIsert(string name, SqlCommand command)
        {
            command.Parameters.Add("subname", SqlDbType.NVarChar).Value = name;
        }



        //تحديث بيانات المادة الدراسية
        public static int UpdateSubjectData(int id, string name)
        {
            return DataAccessLayer.ExciutCommond("UpdateSubject", () => UpdateSubjectDataParametersIsert(id, name, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات تحديث بيانات المادة الدراسية
        private static void UpdateSubjectDataParametersIsert(int id, string name, SqlCommand command)
        {
            command.Parameters.Add("subid", SqlDbType.Int).Value = id;
            command.Parameters.Add("subname", SqlDbType.Text).Value = name;
        }


        //حذف بيانات مادة دراسية
        public static int SubjectDelete(int id)
        {
            return DataAccessLayer.ExciutCommond("DeleteSubject", () => SubjectDeletetParameterInsert(id, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات حذف توزيع المواد على المعلمين
        private static void SubjectDeletetParameterInsert(int id, SqlCommand command)
        {
            command.Parameters.Add("subid", SqlDbType.Int).Value = id;
        }


        //التحقق من وجودالمادة الدراسية
        public static DataTable ExistItem(string name)
        {
            return DataAccessLayer.SelectData("SubjectIsExist", () => ExistItemParameterInsert(name, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات التحقق من وجودالمادة الدراسية
        private static void ExistItemParameterInsert(string name, SqlCommand command)
        {
            command.Parameters.Add("subid", SqlDbType.Text).Value = name;
        }

        public static List<Subject> GetAllSubjects()
        {
            DataTable dt = DataAccessLayer.SelectData("SelecteAllSubject", null);
            List<Subject> sublist = new List<Models.Subject>();
            foreach (DataRow row in dt.Rows)
            {
                if (row != null)
                {
                    sublist.Add(new Subject()
                    {
                        id = Convert.ToInt32(row["sub_id"]),
                        name = row["sub_name"].ToString()
                       
                    });
                }
            }
            return sublist;
            //return dt;
        }
        
    }
}
