using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDataAccessLayer
{
    public class clsLDLAppData
    {
       

        public static DataTable GetLDApps()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "Select * from [LocalDrivingLicenseApplications_View];";

            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return dt;
        }


        public static int GetLDLAppPassedTestsCount(int LocalDrivingLicenseApplicationID)
        {

            int result = -1;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "select [PassedTestCount] from LocalDrivingLicenseApplications_View  " +
                " where [LocalDrivingLicenseApplicationID] = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                object obj= command.ExecuteScalar();

                if (obj != null && int.TryParse(obj.ToString(), out int inserted))
                    result = inserted;

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return result;
        }




        public static bool GetLDLApplication( int LocalDrivingLicenseApplicationID,ref int ApplicationID,ref int LicenseClassID)
        {

            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "  select * from LocalDrivingLicenseApplications " +
                " where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);

                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return result;
        }


        public static bool isLDLApplicationExist(int ID)
        {

            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "select isFound=0 from LocalDrivingLicenseApplications" +
                " where LocalDrivingLicenseApplicationID= @ID;";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ID", ID);

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

        public static int AddNewLDLApplication(int ApplicationID, int LicenseClassID)
        {

            int ID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "insert into LocalDrivingLicenseApplications " +
                "values(@ApplicationID,@LicenseClassID) " +
                " select SCOPE_IDENTITY(); ";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);


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

        public static bool UpdateLDLApplication(int LocalDrivingLicenseApplicationID, int ApplicationID
            , int LicenseClassID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "Update  LocalDrivingLicenseApplications " +
                "set ApplicationID=@ApplicationID,LicenseClassID=@LicenseClassID" +
                " where LocalDrivingLicenseApplicationID= @LocalDrivingLicenseApplicationID; ";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
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

        public static bool DeleteLDLApplication(int LocalDrivingLicenseApplicationID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "delete from LocalDrivingLicenseApplications " +
                " where LocalDrivingLicenseApplicationID= @LocalDrivingLicenseApplicationID;";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();

                rowsAffected = cmd.ExecuteNonQuery();


            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return rowsAffected > 0;
        }

        public static int CheckIfValidForSubmission(string NationalNo,string ClassName)
        {

            int result = -1;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "select * from [LocalDrivingLicenseApplications_View] " +
                " where NationalNo = @NationalNo and ClassName = @ClassName " +
                " and Status not like 'Cancelled';";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
            cmd.Parameters.AddWithValue("@ClassName", ClassName);


            try
            {
                connection.Open();

                object obj = cmd.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int insertedInt))
                    result = insertedInt;

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return result;
        }

        
    }
}
