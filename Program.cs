using ConsoleProject;

class Program
{
    static void Main(string[] args)
    {
        ContactList contactList = new ContactList();

        Contact initialContact1 = new Contact("Billy Herrington", "earthwecan@gmail.com", "123-456-1488", 30, "Male", new DateTime(1992, 3, 15));
        Contact initialContact2 = new Contact("Ms Arghworth", "gparty@gmail.com", "228-654-1337", 28, "Female", new DateTime(1994, 7, 22));
        Contact initialContact3 = new Contact("Van Darkholme", "vandarkholme@gmail.com", "555-300-4567", 35, "Male", new DateTime(1987, 9, 5));

        contactList.AddContact(initialContact1);
        contactList.AddContact(initialContact2);
        contactList.AddContact(initialContact3);

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add a contact");
            Console.WriteLine("2. Remove the contact");
            Console.WriteLine("3. Search for a contact");
            Console.WriteLine("4. Display all contacts");
            Console.WriteLine("5. Edit a contact");
            Console.WriteLine("6. Export contacts to a file");
            Console.WriteLine("0. Exit");
            Console.WriteLine();

            Console.WriteLine("Enter your choice: ");
            int choice = 0;
            //Check the valid of the number
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int IntChoice))
                {
                    choice = IntChoice;
                    break;
                }
                else
                {
                    Console.WriteLine("Input a valid number.");
                }
                
            }

            switch (choice)
            {
                //add the contact
                case 1:
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Email address: ");
                    string email = Console.ReadLine();
                    Console.Write("Phone number: ");
                    string phone = Console.ReadLine();
                    Console.Write("Sex: ");
                    string sex = Console.ReadLine();
                    Console.Write("Age: ");
                    int age;
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out int IntAge))
                        {
                            age = IntAge;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Age must be a valid number. Provide valid age.");
                            Console.Write("Age: ");
                        }
                    }
                    Console.Write("Birthday (yyyy-mm-dd): ");
                    DateTime birthday;
                    while (true)
                    {
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime DateTimeBirthday))
                        {
                            birthday = DateTimeBirthday;
                            Contact newContact = new Contact(name, email, phone, age, sex, birthday);
                            contactList.AddContact(newContact);
                            Console.WriteLine();
                            Console.WriteLine("Contact Added Successfully!");
                            Console.WriteLine();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format. Provide valid date.");
                            Console.Write("Birthday (yyyy-mm-dd): ");
                        }
                    }

                    break;
                //remove the contact
                case 2:
                    Console.Write("Enter the name of the contact to remove: ");
                    Console.WriteLine();
                    string contactToRemove = Console.ReadLine();

                    List<Contact> searchResults = contactList.SearchContactByName(contactToRemove);

                    if (searchResults.Count == 0)
                    {
                        Console.WriteLine($"No contact found with the name '{contactToRemove}'.");
                    }
                    else if (searchResults.Count == 1)
                    {
                        Contact contact = searchResults[0];
                        contactList.RemoveContact(contact);
                        Console.WriteLine($"Contact '{contact.Name}' removed successfully!");
                    }
                    else
                    {

                        Console.WriteLine($"Multiple contacts found with the name '{contactToRemove}':");
                        for (int i = 0; i < searchResults.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {searchResults[i].ToString()}");
                            Console.WriteLine();
                        }

                        Console.Write("Enter the number of the contact to remove: ");
                        if (int.TryParse(Console.ReadLine(), out int contactIndex) && contactIndex >= 1 && contactIndex <= searchResults.Count)
                        {
                            Contact contact = searchResults[contactIndex - 1];
                            contactList.RemoveContact(contact);
                            Console.WriteLine($"Contact '{contact.Name}' removed successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection. No contact removed.");
                        }
                    }
                    break;
                //search the contact
                case 3:
                    Console.WriteLine("Enter the name of the contact to find: ");
                    string contactToShow = Console.ReadLine();

                    List<Contact> findedContacts = contactList.SearchContactByName(contactToShow);
                    if (findedContacts.Count > 0)
                    {
                        for (int i = 0; i < findedContacts.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {findedContacts[i].ToString()}");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Any contacts found.");
                        Console.WriteLine();
                    }

                    
                    break;
                //show the contacts
                case 4:
                    Console.WriteLine("All Contacts: ");
                    Console.WriteLine();
                    contactList.DisplayContacts();
                    break;
                //edit the contact
                case 5:
                    Contact existingContact;
                    Console.Write("Enter the name of the contact to edit: ");
                    string contactToEdit = Console.ReadLine();

                    List<Contact> searchResultsEdit = contactList.SearchContactByName(contactToEdit);

                    if (searchResultsEdit.Count == 0)
                    {
                        Console.WriteLine($"No contact found with the name '{contactToEdit}'.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine($"Contacts found with the name '{contactToEdit}':");
                        Console.WriteLine();
                        for (int i = 0; i < searchResultsEdit.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {searchResultsEdit[i].ToString()}");
                            Console.WriteLine();
                        }
                        if (searchResultsEdit.Count > 1)
                        {
                            while (true)
                            {
                                Console.Write("Enter the number of the contact to edit: ");
                                if (int.TryParse(Console.ReadLine(), out int contactIndex) && contactIndex >= 1 && contactIndex <= searchResultsEdit.Count)
                                {
                                    existingContact = searchResultsEdit[contactIndex - 1];
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid selection.");
                                    Console.WriteLine();
                                }
                            }
                        }
                        else
                        {
                            existingContact = searchResultsEdit[0];
                        }
                        Console.WriteLine("Enter the new details:");
                        Console.WriteLine();

                        // Get new contact details
                        Console.Write("Name: ");
                        string newName = Console.ReadLine();
                        Console.Write("Email address: ");
                        string newEmail = Console.ReadLine();
                        Console.Write("Phone number: ");
                        string newPhone = Console.ReadLine();
                        Console.Write("Sex: ");
                        string newSex = Console.ReadLine();
                        Console.Write("Age: ");
                        int newAge;
                        while (!int.TryParse(Console.ReadLine(), out newAge))
                        {
                            Console.WriteLine("Age must be a valid number. Provide valid age.");
                            Console.Write("Age: ");
                        }
                        Console.Write("Birthday (yyyy-mm-dd): ");
                        DateTime newBirthday;
                        while (!DateTime.TryParse(Console.ReadLine(), out newBirthday))
                        {
                            Console.WriteLine("Invalid date format. Provide valid date.");
                            Console.Write("Birthday (yyyy-mm-dd): ");
                        }

                        // Create a new contact with the updated details
                        Contact newContact = new Contact(newName, newEmail, newPhone, newAge, newSex, newBirthday);

                        // Update the existing contact
                        contactList.EditContact(existingContact, newContact);
                        Console.WriteLine();
                        Console.WriteLine($"Contact '{existingContact.Name}' edited successfully!");
                        Console.WriteLine();
                    }
                    break;
                //export contacts info to the file
                case 6:
                    string exportFilePath = "contactsExport.txt";
                    contactList.ExportContacts(exportFilePath);
                    break;

                //exit from the program
                case 0:
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}