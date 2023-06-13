using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebDuAnNho.Models;

namespace WebDuAnNho.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/category")]
    public class CategoryController : Controller
    {     

        Uri baseAddress = new Uri("https://localhost:7075/api");      
        private readonly HttpClient _client;
        public CategoryController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        // Hien thi danh sach
        [HttpGet]
        public IActionResult Index()
        {
            List<Category> category = new List<Category>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/category/GetAll").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                category = JsonConvert.DeserializeObject<List<Category>>(data);
            }

            return View(category);
        }


        // Them
        [Route("add")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Route("add")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Category category)
        {
            try
            {
                category.IsActive = true;
                string data = JsonConvert.SerializeObject(category);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/category/Add", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Có lỗi xảy ra trong quá trình thêm danh mục.";
                return View();
            }
            return View();
        }


        // Sua
        [Route("edit/{id}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                Category category = new Category();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/category/GetById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    category = JsonConvert.DeserializeObject<Category>(data);
                }
                return View(category);
            }
            catch (Exception)
            {

                return View();
            }
        }

        [Route("edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {

            try
            {
                category.IsActive = true;
                string data = JsonConvert.SerializeObject(category);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Category/Edit", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }


        [Route("delete/{id}")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                Category category = new Category();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/category/GetById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    category = JsonConvert.DeserializeObject<Category>(data);
                }
                return View(category);
            }
            catch (Exception)
            {

                return View();
            }
        }

        [Route("delete/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {

            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/category/delete/" + category.Id).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }
    }
}
