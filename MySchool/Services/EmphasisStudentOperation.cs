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
  public class EmphasisStudentOperation
    {
        //اضافة بيانات تأكيد الطالب في صف دراسي في عام دراسي
        public static int AddEmphasisStudent(EmphasisStudent emphStud)
        {
            return DataAccessLayer.ExciutCommond("AddEmphasisStudent", () => EmphasisStudentParametersIsert(
                emphStud.userId, emphStud.Studentid, emphStud.ClassId, emphStud.YearId, emphStud.StatId, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات تأكيد الطالب في صف دراسي في عام دراسي
        public static void EmphasisStudentParametersIsert(int userid, int studid, int classid, int yearid, int statid, SqlCommand command)
        {
            try
            {
                command.Parameters.Add("userid", SqlDbType.Int).Value = userid;
                command.Parameters.Add("studid", SqlDbType.Int).Value = studid;
                command.Parameters.Add("statid", SqlDbType.Int).Value = statid;
                command.Parameters.Add("yearid", SqlDbType.Int).Value = yearid;
                command.Parameters.Add("classid", SqlDbType.Int).Value = classid;
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }



        //تحديث بيانات تأكيد الطالب في صف دراسي في عام دراسي
        public static int UpdateEmphasisStudent(EmphasisStudent emphStud)
        {
            return DataAccessLayer.ExciutCommond("UpdateEmphasisStudent", () => EmphasisStudentUpdateParametersIsert(
                emphStud.Id, emphStud.userId, emphStud.Studentid, emphStud.ClassId, emphStud.YearId, emphStud.StatId, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات تحديث بيانات تأكيد الطالب في صف دراسي في عام دراسي
        public static void EmphasisStudentUpdateParametersIsert(int id, int userid, int studid, int classid, int yearid, int statid, SqlCommand command)
        {
            try
            {
                command.Parameters.Add("Id", SqlDbType.Int).Value = id;
                command.Parameters.Add("userid", SqlDbType.Int).Value = userid;
                command.Parameters.Add("studid", SqlDbType.Int).Value = studid;
                command.Parameters.Add("classid", SqlDbType.Int).Value = classid;
                command.Parameters.Add("yearid", SqlDbType.Int).Value = yearid;
                command.Parameters.Add("statid", SqlDbType.Int).Value = statid;
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }


        //حذف بيانات تأكيد الطالب في صف دراسي في عام دراسي
        public static int DeleteEmphasisStudentData(int id)
        {
            return DataAccessLayer.ExciutCommond("DeleteEmphasisStudentData", () => EmphasisStudentDeletParameterInsert(id, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات حذف تأكيد الطالب في صف دراسي في عام دراسي
        public static void EmphasisStudentDeletParameterInsert(int id, SqlCommand command)
        {
            command.Parameters.Add("Id", SqlDbType.Int).Value = id;
        }

        //التحقق من وجود الطالب في العام الدراسي
        public static DataTable ExistItem(int yearid, int sutdid)
        {
            return DataAccessLayer.SelectData("EmphasisStudentExist", () => ExistItemParameterInsert(yearid, sutdid, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات التحقق من وجود الطالب في العام الدراسي
        public static void ExistItemParameterInsert(int yearid, int sutdid, SqlCommand command)
        {
            command.Parameters.Add("yearId", SqlDbType.Int).Value = yearid;
            command.Parameters.Add("studId", SqlDbType.Int).Value = sutdid;
        }

        //جلب طلاب الصف المعين في العام الدراسي المعين
        public static DataTable GetAllEmphasisStudent(int yearid,int classid)
        {
            DataTable dt = DataAccessLayer.SelectData("GetAllEmphasisStudent", () => GetAllEmphasisStudentParameterInsert(yearid, classid, DataAccessLayer.sqlcm));
            return dt;
        }
        //إضافة بارامترات جلب طلاب الصف المعين في العام الدراسي المعين
        public static void GetAllEmphasisStudentParameterInsert(int yearid, int classid,  SqlCommand command)
        {
            command.Parameters.Add("yearId", SqlDbType.Int).Value = yearid;
            command.Parameters.Add("classid", SqlDbType.Int).Value = classid;
        }
       

    }
}
