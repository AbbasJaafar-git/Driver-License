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
    public partial class FormRenewLicense : Form
    {
        clsApplication _NewApplication = new clsApplication();

        clsLicense _OldLicense;
        clsLicense _RenewLicense= new clsLicense();

        int _LicenseID = -1;

        public FormRenewLicense()
        {
            InitializeComponent();
        }

        private void lblApplicationID_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void LLHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLicenseHistory frm=new FormLicenseHistory(_OldLicense.PersonInfo.PersonID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void llShowLicenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLicenseInfo frm= new FormLicenseInfo(_RenewLicense.PersonInfo.PersonID, _RenewLicense.LicenseClass);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void _FillApplicationInfo()
        {
            _NewApplication.ApplicantPersonID = _OldLicense.PersonInfo.PersonID;
            _NewApplication.ApplicationDate = DateTime.Now;
            _NewApplication.ApplicationTypeID =
                clsApplicationsTypes.FindApplicationType("Renew Driving License Service").ID;
            _NewApplication.Status = clsApplication.enApplicationStatus.Completed;
            _NewApplication.ApplicationStatus = (int)_NewApplication.Status;
            _NewApplication.LastStatusDate = DateTime.Now;
            _NewApplication.PaidFees = Convert.ToDouble(lblAppFees.Text);
            _NewApplication.CreatedByUserID = Global.User.UserID;
        }

        private void _FillRenewLicenseInfo()
        {
            _RenewLicense.ApplicationID=_NewApplication.ApplicationID;
            _RenewLicense.DriverID = _OldLicense.DriverID;
            _RenewLicense.LicenseClass= _OldLicense.LicenseClass;
            _RenewLicense.IssueDate = DateTime.Now;
            _RenewLicense.ExpirationDate = Convert.ToDateTime(lblExpDate.Text);
            _RenewLicense.Notes= txtNotes.Text;
            _RenewLicense.PaidFees=Convert.ToDouble(lblLicenseFees.Text);
            _RenewLicense.IsActive= true;
            _RenewLicense.IssueReason = 2;
            _RenewLicense.CreatedByUserID= Global.User.UserID;

        }

        private void _FillFormInfo()
        {

            lblRAppID.Text = _RenewLicense.ApplicationID.ToString();
            lblAppDate.Text = _NewApplication.ApplicationDate.ToShortDateString();
            lblIssueDate.Text = _RenewLicense.IssueDate.ToShortDateString();
            lblAppFees.Text = _NewApplication.PaidFees.ToString();
            lblRenewLicenseID.Text = _RenewLicense.ToString();
            lblOldLicenseID.Text = _OldLicense.LicenseID.ToString();
            lblExpDate.Text = _RenewLicense.ExpirationDate.ToShortDateString();
            lblCreatedByUser.Text = Global.User.UserName;

            LLHistory.Enabled = true;
            llShowLicenceInfo.Enabled = true;
        }

        private void _ResetRenewFrom()
        {
            lblRAppID.Text = "[????]";
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblAppFees.Text = 
                clsApplicationsTypes.FindApplicationType("Renew Driving License Service").Fees.ToString();
            lblLicenseFees.Text = "[????]";
            txtNotes.Text = string.Empty;
            lblRenewLicenseID.Text = "[????]";
            lblOldLicenseID.Text = "[????]";

            lblExpDate.Text = DateTime.Now.AddYears(10).ToShortDateString();
            lblCreatedByUser.Text = Global.User.UserName;
            lblTotalFees.Text = "[????]";

            LLHistory.Enabled = false;
            llShowLicenceInfo.Enabled = false;
            btnRenew.Enabled = false;
        }
        private void FormRenewLicense_Load(object sender, EventArgs e)
        {
            _ResetRenewFrom();
        }

        private void ctrlLicenseWithFilter1_OnSelectedLicense(int obj)
        {
           _LicenseID = obj;
           _OldLicense = clsLicense.FindLicense(_LicenseID);


            if (_OldLicense.ExpirationDate > DateTime.Now)
            {
                MessageBox.Show($"  Selected License is Not Yet" +
                    $" Expired,It Will be expired on {_OldLicense.ExpirationDate.ToShortDateString()} ! ", "Error"
                   , MessageBoxButtons.OK
                     , MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                LLHistory.Enabled = true;

                return;
            }
            else
            {
                clsLicense Lic = clsLicense.FindActiveLicenseByPersonID(_OldLicense.PersonInfo.PersonID
                     , _OldLicense.LicenseClass);
                if (Lic!=null)
                {
                    MessageBox.Show($"  Selected License is Expired " +
                  $" ,However License holder have another active License with ID=  {Lic.LicenseID} ! ", "Error"
                 , MessageBoxButtons.OK
                   , MessageBoxIcon.Error);
                    btnRenew.Enabled = false;
                    LLHistory.Enabled = true;

                    return;
                }
            }

           btnRenew.Enabled = true;
           lblOldLicenseID.Text= _OldLicense.LicenseID.ToString();
           lblLicenseFees.Text=_OldLicense.PaidFees.ToString();
            
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
        private void btnRenew_Click(object sender, EventArgs e)
        {
            if(_LicenseID <0)
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


            _FillRenewLicenseInfo();

            if (_RenewLicense.Save())
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
    }
}
