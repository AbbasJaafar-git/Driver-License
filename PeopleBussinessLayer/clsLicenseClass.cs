using PeopleDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PeopleBussinessLayer
{
    public class clsLicenseClass
    {

        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription  { get; set; }
        public int MinimumAllowedAge { get; set; }
        public int DefaultValidityLength { get; set; }
        public double ClassFees { get; set; }

        public clsLicenseClass() { 
        
        }

        private clsLicenseClass( int ClassLicenseID,string ClassName,string ClassDescription
            ,int MinAge,int DefLength,double Fees)
        {
            this.LicenseClassID = ClassLicenseID;
            this.ClassName = ClassName; 
            this.ClassDescription = ClassDescription;   
            this.MinimumAllowedAge = MinAge;
            this.DefaultValidityLength = DefLength;
            this.ClassFees = Fees;

        }

        public static DataTable GetAllLicenses()
        {
            return clsLicenseClassData.GetLicenses();
        }

        public static clsLicenseClass Find(int ClassID)
        {
            string className = "", ClassDescp = "";
            int MinAge = 0, defLen = 0;
            double ClassFees = 0;

            if (clsLicenseClassData.Find(ClassID, ref className, ref ClassDescp
                , ref MinAge, ref defLen,ref ClassFees))
            {
                return new clsLicenseClass(ClassID, className, ClassDescp, MinAge, defLen, ClassFees);

            }
            return null;

        }

        public static int GetLicenseID(string ClassName)
        {
            return clsLicenseClassData.GetLicenseClassID(ClassName);
        }
    }
}
