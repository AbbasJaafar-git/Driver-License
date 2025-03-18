using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleDataAccessLayer;


namespace PeopleBussinessLayer
{
    public class clsCountries
    {
        public static DataTable GetAllCountries()
        {
            return clsCountriesData.GetCountries();
        }

        public static int GetCountryID(string countryName)
        {
            return clsCountriesData.GetCountryID(countryName);
        }
    }
}
