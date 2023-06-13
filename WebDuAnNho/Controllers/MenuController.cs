using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System.Net.Http;
using WebDuAnNho.Models;


namespace WebDuAnNho.Controllers
{
    public class MenuController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        Uri baseAddress = new Uri("https://localhost:7075/api");
        private readonly HttpClient _client;
        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
            _httpClientFactory = httpClientFactory;
        }

        public MenuController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductCategory> items = new List<ProductCategory>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/productcategory/GetAll").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                items = await response.Content.ReadAsAsync<List<ProductCategory>>(new CancellationToken());
                ViewBag.DataProductCategory = items;
            }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> MenuTop()
        {
            List<Category> items = new List<Category>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/category/GetAll").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                items = await response.Content.ReadAsAsync<List<Category>>(new CancellationToken());
                ViewBag.DataCategory = items;
            }

            return PartialView("_MenuTop");
        }

        [HttpGet]
        public async Task<ActionResult> MenuProductCategory()
        {
            List<ProductCategory> items = new List<ProductCategory>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/productcategory/GetAll").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                items = await response.Content.ReadAsAsync<List<ProductCategory>>(new CancellationToken());
                ViewBag.DataProductCategory = items;
            }

            return PartialView("_MenuProductCategory", items);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> MenuLeft(int? id)
        {
            List<ProductCategory> items = new List<ProductCategory>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/productcategory/GetById" +id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                items = await response.Content.ReadAsAsync<List<ProductCategory>>(new CancellationToken());
                ViewBag.DataProductCategory = items;
            }

            return PartialView("_MenuLeft");
        }



        [HttpGet]
        public async Task<ActionResult> MenuArrivals()
        {
            List<ProductCategory> items = new List<ProductCategory>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/productcategory/GetAll").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                items = await response.Content.ReadAsAsync<List<ProductCategory>>(new CancellationToken());
                ViewBag.DataProductCategory = items;
            }

            return PartialView("_MenuArrivals",items);
        }




        public async Task<List<Category>> GetCategories()
        {
              List<Category> items = new List<Category>();
              HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/category/GetAll").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                items = await response.Content.ReadAsAsync<List<Category>>(new CancellationToken());
            }
            return items;
        }



        public async Task<List<ProductCategory>> GetProductCategories()
        {
            List<ProductCategory> items = new List<ProductCategory>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/productcategory/GetAll").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                items = await response.Content.ReadAsAsync<List<ProductCategory>>(new CancellationToken());
            }
            return items;
        }

        public async Task<List<ProductCategory>> GetProductCategories(int id)
        {
            List<ProductCategory> items = new List<ProductCategory>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/productcategory/GetById" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                items = await response.Content.ReadAsAsync<List<ProductCategory>>(new CancellationToken());
            }
            return items;
        }

    }
}
