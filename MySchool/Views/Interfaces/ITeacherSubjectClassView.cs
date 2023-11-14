using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySchool.Views.Interfaces
{
  public  interface ITeacherSubjectClassView
    {
        int id { get; set; }

        LookUpEdit lokyear { get; }
        LookUpEdit lkpteach { get; }
        SimpleButton btnAddSubject { get; }
        TreeList tlsubject { get; }
       
        GridControl gridcontrol { get; }
        GridView gridview { get; }
    }
}
