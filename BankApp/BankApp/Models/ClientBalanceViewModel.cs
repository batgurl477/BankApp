using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class ClientBalanceViewModel
    {
        public IEnumerable<ClientBalance> clientBalances { get; set; }
        public ApplicationUser applicationUsers { get; set; }
    }
}
