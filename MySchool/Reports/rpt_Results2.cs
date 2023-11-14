using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using MySchool.Views.Interfaces;
using MySchool.Persenter;
using MySchool.Services;
using MySchool.Models;
using System.Collections.Generic;
using DevExpress.XtraReports.UI;

namespace MySchool.Reports
{
    public partial class rpt_Results2: DevExpress.XtraReports.UI.XtraReport, IGradesReportView
    {
        private int classid;
        private int yearid;
        //private int termid;
        #region My Property
        public XRTableCell cladmin
        {
            get
            {
                return tbcadmin;
            }
        }

        public XRTableCell clappreci
        {
            get
            {
                return t;
            }
        }

        public XRTableCell clClass
        {
            get
            {
               return  c;
            }
        }

        public XRTableCell clfs1
        {
            get
            {
                return tbcfirstterm;
            }
        }

        public XRTableCell clinstructor
        {
            get
            {
               return  tbcinstructor;
            }
        }

        public XRTableCell clmh1
        {
            get
            {
                return tbcfirstoutcome;
            }
        }

        public XRTableCell clResult
        {
            get
            {
               return  r;
            }
        }

        public XRTableCell clsub
        {
            get
            {
                return tbcsubname;
            }
        }

        public XRTableCell clsum
        {
            get
            {
                return tbcsum;
            }
        }

        public XRTableCell clname
        {
            get
            {
                return tbcstud;
            }
        }

        public XRLabel lbterm
        {
            get
            {
                return lblterm;
            }
        }

        public XRTableCell cltotal
        {
            get
            {
                return tbcsum;
            }
        }

        public XRLabel lbyear
        {
            get
            {
                return lblyear;
            }
        }

        public object rptDataSuorce
        {
            get
            {
                return this.DataSource;
            }
        }
        #endregion

        public rpt_Results2(int yrid,/* int trmid,*/ int clsid)
        {
            InitializeComponent();
            yearid = yrid;
            //termid = trmid;
            classid = clsid;

        }
        public rpt_Results2()
        {
            InitializeComponent();
        }


        static List<ReportGrade> ReportDataSuorce(DataTable Table)
        {
            List<ReportGrade> ListReport = new List<ReportGrade>();
            foreach (DataRow row in Table.Rows)
            {
                //int termid = Convert.ToInt32(row["term_id"]);
                int exmid =Convert.ToInt32( row["exam_id"]);
                string year = row["year_name"].ToString();
                string classname = row["class_name"].ToString();
                string studname = row["stud_name"].ToString();
                string subname = row["sub_name"].ToString();
                decimal mark = Convert.ToDecimal(row["mark"]);
                //string termname = Master.Listterms.Find(x => x.id == termid).Term_name;
                decimal markMax=0;
                if (exmid == (int)Master.enumExams.mh1 || exmid == (int)Master.enumExams.term1)
                    markMax = (decimal)Master.ListExamTerm1.Find(x => x.ID == exmid).gradMax;
                else if (exmid == (int)Master.enumExams.mh2 || exmid == (int)Master.enumExams.term2)
                     markMax = (decimal)Master.ListExamTerm2.Find(x => x.ID == exmid).gradMax;
                ReportGrade regrd = ListReport.Find(x => x.stdname == studname);
                if (regrd == null)
                {
                    regrd = new ReportGrade { yrname = year,  clsname = classname, stdname = studname };
                    ListReport.Add(regrd);
                }
               sub sbj = ListReport.Find(x => x.stdname == studname).sublist.Find(y => y.sbname == subname);
                if (sbj == null)
                {
                    sbj = new sub { sbname = subname };
                  regrd.sublist.Add(sbj);
                }
                mrks mrk = new mrks { mark = mark, gmax = markMax ,examid= exmid };
                sbj.marklist.Add(mrk);
            }
            return ListReport;
        }
        void BindData()
        {
            lblyear.DataBindings.Add("Text", this.DataSource, "yrname");
           lblterm.DataBindings.Add("Text", this.DataSource, "trmname");
           tbcstud.DataBindings.Add("Text", this.DataSource, "stdname");
            tbcclass.DataBindings.Add("Text", this.DataSource, "clsname");
            //tbcadmin.DataBindings.Add("Text", this.DataSource, "");
            // tbcinstructor.DataBindings.Add("Text", this.DataSource, "");
            tbcresult.DataBindings.Add("Text", this.DataSource, "result");
            tbctotal.DataBindings.Add("Text", this.DataSource, "total");
            tbcTaqdeer.DataBindings.Add("Text", this.DataSource, "taqdyr");
            //tbcsubname.DataBindings.Add("Text", this.DataSource, "sbname");
            //tbcfirstoutcome.DataBindings.Add("Text", this.DataSource, "markmh1");
            //tbcfirstterm.DataBindings.Add("Text", this.DataSource, "markfs1");
            //tbcsum.DataBindings.Add("Text", this.DataSource, "sumMark");

            tbcsubname.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "sbname"));
            tbcfirstoutcome.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "markmh1"));
            tbcfirstterm.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "markfs1"));
            tbcSecondoutcome.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "markmh2"));
            tbcSecondterm.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "markfs2"));
            tbcsum.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "sumMark"));
        }
        public void Print(int yearid, int termid, int classid)
        {
            rpt_Results2 rpt = new Reports.rpt_Results2();
            object ds = new object();
            ds = ReportDataSuorce(GradesReportOperation.GetAllGrades(yearid, classid));
            rpt.DataSource = ds;

            //rpt.DetailReport.DataSource = rpt.DataSource;
            //rpt.DetailReport.DataMember = "sublist";
            BindData();
            rpt.ShowPreview();
        }
        public void Print()
        {
            FRM_ReportViewer FRM_repoview = new FRM_ReportViewer();
            rpt_Results2 rpt = new Reports.rpt_Results2();
            object ds = new object();
            ds = ReportDataSuorce(GradesReportOperation.GetAllGrades(yearid,classid));
            rpt.DataSource = ds;
            rpt.RequestParameters = false;
            rpt.DetailReport.DataSource = rpt.DataSource;
            rpt.DetailReport.DataMember = "sublist";
            rpt.tbcadmin.Text = "صالح فروان";
            rpt.BindData();
            //rpt.ShowPreview();
            FRM_repoview.documentViewer1.DocumentSource = rpt;
            FRM_repoview.ShowDialog();
        }
    }
}
