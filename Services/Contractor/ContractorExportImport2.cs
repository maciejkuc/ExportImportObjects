using ExportImportObjects.Models;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;

namespace ExportImportObjects.Services
{
    public class ContractorExportImport2 : ExportImportBase2<Contractor>
    {
        public ContractorExportImport2()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        protected override void ExportToExcel(IEnumerable<Contractor> contractors, string filePath)
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

        protected override IEnumerable<Contractor> ImportFromExcel(string filePath)
        {
            var contractors = new List<Contractor>();
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int row = 2;
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

        protected override void ExportToCsv(IEnumerable<Contractor> contractors, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Name,Company");
                foreach (var contractor in contractors)
                {
                    writer.WriteLine($"{contractor.Name},{contractor.Company}");
                }
            }
        }

        protected override IEnumerable<Contractor> ImportFromCsv(string filePath)
        {
            var contractors = new List<Contractor>();
            using (var reader = new StreamReader(filePath))
            {
                string line;
                reader.ReadLine(); // Skip header
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    contractors.Add(new Contractor { Name = parts[0], Company = parts[1] });
                }
            }
            return contractors;
        }
    }
}