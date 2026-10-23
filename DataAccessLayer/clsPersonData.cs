using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace DataAccessLayer
{
    public class clsPersonData
    {

        public static bool GetPersonByID(int PersonID,ref string NationalNo, ref string FirstName, ref string SecondName, ref String ThridName, ref string LastName
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

                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] != DBNull.Value)
                        ThridName = (string)reader["ThirdName"];
                    else
                        ThridName = "";

                    LastName = (string)reader["LastName"];
                    DateOfBrith = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];

                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";

                    Nationality = (int)reader["NationalityCountryID"];

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
                            People.Address, People.Phone, People.Email, Countries.CountryName
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

        public static bool Delete(int PersonID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Delete From People Where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (RowsAffected > 0);


        }

        public static int AddNewPerson(string NationalNo,string FirstName,string SecondName, String ThirdName, string LastName
            , DateTime DateOfBirth, byte Gendor, string Address,  string Phone, string Email, int Nationality, string ImagePath)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"   
                                insert into People
                                (NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gendor,Address,Phone,Email
                                 ,NationalityCountryID,ImagePath)
                                Values
                                (@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gendor
                                 ,@Address,@Phone,@Email,@Nationality,@ImagePath)
                                select Scope_Identity();
                            ";


            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName != "")
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != "")
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", DBNull.Value);

            command.Parameters.AddWithValue("@Nationality", Nationality);

            if (ImagePath != "")
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);


            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(),out int insertedID))
                    PersonID = insertedID;
                


            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return PersonID;

        }

        public static bool Update(int PersonID,string NationalNo, string FirstName, string SecondName, String ThridName, string LastName
            , DateTime DateOfBirth, byte Gendor, string Address, string Phone, string Email, int Nationality, string ImagePath)
        {

            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"   
                                Update People
                                set NationalNo = @NationalNo,
                                 FirstName = @FirstName,
                                 SecondName = @SecondName,
                                 ThirdName = @ThirdName,
                                 LastName = @LastName,
                                 DateOfBirth = @DateOfBirth,
                                 Gendor = @Gendor,
                                 Address = @Address,
                                 Phone = @Phone,
                                 Email = @Email,
                                 NationalityCountryID = @Nationality,
                                 ImagePath = @ImagePath
                                Where PersonID = @PersonID;
                            ";


            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThridName != "")
                command.Parameters.AddWithValue("@ThirdName", ThridName);
            else
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != "")
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", DBNull.Value);

            command.Parameters.AddWithValue("@Nationality", Nationality);

            if (ImagePath != "")
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

            command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return (RowsAffected > 0);

        }

        public static bool isPersonExists(string NationalNO)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Select Found = 1 from People 
                             Where NationalNO = @NationalNO    
                            ";


            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@NationalNO", NationalNO);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;


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

        public static bool isPersonExists(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Select Found = 1 from People 
                             Where PersonID = @PersonID    
                            ";


            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;


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
    }
}
