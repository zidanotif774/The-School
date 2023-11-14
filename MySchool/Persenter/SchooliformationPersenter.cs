using MySchool.Views.Interfaces;
using MySchool.BSL;
using MySchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MySchool.Services;

namespace MySchool.Persenter
{
    class SchooliformationPersenter
    {

        Schoolinfo schoolinfo;
        ISchoolinformationView view;
        public SchooliformationPersenter(ISchoolinformationView view)
        {
            this.view = view;
            view.LogoSchool.DoubleClick += LogoSchool_DoubleClick;
            RefreshData();
        }

        private void LogoSchool_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                view.LogoSchool.Image = Image.FromFile(ofd.FileName);
            }
        }


        void LoadImage()
        {

        }

        void RefreshData()
        {
            New();
            if (SchoolInformationOperations.GetSchoolInformation().Rows.Count>0)
            {
                schoolinfo.ID = Convert.ToInt16(SchoolInformationOperations.GetSchoolInformation().Rows[0][0]);
                schoolinfo.SchoolName = SchoolInformationOperations.GetSchoolInformation().Rows[0][1].ToString();
                schoolinfo.ImageLogo = (byte[])SchoolInformationOperations.GetSchoolInformation().Rows[0][2]; 
            }
            get();

        }
        void set()
        {
            schoolinfo.ID = view.ID;
            schoolinfo.SchoolName = view.txtSchoolName.Text;
            schoolinfo.ImageLogo = Master.SetImage( (view.LogoSchool.Image));
        }
        
        void get()
        {
            //set();
            view.ID = schoolinfo.ID;
            view.txtSchoolName.Text = schoolinfo.SchoolName;
            view.LogoSchool.Image =(schoolinfo.ImageLogo==null)? view.LogoSchool.Image: Master.getImage(schoolinfo.ImageLogo);
        }
        public void New()
        {
            schoolinfo = new Schoolinfo();
        }

        public void Delete()
        {
            set();

            if (schoolinfo.ID == 0)
            {
                MessageBox.Show("لايوجد عنصر محدد لحذفه");
            }
            else
            {
                if (MessageBox.Show("تأكيد الحذف!!", "هل انت متاكد انك تريد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    //ClassesOperations.ClassDataDelete(Class.ClassID);
                    //MessageBox.Show("تم الحذف بنجاح");
                    //RefreshData();
                    //New();
                }
            }
        }


        public void Save()
        {
            if (IsDataValid())
            {
                set();
               
                    if (schoolinfo.ID == 0)
                    {
                        Add();
                    }
                    else
                    {
                        Update();
                    }
                    RefreshData();
                
            }
        }

        void Add()
        {
            SchoolInformationOperations.AddSchoolInformationData(schoolinfo);
            MessageBox.Show("تم الاظافة بنجاح");
        }

        void Update()
        {
            SchoolInformationOperations.UpdateSchoolInformationData(schoolinfo);

            MessageBox.Show("تم التحديث بنجاح");

        }

        int AutoNum()
        {
            return ClassesOperations.GetAllClass().Rows.Count + 1;
        }

        //التحقق من الحقول ليست فارغة
        bool IsDataValid()
        {
            int errors = 0;
            if (view.txtSchoolName.Text.Trim()==string.Empty)
            {
                errors += 1;
            }
           
            return errors == 0;

        }
       

    }
}
