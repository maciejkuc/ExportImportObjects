using ExportImportObjects.Interfaces;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace ExportImportObjects.Services
{
    public class ExcelGenerator<T> : IDataFormatGenerator<T>
    {
        public ExcelGenerator()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        public virtual void Export(IEnumerable<T> objects, string filePath)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add(typeof(T).Name + "s");
                WriteHeaders(worksheet);
                int row = 2;
                foreach (var obj in objects)
                {
                    WriteRow(obj, worksheet, row);
                    row++;
                }
                package.SaveAs(new FileInfo(filePath));
            }
        }

        public virtual IEnumerable<T> Import(string filePath)
        {
            var objects = new List<T>();
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int row = 2;
                while (worksheet.Cells[row, 1].Value != null)
                {
                    objects.Add(ParseRow(worksheet, row));
                    row++;
                }
            }
            return objects;
        }

        protected virtual void WriteHeaders(ExcelWorksheet worksheet)
        {
            throw new NotImplementedException("Headers must be implemented in a subclass.");
        }

        protected virtual void WriteRow(T obj, ExcelWorksheet worksheet, int row)
        {
            throw new NotImplementedException("Row writing must be implemented in a subclass.");
        }

        protected virtual T ParseRow(ExcelWorksheet worksheet, int row)
        {
            throw new NotImplementedException("Row parsing must be implemented in a subclass.");
        }
    }
}