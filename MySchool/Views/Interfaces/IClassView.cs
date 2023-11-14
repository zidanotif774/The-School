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
    public interface IClassView
    {
        int ClassID { get; set; }
        TextEdit txtClass { get; set; }
        LookUpEdit lkpLevel { get; set; }
        GridView gridview { get; set; }
        GridControl gridcontrol { get; set; }
    }
}
