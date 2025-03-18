using PeopleDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PeopleBussinessLayer
{
    public class clsUsers
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public short isActiveNumber { get; set; }
        public bool isActive { get; set; }



        public enum enMode { AddNew, Update };
        public enMode Mode = enMode.AddNew;
        public clsUsers() {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            Mode = enMode.AddNew;
            this.isActiveNumber = 0;
            this.isActive = false;
        }

        private clsUsers(int userId,int personID,string UserName,string Pass,bool isActive)
        {
            this.UserID=userId;
            this.PersonID=personID;
            this.UserName=UserName;
            this.Password=Pass;
            this.isActive = isActive;
            Mode = enMode.Update;

        }

        static public bool IsUserExist(int UserID)
        {
            return clsUsersData.IsUserExist(UserID);
        }

        static public bool IsPersonHasAUser(int PersonId)
        {
            return clsUsersData.CheckIfPersonHasAUser(PersonId);

        }

        public static clsUsers FindUser(int UserID)
        {
            int PersonID = 0;
            string UserName = "", Password = "";
            bool isActive = false;
            if (clsUsersData.FindUser(UserID, ref PersonID, ref UserName, ref Password, ref isActive))
                return new clsUsers(UserID, PersonID, UserName, Password, isActive);
            else
                return null;
        }

        static public clsUsers FindByUserNameAndPassword(string UserName,string Password)
        {
            int UserID = 0, PersonID = 0;
            bool isActive = false;
            if (clsUsersData.FindByUserNameAndPassword(ref UserID, ref PersonID, UserName, Password, ref isActive))
                return new clsUsers(UserID, PersonID, UserName, Password, isActive);
            else
                return null;
        }

        private bool _AddNewUser()
        {
            UserID = clsUsersData.AddNewUser(this.PersonID, this.UserName, this.Password, this.isActive);

            return (UserID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUsersData.UpdateUser(UserID,PersonID,UserName,Password,isActive);

        }
        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();
        }

        public bool Save ()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if(_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }else
                        return false;
                   
                case enMode.Update:
                    return _UpdateUser();

            }
            return false;
        }

        public static bool Delete(int UserID) {

            return clsUsersData.DeleteUser(UserID);

         }
    }
}
