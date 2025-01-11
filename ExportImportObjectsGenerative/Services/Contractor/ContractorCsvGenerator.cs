using ExportImportObjects.Interfaces;
using ExportImportObjects.Models;
using System.Collections.Generic;
using System.IO;

namespace ExportImportObjects.Services
{
    internal class ContractorCsvGenerator<T> : CsvGenerator<T>, IDataFormatGenerator<T> where T : Contractor
    {
        protected override void WriteHeaders(StreamWriter writer)
        {
            writer.WriteLine("Name,Email");
        }

        protected override void WriteRow(T contractor, StreamWriter writer)
        {
            writer.WriteLine($"{contractor.Name},{contractor.Company}");
        }

        protected override T ParseRow(string line)
        {
            var parts = line.Split(',');
            return new Contractor { Name = parts[0], Company = parts[1] } as T;
        }
        public override void Export(IEnumerable<T> objects, string filePath)
        {
            base.Export(objects, filePath);
        }

        public override IEnumerable<T> Import(string filePath)
        {
            return base.Import(filePath);
        }
    }
}
