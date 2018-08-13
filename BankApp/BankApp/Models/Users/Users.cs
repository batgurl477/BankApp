using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Models.Users
{
    public class Users
    {
        public int UserID { get; set; }
        public string UserUsername { get; set; }
        public string UserPassword { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNum { get; set; } //using string to avoid '0' starter number issues like 021 etc.
        public string HomeAddress { get; set; }
        public bool IsActive { get; set; }
    }
}
