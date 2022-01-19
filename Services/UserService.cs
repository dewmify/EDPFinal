using EDPFinal.Models;
using System;
using System.Collections.Generic;

namespace EDPFinal.Services
{
    public class UserService
    {
        public static List<User> userList;

        public List<User> AllUsers { get; private set; }

        public List<User> GetAllUsers()
        {
            return AllUsers;
        }
    }
}
