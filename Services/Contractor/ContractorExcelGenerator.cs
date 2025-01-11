using ExportImportObjects.Interfaces;
using ExportImportObjects.Models;
using OfficeOpenXml;
using System.Collections.Generic;

namespace ExportImportObjects.Services
{
    internal class ContractorExcelGenerator<T> : ExcelGenerator<T>, IDataFormatGenerator<T> where T : Contractor
    {
        protected override void WriteHeaders(ExcelWorksheet worksheet)
        {
            worksheet.Cells[1, 1].Value = "Name";
            worksheet.Cells[1, 2].Value = "Email";
        }

        protected override void WriteRow(T contractor, ExcelWorksheet worksheet, int row)
        {
            worksheet.Cells[row, 1].Value = contractor.Name;
            worksheet.Cells[row, 2].Value = contractor.Company;
        }

        protected override T ParseRow(ExcelWorksheet worksheet, int row)
        {
            var name = worksheet.Cells[row, 1].Value.ToString();
            var email = worksheet.Cells[row, 2].Value.ToString();
            return new Contractor { Name = name, Company = email } as T;
        }

        public override void Export(IEnumerable<T> objects, string filePath)
        {
            base.Export(objects, filePath);
        }

        public override IEnumerable<T> Import(string filePath)
        {
            return base.Import(filePath);
        }
    }
}
