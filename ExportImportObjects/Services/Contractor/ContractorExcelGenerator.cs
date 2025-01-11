using ExportImportObjects.Models;
using OfficeOpenXml;

namespace ExportImportObjects.Services
{
    internal class ContractorExcelGenerator : ExcelGenerator
    {
        protected override void WriteHeaders(ExcelWorksheet worksheet)
        {
            worksheet.Cells[1, 1].Value = "Name";
            worksheet.Cells[1, 2].Value = "Company";
        }

        protected override void WriteRow<T>(T obj, ExcelWorksheet worksheet, int row)
        {
            Contractor contractor = obj as Contractor;
            worksheet.Cells[row, 1].Value = contractor.Name;
            worksheet.Cells[row, 2].Value = contractor.Company;
        }

        protected override T ParseRow<T>(ExcelWorksheet worksheet, int row)
        {
            var name = worksheet.Cells[row, 1].Value.ToString();
            var company = worksheet.Cells[row, 2].Value.ToString();
            return (T)(object)new Contractor { Name = name, Company = company };
        }
    }
}
