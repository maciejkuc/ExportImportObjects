using ExportImportObjects.Interfaces;
using ExportImportObjects.Models;
using ExportImportObjects.Services;
using System;

namespace ExportImportObjects.Factories
{
    internal class ExportImportFactory3
    {
        public static IExportImportStrategy<T> Create<T>(string filePath)
        {
            var generator = DataFormatGeneratorFactory<T>.GetGenerator(filePath,typeof(T));
            string type = typeof(T).Name;

            switch (type)
            {
                case nameof(Contact):
                    return new ContactExportImport3((IDataFormatGenerator<Contact>)generator) as IExportImportStrategy<T>;
                case nameof(Contractor):
                    return new ContractorExportImport3((IDataFormatGenerator<Contractor>)generator) as IExportImportStrategy<T>;
                default: throw new NotSupportedException($"Export/import for type '{typeof(T).Name}' is not supported.");
            };
        }
    }
}
