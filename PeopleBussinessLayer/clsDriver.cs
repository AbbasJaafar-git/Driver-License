
using PeopleDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PeopleBussinessLayer
{
    public class clsDriver
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }

        public DateTime CreatedDate { get; set; }
       public clsPeople PersonInfo { get; set; }

        public enum enMode { AddNew, Update };
        public enMode Mode = enMode.AddNew;
        public clsDriver()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID =-1;
            this.CreatedDate = DateTime.Now;
            Mode = enMode.AddNew;

        }

        private clsDriver(int DriverId, int personID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverId;
            this.PersonID = personID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            this.PersonInfo = clsPeople.FindPerson(personID);
            Mode = enMode.Update;

        }

        static public bool IsDriverExist(int DriverID)
        {
            return clsDriverData.IsDriverExist(DriverID);
        }

        static public bool DoesPersonHaveADriverID(int PersonId)
        {
            return clsDriverData.CheckIfPersonHasADriverID(PersonId);

        }

        public static clsDriver FindDriver(int DriverID)
        {
            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;
            if (clsDriverData.FindDriver(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;
        }

        public static clsDriver FindDriverByPersonID(int PersonID)
        {
            int DriverID  = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;
            if (clsDriverData.FindDriverByPersonID(PersonID, ref DriverID , ref CreatedByUserID, ref CreatedDate))
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;
        }

        //static public clsDriver FindByCreatedByUserIDAndPassword(int CreatedByUserID, int Password)
        //{
        //    int DriverID = 0, PersonID = 0;
        //    DateTime CreatedDate = false;
        //    if (clsDriverData.FindByCreatedByUserIDAndPassword(ref DriverID, ref PersonID, CreatedByUserID, Password, ref CreatedDate))
        //        return new clsDriver(DriverID, PersonID, CreatedByUserID, Password, CreatedDate);
        //    else
        //        return null;
        //}

        private bool _AddNewDriver()
        {
            DriverID = clsDriverData.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreatedDate);

            return (DriverID != -1);
        }

        private bool _UpdateDriver()
        {
            return clsDriverData.UpdateDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);

        }
        public static DataTable GetAllDrivers()
        {
            return clsDriverData.GetAllDrivers();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriver())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateDriver();

            }
            return false;
        }

        public static bool Delete(int DriverID)
        {

            return clsDriverData.DeleteDriver(DriverID);

        }
    }
}
