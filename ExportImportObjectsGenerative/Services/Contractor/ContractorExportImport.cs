using ExportImportObjects.Interfaces;
using ExportImportObjects.Models;

namespace ExportImportObjects.Services
{
    public class ContractorExportImport : ExportImportBase<Contractor>
    {
        public ContractorExportImport(IDataFormatGenerator<Contractor> generator) : base(generator)
        {

        }
    }
}