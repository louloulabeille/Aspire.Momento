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
    internal class GpxWptTypeEntityTypeConfiguration : IEntityTypeConfiguration<GpxWptType>
    {
        #region Methods
        public void Configure(EntityTypeBuilder<GpxWptType> builder)
        {
            builder.ToTable("WayPoint");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired()
                .HasAnnotation("SqlServer:Identity", "1, 1");

            //builder.HasOne(item => item.GpxType).WithMany(item => item.GpxWptTypes);
            builder.HasMany(item => item.LinkTypes).WithMany(item => item.GpxWptTypes);

        }
        #endregion
    }
}
