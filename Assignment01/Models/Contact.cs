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
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;

        // make fullname for simplicity
        public string FullName => $"{FirstName} {LastName}";
    }
}
