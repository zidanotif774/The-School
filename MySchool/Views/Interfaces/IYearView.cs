using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySchool.Views.Interfaces
{
    public interface IYearView
    {
        int YearID { get; set; }
        TextEdit txeyearname { get; }
        CheckEdit checkActive { get; }
        GridControl gridcontrol { get;}
        GridView  gridview { get;  }
       
    }
}
