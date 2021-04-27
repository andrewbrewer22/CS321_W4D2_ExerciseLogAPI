using CS321_W4D2_ExerciseLogAPI.Core.Services;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W4D2_ExerciseLogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {   
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll().ToApiModels());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService.Get(id);
            if (user == null)
                return NotFound();

            return Ok(user.ToApiModel());
        }

        [HttpPost]
        public IActionResult Post([FromBody]UserModel user)
        {
            try
            {
                return Ok(_userService.Add(user.ToDomainModel()));
            }
            catch(Exception e)
            {
                ModelState.AddModelError("Post", e.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody]UserModel user)
        {
            var current = _userService.Get(id);

            if (current == null)
                return NotFound();

            current = _userService.Update(user.ToDomainModel());

            return Ok(current);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var current = _userService.Get(id);

            if (current == null)
                return NotFound();

            _userService.Remove(current);

            return NoContent();
        }
    }
}
