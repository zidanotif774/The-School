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
    class LevelPersenter
    {
        Level level;
        ILevelView view;
        BindingSource studentbindingsource;
        public LevelPersenter(ILevelView view)
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
            view.ID = Convert.ToInt32(view.gridview.GetFocusedRowCellValue("level_id"));
            view.Level.Text = view.gridview.GetFocusedRowCellValue("level_name").ToString();

        }



        void RefreshData()
        {
            //YearList = YearsOperation.GetAllyears();
            New();
            view.GridControl1.DataSource = LevelsOperations.GetAllLevel();
        }
        void set()
        {
            level.LevelID = view.ID;
            level.LevelName = view.Level.Text;
        }

        void get()
        {
            view.ID = level.LevelID;
            view.Level.Text = level.LevelName;
        }

        public void New()
        {
            level = new Level();
            //year.YearID = AutoNum();
            get();
        }

        public void Delete()
        {
            set();

            if (level.LevelID == 0)
            {
                MessageBox.Show("لايوجد عنصر محدد لحذفه");
            }
            else
            {
                if (MessageBox.Show("تأكيد الحذف!!", "هل انت متاكد انك تريد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    LevelsOperations.LevelDataDelete(level.LevelID);
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
                    if (level.LevelID == 0)
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
            LevelsOperations.AddLevelData(level.LevelName);
            MessageBox.Show("تم الاظافة بنجاح");
        }

        void Update()
        {
            LevelsOperations.UpdateLevelData(level.LevelID, level.LevelName);
            MessageBox.Show("تم التحديث بنجاح");

        }

        int AutoNum()
        {
            return LevelsOperations.GetAllLevel().Rows.Count + 1;
        }

        //التحقق من الحقول ليست فارغة
        bool IsDataValid()
        {
            int errors = 0;
            if (view.Level.Text.Trim()==string.Empty)
            {
                view.Level.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            //if (view.txtnameisempty)
            //{
            //    view.txtnameerrortext = "هذا الحقل مطلوب";
            //    errors += 1;
            //}
            return errors == 0;

        }
        bool IsExist()
        {
            if (LevelsOperations.ExistItem(level.LevelName).Rows.Count > 0)
            {
                MessageBox.Show("هذا العنصر مجود من قبل");
                return true;
            }
            else
                return false;
        }
    }
}

