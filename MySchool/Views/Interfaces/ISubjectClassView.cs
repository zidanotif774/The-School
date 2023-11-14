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
  public  interface ISubjectClassView
    {
        int id { get; set; }
        LookUpEdit lkpClass { get; }
                
        GridView gridview { get; }
        GridControl gridcontrol { get; }
        CheckedListBoxControl SubListbox { get; }

    }
}
