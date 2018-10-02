using BankApp.Data;
using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Repository
{
    public class homeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public homeRepository(ApplicationDbContext dbContext)
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
    }
}
