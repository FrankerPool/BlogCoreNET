using BlogCoreNET.AccessData.Data.Repository.IRepository;
using BlogCoreNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace BlogCoreNET.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IContenedorWork _contenedorWork;
        public CategoriesController(IContenedorWork contenedorWork)
        {
            _contenedorWork = contenedorWork;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create() {
            return View();
        }
		[HttpGet]
		public IActionResult Delete()
		{
			return View();
		}
		[HttpDelete]
        public IActionResult Delete(int Id)
        {
			var objcategory = _contenedorWork.Category.GetValue(Id);
			if (objcategory == null)
			{
				return Json(new {success = false, Message = "Delete Error"});
			}
			_contenedorWork.Category.Remove(objcategory);
			_contenedorWork.Save();

			return Json(new { success = true, Message = "Deleted" });
		}
		[HttpGet]
		public IActionResult Edit(int Id)
		{
            Category category = new Category();
            category = _contenedorWork.Category.GetValue(Id);
            if (category == null)
            {
                return NotFound();
            }

			return View(category);
		}
		[HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult Edit(Category category)
		{
            if (ModelState.IsValid)
            {
                _contenedorWork.Category.Update(category);
                _contenedorWork.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(category);
		}
        [HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult Create(Category category)
		{
            if (ModelState.IsValid)
            {
                _contenedorWork.Category.Add(category);
                _contenedorWork.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(category);
		}
		#region CALLS API
		[HttpGet]
        public IActionResult GetAll() {
            return Json(new {data = _contenedorWork.Category.GetAll()});
        }

        #endregion
    }
}
