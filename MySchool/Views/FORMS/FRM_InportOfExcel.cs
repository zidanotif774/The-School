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
using ExcelWorkbookReader;
using OfficeOpenXml;
using System.IO;

namespace MySchool.Views.FORMS
{
    public partial class FRM_InportOfExcel : DevExpress.XtraEditors.XtraForm
    {
        public FRM_InportOfExcel()
        {
            InitializeComponent();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {

        }
        ExcelDataHandler em = new ExcelDataHandler();
        string filepath = "";
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                filepath = ofd.FileName;
                    List<string> worksheet = em.GetWorksheetNames(filepath);
                    foreach (string name in worksheet)
                    {
                        comboBox1.Items.Add(name);
                    }
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            List<string> colnames = em.GetColumnNames(filepath, comboBox1.SelectedItem.ToString());
            foreach (var itemname in colnames)
            {
                checkedListBox1.Items.Add(itemname); 
            }
        }

        private void btnInport_Click(object sender, EventArgs e)
        {
            int strcol = checkedListBox1.CheckedItems.IndexOf(checkedListBox1.SelectedItem);
             gridControl1.DataSource= em.GetColumnByName(filepath, comboBox1.SelectedItem.ToString(), checkedListBox1.SelectedItem.ToString(), 4, 1, 25, 3);

            
        }

        
    }
}