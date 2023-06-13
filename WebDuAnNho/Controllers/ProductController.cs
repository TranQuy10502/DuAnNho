using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebDuAnNho.Models;

namespace WebDuAnNho.Controllers
{
    public class ProductController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7075/api");
        private readonly HttpClient _client;
        public ProductController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = new List<Product>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/product/GetAll").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<Product>>(data);
                ViewBag.DataProduct = products;
            }

            return View(products);
        }


        [HttpGet]
        public IActionResult Partial_ItemsByCateId()
        {
            List<Product> products = new List<Product>();
            var item = products.Where(x => x.IsHome && x.IsActive).Take(12).ToList();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/product/GetAll").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<Product>>(data);
                ViewBag.DataProduct = products;
            }
            return PartialView();
        }







        public async Task<List<Product>> GetCategories()
        {
            List<Product> items = new List<Product>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/product/GetAll").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                items = await response.Content.ReadAsAsync<List<Product>>(new CancellationToken());
            }
            return items;
        }
    }
}
