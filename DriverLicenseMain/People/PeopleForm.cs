using PeopleBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DriverLicense
{
    public partial class PeopleForm : Form
    {
        public PeopleForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

       

        private void _RefreshPeople()
        {
            dataGridView1.DataSource = clsPeople.GetPeople();
            dataGridView1.AutoResizeColumns();
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 75;
            dataGridView1.Columns["Gendor"].Width = 60;
            dataGridView1.Columns["Email"].Width = 127;




            lblRecords.Text = dataGridView1.RowCount.ToString();
            cbFilter.SelectedIndex = 0;

        }

        private void PeopleForm_Load(object sender, EventArgs e)
        {
            _RefreshPeople();
        }

        private void _ChangeDataViewAccordingToIndex(int index)
        {
            dataGridView1.Sort(dataGridView1.Columns[index], ListSortDirection.Ascending);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ChangeDataViewAccordingToIndex(cbFilter.SelectedIndex);


        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            _UpdatePerson();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormPersonCardDetails frm = new FormPersonCardDetails((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

        }
        private void _UpdatePerson()
        {
            FormAddUpdatePerson frm = new FormAddUpdatePerson((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.OnRefreshPeople += _RefreshPeople;
            frm.ShowDialog();
        }
        private void _AddNewPerson()
        {
            FormAddUpdatePerson frm = new FormAddUpdatePerson();
            frm.OnRefreshPeople += _RefreshPeople;
            frm.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _AddNewPerson();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (clsPeople.Delete((int)dataGridView1.CurrentRow.Cells[0].Value))
                MessageBox.Show("Person Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Person Deleted Failed,Person has linked data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _RefreshPeople();

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _AddNewPerson();

        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (cbFilter.SelectedIndex == 0)
            {
                char chr = e.KeyChar;
                string filter = "";
                filter += chr;
                if (!char.IsDigit(chr) && !char.IsControl(chr))
                    e.Handled = true;

            }


        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
         

            string FilterColumn = "";

            
            switch (cbFilter.Text.Trim())
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "National No.":
                    FilterColumn = "NationalNo";
                    break;
                case "FirstName":
                    FilterColumn = "FirstName";
                    break;

                case "SecondName":
                    FilterColumn = "SecondName";
                    break;
                case "ThirdName":
                    FilterColumn = "ThirdName";
                    break;
                case "LastName":
                    FilterColumn = "LastName";
                    break;
                case "Gender":
                    FilterColumn = "Gender";
                    break;
                case "DateOfBirth":
                    FilterColumn = "DateOfBirth";
                    break;
                case "Nationality":
                    FilterColumn = "Nationality";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
                case "Email":
                    FilterColumn = "Email";
                    break;
            }

            if(FilterColumn.Trim()=="" || txtFilter.Text.Trim()=="")
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "";

                lblRecords.Text = dataGridView1.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "PersonID")
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = 
                    string.Format("{0} = {1}", FilterColumn, txtFilter.Text.Trim());

            }else
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                   string.Format("{0} like '{1}%'", FilterColumn, txtFilter.Text.Trim());

            
        }
    }
}
