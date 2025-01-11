using ExportImportObjects.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class JsonGenerator : IDataFormatGenerator
{
    public void Export<T>(IEnumerable<T> objects, string filePath)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(objects, options);
        File.WriteAllText(filePath, json);
    }

    public IEnumerable<T> Import<T>(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<IEnumerable<T>>(json) ?? new List<T>();
    }
}
