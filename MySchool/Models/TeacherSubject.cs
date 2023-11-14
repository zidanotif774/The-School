using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Models
{
  public  class TeacherSubject
    {
        List<SubjectClass> subclasslist;
        public TeacherSubject()
        {
            subclasslist = new List<Models.SubjectClass>();
        }
        public int id { get; set; }
        public int teachid { get; set; }
        public string teachname { get; set; }
        public List<SubjectClass> teachsubjects { get { return subclasslist; } set { subclasslist = value; } }
    }
}
