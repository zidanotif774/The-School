using MySchool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Models
{
    class Grades
    {
        public int Id { get; set; }
        public int yearId { get; set; }
        public int termId { get; set; }
        public int classId { get; set; }
        public int studId { get; set; }
        public int examId { get; set; }
        public int subjectId { get; set; }
        public decimal mark { get; set; }

    }
    public class ReportGrade
    {
        public List<sub> _sublist;

        public string yrname { get; set; }
        public string trmname { get; set; }
        public string clsname { get; set; }
        public string stdname { get; set; }
        public List<sub> sublist
        {
            get
            {
                if (_sublist == null)
                {
                    _sublist = new List<sub>();
                }
                return _sublist;
            }
            set { _sublist = value; }
        }
        public decimal total { get { return _sublist.Sum(x => x.sumMark); } }
        public decimal totalmax { get { return _sublist.Sum(x => x.sumMx); } }
        public string result
        {
            get
            {
                string result = "";
                if (total >= (totalmax / 2)) result = "ناجح"; else result = "راسب"; return result;
            }
        }
        public string taqdyr
        {
            get
            {
                string result = "";
                decimal ratio = (total / totalmax) * 100;
                if (ratio >= 50 && ratio <= 65) result = "";
                else if (ratio > 65 && ratio < 80) result = "جيد";
                else if (ratio >= 80 && ratio < 90) result = "جيد جدا";
                else if (ratio >= 90 && ratio <= 100) result = "ممتاز";
                return result;
            }
        }
    }
    public class sub
    {
        private List<mrks> _marklist;

        public string sbname { get; set; }
        public List<mrks> marklist
        {
            get
            {
                if (_marklist == null)
                {
                    _marklist = new List<mrks>();
                }
                return _marklist;
            }
            set { _marklist = value; }
        }
        public decimal markfs1 {
            get {
                var mk = _marklist.Where(x => x.examid == (int)Master.enumExams.term1).FirstOrDefault();
                if (mk == null) return 0;
                else return  mk.mark;
                 }
        }
        public decimal markmh1 {
            get
            {
                var mk = _marklist.Where(x => x.examid == (int)Master.enumExams.mh1).FirstOrDefault();
                if (mk == null) return 0;
                else return mk.mark;
            }
        }
        public decimal markfs2
        {
            get
            {
                var mk = _marklist.Where(x => x.examid == (int)Master.enumExams.term2).FirstOrDefault();
                if (mk == null) return 0;
                else return mk.mark;
            }
        }
        public decimal markmh2
        {
            get
            {
                var mk = _marklist.Where(x => x.examid == (int)Master.enumExams.mh2).FirstOrDefault();
                if (mk == null) return 0;
                else return mk.mark;
            }
        }
        public decimal sumMark { get { return _marklist.Sum(x => x.mark); } }
        public decimal sumMx { get { return _marklist.Sum(x => x.gmax); } }
    }
    public class mrks
    {
        private int _examid;
        private decimal _mark;
        private decimal _gmax;
        public int examid { get { return (_examid as int?) ?? 0; } set { _examid = value; } }
        public decimal mark { get { return (_mark as decimal?) ?? 0; } set { _mark = value; } }
        public decimal gmax { get { return (_gmax as decimal?) ?? 0; } set { _gmax = value; } }
    }
}