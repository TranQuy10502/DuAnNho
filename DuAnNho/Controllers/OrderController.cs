using DuAnNho.IServices;
using DuAnNho.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuAnNho.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IAllServices<OrderVM> _allRepositories;
        public OrderController(IAllServices<OrderVM> allRepositories)
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
        public IActionResult Add(OrderVM item)
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
                var order = _allRepositories.GetById(id);
                if (order != null)
                {
                    return Ok(order);
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
        public IActionResult Edit(int id, OrderVM item)
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
