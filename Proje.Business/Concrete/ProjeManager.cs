using Proje.Business.Abstract;
using Proje.DataAcces.Abstract;
using Proje.DataAcces.Concrete;
using Proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Business.Concrete
{
    public class ProjeManager : IProjeService
    {
        private IProjeRepository _projeRepository;

        public ProjeManager(IProjeRepository projeRepository)
        {
            _projeRepository=projeRepository;
        }

        public void CreateHammadde(int id)
        {
            _projeRepository.CreateHammadde(id);
        }

        public void CreateUrun(int id)
        {
            _projeRepository.CreateUrun(id);
        }

        public void DeleteHammadde(int id)
        {
            _projeRepository.DeleteHammadde(id);
        }

        public void DeleteUrun(int id)
        {       
            _projeRepository.DeleteUrun(id);
        }

        public List<Hammadde> GetAllHammadde()
        {
           return _projeRepository.GetAllHammadde();
        }

        public List<Stok> GetAllStok()
        {
            return _projeRepository.GetAllStok();
        }

        public List<Urun> GetAllUrun()
        {
            return _projeRepository.GetAllUrun();
        }

        public Hammadde GetHammaddeById(int id)
        {
            return _projeRepository.GetHammaddeById(id);
        }

        public Urun GetUrunById(int id)
        {
            return _projeRepository.GetUrunById(id);
        }
    }

    
}
