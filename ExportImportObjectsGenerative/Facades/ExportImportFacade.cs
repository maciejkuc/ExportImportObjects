using ExportImportObjects.Factories;
using System.Collections.Generic;

public class ExportImportFacade
{
    public void Export<T>(IEnumerable<T> objects, string filePath)
    {
        var exportImport = ExportImportFactory.Create<T>(filePath);
        exportImport.Export(objects, filePath);
    }

    public IEnumerable<T> Import<T>(string filePath)
    {
        var exportImport = ExportImportFactory.Create<T>(filePath);
        return exportImport.Import(filePath);
    }
}
