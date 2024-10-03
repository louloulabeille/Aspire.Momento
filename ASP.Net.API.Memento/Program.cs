using AutoMapper;
using Memento.Gpx.Infrastructures.AutoMapper;
using ASP.Net.API.Memento.MiddleWare;
using Microsoft.Extensions.DependencyInjection;
using Memento.Gpx.Interfaces.WorkOfUnit;
using Memento.Gpx.Application.WorkOfUnit;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region configuration des Dbcontext
//string? stringConnection = builder.Configuration.GetConnectionString("MementoDatabase")
//    ?? throw new InvalidOperationException("Connection string 'MementoDatabase' not found."); ;

//builder.Services.AddDbContext<MementoDbContext>(options =>{
//    options.UseSqlServer(stringConnection);
//});
builder.ConfigurationDbContextServiceCollection(); // -- Méthode d'instension
#endregion

#region Appel de AutoMapper
builder.ConfigurationAutoMapperServiceCollection();
//var mapperConfig = new MapperConfiguration(mc =>
//{
//    mc.AddProfile(new MappingProfile());
//});

//IMapper mapper = mapperConfig.CreateMapper();
//builder.Services.AddSingleton(mapper);
#endregion
#region Injection
builder.Services.AddScoped<IGpxTypeWorkOfUnit,GlxTypeWorkOfUnit>();
#endregion

var app = builder.Build();

app.MapDefaultEndpoints();

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
