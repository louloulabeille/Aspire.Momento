using AutoMapper;
using Memento.Gpx.Infrastructures.AutoMapper;
using Memento.Gpx.Infrastructures.Data;
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
    }
}
