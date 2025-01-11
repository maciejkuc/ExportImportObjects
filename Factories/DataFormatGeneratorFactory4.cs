using ExportImportObjects.Interfaces;
using ExportImportObjects.Models;
using ExportImportObjects.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace ExportImportObjects.Factories
{ 
    public static class DataFormatGeneratorFactory4
    {
        private static readonly Dictionary<(string, Type), IDataFormatGenerator4> Generators = new Dictionary<(string, Type), IDataFormatGenerator4>()
    {
        { (".csv", typeof(Contact)), new ContactCsvGenerator4() },
        { (".csv", typeof(Contractor)), new ContractorCsvGenerator4() },
        { (".xlsx", typeof(Contact)), new ContactExcelGenerator4() },
        { (".xlsx", typeof(Contractor)), new ContractorExcelGenerator4() },
        { (".json", typeof(Contact)), new JsonGenerator4() },
        { (".json", typeof(Contractor)), new NewtonsoftJsonGenerator4() },
        { (".html", typeof(Contact)), new HtmlGenerator4() },
        { (".html", typeof(Contractor)), new HtmlGenerator4() },
        { (".xml", typeof(Contact)), new XmlGenerator4() },
        { (".xml", typeof(Contractor)), new XmlGenerator4() }
    };

        public static IDataFormatGenerator4 GetGenerator<T>(string filePath)
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