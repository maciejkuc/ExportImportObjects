using ExportImportObjects.Interfaces;
using ExportImportObjects.Models;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;

namespace ExportImportObjects.Services
{
    public class ContractorExportImport : IExportImportStrategy<Contractor>
    {
        public ContractorExportImport()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        public void Export(IEnumerable<Contractor> contractors, string filePath)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Contractors");
                worksheet.Cells[1, 1].Value = "Name";
                worksheet.Cells[1, 2].Value = "Company";

                int row = 2;
                foreach (var contractor in contractors)
                {
                    worksheet.Cells[row, 1].Value = contractor.Name;
                    worksheet.Cells[row, 2].Value = contractor.Company;
                    row++;
                }

                package.SaveAs(new FileInfo(filePath));
            }
        }

        public IEnumerable<Contractor> Import(string filePath)
        {
            var contractors = new List<Contractor>();
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int row = 2; // Assuming the first row contains headers
                while (worksheet.Cells[row, 1].Value != null)
                {
                    var name = worksheet.Cells[row, 1].Value.ToString();
                    var company = worksheet.Cells[row, 2].Value.ToString();
                    contractors.Add(new Contractor { Name = name, Company = company });
                    row++;
                }
            }

            return contractors;
        }
    }
}
