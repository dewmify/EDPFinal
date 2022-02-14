using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace EDPFinal.Models
{
    public class Guides
    {
       [Key]
        public int guideID { get; set; }

     
        public string guideInfo { get; set; }
        public string guideTitle { get; set; }
        public string guideETR { get; set; }

        public string guideVideo { get; set; }
    }
}
