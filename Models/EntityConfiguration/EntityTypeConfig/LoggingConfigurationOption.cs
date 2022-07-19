using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntityTypeConfig
{
    public class LoggingConfigurationOption : IEntityTypeConfiguration<Logging>
    {
        public void Configure(EntityTypeBuilder<Logging> builder)
        {
            builder.HasKey(t => t.id);

            builder.HasOne(t => t.loggingInformation)
                .WithMany(t => t.loggings)
                .HasForeignKey(t => t.LoggingInformationId);

            builder.Property(t => t.LoggingInformationId)
                .HasColumnType("int");
            builder.Property(t => t.Description)
                .HasColumnType("nvarchar")
                .HasMaxLength(100);
            builder.Property(t => t.DateCreate)
                .HasColumnType("nvarchar")
                .HasMaxLength(100);

        }
    }
}
