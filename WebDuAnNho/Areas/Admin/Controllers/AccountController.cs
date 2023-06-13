using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebDuAnNho.Models;

namespace WebDuAnNho.Areas.Admin.Controllers
{

    [Area("admin")]
    [Route("admin")]
    [Route("admin/account")]
    public class AccountController : Controller
    {       
        Uri baseAddress = new Uri("https://localhost:7075/api");
        private readonly HttpClient _client;
        public AccountController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }


        [HttpGet]
        public IActionResult Index()
        {
            List<User> user = new List<User>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/account/GetAll").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<List<User>>(data);
            }
            return View(user);
        }











        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [Route("login")]
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
            HttpResponseMessage response =  _client.PostAsync(_client.BaseAddress + "/account/Login", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product");
            }
            TempData["ErrorMessage"] = "Invalid username or password.";
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            var response = await _client.PostAsync("account/logout", null);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            TempData["ErrorMessage"] = "Logout failed.";
            return View();
        }





        [Route("create")]
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
                return RedirectToAction("Index", "Account");
            }

            TempData["ErrorMessage"] = "Registration failed.";
            return View();
        }

    }
}
