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
    class YearPersenter
    {
        Year year;
        IYearView view;
        public YearPersenter(IYearView view)
        {
            this.view = view;
            view.gridview.RowClick += Gridview_RowClick;
            New();
            RefreshData();
        }

        private void Gridview_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            New();
            bool Act = false;
            view.YearID = Convert.ToInt32(view.gridview.GetFocusedRowCellValue("year_id"));
            view.txeyearname.Text = view.gridview.GetFocusedRowCellValue("year_name").ToString();
            Act=( view.gridview.GetFocusedRowCellValue("IsActive") as bool ?)??false;
            view.checkActive.Checked = Act;

        }



        void RefreshData()
        {
            //YearList = YearsOperation.GetAllyears();
            New();
            view.gridcontrol.DataSource = YearsOperation.GetAllyears();
        }
        void set()
        {
            year.YearID = view.YearID;
            year.YearName = view.txeyearname.Text;
            year.YearActive = view.checkActive.Checked;
        }

        void get()
        {
            view.YearID = year.YearID;
            view.txeyearname.Text = year.YearName;
            view.checkActive.Checked = year.YearActive;
        }

        public void New()
        {
            year = new Year();
            //year.YearID = AutoNum();
            get();
        }

        public void Delete()
        {
            set();
           
                if (year.YearID == 0)
                {
                    MessageBox.Show("لايوجد عنصر محدد لحذفه");
                }
                else
                {
                    if (MessageBox.Show("تأكيد الحذف!!", "هل انت متاكد انك تريد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        YearsOperation.YearDataDelete(year.YearID);
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

                if (year.YearID == 0)
                {
                    if (!IsExist())
                    {
                        Add();
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
            YearsOperation.AddYearData(year.YearName, year.YearActive);
            MessageBox.Show("تم الاظافة بنجاح");
        }

        void Update()
        {
            YearsOperation.UpdateYearData(year.YearID, year.YearName, year.YearActive);
            MessageBox.Show("تم التحديث بنجاح");

        }

        int AutoNum()
        {
            return YearsOperation.GetAllyears().Rows.Count + 1;
        }

        //التحقق من الحقول ليست فارغة
        bool IsDataValid()
        {
            int errors = 0;
           
            if (view.txeyearname.Text.Trim()==string.Empty)
            {
                view.txeyearname.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            return errors == 0;

        }
        bool IsExist()
        {
            if (YearsOperation.ExistItem(year.YearName).Rows.Count>0)
            {
                MessageBox.Show("هذا العنصر مجود من قبل");
                return true;
            }else return false;
        }
    }
}
