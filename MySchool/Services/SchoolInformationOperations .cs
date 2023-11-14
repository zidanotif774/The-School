using MySchool.DAL;
using MySchool.Models;
using MySchool.Services;
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
    class SchoolInformationOperations 
    {
        //اضافة بيانات المدرسة
        public static int AddSchoolInformationData( Schoolinfo schoolInfo)
        {
            return DataAccessLayer.ExciutCommond("InsertInfomationSchool", () => AddSchoolInformationParametersIsert(schoolInfo.SchoolName, schoolInfo.ImageLogo, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات اضافة بيانات المدرسة
        public static void AddSchoolInformationParametersIsert(string schoolInfo, byte[] dataImage, SqlCommand command)
        {
            command.Parameters.Add("name", SqlDbType.Text).Value = schoolInfo;
            command.Parameters.Add("logo", SqlDbType.Image).Value = dataImage;
        }



        //تحديث بيانات المدرسة
        public static int UpdateSchoolInformationData(Schoolinfo schoolInfo)
        {
            return DataAccessLayer.ExciutCommond("UpdateInfomationSchool", () => UpdateSchoolInformationParametersIsert(schoolInfo.ID, schoolInfo.SchoolName, schoolInfo.ImageLogo, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات تحديث بيانات المدرسة
        public static void UpdateSchoolInformationParametersIsert(int id, string schoolInfo, byte[] dataImage, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@name", SqlDbType.Text).Value = schoolInfo;
            command.Parameters.Add("@logo", SqlDbType.Image).Value = dataImage;
        }


       
    }
}
