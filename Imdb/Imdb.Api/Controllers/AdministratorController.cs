using System;
using System.Net;
using Imdb.Api.Helpers;
using Imdb.Domain.Interfaces;
using Imdb.Domain.Models;
using Microsoft.AspNetCore.Authorization;
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

                return HttpResponseHelper.Create(HttpStatusCode.Created, ApiConstants.MSG_REGISTER_ADMIN_SUCCESS, admin);

            }
            catch (Exception ex)
            {
                return HttpResponseHelper.Create(HttpStatusCode.BadRequest, ApiConstants.ERR_GENERIC, ex);

            }
        }
        [HttpPut]
        [Authorize(Roles = "administrator")]
        public IActionResult Update([FromBody] AdministratorModel administratorModel)
        {
            try
            {
                var user = _serviceAdministrator.Update(administratorModel);

                return HttpResponseHelper.Create(HttpStatusCode.Created, ApiConstants.MSG_GENERIC_UPDATE_SUCCESS, user);

            }
            catch (Exception ex)
            {
                return HttpResponseHelper.Create(HttpStatusCode.BadRequest, ApiConstants.ERR_GENERIC, ex);

            }
        }

        [HttpGet("listUsers")]
        [Authorize(Roles = "administrator")]
        public IActionResult ListUsers()
        {
            try
            {
                var users = _serviceUser.RecoverAll();

                return HttpResponseHelper.Create(HttpStatusCode.Created, ApiConstants.MSG_GENERIC_SUCCESS, users);
            }
            catch (Exception ex)
            {
                return HttpResponseHelper.Create(HttpStatusCode.InternalServerError, ApiConstants.ERR_GENERIC, ex);

            }
        }

    }
}
