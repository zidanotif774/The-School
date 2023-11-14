using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using MySchool.BSL;
using MySchool.Models;
using MySchool.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySchool.Persenter
{
   public class TeacherSubjectClassPersenter
    {

        TeacherSubject teachSubjects;
        ITeacherSubjectClassView view;
        List<TreeListNode> listnode;
        List<Models.SubjectClass> listSubject;
        SubjectClass subsclass;
       List< Subject> sublist;
        public TeacherSubjectClassPersenter(ITeacherSubjectClassView view)
        {
            this.view = view;
          
            InitializeControl();
            listnode = new List<TreeListNode>();
            New();
            view.gridview.RowClick += Gridview_RowClick;
            view.lokyear.EditValueChanged += Lokyear_EditValueChanged;
            view.lkpteach.EditValueChanged += Lkpteach_EditValueChanged;
            view.tlsubject.NodeCellStyle += Tlsubject_NodeCellStyle;
           
        }

        private void Lokyear_EditValueChanged(object sender, EventArgs e)
        {
            int yearid= (view.lokyear.EditValue as int?) ?? 0;
            view.lkpteach.Properties.DataSource = TeacherSubjectClassOperation.GetAllTeacherClassSubjectsWithYear(yearid);

        }

        private void Tlsubject_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Column== view.tlsubject.Columns["ClSu_id"])
            {
                bool ischecked = (bool)e.Node.Checked;
                if (ischecked)
                {
                    e.Appearance.Font = new System.Drawing.Font(e.Appearance.Font, System.Drawing.FontStyle.Bold);
                    e.Appearance.ForeColor = System.Drawing.Color.Red;
                   
                }
                else
                {
                    e.Appearance.Reset();
                }
            }
        }
        

        private void Lkpteach_EditValueChanged(object sender, EventArgs e)
        {
            view.tlsubject.UncheckAll();

            teachSubjects = new TeacherSubject();
            teachSubjects.teachid = (view.lkpteach.EditValue as int?) ?? 0;
            teachSubjects = TeacherSubjectClassOperation.GetListTeachClassSubjects().Where(y => y.teachid == teachSubjects.teachid).SingleOrDefault();

            if (teachSubjects != null)
            {
                foreach (SubjectClass subclass in teachSubjects.teachsubjects)
                {
                    foreach (TreeListNode item in view.tlsubject.Nodes)
                    {
                       
                        if (Convert.ToInt32(item.GetValue("ClSu_id")) == subclass.id)
                        {
                            view.tlsubject.Nodes[item.Id].Checked = true;
                            view.id = teachSubjects.id;
                        }
                    }
                }
            }
        }
        
        void InitializeControl()
        {
            AddColumn(view.tlsubject);
            view.tlsubject.DataSource = SubjectClassOperation.GetAllClassSubjects();
           
            view.tlsubject.ViewStyle = TreeListViewStyle.TreeList;
            view.tlsubject.OptionsBehavior.Editable = false;
            view.tlsubject.OptionsSelection.MultiSelectMode = TreeListMultiSelectMode.CellSelect;
            view.tlsubject.OptionsSelection.MultiSelect = true;
            view.tlsubject.OptionsSelection.EnableAppearanceFocusedRow = false;
            view.tlsubject.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.tlsubject.OptionsView.CheckBoxStyle = DefaultNodeCheckBoxStyle.Check;


            view.lokyear.Properties.DataSource = YearsOperation.GetAllyears();
            view.lokyear.Properties.DisplayMember = "year_name";
            view.lokyear.Properties.ValueMember = "year_id";

            RefreshData();
            
            view.lkpteach.Properties.DisplayMember = "teach_name_";
            view.lkpteach.Properties.ValueMember = "id";


            view.gridview.OptionsSelection.MultiSelect = true;
            view.gridview.OptionsBehavior.Editable = false;
            //view.gridview.Columns["TeacherSubjectClass_id"].Visible = false;
            //view.gridview.Columns["teach_id"].Visible = false;
            //view.gridview.Columns["subClass_id"].Visible = false;
            //view.gridview.Columns["sub_id"].Visible = false;
            //view.gridview.Columns["class_id"].Visible = false;
            //view.gridview.Columns["teach_name_"].Caption = "اسم المعلم";
            //view.gridview.Columns["sub_name"].Caption = "اسم المادة";
            //view.gridview.Columns["class_name"].Caption = "اسم الصف";

        }
        void lookcolumon(LookUpEdit lkp)
        {
            lkp.Properties.Columns.Add(
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo
                {
                    FieldName = "teach_id",
                    Visible=false
                }
                );
            lkp.Properties.Columns.Add(
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo
                {
                    FieldName = "teach_name_",
                    Visible = true
                }
                );
        }
        void initioTreeView(DataTable dataTable,TreeView treeView)
        {
            ////dataTable = // احضر الجدول من قاعدة البيانات
            //TreeNode classNode;
            //foreach (DataRow row in dataTable.Rows)
            //{
            //    int classId = (int)row["classe_id"];
            //    string className = (string)row["class_name"];
            //    int subId = (int)row["sub_id"];
            //    string subName = (string)row["sub_name"];

            //    // إنشاء عقدة للصف الدراسي
                
            //    if (treeView.Nodes.ContainsKey(className))
            //    {
            //        classNode = new TreeNode(className);

            //    }
            //    // إضافة عقدة للشجرة
            //    treeView.Nodes.Add(classNode);
               
            //    // إنشاء عقدة للمادة الدراسية
            //    TreeNode subNode = new TreeNode(subName);

            //    // إضافة عقدة المادة الدراسية كابن لعقدة الصف الدراسي
            //    classNode.Nodes.Add(subNode);
            //}

        }
        private void Gridview_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //New();
            //view.id = Convert.ToInt32(view.gridview.GetFocusedRowCellValue("ClSu_id"));
            //view.lkpClass.EditValue = view.gridview.GetFocusedRowCellValue("classe_id");
            //view.lkpSubject.EditValue = view.gridview.GetFocusedRowCellValue("sub_id");

        }
       
        void RefreshData()
        {
            
            view.gridcontrol.DataSource = TeacherSubjectClassOperation.GetAllTeacherClassSubjects();
            New();
        }
        void set()
        {
                    teachSubjects = new Models.TeacherSubject();
            foreach (TreeListNode item in view.tlsubject.Nodes)
            {
                if (view.tlsubject.Nodes[item.Id].Checked)
                {


                    teachSubjects.id = view.id;
                    teachSubjects.teachid = (view.lkpteach.EditValue as int?) ?? 0;
                    teachSubjects.teachsubjects.Add(new Models.SubjectClass
                    {
                        id = Convert.ToInt32(item.GetValue("ClSu_id")),
                        Classid = Convert.ToInt32(item.GetValue("classe_id")),
                    });
                }
            }
        }

        void AddColumn(TreeList tl)
        {
            //RepositoryItemCheckEdit checkedit = new RepositoryItemCheckEdit();

            tl.Columns.Add(
               new DevExpress.XtraTreeList.Columns.TreeListColumn()
               {
                   FieldName = "ClSu_id",
                   Caption = "",
                   Visible = false,
                   //ColumnEdit= checkedit,
                   
               });
            tl.Columns.Add(
                new DevExpress.XtraTreeList.Columns.TreeListColumn()
                {
                    FieldName = "classe_id",
                    Caption = "رقم الصف الدراسي",
                    Visible = false
                });
            tl.Columns.Add(
                new DevExpress.XtraTreeList.Columns.TreeListColumn()
                {
                    FieldName = "class_name",
                    Caption = "اسم الصف",
                    Visible = true
                });
            tl.Columns.Add(
                new DevExpress.XtraTreeList.Columns.TreeListColumn()
                {
                    FieldName = "sub_id",
                    Caption = "رقم المادة",
                    Visible = false
                });
            tl.Columns.Add(
                new DevExpress.XtraTreeList.Columns.TreeListColumn()
                {
                    FieldName = "sub_name",
                    Caption = "اسم المادة",
                    Visible = true
                });
        }
        //void test(TreeList treeList)
        //{
        //    // تحديد اسماء الاعمدة
        //    string idFieldName = "id";
        //    string classIdFieldName = "classid";
        //    string subIdFieldName = "subid";
        //    string classNameFieldName = "className";
        //    string subNameFieldName = "subName";

        //    // إنشاء جدول وإضافة الأعمدة
        //    DataTable dataTable = new DataTable();
        //    dataTable.Columns.Add(idFieldName, typeof(int));
        //    dataTable.Columns.Add(classIdFieldName, typeof(int));
        //    dataTable.Columns.Add(subIdFieldName, typeof(int));
        //    dataTable.Columns.Add(classNameFieldName, typeof(string));
        //    dataTable.Columns.Add(subNameFieldName, typeof(string));

        //    // إضافة البيانات إلى الجدول

        //    // استخدام TreeListNode لتمثيل الصفوف كعقد
        //    List<TreeListNode> nodes = new List<TreeListNode>();

        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        int id = (int)row[idFieldName];
        //        int classId = (int)row[classIdFieldName];
        //        int subId = (int)row[subIdFieldName];
        //        string className = (string)row[classNameFieldName];
        //        string subName = (string)row[subNameFieldName];

        //        TreeListNode node = new TreeListNode(id, classId, subId, className, subName);
        //        nodes.Add(node);
        //    }

        //    // إعداد العقد الأم والعقد الفرعي
        //    foreach (TreeListNode node in nodes)
        //    {
        //        int parentId = node.ClassId;
        //        if (parentId != 0)
        //        {
        //            TreeListNode parentNode = nodes.FirstOrDefault(n => n.Id == parentId);
        //            if (parentNode != null)
        //            {
        //                node.ParentNode = parentNode;
        //                parentNode.ChildNodes.Add(node);
        //            }
        //        }
        //    }

        //    // تعيين الجدول كمصدر بيانات لـ TreeList
        //    treeList.DataSource = nodes;

        //    // تحديد اسماء الاعمدة في TreeList
        //    treeList.KeyFieldName = idFieldName;
        //    treeList.ParentFieldName = classIdFieldName;
        //    treeList.ChildFieldName = subIdFieldName;

        //    // إضافة اعمدة لـ TreeList
        //    treeList.Columns.Add(classNameFieldName, "اسم الصف");
        //    treeList.Columns.Add(subNameFieldName, "اسم المادة الدراسية");

        //    // قم بتعيين اسم العمود الذي يحتوي على مربعات الاختيار
        //    treeList.Columns[subNameFieldName].ColumnType = typeof(bool);

        //    // قم بتعيين اسم العمود الذي يحتوي على مربعات الاختيار
        //    treeList.Columns[subNameFieldName].ColumnType = typeof(bool);

        //}
        //private void PopulateTreeList(DataTable dataTable, TreeList treeList)
        //{
        //    treeList.BeginUpdate();
        //    treeList.Nodes.Clear();

        //    //إنشاء العقد الجذر
        //    //TreeListNode rootNode = treeList.AppendNode(null, null);
        //    //rootNode.SetValue("class_name", "الصف الدراسي");

        //    // تجميع البيانات في هيكل الشجرة
        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        int subclassId = Convert.ToInt32(row["classe_id"]);
        //        int classId = Convert.ToInt32(row["classe_id"]);
        //        int subId = Convert.ToInt32(row["sub_id"]);
        //        string className = row["class_name"].ToString();
        //        string subName = row["sub_name"].ToString();


        //        // العثور على العقد الجذر المراد إضافة العقد الفرعي له
        //        TreeListNode parentNode = FindParentNode(treeList, classId);

        //        // إضافة العقد الفرعي إلى العقد الأب
        //        //TreeListNode childNode = treeList.AppendNode("classe_id", parentNode);
        //        TreeListNode childNode = treeList.AppendNode(new object[] { subName, subId, classId }, parentNode);
        //        //childNode.SetValue("classe_id", classId);
        //        //childNode.SetValue("sub_id", subId);
        //        childNode.Tag = row;
        //    }

        //    treeList.EndUpdate();
        //}

        //// العثور على العقد الجذر المراد إضافة العقد الفرعي له
        //private TreeListNode FindParentNode(TreeList treeList, int classId)
        //{
        //    foreach (TreeListNode node in treeList.Nodes)
        //    {
        //        if (Convert.ToInt32(node["classe_id"]) == classId)
        //            return node;
        //    }

        //    return null;
        //}

        void get()
        {
            view.id = teachSubjects.id;
            view.lkpteach.EditValue = teachSubjects.teachid;
            teachSubjects = new TeacherSubject();
            if (teachSubjects.teachsubjects != null)
            {
                foreach (var subclass in teachSubjects.teachsubjects)
                {
                    view.tlsubject.Nodes[subclass.id].Checked = true;
                }
            }
        }

        public void New()
        {
            sublist = new List<Subject>();
            listSubject = new List<SubjectClass>();
            teachSubjects = new TeacherSubject();
            subsclass = new SubjectClass();
            view.tlsubject.UncheckAll();
            get();
        }

        public void Delete()
        {
            set();

            if (teachSubjects.id == 0)
            {
                MessageBox.Show("لايوجد عنصر محدد لحذفه");
            }
            else
            {
                if (MessageBox.Show("تأكيد الحذف!!", "هل انت متاكد انك تريد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    TeacherSubjectClassOperation.TeachSubClassDelete(teachSubjects.teachid);
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
                    if (teachSubjects.id == 0)
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
            TeacherSubjectClassOperation.AddSubClassDataInTeach(teachSubjects.teachid, teachSubjects.teachsubjects);
            MessageBox.Show("تم الاظافة بنجاح");
        }

        void Update()
        {
            TeacherSubjectClassOperation.UpdateSubClassDataInTeach(teachSubjects.id, teachSubjects.teachid, teachSubjects.teachsubjects);
            MessageBox.Show("تم التحديث بنجاح");

        }

        int AutoNum()
        {
            return SubjectClassOperation.GetListClassSubjects().Count + 1;
        }

        //التحقق من الحقول ليست فارغة
        bool IsDataValid()
        {
            int errors = 0;
            if (view.lkpteach.Text.Trim() == string.Empty)
            {
                view.lkpteach.ErrorText = "هذا الحقل مطلوب";
                errors += 1;
            }
            return errors == 0;

        }
        bool IsExist()
        {
            //if (TeacherSubjectClassOperation.ExistItem(sujectclass.Classid, sujectclass.subjectid).Rows.Count > 0)
            //{
            //    MessageBox.Show("هذا العنصر مجود من قبل");
            //    return true;
            //}
            //else
            return false;
        }

    }
}
