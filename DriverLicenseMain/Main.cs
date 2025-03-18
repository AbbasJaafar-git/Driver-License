using DriverLicense.Applications;
using DriverLicense.DetainedLicenses;
using DriverLicense.Drivers;
using DriverLicense.InternationalLicense;
using DriverLicense.Licenses;
using DriverLicense.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverLicense
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fullScreen();
        }

        private void fullScreen()
        {
            if(this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else if(this.WindowState== FormWindowState.Normal)
            {
                this.WindowState= FormWindowState.Maximized;
            }
        }

        private void managePeopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PeopleForm frm = new PeopleForm();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsersManagement frm = new FormUsersManagement();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void tSMCurrentUserInfo_Click(object sender, EventArgs e)
        {
            FormUserCardInfo userCardInfo= new FormUserCardInfo(Global.User.UserID);
            userCardInfo.StartPosition = FormStartPosition.CenterParent;

            userCardInfo.ShowDialog();
        }

        private void tSMChangeUserPassword_Click(object sender, EventArgs e)
        {
            FormChangePassword1 formChangePassword1 = new FormChangePassword1(Global.User.UserID);
            formChangePassword1.StartPosition = FormStartPosition.CenterParent;

            formChangePassword1.ShowDialog();
        }

        private void tSMSignOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tSMManageTypes_Click(object sender, EventArgs e)
        {
            FromManageApplicationsTypes applicationsTypes = new FromManageApplicationsTypes();
            applicationsTypes.StartPosition= FormStartPosition.CenterParent;
            applicationsTypes.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListTestTypes applicationsTypes = new FormListTestTypes();
            applicationsTypes.StartPosition = FormStartPosition.CenterParent;
            applicationsTypes.ShowDialog();
        }

        private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReleaseLicense frm = new FormReleaseLicense();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNewL frm = new FormNewL();
            frm.StartPosition = FormStartPosition.CenterParent;

            frm.ShowDialog();
        }

        //private void _OpenForm(Form form)
        //{
        //    form= new FormDriversList();
        //    form.ShowDialog();
        //}
        private void localToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLocalDrivingApplication frm = new FormLocalDrivingApplication();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDriversList frm = new FormDriversList();

            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNewInternationalLicense frm = new FormNewInternationalLicense();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInternationalLicenses frm = new FormInternationalLicenses();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRenewLicense frm = new FormRenewLicense();  
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void replacementForToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReplaceLicense frm = new FormReplaceLicense();
            frm.StartPosition=FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void manageDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListDetainedLicenses frm = new FormListDetainedLicenses();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDetainLicense frm = new FormDetainLicense();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

       

        private void realeseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReleaseLicense frm = new FormReleaseLicense();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLocalDrivingApplication frm = new FormLocalDrivingApplication();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }
}
