using EDPFinal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDPFinal.Services
{
    public class AdminService
    {
        private static List<Admin> adminList;

        private Models.SLDbContext _context;
        public AdminService(Models.SLDbContext context)
        {
            _context = context;
        }


        /*List<Admin> AllAdmins = new List<Admin>
        {
            new Admin{ID = "0123", Email = "Joshua", Password = "Password123!"}
            
         };*/

        public List<Admin> GetAllAdmins()
        {
            List<Admin> AllAdmins = new List<Admin>();
            AllAdmins = _context.Admins.ToList();
            return AllAdmins;
        }

        private bool AdminExists(string id)
        {
            return _context.Admins.Any(e => e.ID == id);
        }

        public bool AddAdmin(Admin newadmin)
        {
            if(AdminExists(newadmin.ID))
            {
                return false;
            }
            _context.Add(newadmin);
            _context.SaveChanges();
            return true;
        }
        public Admin GetAdminById(String id)
        {
            Admin theAdmin = _context.Admins.Where(e => e.ID == id).FirstOrDefault();
            return theAdmin;
        }

        public bool UpdateAdmin(Admin theadmin)
        {
            bool updated = true;
            _context.Attach(theadmin).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
                updated = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!AdminExists(theadmin.ID))
                {
                    updated = false;
                }
                else
                {
                    throw;
                }
            }
            return updated;
        }

        public bool DeleteAdmin(Admin theadmin)
        {
            bool deleted = true;
            try
            {
                _context.Remove(theadmin);
                _context.SaveChanges();
                deleted = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(theadmin.ID))
                {
                    deleted = false;
                }
                else
                {
                    throw;
                }
            }
            return deleted;
        }
    }
}
