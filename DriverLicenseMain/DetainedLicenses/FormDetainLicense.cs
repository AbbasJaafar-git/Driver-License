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
using static DriverLicense.DetainedLicenses.FormReleaseLicense;

namespace DriverLicense.DetainedLicenses
{
    public partial class FormDetainLicense : Form
    {
        public delegate void RefreshListDetained();

        public event RefreshListDetained OnRefreshListDetained;

        clsDetainedLicense _DetainedLicense = new clsDetainedLicense();
        int _LicenseID = -1;

        public FormDetainLicense()
        {
            InitializeComponent();
        }

        private void FormDetainLicense_Load(object sender, EventArgs e)
        {
            _ResetDetainFrom();

        }

        private void ctrlLicenseWithFilter1_OnSelectedLicense(int obj)
        {
            _LicenseID = obj;

            if (clsDetainedLicense.isLicenseDetained(_LicenseID))
            {
                MessageBox.Show($"  Selected License is Already Detained" +
                    $" ,choose another License ! ", "Error"
                   , MessageBoxButtons.OK
                     , MessageBoxIcon.Error);
                btnDetain.Enabled = false;
                LLHistory.Enabled = true;

                return;
            }
            LLHistory.Enabled = true;

            btnDetain.Enabled = true;

        }

        private void _ResetDetainFrom()
        {
            lbDetainID.Text = "[????]";
            lbDetainDate.Text = DateTime.Now.ToShortDateString();
            lblFineFees.Text = "50";
            lblLicenseID.Text = "[????]";
            lblCreatedByUser.Text = Global.User.UserName;

            LLHistory.Enabled = false;
            llShowLicenceInfo.Enabled = false;
            btnDetain.Enabled = false;
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

        private void _FillDetainedLicenseInfo()
        {
            _DetainedLicense.LicenseID = _LicenseID;
            _DetainedLicense.DetainDate = DateTime.Now;
            _DetainedLicense.FineFees = 50;
            _DetainedLicense.CreatedByUserID = Global.User.UserID;
            _DetainedLicense.IsReleased=false;

        }
        private void _FillFormInfo()
        {

            lbDetainID.Text = _DetainedLicense.DetainID.ToString();
            lbDetainDate.Text = _DetainedLicense.DetainDate.ToShortDateString();
            lblFineFees.Text = _DetainedLicense.FineFees.ToString();
            lblLicenseID.Text = _LicenseID.ToString();
            lblCreatedByUser.Text = Global.User.UserName;

            LLHistory.Enabled = true;
            llShowLicenceInfo.Enabled = true;
            ctrlLicenseWithFilter1.Enabled = false;
            btnDetain.Enabled=false;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to Detain this License ? ", "Confirm"
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

            _FillDetainedLicenseInfo();
            if (_DetainedLicense.Save())
            {
                MessageBox.Show($" License Detained Successfully ", "Save", MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                _FillFormInfo();
            }
            else
            {
                MessageBox.Show($" License Detained Failed ! ", "Error", MessageBoxButtons.OK
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
