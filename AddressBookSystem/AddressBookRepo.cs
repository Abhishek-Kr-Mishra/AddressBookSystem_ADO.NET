using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookSystem
{
    class AddressBookRepo
    {
        public static string connectionString = "Server=(Localdb)\\MSSQLLocalDB;database=AddressBookServiceDB;Trusted_Connection=true";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        
    }
}
