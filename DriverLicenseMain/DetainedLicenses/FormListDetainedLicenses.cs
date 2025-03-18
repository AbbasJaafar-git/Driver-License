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

namespace DriverLicense.DetainedLicenses
{
    public partial class FormListDetainedLicenses : Form
    {
        int _Records = 0;
        public FormListDetainedLicenses()
        {
            InitializeComponent();
        }

        private void FormListDetainedLicenses_Load(object sender, EventArgs e)
        {
            _RefreshListForm();
        }

        private void _RefreshListForm()
        {
            dgvDetainedLicenses.DataSource= clsDetainedLicense.GetDetainedLicenses();
            _Records = dgvDetainedLicenses.RowCount;
            if(_Records>0)
            {
                lblRecords.Text=_Records.ToString();
            }
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            FormDetainLicense frm = new FormDetainLicense();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.OnRefreshListDetained += _RefreshListForm;

            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            FormReleaseLicense frm = new FormReleaseLicense();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.OnRefreshListDetained += _RefreshListForm;
            frm.ShowDialog();
        }
    }
}
