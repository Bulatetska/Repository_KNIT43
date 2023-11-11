using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class ContactList
    {
        private List<Contact> contacts;

        public ContactList()
        {
            contacts = new List<Contact>();
        }

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public void RemoveContact(Contact contact)
        {
            contacts.Remove(contact);
        }

        public List<Contact> SearchContactByName(string searchQuery)
        {
            List<Contact> searchResults = contacts.FindAll(contact =>
                contact.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)
            );
            return searchResults;
        }


        public void DisplayContacts()
        {
            foreach (Contact contact in contacts)
            {
                Console.WriteLine(contact);
                Console.WriteLine();
            }
        }

        public Contact GetContact(int index)
        {
            if (index >= 0 && index < contacts.Count)
            {
                return contacts[index];
            }
            return null;
        }

        public void EditContact(Contact oldContact, Contact newContact)
        {
            if (contacts.Contains(oldContact))
            {
                int index = contacts.IndexOf(oldContact);
                contacts[index] = newContact;
            }
        }

        public void ExportContacts(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Contact contact in contacts)
                    {
                        writer.WriteLine($"Name: {contact.Name}");
                        writer.WriteLine($"Email: {contact.EmailAddress}");
                        writer.WriteLine($"Phone: {contact.PhoneNumber}");
                        writer.WriteLine($"Age: {contact.Age}");
                        writer.WriteLine($"Sex: {contact.Sex}");
                        writer.WriteLine($"Birthday: {contact.Birthday.ToShortDateString()}");
                        writer.WriteLine();
                    }
                }

                Console.WriteLine("Contacts exported successfully.");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error exporting contacts: {ex.Message}");
                Console.WriteLine();
            }
        }

    }
}
