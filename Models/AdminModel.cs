using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EDPFinal.Models
{
    public class AdminModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int adminID {get; set;}
        
        public string adminEmail {get; set;}

        public string adminPassword { get; set; }

        public void setPassword (string password)
        {
            var hash = BCrypt.Net.BCrypt.HashPassword(password, 12);
            adminPassword = hash;
        }

        public bool comparePassword (string str)
        {
            var currentPassword = adminPassword;

            var isPasswordMatching = BCrypt.Net.BCrypt.Verify(str, currentPassword);
            return isPasswordMatching;
        }
    }
}
