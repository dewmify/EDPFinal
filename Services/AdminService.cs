using EDPFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDPFinal.Services
{
    public class AdminService
    {
        private static List<Admin> adminList;

        public List<Admin> Insert(Admin emp)
        {
            if (adminList == null)
                adminList = new List<Admin>();

            adminList.Add(emp);
            return adminList;
        }
        public List<Admin> SelectAll()
        {
            return adminList;

        }
        List<Admin> AllAdmins = new List<Admin>
        {
            new Admin{ID = "0123", Email = "Joshua", Password = "Password123!"}
            
         };

        public List<Admin> GetAllAdmins()
        {
            return AllAdmins;
        }
        public Admin GetAdminById(String id)
        {
            Admin admin = null;
            foreach (Admin item in AllAdmins)
            {
                if (item.ID == id)
                {
                    admin = item;
                }
            }
            return admin;
        }
    }
}
