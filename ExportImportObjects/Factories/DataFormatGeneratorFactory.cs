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
            { (FileExtensions.Csv, typeof(Contact)), new ContactCsvGenerator() },
            { (FileExtensions.Csv, typeof(Contractor)), new ContractorCsvGenerator() },
            { (FileExtensions.Excel, typeof(Contact)), new ContactExcelGenerator() },
            { (FileExtensions.Excel, typeof(Contractor)), new ContractorExcelGenerator() },
            { (FileExtensions.Json, typeof(Contact)), new JsonGenerator() },
            { (FileExtensions.Json, typeof(Contractor)), new NewtonsoftJsonGenerator() },
            { (FileExtensions.Html, typeof(Contact)), new HtmlGenerator() },
            { (FileExtensions.Html, typeof(Contractor)), new HtmlGenerator() },
            { (FileExtensions.Xml, typeof(Contact)), new XmlGenerator() },
            { (FileExtensions.Xml, typeof(Contractor)), new XmlGenerator() }
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