using PeopleDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PeopleBussinessLayer
{
    public class clsLDLApplications : clsApplication
    {

        public enum enMode { AddNew, Update };
        public enMode Mode = enMode.AddNew;
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        
       public clsLDLApplications()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.MinValue;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = 0;
            this.LastStatusDate = DateTime.MinValue;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;

            this.LicenseClassID = -1;
            Mode = enMode.AddNew;


        }

        private clsLDLApplications(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicantPersonID
            , DateTime ApplicationDate
           , int ApplicationTypeID, int ApplicationStatus
           , DateTime LastStatusDate, double PaidFees, int CreatedByUserID,int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClassID = LicenseClassID;
            this.PersonInfo = clsPeople.FindPerson(ApplicantPersonID);
            this.UserInfo=clsUsers.FindUser(CreatedByUserID);

            Mode = enMode.Update;
        }

        public static DataTable GetAllLDApplications()
        {

            return clsLDLAppData.GetLDApps();
        }

        public static int GetLDLAppPassedTestsCount(int LDLAppID)
        {
            return clsLDLAppData.GetLDLAppPassedTestsCount(LDLAppID);
        }

        public static clsLDLApplications FindLDLApplication (int LocalDrivingLicenseApplicationID)
        {
            int applicationID=-1,LicenseClassID = 0;

            if (clsLDLAppData.GetLDLApplication(LocalDrivingLicenseApplicationID,ref applicationID, ref LicenseClassID))
            {
                clsApplication application = clsApplication.FindApplication(applicationID);
                return new clsLDLApplications(LocalDrivingLicenseApplicationID, applicationID, application.ApplicantPersonID
                    , application.ApplicationDate
                   , application.ApplicationTypeID
                   , application.ApplicationStatus, application.LastStatusDate, application.PaidFees
                   , application.CreatedByUserID, LicenseClassID);
            }
               
            else return null;
        }


        public static bool isLDLApplicationExist(int LocalDrivingLicenseApplicationID)
        {
            return (clsLDLAppData.isLDLApplicationExist(LocalDrivingLicenseApplicationID));
        }

        private bool _AddNewLocalDrivingLicenseApp()
        {
                this.LocalDrivingLicenseApplicationID = clsLDLAppData.AddNewLDLApplication(ApplicationID, LicenseClassID);
                return LocalDrivingLicenseApplicationID != -1;
        }

        private bool _UpdateLocalDrivingLicenseApp()
        {

            return clsLDLAppData.UpdateLDLApplication(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);
         
        }

        public new bool Save()
        {
            if(!base.Save())
              { return false; }


            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApp())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return true;
                case enMode.Update:
                    return _UpdateLocalDrivingLicenseApp();
            }

            return false;
        }
       

        public static bool DeleteLDLApp(int ID)
        {
            return clsLDLAppData.DeleteLDLApplication(ID);
        }

        public static int CheckIfValidForSubmission(string NationalNo , string ClassName)
        {
            return clsLDLAppData.CheckIfValidForSubmission(NationalNo, ClassName);
        }

    }
}
