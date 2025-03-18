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
    public partial class ctrlPersonInfoWithFilter : UserControl
    {
        public ctrlPersonInfoWithFilter()
        {
            InitializeComponent();
        }


        public int PersonIDToCheck = -1;
        public string fullName = "";
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void ctrlPersonInfoWithFilter_Load(object sender, EventArgs e)
        {
            cbFind.SelectedIndex = 0;
        }

        public void LoadctrlCardInfo(int PersonID)
        {
            ctrlPersonInfo1.LoadPersonInfo(PersonID);
            PersonIDToCheck = ctrlPersonInfo1.PersonIDToCheck;
            fullName = ctrlPersonInfo1.fullName;
            cbFind.SelectedIndex = 1;
            txtFind.Text = PersonID.ToString();
            ShowLinkLabeUpdate();

            linkLabel2.Enabled = true;


        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FormAddUpdatePerson formAddUpdatePerson = new FormAddUpdatePerson();
            formAddUpdatePerson.OnReturnPersonID += LoadctrlCardInfo;
            formAddUpdatePerson.ShowDialog();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(cbFind.SelectedIndex == 0)
            {
                if (txtFind.Text == string.Empty) {
                    MessageBox.Show("Enter A National Number!");
                    ctrlPersonInfo1._ResetPersonInfo();
                    linkLabel2.Enabled = false;
                    return;
                }

                if (!ctrlPersonInfo1.LoadPersonInfo(txtFind.Text))
                {
                    linkLabel2.Enabled = false;


                    ctrlPersonInfo1._ResetPersonInfo();
                    return;

                }


            }
                else
            {
                if (txtFind.Text == string.Empty)
                {
                    MessageBox.Show("Enter A Person ID !");
                    ctrlPersonInfo1._ResetPersonInfo();
                    linkLabel2.Enabled = false;

                    return;
                }
                try
                {
                    if (!ctrlPersonInfo1.LoadPersonInfo(Convert.ToInt32(txtFind.Text)))
                    {
                        ctrlPersonInfo1._ResetPersonInfo();
                        linkLabel2.Enabled = false;

                        return;
                    }
                }
                catch {
                    MessageBox.Show("Enter A Person ID !");
                }

            }
            PersonIDToCheck = ctrlPersonInfo1.PersonIDToCheck;
            ShowLinkLabeUpdate();
            linkLabel2.Enabled = true;


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
            FormAddUpdatePerson formAddUpdatePerson = new FormAddUpdatePerson(PersonIDToCheck);
            formAddUpdatePerson.OnReturnPersonID += LoadctrlCardInfo;

            formAddUpdatePerson.ShowDialog();
        }
    }
}
