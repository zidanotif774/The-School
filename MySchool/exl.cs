
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelWorkbookReader
{
    public class ExcelReader
    {
        private Excel.Application excelApp;
        private Excel.Workbook workbook;
        private List<Excel.Worksheet> worksheets;

        public ExcelReader(string filePath)
        {
            try
            {
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Open(filePath);
                worksheets = new List<Excel.Worksheet>();

                foreach (Excel.Worksheet worksheet in workbook.Worksheets)
                {
                    worksheets.Add(worksheet);
                }

                workbook.Close();
                excelApp.Quit();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void LoadWorksheets(CheckedListBox checklistBox)
        {
            try
            {
                foreach (Excel.Worksheet worksheet in worksheets)
                {
                    checklistBox.Items.Add(worksheet.Name);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public List<string> GetSelectedColumns(string worksheetName)
        {
            List<string> columns = new List<string>();

            Excel.Worksheet selectedWorksheet = null;
            foreach (Excel.Worksheet worksheet in worksheets)
            {
                if (worksheet.Name == worksheetName)
                {
                    selectedWorksheet = worksheet;
                    break;
                }
            }

            if (selectedWorksheet != null)
            {
                Excel.Range headerRange = selectedWorksheet.UsedRange.Rows[1];
                foreach (Excel.Range cell in headerRange)
                {
                    columns.Add(cell.Value.ToString());
                }
            }

            return columns;
        }
    }
}