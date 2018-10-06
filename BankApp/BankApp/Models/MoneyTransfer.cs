using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class MoneyTransfer
    {
        public int ID { get; set; }
        public double Amount { get; set; }
        public string ToAccount { get; set; }
        public string FromAccount { get; set; }
        public string ClientRef { get; set; }
        public string OtherRef { get; set; }
        public ApplicationUser Client { get; set; }
        public ClientBalance ClientBalance { get; set; }
    }
}
