using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniBlog.Core.IService;
using MiniBlog.Core.Plugin;
using MiniBlog.Core.ViewModels.PostView;

namespace MiniBlog.App.ManageUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IPictureService _pictureService;
        private readonly ICategoryService _categoryService;

        public HomeController(IPictureService pictureService, ICategoryService categoryService)
        {
            _pictureService = pictureService;
            _categoryService = categoryService;
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

        //分类
        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            var categorys = await _categoryService.GetAllCategories();
            return View(categorys);
        }

        //修改分类
        [HttpGet]
        public async Task<IActionResult> Category(int id)
        {
            var category = await _categoryService.GetCategory(id);
            return View(category);
        }

        //更新类别
        public async Task<IActionResult> Category(EditCategoryViewModel editCategoryViewModel)
        {
            var reuslt=await _categoryService.UpdateCategory(editCategoryViewModel);
            if(reuslt>0)
            {
                return RedirectToAction("Categories");
            }
            return View(editCategoryViewModel);
        }
    }
}
