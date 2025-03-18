
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
    public class clsTest
    {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }

        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        clsTestAppointment appointment= new clsTestAppointment();


        public enum enMode { AddNew, Update };
        public enMode Mode = enMode.AddNew;

        //public enum enTestTypeTitle { VisionTest = 1, WrittenTest = 2, PracticalStreetTest = 3 }
        //public enTestTypeTitle TypeOfTest = enTestTypeTitle.VisionTest;

        public clsTest()
        {
            this.TestID = -1;

            this.TestAppointmentID = -1;
            this.TestResult = false;

            this.Notes = "";
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsTest( int TestID, int TestAppointmentID, bool TestResult
            , string Notes, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        public static DataTable GetTests()
        {
            return clsTestData.GetAllTests();
        }

        public static clsTest FindTest(int TestID)
        {
            int TestAppointmentID = 0, CreatedByUserID = 0;
            string Notes = "";
            bool TestResult = false;
            if (clsTestData.GetTest(TestID , ref TestAppointmentID
                , ref TestResult, ref Notes
                , ref CreatedByUserID
            ))
                return new clsTest( TestID,TestAppointmentID
                  , TestResult, Notes, CreatedByUserID);
            else return null;
        }

        public static clsTest FindTestByAppointment(int TestAppointmentID)
        {
            int TestID  = 0, CreatedByUserID = 0;
            string Notes = "";
            bool TestResult = false;
            if (clsTestData.GetTestByAppointment(TestAppointmentID, ref TestID 
                , ref TestResult, ref Notes
                , ref CreatedByUserID
            ))
                return new clsTest(TestID, TestAppointmentID
                  , TestResult, Notes, CreatedByUserID);
            else return null;
        }

        public static bool isTestExist(int TestID)
        {
            return (clsTestData.isTestExist(TestID));
        }

        private bool _AddNewTest()
        {
            this.TestID = clsTestData.AddNewTest(TestAppointmentID, TestResult
                , Notes, CreatedByUserID);
            return TestID != -1;
        }

        private bool _UpdateTest()
        {
            return clsTestData.UpdateTest(TestID,TestAppointmentID, TestResult
                , Notes, CreatedByUserID);
        }

        //public bool LockTestAppointment()
        //{
        //    return clsTestData.UpdateStatus(TestAppointmentID, true);
        //}


        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTest())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return true;
                case enMode.Update:
                    return _UpdateTest();
            }

            return false;

        }

        public static bool Delete(int TestID)
        {
            return clsTestData.DeleteTest(TestID);
        }
    }
}

