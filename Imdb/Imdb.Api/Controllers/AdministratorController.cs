using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Imdb.Domain.Interfaces;
using Imdb.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Imdb.Api.Controllers
{
    [Route("api/administrator")]
    [ApiController]
    public class AdministratorController : Controller
    {

        private readonly IServiceAdministrator _serviceAdministrator;
        private readonly IServiceUser _serviceUser;


        public AdministratorController(IServiceAdministrator serviceAdministrator, IServiceUser serviceUser)
        {
            _serviceAdministrator = serviceAdministrator;
            _serviceUser = serviceUser;
        }

        [HttpPost]
        [Authorize(Roles = "administrator")]
        public IActionResult Create([FromBody] AdministratorModel administratorModel)
        {
            try
            {
                var admin = _serviceAdministrator.Insert(administratorModel);

                return Ok("Este usuário agora é um administrador");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut]
        [Authorize(Roles = "administrator")]
        public IActionResult Update([FromBody] AdministratorModel administratorModel)
        {
            try
            {
                var user = _serviceAdministrator.Update(administratorModel);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("listUsers")]
        [Authorize(Roles = "administrator")]
        public IActionResult ListUsers()
        {
            try
            {
                var users = _serviceUser.RecoverAll();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
