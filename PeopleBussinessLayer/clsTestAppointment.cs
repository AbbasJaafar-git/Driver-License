
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleDataAccessLayer;

namespace PeopleBussinessLayer
{
    public class clsTestAppointment
    {
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public double PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }

        public int RetakeTestApplicationID { get; set; }
        public clsApplication RetakeTestApplication { get; set; }

        public enum enMode { AddNew, Update };
        public enMode Mode = enMode.AddNew;

        public enum enTestTypeTitle { VisionTest = 1, WrittenTest = 2, PracticalStreetTest = 3 }
        public enTestTypeTitle TypeOfTest =enTestTypeTitle.VisionTest;

        public clsTestAppointment()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.MinValue;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
            this.RetakeTestApplicationID = -1;

            Mode = enMode.AddNew;
        }

        private clsTestAppointment(int TestAppointmentID, int TestTypeID
            , int LocalDrivingLicenseApplicationID, DateTime AppointmentDate
            , double PaidFees, int CreatedByUserID, bool IsLocked,int RetakeTestApplicationID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID= RetakeTestApplicationID;
            this.RetakeTestApplication=clsApplication.FindApplication(RetakeTestApplicationID);
            Mode = enMode.Update;
        }

        public static DataTable GetAppointments()
        {
            return clsTestAppointmentData.GetAllAppointments();
        }
        public static DataTable GetAppointments(int LDLAppID,int TestTypeID)
        {
            return clsTestAppointmentData.GetAllAppointments(LDLAppID, TestTypeID);
        }


        public static clsTestAppointment FindTestAppointment(int TestAppointmentID)
        {
            int TestTypeID = 0, LocalDrivingLicenseApplicationID = 0
                , CreatedByUserID = 0,RetakeTestApplicationID = -1;
            double PaidFees = 0;
            bool IsLocked = false;
            DateTime AppointmentDate = DateTime.Now;
            if (clsTestAppointmentData.GetTestAppointment(TestAppointmentID, ref TestTypeID
                , ref LocalDrivingLicenseApplicationID, ref AppointmentDate
           , ref PaidFees, ref CreatedByUserID, ref IsLocked,ref RetakeTestApplicationID
            ))
                return new clsTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID
                   , AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            else return null;
        }

        public static bool isTestAppointmentExist(int TestAppointmentID)
        {
            return (clsTestAppointmentData.isTestAppointmentExist(TestAppointmentID));
        }

        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointmentData.AddNewTestAppointment(TestTypeID
                , LocalDrivingLicenseApplicationID, AppointmentDate
                , PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            return TestAppointmentID != -1;
        }

        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentData.UpdateTestAppointment(TestAppointmentID, TestTypeID
                , LocalDrivingLicenseApplicationID, AppointmentDate
                , PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
        }

        public bool LockTestAppointment()
        {
            return clsTestAppointmentData.UpdateStatus(TestAppointmentID, true);
        }


        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestAppointment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return true;
                case enMode.Update:
                    return _UpdateTestAppointment();
            }

            return false;

        }

        public static bool Delete(int TestAppointment)
        {
            return clsTestAppointmentData.DeleteTestAppointment(TestAppointment);
        }
    }
}

