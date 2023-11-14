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
    public partial class FRM_Term: FRM_Master, ITermView
    {

        TermPersenter persenter =null;
        private int no;

        public int No
        {
            get
            {
                return no;
            }

            set
            {
                no = value;
            }
        }

        public LookUpEdit lpkTermname
        {
            get
            {
                return lokterm;
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
        public CheckEdit isActive
        {
            get
            {
                return checkEdit1;
            }
        }

        //public RadioGroup group
        //{
        //    get
        //    {
        //        return radioGroup1;
        //    }
        //}
        //public ListBoxControl list
        //{
        //    get
        //    {
        //        return listBoxControl1;
        //    }
        //}
        #region Properties


        #endregion



        public FRM_Term()
        {
            InitializeComponent();

            persenter = new TermPersenter(this);
            btnnew.Enabled = false;
            btndelete.Enabled = false;
            
        }
        
         public override void Save()
        {
            persenter.Save();
           
            base.Save();
        }
        public override void New()
        {
            persenter.New();
          
        }
        public override void GetData()
        {
        }
       
        public override void Delete()
        {
            persenter.Delete();
           
        }

        public void SetStudentBindingSource(BindingSource studentlist)
        {
            grc.DataSource = studentlist;
        }

        private void FRM_StudyYears_Load(object sender, EventArgs e)
        {

        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
