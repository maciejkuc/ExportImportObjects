using ExportImportObjects.Models;
using System.IO;

namespace ExportImportObjects.Services
{
    internal class ContractorCsvGenerator : CsvGenerator
    {
        protected override void WriteHeaders(StreamWriter writer)
        {
            writer.WriteLine("Name,Company");
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
