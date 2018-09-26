using BankApp.Data;
using BankApp.Models;
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
    }
}
