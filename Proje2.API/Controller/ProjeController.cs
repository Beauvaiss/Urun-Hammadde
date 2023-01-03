using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proje.Business.Abstract;
using Proje.Business.Concrete;
using Proje.Entities;


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
        public List<Urun> GetProduct() {
            return _projeService.GetAllUrun();
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

    }
}
