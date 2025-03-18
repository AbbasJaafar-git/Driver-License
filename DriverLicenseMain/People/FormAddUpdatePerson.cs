using DriverLicense.Properties;
using PeopleBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverLicense
{
    public partial class FormAddUpdatePerson : Form
    {

        public delegate void RefreshPeople();

        public event RefreshPeople OnRefreshPeople;

        public delegate void ReturnPersonID(int  personID);

        public event ReturnPersonID OnReturnPersonID;

        clsPeople _Person = new clsPeople();
        public FormAddUpdatePerson()
        {
            InitializeComponent();
        }

        public FormAddUpdatePerson(int ID)
        {
            InitializeComponent();
            _Person = clsPeople.FindPerson(ID);
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FormAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _LoadFormInfo();
        }

        private void _LoadFormInfo()
        {
            
            
            cbCountries.DataSource = clsCountries.GetAllCountries();
            cbCountries.DisplayMember = "CountryName";


            if (_Person.PersonID != -1)
            {
                lblAddUpdate.Text = "Update Person Info";
                _FillFormWithInfo();

            }


        }

        private void _FillFormWithInfo()
        {
            lblPersonID.Text = _Person.PersonID.ToString();
            txtNat.Text = _Person.NationalNumber;
            txtFirst.Text = _Person.FirstName;
            txtSecond.Text = _Person.SecondName;
            txtThird.Text= _Person.ThirdName;
            txtLast.Text = _Person.LastName;
            rtxtAddress.Text = _Person.Address;
            txtEmail.Text = _Person.Email;
            txtPhone.Text = _Person.PhoneNumber;
            if (_Person.GendorNumber==0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;
            this.cbCountries.SelectedItem = _Person.Nationality;

            dateTimePicker1.Value = _Person.DateOfBirth;
            // pbGendor=  _Person.ImagePath;

        }
        private void _FillPersonInfo()
        {
            _Person.NationalNumber=txtNat.Text;
            _Person.FirstName =txtFirst.Text;
            _Person.SecondName=txtSecond.Text;
            _Person.ThirdName =txtThird.Text;   
            _Person.LastName= txtLast.Text;
            _Person.Address=rtxtAddress.Text;
            _Person.Email = txtEmail.Text;
            _Person.PhoneNumber=txtPhone.Text;
            _Person.Gendor = rbFemale.Text;

            if (rbMale.Checked)
                _Person.GendorNumber = 0;
            else
            {
                _Person.GendorNumber = 1;
            }
            _Person.Nationality = this.cbCountries.GetItemText(this.cbCountries.SelectedItem);

            _Person.DateOfBirth = dateTimePicker1.Value;
            _Person.ImagePath = "";
            _Person.CountryID = clsCountries.GetCountryID(_Person.Nationality);

        }

        private bool _CheckIfNull()
        {
            bool result=false;
            if(txtNat.Text==null || txtFirst.Text==null || txtEmail.Text==string.Empty )
                result=true;
            return result;
            
        }
        private void _SavePersonInfo()
        {
            if (!_CheckIfNull())
            {
                _FillPersonInfo();
                if (_Person.Save())
                    MessageBox.Show("Data Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Data saving Failed", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Please Fill Data ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _LoadFormInfo();
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            OnRefreshPeople?.Invoke();
            OnReturnPersonID?.Invoke(_Person.PersonID);
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _SavePersonInfo();
        }

        private void txtNat_TextChanged(object sender, EventArgs e)
        {
            if (clsPeople.isNationalNoExist(txtNat.Text) && _Person.Mode == clsPeople.enMode.AddNew)
            {
                errorProvider1.SetError(txtNat, "National Number is Already used!");
            }
            else
                errorProvider1.Clear();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if(rbMale.Checked)
            {
                pbGendor.Image = Resources.user__1_;
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            pbGendor.Image= Resources.person_girl;


        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            //if (txtEmail.Focus())
            //{
            //    bool result=false;
            //    try
            //    {
            //        var email = new MailAddress(txtEmail.Text);

            //        result =email.Address == txtEmail.Text.Trim();
            //        if (result==false)
            //            errorProvider1.SetError(txtEmail, "Email is not Valid!");
            //        txtEmail.Focus();
            //    }
            //    catch (Exception ex) { 
            //        result = false;
            //    }
                
            //}else
            //    errorProvider1.Clear() ;
        }
    }
}
