
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
    public partial class FormUpdateTestType : Form
    {

        public delegate void RefreshTypes();
        public event RefreshTypes onRefreshTypes;
        clsListTestTypes TestType;
        public FormUpdateTestType(int ID)
        {
            InitializeComponent();
            TestType = clsListTestTypes.FindTestType(ID);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void _FillFormUpdateInfo()
        {
            lblID.Text = TestType.ID.ToString();
            txtTitle.Text = TestType.Title;
            txtDescription.Text = TestType.Description;

            txtFees.Text = TestType.Fees.ToString();
        }

        private void FormUpdateTestType_Load(object sender, EventArgs e)
        {

            _FillFormUpdateInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            onRefreshTypes?.Invoke();
            this.Close();

        }

        private void _FillAppTypeInfo()
        {
            TestType.Title = txtTitle.Text;
            TestType.Description = txtDescription.Text;

            TestType.Fees = Convert.ToDouble(txtFees.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _FillAppTypeInfo();
            if (TestType.Save())
                MessageBox.Show("Test Type Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Test Type Updating Failed !!!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
    }
}

