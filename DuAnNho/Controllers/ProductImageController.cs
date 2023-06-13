using DuAnNho.IServices;
using DuAnNho.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuAnNho.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IAllServices<ProductImageVM> _allRepositories;
        public ProductImageController(IAllServices<ProductImageVM> allRepositories)
        {
            _allRepositories = allRepositories;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_allRepositories.GetAll());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _allRepositories.GetById(id);
            try
            {
                return Ok(product);

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPost]
        public IActionResult Add(ProductImageVM item)
        {
            try
            {
                return Ok(_allRepositories.Add(item));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        //Sua
        [HttpPut("{id}")]
        public IActionResult Edit(ProductImageVM item)
        {
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
    }
}
