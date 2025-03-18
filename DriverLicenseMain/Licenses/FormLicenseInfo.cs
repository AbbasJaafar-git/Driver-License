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
    public partial class FormLicenseInfo : Form
    {
        int _PersonID = -1;
        int _LicenseClassID = -1;
        int _LicenseID = -1;
        public FormLicenseInfo(int PersonID,int _LicenseClassID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            this._LicenseClassID = _LicenseClassID;
            
        }

        public FormLicenseInfo(int LicenseID)
        {
            InitializeComponent();
           this._LicenseID = LicenseID;


        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormLicenseInfo_Load(object sender, EventArgs e)
        {
            if(_LicenseID>0)
                ctrlLicenseInfo1.LoadLicenseInfo(this._LicenseID);
            else
                ctrlLicenseInfo1.LoadLicenseInfo(_PersonID, _LicenseClassID);

        }
    }
}
