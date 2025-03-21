﻿using PeopleBussinessLayer;
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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Global.User = clsUsers.FindByUserNameAndPassword(txtUserName.Text, txtPassword.Text);

            if(Global.User != null )
            {
                if (Global.User.isActive)
                {
                    Main main = new Main();
                    main.ShowDialog();
                    if(chkRemember.Checked != true)
                    {
                        txtUserName.Text = string.Empty;
                        txtPassword.Text = string.Empty;
                    }
                }
                else
                    MessageBox.Show("User is Not Active!", "User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }else
                MessageBox.Show("User/Password is Incorrect!", "User", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
    }
}
