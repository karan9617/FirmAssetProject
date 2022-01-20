using ASPProject4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASPProject4.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new List<UserModel>());
        }
    }
}