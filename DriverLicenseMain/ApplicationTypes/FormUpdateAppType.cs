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
    public partial class FormUpdateAppType : Form
    {

        public delegate void RefreshTypes();
        public event RefreshTypes onRefreshTypes;
        clsApplicationsTypes AppType;
        public FormUpdateAppType(int ID)
        {
            InitializeComponent();
            AppType= clsApplicationsTypes.FindApplicationType(ID);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void _FillFormUpdateInfo() {
            lblID.Text = AppType.ID.ToString();
            txtTitle.Text = AppType.Title;
            txtFees.Text= AppType.Fees.ToString();
        }

        private void FormUpdateAppType_Load(object sender, EventArgs e)
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
            AppType.Title= txtTitle.Text;
            AppType.Fees = Convert.ToDouble(txtFees.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _FillAppTypeInfo();
            if(AppType.Save())
                MessageBox.Show("Application Type Updated Successfully","Update",MessageBoxButtons.OK,MessageBoxIcon.Information);
            else
                MessageBox.Show("Application Type Updating Failed !!!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
    }
}
