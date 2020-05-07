using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniBlog.Core.IService;
using MiniBlog.Core.Plugin;
using MiniBlog.Core.Plugin.IO;
using MiniBlog.Core.ViewModels.PostView;

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
        public void test()
        { 

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
                PageSize = 4,
            };
            var result = await _pictureService.GetPagerAsync(options.PageIndex, options.PageSize);
            options.Total = result.total;
            ViewBag.Options = options;
            return View(result.rows);
        }

        //上传图片
        public async Task<IActionResult> Picture([FromServices]IWebHostEnvironment env, [FromForm]IFormFile imgFile)
        {
            if (imgFile != null && imgFile.Length > 0 && imgFile.Length < 20971520)
            {
                var fileExt = Path.GetExtension(imgFile.FileName);
                var filePath = Path.Combine(env.WebRootPath, Guid.NewGuid().ToString());
                var picture = new EditPictureViewModel
                {
                    Origin = $"{filePath}_Origin{fileExt}",
                    Big = $"{filePath}_Big{fileExt}",
                    Small = $"{filePath}_Small{fileExt}"
                };
                using (var stream = imgFile.OpenReadStream())
                {
                    FormatImage.AutoToSmall(stream, picture.Big, 1080);
                    FormatImage.AutoToSmall(stream, picture.Small, 260);
                }
                await _pictureService.AddPicture(picture);
            }
            return View();
        }

        //删除
        public async Task<IActionResult> DeletePicture(int id)
        {
            await _pictureService.DeletePicture(id);
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

        //发布博文
        [HttpGet]
        public async Task<IActionResult> Post(int Id)
        {
            var categories = await _categoryService.GetAllCategories();
            ViewBag.Categories = categories.Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Category
            });
            var editPostViewModel = await _postService.GetPost(Id);
            return View(editPostViewModel);
        }

        //编辑博文内容
        [HttpGet]
        public async Task<IActionResult> Content(int Id)
        {
            var editPostViewModel = await _postService.GetPost(Id);
            return View(editPostViewModel);
        }

        //编辑博文内容
        [HttpPost]
        public async Task<IActionResult> Content(EditPostViewModel editPostViewModel)
        {
            var result = await _postService.UpdateContent(editPostViewModel);
            return View(editPostViewModel);
        }

        //删除博文
        public async Task<IActionResult> DeletePost(int Id)
        {
            await _postService.DeletePost(Id);
            return RedirectToAction("Posts");
        }

        //发布博文
        [HttpPost]
        public async Task<IActionResult> Post(EditPostViewModel editPostViewModel)
        {
            var result = 0;
            if (editPostViewModel.Id > 0)
            {
                result = await _postService.UpdatePost(editPostViewModel);
            }
            else
            {
                result = await _postService.AddPost(editPostViewModel);
            }
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
                PageSize = 6,
            };
            var result = await _postService.GetPagerAsync(options.PageIndex, options.PageSize);
            options.Total = result.total;
            ViewBag.Options = options;
            return View(result.rows);
        }
    }
}
