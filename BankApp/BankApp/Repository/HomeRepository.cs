using BankApp.Data;
using BankApp.Models;
using BankApp.Models.AccountViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Repository
{
    public class HomeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ApplicationUser> ListAll()
        {
            return _dbContext.Users.ToList();
        }

        public void Add(ApplicationUser user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public ApplicationUser editUser(string ID)
        {
            _dbContext.Users.Find(ID);
            ApplicationUser user = _dbContext.Users.FirstOrDefault(m => m.Id == ID);
            return user;
        }

        public void deleteUser(string ID)
        {
            ApplicationUser user = SingleUser(ID);
            user.IsActive = false;
            _dbContext.SaveChanges();
        }

        public void undeleteUser(string ID)
        {
            ApplicationUser user = SingleUser(ID);
            user.IsActive = true;
            _dbContext.SaveChanges();
        }

        public void editUser(ApplicationUser user)
        {
            _dbContext.Entry(user).GetDatabaseValues();

            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        public ApplicationUser SingleUser(string ID)
        {
            _dbContext.Users.Find(ID);
            ApplicationUser user = _dbContext.Users.SingleOrDefault(m => m.Id == ID);
            return user;
        }

        public ClientBalanceViewModel ClientBalance(string ID)
        {
            _dbContext.Users.Find(ID);
            var viewmodel = new ClientBalanceViewModel()
            {
                applicationUsers = _dbContext.Users.FirstOrDefault(m => m.Id == ID),
                clientBalances = _dbContext.ClientBalance.Where(m => m.Client.Id == ID).ToList()
            };
            return viewmodel;
        }

        public ApplicationUser IsLoggedIn(string Email)
        {
            _dbContext.Users.Find(Email);
            ApplicationUser user = _dbContext.Users.SingleOrDefault(m => m.Email == Email);
            user.IsLoggedIn = true;
            LoginBalanceViewModel balanceViewModel = new LoginBalanceViewModel();
            balanceViewModel.Email = user.Email;
            balanceViewModel.ID = user.Id;
            _dbContext.SaveChanges();
            return user;
        }

        public ApplicationUser IsLoggedOut(string ID)
        {
            _dbContext.Users.Find(ID);
            ApplicationUser user = _dbContext.Users.SingleOrDefault(m => m.Id == ID);
            user.IsLoggedIn = false;
            _dbContext.SaveChanges();
            return user;
        }

        public ClientMoneyTranferViewModel Transfers(ClientMoneyTranferViewModel moneyTransfer, string ID)
        {
            _dbContext.Users.Find(ID);
            ApplicationUser user = _dbContext.Users.SingleOrDefault(m => m.Id == ID);


            ClientBalance toAcc = _dbContext.ClientBalance.Where(m => m.Client.Id == ID)
                .SingleOrDefault(m => m.AccountName == moneyTransfer.MoneyTransfer.ToAccount);

            ClientBalance fromAcc = _dbContext.ClientBalance.Where(m => m.Client.Id == ID)
                .SingleOrDefault(m => m.AccountName == moneyTransfer.MoneyTransfer.FromAccount);

            moneyTransfer.MoneyTransfer.ToAccount = moneyTransfer.MoneyTransfer.ToAccount;
            moneyTransfer.MoneyTransfer.FromAccount = moneyTransfer.MoneyTransfer.FromAccount;
            moneyTransfer.MoneyTransfer.Client = user;

            toAcc.Balance += moneyTransfer.MoneyTransfer.Amount;
            fromAcc.Balance -= moneyTransfer.MoneyTransfer.Amount;

            _dbContext.MoneyTransfer.Add(moneyTransfer.MoneyTransfer);
            _dbContext.SaveChanges();

            return moneyTransfer;
        }

        public ClientMoneyTranferViewModel GetClientandBalancesandMoneyTransferDetails(string ID)
        {
            _dbContext.Users.Find(ID);
            var viewmodel = new ClientMoneyTranferViewModel()
            {
                Client = _dbContext.Users.FirstOrDefault(m => m.Id == ID),
                ClientBalances = _dbContext.ClientBalance.Where(m => m.Client.Id == ID).ToList()
            };

            foreach (var bal in viewmodel.ClientBalances.Where(m => m.Client.Id == ID))
            {
                bal.Account = bal.AccountName + "    $" +
                    bal.Balance.ToString();
            }
            return viewmodel;
        }

        public ClientBalance AddAccount(string ID)
        {
            var client = _dbContext.Users.SingleOrDefault(m => m.Id == ID);
            var Bal = new ClientBalance();

            Bal.Client = client;

            return Bal;
        }

        public ClientBalance AddAccount(string ID, ClientBalance newBal)
        {
            var client = _dbContext.Users.SingleOrDefault(m => m.Id == ID);

            newBal.Client = client;
            newBal.Balance = 100;
            _dbContext.ClientBalance.Add(newBal);
            _dbContext.SaveChanges();

            return newBal;
        }
      
        public ApplicationUser IsAdmin(string Email)
        {
            _dbContext.Users.Find(Email);
            ApplicationUser user = _dbContext.Users.SingleOrDefault(m => m.Email == Email);
            return user;
        }

        public ClientMoneyTranferViewModel MakeAPayment(ClientMoneyTranferViewModel moneyTransfer, string ID)
        {
            _dbContext.Users.Find(ID);
            ApplicationUser user = _dbContext.Users.SingleOrDefault(m => m.Id == ID);


            ClientBalance toAcc = _dbContext.ClientBalance.Where(m => m.Client.Id != ID)
                .SingleOrDefault(m => m.AccountNumber.ToString() == moneyTransfer.MoneyTransfer.ToAccount);

            ClientBalance fromAcc = _dbContext.ClientBalance.Where(m => m.Client.Id == ID)
                .SingleOrDefault(m => m.AccountName == moneyTransfer.MoneyTransfer.FromAccount);

            moneyTransfer.MoneyTransfer.ToAccount = moneyTransfer.MoneyTransfer.ToAccount;
            moneyTransfer.MoneyTransfer.FromAccount = moneyTransfer.MoneyTransfer.FromAccount;
            moneyTransfer.MoneyTransfer.Client = user;

            toAcc.Balance += moneyTransfer.MoneyTransfer.Amount;
            fromAcc.Balance -= moneyTransfer.MoneyTransfer.Amount;

            _dbContext.MoneyTransfer.Add(moneyTransfer.MoneyTransfer);
            _dbContext.SaveChanges();

            return moneyTransfer;
        }
    }
}
