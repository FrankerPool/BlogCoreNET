using BlogCoreNET.AccessData.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BlogCoreNET.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ArticlesController : Controller
	{
		private readonly IContenedorWork _contenedorWork;
		public ArticlesController(IContenedorWork contenedorWork)
		{
			_contenedorWork = contenedorWork;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		#region CALLS API
		[HttpGet]
		public IActionResult GetAll()
		{
			return Json(new { data = _contenedorWork.Article.GetAll() });
		}

		#endregion
	}
}
