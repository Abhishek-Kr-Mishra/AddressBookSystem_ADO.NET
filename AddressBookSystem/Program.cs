using System;

namespace AddressBookSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();
            AddressBookRepo addressBookRepo = new AddressBookRepo();

            addressBook.FirstName = "Aditya";
            addressBook.LastName = "Mishra";
            addressBook.PersonAddress = "05 Florida Street";
            addressBook.PhoneNumber = 7896540123;
            addressBook.EmailID = "adi@gmail.com";
            addressBook.CountryID = 4;
            addressBook.StateID = 4;
            addressBook.CityID = 2;
            addressBook.ZipID = 11254;
            addressBook.PersonTypeID = 2;

            if(addressBookRepo.InseertAddressToAddressBook(addressBook))
            {
                Console.WriteLine("Address Inserted Succesfully");
            }
        }
    }
}
