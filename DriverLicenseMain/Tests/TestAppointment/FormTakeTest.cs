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
using static DriverLicense.Tests.TestAppointment.FormAddNewAppointment;

namespace DriverLicense.Tests.TestAppointment
{
    public partial class FormTakeTest : Form
    {

        public delegate void RefreshAppointments();
        public event RefreshAppointments OnRefreshAppointments;


        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;

        clsLDLApplications LDLApp = new clsLDLApplications();
        clsTestAppointment appointment = new clsTestAppointment();
        clsTest _Test = new clsTest();

        string TestType = "";
        short Records = 0, TestTypeID = 0;
        public FormTakeTest(clsLDLApplications LDLApp, string Type, short Records, int AppointmentID = -1)
        {
            InitializeComponent();
            this.LDLApp = LDLApp;
            this.TestType = Type;
            this.Records = Records;
            this.appointment = clsTestAppointment.FindTestAppointment(AppointmentID);
            
        }

        private void _RefreshFromInfo()
        {
            _ChangeTestTypeMode();

            lblLDLID.Text = LDLApp.LocalDrivingLicenseApplicationID.ToString();
            lblDClass.Text = clsLicenseClass.Find(LDLApp.LicenseClassID).ClassName;
            lblApplicantName.Text = LDLApp.PersonInfo.FullName;
            lblTrial.Text = Records.ToString();
            lblDate.Text = DateTime.Now.ToShortDateString() ;    
            lblFees.Text = appointment.PaidFees.ToString();
            lblTestID.Text = "Not Taken Yet";
            lblUserMessage.Visible = false;

            //_Test = clsTest.FindTestByAppointment(appointment.TestAppointmentID);
            if(appointment.IsLocked)
            {
                _Mode = enMode.Update;
                _Test = clsTest.FindTestByAppointment(appointment.TestAppointmentID);

                lblTestID.Text= _Test.TestID.ToString();
                rbFail.Enabled = false;
                rbPass.Enabled = false;
                if(_Test.TestResult)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;
                lblUserMessage.Visible = true;
                txtNotes.Text = _Test.Notes;
            }



        }
        private void FormTakeTest_Load(object sender, EventArgs e)
        {
            _RefreshFromInfo();
        }

        private void _ChangeTestTypeMode()
        {
            switch (this.TestType)
            {
                case "Vision":
                    lblTestMode.Text = "Vision";
                    TestTypeID = 1;
                    pbTestMode.Image = Properties.Resources.Vision_512;
                    gbTest.Text = "Vision Test";
                    break;
                case "Writting":
                    lblTestMode.Text = "Writting";
                    TestTypeID = 2;
                    pbTestMode.Image = Properties.Resources.Written_Test_512;
                    gbTest.Text = "Writting Test";


                    break;
                case "Street":
                    lblTestMode.Text = "Street";
                    TestTypeID = 3;
                    pbTestMode.Image = Properties.Resources.driving_test_512;
                    gbTest.Text = "Street Test";

                    break;

            }

            lblTestMode.Text = lblTestMode.Text + " Test Appointment";
        }

        private void _FillTestInfo()
        {
            if (_Mode==enMode.AddNew)
            {
                _Test.TestAppointmentID = appointment.TestAppointmentID;
                if (rbFail.Checked)
                    _Test.TestResult = false;
                else
                    _Test.TestResult = true;

                appointment.IsLocked = true;
            }
            _Test.Notes = txtNotes.Text;
            _Test.CreatedByUserID = Global.User.UserID;

        }
        private void _SaveTest()
        {

            _FillTestInfo();
            if (appointment.Save())
            {
                if (_Test.Save())
                {
                    MessageBox.Show("Test Saved Successfully "
                     , "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mode = enMode.Update;
                }
                else
                    MessageBox.Show("Test Saving  Failed!! "
                 , "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("Test Saving  Failed!! "
             , "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);

            OnRefreshAppointments?.Invoke();

            this.Close();

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _SaveTest();
        }

        private void gbTest_Enter(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnRefreshAppointments?.Invoke();
            this.Close();
        }
    }
}

    