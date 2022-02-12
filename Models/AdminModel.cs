using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDPFinal.Models
{
    public class AdminModel
    {
        [Key]
        public string adminID {get; set;}
        [Required, RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Enter a valid Email")]
        public string adminEmail {get; set;}
        [Required, RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")]
        public string adminPassword { get; set; }
    }
}
