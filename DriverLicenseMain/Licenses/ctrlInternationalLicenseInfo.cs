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
    public partial class ctrlInternationalLicenseInfo : UserControl
    {
        public ctrlInternationalLicenseInfo()
        {
            InitializeComponent();
        }
        clsInternationalLicense _InternationalLicense = new clsInternationalLicense();

        private void _FillIntLicenseInfo()
        {
            lblName.Text = _InternationalLicense.PersonInfo.FullName;
            lblIntLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            lblLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblNat.Text = _InternationalLicense.PersonInfo.NationalNumber;

            if (_InternationalLicense.PersonInfo.GendorNumber == 0)
            {
                pbPersonImage.Image = Properties.Resources.user__1_;
                lblGender.Text = "Male";

            }
            else
            {
                pbPersonImage.Image = Properties.Resources.person_girl;
                lblGender.Text = "Female";
            }

            lblIssueDate.Text = (_InternationalLicense.IssueDate).ToShortDateString();
            lblActive.Text = _InternationalLicense.IsActive ? "Yes" : "No";
            lblDOB.Text = _InternationalLicense.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _InternationalLicense.DriverID.ToString();
            lblExpDate.Text = _InternationalLicense.ExpirationDate.ToShortDateString();


        }

        private void _ResetIntLicenseInfo()
        {
            lblName.Text = "[???]";
            lblIntLicenseID.Text = "[???]";
            lblLicenseID.Text = "[????]";
            lblNat.Text = "[???]";
            lblGender.Text = "[???]";
            lblIssueDate.Text = "[???]";
            lblActive.Text = "[???]";
            lblDOB.Text = "[???]";
            lblDriverID.Text = "[???]";
            lblExpDate.Text = "[???]";


        }

        public bool LoadIntLicenseInfo(int PersonID)
        {
            _InternationalLicense = clsInternationalLicense.FindLicenseByPersonID(PersonID);
            if (_InternationalLicense != null)
            {
                _FillIntLicenseInfo();
                return true;
            }
            else
            {
                _ResetIntLicenseInfo();
                MessageBox.Show($"No International License with PersonID = {PersonID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool LoadLicenseInfoByInt(int IntLicenseID)
        {
            _InternationalLicense = clsInternationalLicense.FindLicense(IntLicenseID);
            if (_InternationalLicense != null)
            {
                _FillIntLicenseInfo();
                return true;
            }
            else
            {
                _ResetIntLicenseInfo();
                MessageBox.Show($"No international License with LicenseID = {_InternationalLicense}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblExpDate_Click(object sender, EventArgs e)
        {

        }
    }
}
