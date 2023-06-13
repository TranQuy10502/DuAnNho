using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebDuAnNho.Models;

namespace WebDuAnNho.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/productimage")]
    public class PrductImageController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7075/api");
        private readonly HttpClient _client;
        public PrductImageController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ProductImage> productImages = new List<ProductImage>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/productimage/GetAll").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                productImages = JsonConvert.DeserializeObject<List<ProductImage>>(data);
            }

            return View(productImages);
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
        public IActionResult Add(ProductImage productImage)
        {
            try
            {
                productImage.IsDefault = true;
                string data = JsonConvert.SerializeObject(productImage);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/productimage/Add", content).Result;
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




        //// Sua
        //[Route("edit/{id}")]
        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    try
        //    {
        //        ProductImage productImage = new ProductImage();
        //        HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/productimage/GetById/" + id).Result;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string data = response.Content.ReadAsStringAsync().Result;
        //            productImage = JsonConvert.DeserializeObject<ProductImage>(data);
        //        }
        //        return View(productImage);
        //    }
        //    catch (Exception)
        //    {

        //        return View();
        //    }
        //}

        //[Route("edit/{id}")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(ProductImage productImage)
        //{

        //    try
        //    {
        //        productImage.IsDefault = true;
        //        string data = JsonConvert.SerializeObject(productImage);
        //        StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/productimage/Edit", content).Result;

        //        if (response.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return View();
        //}





        [Route("delete/{id}")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                ProductImage productImage = new ProductImage();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/productimage/GetById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    productImage = JsonConvert.DeserializeObject<ProductImage>(data);
                }
                return View(productImage);
            }
            catch (Exception)
            {

                return View();
            }
        }

        [Route("delete/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ProductImage productImage)
        {

            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/productimage/delete/" + productImage.Id).Result;

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
