


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelManipulation
{
    public class ExcelImporter
    {
        private string filePath;
        private string worksheetName;
        private string[] columnsToImport;

        public ExcelImporter(string filePath, string worksheetName, string[] columnsToImport)
        {
            this.filePath = filePath;
            this.worksheetName = worksheetName;
            this.columnsToImport = columnsToImport;
        }

        public List<string[]> ImportData()
        {
            List<string[]> importedData = new List<string[]>();

            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(filePath);
            Excel._Worksheet worksheet = workbook.Sheets[worksheetName];
            Excel.Range range = worksheet.UsedRange;

            int rowCount = range.Rows.Count;
            int columnCount = range.Columns.Count;

            for (int rowIndex = 1; rowIndex <= rowCount; rowIndex++)
            {
                string[] rowData = new string[columnsToImport.Length];

                for (int columnIndex = 1; columnIndex <= columnCount; columnIndex++)
                {
                    if (/*columnsToImport.AsQueryable().Contains(((Excel.Range)range.Cells[1, columnIndex]).Value2?.ToString())*/true)
                    {
                        rowData[Array.IndexOf(columnsToImport, ((Excel.Range)range.Cells[1, columnIndex]).Value2?.ToString())] =
                            ((Excel.Range)range.Cells[rowIndex, columnIndex]).Value2?.ToString();
                    }
                }

                importedData.Add(rowData);
            }

            workbook.Close();
            excelApp.Quit();

            return importedData;
        }
    }

    public class ExcelExporter
    {
        private string filePath;
        private string worksheetName;
        private string[] columnsToExport;

        public ExcelExporter(string filePath, string worksheetName, string[] columnsToExport)
        {
            this.filePath = filePath;
            this.worksheetName = worksheetName;
            this.columnsToExport = columnsToExport;
        }

        public void ExportData(List<string[]> dataToExport)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel._Worksheet worksheet = workbook.ActiveSheet;

            for (int i = 0; i < columnsToExport.Length; i++)
            {
                worksheet.Cells[1, i + 1] = columnsToExport[i];
            }

            for (int rowIndex = 0; rowIndex < dataToExport.Count; rowIndex++)
            {
                string[] rowData = dataToExport[rowIndex];

                for (int columnIndex = 0; columnIndex < columnsToExport.Length; columnIndex++)
                {
                    worksheet.Cells[rowIndex + 2, columnIndex + 1] = rowData[columnIndex];
                }
            }

            workbook.SaveAs(filePath);
            workbook.Close();
            excelApp.Quit();
        }
    }
}
