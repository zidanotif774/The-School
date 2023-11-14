
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

//public class ExcelDataHandler
//{
//    public List<string> GetWorksheetNames(string filePath)
//    {
//        List<string> worksheetNames = new List<string>();
//        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
//        using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
//        {

//            foreach (ExcelWorksheet worksheet in package.Workbook.Worksheets)
//            {
//                worksheetNames.Add(worksheet.Name);
//            }

//        }

//        return worksheetNames;
//    }

//    public List<string> GetColumnNames(string filePath, string worksheetName)
//    {
//        List<string> columnNames = new List<string>();

//        using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
//        {
//            ExcelWorksheet worksheet = package.Workbook.Worksheets[worksheetName];
//            ExcelRangeBase excelrang = worksheet.Cells.Offset(6, 1);
//            //excelrang = excelrang.
//            foreach (var headerCell in worksheet.Cells[excelrang.Start.Row, excelrang.Start.Column, excelrang.Start.Row, excelrang.End.Column])
//            {
//                columnNames.Add(headerCell.Text);
//            }
//            //for (int columnIndex = 1; columnIndex <= worksheet.Dimension.Columns; columnIndex++)
//            //{
//            //    string columnName = Convert.ToString(worksheet.Cells[1, columnIndex].Value);
//            //    columnNames.Add(columnName);
//            //}
//        }

//        return columnNames;
//    }
//    public void ExportDataToExcel(string filePath, string worksheetName, string[,] data,int startrow,int startcol,int endRow,int EndCol)
//    {

//        Encoding arbicEncoding = Encoding.GetEncoding(1256);

//        // إنشاء ملف Excel جديد
//        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
//        using (var package = new ExcelPackage(new FileInfo(filePath)))
//        {
//            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(worksheetName);
//            worksheet.View.RightToLeft = true;
//            worksheet.Cells.Style.Font.Name = arbicEncoding.HeaderName;
//            ExcelRangeBase excelrang = worksheet.Cells.Offset(6, 1);

//            // تعبئة البيانات في الصفوف والأعمدة المحددة
//            int rowCount = data.GetLength(0);
//            int columnCount = data.GetLength(1);
//            for (int row = startrow; row <= endRow; row++)
//            {
//                for (int column = startcol; column <= EndCol; column++)
//                {
//                    worksheet.Cells[row, column].Value = data[row - 1, column - 1];
//                }
//            }

//            // حفظ الملف
//            package.Save();
//        }
//    }

//    public List<string> ImportDataFromExcel(string filePath, string worksheetName, int startRow, 
//                                              int startColumn, int endRow, int EndCol,string colnam)
//    {
//        List<string> data;
//        Encoding arbicEncoding = Encoding.GetEncoding(1256);

//        using (var package = new ExcelPackage(new FileInfo(filePath)))
//        {
//            ExcelWorksheet worksheet = package.Workbook.Worksheets[worksheetName];
//            worksheet.View.RightToLeft = true;
//            worksheet.Cells.Style.Font.Name = arbicEncoding.HeaderName;
//            //ExcelRangeBase excelrang = worksheet.Cells.Offset(6, 1);

//            // حساب عدد الصفوف والأعمدة المحتوى على الورقة
//            int rowCount = endRow  - startRow + 1;           /* worksheet.Dimension.Rows;*/
//            int columnCount = EndCol - startColumn + 1;          /* worksheet.Dimension.Columns;*/
//            // إنشاء مصفوفة لتخزين البيانات
//            //data = new string[rowCount, columnCount];
//            data = new List<string>();
//            //var colInfo = Enumerable.Range(startColumn, columnCount).ToList()
//            //    .Select(n=>new {index=n,colname=worksheet.Cells[startRow,n].Value.ToString() });
//            //int colIndex = colInfo.SingleOrDefault(c => c.colname == colnam).index;
//            // استيراد البيانات من الورقة
//            for (int row = startRow; row <= rowCount; row++)
//            {
//                for (int column = startColumn; column <= columnCount; column++)
//                {
//                    /*data.Add(/*[row - startRow, column - startColumn]*/  data.Add(worksheet.Cells[row, column+10].Value?.ToString());
//                }
//            }
//        }

//        return data;
//    }
//}
