using MySchool.Views.Interfaces;
using MySchool.BSL;
using MySchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MySchool.Persenter
{
    class TeacherPersenter
    {
        Teacher teacher;
        ITeacherView view;

        public TeacherPersenter(ITeacherView view)
        {
            this.view = view;
            InitializeControl();
            view.gridview.RowClick += Gridview_RowClick;
            RefreshData();
            InitializeControl();
        }

        private void Gridview_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            New();
            teacher.Teach_id = Convert.ToInt32(view.gridview.GetFocusedRowCellValue("teach_id"));
            teacher.Teach_name = view.gridview.GetFocusedRowCellValue("teach_name_").ToString();
            teacher.isactive =Convert.ToBoolean( view.gridview.GetFocusedRowCellValue("isActive"));
            teacher.Teach_sex = Convert.ToInt32(view.gridview.GetFocusedRowCellValue("Teacher_sex"));
            teacher.Teach_major = view.gridview.GetFocusedRowCellValue("major").ToString();
            teacher.Teach_PhonNum = view.gridview.GetFocusedRowCellValue("phone").ToString();
            teacher.Teach_CardNum = view.gridview.GetFocusedRowCellValue("Teacher_CardNum").ToString();
            get();
        }

        void InitializeControl()
        {
            //view.lkpyear.Properties.DataSource = YearsOperation.GetAllyears();
            //view.lkpyear.Properties.DisplayMember = YearsOperation.GetAllyears().Columns[1].ToString();
            //view.lkpyear.Properties.ValueMember = YearsOperation.GetAllyears().Columns[0].ToString();
            ////lookcolumn(view.lkpname);
            //view.lkpname.Properties.DataSource = TeacherOperation.GetAllTeachers();
            //view.lkpname.Properties.DisplayMember = TeacherOperation.GetAllTeachers().Columns[3].ToString();
            //view.lkpname.Properties.ValueMember = TeacherOperation.GetAllTeachers().Columns[0].ToString();
            


            //view.lkpname.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            view.lkpsex.Properties.DataSource = new List<TeacherSex>()
            {
                new TeacherSex() {Id=1,Teach_sex="ذكر" },
                new TeacherSex() {Id=2,Teach_sex="انثى" }
            };
            view.lkpsex.Properties.DisplayMember = "Teach_sex";
            view.lkpsex.Properties.ValueMember = "Id";

            view.gridview.OptionsBehavior.Editable = false;
            //view.gridview.PopulateColumns();
            //view.gridview.Columns["teach_id"].Visible = false;
            //view.gridview.Columns["year_id"].Visible = false;
            //view.gridview.Columns["teach_name_"].Caption = "";
            //view.gridview.Columns["Teacher_sex"].Caption = "";
            //view.gridview.Columns["major"].Caption = "";
            //view.gridview.Columns["phone"].Caption = "";
            //view.gridview.Columns["Teacher_CardNum"].Caption = "";



        }
        //void lookcolumn(LookUpEdit lkp)
        //{
        //    lkp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo
        //    {
        //        FieldName = "teach_id",
        //        Caption="سس",
        //        Visible=false
        //    }
        //        );
        //    lkp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo
        //    {
        //        FieldName = "teach_name_",
        //        Caption = "اسم المعلم",
        //        Visible = true
        //    }
        //        );
        //}

        void RefreshData()
        {
            view.gridcontrol.DataSource = TeacherOperation.GetAllTeachers();
            New();
            get();
        }
        void set()
        {
            teacher.Teach_id = view.teach_id;
            teacher.Teach_name = view.txename.Text;
            teacher.isactive = view.isActive.Checked;
            teacher.Teach_sex = (view.lkpsex.EditValue as int?) ?? 0;
            teacher.Teach_major = view.txtmajor.Text;
            teacher.Teach_PhonNum = view.txtteach_phonnum.Text;
            teacher.Teach_CardNum = view.txtcardnum.Text;
        }

      public  void get()
        {
            view.teach_id = teacher.Teach_id;
            view.txename.Text   = teacher.Teach_name;
            view.isActive.Checked = teacher.isactive;
            //if (teacher.isactive)
            //{
            //    view.isActive.CheckState =CheckState.Checked ; 
            //}
            view.lkpsex.EditValue  = teacher.Teach_sex;
            view.txtmajor.Text = teacher.Teach_major;
            view.txtteach_phonnum.Text = teacher.Teach_PhonNum;
            view.txtcardnum.Text = teacher.Teach_CardNum;
        }
        public void New()
        {
            teacher = new Teacher();
            
        }

        public void Delete()
        {
            set();

            if (teacher.Teach_id == 0)
            {
                MessageBox.Show("لايوجد عنصر محدد لحذفه");
            }
            else
            {
                if (MessageBox.Show("تأكيد الحذف!!", "هل انت متاكد انك تريد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    TeacherOperation.TeacherDelete(teacher.Teach_id);
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

                if (teacher.Teach_id == 0)
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
            TeacherOperation.AddTeacher(teacher.isactive, teacher.Teach_name,teacher.Teach_sex,teacher.Teach_major,teacher.Teach_PhonNum,teacher.Teach_CardNum);
            MessageBox.Show("تم الاظافة بنجاح");
        }

        void Update()
        {
            TeacherOperation.UpdateDataTeacher( teacher.Teach_id, teacher.isactive, teacher.Teach_name, teacher.Teach_sex, teacher.Teach_major, teacher.Teach_PhonNum, teacher.Teach_CardNum);
            MessageBox.Show("تم التحديث بنجاح");

        }

        int AutoNum()
        {
            return TeacherOperation.GetAllTeachers().Rows.Count + 1;
        }

        //التحقق من الحقول ليست فارغة
        bool IsDataValid()
        {
            int errors = 0;
            if (view.txtmajor.Text.Trim() == string.Empty)
            {
                view.txtmajor.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            if (view.txename.Text == null)
            {
                view.txename.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
          
            if (view.lkpsex.EditValue == null)
            {
                view.lkpsex.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            return errors == 0;

        }
        bool IsExist()
        {
            if (TeacherOperation.ExistItem(teacher.Teach_name).Rows.Count > 0)
            {
                MessageBox.Show("هذا العنصر مجود من قبل");
                return true;
            }
            else
                return false;
        }
        public class TeacherSex
        {
            public int Id { get; set; }
            public string Teach_sex { get; set; }
        }
    }
}
