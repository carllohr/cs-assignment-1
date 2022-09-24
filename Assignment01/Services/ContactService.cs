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

        public void ViewContact(string option);
        public void UpdateContact(Contact contactExist);
        public void DeleteContact();
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

        public void DeleteContact()
        {
            throw new NotImplementedException();
        }

        public void UpdateContact(Contact contactExist)
        {
            Console.Clear();
            Console.WriteLine("What information would you like to update?");
            Console.WriteLine("1. First name");
            Console.WriteLine("2. Last name");
            Console.WriteLine("3. Email");
            Console.WriteLine("4. Phone number");
            Console.WriteLine("5. City");
            Console.WriteLine("6. Country");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Enter new first name: ");
                    contactExist.FirstName = Console.ReadLine();
                    break;
                case "2":
                    Console.Write("Enter new last name: ");
                    contactExist.LastName = Console.ReadLine();
                    break;
                case "3":
                    Console.Write("Enter new email: ");
                    contactExist.Email = Console.ReadLine();
                    break;
                case "4":
                    Console.Write("Enter new phone number: ");
                    contactExist.PhoneNumber = Console.ReadLine();
                    break;
                case "5":
                    Console.Write("Enter new city: ");
                    contactExist.City = Console.ReadLine();
                    break;
                case "6":
                    Console.Write("Enter new country: ");
                    contactExist.Country = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
                        

               
            }
            fileMethod.Save(contacts);
            Console.Clear();

        }

        public void ViewContacts()
        {
            try
            {  //loop through list to print contacts to console
                foreach (var item in contacts)
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName}");
                }

            }

            catch { }
           

        }

        public void ViewContact(string option)
        {
            var contactExist = contacts.FirstOrDefault(x => x.FullName == option);



            if(contactExist != null)
            {
                Console.WriteLine($"{contactExist.FullName} {contactExist.Email} {contactExist.PhoneNumber} - {contactExist.City}, {contactExist.Country}");
                Console.WriteLine("1. Update contact");
                Console.WriteLine("2. Delete contact");

                switch (Console.ReadLine())
                {
                    case "1":
                        UpdateContact(contactExist);
                        break;
                }


            }
            else
            {
                Console.WriteLine("Unable to find contact");
            }
            // use this bool var for the case when input does not match any contact
            
            
           
            
        }
    }
}
