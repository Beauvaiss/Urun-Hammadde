using Microsoft.EntityFrameworkCore;
using Proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DataAcces
{
    public class ProjeDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=localhost;Database=ProjeDb2;Username=postgres;Password=12358"); ;
        }
        public DbSet<Urun> Urun { get; set; }
        public DbSet<Hammadde> Hammadde { get; set; }
        public DbSet<Stok> Stok { get; set; }
        public DbSet<User> User { get; set; }
    }
}
