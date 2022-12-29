using Microsoft.Extensions.Hosting;
using Proje.Business.Abstract;
using Proje.Business.Concrete;
using Proje.DataAcces.Abstract;
using Proje.DataAcces.Concrete;

namespace Proje.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddSingleton<IProjeRepository, ProjeRepository>();
            builder.Services.AddSingleton<IProjeService, ProjeManager>();
            builder.Services.AddSwaggerDocument();
            var app = builder.Build();
            app.MapControllers();
            app.UseOpenApi();
            app.UseSwaggerUi3();


            app.Run();
        }
    }
}