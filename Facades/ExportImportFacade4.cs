using ExportImportObjects.Factories;
using System.Collections.Generic;

public class ExportImportFacade4
{
    public void Export<T>(IEnumerable<T> objects, string filePath)
    {
        var generator = DataFormatGeneratorFactory4.GetGenerator<T>(filePath);
        generator.Export(objects, filePath);
    }

    public IEnumerable<T> Import<T>(string filePath)
    {
        var generator = DataFormatGeneratorFactory4.GetGenerator<T>(filePath);
        return generator.Import<T>(filePath);
    }
}
