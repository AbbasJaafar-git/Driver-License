using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDataAccessLayer
{
    public class clsCountriesData
    {

        public static DataTable GetCountries()
        {

            DataTable dt = new DataTable(); 
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = " select CountryName from Countries;";

            SqlCommand cmd= new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    dt.Load(reader);
                reader.Close();


            }catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return dt;
        }

        public static int GetCountryID(string countryName)
        {

            int id = 0; 
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = " select CountryID from Countries " +
                " where CountryName= @countryName;";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@countryName", countryName);

            try
            {
                connection.Open();
                object obj = cmd.ExecuteScalar();
                if (obj!=null)
                    id= Convert.ToInt32(obj);

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return id;
        }
    }
}
