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

namespace DriverLicense.Users
{
    public partial class FormChangePassword1 : Form
    {

        public delegate void RefreshUsers();
        public event RefreshUsers onRefreshUser;

        private clsUsers _User= new clsUsers();

        public FormChangePassword1(int UserID)
        {
            InitializeComponent();
            _User = clsUsers.FindUser(UserID);

        }

        private void FormChangePassword1_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfo(_User.UserID);
            ctrlUserCard1.ShowLinkLabeUpdate(); 


        }

        private void txtCurrentPass_TextChanged(object sender, EventArgs e)
        {
            if(txtCurrentPass.Text != _User.Password)
            {
                errorProvider1.SetError((TextBox)sender, "Password is incorrect!");
            }
            else
                errorProvider1.Clear();
        }

        private void txtConfirmPass_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirmPass.Text != txtNewPass.Text)
            {
                errorProvider1.SetError(txtConfirmPass, "Password is not Correct!");
            }
            else
            {
                errorProvider1.Clear();
                _User.Password = txtNewPass.Text;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _CheckIfEmptyUserInfo()
        {
            return (txtCurrentPass.Text == "" || txtNewPass.Text == "");
        }

        private bool _CheckIfPasswordCorrect()
        {

            bool us= _User.Password == txtCurrentPass.Text;  
            return us;
        }
        private void _SaveUserInfo()
        {
            if (_CheckIfEmptyUserInfo())
            {
                MessageBox.Show("You Should Fill required information!"
                   , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_CheckIfPasswordCorrect())
            {
                MessageBox.Show("User Password Is not correct!"
                  , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_User.Save())
            {
                MessageBox.Show("User Saved Successfully"
                   , "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
