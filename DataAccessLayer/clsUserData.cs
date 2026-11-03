using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
using System.Runtime.InteropServices;

namespace DataAccessLayer
{
    public class clsUserData
    {

        public static bool IsUserExists(string UserName,string Password)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Select Found = 1 From Users Where UserName = @UserName And Password = @Password";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserName",UserName);
            command.Parameters.AddWithValue("@Password",Password);

            bool IsFound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

            }
            catch
            {

                IsFound = false;

            }
            finally
            {
                connection.Close();
            }

            return IsFound;

        }

        public static bool IsUserAcitve(string UserName,string Password)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Select IsActive From Users Where UserName = @UserName And Password = @Password";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            bool IsActive = false;

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();
                bool.TryParse(Result.ToString(), out bool IsActiveByte);

                IsActive = (IsActiveByte == true);

            }
            catch
            {

                IsActive = false;

            }
            finally
            {
                connection.Close();
            }

            return IsActive;

        }

        public static bool GetUserByUserID(int UserID,ref int PersonID,ref string UserName,ref string Password,ref bool IsActive)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"
                                select * From Users Where
                                UserID = @UserID
                            ";


            SqlCommand command = new SqlCommand(Query,connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];

                }
                else
                    IsFound = false;

                reader.Close();

            }
            catch
            {

                IsFound = false;

            }
            finally
            {

                connection.Close();

            }

            return IsFound;
        }

        public static bool GetUserByUserNameAndPassword(string UserName,string Password,ref int UserID,ref int PersonID,ref bool IsActive)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"
                                select * From Users Where
                                UserName = @UserName AND Password = @Password
                            ";


            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];

                }
                else
                    IsFound = false;

                reader.Close();

            }
            catch
            {

                IsFound = false;

            }
            finally
            {

                connection.Close();

            }

            return IsFound;
        }
    
        public static DataTable GetAllUsers()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query =
                @"
                    Select Users.UserID,Users.PersonID, FullName = CONCAT(People.FirstName, ' ', People.SecondName, ' ', People.ThirdName, ' ', People.LastName),
                    Users.UserName,Users.Password,Users.IsActive,People.Gendor,

                    Case 
                    When Gendor = 0 then 'Male' 
                    else 'Female'
                    END as GendorCaption,

                    People.NationalNo,People.DateOfBirth,People.Address, People.Phone, People.Email,People.NationalityCountryID,Countries.CountryName
 
                    from Users inner join 
                    People on Users.PersonID = People.PersonID inner join 
                    Countries on People.NationalityCountryID = Countries.CountryID
                ";

            SqlCommand command = new SqlCommand(Query, connection);

            DataTable dtUsers = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dtUsers.Load(reader);


            }
            catch
            {

                // do something

            }
            finally
            {
                connection.Close();
            }

            return dtUsers;
        }
        
        public static int AddNewUser(int PersonID,string UserName,string Password,bool IsActive)
        {
            int UserID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query =
                @"
                    insert into Users
                    (PersonID,UserName,Password,IsActive)
                    Values
                    (@PersonID,@UserName,@Password,@IsActive)
                    select Scope_Identity();
                ";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            
            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (int.TryParse(Result.ToString(), out int InsertedID))
                    UserID = InsertedID;


            }
            catch
            {


            }
            finally
            {
                connection.Close();
            }

            return UserID;

        }

        public static bool Update(int UserID,int PersonID,string UserName,string Password,bool IsActive)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query =
                @"
                    Update Users  
                    set UserName = @UserName,
                        Password = @Password,
                        IsActive = @IsActive
                    Where UserID = @UserID;
                ";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserID",UserID);
            command.Parameters.AddWithValue("@UserName",UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

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

        public static bool HasAccountOrNot(int PersonID)
        {
            bool HasAccount = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Qury = @"
                            Select Found = 1 From Users Where PersonID = @PersonID
                          ";


            SqlCommand command = new SqlCommand(Qury, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                HasAccount = reader.HasRows;

            }
            catch
            {
                HasAccount  = false;
            }
            finally
            {
                connection.Close();
            }

            return HasAccount;

        }
    }

}
