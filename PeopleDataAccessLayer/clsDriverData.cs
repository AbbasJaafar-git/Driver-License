
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDataAccessLayer
{
    public class clsDriverData
    {


        public static DataTable GetAllDrivers()
        {
            DataTable DriversTable = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "Select * from [Drivers_View];";
            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    DriversTable.Load(reader);
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return DriversTable;
        }

        public static bool FindDriver(int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);


            string query = "select * from Drivers " +
                "where DriverID = @DriverID;";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    PersonID = (int)reader["PersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];

                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return result;

        }

        public static bool FindDriverByPersonID(int PersonID, ref int DriverID  , ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);


            string query = "select * from Drivers " +
                "where PersonID = @PersonID;";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    DriverID = (int)reader["DriverID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];

                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return result;

        }

        //public static bool FindByCreatedByUserIDAndPassword(ref int DriverID, ref int PersonID, int CreatedByUserID
        //    , int Password, ref bool CreatedDate)
        //{
        //    bool result = false;
        //    SqlConnection connection = new SqlConnection(Connectionint.connectionint);

        //    int query = "select * from Drivers " +
        //        "where CreatedByUserID = @CreatedByUserID and Password = @Password;";

        //    SqlCommand cmd = new SqlCommand(query, connection);
        //    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
        //    cmd.Parameters.AddWithValue("@Password", Password);


        //    try
        //    {

        //        connection.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            result = true;
        //            DriverID = (int)reader["DriverID"];
        //            PersonID = (int)reader["PersonID"];
        //            CreatedDate = (bool)reader["CreatedDate"];

        //        }

        //        reader.Close();
        //    }
        //    catch (Exception ex) { }
        //    finally { connection.Close(); }
        //    return result;

        //}



        public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {

            int DriverID = -1;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);


            string query = "insert into Drivers " +
                " values(@PersonID,@CreatedByUserID,@CreatedDate)" +
                " select scope_identity();";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);

            try
            {

                connection.Open();
                object obj = cmd.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int insertedID))
                    DriverID = insertedID;

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return DriverID;
        }

        public static bool UpdateDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);


            string query = "update  Drivers " +
                " set PersonID= @PersonID,CreatedByUserID= @CreatedByUserID " +
                ",CreatedDate=@CreatedDate " +
                "where DriverID= @DriverID;";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);

            try
            {

                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();


            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (rowsAffected > 0);
        }

        public static bool DeleteDriver(int DriverID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "delete from Drivers" +
                " where DriverID= @DriverID;";

            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@DriverID", DriverID);
            try
            {

                connection.Open();
                rowsAffected = sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return (rowsAffected > 0);
        }


        public static bool IsDriverExist(int DriverID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);


            string query = "select found=0 from Drivers " +
                " where DriverID= @DriverID;";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                rowsAffected = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (rowsAffected > 0);


        }



        public static bool CheckIfPersonHasADriverID(int PersonID)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "select isFound=0 from Drivers" +
                " where PersonID= @PersonID;";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);

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


    }
}

