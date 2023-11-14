using MySchool.FORMS;
using MySchool.Views.Interfaces;
using System;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using MySchool.Persenter;
using System.Windows.Forms;
using MySchool.Reports;

namespace MySchool.Views.FORMS
{
    public partial class FRM_AddGrades : FRM_Master, IGradesView
    {
        private int ID;
        
       GradesPersenter gradepersenter;

        #region My Property
        public GridControl gridcontrol
        {
            get
            {
                return gridControl1;
            }
        }
        public GridControl gridcontrolTest
        {
            get
            {
                return gridControl2;
            }
        }
        public GridView gridview
        {
            get
            {
                return gridView1;
            }
        }

        public int id
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

        public LookUpEdit lkpclass
        {
            get
            {
                return lokclass;
            }
        }

        public LookUpEdit lkpexam
        {
            get
            {
                return lokexam;
            }
        }

        public LookUpEdit lkpterm
        {
            get
            {
                return lokterm;
            }
        }

        public LookUpEdit lkpyear
        {
            get
            {
                return lokyear;
            }
        }

        public LookUpEdit lkpsubject
        {
            get
            {
                return loksubject;
            }
        }

        public Label LblTitel1
        {
            get
            {
                return label1;
            }
        }
        public Label LblTitel2
        {
            get
            {
                return label2;
            }
        }
        public Label LblTitel3
        {
            get
            {
                return label3;
            }
        }
        public Label LblTitel4
        {
            get
            {
                return label4;
            }
        }
        public LookUpEdit lkpStudent
        {
            get
            {
                return lokstud;
            }
        }

        public TextEdit txeSubject
        {
            get
            {
                return txtsub;
            }
        }

        public SpinEdit spnMark
        {
            get
            {
               return  spnmark;
            }
        }

        public ListBoxControl ListStud
        {
            get
            {
                return lstStudent;
            }
        }

        #endregion
        public FRM_AddGrades()
        {
            InitializeComponent();
            gradepersenter = new Persenter.GradesPersenter(this);
            btn_print.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

      
        private void FRM_AddGrades_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        public override void New()
        {
            gradepersenter.New();

        }
        public override void Save()
        {
            gradepersenter.Save();
        }
        public override void Delete()
        {
            gradepersenter.Delete();
        }
        public override void Print()
        {
            rpt_Results1 rpt = new Reports.rpt_Results1(Convert.ToInt32( lokyear.EditValue), Convert.ToInt32(lokterm.EditValue), Convert.ToInt32(lokclass.EditValue));
            rpt.Print();
            base.Print();
        }
        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        //public void accdbdatabases(DataGridView dgvtable, string Provider1)
        //{
        //    dgvtable.Rows.Clear();
        //    OleDbConnection conn = new OleDbConnection(Provider1);
        //    DataTable dt = new DataTable();
        //    conn.Open();
        //    dt = conn.GetSchema("Tables");
        //    int i = 0;
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        if (row["TABLE_TYPE"].ToString() == "TABLE" || row["TABLE_TYPE"].ToString() == "VIEW")
        //        {
        //            dgvtable.Rows.Add();
        //            dgvtable[0, i].Value = row["TABLE_NAME"].ToString();
        //            dgvtable[1, i].Value = row["TABLE_TYPE"].ToString();
        //            i += 1;
        //        }

        //    }
        //}
        //public override void Save()
        //{
        //    string filepath;
        //    OpenFileDialog ofd = new OpenFileDialog();
        //    ofd.InitialDirectory = "E:\\";
        //    if (ofd.ShowDialog()==DialogResult.OK)
        //    {//" + passwordtxt.Text + "
        //        string Provider = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + ofd.FileName + ";Jet OLEDB:Database Password=;";
        //        accdbdatabases(dataGridView1, Provider);





        //        //filepath = ofd.FileName;
        //        //    ExcelImporter Er = new ExcelImporter();
        //        //    foreach (string item in Er.GetWorksheetNames(filepath))
        //        //    {
        //        //        checkedListBox1.Items.Add(item);
        //        //    }

        //    }
    }
    
}
