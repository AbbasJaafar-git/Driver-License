using DriverLicense.InternationalLicense;
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

namespace DriverLicense.Licenses
{
    public partial class FormInternationalLicenses : Form
    {

        clsInternationalLicense _IntLicense= new clsInternationalLicense(); 
        int Records = 0;

        public FormInternationalLicenses()
        {
            InitializeComponent();
        }

        private void _RefreshIntApplications()
        {
            dgvIntApplications.DataSource=clsInternationalLicense.GetInternationalLicenses();
            if(( Records=dgvIntApplications.Rows.Count) > 0)
            {
                dgvIntApplications.Columns[0].Width = 80;
                dgvIntApplications.Columns[4].Width = 150;
                dgvIntApplications.Columns[5].Width = 150;


            }

            lblRecords.Text=Records.ToString(); 

        }
        private void FormInternationalLicenses_Load(object sender, EventArgs e)
        {
            _RefreshIntApplications();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddApp_Click(object sender, EventArgs e)
        {
            FormNewInternationalLicense frm = new FormNewInternationalLicense();
            frm.StartPosition= FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void tSMAppDetails_Click(object sender, EventArgs e)
        {
            FormPersonCardDetails frm = new FormPersonCardDetails(_IntLicense.PersonInfo.PersonID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void tSMShowLicense_Click(object sender, EventArgs e)
        {
            FormInternationalLicenseInfo frm= new FormInternationalLicenseInfo(_IntLicense.PersonInfo.PersonID);
            frm.StartPosition= FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void tSMShowHistory_Click(object sender, EventArgs e)
        {
            FormLicenseHistory frm= new FormLicenseHistory(_IntLicense.PersonInfo.PersonID);
            frm.StartPosition= FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void dgvIntApplications_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvIntApplications.CurrentRow!=null)
                 _IntLicense = clsInternationalLicense.FindLicense((int)dgvIntApplications.CurrentRow.Cells[0].Value);

        }
    }
}
