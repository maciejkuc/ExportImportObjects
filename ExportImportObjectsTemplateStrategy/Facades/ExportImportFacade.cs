using ExportImportObjects.Factories;
using System.Collections.Generic;

namespace ExportImportObjects.Facades
{
	public class ExportImportFacade
	{
        public void Export<T>(IEnumerable<T> objects, string type, string filePath)
        {
            var strategy = ExportImportFactory.GetStrategy<T>(type);
            strategy.Export(objects, filePath);
        }

		public IEnumerable<T> Import<T>(string type, string filePath) 
		{ 
			var strategy = ExportImportFactory.GetStrategy<T>(type);
			return strategy.Import(filePath);
		}

    }
}
