using System.Collections.Generic;

namespace ExportImportObjects.Interfaces
{
    public interface IDataFormatGenerator
    {
        void Export<T>(IEnumerable<T> objects, string filePath);
        IEnumerable<T> Import<T>(string filePath);
    }
}