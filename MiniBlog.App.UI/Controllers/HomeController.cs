using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniBlog.Core.IService;
using MiniBlog.Core.Plugin;

namespace MiniBlog.App.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Fuji(int index)
        {
            var options = new PagerOption
            {
                PageIndex = index,
                PageSize = 6,
            };
            var result = await _postService.GetPagerAsync(options.PageIndex, options.PageSize);
            options.Total = result.total;
            ViewBag.Options = options;
            return View(result.rows);
        }

        public async Task<IActionResult> Shoot(int index)
        {
            var options = new PagerOption
            {
                PageIndex = index,
                PageSize = 6,
            };
            var result = await _postService.GetPagerAsync(options.PageIndex, options.PageSize);
            options.Total = result.total;
            ViewBag.Options = options;
            return View(result.rows);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
