using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Proje.Business.Abstract;
using Proje.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Proje.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IProjeService _projeService;
        public LoginController(IProjeService projeService)
        {
            _projeService = projeService;
        }
        [HttpPost("Register")]
        public User Register(User user)
        {
            return _projeService.CreateUser(user);
        }
        [HttpGet("GetToken")]
        public string Get(string username, string password)
        {
            return _projeService.Login(username, password);
        }
    }
}
