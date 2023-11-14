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
    public class TermOperation 
    {

        //اضافة بيانات الفصل الدراسي
        public static int AddTermData(Term term)
        {
            return DataAccessLayer.ExciutCommond("AddTerm", () => AddTermDataParametersIsert(term.id, term.Term_name, term.isActive, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات الفصل الدراسي
        public static void AddTermDataParametersIsert(int id, string name, bool isActive, SqlCommand command)
        {
            try
            {
                command.Parameters.Add("id", SqlDbType.Text).Value = name;
                command.Parameters.Add("termName", SqlDbType.Text).Value = name;
                command.Parameters.Add("Active", SqlDbType.Bit).Value = isActive;
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }



        //تحديث بيانات الفصل الدراسي
        public static void UpdateTermData(Term term)
        {
            int oldid = 0;
            if (ExistItem() != null)
            {
                oldid = Convert.ToInt32(ExistItem().Rows[0][0]);
            }
            /*  return*/
            DataAccessLayer.ExciutCommond("UpdateTerm", () => UpdateTermDataParametersIsert(term.id, term.isActive, DataAccessLayer.sqlcm));
            DataAccessLayer.ExciutCommond("UpdateTerm", () => UpdateTermDataParametersIsert(oldid, !term.isActive, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات تحديث بيانات الفصل الدراسي
        public static void UpdateTermDataParametersIsert(int id, bool isActive, SqlCommand command)
        {
            try
            {
                command.Parameters.Add("termid", SqlDbType.Int).Value = id;
                command.Parameters.Add("Active", SqlDbType.Bit).Value = isActive;
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }


        //حذف بيانات الفصل الدراسي
        public static int TermDataDelete(Term term)
        {
            return DataAccessLayer.ExciutCommond("DeleteTerm", () => TermDeletParameterInsert(term.id, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات حذف الفصل الدراسي
        public static void TermDeletParameterInsert(int id, SqlCommand command)
        {
            command.Parameters.Add("termid", SqlDbType.Int).Value = id;
        }

        //التحقق من وجود الفصل الدراسي
        public static DataTable ExistItem(/*Term term*/)
        {
            return DataAccessLayer.SelectData("TermExist", () => ExistItemParameterInsert(true, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات التحقق من وجود الفصل الدراسي
        public static void ExistItemParameterInsert(bool isActive, SqlCommand command)
        {
            command.Parameters.Add("Active", SqlDbType.Bit).Value = isActive;
        }


        public static DataTable GetAllterms()
        {
            DataTable dt = DataAccessLayer.SelectData("GetAllTerms", null);
            return dt;
        }

       
    } 
}
