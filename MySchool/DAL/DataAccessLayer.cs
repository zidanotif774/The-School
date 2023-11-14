using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace MySchool.DAL
{
    static class DataAccessLayer
    {

        public static SqlCommand sqlcm;
        //this methoud to get connection string from sql server
        private static SqlConnection getConnectionString()
        {
            //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //builder.DataSource = Properties.Settings.Default.ServerName;
            //builder.AttachDBFilename = Properties.Settings.Default.DBName;
            //builder.IntegratedSecurity = true;
            /*|DataDirectory|*/
            //Data Source =.\SQLEXPRESS; AttachDbFilename = "E:\المستندات\Visual Studio 2015\Projects\MySchool\MySchool\School.mdf"; Integrated Security = True; User Instance = True
            //return new SqlConnection(builder.ConnectionString);
            //return new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=\\E:\\المستندات\\VISUAL STUDIO 2015\\PROJECTS\\MySchool\\MySchool\\SCHOOL1.MDF;Integrated Security=True");
            return new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\المستندات\VISUAL STUDIO 2015\PROJECTS\MYSCHOOLTEST\MYSCHOOL\SCHOOL.MDF;Integrated Security=True;User Instance=True");
        }
        //دالة لجلب البيانات من قاعدة البيانات بناءا على الاجراء المخزن الممرر اليها 
        public static DataTable SelectData(string storedprocedure, Action methodm)
        {
            DataTable tbl = new DataTable();
            try
            {
                using (SqlConnection sqlconnection = getConnectionString())
                {
                    sqlcm = new SqlCommand(storedprocedure, sqlconnection);
                    sqlcm.CommandType = CommandType.StoredProcedure;
                    if (methodm != null)
                    {
                        methodm.Invoke();
                    }
                    SqlDataAdapter da = new SqlDataAdapter(sqlcm);
                    da.Fill(tbl);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            return tbl;
        }
        // دالة لتفيذ الاجراء المخزن الممرر اليها 
        public static int ExciutCommond(string storedprocedure, Action method)
        {
            int isExcuted = 0;
            using (SqlConnection sqlconnection = getConnectionString())
            {
                try
                {
                    sqlcm = new SqlCommand(storedprocedure, sqlconnection);
                    sqlcm.CommandType = CommandType.StoredProcedure;
                    if (method != null)
                        method.Invoke();
                    sqlconnection.Open();
                    isExcuted = sqlcm.ExecuteNonQuery();
                    sqlconnection.Close();
                    sqlcm.Dispose();
                }
                catch (Exception ex)
                {
                    sqlcm.Dispose();

                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
            return isExcuted;
        }

    }

}
