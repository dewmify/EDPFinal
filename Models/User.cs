﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDPFinal.Models
{
    public class User
    {
        public int userID { get; set; }

        [Required, RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Invalid email")]
        public string userEmail { get; set; }

        [Required, StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string userName { get; set; }
        
        [Required]
        public string userPassword { get; set; }
        public string userPhoneNo { get; set; }

    }
}
