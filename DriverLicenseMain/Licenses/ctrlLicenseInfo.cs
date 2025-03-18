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
    public partial class ctrlLicenseInfo : UserControl
    {
        clsLicense _License= new clsLicense();

        public ctrlLicenseInfo()
        {
            InitializeComponent();
        }   

        private void _FillLicenseInfo()
        {
            lblClass.Text = clsLicenseClass.Find(_License.LicenseClass).ClassName;
            lblName.Text = _License.PersonInfo.FullName;
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblNat.Text = _License.PersonInfo.NationalNumber;

            if (_License.PersonInfo.GendorNumber == 0)
            {
                pbPersonImage.Image = Properties.Resources.user__1_;
                lblGender.Text = "Male";

            }
            else
            {
                pbPersonImage.Image = Properties.Resources.person_girl;
                lblGender.Text = "Female";
            }

            lblIssueDate.Text = (_License.IssueDate).ToShortDateString();
            if (_License.IssueReason == 1)
                lblReason.Text = "First Time";
            else if (_License.IssueReason == 2)
                lblReason.Text = "Renew";
            else if (_License.IssueReason == 3)
                lblReason.Text = "Lost Replaced";
            else if (_License.IssueReason == 4)
                lblReason.Text = "Damaged Replaced";
            lblNotes.Text = _License.Notes;
            lblActive.Text=_License.IsActive ? "Yes":"No";
            lblDOB.Text = _License.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text=_License.DriverID.ToString();
            lblExpDate.Text= _License.ExpirationDate.ToShortDateString();
            if(clsDetainedLicense.isLicenseDetained(_License.LicenseID))
                lblDetained.Text = "Yes";
            else
                lblDetained.Text = "No";



        }

        private void _ResetLicenseInfo()
        {
            lblClass.Text = "[???]";
            lblName.Text = "[???]";
            lblLicenseID.Text= "[???]";
            lblNat.Text = "[???]";
            lblGender.Text= "[???]";
            lblIssueDate.Text="[???]";
            lblReason.Text = "[???]";
            lblNotes.Text = "[???]";
            lblActive.Text = "[???]";
            lblDOB.Text = "[???]";
            lblDriverID.Text = "[???]";
            lblExpDate.Text = "[???]";
            lblDetained.Text = "[???]";


        }

        public bool LoadLicenseInfo(int PersonID,int LicenseClassID)
        {
            _License= clsLicense.FindLicenseByPersonID(PersonID,LicenseClassID);
            if( _License != null )
            {
                _FillLicenseInfo();
                return true;
            }
            else
            {
                _ResetLicenseInfo();
                MessageBox.Show($"No License with PersonID = {PersonID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool LoadLicenseInfo(int LicenseID )
        {
            _License = clsLicense.FindLicense(LicenseID);
            if (_License != null)
            {
                _FillLicenseInfo();
                return true;
            }
            else
            {
                _ResetLicenseInfo();
                MessageBox.Show($"No License with LicenseID = {LicenseID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ctrlLicenseInfo_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
