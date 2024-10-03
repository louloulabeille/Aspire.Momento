using AutoMapper;
using Memento.Gpx.Application.WorkOfUnit;
using Memento.Gpx.Infrastructures.AutoMapper;
using Memento.Gpx.Infrastructures.Data;
using Memento.Gpx.Interfaces.WorkOfUnit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace ASP.Net.API.Memento.MiddleWare
{
    public static class BuilderExtension
    {
        /// <summary>
        /// Méthode d'instension pour instensier le DbContext
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static WebApplicationBuilder ConfigurationDbContextServiceCollection (this WebApplicationBuilder builder)
        {
            string? stringConnection = builder.Configuration.GetConnectionString("MementoDatabase")
                ?? throw new InvalidOperationException("Connection string 'MementoDatabase' not found.");
            ;

            builder.Services.AddDbContext<MementoDbContext>(options => {
                options.UseSqlServer(stringConnection);
            });

            return builder;
        }

        public static WebApplicationBuilder ConfigurationAutoMapperServiceCollection(this WebApplicationBuilder builder) {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);
            return builder;
        }
        /// <summary>
        /// Méthode d'instansion de paramétrage d'injection des différents classe
        /// WorkOfUnit
        /// </summary>
        /// <param name="builder">WebApplicationBuilder</param>
        /// <returns></returns>
        public static WebApplicationBuilder ConfigurationInjectionWorkOfUnitServiceCollection(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IGpxTypeWorkOfUnit, GlxTypeWorkOfUnit>();

            return builder;
        }
    }
}
