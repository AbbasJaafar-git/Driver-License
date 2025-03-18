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
    public class clsUsersData
    {


        public static DataTable GetAllUsers()
        {
            DataTable UsersTable = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "SELECT [UserID],Users.[PersonID]," +
                "[FirstName] +' '+  [SecondName]+' '+ [ThirdName]+' '+[LastName] as fullName" +
                ",[UserName],[IsActive]  FROM [dbo].[Users] join People on People.PersonID = Users.PersonID ";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    UsersTable.Load(reader);
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return UsersTable;
        }

        public static bool FindUser(int UserID,ref int  PersonID,ref string UserName,ref string Password,ref bool IsActive)
        {
            bool result=false;
            SqlConnection connection = new SqlConnection (ConnectionString.connectionString);

            string query = "select * from Users " +
                "where UserID = @UserID;";

            SqlCommand cmd = new SqlCommand (query, connection);
            cmd.Parameters.AddWithValue("@UserID", UserID);

            try
            {

                connection.Open();  
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    PersonID =(int) reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];

                }

                reader.Close();
            }catch (Exception ex) { }
            finally { connection.Close(); }
            return result;

        }
        public static bool FindByUserNameAndPassword(ref int UserID, ref int PersonID,  string UserName
            ,  string Password, ref bool IsActive)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "select * from Users " +
                "where UserName = @UserName and Password = @Password;";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);


            try
            {

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];

                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return result;

        }
        


        public static int AddNewUser(  int PersonID,  string UserName,  string Password,  bool IsActive)
        {

            int UserID = -1;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "insert into Users " +
                " values(@PersonID,@UserName,@Password,@IsActive)" +
                " select scope_identity();";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {

                connection.Open();
                object obj = cmd.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int insertedID))
                    UserID =insertedID;

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return UserID;
        }

        public static bool UpdateUser(int UserID,int PersonID, string UserName, string Password, bool IsActive)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "update  Users " +
                " set PersonID= @PersonID,UserName= @UserName,Password= @Password" +
                ",IsActive=@IsActive " +
                "where UserID= @UserID;";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserID", UserID);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {

                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();
              

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (rowsAffected>0);
        }

        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "delete from Users" +
                " where UserID= @UserID;";

            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@UserID", UserID);
            try
            {

                connection.Open();
                rowsAffected = sqlCommand.ExecuteNonQuery();

            }catch (Exception ex) { }
            finally { connection.Close(); }
            return (rowsAffected>0);
        }


        public static bool IsUserExist(int UserID)
        {
            int rowsAffected = 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString.connectionString);

            string query = "select found=0 from Users " +
                "where UserID= @UserID;";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                sqlConnection.Open();
                rowsAffected = sqlCommand.ExecuteNonQuery();
            }catch(Exception ex) { }
            finally { sqlConnection.Close(); }

            return (rowsAffected> 0);


        }



        public static bool CheckIfPersonHasAUser(int PersonID)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "select isFound=0 from Users" +
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
