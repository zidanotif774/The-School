using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Models
{
    public class Term
    {
        public int id { get; set; }
        public int No { get; set; }
        public string Term_name { get; set; }
        public bool isActive { get; set; }
    }
}
