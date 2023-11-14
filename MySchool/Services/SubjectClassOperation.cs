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
    class SubjectClassOperation
    {


        //اضافة قائمة  المواد على الصف
        public static void AddSubClassData(SubjectClass subclass)
        {
            foreach (var sub in subclass.subjects)
            {
                AddSubClassData(sub.id, subclass.Classid);
            }
        }
        //اضافة المادة للصف
        public static int AddSubClassData(int subid, int classid)
        {
            return DataAccessLayer.ExciutCommond("InsertClassSubject", () => SubClassParametersIsert(subid, classid, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات اضافة المادة للصف 
        public static void SubClassParametersIsert(int subid, int classid, SqlCommand command)
        {
            command.Parameters.Add("Sub_id", SqlDbType.Int).Value = subid;
            command.Parameters.Add("Class_id", SqlDbType.Int).Value = classid;
        }


        //تحديث قائمةالمواد للصف
        public static void UpdateSubClassData(SubjectClass subclass)
        {
            SubClassDelete(subclass.Classid);
            foreach (var sub in subclass.subjects)
            {
                AddSubClassData(sub.id, subclass.Classid);
            }
        }



        //تحديث المادة للصف
        public static int UpdateSubClassData(int subclassid, int subid, int classid)
        {
            return DataAccessLayer.ExciutCommond("UpdateClassSuject", () => UpdateSubClassParametersIsert(subclassid, subid, classid, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات تحديث المادة للصف
        public static void UpdateSubClassParametersIsert(int subclassid, int subid, int classid, SqlCommand command)
        {
            command.Parameters.Add("classSub_id", SqlDbType.Int).Value = subclassid;
            command.Parameters.Add("Sub_id", SqlDbType.Int).Value = subid;
            command.Parameters.Add("Class_id", SqlDbType.Int).Value = classid;
        }



        //حذف قائمةالمواد من صف 
        public static void SubClassDelete(List<SubjectClass> list)
        {
            foreach (var subclass in list)
            {
                SubClassDelete(subclass.Classid);
            }
        }
        //حذف مادة من صف
        public static int SubClassDelete(int classid)
        {
            return DataAccessLayer.ExciutCommond("DeleteClassSubject", () => SubClassDeleteParameterInsert(classid, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات حذف مادة من صف
        public static void SubClassDeleteParameterInsert(int classid, SqlCommand command)
        {
            command.Parameters.Add("class_id", SqlDbType.Int).Value = classid;
        }



        //التحقق من وجود المادة في الصف الدراسي
        public static DataTable ExistItem(int classid, int subid)
        {
            return DataAccessLayer.SelectData("ClassSubIsExist", () => ExistItemParameterInsert(classid, subid, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات التحقق من وجود المادة في الصف الدراسي
        public static void ExistItemParameterInsert(int classid, int subid, SqlCommand command)
        {
            command.Parameters.Add("Class_id", SqlDbType.Int).Value = classid;
            command.Parameters.Add("Sub_id", SqlDbType.Int).Value = subid;
        }


        public static DataTable GetAllClassSubjects()
        {
            return DataAccessLayer.SelectData("SelectAllClassSujects", null);
        }
        public static DataTable GetAllClassSubjects(int classid)
        {
            return DataAccessLayer.SelectData("GetAllSubjectsInClass", () => GetSubjectsClassParameterInsert(classid, DataAccessLayer.sqlcm));
        }
        public static void GetSubjectsClassParameterInsert(int classid, SqlCommand command)
        {
            command.Parameters.Add("classid", SqlDbType.Int).Value = classid;
        }

       

        public static List<SubjectClass> GetListClassSubjects()
        {
            List<SubjectClass> risultList = new List<SubjectClass>();
            SubjectClass subclass;
            DataTable dt = DataAccessLayer.SelectData("SelectAllClassSujects", null);
            Dictionary<string, List<Subject>> diction = new Dictionary<string, List<Subject>>();
            foreach (DataRow row in dt.Rows)
            {
                if (row!=null)
                {
                    string value = row["classe_id"].ToString();
                    if (diction.ContainsKey(value))
                    {
                        diction[value].Add(new Models.Subject { id = Convert.ToInt32(row["sub_id"]), name=row["sub_name"].ToString() });
                    }
                    else
                    {
                        diction.Add(value, new List<Models.Subject>() { new Subject() { id = Convert.ToInt32(row["sub_id"]), name = row["sub_name"].ToString() } });
                        risultList.Add(new SubjectClass {id = Convert.ToInt32(row["ClSu_id"]), Classid=Convert.ToInt32( value ),ClassName= row["class_name"].ToString() });
                    }

                }

            }
            foreach (KeyValuePair<string, List<Subject>> pair in diction)
            {
                int clsid = Convert.ToInt32(pair.Key);
                risultList.Where(x => x.Classid == clsid).Single().subjects = pair.Value;
            }
                    //int r = Convert.ToInt32(row["classe_id"]);
                    //while (true)
                    //{

                    //}


                    //subclass = new SubjectClass
                    //{
                    //    id = Convert.ToInt32(row["ClSu_id"]),
                    //    Classid = Convert.ToInt32(row["classe_id"]),
                    //    ClassName = row["class_name"].ToString(),
                    //};

                    //List<Subject> subs = new List<Models.Subject>();
                    //subs.Add(
                    //    new Models.Subject
                    //    {
                    //        id = Convert.ToInt32(row["sub_id"]),
                    //        name = row["sub_name"].ToString()
                    //    }
                    //    );

                    //subclassList.Add(new SubjectClass()
                    //{
                    //    id = Convert.ToInt32(row["ClSu_id"]),
                    //    Classid = Convert.ToInt32(row["classe_id"]),
                    //    ClassName = row["class_name"].ToString(),
                    //    //subjects = subs
                    //    subjects =new List<Subject> 
                    //} );


                    return risultList;
        }
       public static List<SubjectClass> ListClassSubjects()
        {
            DataTable dt = DataAccessLayer.SelectData("SelectAllClassSujects", null);
            List<SubjectClass> ListSubjectsInclass = new List<SubjectClass>();
            foreach (DataRow row in dt.Rows)
            {
                int Id = Convert.ToInt32(row["ClSu_id"]);
                int classId = Convert.ToInt32(row["classe_id"]);
                string classname = row["class_name"].ToString();
                string subname = row["sub_name"].ToString();
                int subid = Convert.ToInt32(row["sub_id"]);

                SubjectClass subclass = ListSubjectsInclass.Find(x => x.Classid == classId);
                if (subclass == null)
                {
                    subclass = new SubjectClass { id = Id, Classid = classId, ClassName = classname};
                    ListSubjectsInclass.Add(subclass);
                }
                Subject sbj = ListSubjectsInclass.Find(x => x.Classid == classId).subjects.Find(y => y.id == subid);
                if (sbj == null)
                {
                    sbj = new Subject { id = subid,name= subname };
                    subclass.subjects.Add(sbj);
                }
            }
            return ListSubjectsInclass;
        }
    }
}
