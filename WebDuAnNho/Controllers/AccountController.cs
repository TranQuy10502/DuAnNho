using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebDuAnNho.Models;

namespace WebDuAnNho.Controllers
{
    public class AccountController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7075/api");
        private readonly HttpClient _client;
        public AccountController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
     
      
        //[Route("login")]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string userName, string password)
        {
            var data = new Dictionary<string, string>
            {
                { "userName", userName },
                { "password", password }
            };

            var _content = new FormUrlEncodedContent(data);
            string context = JsonConvert.SerializeObject(data);
            StringContent content = new StringContent(context, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/account/Login", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return View("Index","Home");
                
            }
            TempData["ErrorMessage"] = "Invalid username or password.";
            return View();
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [Route("create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = _client.PostAsync(_client.BaseAddress + "/account/Register", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction();
            }

            TempData["ErrorMessage"] = "Registration failed.";
            return View();
        }












    }
}
