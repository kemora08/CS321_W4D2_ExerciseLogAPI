using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W4D2_ExerciseLogAPI.ApiModels;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W4D2_ExerciseLogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;

        // Constructor
        public UsersController(IUserService UserService)
        {
            _userService = UserService;
        }

        // GET api/users
        [HttpGet]
        public IActionResult Get()
        {
            var userModels = _userService
                .GetAll()
                .ToApiModels(); // convert Users to UserModels

            return Ok(userModels);
        }

      

        // get specific user by id
        // GET api/users/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService.Get(id);
            if (user == null) return NotFound();
            return Ok(user.ToApiModel());
        }

        // create a new user
        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody] UserModel newUser)
        {
            try
            {

                // add the new user
                _userService.Add(newUser.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddUser", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { Id = newUser.Id }, newUser);
        }

        // PUT api/user/:id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserModel updatedUser)
        {
            var user = _userService.Update(updatedUser.ToDomainModel());
            if (user == null) return NotFound();
            return Ok(user.ToApiModel());
        }

        // DELETE api/users/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var activity = _userService.Get(id);
            if (activity == null) return NotFound();
            _userService.Remove(activity);
            return NoContent();
        }
    }
}
