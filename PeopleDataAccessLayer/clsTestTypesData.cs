
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDataAccessLayer
{
    public class clsTestTypesData
    {
        public static DataTable GetAllTypes()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "Select * from TestTypes;";

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

        public static bool FindTestTypes(int ID, ref string Title, ref string Description, ref double Fees)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = "Select * from TestTypes  where [TestTypeID]= @ID;";


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
                    Description = reader.GetString(2);

                    Fees = Convert.ToDouble(reader["TestTypeFees"]);
                }


            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return result;
        }
        public static bool UpdateType(int ID, string Title, string Description, double Fees)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            string query = "Update TestTypes " +
                
                "set [TestTypeDescription]=@Description " +
                ", [TestTypeTitle]= @Title" +
                ",[TestTypeFees]= @Fees" +
                " where [TestTypeID]= @ID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Description", Description);

            command.Parameters.AddWithValue("@Fees", Fees);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return rowsAffected > 0;
        }
    }
}
