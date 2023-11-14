using MySchool.FORMS;
using MySchool.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySchool.Persenter;

namespace MySchool.Views.FORMS
{
    public partial class FRM_Schoolinformation :FRM_Master, ISchoolinformationView
    {

        SchooliformationPersenter schoolInfoPersenter;
        int id;

        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public PictureEdit LogoSchool
        {
            get
            {
                return pictureEdit1;
            }
        }

        public TextBox txtSchoolName
        {
            get
            {
                return textBox1;
            }
        }
        public FRM_Schoolinformation()
        {
            InitializeComponent();
            btn_print.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            schoolInfoPersenter = new Persenter.SchooliformationPersenter(this);
        }
        public override void Save()
        {
            schoolInfoPersenter.Save();
        }
       

    }
}
