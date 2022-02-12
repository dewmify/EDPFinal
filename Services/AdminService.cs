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
        private Models.SLDbContext _context;
        public AdminService(Models.SLDbContext context)
        {
            _context = context;
        }


        /*List<Admin> AllAdmins = new List<Admin>
        {
            new Admin{ID = "0123", Email = "Joshua", Password = "Password123!"}
            
         };*/

        public List<AdminModel> GetAllAdmins()
        {
            List<AdminModel> AllAdmins = new List<AdminModel>();
            AllAdmins = _context.Admins.ToList();
            return AllAdmins;
        }

        private bool AdminExists(string id)
        {
            return _context.Admins.Any(e => e.adminID == id);
        }

        public bool AddAdmin(AdminModel newadmin)
        {
            if(AdminExists(newadmin.adminID))
            {
                return false;
            }
            _context.Add(newadmin);
            _context.SaveChanges();
            return true;
        }
        public AdminModel GetAdminById(String id)
        {
            AdminModel theAdmin = _context.Admins.Where(e => e.adminID == id).FirstOrDefault();
            return theAdmin;
        }

        public AdminModel GetAdminByEmail(string email)
        {
            AdminModel theAdmin = _context.Admins.SingleOrDefault(o => o.adminEmail == email);
            return theAdmin;
        }

        public bool UpdateAdmin(AdminModel theadmin)
        {
            bool updated = true;
            _context.Attach(theadmin).State = EntityState.Modified;
            try
            {
                /*_context.Update(theadmin);*/
                _context.SaveChanges();
                updated = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!AdminExists(theadmin.adminID))
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

        public bool DeleteAdmin(AdminModel theadmin)
        {
            bool deleted = true;
            try
            {
                _context.Remove(theadmin);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(theadmin.adminID))
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
