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
        private readonly ProjeDbContext _projeDbContext;
        String Message { get; set; }

        public ProjeRepository()
        {
            _projeDbContext = new ProjeDbContext();
        }

        public void CreateHammadde(int id)
        {
           
                var HamUret = _projeDbContext.Stok.Where(d => d.UrunId.Equals(id)).FirstOrDefault();
               if (HamUret != null)
                {
                    var x = _projeDbContext.Stok.Where(w => w.UrunId.Equals(id)).ToList();
                    foreach (var a in x)
                    {
                        var b = _projeDbContext.Hammadde.Where(x => x.HamId.Equals(a.HamId)).FirstOrDefault();
                        b.HamAdet = b.HamAdet + 100;
                        _projeDbContext.SaveChanges();
                    }

                
            }
        }

        public void CreateUrun(int id)
        {
            
                var UrunUret = _projeDbContext.Stok.Where(d => d.UrunId.Equals(id)).FirstOrDefault();
                if (UrunUret != null)
                {
                    var urungetir = _projeDbContext.Urun.Where(w => w.UrunId.Equals(id)).FirstOrDefault();
                    urungetir.UrunAdet = urungetir.UrunAdet + 1;
                    var x = _projeDbContext.Stok.Where(w => w.UrunId.Equals(id)).ToList();
                    foreach (var a in x)
                    {
                        var b = _projeDbContext.Hammadde.Where(x => x.HamId.Equals(a.HamId)).FirstOrDefault();
                        var c = _projeDbContext.Stok.Where(x => x.Hammadde.HamId.Equals(a.HamId)).FirstOrDefault();
                    if(b.HamAdet>=c.StokSayi)
                    {
                        b.HamAdet = b.HamAdet - c.StokSayi;
                        _projeDbContext.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Yeterli Hammadde Yok");
                    }  
                    }
                
            }
        }

        public void DeleteHammadde(int id)
        {
            
                var deleteHammadde = GetHammaddeById(id);
                _projeDbContext.Hammadde.Remove(deleteHammadde);
                _projeDbContext.SaveChanges();
            
          
            
        }

        public void DeleteUrun(int id)
        {
          
                var deleteUrun = GetUrunById(id);
                _projeDbContext.Urun.Remove(deleteUrun);
                _projeDbContext.SaveChanges();
            
        }

        public List<Hammadde> GetAllHammadde()
        {
           
                return _projeDbContext.Hammadde.ToList();
            
        }

        public List<Stok> GetAllStok()
        {
            throw new NotImplementedException();
        }

        public List<Urun> GetAllUrun()
        {
           
                return _projeDbContext.Urun.ToList();
            
        }

        public Hammadde GetHammaddeById(int id)
        {
           
                return _projeDbContext.Hammadde.Find(id);
            
        }

        public Urun GetUrunById(int id)
        {
            
                return _projeDbContext.Urun.Find(id);
            
        }
    }
}
        