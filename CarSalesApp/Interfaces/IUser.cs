using CarSalesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSalesApp.Interfaces
{
    public interface IUser
    {
        public IEnumerable<User> GetAllUsers();
        public User GetUser(int id);
        public void InsertUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(User user);
    }
}
