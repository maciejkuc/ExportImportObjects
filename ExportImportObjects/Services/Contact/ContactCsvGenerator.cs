using ExportImportObjects.Models;
using System.IO;

namespace ExportImportObjects.Services
{
    internal class ContactCsvGenerator : CsvGenerator
    {
        protected override void WriteHeaders(StreamWriter writer)
        {
            writer.WriteLine("Name,Email");
        }

        protected override void WriteRow<T>(T obj, StreamWriter writer)
        {
            Contact contact = obj as Contact;
            writer.WriteLine($"{contact.Name},{contact.Email}");
        }

        protected override T ParseRow<T>(string line)
        {
            var parts = line.Split(',');
            return (T)(object)new Contact { Name = parts[0], Email = parts[1] };
        }
    }
}
