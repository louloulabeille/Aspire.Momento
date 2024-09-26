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
    internal class GpxMetadataTypeEntityTypeConfiguration : IEntityTypeConfiguration<GpxMetadataType>
    {
        #region Methods
        public void Configure(EntityTypeBuilder<GpxMetadataType> builder)
        {
            builder.ToTable("MetaData");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired()
                .HasAnnotation("SqlServer:Identity", "1, 1");

            //builder.HasOne(item => item.GpxType).WithOne(item => item.GpxMetadataType);
            builder.HasMany(item => item.LinkTypes).WithMany(item => item.GpxMetadataTypes);
            builder.HasOne(item => item.Author).WithMany(item => item.GpxMetadataType);
            builder.HasOne(item => item.BoundsType).WithOne(item => item.GpxMetadataType);

        }
        #endregion
    }
}
