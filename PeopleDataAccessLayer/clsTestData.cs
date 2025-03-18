
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
    public class clsTestData
    {


        public static DataTable GetAllTests()
        {
            DataTable TestTable = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "SELECT *  from  [Tests];";
            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    TestTable.Load(reader);
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return TestTable;
        }


        public static bool GetTest(int TestID, ref int  TestAppointmentID, ref bool TestResult
             , ref string Notes, ref int CreatedByUserID)
        {

            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "  select * from Tests where TestID = @TestID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    TestAppointmentID = Convert.ToInt32(reader["TestAppointmentID"]);
                    TestResult = (bool)reader["TestResult"];
                    Notes = Convert.ToString(reader["Notes"]);
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

        public static bool GetTestByAppointment(int TestAppointmentID , ref int TestID , ref bool TestResult
            , ref string Notes, ref int CreatedByUserID)
        {

            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "  select * from Tests where TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    TestID = Convert.ToInt32(reader["TestID"]);
                    TestResult = (bool)reader["TestResult"];
                    Notes = Convert.ToString(reader["Notes"]);
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


        public static bool isTestExist(int TestID)
        {

            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "select isFound=0 from [Tests] " +
                " where TestID= @TestID;";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@TestID", TestID);

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

        public static int AddNewTest(int TestAppointmentID, bool TestResult
             , string Notes, int CreatedByUserID)
        {

            int ID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "insert into Tests " +
                "values(@TestAppointmentID,@TestResult,@Notes" +
                ",@CreatedByUserID)" +
                " select SCOPE_IDENTITY(); ";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@TestResult", TestResult);
            cmd.Parameters.AddWithValue("@Notes", Notes);
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

        //public static bool UpdateStatus(int TestAppointmentID, bool AppointmentStatus)
        //{

        //    int rowsAffected = 0;

        //    SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
        //    string query = "Update  Applications " +
        //        "set TestResult=@TestResult " +
        //        " where TestAppointmentID= @TestAppointmentID; ";

        //    SqlCommand cmd = new SqlCommand(query, connection);
        //    cmd.Parameters.AddWithValue("@TestResult", AppointmentStatus);
        //    cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
        //    try
        //    {
        //        connection.Open();
        //        rowsAffected = cmd.ExecuteNonQuery();

        //    }
        //    catch (Exception ex) { }
        //    finally { connection.Close(); }
        //    return (rowsAffected > 0);
        //}


        public static bool UpdateTest(int TestID, int TestAppointmentID , bool TestResult
             , string Notes, int CreatedByUserID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "Update  Tests " +
                "set TestAppointmentID=@TestAppointmentID" +
                ",TestResult=@TestResult" +
                ",Notes=@Notes" +
                ",CreatedByUserID=@CreatedByUserID  " +
                " where TestID= @TestID; ";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TestID", TestID);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@TestResult", TestResult);

            cmd.Parameters.AddWithValue("@Notes", Notes);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return (rowsAffected > 0);
        }

        public static bool DeleteTest(int TestID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "delete from [Tests] " +
                " where TestID= @TestID;";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@TestID", TestID);

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
