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
    public partial class FormTestAppointment : Form
    {
        public delegate void RefreshLDLApplications();
        public event RefreshLDLApplications OnRefreshLDLApps;

        clsLDLApplications LDLApp = new clsLDLApplications();
        clsTest _Test = new clsTest();
        int LDLAppID = -1, TestTypeID = -1;
        private int Records = 0;
        string TestType = "";

        public FormTestAppointment(int LDLAppId,string TestType)
        {
            InitializeComponent();
            LDLAppID= LDLAppId;
            this.TestType = TestType;
            

        }


       private void _ChangeTestTypeMode()
        {
            switch (this.TestType)
            {
                case "Vision":
                    lblTestMode.Text = "Vision";
                    pbTestMode.Image = Properties.Resources.Vision_512;
                    TestTypeID = 1;

                    break;
                case "Writting":
                    lblTestMode.Text = "Writting";
                    pbTestMode.Image = Properties.Resources.Written_Test_512;
                    TestTypeID = 2;


                    break;
                case "Street":
                    lblTestMode.Text = "Street";
                    pbTestMode.Image= Properties.Resources.driving_test_512;
                    TestTypeID = 3;

                    break;

            }

            lblTestMode.Text = lblTestMode.Text + " Test Appointments";
        }


        private void _RefreshAppointmentsTable()
        {
            dgvAppointments.DataSource = clsTestAppointment.GetAppointments(LDLAppID, TestTypeID);

            Records = dgvAppointments.Rows.Count;
            lblRecords.Text = Records.ToString();
            if (Records > 0)
            {
                dgvAppointments.Columns[0].Width = 100;
                dgvAppointments.Columns[1].Width = 150;
                dgvAppointments.Columns[2].Width = 150;
                dgvAppointments.Columns[3].Width = 150;

                _Test = clsTest.FindTestByAppointment((int)dgvAppointments.Rows[Records - 1].Cells[0].Value);

            }


        }

        private void _RefreshFormInfo()
        {
            LDLApp = clsLDLApplications.FindLDLApplication(LDLAppID);
            ctrlDrivingLicenseApp1.LoadLDLApplicationInfo(LDLAppID);
            _ChangeTestTypeMode();
            _RefreshAppointmentsTable();
          


                   
        }
        private void FormTestAppointment_Load(object sender, EventArgs e)
        {
            _RefreshFormInfo();
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnRefreshLDLApps?.Invoke();
            this.Close();
        }


        private bool _CheckForOpenAppointment()
        {
            if (Records == 0)
                return false;

            DataTable dt = (dgvAppointments.DataSource as DataTable);
            DataRow dataRow= dt.Rows[dt.Rows.Count - 1];
            if (Convert.ToBoolean(dataRow[3]) == false)
            {
                MessageBox.Show("Person Already Have an active Appointment for this Test" +
                    ",You cannot add new Appointment" +
                    " !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return true;

            }
            else
            {
                if (_Test.TestResult == true)
                {
                    MessageBox.Show("Person Already Passed an Appointment  for this Test" +
                    ",You Can Only Retake Failed  Appointment" +
                    " !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;


                }
            }


            return false;
        }
        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            if (!_CheckForOpenAppointment())
            {
                FormAddNewAppointment frm = new FormAddNewAppointment(LDLApp, TestType, (short)Records);
                frm.OnRefreshAppointments += _RefreshAppointmentsTable;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
             

        }

        private void tSMEditAppointment_Click(object sender, EventArgs e)
        {
            int appointmentid = (int)dgvAppointments.CurrentRow.Cells[0].Value;
            FormAddNewAppointment frm = new FormAddNewAppointment(
                LDLApp, TestType, (short)Records, appointmentid);
            frm.OnRefreshAppointments += _RefreshAppointmentsTable;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void tSMTakeTest_Click(object sender, EventArgs e)
        {
            int appointmentid = (int)dgvAppointments.CurrentRow.Cells[0].Value;
            FormTakeTest frm = new FormTakeTest(
                LDLApp, TestType, (short)Records, appointmentid);
            frm.OnRefreshAppointments += _RefreshAppointmentsTable;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

        }

        private void ctrlDrivingLicenseApp1_Load(object sender, EventArgs e)
        {

        }
    }
}
