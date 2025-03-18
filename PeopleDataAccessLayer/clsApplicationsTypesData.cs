using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDataAccessLayer
{
    public class clsApplicationsTypesData
    {
        public static DataTable GetAllTypes()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "Select * from ApplicationTypes;";

            SqlCommand cmd = new SqlCommand(query, connection); 
            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);
            }catch (Exception ex)
            {

            }finally { connection.Close(); }
            return dt;
        }

        public static bool FindApplicationType(int ID,ref string Title,ref double Fees)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
           
            string query = "Select * from ApplicationTypes  where ApplicationTypeID= @ID;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
  
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;

                    Title = reader.GetString(1);
                    Fees = Convert.ToDouble(reader["ApplicationFees"]);
                }
                

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return result;
        }

        public static bool FindApplicationType( string Title,ref int ID, ref double Fees)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "Select * from ApplicationTypes  where [ApplicationTypeTitle]= @Title;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Title", Title);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;

                    //Title = reader.GetString(1);
                    ID=Convert.ToInt32( reader["ApplicationTypeID"]);
                    Fees = Convert.ToDouble(reader["ApplicationFees"]);
                }


            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return result;
        }
        public static bool UpdateType(int ID,string Title,double Fees)
        {
            int rowsAffected = 0;
            SqlConnection connection= new SqlConnection(ConnectionString.connectionString);
            string query = "Update ApplicationTypes " +
                "set [ApplicationTypeTitle]= @Title," +
                "[ApplicationFees]= @Fees " +
                " where ApplicationTypeID= @ID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Fees", Fees);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return rowsAffected > 0;
        }
    }
}
