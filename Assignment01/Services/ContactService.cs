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

    }
    internal class ContactService : IContactService
    {
        public List<Contact> contacts = new List<Contact>();
        Contact contact = new Contact();
        FileMethods fileMethod = new FileMethods();
        public void CreateContact(Contact contact)
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
            fileMethod.Read(ref contacts);
           

        }
    }
}
