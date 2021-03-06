﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Sdl.Community.PostEdit.Compare.Core.Helper
{
	public static class ExcelReportHelper
	{
		public static void CreateReportHeader(ExcelPackage xlPackage, ExcelWorksheet worksheet)
		{
			worksheet.Cells["A1"].Value = "Post-Edit Comparison Report" ;
			worksheet.Cells["A1:T1"].Merge = true;		
			worksheet.Cells["A1"].Style.Font.Size = 18;
			worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


			worksheet.Cells["A2"].Value = "Generated " + DateTime.Now;
			worksheet.Cells["A2:T2"].Merge = true;
			worksheet.Cells["A2"].Style.Font.Size = 10;
			worksheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

			xlPackage.Save();
		}

		public static ExcelPackage CreateExcelReport(string filePath)
		{
			var reportPath = Path.Combine(filePath, "report.xlsx");
			if (File.Exists(reportPath)) { File.Delete(reportPath); };
			var newFile = new FileInfo(reportPath);

			var xlPackage = new ExcelPackage(newFile);
			return xlPackage;

		}

		public static ExcelWorksheet CreateWorksheetForReport(ExcelPackage xlPackage , string worksheetName)
		{
			var worksheet = xlPackage.Workbook.Worksheets.Add(worksheetName);

			return worksheet;
		}
		public static void TableTitle(ExcelPackage xlPackage, ExcelWorksheet worksheet, string title,int numberOfCellsToMerge)
		{
			var lastUsedRowIndex = worksheet.Dimension.End.Row;
			worksheet.Cells[lastUsedRowIndex + 3, 1].Value = title;
			worksheet.Cells[lastUsedRowIndex + 3, 1].Style.Font.Size = 14;
			worksheet.Cells[lastUsedRowIndex + 3, 1].Style.Font.Bold = true;
			worksheet.Cells[lastUsedRowIndex + 1, numberOfCellsToMerge].Merge = true;
		}
		public static void CreateTableHeader(ExcelPackage xlPackage, ExcelWorksheet worksheet,List<string> headerValues)
		{			
			int rowNr;
			var columnNr = 1;
			if (worksheet.Dimension == null)
			{
				rowNr = 1;
			}
			else
			{
				rowNr = worksheet.Dimension.End.Row + 2; // leave  1 empty row
			}

			foreach (var item in headerValues)
			{
				worksheet.Cells[rowNr, columnNr].Value = item;
				worksheet.Cells[rowNr, columnNr].AutoFitColumns();
				worksheet.Cells[rowNr, columnNr].Style.Fill.PatternType = ExcelFillStyle.Solid;
				worksheet.Cells[rowNr, columnNr].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
				worksheet.Cells[rowNr, columnNr].Style.Font.Color.SetColor(Color.White);
				worksheet.Cells[rowNr, columnNr].Style.Font.Bold = true;
				columnNr++;

			}
			xlPackage.Save();
		}

		public static void CreateFirstColumnValues(ExcelPackage xlPackage, ExcelWorksheet worksheet,List<string> firstColumnValues)
		{
			var rowIndex = worksheet.Dimension.End.Row + 1;

			foreach (var column in firstColumnValues)
			{
				worksheet.Cells[rowIndex, 1].Value = column;
				worksheet.Cells[rowIndex, 1].Style.Font.Bold = true;
				rowIndex++;
			}

			xlPackage.Save();
		}
	}
}
