using System;
using System.Collections.Generic;

#nullable disable

namespace EDPFinal.Models
{
    public partial class Table
    {
        public int AdminId { get; set; }
        public string AdminEmail { get; set; }
        public string AdminName { get; set; }
        public string AdminPassword { get; set; }
    }
}
