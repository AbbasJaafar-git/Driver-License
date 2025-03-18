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

namespace DriverLicense.InternationalLicense
{
    public partial class FormNewInternationalLicense : Form
    {

        clsLicense _License= new clsLicense();
        clsApplication _NewApplication= new clsApplication();
        clsInternationalLicense _NewInternationalLicense= new clsInternationalLicense();
        public FormNewInternationalLicense()
        {
            InitializeComponent();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void _FillFormInfo()
        {

            lblApplicationID.Text = _NewInternationalLicense.ApplicationID.ToString() ;
            lblDate.Text = _NewApplication.ApplicationDate.ToShortDateString();
            lblIssueDate.Text = _NewInternationalLicense.IssueDate.ToShortDateString();
            lblFees.Text = clsApplicationsTypes.FindApplicationType("New International License").Fees.ToString();
            ILLicenseID.Text = _NewInternationalLicense.InternationalLicenseID.ToString();
            lblLocalLicenseID.Text = _NewInternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblExpDate.Text =_NewInternationalLicense.ExpirationDate.ToShortDateString();
            lblCreatedByUser.Text = Global.User.UserName;

            LLHistory.Enabled = true;
            llShowLicenceInfo.Enabled = true;
        }

        private void _ResetFormInfo()
        {
            lblApplicationID.Text = "[????]";
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblFees.Text = clsApplicationsTypes.FindApplicationType("New International License").Fees.ToString();
            ILLicenseID.Text = "[????]";
            lblLocalLicenseID.Text = "[????]";
            lblExpDate.Text = DateTime.Now.AddYears(10).ToShortDateString();
            lblCreatedByUser.Text = Global.User.UserName;

            LLHistory.Enabled = false;
            llShowLicenceInfo.Enabled = false;
        }

        private void _LoadFormInfo()
        {
            _ResetFormInfo();


        }

        private void FormNewInternationalLicense_Load(object sender, EventArgs e)
        {
            _LoadFormInfo();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtFind.Text == string.Empty)
            {
                MessageBox.Show($"Please Enter License ID ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (ctrlLicenseInfo1.LoadLicenseInfo(Convert.ToInt32(txtFind.Text))){
                //_FillFormInfo();
                _License = clsLicense.FindLicense(Convert.ToInt32(txtFind.Text));
                LLHistory.Enabled = true;
            }
            else
            {
                _ResetFormInfo();
                //MessageBox.Show($"No License with PersonID = {txtFind.Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }

         
        private void _FillApplicationInfo()
        {
            _NewApplication.ApplicantPersonID = _License.PersonInfo.PersonID;
            _NewApplication.ApplicationDate = DateTime.Now;
            _NewApplication.ApplicationTypeID =
                clsApplicationsTypes.FindApplicationType("New International License").ID;
            _NewApplication.Status = clsApplication.enApplicationStatus.Completed;
            _NewApplication.ApplicationStatus = (int)_NewApplication.Status;
            _NewApplication.LastStatusDate = DateTime.Now;
            _NewApplication.PaidFees = Convert.ToDouble(lblFees.Text);
            _NewApplication.CreatedByUserID = Global.User.UserID;
        }

       private void _FillInternationalLicenseInfo()
        {
            _NewInternationalLicense.ApplicationID = _NewApplication.ApplicationID;
            _NewInternationalLicense.DriverID = _License.DriverID;
            _NewInternationalLicense.IssuedUsingLocalLicenseID = _License.LicenseID;
            _NewInternationalLicense.IssueDate= DateTime.Now;
            _NewInternationalLicense.ExpirationDate=_License.ExpirationDate;
            _NewInternationalLicense.IsActive = true;
            _NewInternationalLicense.CreatedByUserID= Global.User.UserID;
        }
        private void _SaveIssueForm()
        {
            if (clsInternationalLicense.isLicenseExistByLocalLicense(_License.LicenseID))
            {
                MessageBox.Show($" Person already has an international driving License ! ", "Error"
                    , MessageBoxButtons.OK
                      , MessageBoxIcon.Error);
                return;
            }


            if (_License.LicenseClass!=clsLicenseClass.GetLicenseID("Class 3 - Ordinary driving license"))
            {
                MessageBox.Show($" License Should be Ordinary driving License ! ", "Error", MessageBoxButtons.OK
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

            
            _FillInternationalLicenseInfo();

            if (_NewInternationalLicense.Save())
            {
                MessageBox.Show($"Internationl License Saved Successfully  ", "Save", MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                _FillFormInfo();
            }
            else
            {
                MessageBox.Show($"Internationl License Saving Failed ! ", "Error", MessageBoxButtons.OK
                   , MessageBoxIcon.Error);

            }
        }
        private void btnIssue_Click(object sender, EventArgs e)
        {
            _SaveIssueForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LLHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLicenseHistory frm = new FormLicenseHistory(_License.PersonInfo.PersonID);
            frm.StartPosition = FormStartPosition.CenterParent;   
            frm.ShowDialog();
        }

        private void llShowLicenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormInternationalLicenseInfo frm=new FormInternationalLicenseInfo(_License.PersonInfo.PersonID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }
}
