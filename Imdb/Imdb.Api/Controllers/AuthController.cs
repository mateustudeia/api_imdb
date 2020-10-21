using System;
using System.Linq;
using System.Net;
using Imdb.Api.Helpers;
using Imdb.Domain.Interfaces;
using Imdb.Domain.Models;
using Imdb.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Imdb.Api.Controllers
{
    [Route("api/auths")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IServiceUser _serviceUser;
        public AuthController(IServiceUser serviceUser)
        {
            _serviceUser = serviceUser;
        }
        [HttpPost("register")]
        [AllowAnonymous]
        public ActionResult Register(CreateUserModel createUserModel)
        {
            if (_serviceUser.GetAll().FirstOrDefault(u => u.Email == createUserModel.Email) != null)
            {
                return HttpResponseHelper.Create(HttpStatusCode.BadRequest, ApiConstants.ERR_EMAIL_IN_USE);
            }

            try
            {
                _serviceUser.Register(createUserModel);
                return HttpResponseHelper.Create(HttpStatusCode.Created, ApiConstants.MSG_REGISTER_SUCCESS);
            }
            catch(Exception ex)
            {
                return HttpResponseHelper.Create(HttpStatusCode.InternalServerError, ApiConstants.ERR_GENERIC, ex);
            }
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult Login(UserLoginModel userLoginModel, [FromServices] IConfiguration config)
        {
            var user = _serviceUser.Login(userLoginModel.Email, userLoginModel.Password);

            if (user == null)
            {
                return HttpResponseHelper.Create(HttpStatusCode.Unauthorized, ApiConstants.ERR_EMAIL_PASSWORD_INCORRECT);
            }

            var token = TokenHelper.GenerateUserToken(user, config.GetSection("AppSettings:Token").Value);
            return HttpResponseHelper.Create(HttpStatusCode.OK, ApiConstants.MSG_LOGIN_SUCCESS, token);
        }


    }
}
