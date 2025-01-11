using ExportImportObjects.Interfaces;
using ExportImportObjects.Models;
using ExportImportObjects.Services;
using System;
using System.Collections.Generic;

namespace ExportImportObjects.Factories
{
    public class ExportImportFactory
    {
        private static readonly Dictionary<string, object> strategies = new Dictionary<string, object>
        {
            { nameof(Contact), new ContactExportImport2() },
            { nameof(Contractor), new ContractorExportImport2() }
        };

        public static IExportImportStrategy<T> GetStrategy<T>(string type)
        {
            if (strategies.TryGetValue(type, out var strategy))
            {
                return (IExportImportStrategy<T>)strategy;
            }
            throw new ArgumentException($"Strategy for type '{type}' not found.");
        }

    }
}