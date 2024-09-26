using Memento.Gpx.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Infrastructures.Data.TypeConfigurations
{
    internal class GpxTypeEntityTypeConfiguration : IEntityTypeConfiguration<GpxType>
    {
        #region Methods
        public void Configure(EntityTypeBuilder<GpxType> builder)
        {
            builder.ToTable("Gpx");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired()
                .HasAnnotation("SqlServer:Identity", "1, 1");

            builder.Property(x => x.Creator).IsRequired();
            builder.Property(x => x.Version).IsRequired();

            #region Liaison
            builder.HasOne(item => item.GpxMetadataType).WithOne(item => item.GpxType)
                .HasForeignKey<GpxMetadataType>(item => item.GpxTypeId)
                .HasPrincipalKey<GpxType>(item => item.Id);

            builder.HasMany(item => item.GpxWptTypes).WithOne(item => item.GpxType);
            #endregion
        }
        #endregion
    }
}
