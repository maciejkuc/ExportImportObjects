using ExportImportObjects.Interfaces;
using ExportImportObjects.Models;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;

namespace ExportImportObjects.Services
{
    public class ContactExportImport : IExportImportStrategy<Contact>
    {
        public ContactExportImport()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        public void Export(IEnumerable<Contact> contacts, string filePath)
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

        public IEnumerable<Contact> Import(string filePath)
        {
            var contacts = new List<Contact>();
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int row = 2; // Assuming the first row contains headers
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
    }
}