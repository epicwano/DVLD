using System;
using System.Data;
using DataAccessLayer;
namespace BusinessLayer
{
    public class ClsPerson
    {
        private enum enMode { AddNew = 1, Update = 2 };

        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBrith { get; set; }
        public bool Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Nationality { get; set; }
        public string ImagePath { get; set; }
        private enMode CurrentMode = enMode.AddNew;

        private ClsPerson(int PersonID,string FirstName,string SecondName,string thirdName,string LastName
            ,DateTime DateOfBrith,bool Gendor,string Address,string Phone,string Email,int Nationality,string ImagePath)
        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBrith = DateOfBrith;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.Nationality = Nationality;
            this.ImagePath = ImagePath;

            this.CurrentMode = enMode.Update;
        }

        public static ClsPerson Find(int PersonID)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", phone = "", Email = "", ImagePath = "";
            DateTime DateOfBrith = DateTime.Now;
            bool Gendor = false;
            int Nationality = -1;

            if ((clsPersonData.GetPersonByID(PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBrith,
                ref Gendor, ref Address, ref phone, ref Email, ref Nationality, ref ImagePath)))
            {
                return new ClsPerson(PersonID, FirstName, SecondName, ThirdName, LastName, DateOfBrith, Gendor, Address, phone, Email, Nationality, ImagePath);
            }
            else
                return null;

        }





    }
}
