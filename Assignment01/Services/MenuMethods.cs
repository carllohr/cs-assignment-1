﻿using Assignment01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment01.Services
{
    internal interface IMenuMethods
    {
        public void MainMenu();
        public void CreateContactMenu();
        public void ViewContactsMenu();
        public void ViewContactMenu();
    }
    internal class MenuMethods : IMenuMethods
    {
        
        
        private FileMethods fileMethod;
        private ContactService contactService;
        


        

        public MenuMethods(string filePath)
        {
           contactService = new ContactService(filePath);
        }



        public void CreateContactMenu() //menu to create a contact
        {
            Contact contact = new Contact();
            Console.Write("First name: ");
            contact.FirstName = Console.ReadLine();
            Console.Write("Last name: ");
            contact.LastName = Console.ReadLine();
            Console.Write("Email: ");
            contact.Email = Console.ReadLine();
            Console.Write("Phone number: ");
            contact.PhoneNumber = Console.ReadLine();
            Console.Write("City: ");
            contact.City = Console.ReadLine();
            Console.Write("Country: ");
            contact.Country = Console.ReadLine();

            contactService.CreateContact(contact); //calling the create contact method from our contactservice to add to list
            Console.WriteLine("Contact added");
            Console.ReadKey();


            
        }

        public void MainMenu()
        {
            contactService.GetContacts(); // call method to read contacts from json file
            Console.Clear();
            Console.WriteLine("1. Create contact");
            Console.WriteLine("2. View contacts");
            Console.WriteLine("3. View detailed contact");
            Console.WriteLine("4. Exit application");
            var option = Console.ReadLine();
            switch (option) {
                case "1":
                    Console.Clear();
                    CreateContactMenu();
                    break;
                case "2":
                    Console.Clear();
                    ViewContactsMenu();
                    break;
                case "3":
                    Console.Clear();
                    ViewContactMenu();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Exiting..");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        public void ViewContactMenu()
        {
            Console.Write("Enter full name of contact you wish to see: ");
            var option = Console.ReadLine();
            contactService.ViewContact(option);
            Console.ReadKey();

        }

        public void ViewContactsMenu()
        {
            Console.WriteLine("######## EXISTING CONTACTS ########");
            contactService.ViewContacts();
            Console.ReadKey();
        }
    }
}
