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
    internal class LinkTypeEntityTypeConfiguration : IEntityTypeConfiguration<LinkType>
    {
        #region Methods
        public void Configure(EntityTypeBuilder<LinkType> builder)
        {
            builder.ToTable("Link");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired()
                .HasAnnotation("SqlServer:Identity", "1, 1");
        }
        #endregion 
    }
}
