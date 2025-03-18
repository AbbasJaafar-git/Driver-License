using PeopleBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverLicense
{
    public partial class FormAddUpdateUser : Form
    {

        public delegate void RefreshUsers();

        public event RefreshUsers OnRefreshUsers;

        clsUsers _User = new clsUsers();
        public FormAddUpdateUser()
        {
            InitializeComponent();
        }

        public FormAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _User = clsUsers.FindUser(UserID);
            ctrlPersonInfoWithFilter1.ShowLinkLabeUpdate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormFindPerson formFindPerson = new FormFindPerson();
            formFindPerson.ShowDialog();
        }

        private void _RefreshUserInfo()
        {
            if (_User.UserID != -1)
            {
                lblAddUpdate.Text = "Update User Info";
                _FillFormWithUserInfo();
            }
        }
        private void FormAddUpdateUser_Load(object sender, EventArgs e)
        {
            _RefreshUserInfo();
            
        }

        private void _FillFormWithUserInfo()
        {
            ctrlPersonInfoWithFilter1.LoadctrlCardInfo(_User.PersonID);
            lblID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            chkActive.Checked = _User.isActive;
        }

        private void lblAddUpdate_Click(object sender, EventArgs e)
        {
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_CheckIfEmptyPersonInfo())
            {
                MessageBox.Show("Please Select a Person "
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsUsers.IsPersonHasAUser(ctrlPersonInfoWithFilter1.PersonIDToCheck) && _User.Mode== clsUsers.enMode.AddNew)
            {
                MessageBox.Show("Selected Person Already has a User,choose another one"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tabControl1.SelectedTab = tbLoginInfo;
        }

        private void tbLoginInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnRefreshUsers?.Invoke();
            this.Close();
        }

        private void txtConfirmPass_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirmPass.Text != txtPass.Text)
            {
                errorProvider1.SetError(txtConfirmPass, "Password is not Correct!");
            } else
                errorProvider1.Clear();
        }
        private bool _CheckIfEmptyPersonInfo()
        {
            return (ctrlPersonInfoWithFilter1.PersonIDToCheck == -1);
        }

        private bool _CheckIfEmptyUserInfo()
        {

            return (txtUserName.Text == string.Empty 
                || txtPass.Text == string.Empty || txtConfirmPass.Text==string.Empty);
        }

        void _FillUserInfo()
        {
            _User.PersonID = ctrlPersonInfoWithFilter1.PersonIDToCheck;
            _User.UserName = txtUserName.Text;
            _User.Password= txtPass.Text;
            _User.isActive = chkActive.Checked;


        }
        private void _SaveUserInfo()
        {
           if(_CheckIfEmptyUserInfo() || _CheckIfEmptyPersonInfo())
            {
                MessageBox.Show("You Should Fill required information!"
                   , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillUserInfo();
            if (_User.Save())
            {
                MessageBox.Show("User Saved Successfully"
                   , "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshUserInfo();
            }
            else
            {
                MessageBox.Show("User Saving Failed!"
                   , "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _SaveUserInfo();
        }

        private void ctrlPersonInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}
