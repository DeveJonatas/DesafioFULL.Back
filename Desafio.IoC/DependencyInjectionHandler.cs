using Desafio.BLL;
using Desafio.BLL.Infra;
using Desafio.Repository;
using Desafio.Repository.Infra;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.IoC
{
    public static class DependencyInjectionHandler
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<DesafioDbContext>();

            services.AddScoped<ITituloRepository, TituloRepository>();

            services.AddScoped<ITituloBLL, TituloBLL>();

            return services;
        }
    }
}
