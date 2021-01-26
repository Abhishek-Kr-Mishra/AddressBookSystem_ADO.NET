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
        public bool InsertAddressToAddressBook(AddressBook addressBook)
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
        public bool UpdateAddress(AddressBook addressBook)
        {
            try
            {
                SqlCommand command = new SqlCommand("updateAddress", sqlConnection);
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
                this.sqlConnection.Close();
                if (result != 0)
                {
                    return true;
                }
                return false;
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
        public bool DeleteAddress(string firstName)
        {
            try
            {
                SqlCommand command = new SqlCommand("deleteAddress", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FirstName", firstName);
                this.sqlConnection.Open();
                var result = command.ExecuteNonQuery();
                this.sqlConnection.Close();
                if (result != 0)
                {
                    return true;
                }
                return false;
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
        public void RetrievePersonToCityOrState()
        {
            try
            {
                SqlCommand command = new SqlCommand("RetrieveCityOrState", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                this.sqlConnection.Open();
                 SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        string fname = reader.GetString(0);
                        string lname = reader.GetString(1);
                        string cityName = reader.GetString(2);
                        string stateName = reader.GetString(3);
                        Console.WriteLine("{0}, {1}, {2}, {3} ", fname, lname, cityName, stateName);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Couldn't found any data");
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void CountPersonByCityOrState()
        {
            try
            {
                SqlCommand command = new SqlCommand("CountRowByCityAndState", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                this.sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("There are {0} Persons in table by City Count and {1} Persons by state Count ",
                                      reader.GetInt32(0), reader.GetInt32(1));
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
        public void SortByPersonName()
        {
            try
            {
                SqlCommand command = new SqlCommand("SortByPersonName", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                this.sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int bookID = reader.GetInt32(0);
                        string fname = reader.GetString(1);
                        string lname = reader.GetString(2);
                        string personAddress = reader.GetString(3);
                        long phoneNumber = reader.GetInt64(4);
                        string emailID = reader.GetString(5);
                        int countryID = reader.GetInt32(6);
                        int stateID = reader.GetInt32(7);
                        int cityID = reader.GetInt32(8);
                        int zipID = reader.GetInt32(9);
                        int personTypeID = reader.GetInt32(10);
                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10}", bookID, fname, lname, personAddress, phoneNumber,
                                          emailID, countryID, stateID, cityID, zipID, personTypeID);
                    }
                }
                else
                {
                    Console.WriteLine("No Data Found");
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
