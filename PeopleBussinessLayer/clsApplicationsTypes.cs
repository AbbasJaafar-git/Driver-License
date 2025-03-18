using PeopleDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleBussinessLayer
{
    public class clsApplicationsTypes
    {
        

        public int ID { get; set; }
        public string Title { get; set; }
        public  double Fees { get; set; }

        private clsApplicationsTypes(int iD, string title, double fees)
        {
            ID = iD;
            Title = title;
            Fees = fees;
        }

      
       
        public static clsApplicationsTypes FindApplicationType(int ID)
        {
            string Title = "";
            double Fees = 0;
            if (clsApplicationsTypesData.FindApplicationType(ID, ref Title, ref Fees))
                return new clsApplicationsTypes(ID,Title,Fees);
            else
                return null;
        }

        public static clsApplicationsTypes FindApplicationType(string Title)
        {
            int ID = -1;
            double Fees = 0;
            if (clsApplicationsTypesData.FindApplicationType( Title,ref ID, ref Fees))
                return new clsApplicationsTypes(ID, Title, Fees);
            else
                return null;
        }
        private bool _Update()
        {

            return clsApplicationsTypesData.UpdateType(ID, Title, Fees);
        }
        public bool Save()
        {
            return _Update();
        }

        public static DataTable GetApplicationTypes()
        {
            return clsApplicationsTypesData.GetAllTypes();
        }
    }
}
