using DriverLicense.Users;
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
    public partial class FormUsersManagement : Form
    {
        public FormUsersManagement()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormUsersManagement_Load(object sender, EventArgs e)
        {
            _RefreshUsersForm();
        }

        private void _RefreshUsersForm()
        {
            dgvUsers.DataSource = clsUsers.GetAllUsers();
            dgvUsers.AutoGenerateColumns = true;
            dgvUsers.Columns["fullName"].Width = 300;
            lblRecords.Text = dgvUsers.RowCount.ToString();
            cbUsers.SelectedIndex = 0;



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tSMShowDetails_Click(object sender, EventArgs e)
        {
            FormUserCardInfo userCardInfo = new FormUserCardInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            userCardInfo.ShowDialog();
        }
        private void _ShowFormAddUpdateUser()
        {
            FormAddUpdateUser formAddUpdateUser = new FormAddUpdateUser();
            formAddUpdateUser.OnRefreshUsers += _RefreshUsersForm;
            formAddUpdateUser.ShowDialog();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            _ShowFormAddUpdateUser();
        }
        private void tSMAddUser_Click(object sender, EventArgs e)
        {
            _ShowFormAddUpdateUser();
        }

        private void CMSUdpat_Click(object sender, EventArgs e)
        {
            FormAddUpdateUser formAddUpdateUser = new FormAddUpdateUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            formAddUpdateUser.OnRefreshUsers += _RefreshUsersForm;
            formAddUpdateUser.ShowDialog();
        }
        private void tSMDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure You want to delete this User?"
                , "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                if (clsUsers.Delete((int)dgvUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshUsersForm();
                }
                else
                    MessageBox.Show("User Deleting Failed!!! ", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void tMSChangePass_Click(object sender, EventArgs e)
        {
            FormChangePassword1 formChangePassword1 = new FormChangePassword1((int)dgvUsers.CurrentRow.Cells[0].Value);
            formChangePassword1.onRefreshUser += _RefreshUsersForm;
            formChangePassword1.ShowDialog();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbUsers.SelectedIndex == 0 || cbUsers.SelectedIndex == 1)
            {
                char c = e.KeyChar;
                if (!char.IsDigit(c) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
            }
           // string rowFilter = string.Format("[{0}] = '{1}'", 1, 1);
            //(dgvUsers.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }

        private void cbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbUsers.SelectedIndex ==4 )
            {
                txtFilter.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.SelectedIndex = 0;
                (dgvUsers.DataSource as DataTable).DefaultView.Sort = "IsActive";

            }
            else
            {
                cbIsActive.Visible = false;
                txtFilter.Visible = true;

            }

            switch(cbUsers.SelectedIndex)
            {
                case 0:
                    (dgvUsers.DataSource as DataTable).DefaultView.Sort = "UserID";
                    break;
                case 1:
                    (dgvUsers.DataSource as DataTable).DefaultView.Sort = "PersonID";
                    break;
                case 2:
                    (dgvUsers.DataSource as DataTable).DefaultView.Sort = "fullName";
                    break;
                case 3:
                    (dgvUsers.DataSource as DataTable).DefaultView.Sort = "UserName";

                    break;



            }
        }
    }
}
