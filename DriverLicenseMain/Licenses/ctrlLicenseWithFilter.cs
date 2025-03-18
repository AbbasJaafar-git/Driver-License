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
    public partial class ctrlLicenseWithFilter : UserControl
    {
        // define event 
        public event Action<int> OnSelectedLicense;

        protected virtual void SelectedLicense(int LicenseID )
        {
            Action<int> handler=OnSelectedLicense;
            if(handler != null)   
            {
                handler(LicenseID);
            }    
        }


       // clsLicense _License = new clsLicense();

        private int  _LicenseID=-1;
        public int LicenseID { get { return _LicenseID; } }
        public ctrlLicenseWithFilter()
        {
            InitializeComponent();
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtFind.Text == string.Empty)
            {
                MessageBox.Show($"Please Enter License ID ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;

                return;
            }


            if (ctrlLicenseInfo1.LoadLicenseInfo(Convert.ToInt32(txtFind.Text)))
            {
                //_FillFormInfo();
               // _License = clsLicense.FindLicense(Convert.ToInt32(txtFind.Text));
                _LicenseID= Convert.ToInt32(txtFind.Text);

                if(OnSelectedLicense != null)
                {
                    SelectedLicense(LicenseID);
                }
            }
            else
            {
                _LicenseID = -1;
                //MessageBox.Show($"No License with PersonID = {txtFind.Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ctrlLicenseWithFilter_Load(object sender, EventArgs e)
        {

        }
    }
}
