using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Views.Interfaces
{
  public  interface IExamView
    {
        int id { get; set; }
        TextEdit txeExamName { get; }
        LookUpEdit lkpTerm { get; }
        SpinEdit SpEdGradeMax { get; }

        GridView gridview { get; }
        GridControl gridcontrol { get; }
    }
}
