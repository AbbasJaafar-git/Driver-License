
using PeopleDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PeopleBussinessLayer
{
    public class clsApplication
    {
        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public int ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public double PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsPeople PersonInfo {  get; set; }
        public clsUsers UserInfo { get; set; }
        public enum enMode { AddNew, Update };
        public enMode Mode = enMode.AddNew;

        public enum enApplicationStatus { New=1, Canceled = 2,Completed=3 }
        public enApplicationStatus Status = enApplicationStatus.New;

        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.MinValue;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = 0;
            this.LastStatusDate = DateTime.MinValue;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate
            , int ApplicationTypeID, int ApplicationStatus
            , DateTime LastStatusDate, double PaidFees, int CreatedByUserID)
        {
            this.ApplicationID =ApplicationID ;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.PersonInfo = clsPeople.FindPerson(ApplicantPersonID);
            this.UserInfo = clsUsers.FindUser(CreatedByUserID);
            if(this.ApplicationStatus == 2)
                 this.Status = enApplicationStatus.Canceled;
            else if(this.ApplicationStatus == 3)
                this.Status = enApplicationStatus.Completed;
            else 
                this.Status = enApplicationStatus.New;
            Mode = enMode.Update;
        }

        public static DataTable GetApplications()
        {
            return clsApplicationData.GetAllApplications();
        }

        public static clsApplication FindApplication(int applicationID)
        {
            int ApplicantPersonID = 0, ApplicationTypeID = 0, ApplicationStatus = 0, CreatedByUserID = 0;
            double PaidFees =0;
            DateTime ApplicationDate = DateTime.Now, LastStatusDate=DateTime.Now;
            if (clsApplicationData.GetApplication(applicationID, ref ApplicantPersonID, ref ApplicationDate
                , ref ApplicationTypeID, ref ApplicationStatus
           , ref LastStatusDate, ref PaidFees, ref CreatedByUserID

            ))
                return new clsApplication(applicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID
                    , ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            else return null;
        }

        public static bool isApplicationExist(int applicationID)
        {
            return (clsApplicationData.isApplicationExist(applicationID));
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationData.AddNewApplication(ApplicantPersonID, ApplicationDate
                , ApplicationTypeID, ApplicationStatus
                , LastStatusDate, PaidFees, CreatedByUserID);
            return ApplicationID != -1;
        }

        private bool _UpdateApplication()
        {
            return clsApplicationData.UpdateApplication(ApplicationID,ApplicantPersonID, ApplicationDate
                , ApplicationTypeID, ApplicationStatus
                , LastStatusDate, PaidFees, CreatedByUserID);
        }

        public  bool CancelApplication()
        {
            return clsApplicationData.UpdateStatus(ApplicationID, (int)enApplicationStatus.Canceled);
        }

        public bool SetComplete()
        {

            return clsApplicationData.UpdateStatus(ApplicationID, (int)enApplicationStatus.Completed);
        }

        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return true;
                case enMode.Update:
                    return _UpdateApplication();
            }

            return false;

        }

        public static bool Delete(int ApplicationID)
        {
            return clsApplicationData.DeleteApplication(ApplicationID);
        }
    }
}
