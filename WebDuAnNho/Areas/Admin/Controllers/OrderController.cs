using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebDuAnNho.Models;

namespace WebDuAnNho.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/order")]
    public class OrderController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7075/api");
        private readonly HttpClient _client;
        public OrderController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<order> gioHang = new List<order>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/order/GetAll").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                gioHang = JsonConvert.DeserializeObject<List<order>>(data);
            }

            return View();
        }

        [HttpGet("{id}")]
        public IActionResult View(int id)
        {
            List<order> giohang = new List<order>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/order/GetById" + id).Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                giohang = JsonConvert.DeserializeObject<List<order>>(data);
            }

            return View();
        }



        public IActionResult PartialSanPham()
        {
            return PartialView();
        }

    }
}
