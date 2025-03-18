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
    public partial class FormPersonCardDetails : Form
    {

        private int _PersonID;
        public FormPersonCardDetails(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPersonCardDetails_Load(object sender, EventArgs e)
        {
           ctrlPersonInfo1.LoadPersonInfo(_PersonID);


        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormAddUpdatePerson formAddUpdatePerson = new FormAddUpdatePerson();
            formAddUpdatePerson.ShowDialog();
        }
    }
}
