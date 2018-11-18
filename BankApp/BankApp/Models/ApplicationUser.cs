using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BankApp.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date Of Birth")]
        public string DOB { get; set; }

        public string Gender { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        //Required to access admin-only feats like Client Logical Delete
        public bool IsAdmin { get; set; }

        //Logical Delete
        [Display(Name = "Status")]
        public bool IsActive { get; set; }

        public IEnumerable<ClientBalance> Balance { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
