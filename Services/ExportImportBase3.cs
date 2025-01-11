using ExportImportObjects.Interfaces;
using System.Collections.Generic;

namespace ExportImportObjects.Services
{
    public abstract class ExportImportBase3<T> : IExportImportStrategy<T>
    {
        private readonly IDataFormatGenerator<T> _generator;

        protected ExportImportBase3(IDataFormatGenerator<T> generator)
        {
            _generator = generator;
        }

        public void Export(IEnumerable<T> objects, string filePath)
        {
            _generator.Export(objects, filePath);
        }

        public IEnumerable<T> Import(string filePath)
        {
            return _generator.Import(filePath);
        }
    }
}