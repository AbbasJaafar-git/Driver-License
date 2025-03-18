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

namespace DriverLicense.Applications.LDLApp
{
    public partial class FormShowLDLAppInfo : Form
    {
        int ID = -1;
        public FormShowLDLAppInfo(int LDLAppID)
        {
            InitializeComponent();
            ID = LDLAppID;
        }

        private void Ref()
        {
            ctrlDrivingLicenseApp1.LoadLDLApplicationInfo(ID);
        }
        private void FormShowLDLAppInfo_Load(object sender, EventArgs e)
        {
            Ref();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlDrivingLicenseApp1_Load(object sender, EventArgs e)
        {

        }
    }
}
