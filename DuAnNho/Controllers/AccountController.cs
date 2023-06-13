using DuAnNho.Areas.Identity.Data;
using DuAnNho.IServices;
using DuAnNho.Models.EF;
using DuAnNho.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DuAnNho.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAllServices<UserVM> _allRepositories;
        private readonly ApplicationBDContext _context;
        public AccountController(IAllServices<UserVM> allRepositories, ApplicationBDContext context)
        {
            _context = context;
            _allRepositories = allRepositories;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _allRepositories.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }




        [HttpPost]
        public IActionResult Login(object content)
        {
            var data = JsonConvert.DeserializeObject<Dictionary<string,string>>(content.ToString());
            var userName = "";
            var pass = "";
            data.TryGetValue("userName",out userName);
            data.TryGetValue("password", out pass);
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);

            if (user == null || user.Password != pass)
            {
                return BadRequest("Invalid username or password");
            }           

            return Ok(user);
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
           
            return Ok("Logout successful");
        }


        [HttpPost]
        public IActionResult Register(object data)
        {
            var user = JsonConvert.DeserializeObject<UserVM>(data.ToString());

            if (_context.Users.Any(u => u.UserName == user.UserName))
            {
                return BadRequest("Username already exists");
            }
            User newUser = user.ToUser(); 

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return Ok("Registration successful");
        }




    }
}
