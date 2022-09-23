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
        public void UpdateContact();
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

        public void UpdateContact()
        {
            throw new NotImplementedException();
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
    }
}
