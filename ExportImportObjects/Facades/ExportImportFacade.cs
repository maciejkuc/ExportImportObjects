using ExportImportObjects.Factories;
using System.Collections.Generic;

namespace ExportImportObjects.Facades
{
    public class ExportImportFacade
    {
        public void Export<T>(IEnumerable<T> objects, string filePath)
        {
            var generator = DataFormatGeneratorFactory.GetGenerator<T>(filePath);
            generator.Export(objects, filePath);
        }

        public IEnumerable<T> Import<T>(string filePath)
        {
            var generator = DataFormatGeneratorFactory.GetGenerator<T>(filePath);
            return generator.Import<T>(filePath);
        }
    }
}