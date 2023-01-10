using Microsoft.IdentityModel.Tokens;
using Proje.DataAcces.Abstract;
using Proje.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
        public String Login(string username, string password)
        {
            password=Encrypt.ConvertToEncrypt(password);
            var user = _projeDbContext.User.Where(x=>x.UserName==username&&x.Password==password).ToList();
            if (user.Count > 0)
            {
                  var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
            };
            var signinKey = "BuBenimSigninKey";
            var securityKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signinKey));
            var credential = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer:"https://locahost",
                audience:"https://locahost",
                claims:claims,
                expires:DateTime.Now.AddDays(1),
                notBefore:DateTime.Now,
                signingCredentials:credential

                );

            var token =new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                return token;
            }
            else
            {
                return "Wrong Username or Password";
            }
            
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
        public User CreateUser(User user)
        {
            user.Password=Encrypt.ConvertToEncrypt(user.Password);
            _projeDbContext.User.Add(user);
            _projeDbContext.SaveChanges();
            return user;

        }
    }
}
        