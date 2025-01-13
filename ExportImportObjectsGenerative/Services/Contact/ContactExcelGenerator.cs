using ExportImportObjects.Interfaces;
using ExportImportObjects.Models;
using OfficeOpenXml;
using System.Collections.Generic;

namespace ExportImportObjects.Services
{
    internal class ContactExcelGenerator<T> : ExcelGenerator<T> where T : Contact
    {
        protected override void WriteHeaders(ExcelWorksheet worksheet)
        {
            worksheet.Cells[1, 1].Value = "Name";
            worksheet.Cells[1, 2].Value = "Email";
        }

        protected override void WriteRow(T contact, ExcelWorksheet worksheet, int row)
        {
            worksheet.Cells[row, 1].Value = contact.Name;
            worksheet.Cells[row, 2].Value = contact.Email;
        }

        protected override T ParseRow(ExcelWorksheet worksheet, int row)
        {
            var name = worksheet.Cells[row, 1].Value.ToString();
            var email = worksheet.Cells[row, 2].Value.ToString();
            return new Contact { Name = name, Email = email } as T;
        }
    }
}
