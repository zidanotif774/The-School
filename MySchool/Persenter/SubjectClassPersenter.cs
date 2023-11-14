using MySchool.Models;
using MySchool.Views.Interfaces;
using MySchool.BSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySchool.Persenter
{
    class SubjectClassPersenter
    {

        SubjectClass sujectclass;
        ISubjectClassView view;
        List<SubjectClass> subclassList;
        List<Subject> subList;
        Subject sub;


        public SubjectClassPersenter(ISubjectClassView view)
        {
            this.view = view;
            New();
           
            view.gridview.RowClick += Gridview_RowClick;
            view.gridview.CustomColumnDisplayText += Gridview_CustomColumnDisplayText;
            view.lkpClass.EditValueChanged += LkpClass_EditValueChanged;

            view.lkpClass.Properties.DataSource = ClassesOperations.GetAllClass();
            view.lkpClass.Properties.DisplayMember = "class_name";
            view.lkpClass.Properties.ValueMember = "class_id";


            view.SubListbox.DisplayMember = nameof(sub.name);
            view.SubListbox.ValueMember = nameof(sub.id);

            RefreshData();
            //view.gridview.ExpandAllGroups();
        }

        private void Gridview_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //if (e.ListSourceRowIndex!=DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            //{
            //    e.DisplayText = "المواد";
            //}
        }

        private void LkpClass_EditValueChanged(object sender, EventArgs e)
        {
            New();
            sujectclass = new SubjectClass();
            sujectclass.Classid = (view.lkpClass.EditValue as int?) ?? 0;
            sujectclass = SubjectClassOperation.ListClassSubjects().Where(y=>y.Classid== sujectclass.Classid).SingleOrDefault();

            if (sujectclass != null)
            {
                foreach (Subject sub in sujectclass.subjects)
                {
                    
                    {
                        view.SubListbox.SelectedValue = sub.id;
                        view.SubListbox.CheckSelectedItems();
                        view.id = sujectclass.id;
                    }
                }
            }
        } 

        private void Gridview_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            New();
            view.id = Convert.ToInt32(view.gridview.GetFocusedRowCellValue("id"));
            view.lkpClass.EditValue = view.gridview.GetFocusedRowCellValue("classid");
        }



        void RefreshData()
        {
            var ds = SubjectClassOperation.ListClassSubjects();
            view.gridcontrol.DataSource = ds;

            foreach (var item in ds)
            {
                var row = view.gridview.GetRowHandle(ds.IndexOf(item));
                view.gridview.SetMasterRowExpanded(row, true);
                
                foreach (var i in item.subjects)
                {
                    //var subeow = view.gridview.GetRelationIndex(row, nameof(item.subjects));
                    //view.gridview.SetMasterRowExpanded(subeow, true);
                }
            }
            New();
            get();
        }
        void set()
        {
            sujectclass = new SubjectClass();
            sujectclass.id = view.id;
            sujectclass.Classid = (view.lkpClass.EditValue as int?) ?? 0;
            foreach (var item in view.SubListbox.CheckedItems)
            {
                subList.Add( new Subject
                {
                     id = Convert.ToInt32(view.SubListbox.GetItemValue(view.SubListbox.FindItem(item))),
                     name = view.SubListbox.GetItemText(view.SubListbox.FindItem(item))
                   
                });
            }
            sujectclass.subjects = subList;
        }

        public void get()
        {
            view.id = sujectclass.id;
            view.lkpClass.EditValue = sujectclass.Classid;
          
        }

        public void New()
        {
            subList = new List<Models.Subject>();
            sujectclass = new SubjectClass();
            subclassList = new List<SubjectClass>();
            view.SubListbox.DataSource = SubjectOperation.GetAllSubjects();

            
        }

        public void Delete()
        {
            set();

            if (sujectclass.id == 0)
            {
                MessageBox.Show("لايوجد عنصر محدد لحذفه");
            }
            else
            {
                if (MessageBox.Show("تأكيد الحذف!!", "هل انت متاكد انك تريد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    SubjectClassOperation.SubClassDelete(sujectclass.Classid);
                    MessageBox.Show("تم الحذف بنجاح");
                    RefreshData();
                  
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
                    if (sujectclass.id == 0)
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
            SubjectClassOperation.AddSubClassData(sujectclass);
            MessageBox.Show("تم الاظافة بنجاح");
        }

        void Update()
        {
            SubjectClassOperation.UpdateSubClassData(sujectclass);
            MessageBox.Show("تم التحديث بنجاح");

        }

        int AutoNum()
        {
            return SubjectClassOperation.GetListClassSubjects().Count + 1;
        }

        //التحقق من الحقول ليست فارغة
        bool IsDataValid()
        {
            int errors = 0;
            if (view.lkpClass.Text.Trim() == string.Empty)
            {
                view.lkpClass.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            //if (view.lkpSubject.Text.Trim() == string.Empty)
            //{
            //    view.lkpSubject.ErrorText = "هذا الحقل مطلوب";
            //    errors += 1;
            //}

            return errors == 0;

        }
        bool IsExist()
        {
            //if (SubjectClassOperation.ExistItem(sujectclass.Classid,sujectclass.subjectid).Rows.Count > 0)
            //{
            //    MessageBox.Show("هذا العنصر مجود من قبل");
            //    return true;
            //}
            //else
                return false;
        }

    }
}
