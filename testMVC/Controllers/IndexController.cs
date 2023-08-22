using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using testMVC.DTO.Req;
using testMVC.Models;
using static System.Net.Mime.MediaTypeNames;

namespace testMVC.Controllers
{
	public class IndexController : Controller
	{
		private readonly LMSContext _context;
		private readonly IWebHostEnvironment _environment;
		public IndexController(LMSContext context, IWebHostEnvironment environment) { 
		  _context = context;
		  _environment = environment;
		}
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
		[HttpPost ]
        public async Task<IActionResult> Register(string firstName ,string lastName ,string phone, string email, string password,
			DateTime birthdate,IFormFile file)
        {
			if(_context.Users.Any(x=>x.Email == email))
			{
				return View("Error"); 

            }
			else
			{
				string baseEncoding = ""; string encoding = "";
				if (file != null)
				{
					using (MemoryStream ms = new MemoryStream())
					{
						await file.CopyToAsync(ms);
						var fileBytes = ms.ToArray();
						baseEncoding = Convert.ToBase64String(fileBytes);

						encoding = "data:"+file.ContentType+"; base64," + baseEncoding;
					}
				}
                //if (file != null)
                //{
                //    String wRootPath = _environment.WebRootPath;
                //    String fileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                //    var path1 = Path.Combine(wRootPath + "/Uploads", fileName);

                //    using (var filestream = new FileStream(path1, FileMode.Create))
                //    {
                //        await file.CopyToAsync(filestream);
                //    }
                //    string path = fileName;


                //}
                User newPerson = new User();
                newPerson.Name = firstName + lastName;
				newPerson.Email = email;
				newPerson.PhoneNumber = phone;
				newPerson.BirthDate = birthdate;
				newPerson.Image = encoding;
                _context.Users.Add(newPerson);
				_context.SaveChanges();

            }	
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
