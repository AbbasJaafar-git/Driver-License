using PeopleBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverLicense
{
    public partial class ctrlPersonInfo : UserControl
    {

        clsPeople _Person = new clsPeople();

        private int _PersonID = -1;
        public int PersonIDToCheck { get { return _PersonID; } }

        private string _fullName = "";
        public string fullName  { get { return _fullName; } }
        public ctrlPersonInfo()
        {
            InitializeComponent();

        }

        public void _ResetPersonInfo()
        {

            lblID.Text = "[????]";
            lblName.Text ="[????]";
            lblNat.Text = "[????]";
            lblEmail.Text = "[????]";
            lblAddress.Text ="[????]";
            lblCountry.Text ="[????]";
            lblDOB.Text = "[????]";
            lblPhone.Text = "[????]";
            // pictureBox1.Image = _Person.ImagePath.ToString
            _PersonID = -1;
            _fullName = "";

        }
        public bool LoadPersonInfo(int personId)
        {
            _Person= clsPeople.FindPerson(personId);
            if(_Person!=null)
            {
                //_ResetPersonInfo();
                _FillPersonInfo();
                return true;

            }
            else
            {
                //_ResetPersonInfo();

                MessageBox.Show($"No Person with PersonID = {personId}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;

            }


        }

        public bool LoadPersonInfo(string NationalNo)
        {
            _Person = clsPeople.FindPerson(NationalNo);
            if (_Person != null)
            {
                _ResetPersonInfo();
                _FillPersonInfo();
                return true;
            }
            else
            {
                MessageBox.Show($"No Person with National Number = {NationalNo}", "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return false;
            }


        }

        private void _FillPersonInfo()
        {

            lblID.Text = _Person.PersonID.ToString();
            lblName.Text = _Person.FullName;
            lblNat.Text = _Person.NationalNumber;
            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblCountry.Text = _Person.Nationality;
            lblDOB.Text = _Person.DateOfBirth.ToShortDateString();
            lblPhone.Text = _Person.PhoneNumber;
            // pictureBox1.Image = _Person.ImagePath.ToString
            if(_Person.GendorNumber==0)
            {
                pbPersonImage.Image = Properties.Resources.user__1_;
                lblGender.Text = "Male";

            }
            else
            {
                pbPersonImage.Image = Properties.Resources.person_girl;
                lblGender.Text = "Female";
            }
            _PersonID = _Person.PersonID;
            _fullName =_Person.FullName;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void ShowLinkLabeUpdate()
        {
            linkLabel2.Visible = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            FormAddUpdatePerson formAddUpdatePerson = new FormAddUpdatePerson(_PersonID);
            formAddUpdatePerson.ShowDialog();
        }
    }
}
