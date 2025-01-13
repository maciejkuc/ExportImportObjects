using ExportImportObjects.Interfaces;
using ExportImportObjects.Models;
using System.Collections.Generic;
using System.IO;

namespace ExportImportObjects.Services
{
    internal class ContactCsvGenerator<T> : CsvGenerator<T> where T : Contact
    {
        protected override void WriteHeaders(StreamWriter writer)
        {
            writer.WriteLine("Name,Email");
        }

        protected override void WriteRow(T contact, StreamWriter writer)
        {
            writer.WriteLine($"{contact.Name},{contact.Email}");
        }

        protected override T ParseRow(string line)
        {
            var parts = line.Split(',');
            return new Contact { Name = parts[0], Email = parts[1] } as T;
        }
    }
}
