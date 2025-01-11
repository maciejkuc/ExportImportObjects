using System.Collections.Generic;

namespace ExportImportObjects.Interfaces
{
    public interface IDataFormatGenerator<T>
    {
        void Export(IEnumerable<T> objects, string filePath);
        IEnumerable<T> Import(string filePath);
    }
}