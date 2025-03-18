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

namespace DriverLicense.Applications.LDLApp
{
    public partial class FormIssueDriverLicenseFirstTime : Form
    {
        public delegate void RefreshLDLApplications();
        public event RefreshLDLApplications OnRefreshLDLApps;

        int LDLAppID = -1;
        clsLDLApplications _LDLApp = new clsLDLApplications();
        clsLicense _NewLicense=new clsLicense();
        public FormIssueDriverLicenseFirstTime(int LDLAppID)
        {
            InitializeComponent();
            this.LDLAppID = LDLAppID;
            _LDLApp = clsLDLApplications.FindLDLApplication(LDLAppID);

        }




        private void _RefreshIssueForm()
        {
            ctrlDrivingLicenseApp1.LoadLDLApplicationInfo(LDLAppID);
        }
        private void FormIssueDriverLicenseFirstTime_Load(object sender, EventArgs e)
        {
            _RefreshIssueForm();
        }

        private void _FillLicenseInfo()
        {

            _NewLicense.ApplicationID = _LDLApp.ApplicationID;
            if (clsDriver.DoesPersonHaveADriverID(_LDLApp.ApplicantPersonID))
            {
                _NewLicense.DriverID = clsDriver.FindDriverByPersonID(_LDLApp.ApplicantPersonID).DriverID;
            }
            else
            {
                clsDriver NewDriver= new clsDriver();
                NewDriver.PersonID= _LDLApp.ApplicantPersonID;
                NewDriver.CreatedByUserID = Global.User.UserID;
                NewDriver.CreatedDate = DateTime.Now;
                if(!NewDriver.Save() )
                {
                    MessageBox.Show("Driver Saving Failed!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            _NewLicense.LicenseClass = _LDLApp.LicenseClassID;
            _NewLicense.IssueDate = DateTime.Now;
            _NewLicense.ExpirationDate = DateTime.Now.AddYears(
                clsLicenseClass.Find(_LDLApp.LicenseClassID).DefaultValidityLength);
            _NewLicense.Notes = txtNotes.Text;
            _NewLicense.PaidFees=_LDLApp.PaidFees;
            _NewLicense.IsActive = true;
            _NewLicense.IssueReason = 1;
            _NewLicense.CreatedByUserID= Global.User.UserID;

            if(_NewLicense.Save())
            {
                MessageBox.Show("License Saved Succeeded!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LDLApp.Status = clsLDLApplications.enApplicationStatus.Completed;
                _LDLApp.ApplicationStatus = (int)_LDLApp.Status;
                _LDLApp.Save();
            }
            else
                MessageBox.Show("License Saving Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _FillLicenseInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnRefreshLDLApps?.Invoke();
            this.Close();
        }

    }
}
