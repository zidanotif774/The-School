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
    public interface IStudentView
    {
       
        int id { get; set; }
        TextEdit txeStudent { get; }
        LookUpEdit lkpsex { get; }
        DateEdit datPrthdate { get; }
        TextEdit txeTitl { get; }

        GridView gridview { get; }
        GridControl gridcontrol { get; }
    }
}
