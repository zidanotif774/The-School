using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
namespace MySchool.FORMS
{
    public partial class FRM_Master : XtraForm
    {
        public FRM_Master()
        {
            InitializeComponent();
        }

        private void btnsave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void btnnew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            New();
        }

        private void btndelet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Delete();
        }

        private void frm_master1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F2)
            {
                New();
            }
            if ( e.KeyCode == Keys.Enter)
            {
                Save();
            }
            if (e.KeyCode == Keys.Delete)
            {
                Delete();
            }
        }
        public virtual void New()
        {
            GetData();
        }
        public virtual void Save()
        {
            //MessageBox.Show("تم الحفظ بنجاح ");
        }

        public virtual void CLose()
        {
            Close();
        }
        public virtual void Delete()
        {
            //MessageBox.Show("تم الحذف");
        }
        public virtual void GetData()
        {

        }
        public virtual void SetData()
        {

        }
        public virtual void LoadDataInDataGridViwe()
        {

        }
        public virtual void Print()
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Print();
        }
    }
}