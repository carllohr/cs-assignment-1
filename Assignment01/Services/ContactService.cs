using Assignment01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment01.Services
{
    internal interface IContactService
    {
        public void CreateContact(Contact contact);

        public void ViewContact(int option);
        public void UpdateContact(Contact contactExist);
        public void DeleteContact(Contact contactExist);
        public void ViewContacts();
        public IEnumerable<Contact> GetContacts();
    }
    internal class ContactService : IContactService
    {
        public List<Contact> contacts;
        Contact contact = new Contact();
        FileMethods fileMethod;
        
        public ContactService(string filePath)
        {
            fileMethod = new FileMethods(filePath);
            contacts = new List<Contact>();
        }

        public IEnumerable<Contact> GetContacts() // method to get list from json file
        {
            
            fileMethod.Read(ref contacts);
            return contacts;
        }

        public void CreateContact(Contact contact) // method for adding added contact to list
        {
            contacts.Add(contact);
            fileMethod.Save(contacts);
        }

        public void DeleteContact(Contact contactExist)
        {
            Console.Clear();
            Console.WriteLine("Deleting contact..");
            contacts.Remove(contactExist);
            fileMethod.Save(contacts);
            Console.WriteLine("Contact successfully deleted");
        }

        public void UpdateContact(Contact contactExist) // method updatecontact takes contactExist from viewcontact method as argument
        {
            Console.Clear();
            Console.WriteLine("What information would you like to update?");
            Console.WriteLine($"1. First name - {contactExist.FirstName}");
            Console.WriteLine($"2. Last name - {contactExist.LastName}");
            Console.WriteLine($"3. Email - {contactExist.Email}");
            Console.WriteLine($"4. Phone number - {contactExist.PhoneNumber}");
            Console.WriteLine($"5. City - {contactExist.City}");
            Console.WriteLine($"6. Country - {contactExist.Country}");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Enter new first name: ");
                    contactExist.FirstName = Console.ReadLine();
                    Console.WriteLine($"New first name '{contactExist.FirstName}' saved");
                    break;
                case "2":
                    Console.Write("Enter new last name: ");
                    contactExist.LastName = Console.ReadLine();
                    Console.WriteLine($"New last name '{contactExist.LastName}' saved");
                    break;
                case "3":
                    Console.Write("Enter new email: ");
                    contactExist.Email = Console.ReadLine();
                    Console.WriteLine($"New email '{contactExist.Email}' saved");
                    break;
                case "4":
                    Console.Write("Enter new phone number: ");
                    contactExist.PhoneNumber = Console.ReadLine();
                    Console.WriteLine($"New phone number '{contactExist.PhoneNumber}' saved");
                    break;
                case "5":
                    Console.Write("Enter new city: ");
                    contactExist.City = Console.ReadLine();
                    Console.WriteLine($"New city '{contactExist.City}' saved");
                    break;
                case "6":
                    Console.Write("Enter new country: ");
                    contactExist.Country = Console.ReadLine();
                    Console.WriteLine($"New country '{contactExist.Country}' saved");
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
            fileMethod.Save(contacts);
            
        }

        public void ViewContacts()
        {
            try
            {  //loop through list to print contacts to console
                for(int i = 0; i < contacts.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {contacts[i].FirstName} {contacts[i].LastName}");
                }

            }
            catch 
            { 
            }
        }

        public void ViewContact(int option)
        {
            // find contact equal to number input, aka the number in the list as the user sees it by taking using the input as index and subtracting one
            // earlier used var contactExist = contacts.FirstOrDefault(x => x.FullName == option) but changed to make it to list[option-1] instead for aestethic reasons

            try
            {
                var contactExist = contacts[option - 1];



                // if user input equals an existing user, show detailed information and give options to update or delete contact
                if (contactExist != null)
                {
                    Console.Clear();
                    Console.WriteLine($"Contact number {option}: {contactExist.FullName} - {contactExist.Email} {contactExist.PhoneNumber} - {contactExist.City}, {contactExist.Country}");
                    Console.WriteLine("1. Update contact");
                    Console.WriteLine("2. Delete contact");
                    Console.WriteLine("\nTo return to main menu, enter any value that is not 1 or 2 and then hit any button");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            UpdateContact(contactExist);
                            break;
                        case "2":
                            DeleteContact(contactExist);
                            break;
                        default:
                            Console.WriteLine("Returning to main menu");
                            break;
                    }


                }
             
            }
            catch { Console.WriteLine("Unable to find contact"); }
        }//method to view contact, takes an integer as argument from viewcontactmenu input
    }
}
