using Desafio_Infrastructure.Repository;

namespace Desafio_API.Extensions
{
    public static class ServiceCollectionRepositoriesExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ITipoEnderecoRepository, TipoEnderecoRepository>();
            services.AddScoped<ITipoContatoRepository, TipoContatoRepository>();
            return services;
        }
    }
}
