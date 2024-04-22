
using Desafio_API.Extensions;
using Desafio_Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Desafio_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connection = configuration.GetSection("ConnectionStrings:PostgreConnection").Value;

            builder.Services.AddDbContext<PostgreContext>(options =>
            {
                options.UseNpgsql(connection);
                options.UseLazyLoadingProxies();
            }, 
            ServiceLifetime.Scoped);

            builder.Services.AddRepositories();            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}