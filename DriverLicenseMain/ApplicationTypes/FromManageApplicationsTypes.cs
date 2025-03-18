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
    public partial class FromManageApplicationsTypes : Form
    {
        public FromManageApplicationsTypes()
        {
            InitializeComponent();
        }

        private void _RefreshTypes()
        {
            dgvManageTypes.DataSource = clsApplicationsTypes.GetApplicationTypes();
            dgvManageTypes.Columns[1].Width = 230;
            lblRecords.Text = dgvManageTypes.RowCount.ToString();
        }
        private void FromManageApplicationsTypes_Load(object sender, EventArgs e)
        {
            _RefreshTypes();
          
        }

        private void btnClose_Click(object sender,EventArgs e)
        {
            this.Close();
        }

        private void editTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUpdateAppType appType = new FormUpdateAppType((int)dgvManageTypes.CurrentRow.Cells[0].Value);
            appType.onRefreshTypes += _RefreshTypes;
            appType.ShowDialog();
        }
    }
}
