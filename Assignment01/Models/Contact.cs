using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment01.Models
{
    internal class Contact
    {

        //blueprint for our contact
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        // make fullname to be able to look for specific contact easier in our viewcontact method
        public string FullName => $"{FirstName} {LastName}";
    }
}
