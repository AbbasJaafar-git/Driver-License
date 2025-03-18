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
    public partial class FormInternationalLicenseInfo : Form
    {
         int  IntLicenseID=-1;
        public FormInternationalLicenseInfo(int IntLicenseID)
        {
            InitializeComponent();
            this.IntLicenseID = IntLicenseID;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlInternationalLicenseInfo1.LoadLicenseInfoByInt(IntLicenseID);
        }
    }
}
