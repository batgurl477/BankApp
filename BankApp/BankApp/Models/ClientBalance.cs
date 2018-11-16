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
        public ApplicationUser Client { get; set; }
        public AccountType AccountType { get; set; }
        public double Balance { get; set; }
        public string Account { get; set; }
    }
    public enum AccountType
    {
        Cheque,
        Savings,
        Other
    }
}
