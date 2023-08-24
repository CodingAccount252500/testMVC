using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Security.Cryptography;
using System.Text;
using testMVC.DTO.Req;

using testMVC.Helper;
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
			var result = _context.Courses.ToList();

			return View(result);
		}


		public IActionResult Courses()
		{
            //var result = _context.Courses.ToList();
			var sortedcourses = _context.Courses.OrderBy( x => x.Title);
            return View(sortedcourses);
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
                using (Aes aes = Aes.Create())
				{
					newPerson.Key = Convert.ToBase64String(aes.Key);
					newPerson.Iv= Convert.ToBase64String(aes.IV);
                    newPerson.Name = Helper.Helper.EncryptString(firstName, aes.Key, aes.IV) + "$"+ Helper.Helper.EncryptString(lastName, aes.Key, aes.IV);
                    newPerson.Email = Helper.Helper.GenerateSHA384String(email);
                    newPerson.PhoneNumber = Helper.Helper.EncryptString(phone, aes.Key, aes.IV);
					newPerson.BirthDate = birthdate;
                    newPerson.Image = Helper.Helper.EncryptString(encoding, aes.Key, aes.IV);
                    newPerson.Password = Helper.Helper.GenerateSHA384String(password);
                    _context.Users.Add(newPerson);
                    _context.SaveChanges();
                }
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
			email = Helper.Helper.GenerateSHA384String(email);
            password = Helper.Helper.GenerateSHA384String(password);
			if(_context.Users.Any(x => x.Email == email && x.Password == password))
			{
                var login = _context.Users.Where(x => x.Email == email && x.Password == password).SingleOrDefault();
				if(login != null)
				{
					HttpContext.Session.SetInt32("UserId", login.UserId);
                    HttpContext.Session.SetString("Key", login.Key);
                    HttpContext.Session.SetString("IV", login.Iv);
					return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Error",new { type="Wrong Email or Password", description="" });
		}

		public IActionResult RegstarInCourse()
		{
			return View();
		}

		[HttpPost]
		public IActionResult RegstarInCourse(CourseRegstration model)
		{

			model.UserId = (int)HttpContext.Session.GetInt32("UserId");
			_context.Add(model);
			_context.SaveChanges();
			return View();
		}

		public IActionResult Thanks()
		{
			return View();
		}

		public IActionResult Error(string type, string description)
		{
			ViewBag.Type=type;
			ViewData.Add("Description", description);
			return View();
		}


        public IActionResult Logout()
        {
			HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("Key");
            HttpContext.Session.Remove("IV");
			HttpContext.Session.Clear();
            return View();
        }


    }
}
