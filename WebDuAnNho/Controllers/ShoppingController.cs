using Microsoft.AspNetCore.Mvc;

namespace WebDuAnNho.Controllers
{
    public class ShoppingController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7075/api");
        private readonly HttpClient _client;
        public ShoppingController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
