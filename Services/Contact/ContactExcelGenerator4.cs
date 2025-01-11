using ExportImportObjects.Models;
using OfficeOpenXml;

namespace ExportImportObjects.Services
{
    internal class ContactExcelGenerator4 : ExcelGenerator4
    {
        protected override void WriteHeaders(ExcelWorksheet worksheet)
        {
            worksheet.Cells[1, 1].Value = "Name";
            worksheet.Cells[1, 2].Value = "Email";
        }

        protected override void WriteRow<T>(T obj, ExcelWorksheet worksheet, int row)
        {
            Contact contact = obj as Contact;
            worksheet.Cells[row, 1].Value = contact.Name;
            worksheet.Cells[row, 2].Value = contact.Email;
        }

        protected override T ParseRow<T>(ExcelWorksheet worksheet, int row)
        {
            var name = worksheet.Cells[row, 1].Value.ToString();
            var email = worksheet.Cells[row, 2].Value.ToString();
            return (T)(object)new Contact { Name = name, Email = email };
        }
    }
}
