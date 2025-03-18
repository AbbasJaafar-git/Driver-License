
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
    public class clsTestAppointmentData
    {


        public static DataTable GetAllAppointments()
        {
            DataTable AppointmentTable = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "SELECT *  from  [TestAppointments];";
            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    AppointmentTable.Load(reader);
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return AppointmentTable;
        }

        public static DataTable GetAllAppointments(int LDLAppID,int TestTypeID)
        {
            DataTable AppointmentTable = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "SELECT [TestAppointmentID],[AppointmentDate],[PaidFees],[IsLocked]  from  [TestAppointments]" +
                " where [LocalDrivingLicenseApplicationID]=@LocalDrivingLicenseApplicationID and TestTypeID=@TestTypeID;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAppID);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);



            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    AppointmentTable.Load(reader);
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return AppointmentTable;
        }



        public static bool GetTestAppointment(int TestAppointmentID, ref int TestTypeID
            , ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate
             ,ref double PaidFees, ref int CreatedByUserID,ref bool isLocked,ref int RetakeTestApplicationID)
        {

            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "  select * from TestAppointments where TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    TestTypeID = Convert.ToInt32(reader["TestTypeID"]);
                    LocalDrivingLicenseApplicationID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]);
                    AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                    PaidFees = Convert.ToDouble(reader["PaidFees"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    isLocked = (bool)reader["IsLocked"];
                    if (reader["RetakeTestApplicationID"] != DBNull.Value)
                        RetakeTestApplicationID = Convert.ToInt32(reader["RetakeTestApplicationID"]);
                    else
                        RetakeTestApplicationID = 0;

                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return result;
        }



        public static bool isTestAppointmentExist(int TestAppointmentID)
        {

            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "select isFound=0 from [TestAppointments] " +
                " where TestAppointmentID= @TestAppointmentID;";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

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

        public static int AddNewTestAppointment( int TestTypeID
            ,  int LocalDrivingLicenseApplicationID,  DateTime AppointmentDate
             ,  double PaidFees,  int CreatedByUserID,  bool IsLocked,int RetakeTestApplicationID)
        {

            int ID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "insert into [TestAppointments] " +
                "values(@TestTypeID,@LocalDrivingLicenseApplicationID,@AppointmentDate" +
                ",@PaidFees,@CreatedByUserID,@IsLocked,@RetakeTestApplicationID)" +
                " select SCOPE_IDENTITY(); ";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsLocked", IsLocked);
            if (RetakeTestApplicationID > 0)
                cmd.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            else
                cmd.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);




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

        public static bool UpdateStatus(int TestAppointmentID, bool AppointmentStatus)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "Update  [TestAppointments] " +
                "set IsLocked=@IsLocked " +
                " where TestAppointmentID= @TestAppointmentID; ";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@IsLocked", AppointmentStatus);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return (rowsAffected > 0);
        }


        public static bool UpdateTestAppointment(int TestAppointmentID,int TestTypeID
            , int LocalDrivingLicenseApplicationID, DateTime AppointmentDate
             , double PaidFees, int CreatedByUserID, bool IsLocked,int RetakeTestApplicationID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "Update  [TestAppointments] " +
                "set TestTypeID=@TestTypeID" +
                ",LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID" +
                ",AppointmentDate=@AppointmentDate " +
                ",PaidFees=@PaidFees" +
                ",CreatedByUserID=@CreatedByUserID,IsLocked=@IsLocked" +
                ", RetakeTestApplicationID=@RetakeTestApplicationID  " +
                " where TestAppointmentID= @TestAppointmentID; ";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);

            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsLocked", IsLocked);
            if (RetakeTestApplicationID > 0)
                cmd.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            else
                cmd.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);

            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return (rowsAffected > 0);
        }

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "delete from [TestAppointments] " +
                " where TestAppointmentID= @TestAppointmentID;";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

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
