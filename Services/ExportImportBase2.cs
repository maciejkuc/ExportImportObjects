using ExportImportObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

public abstract class ExportImportBase2<T> : IExportImportStrategy<T>
{
    public void Export(IEnumerable<T> objects, string filePath)
    {
        string extension = Path.GetExtension(filePath).ToLower();
        switch (extension)
        {
            case ".xlsx":
                ExportToExcel(objects, filePath);
                break;
            case ".csv":
                ExportToCsv(objects, filePath);
                break;
            default:
                throw new NotSupportedException($"File format '{extension}' is not supported.");
        }
    }

    public IEnumerable<T> Import(string filePath)
    {
        string extension = Path.GetExtension(filePath).ToLower();
        switch (extension)
        {
            case ".xlsx":
                return ImportFromExcel(filePath);
            case ".csv":
                return ImportFromCsv(filePath);
            default:
                throw new NotSupportedException($"File format '{extension}' is not supported.");
        }
    }

    protected abstract void ExportToExcel(IEnumerable<T> objects, string filePath);
    protected abstract IEnumerable<T> ImportFromExcel(string filePath);

    protected abstract void ExportToCsv(IEnumerable<T> objects, string filePath);
    protected abstract IEnumerable<T> ImportFromCsv(string filePath);
}
