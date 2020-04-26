using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniBlog.Core.ViewModels.PostView;
using MiniBlog.Core.IService;

namespace MiniBlog.App.ManageUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAdminService _adminService;
        public AccountController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            return View();
        }
    }
}