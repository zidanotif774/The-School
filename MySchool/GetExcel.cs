using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using OfficeOpenXml;
using System.ComponentModel;

public class ExcelImporter
{
    public ExcelImporter()
    {
      //  System.ComponentModel.LicenseContext licenscontext = new System.ComponentModel.LicenseContext();
      //  LicenseManager.CurrentContext = licenscontext;
      //var lu=  licenscontext.UsageMode ;
      //  lu = LicenseUsageMode.Designtime;
    }
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
            ExcelRangeBase excelrang = worksheet.Cells.Offset(6,1);
            //excelrang = excelrang.
            foreach (var headerCell in worksheet.Cells[excelrang.Start.Row,excelrang.Start.Column,excelrang.Start.Row, excelrang.End.Column])
            {
                columnNames.Add(headerCell.Text);
            }
            //for (int columnIndex = 1; columnIndex <= worksheet.Dimension.Columns; columnIndex++)
            //{
            //    string columnName = Convert.ToString(worksheet.Cells[1, columnIndex].Value);
            //    columnNames.Add(columnName);
            //}
        }

        return columnNames;
    }
}
