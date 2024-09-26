using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Infrastructures.Data
{
    internal class MementoDbContextFactory : IDesignTimeDbContextFactory<MementoDbContext>
    {
        public MementoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MementoDbContext>();
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Memento;Trusted_Connection=True;TrustServerCertificate=True;");
            return new MementoDbContext(optionsBuilder.Options);
        }
    }
}
