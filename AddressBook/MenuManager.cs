using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class MenuManager
    {

        List<Contact> contacts = new List<Contact>();

        public string OptionsMenu()
        {
            Console.WriteLine("**** ADDRESS MENU ****");
            Console.WriteLine("1. View Contacts");
            Console.WriteLine("2. Create New Contact");
            Console.WriteLine("3. View One Contact");
            Console.WriteLine("Q. Close Adress Book");
            Console.Write("Choose one option: ");

            return Console.ReadLine();
        }
        // här visas 4 alternativ som användaren får välja emellan.

        public void ViewContactsMenu()
        {
            Console.Clear();
            Console.WriteLine("*** CONTACTS ***");

            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.Id} - {contact.FirstName} {contact.LastName}, {contact.StreetName} {contact.PostalCode} {contact.City}");
            }
        }
        // den här metoden visar användaren alla kontakter som finns i adressboken.
         
        public void CreateNewContactMenu()
        {
            Console.Clear();
            Console.WriteLine("*** CREATE CONTACT ***");

            var contact = new Contact();
            contact.Id = Guid.NewGuid();

            Console.Write("Firstname: ");
            contact.FirstName = Console.ReadLine();

            Console.Write("Lastname: ");
            contact.LastName = Console.ReadLine();

            Console.Write("Streetname: ");
            contact.StreetName = Console.ReadLine();

            Console.Write("Postalcode: ");
            contact.PostalCode = Console.ReadLine();

            Console.Write("City: ");
            contact.City = Console.ReadLine();

            contacts.Add(contact);
        }
        // här kan användaren skapa en ny kontakt.

        public void ViewOneContactMenu()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("*** CONTACT DETAILS ***");
                Console.Write("Enter contact Id to view: ");
                var id = Guid.Parse(Console.ReadLine());

                var contact = contacts.FirstOrDefault(x => x.Id == id);
                
                Console.WriteLine();
                Console.WriteLine($"Firstname: {contact.FirstName}");
                Console.WriteLine($"Lastname: {contact.LastName}");
                Console.WriteLine($"Streetname: {contact.StreetName}");
                Console.WriteLine($"Postalcode: {contact.PostalCode}");
                Console.WriteLine($"City: {contact.City}");
                Console.WriteLine();

                Console.WriteLine("1. Edit contact.");
                Console.WriteLine("2. Delete contact.");
                Console.Write("Enter option: ");
                var option = Console.ReadLine();
                // här har jag skrivit två alternativ som användaren kan välja mellan

                switch (option)
                {
                    case "1":
                        UpdateContact(contact);
                        break;

                    case "2":
                        DeleteContact(contact.Id);
                        break;

                    default:
                        break;
                }
            }
            catch { }
        }
        // den här metoden visar användaren en specifik kontakt från adressboken.

        public void UpdateContact(Contact contact)
        {
            Console.Clear();
            Console.Write("Enter contact id to edit: ");
            var option = Console.ReadLine();

            Console.Write("Firstname: ");
            var firstName = Console.ReadLine();
            if (!string.IsNullOrEmpty(firstName))
                contact.FirstName = firstName;

            Console.Write("Lastname: ");
            var lastName = Console.ReadLine();
            if (!string.IsNullOrEmpty(lastName))
                contact.LastName = lastName;

            Console.Write("Streetname: ");
            var streetName = Console.ReadLine();
            if (!string.IsNullOrEmpty(streetName))
                contact.StreetName = streetName;

            Console.Write("Postalcode: ");
            var postalCode = Console.ReadLine();
            if (!string.IsNullOrEmpty(postalCode))
                contact.PostalCode = postalCode;

            Console.Write("City: ");
            var city = Console.ReadLine();
            if (!string.IsNullOrEmpty(city))
                contact.City = city;
            // här kommer kontakten uppdateras och sparas
        }
        // om anvädaren väljer detta alternativ så kan en kontakt uppdateras.

        public void DeleteContact(Guid id)
        {
            Console.Write("Enter contact id to delete: ");
            var option = Console.ReadLine();
            contacts = contacts.Where(x => x.Id != id).ToList();
        }
        //här kan användaren välja en kontakt som kan raderas.

        public void Run()
        {
            do
            {
                Console.Clear();
                var option = OptionsMenu();
                switch (option.ToUpper())
                {
                    case "1":
                        ViewContactsMenu();
                        break;

                    case "2":
                        CreateNewContactMenu();
                        break;

                    case "3":
                        ViewOneContactMenu();
                        break;

                    case "Q":
                        Environment.Exit(0);
                        break;

                }

                Console.ReadKey();

            } while (true);

        }
        // de 3 alternativen från huvudmenyn körs genom denna.

    }
     


}
