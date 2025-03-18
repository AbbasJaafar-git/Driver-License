
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PeopleDataAccessLayer
{
    public class clsInternationalData
    {

        public static DataTable GetAllInternationalLicenses()
        {
            DataTable LicenseTable = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = " SELECT * from [InternationalLicenses] ";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    LicenseTable.Load(reader);
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return LicenseTable;
        }

        public static DataTable GetAllInternationalLicensesForPerson(int PersonID)
        {
            DataTable LicenseTable = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "  select LicID=InternationalLicenses.InternationalLicenseID" +
                ",InternationalLicenses.ApplicationID as AppID " +
                ",InternationalLicenses.IssuedUsingLocalLicenseID as LLicenseID " +
                ",InternationalLicenses.IssueDate,InternationalLicenses.ExpirationDate" +
                "  ,InternationalLicenses.IsActive from [InternationalLicenses]  " +
                "  join Drivers on Drivers.DriverID=InternationalLicenses.DriverID" +
                "  where Drivers.PersonID=@PersonID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    LicenseTable.Load(reader);
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return LicenseTable;
        }




        public static bool GetLicense(int LicenseID, ref int ApplicationID, ref int DriverID, ref int IssuedUsingLocalLicenseID
            , ref DateTime IssueDate, ref DateTime ExpirationDate
            , ref bool IsActive,  ref int CreatedByUserID)
        {

            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "  select * from InternationalLicenses where InternationalLicenseID = @LicenseID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    DriverID = Convert.ToInt32(reader["DriverID"]);
                    IssuedUsingLocalLicenseID = Convert.ToInt32(reader["IssuedUsingLocalLicenseID"]);
                    IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
               
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);

                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return result;
        }

        public static bool GetLicenseByPersonID(int PersonID,ref int InternationalLicenseID
            , ref int ApplicationID, ref int DriverID, ref int IssuedUsingLocalLicenseID
         , ref DateTime IssueDate, ref DateTime ExpirationDate
         , ref bool IsActive,  ref int CreatedByUserID)
        {

            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "select InternationalLicenses.* from InternationalLicenses join Drivers " +
                " on InternationalLicenses.DriverID = Drivers.DriverID  where Drivers.PersonID=@PersonID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;

                    InternationalLicenseID = Convert.ToInt32(reader["InternationalLicenseID"]);
                    ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    DriverID = Convert.ToInt32(reader["DriverID"]);
                    IssuedUsingLocalLicenseID = Convert.ToInt32(reader["IssuedUsingLocalLicenseID"]);
                    IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                 
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);

                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return result;
        }






        public static bool isLicenseExist(int LicenseID)
        {

            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "select isFound=0 from InternationalLicenses" +
                " where InternationalLicenseID= @LicenseID;";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                object obj = cmd.ExecuteScalar();
                if (obj != null)
                    result = true;


            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return result;
        }

        public static bool isLicenseExistByLocalLicense(int LicenseID)
        {

            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "select isFound=0 from InternationalLicenses" +
                " where IssuedUsingLocalLicenseID= @LicenseID;";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                object obj = cmd.ExecuteScalar();
                if (obj != null)
                    result = true;


            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return result;
        }


        public static int AddNewLicense(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID
            , DateTime IssueDate, DateTime ExpirationDate
            , bool IsActive, int CreatedByUserID)
        {

            int ID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "insert into InternationalLicenses " +
                "values(@ApplicationID,@DriverID,@IssuedUsingLocalLicenseID" +
                ",@IssueDate,@ExpirationDate,@IsActive,@CreatedByUserID)" +
                " select SCOPE_IDENTITY(); ";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            cmd.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
          
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);



            try
            {
                connection.Open();
                object obj = cmd.ExecuteScalar();
                if (obj != null)
                    ID = Convert.ToInt32(obj);

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return ID;
        }

        //public static bool UpdateStatus(int LicenseID, int IssuedUsingLocalLicenseID)
        //{

        //    int rowsAffected = 0;

        //    SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
        //    string query = "Update  InternationalLicenses " +
        //        "set IssuedUsingLocalLicenseID=@IssuedUsingLocalLicenseID ,ExpirationDate=@ExpirationDate" +
        //        " where LicenseID= @LicenseID; ";

        //    SqlCommand cmd = new SqlCommand(query, connection);
        //    cmd.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
        //    cmd.Parameters.AddWithValue("@ExpirationDate", DateTime.Now);
        //    cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
        //    try
        //    {
        //        connection.Open();
        //        rowsAffected = cmd.ExecuteNonQuery();

        //    }
        //    catch (Exception ex) { }
        //    finally { connection.Close(); }
        //    return (rowsAffected > 0);
        //}


        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID
            , DateTime IssueDate, DateTime ExpirationDate
            ,bool IsActive, int CreatedByUserID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "Update  InternationalLicenses " +
                "set ApplicationID=@ApplicationID" +
                ",DriverID=@DriverID,IssuedUsingLocalLicenseID=@IssuedUsingLocalLicenseID" +
                ",IssueDate=@IssueDate, ExpirationDate=@ExpirationDate " +
                ", IsActive=@IsActive " +
                ",CreatedByUserID=@CreatedByUserID " +
                " where InternationalLicenseID= @LicenseID;";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            cmd.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            

            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return (rowsAffected > 0);
        }

        public static bool DeleteLicense(int LicenseID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "delete from InternationalLicenses " +
                " where InternationalLicenseID= @LicenseID;";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                rowsAffected = cmd.ExecuteNonQuery();


            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return rowsAffected > 0;
        }
    }


}
