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
    internal class BoundsTypeEntityConfiguration : IEntityTypeConfiguration<BoundsType>
    {
        public void Configure(EntityTypeBuilder<BoundsType> builder)
        {
            builder.ToTable("Bounds");
            builder.Property(x => x.Id).IsRequired()
                .HasAnnotation("SqlServer:Identity", "1, 1");
            builder.HasKey(x => x.Id);
            builder.HasOne(item => item.GpxMetadataType).WithOne(item => item.BoundsType);
            
        }
    }
}
