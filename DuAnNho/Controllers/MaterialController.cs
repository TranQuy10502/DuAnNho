using DuAnNho.IServices;
using DuAnNho.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuAnNho.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IAllServices<MaterialsVM> _allRepositories;
        public MaterialController(IAllServices<MaterialsVM> allRepositories)
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

        [HttpPost]
        public IActionResult Add(MaterialsVM item)
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


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var category = _allRepositories.GetById(id);
                if (category != null)
                {
                    return Ok(category);
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


        //Sua
        [HttpPut("{id}")]
        public IActionResult Edit(int id, MaterialsVM item)
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


    }
}
