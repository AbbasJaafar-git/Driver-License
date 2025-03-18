
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PeopleDataAccessLayer
{
    public class clsApplicationData
    {


        public static DataTable GetAllApplications()
        {
            DataTable ApplicationTable = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query =" SELECT [ApplicationID],[ApplicantPersonID],[ApplicationDate],[ApplicationTypeID]" +
                ",[ApplicationStatus],[LastStatusDate],[PaidFees],[CreatedByUserID] FROM[DVLD].[dbo].[Applications] ";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    ApplicationTable.Load(reader);
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return ApplicationTable;
        }


        public static bool GetApplication(int ApplicationID,ref int ApplicantPersonID,ref DateTime ApplicationDate
            ,ref int ApplicationTypeID,ref int ApplicationStatus
            ,ref DateTime LastStatusDate,ref double PaidFees,ref int CreatedByUserID)
        {

            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "  select * from Applications where ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    ApplicantPersonID = Convert.ToInt32(reader["ApplicantPersonID"]);
                    ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]);
                    ApplicationTypeID = Convert.ToInt32(reader["ApplicationTypeID"]);
                    ApplicationStatus = Convert.ToInt32(reader["ApplicationStatus"]);
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = Convert.ToDouble(reader["PaidFees"]);
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
      


        public static bool isApplicationExist(int ApplicationID)
        {

            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "select isFound=0 from Applications" +
                " where ApplicationID= @ApplicationID;";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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

        public static int AddNewApplication(  int ApplicantPersonID,  DateTime ApplicationDate
            ,  int ApplicationTypeID,  int ApplicationStatus
            ,  DateTime LastStatusDate,  double PaidFees, int CreatedByUserID)
        {

            int ID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "insert into Applications " +
                "values(@ApplicantPersonID,@ApplicationDate,@ApplicationTypeID,@ApplicationStatus" +
                ",@LastStatusDate,@PaidFees,@CreatedByUserID)" +
                " select SCOPE_IDENTITY(); ";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            cmd.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
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

        public static bool UpdateStatus(int ApplicationID, int ApplicationStatus )
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "Update  Applications " +
                "set ApplicationStatus=@ApplicationStatus ,LastStatusDate=@LastStatusDate" +
                " where ApplicationID= @ApplicationID; ";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return (rowsAffected > 0);
        }


        public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate
            , int ApplicationTypeID, int ApplicationStatus
            , DateTime LastStatusDate, double PaidFees, int CreatedByUserID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "Update  Applications " +
                "set ApplicantPersonID=@ApplicantPersonID,ApplicationDate=@ApplicationDate" +
                ",ApplicationTypeID=@ApplicationTypeID,ApplicationStatus=@ApplicationStatus" +
                ",LastStatusDate=@LastStatusDate,PaidFees=@PaidFees" +
                ",CreatedByUserID=@CreatedByUserID " +
                " where ApplicationID= @ApplicationID; ";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            cmd.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return (rowsAffected > 0);
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "delete from Applications " +
                " where ApplicationID= @ApplicationID;";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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
