using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class AddressBook
    {
        public int BookID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonAddress { get; set; }
        public long PhoneNumber { get; set; }
        public string EmailID { get; set; }
        public int CountryID { get; set; }
        public int StateID { get; set; }
        public int CityID { get; set; }
        public int ZipID { get; set; }
        public int PersonTypeID { get; set; }
    }
}
