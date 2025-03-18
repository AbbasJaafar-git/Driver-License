using DriverLicense.Licenses;
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

namespace DriverLicense.DetainedLicenses
{
    public partial class FormReleaseLicense : Form
    {
        public delegate void RefreshListDetained();

        public event RefreshListDetained OnRefreshListDetained;

        clsApplication _NewApplication = new clsApplication();
        string _AppTypeString = "Release Detained Driving Licsense";

        clsDetainedLicense _DetainedLicense = new clsDetainedLicense();
        int _LicenseID = -1;
        public FormReleaseLicense()
        {
            InitializeComponent();
        }

        private void FormReleaseLicense_Load(object sender, EventArgs e)
        {
            _ResetFrom();
        }

        private void _ResetFrom()
        {
            lbDetainID.Text = "[????]";
            lbDetainDate.Text = DateTime.Now.ToShortDateString();
            lblFineFees.Text = "50";
            lblLicenseID.Text = "[????]";
            lblCreatedByUser.Text = Global.User.UserName;

            LLHistory.Enabled = false;
            llShowLicenceInfo.Enabled = false;
            btnRelease.Enabled = false;
        }

        private void ctrlLicenseWithFilter1_OnSelectedLicense(int obj)
        {
            _LicenseID = obj;

            if (!clsDetainedLicense.isLicenseDetained(_LicenseID))
            {
                MessageBox.Show($" Selected License is Not Detained" +
                    $" ,choose another License ! ", "Error"
                   , MessageBoxButtons.OK
                     , MessageBoxIcon.Error);
                btnRelease.Enabled = false;
                LLHistory.Enabled = true;

                return;
            }

            _DetainedLicense = clsDetainedLicense.FindDetainedLicenseByLicenseID(_LicenseID);
            _FillDetainInfo();
            LLHistory.Enabled = true;

            btnRelease.Enabled = true;

        }

        private void LLHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLicenseHistory frm =
                new FormLicenseHistory(clsLicense.FindLicense(_LicenseID).PersonInfo.PersonID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void llShowLicenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLicenseInfo frm = new FormLicenseInfo(_LicenseID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void _FillApplicationInfo()
        {
            _NewApplication.ApplicantPersonID = clsLicense.FindLicense(_LicenseID).PersonInfo.PersonID;
            _NewApplication.ApplicationDate = DateTime.Now;

            _NewApplication.ApplicationTypeID =
                clsApplicationsTypes.FindApplicationType(_AppTypeString).ID;
            _NewApplication.Status = clsApplication.enApplicationStatus.Completed;
            _NewApplication.ApplicationStatus = (int)_NewApplication.Status;
            _NewApplication.LastStatusDate = DateTime.Now;
            _NewApplication.PaidFees = Convert.ToDouble(lblAppFees.Text);
            _NewApplication.CreatedByUserID = Global.User.UserID;
        }

        private void _FillReleaseLicenseInfo()
        {
            //_DetainedLicense.LicenseID = _LicenseID;
            //_DetainedLicense.DetainDate = DateTime.Now;
            //_DetainedLicense.FineFees = 50;
            //_DetainedLicense.CreatedByUserID = Global.User.UserID;
            //_DetainedLicense.IsReleased = false;
            _DetainedLicense.IsReleased = true;
            _DetainedLicense.ReleaseDate = DateTime.Now;
            _DetainedLicense.ReleasedByUserID = Global.User.UserID;
            _DetainedLicense.ReleaseApplicationID= _NewApplication.ApplicationID;


        }


        private void _FillDetainInfo()
        {
            lbDetainID.Text = _DetainedLicense.DetainID.ToString();
            lbDetainDate.Text = _DetainedLicense.DetainDate.ToShortDateString();
            lblFineFees.Text = _DetainedLicense.FineFees.ToString();
            lblLicenseID.Text = _LicenseID.ToString();
            lblCreatedByUser.Text = Global.User.UserName;
            lblAppFees.Text = Convert.ToString(clsApplicationsTypes.FindApplicationType
                (_AppTypeString).Fees);
            lblTotalFees.Text = (Convert.ToDouble(lblFineFees.Text)
                + Convert.ToDouble(lblAppFees.Text)).ToString();


        }
        private void _FillFormInfo()
        {

           _FillDetainInfo();
            lblAppID.Text=_NewApplication.ApplicationID.ToString();

            LLHistory.Enabled = true;
            llShowLicenceInfo.Enabled = true;
            ctrlLicenseWithFilter1.Enabled = false;
            btnRelease.Enabled = false;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show($"Are you sure you want to Release this License ? ", "Confirm"
                   , MessageBoxButtons.OKCancel
                     , MessageBoxIcon.Information) == DialogResult.Cancel)
                return;


            if (_LicenseID < 0 || ctrlLicenseWithFilter1.LicenseID < 0)
            {
                MessageBox.Show($" Please select a License ! ", "Error"
                   , MessageBoxButtons.OK
                     , MessageBoxIcon.Error);
                return;
            }


            _FillApplicationInfo();
            if (!_NewApplication.Save())
            {
                MessageBox.Show($"Application License Saving Failed ! ", "Error", MessageBoxButtons.OK
                       , MessageBoxIcon.Error);
                return;
            }


            _FillReleaseLicenseInfo();

            if (_DetainedLicense.Save())
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
            OnRefreshListDetained?.Invoke();
            this.Close();
        }
    }
}
