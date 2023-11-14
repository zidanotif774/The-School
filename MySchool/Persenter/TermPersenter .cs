using MySchool.Views.Interfaces;
using MySchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySchool.BSL;

namespace MySchool.Persenter
{
    class TermPersenter 
    {
        Term term;
        ITermView view;
        public TermPersenter (ITermView view)
        {
            this.view = view;
            view.gridview.RowClick += Gridview_RowClick;
            New();
            //view.list.ContextButtonOptions.=
            RefreshData();
        }

        private void Gridview_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            New();
            view.No = Convert.ToInt32(view.gridview.GetFocusedRowCellValue("term_id"));
            view.lpkTermname.EditValue = view.gridview.GetFocusedRowCellValue("term_id");
            view .isActive.Checked= ( view.gridview.GetFocusedRowCellValue("IsActive") as bool ?)??false;
        }



        void RefreshData()
        {
            //YearList = YearsOperation.GetAllyears();
            New();
            view.gridcontrol.DataSource = TermOperation.GetAllterms();
            view.lpkTermname.Properties.DataSource = TermOperation.GetAllterms();
            view.lpkTermname.Properties.DisplayMember = "term_name";
            view.lpkTermname.Properties.ValueMember = "term_id";
            //view.list.DataSource= TermOperation.GetAllterms();
            //view.list.DisplayMember = "term_name";
            //view.list.ValueMember = "term_id";
        }
        void set()
        {
            term.id = (view.lpkTermname.EditValue as int ?)??0;
            term.Term_name = view.lpkTermname.Text;
            term.isActive = view.isActive.Checked;
            
        }

        void get()
        {
            view.No = term.No;
            view.lpkTermname.Text = term.Term_name;
            view.isActive.Checked = term.isActive;
        }

        public void New()
        {
            term = new Term();
            get();
        }

        public void Delete()
        {
            set();
           
                if (term.No == 0)
                {
                    MessageBox.Show("لايوجد عنصر محدد لحذفه");
                }
                else
                {
                    if (MessageBox.Show("تأكيد الحذف!!", "هل انت متاكد انك تريد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        TermOperation.TermDataDelete(term);
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

                if (term.id == 0)
                {
                    if (!IsExist())
                    {
                        //Add();
                    }
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
            TermOperation.AddTermData(term);
            MessageBox.Show("تم الاظافة بنجاح");
        }

        void Update()
        {
            TermOperation.UpdateTermData(term);
            MessageBox.Show("تم التحديث بنجاح");

        }

        
        //التحقق من الحقول ليست فارغة
        bool IsDataValid()
        {
            int errors = 0;
           
            if (view.lpkTermname.Text.Trim()==string.Empty)
            {
                view.lpkTermname.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            return errors == 0;

        }
        bool IsExist()
        {
            if (TermOperation.ExistItem(/*term*/).Rows.Count>0)
            {
                MessageBox.Show("هذا العنصر مجود من قبل");
                return true;
            }else return false;
        }
    }
}
