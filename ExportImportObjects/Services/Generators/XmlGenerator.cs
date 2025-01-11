using ExportImportObjects.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

public class XmlGenerator : IDataFormatGenerator
{
    public void Export<T>(IEnumerable<T> objects, string filePath)
    {
        var serializer = new XmlSerializer(typeof(List<T>));
        using (var writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, objects.ToList());
        }
    }

    public IEnumerable<T> Import<T>(string filePath)
    {
        var serializer = new XmlSerializer(typeof(List<T>));
        using (var reader = new StreamReader(filePath))
        {
            return (List<T>)(serializer.Deserialize(reader) ?? new List<T>());
        }
    }
}
