using System;
using Imdb.Domain.Interfaces;
using Imdb.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Imdb.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IServiceUser _serviceUser;

        public UserController(IServiceUser serviceUser) =>
            _serviceUser = serviceUser;

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel userModel)
        {
            try
            {
                var user = _serviceUser.Insert(userModel);

                return Created($"/api/users/{user?.Id}", user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult Update([FromBody] UpdateUserModel userModel)
        {
            try
            {
                var user = _serviceUser.Update(userModel);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _serviceUser.SoftDelete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
