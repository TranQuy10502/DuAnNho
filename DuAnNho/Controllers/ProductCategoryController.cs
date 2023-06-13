using DuAnNho.IServices;
using DuAnNho.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuAnNho.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IAllServices<ProductCategoryVM> _allRepositories;
        public ProductCategoryController(IAllServices<ProductCategoryVM> allRepositories)
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
            try
            {
                var productcategory = _allRepositories.GetById(id);
                if (productcategory != null)
                {
                    return Ok(productcategory);
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
        public IActionResult Add(ProductCategoryVM item)
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
        [HttpPut]
        public IActionResult Edit( ProductCategoryVM item)
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
