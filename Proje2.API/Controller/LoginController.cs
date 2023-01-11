using Microsoft.AspNetCore.Authorization;
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
        public ApiResponse<User> Register(User user)
        {
            var response = new ApiResponse<User>();
            try
            {
                var result = _projeService.CreateUser(user);

                response = new ApiResponse<User>
                {
                    Code = 200,
                    Message = "OK",
                    ResponseData = result
                };
            }
            catch (Exception ex)
            {
                response = new ApiResponse<User>
                {
                    Code = 404,
                    Message = ex.Message,
                    ResponseData = null
                };
            }
            return response;
        }
        [HttpGet("GetToken")]
        public ApiResponse<String> LogIn(String username,string password)
        {
            var response = new ApiResponse<String>();
            try
            {
                var result = _projeService.Login(username,password);

                response = new ApiResponse<String>
                {
                    Code = 200,
                    Message = "OK",
                    ResponseData = result
                };
            }
            catch (Exception ex)
            {
                response = new ApiResponse<String>
                {
                    Code = 404,
                    Message = ex.Message,
                    ResponseData = null
                };
            }
            return response;
        }
    }
}
