using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebDuAnNho.Models;

namespace WebDuAnNho.Controllers
{
    public class NewsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7075/api");
        private readonly HttpClient _client;
        public NewsController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<News> baiViet = new List<News>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/news/GetAll").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                baiViet = JsonConvert.DeserializeObject<List<News>>(data);
                ViewBag.DataNews = baiViet;
            }

            return View(baiViet);
        }

        [Route("detail/{id}")]
        [HttpGet]
        public IActionResult Detail(int id)
        {
            List<News> baiViet = new List<News>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/news/GetById" + id).Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                baiViet = JsonConvert.DeserializeObject<List<News>>(data);
                ViewBag.DataNews = baiViet;
            }

            return View(baiViet);
        }

        public async Task<ActionResult> Partial_News_Home()
        {
            List<News> items = new List<News>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/news/GetAll").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                items = await response.Content.ReadAsAsync<List<News>>(new CancellationToken());
                ViewBag.DataNews = items;
            }
            return PartialView(items);
        }

        public async Task<List<News>> GetCategories()
        {
            List<News> items = new List<News>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/news/GetAll").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                items = await response.Content.ReadAsAsync<List<News>>(new CancellationToken());
            }
            return items;
        }
    }
}
