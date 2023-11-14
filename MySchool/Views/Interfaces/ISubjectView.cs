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
  public interface ISubjectView
    {
        int id { get; set; }
        TextEdit txtSubject { get; }
        GridView gridview { get;  }
        GridControl gridcontrol { get;  }
    }
}
