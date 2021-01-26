using System;

namespace AddressBookSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBookRepo addressBookRepo = new AddressBookRepo();

            addressBookRepo.CountPersonByCityOrState();
        }
    }
}
