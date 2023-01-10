using Proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Business.Abstract
{
    public interface IProjeService
    {
        
        List<Urun> GetAllUrun();
        List<Hammadde> GetAllHammadde();
        Urun GetUrunById(int id);
        Hammadde GetHammaddeById(int id);
        void CreateUrun(int id);
        void DeleteUrun(int id);
        void CreateHammadde(int id);
        void DeleteHammadde(int id);
        String Login(string username, string password);

    }
}

