using CloudinaryDotNet;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

using WebDuAnNho.Models;


namespace WebDuAnNho.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/news")]
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
            }

            return View(baiViet);
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
        public IActionResult Add(News baiViet)
        {
            try
            {
                baiViet.IsActive = true;
                baiViet.CategoryId = 1;
                baiViet.ModifiedDate = baiViet.CreatedDate = DateTime.Now;
                baiViet.Alias = WebDuAnNho.Models.Common.Filter.FilterChar(baiViet.Title);
                string data = JsonConvert.SerializeObject(baiViet);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/news/Add", content).Result;
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


        //sua



        [Route("edit/{id}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                News baiViet = new News();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/news/GetById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    baiViet = JsonConvert.DeserializeObject<News>(data);
                }
                return View(baiViet);
            }
            catch (Exception)
            {

                return View();
            }
        }

        [Route("edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(News baiViet)
        {

            try
            {
                baiViet.IsActive = true;
                baiViet.CategoryId = 1;
                baiViet.ModifiedDate = baiViet.CreatedDate = DateTime.Now;
                baiViet.Alias = WebDuAnNho.Models.Common.Filter.FilterChar(baiViet.Title);
                string data = JsonConvert.SerializeObject(baiViet);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/news/Edit", content).Result;

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
                News baiViet = new News();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/news/GetById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    baiViet = JsonConvert.DeserializeObject<News>(data);
                }
                return View(baiViet);
            }
            catch (Exception)
            {

                return View();
            }
        }

        [Route("delete/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(News baiViet)
        {

            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/news/delete/" + baiViet.Id).Result;

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
