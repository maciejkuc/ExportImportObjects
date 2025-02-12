﻿using ExportImportObjects.Interfaces;
using ExportImportObjects.Models;
using OfficeOpenXml;
using System.Collections.Generic;

namespace ExportImportObjects.Services
{
    internal class ContractorExcelGenerator<T> : ExcelGenerator<T> where T : Contractor
    {
        protected override void WriteHeaders(ExcelWorksheet worksheet)
        {
            worksheet.Cells[1, 1].Value = "Name";
            worksheet.Cells[1, 2].Value = "Company";
        }

        protected override void WriteRow(T contractor, ExcelWorksheet worksheet, int row)
        {
            worksheet.Cells[row, 1].Value = contractor.Name;
            worksheet.Cells[row, 2].Value = contractor.Company;
        }

        protected override T ParseRow(ExcelWorksheet worksheet, int row)
        {
            var name = worksheet.Cells[row, 1].Value.ToString();
            var company = worksheet.Cells[row, 2].Value.ToString();
            return new Contractor { Name = name, Company = company } as T;
        }
    }
}
