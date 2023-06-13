using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using WebDuAnNho.Models;

namespace WebDuAnNho.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/product")]
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
                foreach (var item in products)
                {
                    getProductCategory(item);
                }
            }

            return View(products);
        }

        private void getProductCategory(Product product)
        {
            var responsePC = _client.GetAsync(_client.BaseAddress + "/productcategory/GetById/" + product.ProductCategoryId).Result;
            if (responsePC.IsSuccessStatusCode)
            {
                var resData = responsePC.Content.ReadAsStringAsync().Result;
                product.ProductCategory = JsonConvert.DeserializeObject<ProductCategory>(resData);
            }
        }


        [Route("add")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {

            var productCategories = await GetProductCategoriesFromAPI();
            ViewBag.ProductCategory = new SelectList(productCategories.ToList(), "Id", "Title");
            return View();
        }

        [Route("add")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Product model, List<string> Images, List<int> rDefault)
        {

                if (Images != null && Images.Count > 0)
                {
                    for (int i = 0; i < Images.Count; i++)
                    {
                        if (i + 1 == rDefault[0])
                        {
                            model.Image = Images[i];
                            model.ProductImages = new List<ProductImage>
                            {
                                 new ProductImage
                                 {
                                     ProductId = model.Id,
                                     Image = Images[i],
                                     IsDefault = true
                                 }
                            };
                        }
                        else
                        {
                            model.ProductImages.Add(new ProductImage
                            {
                                ProductId = model.Id,
                                Image = Images[i],
                                IsDefault = false
                            });
                        }
                    }
                }
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;

                if (string.IsNullOrEmpty(model.Alias))
                    model.Alias = WebDuAnNho.Models.Common.Filter.FilterChar(model.Title);
                try
                {
                  
                    string data = JsonConvert.SerializeObject(model);
                    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/product/Add", content).Result;

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

                return RedirectToAction("Index");
            ViewBag.ProductCategory = GetProductCategoriesFromAPI();
            return View(model);
        }

        private async Task<List<ProductCategory>> GetProductCategoriesFromAPI()
        {
            List<ProductCategory> productCategories = new List<ProductCategory>();
            var response = await _client.GetAsync(_client.BaseAddress + "/productcategory/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var categoriesJson = await response.Content.ReadAsStringAsync();
                productCategories = JsonConvert.DeserializeObject<List<ProductCategory>>(categoriesJson);
            }

            return productCategories;
        }

        [Route("edit/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit (int id)
        {
            try
            {
                var productCategories = await GetProductCategoriesFromAPI();
                ViewBag.ProductCategory = new SelectList(productCategories.ToList(), "Id", "Title");

                HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + "/product/GetById" + id);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var sanPham = JsonConvert.DeserializeObject<Product>(data);
                    return View(sanPham);
                }

                return NotFound();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }



















    }
}
