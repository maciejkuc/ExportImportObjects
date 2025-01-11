using ExportImportObjects.Models;
using ExportImportObjects.Facades;
using System;
using System.Collections.Generic;

namespace ExportImportObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Contact> contacts;
            List<Contractor> contractors;
            PrepareExampleData(out contacts, out contractors);

            FacadeWithGenerativeTypeAndGeneratorsOtherWay(contacts, contractors);
            Console.ReadLine();
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


        private static void FacadeWithGenerativeTypeAndGeneratorsOtherWay(List<Contact> contacts, List<Contractor> contractors)
        {
            Console.WriteLine("Export/import z generowanym typem generatora dla konkretnego typu bez generycznych klas generatorów");
            var facade = new ExportImportFacade();

            // Eksport i import Contact
            facade.Export(contacts, "contacts4.csv");
            var importedContacts = facade.Import<Contact>("contacts4.csv");
            facade.Export(contacts, "contacts4.xlsx");
            var importedContacts2 = facade.Import<Contact>("contacts4.xlsx");
            facade.Export(contacts, "contacts4.json");
            var importedContacts3 = facade.Import<Contact>("contacts4.json");
            facade.Export(contacts, "contacts4.xml");
            var importedContacts4 = facade.Import<Contact>("contacts4.xml");
            facade.Export(contacts, "contacts4.html");

            // Eksport i import Contractor
            facade.Export(contractors, "contractors4.csv");
            var importedContractors = facade.Import<Contractor>("contractors4.csv");
            facade.Export(contractors, "contractors4.xlsx");
            var importedContractors2 = facade.Import<Contractor>("contractors4.xlsx");
            facade.Export(contractors, "contractors4.json");
            var importedContractors3 = facade.Import<Contractor>("contractors4.json");
            facade.Export(contractors, "contractors4.xml");
            var importedContractors4 = facade.Import<Contractor>("contractors4.xml");
            facade.Export(contractors, "contractors4.html");

            WriteResults(importedContacts, importedContractors);
            WriteResults(importedContacts2, importedContractors2);
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
