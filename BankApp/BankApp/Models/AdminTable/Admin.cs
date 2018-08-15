using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Models.AdminTable
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string AdminUsername { get; set; }
        public string AdminPassword { get; set; }
        public string AdminFirstName { get; set; }
        public string AdminLastName { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNum { get; set; } //using string to avoid '0' starter number issues like 021 etc.
        public string HomeAddress { get; set; }
        public bool IsActive { get; set; }

    }
}
