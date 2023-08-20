using Microsoft.AspNetCore.Mvc;

namespace testMVC.Controllers
{
	public class IndexController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Courses()
		{
			return View();
		}

		public IActionResult Register()
		{
			return View();
		}

		public IActionResult Login()
		{
			return View();
		}

		public IActionResult RegstarInCourse()
		{
			return View();
		}

		public IActionResult Thanks()
		{
			return View();
		}

		public IActionResult Error(string type, string description)
		{
			return View();
		}

	}
}
