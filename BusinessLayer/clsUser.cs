using System;
using System.Data;
using DataAccessLayer;
using Microsoft.SqlServer.Server;

namespace BusinessLayer
{
    public class clsUser 
    {

        public enum enMode { AddNew = 1, Update = 2 };

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public enMode CurrentMode = enMode.AddNew;

        public ClsPerson UserInfo;

        private clsUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;

            this.UserInfo = ClsPerson.Find(PersonID);

            this.CurrentMode = enMode.Update;
        }

        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = false;

            this.CurrentMode = enMode.AddNew;
        }

        public static bool IsUserExists(string UserName,string Password)
        {

            return clsUserData.IsUserExists(UserName,Password);
            
        }

        public static bool IsUserActive(string UserName, string Password)
        {
            return clsUserData.IsUserAcitve(UserName, Password);
        }

        public static clsUser Find(int UserID)
        {
            string UserName = "", Password = "";
            int PersonID = -1;
            bool IsActive = false;

            if (clsUserData.GetUserByUserID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;

        }

        public static clsUser Find(string UserName,string Password)
        {

            int UserID = -1, PersonID = -1;
            bool IsActive = false;

            if (clsUserData.GetUserByUserNameAndPassword(UserName, Password, ref UserID, ref PersonID, ref IsActive))
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;

        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public bool HasAccountOrNot()
        {
            return clsUserData.HasAccountOrNot(this.PersonID);
        }

        private bool _AddNewUser()
        {
            if (this.HasAccountOrNot())
                return false;

            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);

            return (this.UserID != -1);
        }

        private bool _Update()
        {
            return clsUserData.Update(this.UserID,this.PersonID,this.UserName,this.Password,this.IsActive);
        }

        public bool Save()
        {
            switch (this.CurrentMode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                        return true;
                    else
                        return false;

                case enMode.Update:
                    return _Update();
            }

            return false;

        }



    }
}
