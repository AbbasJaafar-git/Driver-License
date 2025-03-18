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

namespace DriverLicense.Licenses
{


    public partial class FormReplaceLicense : Form
    {

        clsApplication _NewApplication = new clsApplication();

        clsLicense _OldLicense;
        clsLicense _ReplacedLicense = new clsLicense();

        int _LicenseID = -1;
        string _AppTypeString = "Replacement for a Damaged Driving License";

        public FormReplaceLicense()
        {
            InitializeComponent();
        }

        private void FormReplaceLicense_Load(object sender, EventArgs e)
        {
            _ResetReplacementFrom();
        }


        private void ctrlLicenseWithFilter1_OnSelectedLicense(int obj)
        {
            _LicenseID = obj;
            _OldLicense = clsLicense.FindLicense(_LicenseID);


            if (!_OldLicense.IsActive)
            {
                MessageBox.Show($"  Selected License is Not Active" +
                    $" ,choose an active License ! ", "Error"
                   , MessageBoxButtons.OK
                     , MessageBoxIcon.Error);
                btnReplace.Enabled = false;
                LLHistory.Enabled = true;

                return;
            }
            LLHistory.Enabled = true;

            btnReplace.Enabled = true;
            lblOldLicenseID.Text = _OldLicense.LicenseID.ToString();

        }

        private void _DeactivateOldLicense()
        {
            _OldLicense.IsActive = false;
            if (!_OldLicense.Save())
            {
                MessageBox.Show($"Deactivating Old License Failed ! ", "Error"
                   , MessageBoxButtons.OK
                     , MessageBoxIcon.Error);
                return;
            }
        }

        private void _ResetReplacementFrom()
        {
            lblRAppID.Text = "[????]";
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblAppFees.Text =
                clsApplicationsTypes.FindApplicationType(_AppTypeString).Fees.ToString();
            lblReplaceLicenseID.Text = "[????]";
            lblOldLicenseID.Text = "[????]";

            lblCreatedByUser.Text = Global.User.UserName;

            LLHistory.Enabled = false;
            llShowLicenceInfo.Enabled = false;
            btnReplace.Enabled = false;
        }

        private void LLHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLicenseHistory frm = new FormLicenseHistory(_OldLicense.PersonInfo.PersonID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void llShowLicenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLicenseInfo frm = new FormLicenseInfo(_ReplacedLicense.LicenseID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void _ChangeReplacementMode()
        {
            if(rbDamaged.Checked)
            {
                lblMode.Text = "Replacement for Damaged License";
                _AppTypeString = "Replacement for a Damaged Driving License";
                lblAppFees.Text=
                clsApplicationsTypes.FindApplicationType(_AppTypeString).Fees.ToString();

            }
            else 
            {
                lblMode.Text = "Replacement for Lost License";
                _AppTypeString = "Replacement for a Lost Driving License";
                lblAppFees.Text =
               clsApplicationsTypes.FindApplicationType(_AppTypeString).Fees.ToString();

            }
        }
        private void _FillApplicationInfo()
        {
            _NewApplication.ApplicantPersonID = _OldLicense.PersonInfo.PersonID;
            _NewApplication.ApplicationDate = DateTime.Now;

            _NewApplication.ApplicationTypeID =
                clsApplicationsTypes.FindApplicationType(_AppTypeString).ID;
            _NewApplication.Status = clsApplication.enApplicationStatus.Completed;
            _NewApplication.ApplicationStatus = (int)_NewApplication.Status;
            _NewApplication.LastStatusDate = DateTime.Now;
            _NewApplication.PaidFees = Convert.ToDouble(lblAppFees.Text);
            _NewApplication.CreatedByUserID = Global.User.UserID;
        }

        private void _FillReplacedLicenseInfo()
        {
            _ReplacedLicense.ApplicationID = _NewApplication.ApplicationID;
            _ReplacedLicense.DriverID = _OldLicense.DriverID;
            _ReplacedLicense.LicenseClass = _OldLicense.LicenseClass;
            _ReplacedLicense.IssueDate = DateTime.Now;
            _ReplacedLicense.ExpirationDate = Convert.ToDateTime(_OldLicense.ExpirationDate);
            _ReplacedLicense.Notes = _OldLicense.Notes;
            _ReplacedLicense.PaidFees = Convert.ToDouble(_OldLicense.PaidFees);
            _ReplacedLicense.IsActive = true;
            if(_AppTypeString== "Replacement for a Damaged Driving License")
                _ReplacedLicense.IssueReason = 4;
            else
                _ReplacedLicense.IssueReason = 3;

            _ReplacedLicense.CreatedByUserID = Global.User.UserID;

        }

        private void _FillFormInfo()
        {

            lblRAppID.Text = _ReplacedLicense.ApplicationID.ToString();
            lblAppDate.Text = _NewApplication.ApplicationDate.ToShortDateString();
            lblAppFees.Text = _NewApplication.PaidFees.ToString();
            lblReplaceLicenseID.Text = _ReplacedLicense.LicenseID.ToString();
            lblOldLicenseID.Text = _OldLicense.LicenseID.ToString();
            lblCreatedByUser.Text = Global.User.UserName;

            LLHistory.Enabled = true;
            llShowLicenceInfo.Enabled = true;
            ctrlLicenseWithFilter1.Enabled = false;
            gbReplacement.Enabled = false;
        }
        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            _ChangeReplacementMode();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            _ChangeReplacementMode();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show($"Are you sure you want to replace this License ? ", "Confirm"
                   , MessageBoxButtons.OKCancel
                     , MessageBoxIcon.Information)==DialogResult.Cancel)
                return;


            if (_LicenseID < 0|| ctrlLicenseWithFilter1.LicenseID < 0)
            {
                MessageBox.Show($" Please select a License ! ", "Error"
                   , MessageBoxButtons.OK
                     , MessageBoxIcon.Error);
                return;
            }

            _DeactivateOldLicense();

            _FillApplicationInfo();
            if (!_NewApplication.Save())
            {
                MessageBox.Show($"Application License Saving Failed ! ", "Error", MessageBoxButtons.OK
                       , MessageBoxIcon.Error);
                return;
            }


            _FillReplacedLicenseInfo();

            if (_ReplacedLicense.Save())
            {
                MessageBox.Show($" License Saved Successfully  ", "Save", MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                _FillFormInfo();
            }
            else
            {
                MessageBox.Show($" License Saving Failed ! ", "Error", MessageBoxButtons.OK
                   , MessageBoxIcon.Error);

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
