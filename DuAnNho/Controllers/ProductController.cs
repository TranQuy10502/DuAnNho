using DuAnNho.Areas.Identity.Data;
using DuAnNho.IServices;
using DuAnNho.Models.EF;
using DuAnNho.Models.ViewModel;
using DuAnNho.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DuAnNho.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IAllServices<ProductVM> _allRepositories;

        private readonly ApplicationBDContext _context;
       
        public ProductController(IAllServices<ProductVM> allRepositories, ApplicationBDContext context)
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


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var product = _allRepositories.GetById(id);
                if (product != null)
                {
                    return Ok(product);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPost]
        public IActionResult Add(object data)
        {
            try
            {
                var temp = JsonConvert.DeserializeObject<ProductVM>(data.ToString());
                return Ok(_allRepositories.Add(temp));
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        //Sua
        [HttpPut("{id}")]
        public IActionResult Edit(int id, ProductVM item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            try
            {
                _allRepositories.Update(item);
                return NoContent();

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        //Xoa
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _allRepositories.Delete(id);
                return Ok();

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = _context.Products.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                _context.SaveChanges();
                return Ok(new { success = true, isAcive = item.IsActive });
            }

            return Ok(new { success = false });
        }
        [HttpPost]
        public ActionResult IsHome(int id)
        {
            var item = _context.Products.Find(id);
            if (item != null)
            {
                item.IsHome = !item.IsHome;
                _context.SaveChanges();
                return Ok(new { success = true, IsHome = item.IsHome });
            }

            return Ok(new { success = false });
        }

        [HttpPost]
        public ActionResult IsSale(int id)
        {
            var item = _context.Products.Find(id);
            if (item != null)
            {
                item.IsSale = !item.IsSale;
                _context.SaveChanges();
                return Ok(new { success = true, IsSale = item.IsSale });
            }

            return Ok(new { success = false });
        }



    }
}
