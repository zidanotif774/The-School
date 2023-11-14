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
    class TermInYearOperation
    {

        //اضافة قائمة توزيع الفصول الدراسية على الاعوام
        public static void AddTermInYearData(TermInYear terminyear)
        {
            foreach (var trm in terminyear.TermList)
            {
                AddTermInYearData(terminyear.year_id, trm.id);
            }
        }
        //اضافة توزيع الفصول الدراسية على الاعوام
        public static int AddTermInYearData(int yearid, int termid)
        {
            return DataAccessLayer.ExciutCommond("AddTermInYear", () => AddTermInYearDataParametersIsert(yearid, termid, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات توزيع الفصول الدراسية على الاعوام 
        public static void AddTermInYearDataParametersIsert(int yearid, int termid, SqlCommand command)
        {
            command.Parameters.Add("yearid", SqlDbType.Int).Value = yearid;
            command.Parameters.Add("termid", SqlDbType.Int).Value = termid;
        }


        //تحديث قائمة توزيع الفصول الدراسية على الاعوام
        public static void UpdateTermInYearData(TermInYear terminyear)
        {
            termInYearDelete(terminyear.year_id);
            foreach (var trm in terminyear.TermList)
            {
                AddTermInYearData(terminyear.year_id, trm.id);
            }
        }





        public static void termInYearDelete(TermInYear terminyear)
        {
            termInYearDelete(terminyear.year_id);
        }
        //حذف بيانات توزيع المواد على الصفوف
        public static int termInYearDelete(int yearid)
        {
            return DataAccessLayer.ExciutCommond("DeleteTermInYear", () => SubClassDeleteParameterInsert(yearid, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات حذف توزيع المواد على الصفوف
        public static void SubClassDeleteParameterInsert(int yearid, SqlCommand command)
        {
            command.Parameters.Add("yearid", SqlDbType.Int).Value = yearid;
        }



      

        public static DataTable GetAllTermsInYear()
        {
            return DataAccessLayer.SelectData("GetAllTermInYear", null);
        }
        public static List<TermInYear> GetListTermsInYear()
        {
            List<TermInYear> risultList = new List<TermInYear>();
            DataTable dt = DataAccessLayer.SelectData("GetAllTermInYear", null);
            Dictionary<string, List<Term>> diction = new Dictionary<string, List<Term>>();
            foreach (DataRow row in dt.Rows)
            {
                if (row != null)
                {
                    string value = row["year_id"].ToString();
                    if (diction.ContainsKey(value))
                    {
                        diction[value].Add(new Models.Term { id = Convert.ToInt32(row["term_id"]), Term_name = row["term_name"].ToString() });
                    }
                    else
                    {
                        diction.Add(value, new List<Models.Term>() { new Term() { id = Convert.ToInt32(row["term_id"]), Term_name = row["term_name"].ToString() } });
                        risultList.Add(new TermInYear { id = Convert.ToInt32(row["id"]), year_id = Convert.ToInt32(value) });
                    }

                }

            }
            foreach (KeyValuePair<string, List<Term>> pair in diction)
            {
                int yearid = Convert.ToInt32(pair.Key);
                risultList.Where(x => x.year_id == yearid).Single().TermList = pair.Value;
            }
            


            return risultList;
        }

       
    }
}
