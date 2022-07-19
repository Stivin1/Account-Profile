using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntityTypeConfig
{
    public class LoggingInfoConfigurationOption : IEntityTypeConfiguration<LoggingInformation>
    {
        public void Configure(EntityTypeBuilder<LoggingInformation> builder)
        {
            builder.HasKey(t => t.id);

            builder.Property(t => t.Name)
                .HasColumnType("nvarchar(max)");
        }
    }
}
