using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    public class DashboardController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public DashboardController( RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
    }
}
