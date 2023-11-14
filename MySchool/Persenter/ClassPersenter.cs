using MySchool.Views.Interfaces;
using MySchool.BSL;
using MySchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySchool.Persenter
{
    class ClassPersenter
    {

        ClassStudy Class;
        IClassView view;
        BindingSource studentbindingsource;
        public ClassPersenter(IClassView view)
        {
            this.view = view;
            this.studentbindingsource = new BindingSource();
            view.gridview.RowClick += Gridview_RowClick;
            New();
            RefreshData();
        }

        private void Gridview_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            New();
            view.ClassID = Convert.ToInt32(view.gridview.GetFocusedRowCellValue("class_id"));
            view.txtClass.Text = view.gridview.GetFocusedRowCellValue("class_name").ToString();
            view.lkpLevel.EditValue = view.gridview.GetFocusedRowCellValue("level_id");

        }



        void RefreshData()
        {
           
            New();
            view.lkpLevel.Properties.DataSource = LevelsOperations.GetAllLevel();
            view.lkpLevel.Properties.DisplayMember = LevelsOperations.GetAllLevel().Columns[1].ToString();
            view.lkpLevel.Properties.ValueMember = LevelsOperations.GetAllLevel().Columns[0].ToString();
             
            view.gridcontrol.DataSource = ClassesOperations.GetAllClass();
            
        }
        void set()
        {
            Class.ClassID = view.ClassID;
            Class.ClassName = view.txtClass.Text;
            Class.levelid = (view.lkpLevel.EditValue as int?) ?? 0;
        }

        void get()
        {
            view.ClassID = Class.ClassID;
            view.txtClass.Text = Class.ClassName;
            view.lkpLevel.EditValue = Class.levelid;
        }
        public void New()
        {
            Class = new ClassStudy();
           
            get();
        }

        public void Delete()
        {
            set();

            if (Class.ClassID == 0)
            {
                MessageBox.Show("لايوجد عنصر محدد لحذفه");
            }
            else
            {
                if (MessageBox.Show("تأكيد الحذف!!", "هل انت متاكد انك تريد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    ClassesOperations.ClassDataDelete(Class.ClassID);
                    MessageBox.Show("تم الحذف بنجاح");
                    RefreshData();
                    New();
                }
            }
        }


        public void Save()
        {
            if (IsDataValid())
            {
                set();
                if (!IsExist())
                {
                    if (Class.ClassID == 0)
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
        }

        void Add()
        {
            ClassesOperations.AddClassData(Class.levelid,Class.ClassName);
            MessageBox.Show("تم الاظافة بنجاح");
        }

        void Update()
        {
            ClassesOperations.UpdateClassData(Class.levelid, Class.ClassID,Class.ClassName);
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
            if (view.txtClass.Text.Trim()==string.Empty)
            {
                view.txtClass.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            if (view.lkpLevel.EditValue==null)
            {
                view.lkpLevel.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            return errors == 0;

        }
        bool IsExist()
        {
            if (ClassesOperations.ExistItem(Class.ClassName,Class.levelid).Rows.Count > 0)
            {
                MessageBox.Show("هذا العنصر مجود من قبل");
                return true;
            }
            else
                return false;
        }

    }
}
