using ExportImportObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace ExportImportObjects.Services
{
    public class CsvGenerator4 : IDataFormatGenerator4
    {
        public virtual void Export<T>(IEnumerable<T> objects, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                WriteHeaders(writer);
                foreach (var obj in objects)
                {
                    WriteRow(obj, writer);
                }
            }
        }

        public virtual IEnumerable<T> Import<T>(string filePath)
        {
            var objects = new List<T>();
            using (var reader = new StreamReader(filePath))
            {
                reader.ReadLine(); // Skip header
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    objects.Add(ParseRow<T>(line));
                }
            }
            return objects;
        }

        protected virtual void WriteHeaders(StreamWriter writer)
        {
            throw new NotImplementedException("Headers must be implemented in a subclass.");
        }

        protected virtual void WriteRow<T>(T obj, StreamWriter writer)
        {
            throw new NotImplementedException("Row writing must be implemented in a subclass.");
        }

        protected virtual T ParseRow<T>(string line)
        {
            throw new NotImplementedException("Row parsing must be implemented in a subclass.");
        }
    }
}