using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class ClientMoneyTranferViewModel
    {
        public ApplicationUser Client { get; set; }
        public IEnumerable<ClientBalance> ClientBalances { get; set; }
        public MoneyTransfer MoneyTransfer { get; set; }
    }
}
