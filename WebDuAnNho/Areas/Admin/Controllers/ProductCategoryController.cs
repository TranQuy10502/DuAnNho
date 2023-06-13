using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebDuAnNho.Models;

namespace WebDuAnNho.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/productcategory")]
    public class ProductCategoryController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7075/api");
        private readonly HttpClient _client;
        public ProductCategoryController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ProductCategory> productCategories = new List<ProductCategory>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/productcategory/GetAll").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                productCategories = JsonConvert.DeserializeObject<List<ProductCategory>>(data);
            }

            return View(productCategories);
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
        public IActionResult Add(ProductCategory productCategories)
        {
            try
            {
              
                productCategories.Alias = WebDuAnNho.Models.Common.Filter.FilterChar(productCategories.Title);
                productCategories.ModifiedDate = productCategories.CreatedDate = DateTime.Now;
                string data = JsonConvert.SerializeObject(productCategories);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/productcategory/Add", content).Result;
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
                ProductCategory productCategory = new ProductCategory();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/productcategory/GetById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    productCategory = JsonConvert.DeserializeObject<ProductCategory>(data);
                }
                return View(productCategory);
            }
            catch (Exception)
            {

                return View();
            }
        }


        [Route("edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductCategory productCategories)
        {

            try
            {

                productCategories.ModifiedDate = productCategories.CreatedDate = DateTime.Now;
                string data = JsonConvert.SerializeObject(productCategories);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/productcategory/Edit", content).Result;

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


        //xoa
        [Route("delete/{id}")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                ProductCategory productCategory = new ProductCategory();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/productcategory/GetById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    productCategory = JsonConvert.DeserializeObject<ProductCategory>(data);
                }
                return View(productCategory);
            }
            catch (Exception)
            {

                return View();
            }
        }

        [Route("delete/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ProductCategory productCategory)
        {

            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/productcategory/delete/" + productCategory.Id).Result;

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
