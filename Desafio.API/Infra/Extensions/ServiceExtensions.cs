
using AutoMapper;
using Desafio.API.Infra.AutoMapper;
using Desafio.API.UoWs;
using Desafio.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.API.Infra.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddSQLDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DesafioDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("SqliteConnectionString"), x => x.MigrationsAssembly("Desafio.API"))
            );

            return services;
        }

        public static IServiceCollection RegisterWebApiServices(this IServiceCollection services)
        {
            services.AddScoped<TituloUoW>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingModel());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
