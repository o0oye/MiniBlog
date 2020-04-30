using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniBlog.Core.IService;
using MiniBlog.Core.Plugin;
using MiniBlog.Core.ViewModels.PostView;
using MiniBlog.Core.ViewModels.ListView;

namespace MiniBlog.App.ManageUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IPictureService _pictureService;
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;

        public HomeController(IPictureService pictureService,
            ICategoryService categoryService, IPostService postService)
        {
            _pictureService = pictureService;
            _categoryService = categoryService;
            _postService = postService;
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
                PageSize = 6,
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
            var reuslt = await _categoryService.UpdateCategory(editCategoryViewModel);
            if (reuslt > 0)
            {
                return RedirectToAction("Categories");
            }
            return View(editCategoryViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Post(int Id)
        {
            var editPostViewModel = await _postService.GetPost(Id);
            return View(editPostViewModel);
        }

        //发布博文
        [HttpPost]
        public async Task<IActionResult> Post(EditPostViewModel editPostViewModel)
        {
            var result = await _postService.AddPost(editPostViewModel);
            if (result > 0)
            {
                return RedirectToAction("Posts");
            }
            return View(editPostViewModel);
        }


        //博文列表
        public async Task<IActionResult> Posts([FromQuery]int index)
        {
            var options = new PagerOption
            {
                PageIndex = index,
                PageSize = 1,
            };
            var result = await _postService.GetPagerAsync(options.PageIndex, options.PageSize);
            options.Total = result.total;
            ViewBag.Options = options;
            return View(result.rows);
        }
    }
}
