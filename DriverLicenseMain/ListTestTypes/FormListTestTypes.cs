
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


    public partial class FormListTestTypes : Form
    {
        public FormListTestTypes()
        {
            InitializeComponent();
        }

        private void _RefreshTypes()
        {
            dgvManageTypes.DataSource = clsListTestTypes.GetTestTypes();
            dgvManageTypes.Columns[2].Width = 150;

            dgvManageTypes.Columns[2].Width = 250;
            lblRecords.Text = dgvManageTypes.RowCount.ToString();
        }
        private void FromManageApplicationsTypes_Load(object sender, EventArgs e)
        {
            _RefreshTypes();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUpdateTestType appType = new FormUpdateTestType((int)dgvManageTypes.CurrentRow.Cells[0].Value);
            appType.onRefreshTypes += _RefreshTypes;
            appType.ShowDialog();
        }
    }
}
