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
  public  interface ITermInYearView 
    {
        int id { get; set; }
        LookUpEdit lkpYear { get; }
        CheckedListBoxControl checkListTerm { get; }

        GridView gridview { get; }
        GridControl gridcontrol { get; }

    }
}
