using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Proje.Business.Abstract;
using Proje.Business.Concrete;
using Proje.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Proje.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProjeController : ControllerBase
    {
        private IProjeService _projeService;
        public ProjeController(IProjeService projeService) {
            _projeService = projeService;
        }
        [HttpGet("GetAllProducts")]
        public ApiResponse<List<Urun>> GetProduct()
        {
            var response = new ApiResponse<List<Urun>>();

            try
            {
                var result = _projeService.GetAllUrun();

                response = new ApiResponse<List<Urun>>
                {
                    Code = 200,
                    Message = "OK",
                    ResponseData = result
                };
            }
            catch (Exception ex)
            {
                response = new ApiResponse<List<Urun>>
                {
                    Code = 404,
                    Message = ex.Message,
                    ResponseData = null
                };
            }

            return response;
        }
        

        [HttpGet("GetAllRawMaterials")]
        public List<Hammadde> GetRawMaterials()
        {
            return _projeService.GetAllHammadde();
        }

        [HttpGet("GetProductById")]
        public Urun GetProductById(int id)
        {
            return _projeService.GetUrunById(id);

        }
        [HttpGet("GetRawMaterialById")]
        public Hammadde GetRawMaterialById(int id)
        {
            return _projeService.GetHammaddeById(id);
        }

        [HttpDelete("DeleteProduct")]
        public void DeleteProduct(int id)
        {
            _projeService.DeleteUrun(id);

        }

        [HttpPut("CreateRawMaterials")]
        public void CreateRawMaterials(int id)
        {
            _projeService.CreateHammadde(id);
        }
        [HttpPut("CrateProduct")]
        public void CreateProduct(int id)
        {
            _projeService.CreateUrun(id);
        }
        [HttpPost("Register")]
        public User Register(User user)
        {
            return _projeService.CreateUser(user);
        }
       



    }
}
