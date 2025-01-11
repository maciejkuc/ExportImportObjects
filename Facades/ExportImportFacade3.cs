using ExportImportObjects.Factories;
using ExportImportObjects.Services;
using System.Collections.Generic;

public class ExportImportFacade3
{
    public void Export<T>(IEnumerable<T> objects, string filePath)
    {
        var exportImport = ExportImportFactory3.Create<T>(filePath);
        exportImport.Export(objects, filePath);
    }

    public IEnumerable<T> Import<T>(string filePath)
    {
        var exportImport = ExportImportFactory3.Create<T>(filePath);
        return exportImport.Import(filePath);
    }
}
