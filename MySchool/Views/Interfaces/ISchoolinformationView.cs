using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using DevExpress.XtraEditors;

namespace MySchool.Views.Interfaces
{
   public interface ISchoolinformationView
    {
        int ID { get; set; }
        TextBox txtSchoolName { get;  }
        PictureEdit LogoSchool { get; }
    }
}
