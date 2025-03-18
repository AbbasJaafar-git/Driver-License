using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using PeopleBussinessLayer;

namespace DriverLicense.Applications
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        clsApplication application=new clsApplication();

        private int _ApplicationID = -1;

        public int ApplicationID
        {
            get { return _ApplicationID; }
        }
        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        private void _FillApplicationInfo()
        {
            lblApplicationID.Text = application.ApplicationID.ToString();
            lblStatus.Text = application.Status.ToString();
            lblFees.Text=application.PaidFees.ToString();
            lblType.Text = clsApplicationsTypes.FindApplicationType(application.ApplicationTypeID).Title;
            lblApplicant.Text = application.PersonInfo.FullName;    
            lblDate.Text= application.ApplicationDate.ToShortDateString();
            lblStatusDate.Text= application.LastStatusDate.ToShortDateString();
            lblCreatedByUser.Text=application.UserInfo.UserName;
        }
        public void LoadApplicationInfo(int AppID)
        {
            application= clsApplication.FindApplication(AppID);
            if (application == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                _FillApplicationInfo();

        }

        public void ResetApplicationInfo()
        {
            _ApplicationID = -1;

            lblApplicationID.Text = "[????]";
            lblStatus.Text = "[????]";
            lblType.Text = "[????]";
            lblFees.Text = "[????]";
            lblApplicant.Text = "[????]";
            lblDate.Text = "[????]";
            lblStatusDate.Text = "[????]";
            lblCreatedByUser.Text = "[????]";
        }
        private void ctrlApplicationBasicInfo_Load(object sender, EventArgs e)
        {

        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormPersonCardDetails frm = new FormPersonCardDetails(application.ApplicantPersonID);
            frm.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lblType_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void lblApplicant_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lblFees_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void lblApplicationID_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
