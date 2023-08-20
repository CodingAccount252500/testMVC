using Microsoft.AspNetCore.Mvc;
using testMVC.DTO.Req;

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

		[HttpPost]
		public IActionResult Login(string email,string password)
		{
			return View();
		}

		public IActionResult RegstarInCourse()
		{
			return View();
		}

		[HttpPost]
		public IActionResult RegstarInCourse(CourseRegstration model)
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
