
using PeopleDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PeopleBussinessLayer
{
    public class clsLicense
    {
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public double PaidFees { get; set; }
        public bool IsActive { get; set; }
        public int IssueReason { get; set; }
        public int CreatedByUserID { get; set; }
        public clsPeople PersonInfo { get; set; }

        public enum enMode { AddNew, Update };
        public enMode Mode = enMode.AddNew;
        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };
        public enIssueReason reason { get; set; }

        public clsLicense()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = 0;
            this.IssueDate = DateTime.MinValue;
            this.ExpirationDate = DateTime.MinValue;
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = false;
            this.IssueReason =(int) enIssueReason.FirstTime;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass
            , DateTime IssueDate, DateTime ExpirationDate, string Notes
            , double PaidFees, bool IsActive, int IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive=IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;
            this.PersonInfo = clsPeople.FindPerson(clsDriver.FindDriver(DriverID).PersonID);
            Mode = enMode.Update;
        }

        public static DataTable GetLicenses()
        {
            return clsLicenseData.GetAllLicenses();
        }

        public static DataTable GetLicensesForPerson(int PersonID)
        {
            return clsLicenseData.GetAllLicensesForPerson(PersonID);
        }
        public static clsLicense FindLicense(int LicenseID)
        {
            int ApplicationID = 0, DriverID = 0, LicenseClass = 0, IssueReason=0, CreatedByUserID = 0;
            bool IsActive = false;
            string Notes = "";
            double PaidFees = 0;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            if (clsLicenseData.GetLicense(LicenseID, ref ApplicationID, ref DriverID,ref LicenseClass
                ,ref IssueDate, ref ExpirationDate
                , ref Notes, ref PaidFees,ref IsActive,ref IssueReason, ref CreatedByUserID
            ))
                return new clsLicense(LicenseID,  ApplicationID,  DriverID,  LicenseClass
                ,  IssueDate,  ExpirationDate
                ,  Notes,  PaidFees,  IsActive,  IssueReason,  CreatedByUserID);
            else return null;
        }

        public static clsLicense FindLicenseByPersonID(int PersonID,int LicenseClassID)
        {
            int LicenseID=-1, ApplicationID = 0, DriverID = 0, LicenseClass = 0, IssueReason = 0, CreatedByUserID = 0;
            bool IsActive = false;
            string Notes = "";
            double PaidFees = 0;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            if (clsLicenseData.GetLicenseByPersonID(PersonID, LicenseClassID, ref LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass
                , ref IssueDate, ref ExpirationDate
                , ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID
            ))
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass
                , IssueDate, ExpirationDate
                , Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            else return null;
        }

        public static clsLicense FindActiveLicenseByPersonID(int PersonID, int LicenseClassID)
        {
            int LicenseID = -1, ApplicationID = 0, DriverID = 0, LicenseClass = 0, IssueReason = 0, CreatedByUserID = 0;
            bool IsActive = false;
            string Notes = "";
            double PaidFees = 0;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            if (clsLicenseData.GetActiveLicenseByPersonID(PersonID, LicenseClassID, ref LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass
                , ref IssueDate, ref ExpirationDate
                , ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID
            ))
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass
                , IssueDate, ExpirationDate
                , Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            else return null;
        }

        public static bool isLicenseExist(int LicenseID)
        {
            return (clsLicenseData.isLicenseExist(LicenseID));
        }

        //public static bool doesDriverHaveAnActiveLicense(int LicenseID)
        //{
        //    return (clsLicenseData.doesDriverHaveAnActiveLicense(LicenseID));
        //}



        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicenseData.AddNewLicense(ApplicationID, DriverID, LicenseClass
                , IssueDate, ExpirationDate
                , Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            return LicenseID != -1;
        }

        private bool _UpdateLicense()
        {
            return clsLicenseData.UpdateLicense(LicenseID,ApplicationID, DriverID, LicenseClass
                , IssueDate, ExpirationDate
                , Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
        }

        //public bool CancelLicense()
        //{
        //    return clsLicenseData.UpdateStatus(LicenseID, (int)enLicenseClass.Canceled);
        //}

        //public bool SetComplete()
        //{

        //    return clsLicenseData.UpdateStatus(LicenseID, (int)enLicenseClass.Completed);
        //}

        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return true;
                case enMode.Update:
                    return _UpdateLicense();
            }

            return false;

        }

        public static bool Delete(int LicenseID)
        {
            return clsLicenseData.DeleteLicense(LicenseID);
        }
    }
}

