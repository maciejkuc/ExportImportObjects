using ExportImportObjects.Models;
using System.IO;

namespace ExportImportObjects.Services
{
    internal class ContractorCsvGenerator4 : CsvGenerator4
    {
        protected override void WriteHeaders(StreamWriter writer)
        {
            writer.WriteLine("Name,Email");
        }

        protected override void WriteRow<T>(T obj, StreamWriter writer)
        {
            Contractor contractor = obj as Contractor;
            writer.WriteLine($"{contractor.Name},{contractor.Company}");
        }

        protected override T ParseRow<T>(string line)
        {
            var parts = line.Split(',');
            return (T)(object)new Contractor { Name = parts[0], Company = parts[1] };
        }
    }
}
