using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Models
{
   public class Teacher
    {
        private int teach_id;
        private bool activeation=false;
        private string teach_name;
        private int teach_sex;
        private string teach_major;
        private string teach_PhonNum;
        private string teach_CardNum;

        public int Teach_id
        {
            get
            {
                return teach_id;
            }

            set
            {
                teach_id = value;
            }
        }

        public bool isactive
        {
            get
            {
                return activeation;
            }

            set
            {
                activeation = value;
            }
        }

        public string Teach_name
        {
            get
            {
                return teach_name;
            }

            set
            {
                teach_name = value;
            }
        }

        public int Teach_sex
        {
            get
            {
                return teach_sex;
            }

            set
            {
                teach_sex = value;
            }
        }

        public string Teach_major
        {
            get
            {
                return teach_major;
            }

            set
            {
                teach_major = value;
            }
        }

        public string Teach_PhonNum
        {
            get
            {
                return teach_PhonNum;
            }

            set
            {
                teach_PhonNum = value;
            }
        }

        public string Teach_CardNum
        {
            get
            {
                return teach_CardNum;
            }

            set
            {
                teach_CardNum = value;
            }
        }
    }
}
