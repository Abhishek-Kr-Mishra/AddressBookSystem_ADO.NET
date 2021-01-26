using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookSystem
{
    class AddressBookRepo
    {
        public static string connectionString = "Server=(Localdb)\\MSSQLLocalDB;database=AddressBookServiceDB;Trusted_Connection=true";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        public bool InseertAddressToAddressBook(AddressBook addressBook)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand command = new SqlCommand("insertAddress", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", addressBook.FirstName);
                    command.Parameters.AddWithValue("@LastName", addressBook.LastName);
                    command.Parameters.AddWithValue("@PersonAddress", addressBook.PersonAddress);
                    command.Parameters.AddWithValue("@PhoneNumber", addressBook.PhoneNumber);
                    command.Parameters.AddWithValue("@EmailID", addressBook.EmailID);
                    command.Parameters.AddWithValue("@CountryID", addressBook.CountryID);
                    command.Parameters.AddWithValue("@StateID", addressBook.StateID);
                    command.Parameters.AddWithValue("@CityID", addressBook.CityID);
                    command.Parameters.AddWithValue("@ZipID", addressBook.ZipID);
                    command.Parameters.AddWithValue("@PersonTypeID", addressBook.PersonTypeID);
                    this.sqlConnection.Open();
                    var result = command.ExecuteNonQuery();
                    if(result != 0)
                    {
                        return true;
                    }
                    return false;
                }       
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
    }
}
