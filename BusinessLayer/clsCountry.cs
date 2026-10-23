using DataAccessLayer;
using System;
using System.Data;


namespace BusinessLayer
{
    public class clsCountry
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        private clsCountry(int CountryID,string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }

        public static clsCountry Find(int CountryID)
        {
            string CountryName = "";

            if (clsCountryData.GetCountryByID(CountryID, ref CountryName))
                return new clsCountry(CountryID, CountryName);
            else
                return null;

        }
        
        public static clsCountry Find(string CountryName)
        {
            int CountryID = -1;

            if (clsCountryData.GetCountryByName(CountryName, ref CountryID))
                return new clsCountry(CountryID, CountryName);
            else
                return null;

        }

        public static DataTable GetAllCountries()
        {

            return clsCountryData.GetAllCountries();

        }

    }
}
