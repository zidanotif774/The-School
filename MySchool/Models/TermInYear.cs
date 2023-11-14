using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Models
{
   public class TermInYear
    {
        public int id { get; set; }
        public int year_id { get; set; }
        public List<Term> TermList { get; set; }
    }
}
