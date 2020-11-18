using CarSalesApp.Interfaces;
using CarSalesApp.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CarSalesApp.Repositories
{
    public class UserRepository : IUser
    {
        private readonly IDbConnection _conn;
        public UserRepository(IDbConnection connection)
        {
            _conn = connection;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _conn.Query<User>("SELECT * FROM Users;");
        }

        public User GetUser(int id)
        {
            return _conn.QuerySingle<User>("SELECT * FROM Users WHERE User_ID = @id;",
                new { id = id });
        }

        public void InsertUser(User user)
        {
            _conn.Execute("INSERT INTO users (UserName, Password, IsAdmin) Values (@Name, @Password, @IsAdmin);",
                          new { Name = user.UserName, Password = user.Password, IsAdmin = user.IsAdmin });
        }

        public void UpdateUser(User user)
        {
            _conn.Execute("UPDATE users SET UserName = @userName, Password = @password WHERE UserID = @id",
                new { userName = user.UserName, password = user.Password });
        }

        public void DeleteUser(User user)
        {
            _conn.Execute("DELETE FROM users WHERE UserID = @id", new { id = user.UserID });
        }
    }
}
