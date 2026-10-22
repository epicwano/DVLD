using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class clsPersonData
    {

        public static bool GetPersonByID(int PersonID,ref string FirstName, ref string SecondName, ref String ThridName, ref string LastName
            , ref DateTime DateOfBrith, ref byte Gendor, ref string Address, ref string Phone, ref string Email, ref int Nationality, ref string ImagePath)
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

                    if (reader["ThirdName"] != DBNull.Value)
                        ThridName = (string)reader["ThirdName"];
                    else
                        ThridName = "";

                    LastName = (string)reader["LastName"];
                    DateOfBrith = (DateTime)reader["DateOfBrith"];
                    Gendor = (byte)reader["Gendor"];
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
                   SELECT   People.PersonID, People.NationalNo, People.FirstName, People.SecondName, 
                            People.ThirdName, People.LastName, People.DateOfBirth, Gendor = 
                    Case 
                    When Gendor = 1 then 'Female' when Gendor = 0 then 'Male' ELSE 'UnKnown' END,
                            People.Address, People.Phone, People.Email, Countries.CountryName, People.ImagePath
                    FROM        Countries INNER JOIN
                                People ON 
                    Countries.CountryID = People.NationalityCountryID 
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
