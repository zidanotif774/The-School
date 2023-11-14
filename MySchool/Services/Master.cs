using MySchool.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Services
{
   public class Master
    {
        public class ValueAndId
        {
            public int ID { get; set; }
            public string Name { get; set; }

        }
        //public class Exams
        //{
        //    public int ID { get; set; }
        //    public string Name { get; set; }
        //    public int gradMax { get; set; }

        //}

        

            //قائمة الامتحانات 
        public static List<Exam> ListExamTerm2 = new List<Exam>
        {
            new Exam { id = (int)enumExams.mh1, ExamName = "المحصلة الاولى",GradeMax=20 },
            new Exam { id = (int)enumExams.term1, ExamName = "الفصل الاول" ,GradeMax=30},
            new Exam { id = (int)enumExams.mh2, ExamName = "المحصلة الثانية",GradeMax=20 },
            new Exam { id = (int)enumExams.term2, ExamName = "الفصل الثاني" ,GradeMax=30},
        };
      
        public enum enumExams
        {
            //المحصلة الاولى
            mh1=9,

            //الفصل الاول
            term1,

            //المحصلة الثانية
            mh2,

            //الفصل الثاني
            term2
        }
        

            //قائمة الفصول الدراسية
        public static List<Term> Listterms = new List<Term>
        {
            new Term { id = (int)Terms.term1, Term_name = "الفصل الاول" },
            new Term { id = (int)Terms.term2, Term_name = "الفصل الثاني" },
        };
        public enum Terms
        {
            //الفصل الاول
            term1 = 1,
            //الفصل الثاني
            term2
        }
            //دالة لتحويل الصورة لمصفوفة ثنائية
        public static byte[] SetImage(Image image)
        {
            if (image == null) return null;
          
                MemoryStream ms = new MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); 
           
            return ms.ToArray();
        }
        //دالة لتحويل المصفوفة الثنائية لصورة 
        public static Image  getImage(byte[] dataImage)
        {
            if (dataImage.Length > 0)
            {
                MemoryStream ms = new MemoryStream(dataImage);
                return Image.FromStream(ms);
            }
            else return null;
        }
    }
}
