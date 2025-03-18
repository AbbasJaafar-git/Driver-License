
using PeopleDataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PeopleBussinessLayer
{
    public class clsDetainedLicense
    {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public double FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }
       
        public clsUsers UserInfo { get; set; }
        public clsLicense LicenseInfo { get; set; }

        public enum enMode { AddNew, Update };
        public enMode Mode = enMode.AddNew;

      

        public clsDetainedLicense()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.MinValue;
            this.FineFees = 0;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.MinValue;

            this.ReleasedByUserID = -1;
            this.ReleaseApplicationID = -1;

            Mode = enMode.AddNew;
        }

        private clsDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate
            , double FineFees, int CreatedByUserID,bool IsReleased, DateTime ReleaseDate
            , int ReleasedByUserID, int ReleaseApplicationID
           )
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;
            this.UserInfo = clsUsers.FindUser(CreatedByUserID);
            this.LicenseInfo = clsLicense.FindLicense(LicenseID);
            Mode = enMode.Update;
        }

        public static DataTable GetDetainedLicenses()
        {
            return clsDetainedLicenseData.GetAllDetainedLicenses();
        }

        public static clsDetainedLicense FindDetainedLicense(int DetainID)
        {
            int LicenseID = 0, ReleasedByUserID = 0, ReleaseApplicationID = 0, CreatedByUserID = 0;
            double FineFees = 0;
            bool IsReleased = false;
            DateTime DetainDate = DateTime.Now, ReleaseDate = DateTime.Now;
            if (clsDetainedLicenseData.GetDetainedLicense(DetainID, ref LicenseID, ref DetainDate
                , ref FineFees, ref CreatedByUserID,ref IsReleased, ref ReleaseDate
                , ref ReleasedByUserID, ref ReleaseApplicationID
            ))
                return new clsDetainedLicense(DetainID, LicenseID, DetainDate
                    , FineFees, CreatedByUserID,IsReleased, ReleaseDate, ReleasedByUserID
                    , ReleaseApplicationID);
            else return null;
        }

        public static clsDetainedLicense FindDetainedLicenseByLicenseID(int  LicenseID)
        {
            int DetainID = 0, ReleasedByUserID = 0, ReleaseApplicationID = 0, CreatedByUserID = 0;
            double FineFees = 0;
            bool IsReleased = false;
            DateTime DetainDate = DateTime.Now, ReleaseDate = DateTime.Now;
            if (clsDetainedLicenseData.GetDetainedLicenseByLicenseID( LicenseID, ref DetainID, ref DetainDate
                , ref FineFees, ref CreatedByUserID, ref IsReleased, ref ReleaseDate
                , ref ReleasedByUserID, ref ReleaseApplicationID
            ))
                return new clsDetainedLicense(DetainID, LicenseID, DetainDate
                    , FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID
                    , ReleaseApplicationID);
            else return null;
        }

        public static bool isLicenseDetained(int LicenseID)
        {
            return (clsDetainedLicenseData.isLicenseDetained(LicenseID));
        }

        private bool _AddNewDetainedLicense()
        {
            this.DetainID = clsDetainedLicenseData.AddNewDetainedLicense( LicenseID, DetainDate
                    , FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID
                    , ReleaseApplicationID);
            return DetainID != -1;
        }

        private bool _UpdateDetainedLicense()
        {
            return clsDetainedLicenseData.UpdateDetainedLicense(DetainID, LicenseID, DetainDate
              , FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID
              , ReleaseApplicationID);
        }

        //public bool CancelApplication()
        //{
        //    return clsDetainedLicenseData.UpdateStatus(DetainID, (int)enReleaseApplicationID.Canceled);
        //}

        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDetainedLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return true;
                case enMode.Update:
                    return _UpdateDetainedLicense();
            }

            return false;

        }

        public static bool Delete(int DetainID)
        {
            return clsDetainedLicenseData.DeleteDetainedLicense(DetainID);
        }
    }
}
