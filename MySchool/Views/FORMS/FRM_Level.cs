using System;
using MySchool.Views.Interfaces;
using DevExpress.XtraGrid.Views.Grid;
using MySchool.Persenter;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace MySchool.FORMS
{
    public partial class FRM_Level : FRM_Master,ILevelView
    {
        int ID;
        LevelPersenter levelpersenter;
        #region Property
        int ILevelView.ID
        {
            get
            {
                return ID;
            }

            set
            {
                ID = value;
            }
        }

        public TextEdit Level
        {
            get
            {
                return txtlevel;
            }
        }

        public GridControl GridControl1
        {
            get
            {
                return gridControl1;
            }
        }

        public GridView gridview
        {
            get
            {
                return gridView1;
            }
        }
     



        #endregion

        //LevelsManger levelmanger;
        //Level level;
        public FRM_Level()
        {
            InitializeComponent();
            levelpersenter = new LevelPersenter(this);
            this.Load += FRM_Level_Load;
            New();
            refresh();
        }

        private void FRM_Level_Load(object sender, EventArgs e)
        {
            //gridView1.OptionsBehavior.Editable = false;
            //gridView1.Columns[0].Visible=false;
            //gridView1.Columns[1].Caption = "المرحلة الدراسية ";
        }

        public override void New()
        {
            levelpersenter.New();
            //level = new Level();
            //GetData();
            //base.New();
        }
        public override void Save()
        {
            levelpersenter.Save();
       //public void dataaccesslayer_sql()
       // {
            //sqlcon = new SqlConnection(@"Data Source=DESKTOP-574FDII\LOCALSERVERDB;Integrated Security=True;  database=eramodel;");
            //sqlcon.Open();
            //// }


            //if (txtlevel.Text!=string.Empty)
            //{
            //    SetData();
            //if (IsNotExist(txtlevel.Text.Trim()))
            //{
            //    levelmanger.InsertLevelStudy(level);
            //    levelmanger.SaveChengs();
            //        New();
            //    base.Save();
            //    refresh();
            //}
            //else MessageBox.Show("هذه المرحلة موجودة مسبقا ...");
            //    txtlevel.Focus();
            //}
        }
        public override void GetData()
        {
            //txtlevel.Text = level.LevelName;
            //base.GetData();
        }
        public override void SetData()
        {
            //level.LevelName = txtlevel.Text;
            //base.SetData();
        }
        public override void Delete()
        {

            levelpersenter.Delete();
            //if (level.LevelID!=0)
            //{
            //    if (MessageBox.Show("هل تريد الحذف فعلا !!!","تأكيد الحذف ",MessageBoxButtons.YesNo,MessageBoxIcon.Stop)==DialogResult.Yes )
            //    {
            //        levelmanger.DeletLevel(level);
            //         base.Delete();
            //        refresh();
            //        New();
            //    }
               
            //}
            
        }
        public bool IsNotExist(string levelname)
        {
            bool isnotExist = true;
            //if (levelmanger.LevelIsExist(levelname).Rows.Count>0)
            //{
            //    isnotExist = false;
            //}
            return isnotExist;
        }
      
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //if (gridView1.GetFocusedRowCellValue("level_id").ToString() != null)
            //{
            //    level.LevelID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("level_id"));
            //    level.LevelName = gridView1.GetFocusedRowCellValue("level_name").ToString();
            //    GetData();
            //}
        }
       public void refresh()
        {
            //gridControl1.DataSource = levelmanger.GetAllLevels();
        }
        public void getEndItem()
        {
            //level.LevelID = levelmanger.GetEndData().LevelID;
            //level.LevelName = levelmanger.GetEndData().LevelName;

        }

      
    }
}
