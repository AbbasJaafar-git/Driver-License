using PeopleBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverLicense.Tests.TestAppointment
{
    public partial class FormAddNewAppointment : Form
    {
        public delegate void RefreshAppointments();
        public event RefreshAppointments OnRefreshAppointments;

        public enum enMode { AddNew=0, Update=1}
        private enMode _Mode = enMode.AddNew;

        clsLDLApplications LDLApp=new clsLDLApplications();
        clsTestAppointment appointment= new clsTestAppointment();
        clsApplication RetakeApp= new clsApplication();

        string TestType = "";
        short Records = 0, TestTypeID = 0;
        int AppointmentID = -1;
        public FormAddNewAppointment(clsLDLApplications LDLApp,string Type,short Records,int AppointmentID=-1)
        {
            InitializeComponent();
            this.LDLApp=LDLApp;
            this.TestType = Type;
            this.Records = Records;
            if (AppointmentID > 0)
            {
                this.AppointmentID = AppointmentID;
                _Mode = enMode.Update;
            }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void _ChangeTestTypeMode()
        {
            switch (this.TestType)
            {
                case "Vision":
                   // lblTestMode.Text = "Vision";
                    TestTypeID = 1;
                    pbTestMode.Image = Properties.Resources.Vision_512;
                    gbTest.Text = "Vision Test";
                    break;
                case "Writting":
                   // lblTestMode.Text = "Writting";
                    TestTypeID = 2;
                    pbTestMode.Image = Properties.Resources.Written_Test_512;
                    gbTest.Text = "Writting Test";


                    break;
                case "Street":
                    //lblTestMode.Text = "Street";
                    TestTypeID = 3;
                    pbTestMode.Image = Properties.Resources.driving_test_512;
                    gbTest.Text = "Street Test";

                    break;

            }

            //lblTestMode.Text = lblTestMode.Text + " Test Appointments";
        }
        private void _FillAppointmentInfo()
        {
            appointment.TestTypeID= TestTypeID;
            appointment.LocalDrivingLicenseApplicationID = LDLApp.LocalDrivingLicenseApplicationID;
            appointment.AppointmentDate = dateTimePicker1.Value;
            appointment.PaidFees = clsListTestTypes.FindTestType(TestTypeID).Fees;
            appointment.CreatedByUserID= Global.User.UserID;
            appointment.IsLocked = false;
            if(RetakeApp.ApplicationID>0)
                appointment.RetakeTestApplicationID=RetakeApp.ApplicationID;
        }

        private void _MakeRetakeApplication() {
            RetakeApp.ApplicantPersonID = LDLApp.ApplicantPersonID;
            RetakeApp.ApplicationDate = DateTime.Now;
            RetakeApp.ApplicationTypeID = clsApplicationsTypes.FindApplicationType("Retake Test").ID;
            RetakeApp.ApplicationStatus = (int)clsApplication.enApplicationStatus.New;
            RetakeApp.LastStatusDate= DateTime.Now;
            RetakeApp.PaidFees = clsApplicationsTypes.FindApplicationType("Retake Test").Fees;
            RetakeApp.CreatedByUserID= Global.User.UserID;

        }

        private void _FillFormInfo()
        {

            if (appointment.IsLocked)
            {
                lblUserMessage.Visible = true;

                gbTest.Enabled = false;
                gbRetakeTest.Enabled = false;
            }
            else
            {
               
               dateTimePicker1.Value = appointment.AppointmentDate;
                if (Records > 0 && appointment.RetakeTestApplication!=null)
                {
                    lblTestMode.Text = "Schedule Retake Test";
                    gbRetakeTest.Enabled = true;
                    lblRetakeFees.Text = appointment.RetakeTestApplication.PaidFees.ToString();
                    lblTotalFees.Text = Convert.ToString(Convert.ToDouble(lblFees.Text) + appointment.RetakeTestApplication.PaidFees);
                    lblRetakeTestAppID.Text = appointment.RetakeTestApplication.ApplicationID.ToString();
                }
            }

        }
        private void _RefreshFromInfo()
        {
            _ChangeTestTypeMode();
            lblTestMode.Text= "Schedule Test";
            lblUserMessage.Visible = false;

            lblLDLID.Text = LDLApp.LocalDrivingLicenseApplicationID.ToString();
            lblDClass.Text = clsLicenseClass.Find(LDLApp.LicenseClassID).ClassName;
            lblApplicantName.Text = LDLApp.PersonInfo.FullName;
            lblTrial.Text= Records.ToString();
            lblFees.Text= clsListTestTypes.FindTestType(TestTypeID).Fees.ToString();
            gbRetakeTest.Enabled = false;
            lblRetakeFees.Text = "0";
            lblTotalFees.Text = Convert.ToString(LDLApp.PaidFees);


            if (_Mode == enMode.Update)
            {
                this.appointment = clsTestAppointment.FindTestAppointment(AppointmentID);

                _FillFormInfo();
            }
            else
            {
                dateTimePicker1.Value = DateTime.Now;
                if (Records > 0)
                {
                    lblTestMode.Text = "Schedule Retake Test";

                    _MakeRetakeApplication();
                    gbRetakeTest.Enabled = true;
                    lblRetakeFees.Text = RetakeApp.PaidFees.ToString();

                    lblTotalFees.Text = Convert.ToString(Convert.ToDouble(lblFees.Text) + RetakeApp.PaidFees);
                    lblRetakeTestAppID.Text = "N/A";

                }

            }



        }
        private void FormAddNewAppointment_Load(object sender, EventArgs e)
        {
            _RefreshFromInfo();
        }

        private void _SaveAppointment()
        {
            if (_Mode == enMode.AddNew)
                RetakeApp.Save();
            else
            {
                if(appointment.RetakeTestApplication!=null)
                     appointment.RetakeTestApplication.Save();
            }

            _FillAppointmentInfo();
            if (appointment.Save())
            {
                MessageBox.Show("Appointment Saved Successfully "
                 , "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mode = enMode.Update;
                _FillFormInfo();
            }else
                MessageBox.Show("Appointment Saving  Failed!! "
                 , "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);



        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _SaveAppointment();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnRefreshAppointments?.Invoke();
            this.Close();
        }
    }
}
