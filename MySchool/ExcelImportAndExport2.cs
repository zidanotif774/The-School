
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class ExcelDataHandler
{
    public List<string> GetWorksheetNames(string filePath)
    {
        List<string> worksheetNames = new List<string>();
        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
        {

            foreach (ExcelWorksheet worksheet in package.Workbook.Worksheets)
            {
                worksheetNames.Add(worksheet.Name);
            }

        }

        return worksheetNames;
    }

    public List<string> GetColumnNames(string filePath, string worksheetName)
    {
        List<string> columnNames = new List<string>();

        using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[worksheetName];
            ExcelRangeBase excelrang = worksheet.Cells.Offset(6, 1);
            foreach (var headerCell in worksheet.Cells[excelrang.Start.Row, excelrang.Start.Column, excelrang.Start.Row, excelrang.Start.Column+30])
            {
                
                columnNames.Add(headerCell.Text+ headerCell.Address);
                ////var column = worksheet.Cells.FirstOrDefault(c => c.Value?.ToString() == headerCell.Text)?.Start?.Column;
                ////if (column!=null)
                ////{
                ////    for (int i = column.Value; i < column.Value + 2; i++)
                ////    {
                ////        var name = worksheet.Cells[excelrang.Start.Row + 1, i].Value?.ToString();

                ////        if(name!=null)
                ////        columnNames.Add(name);
                ////    } 
                ////}
            }
        }

        return columnNames;
    }
    string ExcelColumnFromNumber(int num)
    {
        int divifent = num;
        string colname = "";
        while (divifent>0)
        {
            int modulo = (divifent - 1) % 26;
            colname = Convert.ToChar(65 + modulo) + colname;
            divifent = (divifent - modulo) / 26;
        }
        return colname;
    }
    public void ExportDataToExcel(string filePath, string worksheetName, string[,] data, int startRow, int startColumn, int endRow, int endColumn)
    {
        // إعداد ترميز اللغة العربية
        Encoding arabicEncoding = Encoding.GetEncoding(1256);

        // إنشاء ملف Excel جديد
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(worksheetName);

            // تحديد اتجاه النص العربي
            worksheet.View.RightToLeft = true;

            // تعيين ترميز اللغة العربية
            worksheet.Cells.Style.Font.Name = arabicEncoding.HeaderName;

            // تعبئة البيانات في الصفوف والأعمدة المحددة
            for (int row = startRow; row <= endRow; row++)
            {
                for (int column = startColumn; column <= endColumn; column++)
                {
                    worksheet.Cells[row, column].Value = data[row - startRow, column - startColumn];
                }
            }

            // حفظ الملف
            package.Save();
        }
    }

    public string[,] ImportDataFromExcel(string filePath, string worksheetName, int startRow, int startColumn, int endRow, int endColumn)
    {
        string[,] data;

        // إعداد ترميز اللغة العربية
        Encoding arabicEncoding = Encoding.GetEncoding(1256);

        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[worksheetName];

            // تحديد اتجاه النص العربي
            worksheet.View.RightToLeft = true;

            // تعيين ترميز اللغة العربية
            worksheet.Cells.Style.Font.Name = arabicEncoding.HeaderName;

            // إنشاء مصفوفة لتخزين البيانات
            int rowCount = endRow - startRow + 1;
            int columnCount = endColumn - startColumn + 1;
            data = new string[rowCount, columnCount];

            // استيراد البيانات من الورقة
            for (int row = startRow; row <= endRow; row++)
            {
                for (int column = startColumn; column <= endColumn; column++)
                {
                    data[row - startRow, column - startColumn] = worksheet.Cells[row, column].Value?.ToString();
                }
            }
        }

        return data;
    }

    public List<string> GetColumnByName(string filePath, string worksheetName, string columnName, int startRow, int startColumn, int endRow, int endColumn)
    {
        // إعداد ترميز اللغة العربية
        Encoding arabicEncoding = Encoding.GetEncoding(1256);

        List<string> columnData;

        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[worksheetName];

            // تحديد اتجاه النص العربي
            worksheet.View.RightToLeft = true;

            // تعيين ترميز اللغة العربية
            worksheet.Cells.Style.Font.Name = arabicEncoding.HeaderName;

            // الحصول على العمود بواسطة اسمه
            var column = worksheet.Cells.FirstOrDefault(c => c.Value?.ToString() == columnName)?.Start?.Column;

            if (column != null)
            {
                // استرداد بيانات العمود
                //columnData = new string[endRow - startRow + 1];
                columnData = new List<string>();


                for (int row = startRow; row <= endRow; row++)
                {
                   var name  = worksheet.Cells[row , column.Value].Value?.ToString();
                    if (name != null)
                        columnData.Add( name);
                }
            }
            else
            {
                // إذا لم يتم العثور على العمود المطلوب
                columnData = new List<string>(new string[0]);
            }
        }

        return columnData;
    }
}
