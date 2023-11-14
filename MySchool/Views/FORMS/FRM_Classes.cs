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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using MySchool.Persenter;

namespace MySchool.FORMS
{
    public partial class FRM_Classes : FRM_Master,IClassView
    {
        ClassPersenter classpersenter;
        private int Classid;
        #region Property
        public int ClassID
        {
            get
            {
                return Classid;
            }

            set
            {
                Classid = value;
            }
        }

        public TextEdit txtClass
        {
            get
            {
                return txtclass;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public LookUpEdit lkpLevel
        {
            get
            {
                return cmblevel;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public GridView gridview
        {
            get
            {
                return gridView1;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public GridControl gridcontrol
        {
            get
            {
                return gridControl1;
            }

            set
            {
                throw new NotImplementedException();
            }
        }


        #endregion

        //ClassesManger classesManger;
        //LevelsManger levelManger;
        //ClassStudy class1;
        //Level level;
        public FRM_Classes()
        {
            InitializeComponent();
            classpersenter = new ClassPersenter(this);
            New();
            fillCombo();
            //cmblevel.Focus();
            LoadDataInDataGridViwe();
        }
        public override void Save()
        {
            classpersenter.Save();
            //SetData();
            //if (class1.levelid == 0)
            //{
            //    cmblevel.ErrorText = "لابد أن تختار المرحلة الدراسية .."; return;
            //}
            //if (class1.ClassName == string.Empty)
            //{
            //    txtclass.ErrorText = "هذا الحقل يجب ان تكتب فيه الصف الدراسي .."; return;
            //}
            //if (IsNotExist(class1.ClassName, class1.levelid))
            //{
            //    classesManger.InsertClassStudy(class1);
            //    classesManger.SaveChengs();
            base.Save();
            //    New();
            //    LoadDataInDataGridViwe();
            //}
            //else
            //{
            //    MessageBox.Show("هذا الصف موجود مسبقا !!");
            //    txtclass.Focus();
            //}
        }
        public override void New()
        {
            classpersenter.New();
            //class1 = new ClassStudy();
            //level = new Level();
            ////cmblevel.EditValue = null;
            ////cmblevel.SelectedText = null;
            //GetData();
            //base.New();
        }
        public override void GetData()
        {
            //    cmblevel.EditValue = class1.levelid;
            //    txtclass.Text = class1.ClassName;
            //    base.GetData();
        }
        public override void SetData()
        {
            //class1.levelid = (cmblevel.EditValue as int?)??0;
            
            //class1.ClassName = txtclass.Text;
           
            //base.SetData();
        }
        public void getEndItem()
        {
            //class1.ClassID=classesManger.GetEndData().ClassID;
            //class1.ClassName = classesManger.GetEndData().ClassName;
        }
        public override void Delete()
        {
            classpersenter.Delete();
            //if (class1.ClassID!=0)
            //{
            //    if (MessageBox.Show("هل حقا تريد حذف هذا الصف الدراسي ..","تأكيد الحذف!",MessageBoxButtons.YesNo,MessageBoxIcon.Stop)==DialogResult.Yes)
            //    {
            //        classesManger.DeletClass(class1);
            //        base.Delete();
            //        New();
            //        LoadDataInDataGridViwe();
            //    }

            //}

        }
        public bool IsNotExist(string cls, int lvl)
        {
            bool isnotexist = true;
            //if (classesManger.ClassIsExist(cls, lvl).Rows.Count > 0)
            //{
            //    isnotexist = false;
            //}
            return isnotexist;
        }
        public void fillCombo()
        {
            //cmblevel.Properties.DataSource = levelManger.GetAllLevels();
            //cmblevel.Properties.DisplayMember = levelManger.GetAllLevels().Columns[1].ToString();
            //cmblevel.Properties.ValueMember= levelManger.GetAllLevels().Columns[0].ToString();
            //cmblevel.EditValue = null;
        }
        public override void LoadDataInDataGridViwe()
        {
           //gridControl1.DataSource = classesManger.GetAllClass();
           // gridView1.Columns["class_name"].Caption = "اسم الصف الدراسي :";
           // gridView1.Columns["level_name"].Caption = "اسم المرحلة الدراسية :";
           // gridView1.Columns[0].Visible = false;
           // gridView1.Columns[2].Visible = false;
           // base.LoadDataInDataGridViwe();
        }

        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            //New();
            //class1.ClassID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("class_id"));
            //class1.ClassName = gridView1.GetFocusedRowCellValue("class_name").ToString();
            //class1.levelid = Convert.ToInt32(gridView1.GetFocusedRowCellValue("level_id"));
            //class1.levelname = gridView1.GetFocusedRowCellValue("level_name").ToString();
           
            //GetData();
        }

        private void FRM_Classes_Load(object sender, EventArgs e)
        {
            //gridView1.OptionsBehavior.Editable = false;
            //cmblevel.Properties.PopulateColumns();
            //cmblevel.Properties.Columns[0].Visible = false;
        }
    }
}
