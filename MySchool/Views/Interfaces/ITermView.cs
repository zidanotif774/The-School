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
    public interface ITermView
    {
        int No { get; set; }
        LookUpEdit lpkTermname { get; }
        GridControl gridcontrol { get;}
        GridView  gridview { get;  }
        CheckEdit isActive { get; }
        //RadioGroup group { get; }
        //ListBoxControl list { get; }

    }
}
