using ExportImportObjects.Facades;
using ExportImportObjects.Models;
using System;
using System.Collections.Generic;

namespace ExportImportObjects1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Contact> contacts;
            List<Contractor> contractors;
            PrepareExampleData(out contacts, out contractors);
            FacadeWithTemplate(contacts, contractors);
            Console.ReadLine();
        }

        private static void FacadeWithTemplate(List<Contact> contacts, List<Contractor> contractors)
        {
            Console.WriteLine("Export/Import z klasą bazową dla csv i xlsx");
            var facade = new ExportImportFacade();

            // Eksport Contact
            facade.Export(contacts, nameof(Contact), "contacts.xlsx");
            facade.Export(contacts, nameof(Contact), "contacts.csv");

            // Import Contact
            var importedContacts = facade.Import<Contact>(nameof(Contact), "contacts.xlsx");
            var importedContacts2 = facade.Import<Contact>(nameof(Contact), "contacts.csv");

            // Eksport Contractor
            facade.Export(contractors, nameof(Contractor), "contractors.xlsx");
            facade.Export(contractors, nameof(Contractor), "contractors.csv");

            // Import Contractor
            var importedContractors = facade.Import<Contractor>(nameof(Contractor), "contractors.xlsx");
            var importedContractors2 = facade.Import<Contractor>(nameof(Contractor), "contractors.csv");
            WriteResults(importedContacts, importedContractors);
            WriteResults(importedContacts2, importedContractors2);
        }

        private static void PrepareExampleData(out List<Contact> contacts, out List<Contractor> contractors)
        {
            contacts = new List<Contact>
            {
                new Contact { Name = "John Doe", Email = "john@example.com" },
                new Contact { Name = "John Doe2", Email = "john@example.com" },
                new Contact { Name = "John Doe3", Email = "john@example.com" },
                new Contact { Name = "John Doe4", Email = "john@example.com" },
                new Contact { Name = "John Doe5", Email = "john@example.com" },
                new Contact { Name = "John Doe6", Email = "john@example.com" },
                new Contact { Name = "John Doe7", Email = "john@example.com" },
                new Contact { Name = "John Doe8", Email = "john@example.com" },
                new Contact { Name = "John Doe9", Email = "john@example.com" },
                new Contact { Name = "John Doea", Email = "john@example.com" },
                new Contact { Name = "John Doeb", Email = "john@example.com" },
            };
            contractors = new List<Contractor>
            {
                new Contractor { Name = "Jane Doe1", Company = "Example Inc." },
                new Contractor { Name = "Jane Doe2", Company = "Example Inc." },
                new Contractor { Name = "Jane Doe3", Company = "Example Inc." },
                new Contractor { Name = "Jane Doe4", Company = "Example Inc." },
                new Contractor { Name = "Jane Doe5", Company = "Example Inc." },
                new Contractor { Name = "Jane Doe6", Company = "Example Inc." },
                new Contractor { Name = "Jane Doe7", Company = "Example Inc." },
                new Contractor { Name = "Jane Doe8", Company = "Example Inc." },
                new Contractor { Name = "Jane Doe9", Company = "Example Inc." },
                new Contractor { Name = "Jane Doea", Company = "Example Inc." },
            };
        }

        private static void WriteResults(IEnumerable<Contact> importedContacts, IEnumerable<Contractor> importedContractors)
        {
            // Wyświetlanie wyników
            Console.WriteLine("Imported Contacts:");
            foreach (var contact in importedContacts)
            {
                Console.WriteLine($"Name: {contact.Name}, Email: {contact.Email}");
            }

            Console.WriteLine("\nImported Contractors:");
            foreach (var contractor in importedContractors)
            {
                Console.WriteLine($"Name: {contractor.Name}, Company: {contractor.Company}");
            }
            Console.WriteLine();
        }
    }
}
