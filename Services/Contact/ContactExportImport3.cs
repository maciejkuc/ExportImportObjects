using ExportImportObjects.Interfaces;
using ExportImportObjects.Models;

namespace ExportImportObjects.Services
{
    public class ContactExportImport3 : ExportImportBase3<Contact>
    {
        public ContactExportImport3(IDataFormatGenerator<Contact> generator) : base(generator)
        {

        }
    }
}