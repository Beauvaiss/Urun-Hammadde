using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Proje.Business.Abstract;
using Proje.Business.Concrete;
using Proje.DataAcces.Abstract;
using Proje.DataAcces.Concrete;
using System.Text;

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
            var issur = builder.Configuration["JwtConfig:Issuer"];
            var audience = builder.Configuration["JwtConfig:Audience"];
            var signingKey = builder.Configuration["JwtConfig:SigninKey"];

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issur,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey))
                };
            
                });       
            var app = builder.Build();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.Run();
        }
    }
}