using AutoMapper;
using Memento.Gpx.Application.WorkOfUnit;
using Memento.Gpx.Infrastructures.AutoMapper;
using Memento.Gpx.Infrastructures.Data;
using Memento.Gpx.Interfaces.WorkOfUnit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace ASP.Net.API.Memento.Instension.Builder
{
    public static class BuilderExtension
    {
        /// <summary>
        /// Méthode d'instension pour instensier le DbContext
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static IServiceCollection ConfigurationDbContextServiceCollection(this IServiceCollection service, WebApplicationBuilder builder)
        {
            string? stringConnection = builder.Configuration.GetConnectionString("MementoDatabase")
                ?? throw new InvalidOperationException("Connection string 'MementoDatabase' not found.");
            ;

            service.AddDbContext<MementoDbContext>(options =>
            {
                options.UseSqlServer(stringConnection);
            });

            return service;
        }
        /// <summary>
        /// instenciation du Mapper et ajout aux services de l'apllication en injection de dépendance
        /// en singleton
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigurationAutoMapperServiceCollection(this IServiceCollection service)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            service.AddSingleton(mapper);
            return service;
        }
        /// <summary>
        /// Méthode d'instansion de paramétrage d'injection des différents classe
        /// WorkOfUnit
        /// </summary>
        /// <param name="builder">WebApplicationBuilder</param>
        /// <returns></returns>
        public static IServiceCollection ConfigurationInjectionWorkOfUnitServiceCollection(this IServiceCollection service)
        {
            service.AddScoped<IGpxTypeWorkOfUnit, GlxTypeWorkOfUnit>();

            return service;
        }
    }
}
