using DuAnNho.IServices;
using DuAnNho.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuAnNho.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly IAllServices<PaymentMethodsVM> _allRepositories;
        public PayController(IAllServices<PaymentMethodsVM> allRepositories)
        {
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
        public IActionResult Add(PaymentMethodsVM item)
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
        public IActionResult Edit(int id,PaymentMethodsVM item)
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
