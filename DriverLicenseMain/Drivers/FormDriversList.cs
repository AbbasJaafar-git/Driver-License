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

namespace DriverLicense.Drivers
{
    public partial class FormDriversList : Form
    {
        public FormDriversList()
        {
            InitializeComponent();
        }

        private void _RefreshDrivers()
        {
            dgvDrivers.DataSource= clsDriver.GetAllDrivers();
            dgvDrivers.Columns[0].Width = 150;
            dgvDrivers.Columns[1].Width = 100;
            dgvDrivers.Columns[2].Width = 100;
            dgvDrivers.Columns[3].Width = 250;
            dgvDrivers.Columns[4].Width = 200;


            lblRecords.Text= dgvDrivers.Rows.Count.ToString();
        }
        private void FormDriversList_Load(object sender, EventArgs e)
        {
            _RefreshDrivers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
