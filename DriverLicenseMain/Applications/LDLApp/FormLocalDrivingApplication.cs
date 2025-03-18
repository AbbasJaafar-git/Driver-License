using DriverLicense.Applications.LDLApp;
using DriverLicense.Licenses;
using DriverLicense.Tests.TestAppointment;
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

namespace DriverLicense.Applications
{
    public partial class FormLocalDrivingApplication : Form
    {
        private clsLDLApplications CurrentLDLApp= new clsLDLApplications();

        public enum enTestType { VisionTest=1,WrittenTest=2,StreetTest=3};

        enTestType TestType = enTestType.VisionTest;

        int _CurrentLDLAppID = -1;
        int PassedTests = 0;
        string Status = "";
        public FormLocalDrivingApplication()
        {
            InitializeComponent();
        }

        private void lblRecords_Click(object sender, EventArgs e)
        {

        }

        private void _RefreshApplications()
        {
            dgvLocalApplications.DataSource = clsLDLApplications.GetAllLDApplications();
            dgvLocalApplications.Columns[0].Name = "L.D.LAppID";
            dgvLocalApplications.Columns[0].Width = 80;
            dgvLocalApplications.Columns[1].Width = 180;
            dgvLocalApplications.Columns[3].Width = 210;
            dgvLocalApplications.Columns[4].Width = 180;
            dgvLocalApplications.Columns[5].Width = 60;
            lblRecords.Text = dgvLocalApplications.RowCount.ToString();
            tSMIssueLicense.Enabled = false;
            tSMSchedule.Enabled = true;
            tSMShowLicense.Enabled = false;
            scheduleVisionTestToolStripMenuItem.Enabled = true;
            scheduleWrittingTestToolStripMenuItem.Enabled = false;
            scheduleStreetTestToolStripMenuItem.Enabled = false;

        }
        private void FormLocalDrivingApplication_Load(object sender, EventArgs e)
        {

            _RefreshApplications();
            _RefreshTestAppointments();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                dgvLocalApplications.Sort(dgvLocalApplications.Columns[0], ListSortDirection.Ascending);
            }
            if (comboBox1.SelectedIndex == 2)
                dgvLocalApplications.Sort(dgvLocalApplications.Columns[3], ListSortDirection.Ascending);
        }

        private void btnAddApp_Click(object sender, EventArgs e)
        {
            FormNewL frm = new FormNewL();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.onRefreshLDLApp += _RefreshApplications;

            frm.ShowDialog();
        }

