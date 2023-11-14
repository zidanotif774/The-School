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
    class TermInYearPersenter
    {

        TermInYear terminyear;
        ITermInYearView view;
        List<Term> termList;


        public TermInYearPersenter(ITermInYearView view)
        {
            this.view = view;
            New();

            view.gridview.RowClick += Gridview_RowClick;
            view.lkpYear.EditValueChanged += LkpClass_EditValueChanged;

            view.lkpYear.Properties.DataSource = YearsOperation.GetAllyears();
            view.lkpYear.Properties.DisplayMember = "year_name";
            view.lkpYear.Properties.ValueMember = "year_id";



            view.checkListTerm.DisplayMember ="term_name";
            view.checkListTerm.ValueMember = "term_id";

            RefreshData();
        }

        private void LkpClass_EditValueChanged(object sender, EventArgs e)
        {
            New();
            terminyear = new TermInYear();
            terminyear.year_id = (view.lkpYear.EditValue as int?) ?? 0;
            terminyear = TermInYearOperation.GetListTermsInYear().Where(y => y.year_id == terminyear.year_id).SingleOrDefault();

            if (terminyear != null)
            {
                foreach (Term term in terminyear.TermList)
                {

                    {
                        view.checkListTerm.SelectedValue = term.id;
                        view.checkListTerm.CheckSelectedItems();
                        view.id = terminyear.id;
                    }
                }
            }
        }

        private void Gridview_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            New();
            view.id = Convert.ToInt32(view.gridview.GetFocusedRowCellValue("ClSu_id"));
            view.lkpYear.EditValue = view.gridview.GetFocusedRowCellValue("classe_id");

        }



        void RefreshData()
        {

            view.gridcontrol.DataSource = TermInYearOperation.GetListTermsInYear();
            New();
            get();
        }
        void set()
        {
            terminyear = new TermInYear();
            terminyear.id = view.id;
            terminyear.year_id = (view.lkpYear.EditValue as int?) ?? 0;
            foreach (var item in view.checkListTerm.CheckedItems)
            {
                termList.Add(new Term
                {
                    id = Convert.ToInt32(view.checkListTerm.GetItemValue(view.checkListTerm.FindItem(item))),
                    Term_name = view.checkListTerm.GetItemText(view.checkListTerm.FindItem(item))
                    //Classid = ,
                    //subid =Convert.ToInt32( view.SubListbox.GetItemValue (view.SubListbox.FindItem(item)) ),
                    //subName= view.SubListbox.GetItemText(view.SubListbox.FindItem(item))
                });
            }
            terminyear.TermList = termList;
        }

        public void get()
        {
            view.id = terminyear.id;
            view.lkpYear.EditValue = terminyear.year_id;

        }

        public void New()
        {
            termList = new List<Models.Term>();
            terminyear = new TermInYear();
            //subclassList = new List<SubjectClass>();
            view.checkListTerm.DataSource = TermOperation.GetAllterms();


        }

        public void Delete()
        {
            set();

            if (terminyear.id == 0)
            {
                MessageBox.Show("لايوجد عنصر محدد لحذفه");
            }
            else
            {
                if (MessageBox.Show("تأكيد الحذف!!", "هل انت متاكد انك تريد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    TermInYearOperation.termInYearDelete(terminyear);
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
                    if (terminyear.id == 0)
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
            TermInYearOperation.AddTermInYearData(terminyear);
            MessageBox.Show("تم الاظافة بنجاح");
        }

        void Update()
        {
            TermInYearOperation.UpdateTermInYearData(terminyear);
            MessageBox.Show("تم التحديث بنجاح");

        }

        //int AutoNum()
        //{
        //    return SubjectClassOperation.GetListClassSubjects().Count + 1;
        //}

        //التحقق من الحقول ليست فارغة
        bool IsDataValid()
        {
            int errors = 0;
            if (view.lkpYear.Text.Trim() == string.Empty)
            {
                view.lkpYear.ErrorText = "هذا الحقل مطلوب";
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
