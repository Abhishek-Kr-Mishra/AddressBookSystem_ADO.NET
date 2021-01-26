using System;

namespace AddressBookSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();
            AddressBookRepo addressBookRepo = new AddressBookRepo();

            addressBook.FirstName = "Aadi";
            addressBook.LastName = "Singh";
            addressBook.PersonAddress = "21th Florida Street";
            addressBook.PhoneNumber = 9452513121;
            addressBook.EmailID = "adi@gmail.com";
            addressBook.CountryID = 4;
            addressBook.StateID = 4;
            addressBook.CityID = 2;
            addressBook.ZipID = 321456;
            addressBook.PersonTypeID = 2;

            //if(addressBookRepo.InseertAddressToAddressBook(addressBook))
            //{
            //    Console.WriteLine("Address Inserted Succesfully");
            //}

            if (addressBookRepo.updateAddress(addressBook,addressBook.BookID))
            {
                Console.WriteLine("Address Updated Succesfully");
            }
        }
    }
}
