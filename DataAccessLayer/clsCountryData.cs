using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace DataAccessLayer
{
    public class clsCountryData
    {

        public static bool GetCountryByID(int CountryID, ref string CountryName)
        {

            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query =
                @"
                    Select * From Countries
                    Where CountryID = @CountryID
                ";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    CountryName = (string)reader["CountryName"];
                }
                else
                    isFound = false;

            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return isFound;

        }

        public static bool GetCountryByName(string CountryName,ref int CountryID)
        {

            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query =
                @"
                    Select * From Countries
                    Where CountryName = @CountryName
                ";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    CountryID = (int)reader["CountryID"];
                }
                else
                    isFound = false;

            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return isFound;

        }

        public static DataTable GetAllCountries()
        {
            DataTable datatable = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "Select * From Countries";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {

                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                if (reader.HasRows)
                {
                    datatable.Load(reader);
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                // Handle exception if needed
            }
            finally
            {
                Connection.Close();
            }


            return datatable;

        }

    }
}
