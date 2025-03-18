using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDataAccessLayer
{
    public class clsLicenseClassData
    {
        public static DataTable GetLicenses()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = " select * from LicenseClasses;";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    dt.Load(reader);
                reader.Close();


            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return dt;
        }

        public static int GetLicenseClassID(string ClassName)
        {

            int id = 0;
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

            string query = " select [LicenseClassID] from [LicenseClasses] " +
                " where ClassName= @ClassName;";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();
                object obj = cmd.ExecuteScalar();
                if (obj != null)
                    id = Convert.ToInt32(obj);

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return id;
        }

        public static bool Find(int LicenseID,ref string ClassName,ref string Desc,ref int MinAge
            ,ref int DefLen,ref double Fees)
        {

            bool result=false;
            SqlConnection connection = new SqlConnection (ConnectionString.connectionString);
            string query = "select * from [LicenseClasses]" +
                " where [LicenseClassID]= @LicenseID;";
            SqlCommand cmd= new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    ClassName = reader[1].ToString();
                    Desc = reader[2].ToString();
                    MinAge=Convert.ToInt32( reader["MinimumAllowedAge"]);
                    DefLen = Convert.ToInt32(reader["DefaultValidityLength"]);
                    Fees = Convert.ToDouble(reader["ClassFees"]);
                }
                
            }catch (Exception ex) { }
            finally { connection.Close(); }
            return result;
        }
    }
}
