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
    class SubjectPersenter
    {

        
            Subject suject;
            ISubjectView view;
            BindingSource studentbindingsource;
      
            public SubjectPersenter(ISubjectView view)
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
                view.id = Convert.ToInt32(view.gridview.GetFocusedRowCellValue("id"));
                view.txtSubject.Text = view.gridview.GetFocusedRowCellValue("name").ToString();

            }



            void RefreshData()
            {
                //YearList = YearsOperation.GetAllyears();
                New();
            view.gridcontrol.DataSource = SubjectOperation.GetAllSubjects();
            }
            void set()
            {
                suject.id = view.id;
                suject.name = view.txtSubject.Text;
            }

            void get()
            {
                view.id = suject.id;
                view.txtSubject.Text = suject.name;
            }

            public void New()
            {
                suject = new Subject();
                //year.YearID = AutoNum();
                get();
            }

            public void Delete()
            {
                set();

                if (suject.id == 0)
                {
                    MessageBox.Show("لايوجد عنصر محدد لحذفه");
                }
                else
                {
                    if (MessageBox.Show("تأكيد الحذف!!", "هل انت متاكد انك تريد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        SubjectOperation.SubjectDelete(suject.id);
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
                        if (suject.id == 0)
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
                SubjectOperation.AddSubject(suject.name);
                MessageBox.Show("تم الاظافة بنجاح");
            }

            void Update()
            {
                SubjectOperation.UpdateSubjectData(suject.id, suject.name);
                MessageBox.Show("تم التحديث بنجاح");

            }

            //int AutoNum()
            //{
            //    return SubjectOperation.GetAllSubjects().Count + 1;
            //}

            //التحقق من الحقول ليست فارغة
            bool IsDataValid()
            {
                int errors = 0;
                if (view.txtSubject.Text.Trim()==string.Empty)
                {
                    view.txtSubject.ErrorText = "هذا الحقل مطلوب";
                    errors += 1;
                }
                
                return errors == 0;

            }
            bool IsExist()
            {
                if (SubjectOperation.ExistItem(suject.name).Rows.Count > 0)
                {
                    MessageBox.Show("هذا العنصر مجود من قبل");
                    return true;
                }
                else
                    return false;
            }
        
    }
}
