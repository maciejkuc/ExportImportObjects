using ExportImportObjects.Models;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;

namespace ExportImportObjects.Services
{
    public class ContactExportImport2 : ExportImportBase2<Contact>
    {
        public ContactExportImport2()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        protected override void ExportToExcel(IEnumerable<Contact> contacts, string filePath)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Contacts");
                worksheet.Cells[1, 1].Value = "Name";
                worksheet.Cells[1, 2].Value = "Email";

                int row = 2;
                foreach (var contact in contacts)
                {
                    worksheet.Cells[row, 1].Value = contact.Name;
                    worksheet.Cells[row, 2].Value = contact.Email;
                    row++;
                }

                package.SaveAs(new FileInfo(filePath));
            }
        }

        protected override IEnumerable<Contact> ImportFromExcel(string filePath)
        {
            var contacts = new List<Contact>();
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int row = 2;
                while (worksheet.Cells[row, 1].Value != null)
                {
                    var name = worksheet.Cells[row, 1].Value.ToString();
                    var email = worksheet.Cells[row, 2].Value.ToString();
                    contacts.Add(new Contact { Name = name, Email = email });
                    row++;
                }
            }
            return contacts;
        }

        protected override void ExportToCsv(IEnumerable<Contact> contacts, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Name,Email");
                foreach (var contact in contacts)
                {
                    writer.WriteLine($"{contact.Name},{contact.Email}");
                }
            }
        }

        protected override IEnumerable<Contact> ImportFromCsv(string filePath)
        {
            var contacts = new List<Contact>();
            using (var reader = new StreamReader(filePath))
            {
                string line;
                reader.ReadLine(); // Skip header
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    contacts.Add(new Contact { Name = parts[0], Email = parts[1] });
                }
            }
            return contacts;
        }
    }
}