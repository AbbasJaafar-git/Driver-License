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
    public partial class FormLicenseHistory : Form
    {
        int _PersonID=-1;
        public FormLicenseHistory(int PersonID)
        {
            InitializeComponent();
            this._PersonID = PersonID;
        }

        private void _RefreshFormInfo()
        {
            ctrlPersonInfo1.LoadPersonInfo(_PersonID);
            dgvLocalLicenses.DataSource= clsLicense.GetLicensesForPerson(_PersonID);
            if(dgvLocalLicenses.Rows.Count > 0 )
            {
                dgvLocalLicenses.Columns[0].Width = 50;
                dgvLocalLicenses.Columns[1].Width = 80;

                dgvLocalLicenses.Columns[2].Width = 220;
                dgvLocalLicenses.Columns[5].Width = 50;
                if (tabControl1.SelectedIndex == 0) { lblRecords.Text = dgvLocalLicenses.Rows.Count.ToString(); }



            }


            dgvIntLicenses.DataSource= clsInternationalLicense.GetInternationalLicensesForPerson(_PersonID);      
           // dgvIntLicenses.Columns[0].Width = 50;
           if(dgvIntLicenses.Rows.Count > 0)
            {
                dgvIntLicenses.Columns[0].Width = 75;

                dgvIntLicenses.Columns[3].Width = 120;

                dgvIntLicenses.Columns[4].Width = 120;
                
            }
            
        }

        private void FormLicenseHistory_Load(object sender, EventArgs e)
        {
            _RefreshFormInfo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                lblRecords.Text = dgvIntLicenses.Rows.Count.ToString();
            }
           


            if (tabControl1.SelectedIndex == 0) { lblRecords.Text = dgvLocalLicenses.Rows.Count.ToString(); }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (Convert.ToInt32(lblRecords.Text) < 1)
                    return;
                FormLicenseInfo frm = new FormLicenseInfo((int)dgvLocalLicenses.CurrentRow.Cells[0].Value);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            else
            {
                if (Convert.ToInt32(lblRecords.Text) < 1)
                    return;
                FormInternationalLicenseInfo frm =
                    new FormInternationalLicenseInfo((int)dgvIntLicenses.CurrentRow.Cells[0].Value);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();

            }

        }
    }
}
