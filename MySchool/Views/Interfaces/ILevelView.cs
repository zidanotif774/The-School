using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Views.Interfaces
{
    public interface ILevelView
    {
        int ID { get; set; }
        TextEdit Level { get; }
        GridControl GridControl1 { get; }
        GridView gridview { get; }
    }
}
