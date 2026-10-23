using System;
using System.Data;
using DataAccessLayer;
namespace BusinessLayer
{
    public class ClsPerson
    {
        private enum enMode { AddNew = 1, Update = 2 };

        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBrith { get; set; }
        public byte Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Nationality { get; set; }
        public string ImagePath { get; set; }
        private enMode CurrentMode = enMode.AddNew;

        private ClsPerson(int PersonID,string NationalNo, string FirstName,string SecondName,string thirdName,string LastName
            ,DateTime DateOfBrith,byte Gendor,string Address,string Phone,string Email,int Nationality,string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
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

        public ClsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBrith = DateTime.Now;
            this.Gendor = 0;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.Nationality = -1;
            this.ImagePath = "";

            this.CurrentMode = enMode.AddNew;
        }

        public static ClsPerson Find(int PersonID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", phone = "", Email = "", ImagePath = "";
            DateTime DateOfBrith = DateTime.Now;
            byte Gendor = 1;
            int Nationality = -1;

            if ((clsPersonData.GetPersonByID(PersonID,ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBrith,
                ref Gendor, ref Address, ref phone, ref Email, ref Nationality, ref ImagePath)))
            {
                return new ClsPerson(PersonID,NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBrith, Gendor, Address, phone, Email, Nationality, ImagePath);
            }
            else
                return null;

        }

        public static DataTable GetAllPepole()
        {
            return clsPersonData.GetAllPeople();
        }

        public static bool Delete(int PersonID)
        {
            return clsPersonData.Delete(PersonID);
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName
                ,this.DateOfBrith, this.Gendor, this.Address, this.Phone, this.Email, this.Nationality, this.ImagePath);

            return (this.PersonID != -1);

        }
        
        private bool _Update()
        {

            return clsPersonData.Update(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName
                , this.DateOfBrith, this.Gendor, this.Address, this.Phone, this.Email, this.Nationality, this.ImagePath);

        }

        public bool Save()
        {
            switch (CurrentMode)
            {

                case enMode.AddNew:
                    if (_AddNewPerson())
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
