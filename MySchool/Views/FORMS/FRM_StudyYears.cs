using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySchool.Views.Interfaces;
using MySchool.Persenter;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace MySchool.FORMS
{
    public partial class FRM_StudyYears : FRM_Master, IYearView
    {
      
        YearPersenter persenter=null;
        private int ID;


        #region Properties

        public int YearID
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

        public TextEdit txeyearname
        {
            get
            {
                return txtYearName;
            }
        }

        public GridControl gridcontrol
        {
            get
            {
               return grc;
            }
        }

        public GridView gridview
        {
            get
            {
                return gridView1;
            }
        }

        public CheckEdit checkActive
        {
            get
            {
                return checkEdit1;
            }
        }
        #endregion



        public FRM_StudyYears()
        {
            InitializeComponent();

            persenter = new YearPersenter(this);
        }

        //private void GridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        //{
        //    //selectedrowevent.Invoke(this, EventArgs.Empty);
        //    //Year.YearID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("year_id").ToString());
        //    //year.yearname = gridview1.getfocusedrowcellvalue("year_name").tostring();
        //    //GetData();

        //    //MessageBox.Show(e.RowHandle.ToString());
        //    DataRow tb = gridView1.GetDataRow(e.RowHandle);

        //    _SelectedRow = tb.Table;
        //    persenter.selectedrow();
        //}




        //New();
        //          LoadDataInDataGridViwe();       

        public override void Save()
        {
            persenter.Save();
            //SetData();
            //if (Year.YearName != string.Empty)
            //{
            //    if (IsNotExist(Year.YearName.Trim()))
            //    {
            //        YearsManger.InsertYearStudy(Year);
            //        YearsManger.SaveChengs();
            //        New();
            //        base.Save();

            //        YearEnd();
            //        LoadDataInDataGridViwe();
            //    }
            //    else MessageBox.Show("هذا العام موجود مسبقا !!");
            //}
            base.Save();
        }
        public override void New()
        {
            persenter.New();
            //Year = new Year();
            //GetData();
            //txtYearName.Focus();
            //base.New();
        }
        public override void GetData()
        {
            //txtYearName.Text = Year.YearName;
            //base.GetData();
        }
        //public override void SetData()
        //{
        //   Year.YearName  = txtYearName.Text;
        //    base.SetData();
        //}
        //public void YearEnd()
        //{
        //    Year.YearID = YearsManger.GetEndData().YearID;
        //    Year.YearName = YearsManger.GetEndData().YearName;

        //}
        //public void Refreshe()
        //{
        //    LoadDataInDataGridViwe();
        //}
        //public override void LoadDataInDataGridViwe()
        //{
        //    grc.DataSource = YearsManger.GetAllyears();
        //    base.LoadDataInDataGridViwe();
        //}
        //public override void CLose()
        //{
        //    base.CLose();
        //}
        //public bool IsNotExist(string year)
        //{
        //    bool isnotexist = true;
        //    if (YearsManger.YearIsExist(year).Rows.Count>0)
        //    {
        //        isnotexist = false;
        //    }return isnotexist;
        //}
        public override void Delete()
        {
            persenter.Delete();
            //if (Year.YearID == 0)
            //{
            //    MessageBox.Show("العنصر المراد حذفه غير موجود ");
            //    return;
            //}
            //if (MessageBox.Show("هل تريد الحذف فعلا !!", "تأكيدالحذف ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //{
            //    YearsManger.DeletYear(Year);
            //    base.Delete();
            //    New();
            //    Refreshe();
            //}
        }

        public void SetStudentBindingSource(BindingSource studentlist)
        {
            grc.DataSource = studentlist;
        }

        private void FRM_StudyYears_Load(object sender, EventArgs e)
        {

        }

        //private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        //{
        //    // ((DataRow) sender).


        //    //New();
        //    //Year.YearID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("year_id").ToString());
        //    //Year.YearName = gridView1.GetFocusedRowCellValue("year_name").ToString();
        //    //GetData();

        //}



        //private void FRM_StudyYears_Load(object sender, EventArgs e)
        //{
        //    gridView1.OptionsBehavior.Editable = false;
        //    gridView1.Columns[1].Visible = false;


    }
}
