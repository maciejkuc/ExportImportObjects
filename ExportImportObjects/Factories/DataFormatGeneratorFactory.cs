using ExportImportObjects.Interfaces;
using ExportImportObjects.Models;
using ExportImportObjects.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace ExportImportObjects.Factories
{ 
    public static class DataFormatGeneratorFactory
    {
        private static readonly Dictionary<(string, Type), IDataFormatGenerator> Generators = new Dictionary<(string, Type), IDataFormatGenerator>()
        {
            { (".csv", typeof(Contact)), new ContactCsvGenerator() },
            { (".csv", typeof(Contractor)), new ContractorCsvGenerator() },
            { (".xlsx", typeof(Contact)), new ContactExcelGenerator() },
            { (".xlsx", typeof(Contractor)), new ContractorExcelGenerator() },
            { (".json", typeof(Contact)), new JsonGenerator() },
            { (".json", typeof(Contractor)), new NewtonsoftJsonGenerator() },
            { (".html", typeof(Contact)), new HtmlGenerator() },
            { (".html", typeof(Contractor)), new HtmlGenerator() },
            { (".xml", typeof(Contact)), new XmlGenerator() },
            { (".xml", typeof(Contractor)), new XmlGenerator() }
        };

        public static IDataFormatGenerator GetGenerator<T>(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            if (Generators.TryGetValue((extension, typeof(T)), out var generator))
            {
                return generator;
            }
            throw new NotSupportedException($"File format '{extension}' and type '{typeof(T).Name}' are not supported.");
        }
    }
}