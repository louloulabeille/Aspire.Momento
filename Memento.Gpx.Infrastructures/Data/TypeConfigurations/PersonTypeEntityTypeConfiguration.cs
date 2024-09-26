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
    internal class PersonTypeEntityTypeConfiguration : IEntityTypeConfiguration<PersonType>
    {
        #region methods 
        public void Configure(EntityTypeBuilder<PersonType> builder)
        {
            builder.ToTable("Person");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired()
                .HasAnnotation("SqlServer:Identity", "1, 1");

            builder.HasMany(item => item.GpxMetadataType).WithOne(item => item.Author);
            builder.HasOne(item => item.LinkType).WithMany(item => item.PersonTypes);
        }
        #endregion
    }
}
