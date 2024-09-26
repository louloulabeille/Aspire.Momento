// See https://aka.ms/new-console-template for more information
using Memento.Gpx.Infrastructures.Data;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var option = new DbContextOptions<MementoDbContext>();
var dbcontext = new MementoDbContext(option);

var toto = dbcontext.GpxTypes;
foreach (var type in toto)
{
    Console.WriteLine(type.Version + " " + type.Creator);
}
