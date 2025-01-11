using ExportImportObjects.Interfaces;
using ExportImportObjects.Models;
using ExportImportObjects.Services;
using System;
using System.IO;

namespace ExportImportObjects.Factories
{
    public static class DataFormatGeneratorFactory<T>
    {
        public static IDataFormatGenerator<T> GetGenerator(string filePath, Type type)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            switch (type.Name + extension)
            {
                case nameof(Contact) + ".xlsx": return (IDataFormatGenerator<T>)new ContactExcelGenerator<Contact>();
                case nameof(Contractor) + ".xlsx" : return (IDataFormatGenerator<T>) new ContractorExcelGenerator<Contractor>();
                case nameof(Contact) + ".csv": return (IDataFormatGenerator<T>)new ContactCsvGenerator<Contact>();
                case nameof(Contractor) + ".csv": return (IDataFormatGenerator<T>)new ContractorCsvGenerator<Contractor>();
                default: throw new NotSupportedException($"Type '{type.Name}' with extension '{extension}'  is not supported.");
            };
        }
    }
}