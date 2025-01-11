using ExportImportObjects.Interfaces;
using ExportImportObjects.Models;

namespace ExportImportObjects.Services
{
    public class ContractorExportImport3 : ExportImportBase3<Contractor>
    {
        public ContractorExportImport3(IDataFormatGenerator<Contractor> generator) : base(generator)
        {

        }
    }
}