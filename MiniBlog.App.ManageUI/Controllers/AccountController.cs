using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using MiniBlog.Core.IService;
using MiniBlog.Core.ViewModels.PostView;

namespace MiniBlog.App.ManageUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAdminService _adminService;
        public AccountController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        //登陆
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("", "Home");
            }
            return View();
        }

        //登陆
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var user = loginViewModel.User;
            var result = await _adminService.Login(loginViewModel);
            if (result)
            {
                var claim = new Claim(ClaimTypes.Name, user);
                var claims = new List<Claim>();
                claims.Add(claim);
                var claimsIdentity = new ClaimsIdentity(claims, "local");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                return RedirectToAction("", "Home");
            }
            return View();
        }

        //退出
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            return RedirectToAction("Login");
        }

        //修改管理员
        [HttpGet]
        public async Task<IActionResult> Admin()
        {
            var editAdminViewModel = await _adminService.GetAdmin();
            return View(editAdminViewModel);
        }

        //修改管理员
        [HttpPost]
        public async Task<IActionResult> Admin(EditAdminViewModel editAdminViewModel)
        {
            var result= await _adminService.UpdateAdmin(editAdminViewModel);
            if (result > 0)
            {
                return RedirectToAction("LogOut");
            }
            return View(editAdminViewModel);
        }
    }
}