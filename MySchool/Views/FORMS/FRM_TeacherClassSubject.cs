using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using MySchool.Persenter;
using MySchool.Views.Interfaces;


namespace MySchool.FORMS
{
    public partial class FRM_TeacherClassSubject: FRM_Master, ITeacherSubjectClassView
    {
        private int ID;
        TeacherSubjectClassPersenter teachsubjclasspers;
        #region property
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
        public LookUpEdit lokyear
        {
            get
            {
                return lkpyear;
            }
        }
        public LookUpEdit lkpteach
        {
            get
            {
                return lookUpEdit1;
            }
        }

        SimpleButton ITeacherSubjectClassView.btnAddSubject
        {
            get
            {
                return btnAddSubject;
            }
        }

        public TreeList tlsubject
        {
            get
            {
                return treeList1;
            }
        }
     
        public GridControl gridcontrol
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
                return gridView2;
            }
        }

        #endregion
        //TeacherSubjectClassManger teachSubClass;

        //List<int > Teachsubjectsclassid;
        //int selectednode = 0;
        public FRM_TeacherClassSubject()
        {
            InitializeComponent();
            teachsubjclasspers = new Persenter.TeacherSubjectClassPersenter(this);
            New();
            fillCombo();
            LoadDataInDataGridViwe();
        }

        public override void Save()
        {
            teachsubjclasspers.Save();
            //Teachsubjectsclassid = new List<int>();
            //SetData();
            //foreach (int t in Teachsubjectsclassid)
            //{
            //    teachSubClass._subjectclassId = t;
            //    teachSubClass._TeacherId = (int)lokTeach.EditValue;
            //    if (IsValid())
            //    {
            //        teachSubClass.SaveChengs();
            //    }
            //    else return;
            //}
            //base.Save();
            //New();
            //LoadDataInDataGridViwe();
        }
        public override void New()
        {
            teachsubjclasspers.New();
            //teachSubClass = new TeacherSubjectClassManger();
            // Teachsubjectsclassid = new List<int>();
            //GetData();
        }
        public override void GetData()
        {
            //lokTeach.EditValue = teachSubClass._TeacherId;
            //treeList1.UncheckAll();
            //base.GetData();
        }
    public override void SetData()
        {
            //    foreach (TreeListNode n in treeList1.GetAllCheckedNodes())
            //    {
            //        selectednode =(int)n.GetValue("ClSu_id");
            //         Teachsubjectsclassid.Add(selectednode);
            //    }
            //    base.SetData();
        }
        public void getEndItem()
        {
            
        }
        public override void Delete()
        {
            teachsubjclasspers.Delete();
            //foreach (int i in gridView2.GetSelectedRows())
            //{
            //    Teachsubjectsclassid.Add(Convert.ToInt32(gridView2.GetRowCellValue(i, "TeacherSubjectClass_id"))) ;
            //}
            //if (Teachsubjectsclassid.Count != 0)
            //{
            //    if (MessageBox.Show("هل حقا تريد حذف هذا  ..", "تأكيد الحذف!", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            //    {
            //        foreach (int t in Teachsubjectsclassid)
            //        {
            //            teachSubClass._teachsubclasseId = t;
            //                teachSubClass.DeletTeachClassSubject();
            //        }
            //        base.Delete();
            //        New();
            //        LoadDataInDataGridViwe();
            //    }
            //}

        }
        public bool IsValid()
        {
            //if (teachSubClass._TeacherId == 0)
            //{
            //    lokTeach.ErrorText = "اختيار المعلم مطلوب "; lokTeach.Focus(); return false;
            //}
            //if (teachSubClass._subjectclassId == 0)
            //{
            //    return false;
            //}
            //if (teachSubClass.TeachClassSubjecIsExist().Rows.Count != 0)
            //{
            //    MessageBox.Show("هذه المادة موجودة مسبقا في هذا الصف ");  return false;
            //}
            return true;
        }
        public void fillCombo()
        {
            //TeacherManger TeachMang = new TeacherManger();
            //SubjectClassManger SubclassMang = new SubjectClassManger();

            //lokTeach.Properties.DataSource = TeachMang.GetAllTeacher ();
            //lokTeach.Properties.DisplayMember = TeachMang.GetAllTeacher().Columns[3].ToString();
            //lokTeach.Properties.ValueMember = TeachMang.GetAllTeacher().Columns[0].ToString();
            
            //treeList1.DataSource = SubclassMang.GetAllClassSubjects();
            //treeList1.ParentFieldName = "classe_id";
            //treeList1.KeyFieldName = "ClSu_id";
            
            //treeList1.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
        }
        public override void LoadDataInDataGridViwe()
        {
            //try
            //{
            //    gridControl2.DataSource = teachSubClass.GetAllTeacherClassSubjects();
            //    gridView2.OptionsSelection.ShowCheckBoxSelectorChangesSelectionNavigation = DevExpress.Utils.DefaultBoolean.True;
            //    base.LoadDataInDataGridViwe();
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message);}
        }
        //New();
        //subClassManger._subjectclassId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ClSu_id"));
        //subClassManger._classeId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("classe_id"));
        //subClassManger._SubjectId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("sub_id"));
        //GetData();
      

        private void FRM_Classes_Load(object sender, EventArgs e)
        {
            //lokTeach.Properties.PopulateColumns();
            //lokTeach.Properties.Columns[0].Visible = false;
            //lokTeach.Properties.Columns[1].Visible = false;
            //lokTeach.Properties.Columns[2].Visible = false;
            //lokTeach.Properties.Columns[4].Visible = false;
            //lokTeach.Properties.Columns[5].Visible = false;
            //lokTeach.Properties.Columns[6].Visible = false;
            //lokTeach.Properties.Columns[7].Visible = false;
            //lokTeach.Properties.Columns[8].Visible = false;

            //CheckGridVeiw();

            //gridView2.Columns[0].Visible = false;
            //gridView2.Columns[1].Visible = false;
            //gridView2.Columns[2].Visible = false;
            //gridView2.Columns[3].Visible = false;
            //gridView2.Columns[4].Visible = false;
        }


            //SetData();
            //if (teachSubClass._TeacherId == 0)
            //{
            //    lokTeach.ErrorText = "اختر المعلم اولا "; return;
            //}
            //if (Convert.ToInt32(gridView1.GetFocusedRowCellValue("ClSu_id")) != 0)
            //{
            //    teachSubClass._subjectclassId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ClSu_id"));
            //    int count = teachSubClass.TeachClassSubjecIsExist().Rows.Count;
            //    if (count == 0)
            //    {
            //        if (!Teachsubjectsclassid.Contains(teachSubClass))
            //        {
            //            Teachsubjectsclassid.Add(teachSubClass);
            //        }
                   
            //    }
            //}
     
        void CheckGridVeiw()
        {
            //gridView2.OptionsSelection.MultiSelect = true;
            //gridView2.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
        }

        private void treeList1_AfterCheckNode(object sender, NodeEventArgs e)
        {

        }
    }
}
