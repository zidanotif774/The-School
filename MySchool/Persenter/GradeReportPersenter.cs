using DevExpress.XtraReports.UI;
using MySchool.Models;
using MySchool.Reports;
using MySchool.Services;
using MySchool.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Persenter
{
   public class GradeReportPersenter
    {
        IGradesReportView view;
        public GradeReportPersenter(IGradesReportView view)
        {
            this.view = view;

        }



      static  List<ReportGrade> ReportDataSuorce(DataTable Table)
        {
            List<ReportGrade> ListReport = new List<ReportGrade>();
            foreach (DataRow row in Table.Rows)
            {
                string year = row["year_name"].ToString();
                string classname = row["class_name"].ToString();
                string termname = row["term_name"].ToString();
                string studname = row["stud_name"].ToString();
                string subname = row["sub_name"].ToString();
                string examname = row["exam_name"].ToString();
                decimal mark = Convert.ToDecimal(row["mark"]);
                decimal markMax = Convert.ToDecimal(row["gradeMax"]);

                ReportGrade regrd = ListReport.Find(x => x.stdname == studname);
                if (regrd == null)
                {
                    regrd = new ReportGrade { yrname = year, trmname = termname, clsname = classname, stdname = studname };
                    ListReport.Add(regrd);
                }
                sub sbj = ListReport.Find(x => x.stdname == studname).sublist.Find(y => y.sbname == subname);
                if (sbj == null)
                {
                    sbj = new sub { sbname = subname };
                }
                //sub sbj = ListReport.Find(x => x.stdname == studname).sublist.Find(y => y.sbname == subname);
                mrks mrk = new mrks {  mark = mark ,gmax= markMax };
                sbj.marklist.Add(mrk);
                    regrd.sublist.Add(sbj);
                ListReport.Add(regrd);
            }
            return ListReport;
        }
        void BinData()
        {
            view.lbyear.DataBindings.Add("Text", view.rptDataSuorce, "yrname");
            view.lbterm.DataBindings.Add("Text", view.rptDataSuorce, "trmname");
            view.clname.DataBindings.Add("Text", view.rptDataSuorce, "stdname");
            view.clClass.DataBindings.Add("Text", view.rptDataSuorce, "clsname");
            //view.cladmin.DataBindings.Add("Text", view.rptDataSuorce, "");
            //view.clinstructor.DataBindings.Add("Text", view.rptDataSuorce, "");
            view.clResult.DataBindings.Add("Text", view.rptDataSuorce, "result");
            view.cltotal.DataBindings.Add("Text", view.rptDataSuorce, "total");
            view.clappreci.DataBindings.Add("Text", view.rptDataSuorce, "taqdyr");
            view.clsub.ExpressionBindings.Add(new DevExpress.XtraReports.UI.ExpressionBinding("BeforPrint", "Text", "sbname"));
            view.clmh1.ExpressionBindings.Add(new DevExpress.XtraReports.UI.ExpressionBinding("BeforPrint", "Text", "markmh1"));
            view.clfs1.ExpressionBindings.Add(new DevExpress.XtraReports.UI.ExpressionBinding("BeforPrint", "Text", "markfs1"));
            view.clsum.ExpressionBindings.Add(new DevExpress.XtraReports.UI.ExpressionBinding("BeforPrint", "Text", "sumMark"));
        }
        public  void Print(int yearid,int termid,int classid)
        {
            rpt_Results1 rpt = new Reports.rpt_Results1();
            rpt.DataSource = ReportDataSuorce(GradesReportOperation.GetAllGrades(yearid, termid, classid));
            //rpt.DetailReport.DataSource = rpt.DataSource;
            //rpt.DetailReport.DataMember = "sublist";
            BinData();
            rpt.ShowPreview();
        }
    }
}
