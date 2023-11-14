using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySchool.Views.Interfaces
{
    public interface IGradesView
    {
       
        int id { get; set; }
        LookUpEdit lkpyear { get; }
        LookUpEdit lkpclass { get; }
        LookUpEdit lkpsubject { get; }
        LookUpEdit lkpterm{ get; }
        LookUpEdit lkpexam{ get; }
        Label LblTitel1{ get; }
        Label LblTitel2{ get; }
        Label LblTitel3{ get; }
        Label LblTitel4{ get; }
        LookUpEdit lkpStudent { get; }
        TextEdit txeSubject{ get; }
        SpinEdit spnMark{ get; }
        ListBoxControl ListStud{ get; }

        GridView gridview { get; }
        GridControl gridcontrol { get; }
        GridControl gridcontrolTest { get; }
    }
}
