using ExportImportObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

public class HtmlGenerator : IDataFormatGenerator
{
    public void Export<T>(IEnumerable<T> objects, string filePath)
    {
        var htmlBuilder = new StringBuilder();

        // Header
        htmlBuilder.AppendLine("<!DOCTYPE html>");
        htmlBuilder.AppendLine("<html>");
        htmlBuilder.AppendLine("<head><title>Export</title></head>");
        htmlBuilder.AppendLine("<body>");
        htmlBuilder.AppendLine("<table border='1'>");

        // Table Headers
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        htmlBuilder.AppendLine("<tr>");
        foreach (var prop in properties)
        {
            htmlBuilder.AppendLine($"<th>{EscapeHtml(prop.Name)}</th>");
        }
        htmlBuilder.AppendLine("</tr>");

        // Table Rows
        foreach (var obj in objects)
        {
            htmlBuilder.AppendLine("<tr>");
            foreach (var prop in properties)
            {
                var value = prop.GetValue(obj)?.ToString() ?? string.Empty;
                htmlBuilder.AppendLine($"<td>{EscapeHtml(value)}</td>");
            }
            htmlBuilder.AppendLine("</tr>");
        }

        // Footer
        htmlBuilder.AppendLine("</table>");
        htmlBuilder.AppendLine("</body>");
        htmlBuilder.AppendLine("</html>");

        File.WriteAllText(filePath, htmlBuilder.ToString());
    }

    public IEnumerable<T> Import<T>(string filePath)
    {
        throw new NotImplementedException("HTML import is not supported.");
    }

    private string EscapeHtml(string input)
    {
        return input.Replace("&", "&amp;")
                    .Replace("<", "&lt;")
                    .Replace(">", "&gt;")
                    .Replace("\"", "&quot;")
                    .Replace("'", "&#39;");
    }
}
