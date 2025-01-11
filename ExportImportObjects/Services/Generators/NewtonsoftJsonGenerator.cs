using ExportImportObjects.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

public class NewtonsoftJsonGenerator : IDataFormatGenerator
{
    public void Export<T>(IEnumerable<T> objects, string filePath)
    {
        var settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented
        };

        var json = JsonConvert.SerializeObject(objects, settings);
        File.WriteAllText(filePath, json);
    }

    public IEnumerable<T> Import<T>(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<IEnumerable<T>>(json) ?? new List<T>();
    }
}
