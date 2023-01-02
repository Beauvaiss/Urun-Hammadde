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
        [HttpGet]
        public List<Urun>Get() {
            return _projeService.GetAllUrun();
        }
        [HttpGet]
        [Route("api/[controller]")]
        public List<Hammadde> Get2()
        {
            return _projeService.GetAllHammadde();
        }
        [HttpGet("{id}")]   
        public Urun Get(int id)
        {
            return _projeService.GetUrunById(id);

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _projeService.DeleteUrun(id);

        }
        
        [HttpPut("{id}")]
        public void Post2(int id)
        {
            _projeService.CreateHammadde(id);
        }
        [HttpPut("Urun Olustur/{id}")]
        public void Post3(int id)
        {
            _projeService.CreateUrun(id);
        }

    }
}
