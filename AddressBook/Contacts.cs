using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class Contacts
    {
        public Contacts()
        {
        }

        public Contacts(Guid id, string firstName, string lastName, string streetName, string postalCode, string city)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            StreetName = streetName;
            PostalCode = postalCode;
            City = city;
        }

        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string StreetName { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

    }
}
