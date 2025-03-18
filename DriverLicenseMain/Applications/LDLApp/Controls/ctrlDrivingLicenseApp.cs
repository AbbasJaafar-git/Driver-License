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
using static System.Net.Mime.MediaTypeNames;

namespace DriverLicense.Applications.LDLApp.Controls
{
    public partial class ctrlDrivingLicenseApp : UserControl
    {

        clsLDLApplications LDLApp= new clsLDLApplications();

        private int _LDLAppID=-1;
        public int LDLAppID { get { return _LDLAppID; } }


        public ctrlDrivingLicenseApp()
        {
            InitializeComponent();
        }


        public void ResetLDLApplicationInfo()
        {
            _LDLAppID = -1;

            lblLocalDrivingLicenseApplicationID.Text = "[????]";
            lblAppliedFor.Text = "[????]";
            lblPassedTests.Text = "[????]";
          
        }


        private void _FillLDLApplicationInfo()
        {
            lblLocalDrivingLicenseApplicationID.Text = LDLApp.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedFor.Text = clsLicenseClass.Find(LDLApp.LicenseClassID).ClassName;
            lblPassedTests.Text =clsLDLApplications.GetLDLAppPassedTestsCount(LDLApp.LocalDrivingLicenseApplicationID).ToString();
            if(Convert.ToInt32(lblPassedTests.Text)>=3) { llShowLicenceInfo.Enabled = true; }
            ctrlApplicationBasicInfo1.LoadApplicationInfo(LDLApp.ApplicationID);
            
        
        }
        public void LoadLDLApplicationInfo(int LDLAppID)
        {
            LDLApp = clsLDLApplications.FindLDLApplication(LDLAppID);
            llShowLicenceInfo.Enabled=false;
            if (LDLApp == null)
            {
                ResetLDLApplicationInfo();
                MessageBox.Show("No Local License Driving Application with ApplicationID = " 
                    + LDLAppID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                _FillLDLApplicationInfo();
        }


        private void ctrlApplicationBasicInfo1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void ctrlDrivingLicenseApp_Load(object sender, EventArgs e)
        {

        }
    }
}
