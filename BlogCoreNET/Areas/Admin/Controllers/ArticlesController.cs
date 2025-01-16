using Microsoft.AspNetCore.Mvc;

namespace BlogCoreNET.Areas.Admin.Controllers
{
	public class ArticlesController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
