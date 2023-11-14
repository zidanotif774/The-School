using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Models
{
 public   class Exam
    {
        public int id { get; set; }
        public string ExamName { get; set; }
        public int GradeMax { get; set; }
        public int termid { get; set; }
    }
}
