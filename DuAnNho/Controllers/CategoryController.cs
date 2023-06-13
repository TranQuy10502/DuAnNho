﻿using DuAnNho.Areas.Identity.Data;
using DuAnNho.IServices;
using DuAnNho.Models.EF;
using DuAnNho.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuAnNho.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IAllServices<CategoryVM> _allRepositories;
        public CategoryController(IAllServices<CategoryVM> allRepositories)
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
        public IActionResult Add(CategoryVM item)
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
        [HttpPut]
        public IActionResult Edit(CategoryVM item)
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