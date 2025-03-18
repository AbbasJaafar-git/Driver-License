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

namespace DriverLicense
{
    public partial class ctrlUserCard : UserControl
    {

        clsUsers _User = new clsUsers();
        public int UserToCheck { get { return _User.UserID; } }
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        private void ctrlUserCard_Load(object sender, EventArgs e)
        {

            _RefreshCard();
        }

        private void _RefreshCard()
        {

            
        }


        public bool LoadUserInfo(int UserID)
        {

            _User = clsUsers.FindUser(UserID);
            if (_User != null)
            {
                _ResetUserInfo();
                _FillUserInfo();
                return true;

            }
            else
            {
                MessageBox.Show($"No User with UserID = {UserID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

        }
        void _ResetUserInfo() {
            lblUserID.Text = "[????]";
            lblUserName.Text = "[????]";
            lblIsActive.Text = "[????]";
        }
        private void _FillUserInfo()
        {
            ctrlPersonInfo1.LoadPersonInfo(_User.PersonID);

            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName;
            lblIsActive.Text = _User.isActive ? "Yes" : "No";


        }

        public void ShowLinkLabeUpdate()
        {
            linkLabel2.Visible = true;
        }
        private void ctrlPersonInfo1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormAddUpdatePerson formAddUpdatePerson = new FormAddUpdatePerson(_User.PersonID);
            formAddUpdatePerson.OnRefreshPeople += _FillUserInfo ;
            formAddUpdatePerson.ShowDialog();
        }
    }
}
