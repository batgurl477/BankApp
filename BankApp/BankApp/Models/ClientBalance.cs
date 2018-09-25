using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class ClientBalance
    {
        public int ID { get; set; }
        public string AccountName { get; set; }
        public int AccountNumber { get; set; }
        public string ClientRefNumber { get; set; }
        public string OtherRefNumber { get; set; }
        public ApplicationUser Client { get; set; }
    }
}
