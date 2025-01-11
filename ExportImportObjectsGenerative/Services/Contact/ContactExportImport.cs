using ExportImportObjects.Interfaces;
using ExportImportObjects.Models;

namespace ExportImportObjects.Services
{
    public class ContactExportImport : ExportImportBase<Contact>
    {
        public ContactExportImport(IDataFormatGenerator<Contact> generator) : base(generator)
        {

        }
    }
}