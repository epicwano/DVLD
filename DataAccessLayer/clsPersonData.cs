using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class clsPersonData
    {

        public static bool GetPersonByID(int PersonID,ref string FirstName, ref string SecondName, ref String ThridName, ref string LastName
            , ref DateTime DateOfBrith, ref bool Gendor, ref string Address, ref string Phone, ref string Email, ref int Nationality, ref string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query =
                @"
                Select * From People                 
                Where PersonID = @PersonID;
                ";

            SqlCommand command = new SqlCommand(Query,connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            bool isFound = false;
            
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThridName = (string)reader["ThirdName"];
                    LastName = (string)reader["LastName"];
                    DateOfBrith = (DateTime)reader["DateOfBrith"];
                    Gendor = (bool)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];

                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";

                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";

                }

                reader.Close();

            }
            catch
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable GetAllPeople()
        {
            DataTable DT = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query =
                @"
                    Select * From People;  
                ";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    DT.Load(reader);

                reader.Close();

            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return DT;

        }



    }
}
