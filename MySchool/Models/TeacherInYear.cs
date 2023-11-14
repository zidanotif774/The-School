using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Models
{
    public class TeacherInYear
    {
        private List<Teacher> Teacherlist;
        public TeacherInYear()
        {
            Teacherlist = new List<Models.Teacher>();
        }
        public int id { get; set; }
        public int userid { get; set; }
        public int yearid { get; set; }
        public int termid { get; set; }
        public List<Teacher> teachers { get { return Teacherlist; } set { Teacherlist = value; } }

    }
}
