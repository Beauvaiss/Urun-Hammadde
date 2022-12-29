using Proje.DataAcces.Abstract;
using Proje.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DataAcces.Concrete
{
    public class ProjeRepository : IProjeRepository
    {
        public void CreateHammadde(int id)
        {
            using (var projeDbContext = new ProjeDbContext())
            {
                var HamUret = projeDbContext.Stok.Where(d => d.UrunId.Equals(id)).FirstOrDefault();
                if (HamUret != null)
                {
                    if (HamUret.UrunId== id)
                    {
                        var x = projeDbContext.Stok.GroupBy(g=>g.HamId).ToList();
                        foreach (var a in x)
                        {
                            HamUret.Hammadde.HamAdet = HamUret.Hammadde.HamAdet + 100;
                            projeDbContext.SaveChanges();
                        }
                    }
                }
            }
        }

        public void CreateUrun(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteHammadde(int id)
        {
            using (var projeDbContext = new ProjeDbContext())
            {
                var deleteHammadde = GetHammaddeById(id);
                projeDbContext.Hammadde.Remove(deleteHammadde);
                projeDbContext.SaveChanges();
            }
          
            
        }

        public void DeleteUrun(int id)
        {
            using (var projeDbContext = new ProjeDbContext())
            {
                var deleteUrun = GetUrunById(id);
                projeDbContext.Urun.Remove(deleteUrun);
                projeDbContext.SaveChanges();
            }
        }

        public List<Hammadde> GetAllHammadde()
        {
            using (var projeDbContext = new ProjeDbContext())
            {
                return projeDbContext.Hammadde.ToList();
            }
        }

        public List<Stok> GetAllStok()
        {
            throw new NotImplementedException();
        }

        public List<Urun> GetAllUrun()
        {
            using (var projeDbContext=new ProjeDbContext())
            {
                return projeDbContext.Urun.ToList();
            }
        }

        public Hammadde GetHammaddeById(int id)
        {
            using (var projeDbContext = new ProjeDbContext())
            {
                return projeDbContext.Hammadde.Find(id);
            }
        }

        public Urun GetUrunById(int id)
        {
            using (var projeDbContext = new ProjeDbContext())
            {
                return projeDbContext.Urun.Find(id);
            }
        }
    }
}
        