using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Models
{
  public  class SubjectClass
    {
        private List<Subject> subjectlist;
        public SubjectClass()
        {
            subjectlist = new List<Models.Subject> ();
        }
        public int id { get; set; }
        public int Classid { get; set; }
        public string ClassName { get; set; }
        public List<Subject> subjects { get { return subjectlist; } set {subjectlist=value; } }
        
    }
}
