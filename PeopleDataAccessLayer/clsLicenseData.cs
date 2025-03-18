
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
    public class clsLicenseData
    {


        public static DataTable GetAllLicenses()
        {
            DataTable LicenseTable = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = " SELECT * from [Licenses] ";

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

        public static DataTable GetAllLicensesForPerson(int PersonID)
        {
            DataTable LicenseTable = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "select LicID = Licenses.LicenseID, Licenses.ApplicationID as AppID" +
                ",LicenseClasses.ClassName  " +
                ",Licenses.IssueDate,Licenses.ExpirationDate,Licenses.IsActive from Licenses join" +
                " LicenseClasses " +
                "  on Licenses.LicenseClass= LicenseClasses.LicenseClassID join " +
                " Drivers on Drivers.DriverID=Licenses.DriverID  " +
                "   where Drivers.PersonID=@PersonID";

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

        

            
        public static bool GetLicense(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClass
            , ref DateTime IssueDate, ref DateTime ExpirationDate,ref string Notes
            , ref double PaidFees,ref bool IsActive,ref int IssueReason , ref int CreatedByUserID)
        {

            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "  select * from Licenses where LicenseID = @LicenseID;";

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
                    LicenseClass = Convert.ToInt32(reader["LicenseClass"]);
                    IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    if (reader["Notes"]!= DBNull.Value)
                        Notes = (string)reader["ExpirationDate"];
                    else
                        Notes = "";
                    PaidFees = Convert.ToDouble(reader["PaidFees"]);
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                    IssueReason = Convert.ToInt32(reader["IssueReason"]);
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

        public static bool GetLicenseByPersonID(int PersonID,int LicenseClassID,ref int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClass
         , ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes
         , ref double PaidFees, ref bool IsActive, ref int IssueReason, ref int CreatedByUserID)
        {

            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "select Licenses.* from Licenses join Drivers " +
                " on Licenses.DriverID = Drivers.DriverID  where Drivers.PersonID=@PersonID" +
                " and LicenseClass=@LicenseClass;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;

                    LicenseID = Convert.ToInt32(reader["LicenseID"]);
                    ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    DriverID = Convert.ToInt32(reader["DriverID"]);
                    LicenseClass = Convert.ToInt32(reader["LicenseClass"]);
                    IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    if (reader["Notes"] != DBNull.Value)
                        Notes = (string)reader["ExpirationDate"];
                    else
                        Notes = "";
                    PaidFees = Convert.ToDouble(reader["PaidFees"]);
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                    IssueReason = Convert.ToInt32(reader["IssueReason"]);
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

        public static bool GetActiveLicenseByPersonID(int PersonID, int LicenseClassID, ref int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClass
        , ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes
        , ref double PaidFees, ref bool IsActive, ref int IssueReason, ref int CreatedByUserID)
        {

            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "select Licenses.* from Licenses join Drivers " +
                " on Licenses.DriverID = Drivers.DriverID  where Drivers.PersonID=@PersonID" +
                " and LicenseClass=@LicenseClass and IsActive=1;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;

                    LicenseID = Convert.ToInt32(reader["LicenseID"]);
                    ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    DriverID = Convert.ToInt32(reader["DriverID"]);
                    LicenseClass = Convert.ToInt32(reader["LicenseClass"]);
                    IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    if (reader["Notes"] != DBNull.Value)
                        Notes = (string)reader["ExpirationDate"];
                    else
                        Notes = "";
                    PaidFees = Convert.ToDouble(reader["PaidFees"]);
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                    IssueReason = Convert.ToInt32(reader["IssueReason"]);
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
            string query = "select isFound=0 from Licenses" +
                " where LicenseID= @LicenseID;";
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

        public static int AddNewLicense( int ApplicationID, int DriverID,int LicenseClass
            ,  DateTime IssueDate,  DateTime ExpirationDate,  string Notes
            , double PaidFees,  bool IsActive,  int IssueReason,  int CreatedByUserID)
        {

            int ID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "insert into Licenses " +
                "values(@ApplicationID,@DriverID,@LicenseClass" +
                ",@IssueDate,@ExpirationDate,@Notes,@PaidFees,@IsActive,@IssueReason,@CreatedByUserID)" +
                " select SCOPE_IDENTITY(); ";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            cmd.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            if(Notes!="")
                cmd.Parameters.AddWithValue("@Notes", Notes);
            else
                cmd.Parameters.AddWithValue("@Notes", DBNull.Value);

            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IssueReason", IssueReason);
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

        public static bool UpdateStatus(int LicenseID, int LicenseClass)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "Update  Licenses " +
                "set LicenseClass=@LicenseClass ,ExpirationDate=@ExpirationDate" +
                " where LicenseID= @LicenseID; ";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            cmd.Parameters.AddWithValue("@ExpirationDate", DateTime.Now);
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


        public static bool UpdateLicense(int LicenseID,int ApplicationID, int DriverID, int LicenseClass
            , DateTime IssueDate, DateTime ExpirationDate, string Notes
            , double PaidFees, bool IsActive, int IssueReason, int CreatedByUserID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "Update  Licenses " +
                "set ApplicationID=@ApplicationID" +
                ",DriverID=@DriverID,LicenseClass=@LicenseClass" +
                ",IssueDate=@IssueDate, ExpirationDate=@ExpirationDate,Notes=@Notes" +
                ", PaidFees=@PaidFees,IsActive=@IsActive,IssueReason=@IssueReason" +
                ",CreatedByUserID=@CreatedByUserID " +
                " where LicenseID= @LicenseID;";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            cmd.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            if (Notes != "")
                cmd.Parameters.AddWithValue("@Notes", Notes);
            else
                cmd.Parameters.AddWithValue("@Notes", DBNull.Value);

            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IssueReason", IssueReason);
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
            string query = "delete from Licenses " +
                " where LicenseID= @LicenseID;";
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
