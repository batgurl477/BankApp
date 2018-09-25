using BankApp.Data;
using BankApp.Models;
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

        public IEnumerable<ClientBalance> ClientBalance(string ID)
        {
            _dbContext.Users.Find(ID);
            var balance = _dbContext.ClientBalance.Include(m => m.Client).FirstOrDefault(m => m.Client.Id == ID);
            yield return balance;
        }
    }
}
