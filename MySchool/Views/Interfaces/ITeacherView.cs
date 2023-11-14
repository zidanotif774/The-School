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
    public interface ITeacherView
    {
        int teach_id { get; set; }
        CheckEdit isActive { get; }
        TextEdit txename { get; }
        LookUpEdit lkpsex { get; }
        TextEdit txtmajor { get; }
        TextEdit txtteach_phonnum { get;}
        TextEdit txtcardnum { get; }
        GridControl gridcontrol { get; }
        GridView gridview { get; }
    }
}
