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
    class TeacherSubjectClassOperation
    {

        public static void AddSubClassDataInTeach(int Teachid, List<SubjectClass> subListclass)
        {
            foreach (var item in subListclass)
            {
                AddSubClassDataInTeach(Teachid, item.id);
            }

        }
        //اضافة مادة لمعلم
        public static int AddSubClassDataInTeach(int Teachid, int subclassid)
        {
            return DataAccessLayer.ExciutCommond("InsertTeacherClassSubject", () => TeachSubClassParametersIsert(Teachid, subclassid, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات اضافة مادة لمعلم 
        public static void TeachSubClassParametersIsert(int Teachid, int subclassid, SqlCommand command)
        {
            command.Parameters.Add("Teach_id", SqlDbType.Int).Value = Teachid;
            command.Parameters.Add("SubClass_id", SqlDbType.Int).Value = subclassid;
        }


        //تحديث قائمة المواد لمعلم
        public static void UpdateSubClassDataInTeach(int teachsubclass, int Teachid, List<SubjectClass> subListclass)
        {
            TeachSubClassDelete(Teachid);
            foreach (var item in subListclass)
            {
                AddSubClassDataInTeach(Teachid, item.id);
            }
        }
        //تحديث  مادة لمعلم
        public static int UpdateSubClassDataInTeach(int teachsubclass, int Teachid, int subclassid)
        {
            return DataAccessLayer.ExciutCommond("UpdateTeacherClassSuject", () => UpdateTeachSubClassParametersIsert(teachsubclass, Teachid, subclassid, DataAccessLayer.sqlcm));
        }
        //اضافة بارامترات تحديث تحديث  مادة لمعلم
        public static void UpdateTeachSubClassParametersIsert(int teachsubclass, int Teachid, int subclassid, SqlCommand command)
        {
            command.Parameters.Add("TeachSubclass_id", SqlDbType.Int).Value = teachsubclass;
            command.Parameters.Add("Teach_id", SqlDbType.Int).Value = Teachid;
            command.Parameters.Add("SubClass_id", SqlDbType.Int).Value = subclassid;
        }



        //حذف مواد المعلم
        public static int TeachSubClassDelete(int id)
        {
            return DataAccessLayer.ExciutCommond("DeleteTeachClassSubject", () => TeachSubClassDeletParameterInsert(id, DataAccessLayer.sqlcm));
        }
        //اضافة بارمترات حذف مواد المعلم
        public static void TeachSubClassDeletParameterInsert(int id, SqlCommand command)
        {
            command.Parameters.Add("teachid", SqlDbType.Int).Value = id;
        }

        public static DataTable GetAllTeacherClassSubjectsWithYear(int yearid)
        {
            DataTable dt = DataAccessLayer.SelectData("GetAllTeacherWithYear", () => GetAllTeacherClassSubjectsWithYearParameterInsert(yearid, DataAccessLayer.sqlcm));
            return dt;
        }
        public static void GetAllTeacherClassSubjectsWithYearParameterInsert(int yearid, SqlCommand command)
        {
            command.Parameters.Add("yearid", SqlDbType.Int).Value = yearid;
        }

        public static DataTable GetAllTeacherClassSubjects()
        {
            DataTable dt = DataAccessLayer.SelectData("GetAllTeacherClassSujects", null);
            return dt;
        }


        public static List<TeacherSubject> GetListTeachClassSubjects()
        {
            List<TeacherSubject> teachListsubject = new List<TeacherSubject>();
            List<SubjectClass> subjectList = new List<SubjectClass>();
            SubjectClass subclass;
            DataTable dt = DataAccessLayer.SelectData("GetAllTeacherClassSujects", null);
            Dictionary<string, List<SubjectClass>> diction = new Dictionary<string, List<SubjectClass>>();
            Dictionary<string, List<Subject>> diction1 = new Dictionary<string, List<Subject>>();
            foreach (DataRow row in dt.Rows)
            {
                if (row != null)
                {


                    string value = row["classe_id"].ToString();
                    if (diction1.ContainsKey(value))
                    {
                        diction1[value].Add(new Models.Subject
                        {
                            id = Convert.ToInt32(row["sub_id"]),
                            name = row["sub_name"].ToString()
                        });
                    }
                    else
                    {
                        diction1.Add(value, new List<Models.Subject>() { new Subject()
                                                                    { id = Convert.ToInt32(row["sub_id"]),
                                                                        name = row["sub_name"].ToString() } });
                        subjectList.Add(new SubjectClass()
                        {
                            id = Convert.ToInt32(row["subClass_id"]),
                            Classid = Convert.ToInt32(value),
                            ClassName = row["class_name"].ToString()
                        });
                    }
                }
            }
            foreach (KeyValuePair<string, List<Subject>> pair in diction1)
            {
                int clsid = Convert.ToInt32(pair.Key);
                subjectList.Where(x => x.Classid == clsid).Single().subjects = pair.Value;

            }

            foreach (DataRow row in dt.Rows)
            {
                if (row != null)
                {
                    string value1 = row["teach_id"].ToString();

                    if (diction.ContainsKey(value1))
                    {
                        diction[value1].Add(new SubjectClass
                        {
                            id = Convert.ToInt32(row["subClass_id"]),
                            Classid = Convert.ToInt32(row["classe_id"]),
                            ClassName = row["class_name"].ToString(),
                            subjects = subjectList.Where(x => x.Classid == Convert.ToInt32(row["classe_id"])).Single().subjects
                        });
                    }
                    else
                    {
                        diction.Add(value1, new List<SubjectClass>() { new SubjectClass() {
                                                                id = Convert.ToInt32(row["subClass_id"]),
                                                                Classid=Convert.ToInt32(row["classe_id"]),
                                                               ClassName = row["class_name"].ToString() ,
                            subjects= subjectList.Where(x => x.Classid == Convert.ToInt32(row["classe_id"])).Single().subjects

                        } });

                        teachListsubject.Add(new TeacherSubject()
                        {
                            id = Convert.ToInt32(row["TeacherSubjectClass_id"]),
                            teachid = Convert.ToInt32(row["teach_id"]),
                            teachname = row["teach_name_"].ToString()
                        });
                    }
                }
            }
            foreach (KeyValuePair<string, List<SubjectClass>> pair in diction)
            {
                int teachid = Convert.ToInt32(pair.Key);
                teachListsubject.Where(x => x.teachid == teachid).Single().teachsubjects = pair.Value;
            }

            return teachListsubject;
        }

      
    }
}
