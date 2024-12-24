using BlogCoreNET.AccessData.Data.Repository.IRepository;
using BlogCoreNET.Models;
using Microsoft.AspNetCore.Mvc;

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
