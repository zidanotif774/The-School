using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Views.Interfaces
{
   public interface IGradesReportView
    {
        XRTableCell clname { get; }
        XRLabel lbyear { get;  }
        XRLabel lbterm { get;  }
        XRTableCell cltotal { get;  }
        XRTableCell clsub { get; }
        XRTableCell clmh1 { get;  }
        XRTableCell clfs1 { get; }
        XRTableCell clsum { get; }
        XRTableCell clClass { get; }
        XRTableCell clResult { get; }
        XRTableCell clappreci { get;  }
        XRTableCell cladmin { get;  }
        XRTableCell clinstructor { get; }
        object rptDataSuorce { get; }

    }
}
