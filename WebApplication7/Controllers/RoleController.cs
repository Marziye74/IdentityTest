using DomainLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication7.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager<Role> _roleManager;
        public RoleController(RoleManager<Role> roleManager) 
        {
            _roleManager = roleManager;
        }


    }
}
