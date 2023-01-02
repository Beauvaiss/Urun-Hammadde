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
                    var x = projeDbContext.Stok.Where(w => w.UrunId.Equals(id)).ToList();
                    foreach (var a in x)
                    {
                        var b = projeDbContext.Hammadde.Where(x => x.HamId.Equals(a.HamId)).FirstOrDefault();
                        b.HamAdet = b.HamAdet + 100;

                        projeDbContext.SaveChanges();
                    }

                }
            }
        }

        public void CreateUrun(int id)
        {
            using (var projeDbContext = new ProjeDbContext())
            {
                var UrunUret = projeDbContext.Stok.Where(d => d.UrunId.Equals(id)).FirstOrDefault();
                if (UrunUret != null)
                {
                    var urungetir = projeDbContext.Urun.Where(w => w.UrunId.Equals(id)).FirstOrDefault();
                    urungetir.UrunAdet = urungetir.UrunAdet + 1;
                    var x = projeDbContext.Stok.Where(w => w.UrunId.Equals(id)).ToList();
                    foreach (var a in x)
                    {
                        var b = projeDbContext.Hammadde.Where(x => x.HamId.Equals(a.HamId)).FirstOrDefault();
                        var c = projeDbContext.Stok.Where(x => x.Hammadde.HamId.Equals(a.HamId)).FirstOrDefault();
                        b.HamAdet = b.HamAdet -c.StokSayi;

                        projeDbContext.SaveChanges();
                    }
                }
            }
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
        