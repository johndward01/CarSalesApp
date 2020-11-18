using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CarSalesApp.Interfaces;
using CarSalesApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarSalesApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUser _user;
        public UsersController(IUser user)
        {
            _user = user;
        }

        public IActionResult Index()
        {
            var users = _user.GetAllUsers();
            return View(users);
        }
        
        public IActionResult GetUser(int id)
        {
            var user = _user.GetUser(id);
            return View(user);
        }

        public IActionResult InsertUser(User user)
        {
            _user.InsertUser(user);
            return View(user);
        }

        public IActionResult UpdateUser(User user)
        {
            var userToUpdate = _user.GetUser(user.UserID);
            _user.UpdateUser(userToUpdate);
            if (userToUpdate == null)
            {
                return View("User Not Found");
            }
            return View(userToUpdate);
        }

        public IActionResult DeleteUser(User user)
        {
            _user.DeleteUser(user);
            return RedirectToAction("Index");
        }
        
    }
}
