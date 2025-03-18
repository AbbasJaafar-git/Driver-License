using PeopleDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PeopleBussinessLayer
{
    public class clsPeople
    {

        public int PersonID { get; set; }
        public string NationalNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName {  get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; } }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string ImagePath { get; set; }
        public int GendorNumber {  get; set; }
        public string Gendor { get; set; }
        public int CountryID { get; set; }

        public enum enMode { AddNew,Update};
        public enMode Mode = enMode.AddNew;



        public clsPeople() { 
            this.PersonID = -1;
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.ThirdName = string.Empty;
            this.LastName = string.Empty;
            this.Address = string.Empty;
            this.Email = string.Empty;
            this.PhoneNumber = string.Empty;
            this.DateOfBirth = DateTime.MinValue;
            this.Nationality = string.Empty;
            this.GendorNumber = 0;
            this.Gendor = string.Empty;
            this.ImagePath= string.Empty;
            
            Mode= enMode.AddNew;
        }

        private clsPeople(int personID, string nationalNumber, string firstName, string secondName, string thirdName
            , string lastName, string address, string email
            , string phoneNumber, DateTime dateOfBirth, string nationality, string imagePath, string gendor)
        {
            PersonID = personID;
            NationalNumber = nationalNumber;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            Nationality = nationality;
            ImagePath = imagePath;
            Gendor = gendor;
            CountryID = clsCountries.GetCountryID(Nationality);
            Mode = enMode.Update;
        }

        public static DataTable GetPeople()
        {
            return clsPeopleData.GetAllPeople();
        }

        public static clsPeople FindPerson (int ID) 
        {
            string nationalNumber="",  firstName="",  secondName="",  thirdName=""
           ,  lastName="",  address="",  email=""
           ,  phoneNumber="", nationality = "",  imagePath="",  gendor="";
            DateTime dateOfBirth=DateTime.Now;
            if(clsPeopleData.GetPerson(ID, ref nationalNumber, ref firstName, ref secondName, ref thirdName
           , ref lastName, ref address, ref email
           , ref phoneNumber, ref dateOfBirth, ref nationality, ref imagePath, ref gendor
            ))
                return new clsPeople(ID, nationalNumber, firstName,secondName,thirdName,lastName,address,email
                    ,phoneNumber,dateOfBirth,nationality,imagePath, gendor);
            else return null;
        }

        public static clsPeople FindPerson(string nationalNumber)
        {
            int ID = 0;
            string firstName = "", secondName = "", thirdName = ""
           , lastName = "", address = "", email = ""
           , phoneNumber = "", nationality = "", imagePath = "", gendor = "";
            DateTime dateOfBirth = DateTime.Now;
            if (clsPeopleData.GetPerson(ref ID, nationalNumber, ref firstName, ref secondName, ref thirdName
           , ref lastName, ref address, ref email
           , ref phoneNumber, ref dateOfBirth, ref nationality, ref imagePath, ref gendor
            ))
                return new clsPeople(ID, nationalNumber, firstName, secondName, thirdName, lastName, address, email
                    , phoneNumber, dateOfBirth, nationality, imagePath, gendor);
            else return null;
        }

        public static bool isNationalNoExist(string nationalNumber)
        {
            return (clsPeopleData.isNationalNoExist(nationalNumber));
        }

        public bool _AddNewPerson()
        {
            this.PersonID = clsPeopleData.AddNewPerson(NationalNumber, FirstName, SecondName, ThirdName
                , LastName, Address, Email, PhoneNumber
                , DateOfBirth, CountryID, ImagePath, GendorNumber);
            return PersonID != -1;
        }

        public bool _UpdatePerson()
        {
            
            return clsPeopleData.UpdatePerson(PersonID,NationalNumber, FirstName, SecondName, ThirdName
                , LastName, Address, Email, PhoneNumber
                , DateOfBirth, CountryID, ImagePath, GendorNumber);
        }


        public bool  Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }else
                        return true;
                case enMode.Update:
                   return _UpdatePerson();
            }

            return false;

        }

        public static bool Delete(int PersonID)
        {
            return clsPeopleData.DeletePerson(PersonID);
        }
    }
}
