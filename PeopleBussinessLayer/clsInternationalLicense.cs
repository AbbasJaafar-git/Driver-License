
using PeopleDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PeopleBussinessLayer
{
    public class clsInternationalLicense
    {
        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public clsPeople PersonInfo { get; set; }

        public enum enMode { AddNew, Update };
        public enMode Mode = enMode.AddNew;
        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };
        public enIssueReason reason { get; set; }

        public clsInternationalLicense()
        {
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = 0;
            this.IssueDate = DateTime.MinValue;
            this.ExpirationDate = DateTime.MinValue;
            this.IsActive = false;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID
            , int IssuedUsingLocalLicenseID
            , DateTime IssueDate, DateTime ExpirationDate
            , bool IsActive, int CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;
            this.PersonInfo = clsPeople.FindPerson(clsDriver.FindDriver(DriverID).PersonID);
            Mode = enMode.Update;
        }

        public static DataTable GetInternationalLicenses()
        {
            return clsInternationalData.GetAllInternationalLicenses();
        }

        public static DataTable GetInternationalLicensesForPerson(int PersonID)
        {
            return clsInternationalData.GetAllInternationalLicensesForPerson(PersonID);
        }
        public static clsInternationalLicense FindLicense(int InternationalLicenseID)
        {
            int ApplicationID = 0, DriverID = 0, IssuedUsingLocalLicenseID = 0
                , CreatedByUserID = 0;
            bool IsActive = false;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            if (clsInternationalData.GetLicense(InternationalLicenseID, ref ApplicationID, ref DriverID, ref IssuedUsingLocalLicenseID
                , ref IssueDate, ref ExpirationDate
               , ref IsActive,  ref CreatedByUserID
            ))
                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID
                , IssueDate, ExpirationDate
               , IsActive,  CreatedByUserID);
            else return null;
        }

        public static clsInternationalLicense FindLicenseByPersonID(int PersonID)
        {
            int InternationalLicenseID = -1, ApplicationID = 0, DriverID = 0
                , IssuedUsingLocalLicenseID = 0, CreatedByUserID = 0;
            bool IsActive = false;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            if (clsInternationalData.GetLicenseByPersonID(PersonID, ref InternationalLicenseID, ref ApplicationID
                , ref DriverID, ref IssuedUsingLocalLicenseID
                , ref IssueDate, ref ExpirationDate
                , ref IsActive, ref CreatedByUserID
            ))
                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID
                , IssueDate, ExpirationDate
                , IsActive, CreatedByUserID);
            else return null;
        }

        public static bool isLicenseExist(int InternationalLicenseID)
        {
            return (clsInternationalData.isLicenseExist(InternationalLicenseID));
        }

        public static bool isLicenseExistByLocalLicense(int InternationalLicenseID)
        {
            return (clsInternationalData.isLicenseExistByLocalLicense(InternationalLicenseID));
        }

        private bool _AddNewLicense()
        {
            this.InternationalLicenseID = clsInternationalData.AddNewLicense(ApplicationID, DriverID, IssuedUsingLocalLicenseID
                , IssueDate, ExpirationDate
                ,  IsActive, CreatedByUserID);
            return InternationalLicenseID != -1;
        }

        private bool _UpdateLicense()
        {
            return clsInternationalData.UpdateLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID
                , IssueDate, ExpirationDate
                ,  IsActive, CreatedByUserID);
        }

        //public bool CancelLicense()
        //{
        //    return clsLicenseData.UpdateStatus(LicenseID, (int)enIssuedUsingLocalLicenseID.Canceled);
        //}

        //public bool SetComplete()
        //{

        //    return clsLicenseData.UpdateStatus(LicenseID, (int)enIssuedUsingLocalLicenseID.Completed);
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

