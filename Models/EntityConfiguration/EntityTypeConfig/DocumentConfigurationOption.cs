using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntityTypeConfig
{
    public class DocumentConfigurationOption : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder
               .HasKey(t => t.id);

            builder
                .Property(t => t.DateCreate)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder
                .Property(t => t.DateDeleted)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder
                .Property(t => t.IsDeleted)
                .HasColumnType("bit")
                .HasMaxLength(1)
                .HasDefaultValue(0);

            builder
                .HasOne(t => t.DocumentType)
                .WithMany(t => t.Document)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(t => t.User)
                .WithMany(t => t.Documents)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
