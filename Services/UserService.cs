using EDPFinal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EDPFinal.Services
{
    public class UserService
    {
        public static List<UserModel> userList;

        private UserDbContext _context;

        public UserService(UserDbContext context)
        {
            _context = context;
        }

        public List<UserModel> AllUsers { get; private set; }

        public List<UserModel> GetAllUsers()
        {
            List<UserModel> AllUser = new List<UserModel>();
            AllUsers = _context.Users.ToList();
            return AllUsers;
        }

        public UserModel GetUserById(int id)
        {
            var userObject = _context.Users.Where(o => o.userID == id).FirstOrDefault();
            return userObject;
        }

        public bool AddUser(UserModel userObject)
        {
            if (_context.Users.Any(o => o.userID == userObject.userID)) return false;
            _context.Users.Add(userObject);
            _context.SaveChanges();
            
            return true;
        }

        public UserModel GetUserByEmail(string email)
        {
            var userObject = _context.Users.SingleOrDefault(o => o.userEmail == email);
            return userObject;
        }
        public UserModel GetUserByPhonenum(string userPhoneNo)
        {
            var userObject = _context.Users.SingleOrDefault(o => o.userPhoneNo == userPhoneNo);
            return userObject;
        }

        public bool UpdateUser(UserModel userObject)
        {
            _context.Attach(userObject).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
        public bool DestroyUser(int id)
        {
            try
            {
                var userObject = GetUserById(id);
                _context.Remove(userObject);
                _context.SaveChanges();
                return true;
            }
            catch (DBConcurrencyException)
            {
                return false;
            }
        }

    }
}
