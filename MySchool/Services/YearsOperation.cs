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
    public class YearsOperation
    {

        //اضافة بيانات العام الدراسي
        public static int AddYearData(string name, bool isActive)
        {
            int oldid = 0; string yearname = "";

            if (ActiveYear().Rows.Count > 0)
            {
                oldid = Convert.ToInt32(ActiveYear().Rows[0][0]);
                yearname = ActiveYear().Rows[0][1].ToString();
                DataAccessLayer.ExciutCommond("UpdateYearStudy", () => YearUpdateParametersIsert(oldid, yearname, !isActive, DataAccessLayer.sqlcm));

            }
            return DataAccessLayer.ExciutCommond("addyearstud", () => YearParametersIsert(name, isActive, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات العام الدراسي
        private static void YearParametersIsert(string name, bool isActive, SqlCommand command)
        {
            try
            {
                command.Parameters.Add("yr_name", SqlDbType.Text).Value = name;
                command.Parameters.Add("yr_Active", SqlDbType.Bit).Value = isActive;
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }



        //تحديث بيانات العام الدراسي
        public static void UpdateYearData(int id, string name, bool isActive)
        {
            int oldid = 0; string yearname = "";

            if (ActiveYear() .Rows.Count>0)
            {
                oldid = Convert.ToInt32(ActiveYear().Rows[0][0]);
                yearname = ActiveYear().Rows[0][1].ToString();

            }

            DataAccessLayer.ExciutCommond("UpdateYearStudy", () => YearUpdateParametersIsert(id, name, isActive, DataAccessLayer.sqlcm));
            DataAccessLayer.ExciutCommond("UpdateYearStudy", () => YearUpdateParametersIsert(oldid, yearname, !isActive, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات تحديث بيانات العام الدراسي
        private static void YearUpdateParametersIsert(int id, string name, bool isActive, SqlCommand command)
        {
            try
            {
                command.Parameters.Add("y_id", SqlDbType.Int).Value = id;
                command.Parameters.Add("yr_name", SqlDbType.Text).Value = name;
                command.Parameters.Add("yr_Active", SqlDbType.Bit).Value = isActive;
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }


        //حذف بيانات العام الدراسي
        public static int YearDataDelete(int id)
        {
            return DataAccessLayer.ExciutCommond("DeleteYear", () => YearDeletParameterInsert(id, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات حذف العام الدراسي
        private static void YearDeletParameterInsert(int id, SqlCommand command)
        {
            command.Parameters.Add("id", SqlDbType.Int).Value = id;
        }

        //التحقق من وجود العام الدراسي
        public static DataTable ExistItem(string name)
        {
            return DataAccessLayer.SelectData("YearExist", () => ExistItemParameterInsert(name, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات التحقق من وجود العام الدراسي
        private static void ExistItemParameterInsert(string name, SqlCommand command)
        {
            command.Parameters.Add("y_name", SqlDbType.Text).Value = name;
        }


        public static DataTable GetAllyears()
        {
            DataTable dt = DataAccessLayer.SelectData("selectallyear", null);
            return dt;
        }
        public static DataTable ActiveYear()
        {
            return DataAccessLayer.SelectData("GetActiveYear", () => ActiveYearParameterInsert(true, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات التحقق من وجود العام الدراسي
        private static void ActiveYearParameterInsert(bool isActive, SqlCommand command)
        {
            command.Parameters.Add("Active", SqlDbType.Bit).Value = isActive;

        }

       
    } 
}
