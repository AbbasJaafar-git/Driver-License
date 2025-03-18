
using PeopleDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleBussinessLayer
{
    public class clsListTestTypes
    {


        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public double Fees { get; set; }

        private clsListTestTypes(int iD, string title, string description, double fees)
        {
            ID = iD;
            Title = title;
            Description = description;
            Fees = fees;
        }

        public static clsListTestTypes FindTestType(int ID)
        {
            string Title = "", Description = "";
            double Fees = 0;
            if (clsTestTypesData.FindTestTypes(ID, ref Title,ref Description, ref Fees))
                return new clsListTestTypes(ID, Title,Description, Fees);
            else
                return null;
        }
        private bool _Update()
        {

            return clsTestTypesData.UpdateType(ID, Title,Description, Fees);
        }
        public bool Save()
        {
            return _Update();
        }

        public static DataTable GetTestTypes()
        {
            return clsTestTypesData.GetAllTypes();
        }
    }
}

