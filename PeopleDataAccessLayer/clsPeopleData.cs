 using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDataAccessLayer
{
    public class clsPeopleData
    {


        public static DataTable GetAllPeople()
        {
            DataTable peopleTable = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "select PersonID,NationalNo,FirstName" +
                ",SecondName,ThirdName,LastName,Gendor,DateOfBirth," +
                "Countries.CountryName as Nationality,Phone,Email  " +
                " from People join Countries on People.NationalityCountryID= Countries.CountryID;";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
               connection.Open();
               SqlDataReader reader=  cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    peopleTable.Load(reader);
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return peopleTable;
        }


        public static bool  GetPerson(int personID,ref string nationalNumber, ref string firstName, ref string secondName
            , ref string thirdName
            , ref string lastName, ref string address, ref string email
            , ref string phoneNumber, ref DateTime dateOfBirth, ref string nationality
            , ref string imagePath, ref string gendor) {

            bool result= false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "select PersonID,NationalNo,FirstName" +
                ",SecondName,ThirdName,LastName,Gendor,DateOfBirth," +
                "Countries.CountryName as Nationality,address,Phone,Email,ImagePath  " +
                " from People join Countries on People.NationalityCountryID= Countries.CountryID " +
                " where PersonID= @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personID);

            try
            {
                connection.Open();
                SqlDataReader reader= command.ExecuteReader();
                if(reader.Read())
                {
                    result = true;
                    nationalNumber = (string)reader["NationalNo"];
                    firstName = (string)reader["FirstName"];
                    secondName = (string)reader["secondName"];
                    //thirdname allows null in the database so we should handle null    
                    if (reader["thirdName"]!= DBNull.Value)
                        thirdName = (string)reader["thirdName"];
                    else
                        thirdName = "";
                    lastName = (string)reader["lastName"];
                    dateOfBirth = (DateTime)reader["dateOfBirth"];
                    gendor = Convert.ToString(reader["Gendor"]);

                    address = (string)reader["address"];
                    phoneNumber = (string)reader["phone"];
                    if (reader["email"] != DBNull.Value)
                        email = (string)reader["email"];
                    else
                        email = "";

                    nationality = (string)reader["nationality"];
                    if (reader["ImagePath"] != DBNull.Value)
                        imagePath = reader["ImagePath"].ToString();
                    else
                        imagePath = "";




                }
                reader.Close();
            }catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return result;
        }

        public static bool GetPerson(ref int personID,  string nationalNumber, ref string firstName, ref string secondName
            , ref string thirdName
            , ref string lastName, ref string address, ref string email
            , ref string phoneNumber, ref DateTime dateOfBirth, ref string nationality
            , ref string imagePath, ref string gendor)
        {

            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "select PersonID,NationalNo,FirstName" +
                ",SecondName,ThirdName,LastName,Gendor,DateOfBirth," +
                "Countries.CountryName as Nationality,address,Phone,Email,ImagePath  " +
                " from People join Countries on People.NationalityCountryID= Countries.CountryID " +
                " where NationalNo= @nationalNumber;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@nationalNumber", nationalNumber);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    personID = (int)reader["PersonID"];
                    nationalNumber = (string)reader["NationalNo"];
                    firstName = (string)reader["FirstName"];
                    secondName = (string)reader["secondName"];
                    //thirdname allows null in the database so we should handle null    
                    if (reader["thirdName"] != DBNull.Value)
                        thirdName = (string)reader["thirdName"];
                    else
                        thirdName = "";
                    lastName = (string)reader["lastName"];
                    dateOfBirth = (DateTime)reader["dateOfBirth"];
                    gendor = Convert.ToString(reader["Gendor"]);

                    address = (string)reader["address"];
                    phoneNumber = (string)reader["phone"];
                    if (reader["email"] != DBNull.Value)
                        email = (string)reader["email"];
                    else
                        email = "";

                    nationality = (string)reader["nationality"];
                    if (reader["ImagePath"] != DBNull.Value)
                        imagePath = reader["ImagePath"].ToString();
                    else
                        imagePath = "";



                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return result;
        }

        public static bool isNationalNoExist(string nationalNo)
        {

            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "select isFound=0 from People" +
                " where NationalNo= @nationalNo;";
            SqlCommand cmd= new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@nationalNo", nationalNo);

            try
            {
                connection.Open();

                object obj = cmd.ExecuteScalar();
                if (obj != null)
                    result = true;


            }catch (Exception ex) { }
            finally { connection.Close(); }
            return result;
        }

        public static int AddNewPerson(string nationalNumber, string firstName, string secondName, string thirdName
            , string lastName, string address, string email
            , string phoneNumber, DateTime dateOfBirth, int  CountryID, string imagePath, int gendor)   
        {

            int ID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "insert into People " +
                "values(@nationalNumber,@firstName,@secondName,@thirdName,@lastName,@dateOfBirth,@gendor" +
                ",@address,@phoneNumber,@email,@CountryID,@imagePath)" +
                " select SCOPE_IDENTITY(); ";

            SqlCommand cmd= new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nationalNumber", nationalNumber);
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@secondName", secondName);

            if (thirdName != "" && thirdName != null)
                cmd.Parameters.AddWithValue("@thirdName", thirdName);
            else
                cmd.Parameters.AddWithValue("@thirdName", System.DBNull.Value);

            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
            cmd.Parameters.AddWithValue("@gendor", gendor);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);

            if (email != "" && email != null)
                cmd.Parameters.AddWithValue("@email", email);
            else
                cmd.Parameters.AddWithValue("@email", System.DBNull.Value);

            cmd.Parameters.AddWithValue("@CountryID", CountryID);
            if (imagePath != "" && imagePath != null)
                cmd.Parameters.AddWithValue("@imagePath", imagePath);
            else
                cmd.Parameters.AddWithValue("@imagePath", System.DBNull.Value);

            try
            {
                connection.Open();
                object obj = cmd.ExecuteScalar();
                if(obj != null)
                    ID = Convert.ToInt32(obj);
                
            }catch(Exception ex) { }
            finally { connection.Close(); }
            return ID;
        }

        public static bool UpdatePerson(int PersonID,string nationalNumber, string firstName, string secondName, string thirdName
           , string lastName, string address, string email
           , string phoneNumber, DateTime dateOfBirth, int CountryID, string imagePath, int gendor)
        {
              
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "Update  People " +
                "set NationalNo=@nationalNumber,FirstName=@firstName" +
                ",SecondName=@secondName,ThirdName=@thirdName,LastName=@lastName" +
                ",DateOfBirth=@dateOfBirth,Gendor=@gendor" +
                ",address=@address,Phone=@phoneNumber,Email=@email" +
                ",NationalityCountryID=@CountryID,ImagePath=@imagePath" +
                " where PersonID= @PersonID; ";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nationalNumber", nationalNumber);
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@secondName", secondName);
            if (thirdName != "" && thirdName != null)
                cmd.Parameters.AddWithValue("@thirdName", thirdName);
            else
                cmd.Parameters.AddWithValue("@thirdName", System.DBNull.Value);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
            cmd.Parameters.AddWithValue("@gendor", gendor);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            if (email != "" && email != null)
                cmd.Parameters.AddWithValue("@email", email);
            else
                cmd.Parameters.AddWithValue("@email", System.DBNull.Value);
            cmd.Parameters.AddWithValue("@CountryID", CountryID);
            if (imagePath != "" && imagePath != null)
                cmd.Parameters.AddWithValue("@imagePath", imagePath);
            else
                cmd.Parameters.AddWithValue("@imagePath", System.DBNull.Value);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                rowsAffected  = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return (rowsAffected>0);
        }

        public static bool DeletePerson (int PersonID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "delete from People " +
                " where PersonID= @PersonID;";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                 rowsAffected = cmd.ExecuteNonQuery();
               

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return rowsAffected>0;
        }
    }


}
