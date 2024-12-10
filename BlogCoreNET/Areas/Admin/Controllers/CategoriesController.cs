using BlogCoreNET.AccessData.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BlogCoreNET.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IContenedorWork _contenedorWork;
        public CategoriesController(IContenedorWork contenedorWork)
        {
            contenedorWork = _contenedorWork;
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
        #region CALLS API
        [HttpGet]
        public IActionResult GetAll() {
            return Json(new {data = _contenedorWork.Category.GetAll()});
        }

        #endregion
    }
}
