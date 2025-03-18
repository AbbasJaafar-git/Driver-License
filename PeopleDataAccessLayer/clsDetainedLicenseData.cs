
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
    public class clsDetainedLicenseData
    {


        public static DataTable GetAllDetainedLicenses()
        {
            DataTable ApplicationTable = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);


            string query = "SELECT TOP (1000) [DetainID],[LicenseID],[DetainDate],[IsReleased]" +
                " ,[FineFees],[ReleaseDate] ,[NationalNo]  ,[FullName] " +
                "  ,[ReleaseApplicationID] FROM [DVLD].[dbo].[DetainedLicenses_View] ";

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


        public static bool GetDetainedLicense(int DetainID, ref int LicenseID, ref DateTime DetainDate
            , ref double FineFees, ref int CreatedByUserID, ref bool IsReleased
            , ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {

            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "  select * from [DetainedLicenses] where DetainID = @DetainID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    LicenseID = Convert.ToInt32(reader["LicenseID"]);
                    DetainDate = Convert.ToDateTime(reader["DetainDate"]);
                    FineFees = Convert.ToDouble(reader["FineFees"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    IsReleased = Convert.ToBoolean(reader["IsReleased"]);
                    if (reader["ReleaseDate"]!=DBNull.Value)
                        ReleaseDate = (DateTime)reader["ReleaseDate"];
                    //else
                     //   ReleaseDate = DateTime.MinValue;
                    if(reader["ReleasedByUserID"] != DBNull.Value)
                        ReleasedByUserID = Convert.ToInt32(reader["ReleasedByUserID"]); 
                    if(reader["ReleaseApplicationID"]!=DBNull.Value)
                        ReleaseApplicationID = Convert.ToInt32(reader["ReleaseApplicationID"]);

                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return result;
        }

        public static bool GetDetainedLicenseByLicenseID(int  LicenseID, ref int DetainID, ref DateTime DetainDate
          , ref double FineFees, ref int CreatedByUserID, ref bool IsReleased
          , ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {

            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "  select * from [DetainedLicenses] where LicenseID = @LicenseID " +
                " and IsReleased=0;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    DetainID = Convert.ToInt32(reader["DetainID"]);
                    DetainDate = Convert.ToDateTime(reader["DetainDate"]);
                    FineFees = Convert.ToDouble(reader["FineFees"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    IsReleased = Convert.ToBoolean(reader["IsReleased"]);
                    if (reader["ReleaseDate"] != DBNull.Value)
                        ReleaseDate = (DateTime)reader["ReleaseDate"];
                    //else
                    //   ReleaseDate = DateTime.MinValue;
                    if (reader["ReleasedByUserID"] != DBNull.Value)
                        ReleasedByUserID = Convert.ToInt32(reader["ReleasedByUserID"]);
                    if (reader["ReleaseApplicationID"] != DBNull.Value)
                        ReleaseApplicationID = Convert.ToInt32(reader["ReleaseApplicationID"]);

                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return result;
        }

        public static bool isLicenseDetained(int LicenseID)
        {

            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "select isFound=0 from DetainedLicenses" +
                " where LicenseID= @LicenseID and IsReleased=0;";
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

        public static int AddNewDetainedLicense( int LicenseID,  DateTime DetainDate
            ,  double FineFees, int CreatedByUserID,  bool IsReleased
            ,  DateTime ReleaseDate,  int ReleasedByUserID, int ReleaseApplicationID)
        {

            int ID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "insert into DetainedLicenses " +
                "values(@LicenseID,@DetainDate,@FineFees,@CreatedByUserID" +
                ",@IsReleased,@ReleaseDate,@ReleasedByUserID,@ReleaseApplicationID)" +
                " select SCOPE_IDENTITY(); ";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            cmd.Parameters.AddWithValue("@DetainDate", DetainDate);
            cmd.Parameters.AddWithValue("@FineFees", FineFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsReleased", IsReleased);
            //if( ReleaseDate != null  )
            //     cmd.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            //else 
                 cmd.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
            if ( ReleasedByUserID != -1)
                cmd.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            else
                cmd.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
            if(ReleaseApplicationID!=-1)
                cmd.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            else
                cmd.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);





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

        //public static bool RealeseLicense(int DetainID, int IsReleased)
        //{
        //    int rowsAffected = 0;

        //    SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
        //    string query = "Update  [DetainedLicenses] " +
        //        "set ApplicationStatus=@ApplicationStatus ,ReleaseDate=@ReleaseDate" +
        //        " where DetainID= @DetainID; ";

        //    SqlCommand cmd = new SqlCommand(query, connection);
        //    cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
        //    cmd.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
        //    cmd.Parameters.AddWithValue("@DetainID", DetainID);
        //    try
        //    {
        //        connection.Open();
        //        rowsAffected = cmd.ExecuteNonQuery();

        //    }
        //    catch (Exception ex) { }
        //    finally { connection.Close(); }
        //    return (rowsAffected > 0);
        //}


        public static bool UpdateDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate
            , double FineFees, int CreatedByUserID, bool IsReleased
            , DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "Update  [DetainedLicenses] " +
                "set LicenseID=@LicenseID,DetainDate=@DetainDate" +
                ",FineFees=@FineFees,CreatedByUserID=@CreatedByUserID" +
                ",IsReleased=@IsReleased,ReleaseDate=@ReleaseDate" +
                ",ReleasedByUserID=@ReleasedByUserID,ReleaseApplicationID=@ReleaseApplicationID " +
                " where DetainID= @DetainID; ";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            cmd.Parameters.AddWithValue("@DetainDate", DetainDate);
            cmd.Parameters.AddWithValue("@FineFees", FineFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsReleased", IsReleased);
            if (ReleaseDate != null)
                cmd.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            else
                cmd.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
            if (ReleasedByUserID != -1)
                cmd.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            else
                cmd.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
            if (ReleaseApplicationID != -1)
                cmd.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            else
                cmd.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);
            cmd.Parameters.AddWithValue("@DetainID", DetainID);


            try
            {
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return (rowsAffected > 0);
        }

        public static bool DeleteDetainedLicense(int DetainID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "delete from [DetainedLicenses] " +
                " where DetainID= @DetainID;";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@DetainID", DetainID);

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
