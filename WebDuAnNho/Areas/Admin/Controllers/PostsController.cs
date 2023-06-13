using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebDuAnNho.Models;

namespace WebDuAnNho.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/posts")]
    public class PostsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7075/api");
        private readonly HttpClient _client;

        public PostsController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }


        [HttpGet]
        public IActionResult Index()
        {
            List<Posts> baiViet = new List<Posts>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/posts/GetAll").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                baiViet = JsonConvert.DeserializeObject<List<Posts>>(data);
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
        public IActionResult Add(Posts baiViet)
        {
            try
            {
                baiViet.IsActive = true;
                baiViet.CategoryId = 1;
                baiViet.ModifiedDate = baiViet.CreatedDate = DateTime.Now;               
                string data = JsonConvert.SerializeObject(baiViet);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/posts/Add", content).Result;
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

        //Sua

        [Route("edit/{id}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                Posts baiViet = new Posts();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/posts/GetById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    baiViet = JsonConvert.DeserializeObject<Posts>(data);
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
        public IActionResult Edit(Posts baiViet)
        {

            try
            {
                baiViet.IsActive = true;
                baiViet.CategoryId = 1;
                baiViet.ModifiedDate = baiViet.CreatedDate = DateTime.Now;
                string data = JsonConvert.SerializeObject(baiViet);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/posts/Edit", content).Result;

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


           //Xoa

        [Route("delete/{id}")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                Posts baiViet = new Posts();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/posts/GetById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    baiViet = JsonConvert.DeserializeObject<Posts>(data);
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
        public IActionResult Delete(Posts baiViet)
        {

            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/posts/delete/" + baiViet.Id).Result;

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
