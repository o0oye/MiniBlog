using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniBlog.Core.IService;
using MiniBlog.Core.Plugin;

namespace MiniBlog.App.ManageUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IPictureService _pictureService;

        public HomeController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        //主页
        public IActionResult Index()
        {
            return View();
        }

        //图片管理
        [HttpGet]
        public async Task<IActionResult> Pictures([FromQuery]int index)
        {
            var options = new PagerOption
            {
                PageIndex = index,
                PageSize = 3,
            };
            var result = await _pictureService.GetPagerAsync(options.PageIndex, options.PageSize);
            options.Total = result.total;
            ViewBag.Options = options;
            return View(result.rows);
        }

        //删除
        public async Task<IActionResult> Delete(int id)
        {
            await _pictureService.DeletePictureAsync(id);
            return RedirectToAction("Pictures");
        }
    }
}