        private void tSMAppDetails_Click(object sender, EventArgs e)
        {
            FormShowLDLAppInfo frm = new FormShowLDLAppInfo((int)dgvLocalApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void tSMEditApp_Click(object sender, EventArgs e)
        {
            FormNewL frm = new FormNewL((int)dgvLocalApplications.CurrentRow.Cells[0].Value);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.onRefreshLDLApp += _RefreshApplications;
            frm.ShowDialog();
        }

        private void tSMDelete_Click(object sender, EventArgs e)
        {

            
            if (MessageBox.Show("Are you sure you want to Delete Application ?"
               , "Cancel", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                return;

            int LDLAppID =(int) dgvLocalApplications.CurrentRow.Cells[0].Value;
            int ApplicatoinID = clsLDLApplications.FindLDLApplication(LDLAppID).ApplicationID;
            if (clsLDLApplications.DeleteLDLApp(LDLAppID))
                if (clsApplication.Delete(ApplicatoinID))
                {
                    MessageBox.Show("Local Driving Application Canceled Successfully"
                 , "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshApplications();
                }
                else
                {
                    MessageBox.Show("Local Driving Application Cancelling Failed!"
                    , "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshApplications();

                }



        }

        private void tSMCancel_Click(object sender, EventArgs e)
        {
            clsLDLApplications lDLApplications =
                clsLDLApplications.FindLDLApplication((int)dgvLocalApplications.CurrentRow.Cells[0].Value);
            if (lDLApplications.ApplicationStatus == (int)clsLDLApplications.enApplicationStatus.Completed) { 
                MessageBox.Show("Local Driving Application is Completed,You Can't Cancel it!"
                , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to Cancel Application ?"
                , "Cancel", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                return;

            if (lDLApplications.CancelApplication())
            {
                MessageBox.Show("Local Driving Application Canceled Successfully"
                 , "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshApplications();
            }
            else
            {
                MessageBox.Show("Local Driving Application Cancelling Failed!"
                , "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshApplications();

            }
        }

        private void tSMSchedule_Click(object sender, EventArgs e)
        {

        }

        private void tSMIssueLicense_Click(object sender, EventArgs e)
        {
            FormIssueDriverLicenseFirstTime frm= new FormIssueDriverLicenseFirstTime(_CurrentLDLAppID
                );
            frm.OnRefreshLDLApps += _RefreshApplications;

            frm.ShowDialog();
        }

        private void tSMShowLicense_Click(object sender, EventArgs e)
        {
            FormLicenseInfo frm = new FormLicenseInfo(CurrentLDLApp.ApplicantPersonID,CurrentLDLApp.LicenseClassID);

            frm.ShowDialog();

        }

        private void tSMShowHistory_Click(object sender, EventArgs e)
        {
            FormLicenseHistory frm = new FormLicenseHistory(CurrentLDLApp.ApplicantPersonID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void dgvLocalApplications_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void _EditCancelDelete()
        {
            if (Status != "New")
            {
                tSMEditApp.Enabled = false;
                tSMDelete.Enabled = false;
                tSMCancel.Enabled = false;

                return;
            }
            else
            {
                tSMEditApp.Enabled = true;
                tSMDelete.Enabled = true;
                tSMCancel.Enabled = true;
            }


        }

        private void _RefreshTestAppointments()
        {
            
           

            if (Status != "New")
            {
                tSMSchedule.Enabled = false;

                return;
            }

            tSMSchedule.Enabled= true;
            if (PassedTests==0)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = true;
                scheduleWrittingTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = false;

            }
            else if (PassedTests == 1)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = false;
                scheduleWrittingTestToolStripMenuItem.Enabled = true;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
            }
            else if(PassedTests==2) {
                scheduleVisionTestToolStripMenuItem.Enabled = false;
                scheduleWrittingTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = true;
            }
            else
            {
                tSMSchedule.Enabled = false;
            }

        }

        private void _RefreshIssueLicense()
        {
            
            if (PassedTests>=3 && Status == "New")
            {
                tSMIssueLicense.Enabled = true;
            }
            else
                tSMIssueLicense.Enabled = false;
        }

        private void _RefreshShowLicense()
        {
            if (Status != "Completed")
                tSMShowLicense.Enabled = false;
            else tSMShowLicense.Enabled = true;
        }

        private void _RefreshSelectedLDLAppMenu()
        {

            //CurrentLDLApp= 
            //    clsLDLApplications.FindLDLApplication((int)dgvLocalApplications.CurrentRow.Cells[0].Value);
            _EditCancelDelete();
            _RefreshTestAppointments();
            _RefreshIssueLicense();
            _RefreshShowLicense();
            
        }


        private void dgvLocalApplications_SelectionChanged(object sender, EventArgs e)
        {
            //if (dgvLocalApplications.CurrentRow.Index == 0) {
            //    this.BackColor = Color.Blue;

            //}else
            //    this.BackColor = Color.Yellow;
            if (dgvLocalApplications.CurrentRow == null)
                return;

            _CurrentLDLAppID = (int)dgvLocalApplications.CurrentRow.Cells[0].Value;
            CurrentLDLApp = clsLDLApplications.FindLDLApplication(_CurrentLDLAppID);
            PassedTests = (int)dgvLocalApplications.CurrentRow.Cells[5].Value;
            Status = (string)dgvLocalApplications.CurrentRow.Cells[6].Value;


            _RefreshSelectedLDLAppMenu();

        }

        private void _OpenTestAppointmentForm(string AppointmentMode)
        {
            FormTestAppointment frm =
            new FormTestAppointment(_CurrentLDLAppID,AppointmentMode);
            frm.OnRefreshLDLApps += _RefreshApplications;
            frm.StartPosition = FormStartPosition.CenterParent;

            frm.ShowDialog();
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            _OpenTestAppointmentForm("Vision");
        }

        private void scheduleWrittingTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            _OpenTestAppointmentForm("Writting");

        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _OpenTestAppointmentForm("Street");

        }
    }
}
