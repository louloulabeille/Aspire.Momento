using Memento.Gpx.Domain;
using Memento.Gpx.Infrastructures.Data.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Infrastructures.Data
{
    public class MementoDbContext(DbContextOptions<MementoDbContext> options) : DbContext(options)
    {

        #region Constructeur 
        //public MementoDbContext (DbContextOptions<MementoDbContext> options) : base(options) { }
        #endregion

        #region internal methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GpxTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GpxMetadataTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GpxWptTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LinkTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PersonTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BoundsTypeEntityConfiguration());
        }
        #endregion

        #region protected Override
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = @"Server=localhost\SQLEXPRESS;Database=Memento;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connection);
            //base.OnConfiguring(optionsBuilder);
        }
        #endregion

        #region Properties
        public virtual DbSet<GpxType> GpxTypes { get; set; }
        public virtual DbSet<GpxMetadataType> GpxMetadataTypes { get; set; }
        public virtual DbSet<GpxWptType> GpxWptTypes { get; set; }
        public virtual DbSet<LinkType> LinkTypes { get; set; }
        public virtual DbSet<PersonType> PersonTypes { get; set; }
        public virtual DbSet<BoundsType> BoundsTypes { get; set; }
        #endregion
    }
}
