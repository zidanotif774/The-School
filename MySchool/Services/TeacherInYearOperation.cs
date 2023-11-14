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
    public class TeacherInYearOperation
    {
        //اضافة قائمة المعلمين لعام دراسي
        public static void AddTeacherInYearData(TeacherInYear teachInyear)
        {
            foreach (var teach in teachInyear.teachers)
            {
                AddTeacherInYearData(teachInyear.userid, teach.Teach_id, teachInyear.yearid, teachInyear.termid);
            }
        }
        //اضافة معلم لعام دراسي
        public static int AddTeacherInYearData(int userid, int teachid, int yearid, int termid)
        {
            return DataAccessLayer.ExciutCommond("InsertTeacherInYear", () => TeacherInYearParametersIsert(userid, teachid, yearid, termid, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات  اضافة معلم لعام دراسي
        public static void TeacherInYearParametersIsert(int userid, int teachid, int yearid, int termid, SqlCommand command)
        {
            command.Parameters.Add("userid", SqlDbType.Int).Value = userid;
            command.Parameters.Add("teachid", SqlDbType.Int).Value = teachid;
            command.Parameters.Add("yearid", SqlDbType.Int).Value = yearid;
            command.Parameters.Add("termid", SqlDbType.Int).Value = termid;
        }


        //تحديث قائمة المعلمين لعام دراسي
        public static void UpdateTeacherInYearData(TeacherInYear teachInyear)
        {
            DeleteTeachersInYear(teachInyear.yearid);
            foreach (var teach in teachInyear.teachers)
            {
                AddTeacherInYearData(teachInyear.userid, teach.Teach_id, teachInyear.yearid, teachInyear.termid);
            }
        }

        //حذف بيانات المعلمين لعام دراسي
        public static int DeleteTeachersInYear(int yearid)
        {
            return DataAccessLayer.ExciutCommond("DeleteTeachersInYear", () => TeacherInYearDeleteParameterInsert(yearid, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات حذف بيانات المعلمين لعام دراسي
        public static void TeacherInYearDeleteParameterInsert(int yearid, SqlCommand command)
        {
            command.Parameters.Add("yearid", SqlDbType.Int).Value = yearid;
        }

       

        public static DataTable GetAllTeachersInYear()
        {
            return DataAccessLayer.SelectData("GetAllTeacherInYear", null);
        }
        public static List<TeacherInYear> GetListTeachersInYear()
        {
            List<TeacherInYear> risultList = new List<TeacherInYear>();
            DataTable dt = DataAccessLayer.SelectData("GetAllTeacherInYear", null);
            Dictionary<string, List<Teacher>> diction = new Dictionary<string, List<Teacher>>();
            foreach (DataRow row in dt.Rows)
            {
                if (row != null)
                {
                    string value = row["year_id"].ToString();
                    if (diction.ContainsKey(value))
                    {
                        diction[value].Add(new Teacher { Teach_id = Convert.ToInt32(row["teach_id"]), Teach_name = row["teach_name_"].ToString() });
                    }
                    else
                    {
                        diction.Add(value, new List<Models.Teacher>() { new Teacher() { Teach_id = Convert.ToInt32(row["teach_id"]), Teach_name = row["teach_name_"].ToString() } });
                        risultList.Add(new TeacherInYear { id = Convert.ToInt32(row["id"]), yearid = Convert.ToInt32(value)});
                    }

                }

            }
            foreach (KeyValuePair<string, List<Teacher>> pair in diction)
            {
                int yearid = Convert.ToInt32(pair.Key);
                risultList.Where(x => x.yearid == yearid).Single().teachers = pair.Value;
            }
            return risultList;
        }

    }
}
