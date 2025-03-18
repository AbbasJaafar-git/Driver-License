using PeopleBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverLicense.Applications
{
    public partial class FormNewL : Form
    {

        public delegate void RefreshLDLApp();
        public event RefreshLDLApp onRefreshLDLApp;

        clsLDLApplications LDLApplication = new clsLDLApplications();
        private string ApplicationTypeTitle = "New Local Driving License Service";
        public FormNewL()
        {
            InitializeComponent();
        }

        public FormNewL(int LDLID)
        {
            InitializeComponent();
            LDLApplication = clsLDLApplications.FindLDLApplication(LDLID);
        }


        private void _RefreshLDLApplicationInfo()
        {
            if (LDLApplication.LocalDrivingLicenseApplicationID != -1)
            {
                lblAddUpdate.Text = "Update Local Driving License Application";
                cbLicenseClass.SelectedIndex = LDLApplication.LicenseClassID-1 ;
                lblID.Text = LDLApplication.LocalDrivingLicenseApplicationID.ToString();
                ctrlPersonInfoWithFilter1.LoadctrlCardInfo(LDLApplication.ApplicantPersonID);
            }

            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblFees.Text = clsApplicationsTypes.FindApplicationType(ApplicationTypeTitle).Fees.ToString();

            //lblCreatedBy.Text = LDLApplication.CreatedByUserID.ToString();
            lblCreatedBy.Text = Global.User.UserName;

        }
        private void FormNewL_Load(object sender, EventArgs e)
        {
            _RefreshLDLApplicationInfo();
        }
        private void tbLoginInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (_CheckIfEmptyPersonInfo())
            {
                MessageBox.Show("Please Select a Person "
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tabControl1.SelectedIndex = 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            onRefreshLDLApp?.Invoke();
            this.Close();
        }

        private bool _CheckIfEmptyPersonInfo()
        {
            return (ctrlPersonInfoWithFilter1.PersonIDToCheck == -1);
        }

        private bool _CheckIfEmptyApplicationInfo()
        {
            return (cbLicenseClass.Text == string.Empty);
        }

        private bool _CheckIfValidForSubmission()
        {
            int ID = clsLDLApplications.CheckIfValidForSubmission
                (clsPeople.FindPerson(LDLApplication.ApplicantPersonID).NationalNumber, cbLicenseClass.Text);
            if (ID >0)
            {
                MessageBox.Show("Choose another License Class, the Selected Person has already " +
                    "an active Application  for the selected Class with ID = " + ID
                   , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) ;
                return false;
            }
            return true;

        }

        private void _FillLDlApplicationInfo()
        {
            LDLApplication.ApplicationDate = Convert.ToDateTime(lblAppDate.Text);
            LDLApplication.LicenseClassID = cbLicenseClass.SelectedIndex+1;
            LDLApplication.PaidFees = Convert.ToDouble(lblFees.Text);
            LDLApplication.CreatedByUserID=Global.User.UserID;
            LDLApplication.ApplicantPersonID = ctrlPersonInfoWithFilter1.PersonIDToCheck;
            LDLApplication.ApplicationStatus = (int)clsApplication.enApplicationStatus.New;
            LDLApplication.LastStatusDate= DateTime.Now;
            LDLApplication.CreatedByUserID = Global.User.UserID;
            LDLApplication.ApplicationTypeID = clsApplicationsTypes.FindApplicationType(ApplicationTypeTitle).ID;
        }
        private void _SaveApplicationInfo()
        {


            if (_CheckIfEmptyApplicationInfo() || _CheckIfEmptyPersonInfo())
            {
                MessageBox.Show("You Should Fill required information!"
                   , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillLDlApplicationInfo();
            if (!_CheckIfValidForSubmission())
                return;
            _RefreshLDLApplicationInfo();

            if (LDLApplication.Save())
            {
                MessageBox.Show("Local Driving Application Saved Successfully"
                   , "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshLDLApplicationInfo();
            }
            else
            {
                MessageBox.Show("Local Driving Application Saving Failed!"
                   , "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _SaveApplicationInfo();
        }
    }
}
